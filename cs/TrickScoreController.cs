using System;
using System.Collections.Generic;
using Harmony12;
using UnityEngine;

namespace SFToolKit
{
    /// <summary>
    /// Handles trick-score tracking and HUD rendering.
    /// </summary>
    public class TrickScoreController : MonoBehaviour
    {
        private const int MaxEntries = 5;

        private static TrickScoreController _instance;

        private readonly List<TrickEntry> recentEntries = new List<TrickEntry>();

        private bool lineActive;
        private bool displayActive;
        private int currentLineScore;
        private int lastLineScore;
        private float lineEndTime = -999f;

        [SerializeField] private bool enabledByUser = false;
        [SerializeField] private float displayDuration = 4f;
        [SerializeField] private float fadeDuration = 1.5f;

        public static TrickScoreController Instance => _instance;

        public bool Enabled
        {
            get => enabledByUser;
            set
            {
                enabledByUser = value;
                if (!enabledByUser)
                {
                    ClearAll();
                }
            }
        }

        public float DisplayDuration
        {
            get => displayDuration;
            set => displayDuration = Mathf.Max(0f, value);
        }

        public float FadeDuration
        {
            get => fadeDuration;
            set => fadeDuration = Mathf.Max(0f, value);
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                return;
            }
            _instance = this;
        }

        private void Update()
        {
            if (!enabledByUser)
            {
                ClearAll();
                return;
            }

            if (!lineActive && displayActive)
            {
                float elapsed = Time.time - lineEndTime;
                if (elapsed > displayDuration + fadeDuration)
                {
                    displayActive = false;
                    recentEntries.Clear();
                    currentLineScore = 0;
                    lastLineScore = 0;
                }
            }
        }

        private void OnGUI()
        {
            if (!enabledByUser || !displayActive)
                return;

            if (!lineActive)
            {
                float elapsed = Time.time - lineEndTime;
                if (elapsed > displayDuration + fadeDuration)
                    return;
            }

            float alpha = CalculateAlpha();
            if (alpha <= 0f)
                return;

            Color prevColor = GUI.color;
            GUI.color = new Color(1f, 1f, 1f, alpha);

            float width = 300f;
            float lineHeight = 22f;
            int count = recentEntries.Count;
            float height = 30f + lineHeight * (Mathf.Max(count, 1) + 1);
            float x = Screen.width - width - 30f;
            float y = 80f;

            GUI.Box(new Rect(x, y, width, height), GUIContent.none);

            string header = lineActive ? $"Line Score: {currentLineScore}" : $"Line Score: {lastLineScore}";
            GUI.Label(new Rect(x + 12f, y + 8f, width - 24f, 20f), header);

            for (int i = 0; i < count; i++)
            {
                // Display newest trick at the top of the stack.
                TrickEntry entry = recentEntries[count - 1 - i];
                float entryY = y + 32f + lineHeight * i;
                GUI.Label(new Rect(x + 18f, entryY, width - 36f, lineHeight), $"{entry.Name}  +{entry.Points}");
            }

            GUI.color = prevColor;
        }

        private float CalculateAlpha()
        {
            if (lineActive)
                return 1f;

            float elapsed = Time.time - lineEndTime;
            if (elapsed <= displayDuration)
                return 1f;
            if (fadeDuration <= 0f)
                return 0f;

            float t = Mathf.Clamp01((elapsed - displayDuration) / fadeDuration);
            return 1f - t;
        }

        private void ClearAll()
        {
            lineActive = false;
            displayActive = false;
            currentLineScore = 0;
            lastLineScore = 0;
            recentEntries.Clear();
        }

        private void HandleTrick(string trickName, int points)
        {
            if (!enabledByUser)
                return;

            if (!lineActive)
            {
                recentEntries.Clear();
                currentLineScore = 0;
                lastLineScore = 0;
            }

            lineActive = true;
            displayActive = true;
            lineEndTime = -999f;
            currentLineScore += points;

            recentEntries.Add(new TrickEntry(trickName, points));
            if (recentEntries.Count > MaxEntries)
            {
                recentEntries.RemoveAt(0);
            }
        }

        private void HandleLand(PlayerScoring scoring)
        {
            if (!enabledByUser || !lineActive)
                return;

            if (scoring != null && scoring.scooterController != null)
            {
                var controller = scoring.scooterController;
                if (controller.Manual || controller.NoseManual || controller.FootJam)
                {
                    return;
                }
            }

            lineActive = false;
            lastLineScore = currentLineScore;
            lineEndTime = Time.time;
        }

        public static void RegisterTrick(string trickName, int points)
        {
            _instance?.HandleTrick(trickName, points);
        }

        public static void NotifyLand(PlayerScoring scoring)
        {
            _instance?.HandleLand(scoring);
        }

        public static bool IsAvailable => _instance != null;

        public IReadOnlyList<TrickEntry> RecentEntries => recentEntries;

        public bool LineActive => lineActive;

        public int CurrentLineScore => currentLineScore;

        public int LastLineScore => lastLineScore;

        public readonly struct TrickEntry
        {
            public TrickEntry(string name, int points)
            {
                Name = name;
                Points = points;
            }

            public string Name { get; }
            public int Points { get; }
        }

        /// <summary>
        /// Harmony patch: hook PlayerScoring.AddScore.
        /// </summary>
        [HarmonyPatch(typeof(PlayerScoring), "AddScore")]
        private static class PlayerScoringAddScorePatch
        {
            [HarmonyPostfix]
            private static void Postfix(string trickName, int points)
            {
                if (TrickScoreController.IsAvailable)
                {
                    RegisterTrick(trickName, points);
                }
            }
        }

        /// <summary>
        /// Harmony patch: hook PlayerScoring.Land.
        /// </summary>
        [HarmonyPatch(typeof(PlayerScoring), "Land")]
        private static class PlayerScoringLandPatch
        {
            [HarmonyPostfix]
            private static void Postfix(PlayerScoring __instance)
            {
                if (TrickScoreController.IsAvailable)
                {
                    NotifyLand(__instance);
                }
            }
        }
    }
}
