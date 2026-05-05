using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using SFToolKit;

/// <summary>
/// Scooter Flow menu
/// </summary>
public class SFMenu : MonoBehaviour
{
    // Set these before building. The section classes remain compiled into the DLL;
    // these flags only control whether they are added to the rendered menu.
    private static readonly bool ShowConnectedPlayers = false;
    private static readonly bool ShowScooterChanging = false;
    private static readonly bool ShowSoundboard = false;

    [Header("UI Settings")]
    public Vector2 windowSize = new Vector2(640, 520);

    private Rect windowRect;
    private bool isMenuOpen;

    // UI layout constants
    private const float TitleBarHeight = 20f;
    private const float ContentPadding = 12f;
    private const float EstimatedRowHeight = 26f;
    private const float ColumnSpacing = 12f;

    // Sections shown in the menu
    private List<TweakSection> sections;

    // Hotkey to open/close the menu when the game is hiding the cursor
    private KeyCode toggleKey = KeyCode.F1;

    // We’ll restore whatever the game was doing with the cursor when we close the menu
    private bool prevCursorVisible;
    private CursorLockMode prevCursorLock;

    [Header("Auto-size")]
    [Range(0.50f, 0.95f)]
    public float maxScreenHeightPercent = 0.90f;
    public float minScreenMargin = 5f;        

    private void SetMenuOpen(bool open)
    {
        if (open == isMenuOpen) return;

        if (open)
        {
            // remember current cursor state to restore later
            prevCursorVisible = Cursor.visible;
            prevCursorLock = Cursor.lockState;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isMenuOpen = true;
        }
        else
        {
            isMenuOpen = false;
            // restore the game’s cursor state
            Cursor.visible = prevCursorVisible;
            Cursor.lockState = prevCursorLock;
        }
    }

    private void Start()
    {
        windowRect = new Rect(10, 10, windowSize.x, windowSize.y);

        sections = BuildSections();
    }

    private static List<TweakSection> BuildSections()
    {
        var menuSections = new List<TweakSection>();

        if (ShowConnectedPlayers)
            menuSections.Add(new PlayerRosterSection());

        menuSections.Add(new GravitySection());
        menuSections.Add(new HopSection());
        menuSections.Add(new TimeSpeedSection());
        menuSections.Add(new InvectorSection());
        menuSections.Add(new WheelSection());
        menuSections.Add(new PushSection());
        menuSections.Add(new PumpSection());

        if (ShowScooterChanging)
            menuSections.Add(new NetworkScooterSection());

        if (ShowSoundboard)
            menuSections.Add(new SoundboardSection());

        return menuSections;
    }

    private void Update()
    {
        // Open/close via hotkey so you don't need to click the tiny button
        if (Input.GetKeyDown(toggleKey))
            SetMenuOpen(!isMenuOpen);

        // Let each section try to find components (and capture originals).
        if (sections != null)
            foreach (var section in sections)
                section.FindComponents();
    }

    private void OnGUI()
    {
        if (!isMenuOpen)
        {
            // Small open button (optional); hotkey also works
            if (GUI.Button(new Rect(10, 10, 30, 30), ">"))
                SetMenuOpen(true);
            return;
        }

        windowRect = GUI.Window(0, windowRect, DrawContents, "SFToolKit v2.0.2");
    }

    private void DrawContents(int id)
    {
        float contentBottom = 0f; // measured right before we add the footer

        // Decide columns up front so we avoid scrolling.
        int totalRows = GetTotalRowCount();
        float targetMaxContentHeight = Screen.height * maxScreenHeightPercent - (TitleBarHeight + ContentPadding + minScreenMargin);
        float availableHeight = Mathf.Max(200f, targetMaxContentHeight);
        int neededColumns = Mathf.CeilToInt(((totalRows * EstimatedRowHeight) + ContentPadding * 2f) / availableHeight);
        int columns = Mathf.Clamp(neededColumns, 1, 3);

        // Build balanced columns (greedy by current row height)
        var cols = BuildBalancedColumns(columns);

        GUILayout.BeginVertical();

        /***************************************
         *  • Sections laid out in columns     *
         ***************************************/
        if (cols.Count <= 1)
        {
            // Single column
            GUILayout.BeginVertical();
            foreach (var s in cols[0])
                s.DrawGUI();
            GUILayout.EndVertical();
        }
        else
        {
            GUILayout.BeginHorizontal();
            for (int c = 0; c < cols.Count; c++)
            {
                GUILayout.BeginVertical(GUILayout.ExpandWidth(true));
                foreach (var s in cols[c])
                    s.DrawGUI();
                GUILayout.EndVertical();

                if (c != cols.Count - 1)
                    GUILayout.Space(ColumnSpacing);
            }
            GUILayout.EndHorizontal();
        }

        /***************************************
         *  • Footer (Reset/Close)             *
         ***************************************/
        // Record the bottom of real content *before* FlexibleSpace pushes the footer down
        if (Event.current.type == EventType.Repaint)
            contentBottom = GUILayoutUtility.GetLastRect().yMax;

        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Reset All", GUILayout.Width(90)))
            ResetAllSections();

        if (GUILayout.Button("Close", GUILayout.Width(60)))
            SetMenuOpen(false);

        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        // Allow dragging by the title bar
        GUI.DragWindow(new Rect(0, 0, 10000, TitleBarHeight));

        /***************************************
         *  • Auto-size & screen clamp         *
         ***************************************/
        if (Event.current.type == EventType.Repaint)
        {
            // Width is based on slider layout
            float controlWidth = (180f + MenuDisplaySettings.SliderWidth + 68f);
            float desiredWidth = columns * controlWidth + (columns - 1) * ColumnSpacing + ContentPadding * 2f;
            windowRect.width = Mathf.Round(desiredWidth);

            // Height: use measured content bottom + estimated footer (taken before FlexibleSpace)
            float desiredHeight = contentBottom  + ContentPadding + TitleBarHeight;

            // Don't let the window go to full height; keep a margin and obey the max percent cap
            float maxByPercent = Screen.height * maxScreenHeightPercent;
            float maxHeight = Mathf.Min(Screen.height - minScreenMargin, maxByPercent);
            windowRect.height = Mathf.Round(Mathf.Min(desiredHeight, maxHeight));

            // Keep window fully on-screen
            windowRect.x = Mathf.Clamp(windowRect.x, 0f, Mathf.Max(0f, Screen.width - windowRect.width));
            windowRect.y = Mathf.Clamp(windowRect.y, 0f, Mathf.Max(0f, Screen.height - windowRect.height));
        }
    }

    private int GetTotalRowCount()
    {
        if (sections == null) return 0;
        int sum = 0;
        foreach (var s in sections)
            sum += Mathf.Max(1, s.GetRowCount());
        return sum;
    }

    private List<List<TweakSection>> BuildBalancedColumns(int columns)
    {
        var result = new List<List<TweakSection>>(columns);
        var heights = new List<int>(columns);
        for (int i = 0; i < columns; i++) { result.Add(new List<TweakSection>()); heights.Add(0); }

        if (sections == null || sections.Count == 0) return result;

        foreach (var s in sections)
        {
            // place into the column with the smallest current row count
            int best = 0;
            int bestH = heights[0];
            for (int c = 1; c < columns; c++)
            {
                if (heights[c] < bestH)
                {
                    best = c; bestH = heights[c];
                }
            }
            result[best].Add(s);
            heights[best] += Mathf.Max(1, s.GetRowCount());
        }
        return result;
    }

    private void ResetAllSections()
    {
        if (sections == null) return;
        foreach (var s in sections)
            s?.ResetToDefaults();
    }
}

/* ========================= Shared UI Helpers ========================= */

public abstract class TweakSection
{
    public abstract void FindComponents();
    public abstract void DrawGUI();
    public abstract void ResetToDefaults();

    /// <summary>
    /// Approximate number of horizontal rows drawn by this section
    /// (used for automatic multi-column layout; does not affect drawing).
    /// </summary>
    public abstract int GetRowCount();
}

public static class MenuDisplaySettings
{
    public const float SliderWidth = 160f;
}

[Serializable]
public struct SliderRange
{
    public float Min;
    public float Max;

    public SliderRange(float min, float max)
    {
        if (min > max) { float t = min; min = max; max = t; }
        Min = min; Max = max;
    }
}

public static class SliderRanges
{
    public static readonly SliderRange GravityY = new SliderRange(-11f, -8f);
    public static readonly SliderRange HopTime = new SliderRange(0.01f, 0.3f);
    public static readonly SliderRange HopNormalStrength = new SliderRange(145000f, 290000f);
    public static readonly SliderRange HopLowStrength = new SliderRange(110000f, 220000f);
    public static readonly SliderRange HopNoseManualStrength = new SliderRange(120000f, 240000f);
    public static readonly SliderRange HopFootJamUp = new SliderRange(130000f, 260000f);
    public static readonly SliderRange HopFootJamForward = new SliderRange(90000f, 180000f);
    public static readonly SliderRange TimeSlowMotion = new SliderRange(0.30f, 1.5f);
    public static readonly SliderRange InvectorTrickSpeed = new SliderRange(0.1f, 1.8f);
    public static readonly SliderRange WheelMaxMotorTorque = new SliderRange(20f, 5000f);
    public static readonly SliderRange WheelStopDrag = new SliderRange(0f, 20f);
    public static readonly SliderRange PushDelay = new SliderRange(0f, 100f);
    public static readonly SliderRange PushDuration = new SliderRange(0f, 100f);
    public static readonly SliderRange PushInitialForce = new SliderRange(1100f, 4400f);
    public static readonly SliderRange PumpTime = new SliderRange(0.1f, 10f);
    public static readonly SliderRange PumpForce = new SliderRange(2500f, 5000f);
}

/* ========================= Sections ========================= */

/// <summary>
/// Displays the connected player roster.
/// </summary>
public class PlayerRosterSection : TweakSection
{
    private readonly List<PlayerRow> rows = new List<PlayerRow>();
    private float nextRefreshTime;
    private Vector2 scrollPosition;
    private bool lookedUpLocalSteamId;
    private ulong cachedLocalSteamId;
    private bool assumeClientIdsAreSteam;

    public override void FindComponents()
    {
        float now = Time.unscaledTime;
        if (now < nextRefreshTime)
            return;

        nextRefreshTime = now + 1f;

        rows.Clear();

        if (!lookedUpLocalSteamId)
        {
            lookedUpLocalSteamId = true;
            NameTagHelper.TryGetLocalSteamId(out cachedLocalSteamId);
        }

        var snapshots = NameTagHelper.CapturePlayerSnapshots();
        if (snapshots == null || snapshots.Count == 0)
            return;

        foreach (var snapshot in snapshots)
        {
            var row = new PlayerRow
            {
                IsLocal = snapshot.IsLocalOwner,
                NetworkObjectId = snapshot.NetworkObjectId,
                ClientIdValue = snapshot.OwnerClientId
            };

            string displayName = snapshot.DisplayName;
            if (string.IsNullOrWhiteSpace(displayName))
                displayName = snapshot.NetworkObjectId != 0UL ? $"Player {snapshot.NetworkObjectId}" : "Player";
            row.DisplayName = displayName;

            ulong possibleSteamId = 0UL;
            if (snapshot.IsLocalOwner && cachedLocalSteamId != 0UL)
            {
                possibleSteamId = cachedLocalSteamId;
            }
            else if (LooksLikeSteamId(snapshot.OwnerClientId) || (assumeClientIdsAreSteam && snapshot.OwnerClientId > 0UL))
            {
                possibleSteamId = snapshot.OwnerClientId;
            }

            if (possibleSteamId != 0UL)
            {
                row.SteamIdText = possibleSteamId.ToString();
                if (NameTagHelper.TryGetPersonaName(possibleSteamId, out var personaName) &&
                    !string.IsNullOrWhiteSpace(personaName) &&
                    !string.Equals(personaName, row.DisplayName, System.StringComparison.Ordinal))
                {
                    row.PersonaName = personaName;
                }
            }
            else
            {
                row.SteamIdText = snapshot.IsLocalOwner && cachedLocalSteamId == 0UL ? "Steam offline" : "Unknown";
            }

            if (snapshot.Tag == null)
                row.Status = "Awaiting player object";

            rows.Add(row);
        }

        rows.Sort((a, b) =>
        {
            if (a.IsLocal && !b.IsLocal) return -1;
            if (!a.IsLocal && b.IsLocal) return 1;
            return string.Compare(a.DisplayName, b.DisplayName, System.StringComparison.Ordinal);
        });
    }

    public override void DrawGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Connected Players", GUILayout.Width(180));
        bool newAssumption = GUILayout.Toggle(assumeClientIdsAreSteam, "Treat client IDs as Steam IDs", GUILayout.Width(210));
        if (newAssumption != assumeClientIdsAreSteam)
        {
            assumeClientIdsAreSteam = newAssumption;
            nextRefreshTime = 0f;
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        if (rows.Count == 0)
        {
            GUILayout.Label("No players detected yet.");
            GUILayout.Space(4);
            return;
        }

        float targetHeight = Mathf.Clamp(rows.Count * 56f, 140f, 320f);
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(targetHeight));

        foreach (var row in rows)
        {
            GUILayout.BeginVertical("box");
            string nameLine = row.IsLocal ? $"{row.DisplayName} (You)" : row.DisplayName;
            GUILayout.Label(nameLine);

            if (!string.IsNullOrEmpty(row.PersonaName))
                GUILayout.Label($"Persona: {row.PersonaName}");

            GUILayout.Label($"Steam ID: {row.SteamIdText}");
            GUILayout.Label($"Client ID: {row.ClientIdValue}   Network Obj: {(row.NetworkObjectId != 0UL ? row.NetworkObjectId.ToString() : "—")}");

            if (!string.IsNullOrEmpty(row.Status))
                GUILayout.Label(row.Status);

            GUILayout.EndVertical();
        }

        GUILayout.EndScrollView();
        GUILayout.Space(4);
    }

    public override void ResetToDefaults()
    {
        // No toggles to reset.
    }

    public override int GetRowCount() => Mathf.Max(4, rows.Count + 2);

    private static bool LooksLikeSteamId(ulong value)
    {
        return value >= 70000000000000000UL && value <= 80000000000000000UL;
    }

    private struct PlayerRow
    {
        public string DisplayName;
        public string PersonaName;
        public string SteamIdText;
        public ulong ClientIdValue;
        public ulong NetworkObjectId;
        public bool IsLocal;
        public string Status;
    }
}

/// <summary>
/// Cycles through global one-shot sounds so every client hears them.
/// </summary>
public class SoundboardSection : TweakSection
{
    private const float LookupCooldown = 2f;
    private const float CycleInterval = 1f;

    private Component localSync;
    private AudioSource[] oneShotSources;
    private string[] sourceLabels = Array.Empty<string>();

    private Type multiSyncType;
    private PropertyInfo isOwnerProperty;
    private FieldInfo prevOneShotField;
    private float nextLookup;

    private bool cycleEnabled;
    private float nextCycleTime;
    private int currentIndex;
    private string lastSoundLabel = "None";

    public override void FindComponents()
    {
        if (Time.unscaledTime >= nextLookup)
        {
            nextLookup = Time.unscaledTime + LookupCooldown;
            LocateLocalSync();
        }

        if (cycleEnabled && localSync != null && oneShotSources != null && oneShotSources.Length > 0)
        {
            if (Time.unscaledTime >= nextCycleTime)
            {
                TriggerNextSound();
                nextCycleTime = Time.unscaledTime + CycleInterval;
            }
        }
    }

    public override void DrawGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Soundboard", GUILayout.Width(180));
        bool newCycle = GUILayout.Toggle(cycleEnabled, "Cycle all one-shots", GUILayout.Width(180));
        if (newCycle != cycleEnabled)
        {
            cycleEnabled = newCycle;
            nextCycleTime = Time.unscaledTime + 0.1f;
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        if (localSync == null)
        {
            GUILayout.Label("Local network controller not found yet.");
            GUILayout.Space(4);
            return;
        }

        if (oneShotSources == null || oneShotSources.Length == 0)
        {
            GUILayout.Label("No one-shot sounds discovered.");
            GUILayout.Space(4);
            return;
        }

        GUILayout.Label($"Sources: {oneShotSources.Length}");
        GUILayout.Label($"Last played: {lastSoundLabel}");

        if (GUILayout.Button("Play next now", GUILayout.Width(140)))
        {
            TriggerNextSound();
            nextCycleTime = Time.unscaledTime + CycleInterval;
        }

        GUILayout.BeginVertical("box");
        for (int i = 0; i < sourceLabels.Length; i++)
        {
            string prefix = (i == currentIndex ? ">" : " ");
            GUILayout.Label($"{prefix} {sourceLabels[i]}");
        }
        GUILayout.EndVertical();

        GUILayout.Space(4);
    }

    public override void ResetToDefaults()
    {
        cycleEnabled = false;
    }

    public override int GetRowCount() => 5;

    private void LocateLocalSync()
    {
        if (multiSyncType == null)
        {
            multiSyncType = ResolveType("MultiTransformSyncLiteCleaned");
        }
        if (multiSyncType == null)
        {
            localSync = null;
            oneShotSources = null;
            sourceLabels = Array.Empty<string>();
            return;
        }

        if (isOwnerProperty == null)
        {
            isOwnerProperty = multiSyncType.GetProperty("IsOwner", BindingFlags.Instance | BindingFlags.Public);
        }
        if (prevOneShotField == null)
        {
            prevOneShotField = multiSyncType.GetField("prevOneShotPlaying", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        UnityEngine.Object[] found = UnityEngine.Object.FindObjectsOfType(multiSyncType);
        Component owned = null;
        foreach (var obj in found)
        {
            if (obj is Component component)
            {
                if (IsOwner(component))
                {
                    owned = component;
                    break;
                }
            }
        }

        localSync = owned;
        if (localSync == null)
        {
            oneShotSources = null;
            sourceLabels = Array.Empty<string>();
            return;
        }

        var field = multiSyncType.GetField("oneShotSounds", BindingFlags.Instance | BindingFlags.Public);
        if (field != null)
        {
            try
            {
                oneShotSources = field.GetValue(localSync) as AudioSource[];
            }
            catch
            {
                oneShotSources = null;
            }
        }
        else
        {
            oneShotSources = null;
        }

        if (oneShotSources != null)
        {
            sourceLabels = new string[oneShotSources.Length];
            for (int i = 0; i < sourceLabels.Length; i++)
            {
                var src = oneShotSources[i];
                string clipName = src != null && src.clip != null ? src.clip.name : "<null>";
                sourceLabels[i] = $"[{i}] {clipName}";
            }
        }
        else
        {
            sourceLabels = Array.Empty<string>();
        }

        currentIndex = 0;
    }

    private bool IsOwner(Component component)
    {
        if (component == null || isOwnerProperty == null)
            return false;

        try
        {
            object value = isOwnerProperty.GetValue(component, null);
            return value is bool result && result;
        }
        catch
        {
            return false;
        }
    }

    private void TriggerNextSound()
    {
        if (oneShotSources == null || oneShotSources.Length == 0)
            return;

        int attempts = oneShotSources.Length;
        for (int i = 0; i < attempts; i++)
        {
            int index = (currentIndex + i) % oneShotSources.Length;
            var source = oneShotSources[index];
            if (TryPlaySource(source, index))
            {
                currentIndex = (index + 1) % oneShotSources.Length;
                return;
            }
        }
    }

    private bool TryPlaySource(AudioSource source, int index)
    {
        if (source == null)
            return false;
        if (source.clip == null)
            return false;

        if (oneShotSources != null)
        {
            for (int i = 0; i < oneShotSources.Length; i++)
            {
                if (oneShotSources[i] != null)
                    oneShotSources[i].Stop();
            }
        }

        ForceResetPrevOneShot();

        source.time = 0f;
        source.Play();

        lastSoundLabel = index >= 0 && index < sourceLabels.Length ? sourceLabels[index] : $"[{index}]";
        return true;
    }

    private static Type ResolveType(string typeName)
    {
        if (string.IsNullOrEmpty(typeName))
            return null;

        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            Type found = null;
            try { found = assembly.GetType(typeName); }
            catch { }
            if (found != null)
                return found;
        }
        return null;
    }

    private void ForceResetPrevOneShot()
    {
        if (localSync == null || prevOneShotField == null)
            return;

        try
        {
            prevOneShotField.SetValue(localSync, false);
        }
        catch
        {
        }
    }
}

/// <summary>
/// Physics: Gravity
/// </summary>
public class GravitySection : TweakSection
{
    private bool hasCapturedOriginal = false;
    private Vector3 originalGravity;

    public override void FindComponents()
    {
        if (!hasCapturedOriginal)
        {
            originalGravity = Physics.gravity;
            hasCapturedOriginal = true;
        }
    }

    public override void DrawGUI()
    {
        GUILayout.BeginHorizontal();
        float currentGravity = Physics.gravity.y;
        GUILayout.Label($"Gravity: {currentGravity:F1}", GUILayout.Width(180));

        var range = SliderRanges.GravityY;
        float newGravity = GUILayout.HorizontalSlider(currentGravity, range.Min, range.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
        if (!Mathf.Approximately(newGravity, currentGravity))
        {
            var g = Physics.gravity;
            g.y = Mathf.Clamp(newGravity, range.Min, range.Max);
            Physics.gravity = g;
        }

        if (GUILayout.Button("Reset", GUILayout.Width(60)) && hasCapturedOriginal)
            Physics.gravity = originalGravity;

        GUILayout.EndHorizontal();
        GUILayout.Space(4);
    }

    public override void ResetToDefaults()
    {
        if (hasCapturedOriginal)
            Physics.gravity = originalGravity;
    }

    public override int GetRowCount() => 1;
}

/// <summary>
/// Hop & Sub-Settings
/// </summary>
public class HopSection : TweakSection
{
    private Hop hop;
    private HopTimerSettings hopTimerSettings;
    private NormalHopSettings normalHopSettings;
    private LowHopSettings lowHopSettings;
    private NoseManualHopSettings noseManualHopSettings;
    private FootJamHopSettings footJamHopSettings;

    // original values
    private bool capturedTimer = false; private float originalHopTime;
    private bool capturedNormal = false; private float originalNormalStrength;
    private bool capturedLow = false; private float originalLowStrength;
    private bool capturedNose = false; private float originalNoseManualStrength;
    private bool capturedFootJam = false; private float originalFootJamUp; private float originalFootJamFwd;

    public override void FindComponents()
    {
        var foundHop = GameObject.FindObjectOfType<Hop>();
        if (foundHop == null) return;

        hop = foundHop;

        if (hop.hopTimerSettings != null)
        {
            if (!capturedTimer)
            {
                originalHopTime = hop.hopTimerSettings.hopTime;
                capturedTimer = true;
            }
            hopTimerSettings = hop.hopTimerSettings;
        }

        if (hop.normalHopSettings != null)
        {
            if (!capturedNormal)
            {
                originalNormalStrength = hop.normalHopSettings.strength;
                capturedNormal = true;
            }
            normalHopSettings = hop.normalHopSettings;
        }

        if (hop.lowHopSettings != null)
        {
            if (!capturedLow)
            {
                originalLowStrength = hop.lowHopSettings.strength;
                capturedLow = true;
            }
            lowHopSettings = hop.lowHopSettings;
        }

        if (hop.noseManualHopSettings != null)
        {
            if (!capturedNose)
            {
                originalNoseManualStrength = hop.noseManualHopSettings.strength;
                capturedNose = true;
            }
            noseManualHopSettings = hop.noseManualHopSettings;
        }

        if (hop.footJamHopSettings != null)
        {
            if (!capturedFootJam)
            {
                originalFootJamUp = hop.footJamHopSettings.upwardStrength;
                originalFootJamFwd = hop.footJamHopSettings.forwardStrength;
                capturedFootJam = true;
            }
            footJamHopSettings = hop.footJamHopSettings;
        }
    }

    public override void DrawGUI()
    {
        if (hop == null)
        {
            GUILayout.Label("Hop component not found");
            GUILayout.Space(4);
            return;
        }

        // -- HopTimerSettings --
        if (hopTimerSettings != null)
        {
            GUILayout.BeginHorizontal();
            float current = hopTimerSettings.hopTime;
            GUILayout.Label($"Hop Time: {current:F2}", GUILayout.Width(180));
            var range = SliderRanges.HopTime;
            float newValue = GUILayout.HorizontalSlider(current, range.Min, range.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
            if (!Mathf.Approximately(newValue, current))
                hopTimerSettings.hopTime = Mathf.Clamp(newValue, range.Min, range.Max);

            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedTimer)
                hopTimerSettings.hopTime = originalHopTime;
            GUILayout.EndHorizontal();
        }
        else GUILayout.Label("  (HopTimerSettings not found)");
        GUILayout.Space(4);

        // -- NormalHopSettings --
        if (normalHopSettings != null)
        {
            GUILayout.BeginHorizontal();
            float currentStrength = normalHopSettings.strength;
            GUILayout.Label($"NormalHop Height: {currentStrength:F1}", GUILayout.Width(180));
            var range = SliderRanges.HopNormalStrength;
            float newValue = GUILayout.HorizontalSlider(currentStrength, range.Min, range.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
            if (!Mathf.Approximately(newValue, currentStrength))
                normalHopSettings.strength = Mathf.Clamp(newValue, range.Min, range.Max);

            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedNormal)
                normalHopSettings.strength = originalNormalStrength;
            GUILayout.EndHorizontal();
        }
        else GUILayout.Label("  (NormalHopSettings not found)");
        GUILayout.Space(4);

        // -- LowHopSettings --
        if (lowHopSettings != null)
        {
            GUILayout.BeginHorizontal();
            float currentStrength = lowHopSettings.strength;
            GUILayout.Label($"LowHop Height: {currentStrength:F1}", GUILayout.Width(180));
            var range = SliderRanges.HopLowStrength;
            float newValue = GUILayout.HorizontalSlider(currentStrength, range.Min, range.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
            if (!Mathf.Approximately(newValue, currentStrength))
                lowHopSettings.strength = Mathf.Clamp(newValue, range.Min, range.Max);

            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedLow)
                lowHopSettings.strength = originalLowStrength;
            GUILayout.EndHorizontal();
        }
        else GUILayout.Label("  (LowHopSettings not found)");
        GUILayout.Space(4);

        // -- NoseManualHopSettings --
        if (noseManualHopSettings != null)
        {
            GUILayout.BeginHorizontal();
            float currentStrength = noseManualHopSettings.strength;
            GUILayout.Label($"NoseHop Height: {currentStrength:F1}", GUILayout.Width(180));
            var range = SliderRanges.HopNoseManualStrength;
            float newValue = GUILayout.HorizontalSlider(currentStrength, range.Min, range.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
            if (!Mathf.Approximately(newValue, currentStrength))
                noseManualHopSettings.strength = Mathf.Clamp(newValue, range.Min, range.Max);

            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedNose)
                noseManualHopSettings.strength = originalNoseManualStrength;
            GUILayout.EndHorizontal();
        }
        else GUILayout.Label("  (NoseManualHopSettings not found)");
        GUILayout.Space(4);

        // -- FootJamHopSettings --
        if (footJamHopSettings != null)
        {
            // Upward
            GUILayout.BeginHorizontal();
            float currentUp = footJamHopSettings.upwardStrength;
            GUILayout.Label($"FootJam Up: {currentUp:F1}", GUILayout.Width(180));
            var rangeUp = SliderRanges.HopFootJamUp;
            float newValueUp = GUILayout.HorizontalSlider(currentUp, rangeUp.Min, rangeUp.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
            if (!Mathf.Approximately(newValueUp, currentUp))
                footJamHopSettings.upwardStrength = Mathf.Clamp(newValueUp, rangeUp.Min, rangeUp.Max);
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedFootJam)
                footJamHopSettings.upwardStrength = originalFootJamUp;
            GUILayout.EndHorizontal();
            GUILayout.Space(4);

            // Forward
            GUILayout.BeginHorizontal();
            float currentForward = footJamHopSettings.forwardStrength;
            GUILayout.Label($"FootJam Fwd: {currentForward:F1}", GUILayout.Width(180));
            var rangeF = SliderRanges.HopFootJamForward;
            float newValueF = GUILayout.HorizontalSlider(currentForward, rangeF.Min, rangeF.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
            if (!Mathf.Approximately(newValueF, currentForward))
                footJamHopSettings.forwardStrength = Mathf.Clamp(newValueF, rangeF.Min, rangeF.Max);
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedFootJam)
                footJamHopSettings.forwardStrength = originalFootJamFwd;
            GUILayout.EndHorizontal();
        }
        else GUILayout.Label("  (FootJamHopSettings not found)");

        GUILayout.Space(4);
    }

    public override void ResetToDefaults()
    {
        if (hop == null) return;

        if (capturedTimer && hopTimerSettings != null)
            hopTimerSettings.hopTime = originalHopTime;
        if (capturedNormal && normalHopSettings != null)
            normalHopSettings.strength = originalNormalStrength;
        if (capturedLow && lowHopSettings != null)
            lowHopSettings.strength = originalLowStrength;
        if (capturedNose && noseManualHopSettings != null)
            noseManualHopSettings.strength = originalNoseManualStrength;
        if (capturedFootJam && footJamHopSettings != null)
        {
            footJamHopSettings.upwardStrength = originalFootJamUp;
            footJamHopSettings.forwardStrength = originalFootJamFwd;
        }
    }

    public override int GetRowCount() => 6; // hopTime, normal, low, nose, foot up, foot fwd
}

/// <summary>
/// TimeSpeed slow-motion scale
/// </summary>
public class TimeSpeedSection : TweakSection
{
    private TimeSpeed timeSpeed;
    private bool captured = false; private float originalSlowMotion;

    public override void FindComponents()
    {
        var found = GameObject.FindObjectOfType<TimeSpeed>();
        if (found == null) return;

        if (!captured)
        {
            originalSlowMotion = found.slowMotion;
            captured = true;
        }
        timeSpeed = found;
    }

    public override void DrawGUI()
    {
        if (timeSpeed == null)
        {
            GUILayout.Label("TimeSpeed not found");
            GUILayout.Space(4);
            return;
        }

        GUILayout.BeginHorizontal();
        float current = timeSpeed.slowMotion;
        GUILayout.Label($"Slomo Scale: {current:F2}", GUILayout.Width(180));
        var range = SliderRanges.TimeSlowMotion;
        float newValue = GUILayout.HorizontalSlider(current, range.Min, range.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
        if (!Mathf.Approximately(newValue, current))
            timeSpeed.slowMotion = Mathf.Clamp(newValue, range.Min, range.Max);
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            timeSpeed.slowMotion = originalSlowMotion;
        GUILayout.EndHorizontal();

        GUILayout.Space(4);
    }

    public override void ResetToDefaults()
    {
        if (captured && timeSpeed != null)
            timeSpeed.slowMotion = originalSlowMotion;
    }

    public override int GetRowCount() => 1;
}

/// <summary>
/// Invector Animator "Trick Speed" override
/// </summary>
public class InvectorSection : TweakSection
{
    private Component playerController;
    private Animator invectorAnimator;
    private AnimatorSpeedController animatorSpeedController;
    private static readonly string[] ControllerTypeNames =
    {
        "Invector.vCharacterController.vThirdPersonMotor",
        "vThirdPersonMotor",
        "ScooterController"
    };
    private static readonly string[] InputTypeNames =
    {
        "Invector.vCharacterController.vThirdPersonInput",
        "vThirdPersonInput"
    };

    private bool captured = false;
    private float originalAnimSpeed;

    public override void FindComponents()
    {
        Component ctrl = null;
        Animator anim = null;

        GameObject invRoot = GameObject.Find("PlayerComponents") ?? GameObject.Find("PlayerComponents(Clone)");
        if (invRoot != null)
        {
            ctrl = GetComponentInChildrenByTypeName(invRoot, ControllerTypeNames);
            anim = invRoot.GetComponentInChildren<Animator>();
        }

        if (anim == null)
        {
            if (!TryLocateLocalInvector(out ctrl, out anim))
            {
                playerController = null;
                invectorAnimator = null;
                animatorSpeedController = null;
                return;
            }
        }

        bool animatorChanged = invectorAnimator != anim;
        var previousController = animatorSpeedController;

        playerController = ctrl;
        invectorAnimator = anim;
        animatorSpeedController = AnimatorSpeedController.GetOrAdd(anim);

        if (!captured || animatorChanged)
        {
            originalAnimSpeed = animatorSpeedController?.OverrideSpeed ?? anim.speed;
            captured = true;
        }

        if (animatorChanged && previousController != null && previousController != animatorSpeedController)
            previousController.ClearOverride();
    }

    public override void DrawGUI()
    {
        if (invectorAnimator == null)
        {
            GUILayout.Label("Player animator not found");
            GUILayout.Space(4);
            return;
        }

        float displaySpeed = animatorSpeedController?.OverrideSpeed ?? invectorAnimator.speed;

        GUILayout.BeginHorizontal();
        GUILayout.Label($"Trick Speed (Host Only): {displaySpeed:F1}", GUILayout.Width(180));
        var range = SliderRanges.InvectorTrickSpeed;
        float newValue = GUILayout.HorizontalSlider(displaySpeed, range.Min, range.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
        if (!Mathf.Approximately(newValue, displaySpeed))
        {
            if (animatorSpeedController != null)
                animatorSpeedController.SetOverride(Mathf.Clamp(newValue, range.Min, range.Max));
            else
                invectorAnimator.speed = Mathf.Clamp(newValue, range.Min, range.Max);
        }
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
        {
            if (animatorSpeedController != null) animatorSpeedController.ClearOverride();
            invectorAnimator.speed = originalAnimSpeed;
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(4);
    }

    public override void ResetToDefaults()
    {
        if (invectorAnimator == null) return;

        if (animatorSpeedController != null)
            animatorSpeedController.ClearOverride();

        invectorAnimator.speed = originalAnimSpeed;
    }

    public override int GetRowCount() => 1;

    private bool TryLocateLocalInvector(out Component controller, out Animator animator)
    {
        controller = null; animator = null;

        if (TryLocateFromThirdPersonInput(out controller, out animator))
            return true;

        Component[] motors;
        try { motors = FindComponentsByTypeNames(ControllerTypeNames); }
        catch { return false; }

        if (motors == null || motors.Length == 0) return false;

        foreach (var motor in motors)
        {
            if (motor == null || !IsLocalOwner(motor.gameObject)) continue;
            var foundAnimator = FindAnimatorForMotor(motor);
            if (foundAnimator != null)
            {
                controller = motor; animator = foundAnimator;
                return true;
            }
        }
        foreach (var motor in motors)
        {
            if (motor == null) continue;
            var foundAnimator = FindAnimatorForMotor(motor);
            if (foundAnimator != null)
            {
                controller = motor; animator = foundAnimator;
                return true;
            }
        }
        return false;
    }

    private bool TryLocateFromThirdPersonInput(out Component controller, out Animator animator)
    {
        controller = null; animator = null;

        Component[] inputs;
        try { inputs = FindComponentsByTypeNames(InputTypeNames); }
        catch { return false; }

        if (inputs == null || inputs.Length == 0) return false;

        foreach (var input in inputs)
        {
            if (input == null) continue;
            if (input is Behaviour behaviour && !behaviour.enabled) continue;

            var motor = GetComponentByTypeName(input.gameObject, ControllerTypeNames) ??
                        GetComponentInChildrenByTypeName(input.gameObject, ControllerTypeNames) ??
                        GetComponentInParentByTypeName(input.gameObject, ControllerTypeNames);

            var foundAnimator = FindAnimatorForMotor(motor);
            if (motor != null && foundAnimator != null)
            {
                controller = motor; animator = foundAnimator; return true;
            }

            if (motor == null)
            {
                motor = GetComponentInParentByTypeName(input.gameObject, ControllerTypeNames);
                foundAnimator = FindAnimatorForMotor(motor);
                if (motor != null && foundAnimator != null)
                {
                    controller = motor; animator = foundAnimator; return true;
                }
            }
        }
        return false;
    }

    private Animator FindAnimatorForMotor(Component motor)
    {
        if (motor == null) return null;
        return motor.GetComponentInChildren<Animator>() ??
               motor.GetComponent<Animator>() ??
               motor.GetComponentInParent<Animator>();
    }

    private static Component[] FindComponentsByTypeNames(IEnumerable<string> typeNames)
    {
        var list = new List<Component>();
        foreach (var typeName in typeNames)
        {
            Type type = ResolveType(typeName);
            if (type == null || !typeof(Component).IsAssignableFrom(type))
                continue;

            foreach (var obj in UnityEngine.Object.FindObjectsOfType(type))
            {
                if (obj is Component component)
                    list.Add(component);
            }
        }
        return list.ToArray();
    }

    private static Component GetComponentByTypeName(GameObject go, IEnumerable<string> typeNames)
    {
        if (go == null) return null;
        foreach (var typeName in typeNames)
        {
            Type type = ResolveType(typeName);
            if (type == null || !typeof(Component).IsAssignableFrom(type))
                continue;

            var component = go.GetComponent(type) as Component;
            if (component != null) return component;
        }
        return null;
    }

    private static Component GetComponentInChildrenByTypeName(GameObject go, IEnumerable<string> typeNames)
    {
        if (go == null) return null;
        foreach (var typeName in typeNames)
        {
            Type type = ResolveType(typeName);
            if (type == null || !typeof(Component).IsAssignableFrom(type))
                continue;

            var component = go.GetComponentInChildren(type) as Component;
            if (component != null) return component;
        }
        return null;
    }

    private static Component GetComponentInParentByTypeName(GameObject go, IEnumerable<string> typeNames)
    {
        if (go == null) return null;
        foreach (var typeName in typeNames)
        {
            Type type = ResolveType(typeName);
            if (type == null || !typeof(Component).IsAssignableFrom(type))
                continue;

            var component = go.GetComponentInParent(type) as Component;
            if (component != null) return component;
        }
        return null;
    }

    private static Type ResolveType(string typeName)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            Type type = null;
            try { type = assembly.GetType(typeName, false); }
            catch { }

            if (type != null)
                return type;
        }
        return null;
    }

    private bool IsLocalOwner(GameObject go)
    {
        if (go == null) return false;

        Component[] parents;
        try { parents = go.GetComponentsInParent<Component>(true); }
        catch { return false; }

        foreach (var component in parents)
        {
            if (component == null) continue;

            var type = component.GetType();
            if (type.FullName == "Unity.Netcode.NetworkObject")
            {
                var isOwnerProperty = type.GetProperty("IsOwner", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (isOwnerProperty != null && isOwnerProperty.PropertyType == typeof(bool))
                {
                    try { return (bool)isOwnerProperty.GetValue(component, null); }
                    catch { return false; }
                }
                return false;
            }
        }
        return false;
    }
}

/// <summary>
/// ScooterWheel Settings
/// </summary>
public class WheelSection : TweakSection
{
    private ScooterWheelSettings wheelSettings;

    private bool captured = false;
    private float originalMaxMotorTorque;
    private float originalStopDrag;

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter == null || foundScooter.scooterWheelSettings == null) return;

        if (!captured)
        {
            var ws = foundScooter.scooterWheelSettings;
            originalMaxMotorTorque = ws.maxMotorTorque;
            originalStopDrag = ws.stopDrag;
            captured = true;
        }
        wheelSettings = foundScooter.scooterWheelSettings;
    }

    public override void DrawGUI()
    {
        if (wheelSettings == null)
        {
            GUILayout.Label("ScooterWheelSettings not found");
            GUILayout.Space(4);
            return;
        }

        // Max Motor Torque
        GUILayout.BeginHorizontal();
        float currentTorque = wheelSettings.maxMotorTorque;
        GUILayout.Label($"Max Motor Torque: {currentTorque:F1}", GUILayout.Width(180));
        var range = SliderRanges.WheelMaxMotorTorque;
        float newValue = GUILayout.HorizontalSlider(currentTorque, range.Min, range.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
        if (!Mathf.Approximately(newValue, currentTorque))
            wheelSettings.maxMotorTorque = Mathf.Clamp(newValue, range.Min, range.Max);
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            wheelSettings.maxMotorTorque = originalMaxMotorTorque;
        GUILayout.EndHorizontal();
        GUILayout.Space(4);

        // Stop Drag
        GUILayout.BeginHorizontal();
        float currentDrag = wheelSettings.stopDrag;
        GUILayout.Label($"Stop Drag: {currentDrag:F1}", GUILayout.Width(180));
        var range2 = SliderRanges.WheelStopDrag;
        float newValue2 = GUILayout.HorizontalSlider(currentDrag, range2.Min, range2.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
        if (!Mathf.Approximately(newValue2, currentDrag))
            wheelSettings.stopDrag = Mathf.Clamp(newValue2, range2.Min, range2.Max);
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            wheelSettings.stopDrag = originalStopDrag;
        GUILayout.EndHorizontal();

        GUILayout.Space(4);
    }

    public override void ResetToDefaults()
    {
        if (wheelSettings == null) return;
        if (captured)
        {
            wheelSettings.maxMotorTorque = originalMaxMotorTorque;
            wheelSettings.stopDrag = originalStopDrag;
        }
    }

    public override int GetRowCount() => 2;
}

/// <summary>
/// Push Settings
/// </summary>
public class PushSection : TweakSection
{
    private PushSettings pushSettings;

    private bool captured = false;
    private float originalDelay;
    private float originalDuration;
    private float originalInitialPush;

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter == null || foundScooter.pushSettings == null) return;

        if (!captured)
        {
            var ps = foundScooter.pushSettings;
            originalDelay = ps.delay;
            originalDuration = ps.duration;
            originalInitialPush = ps.initialPushForce;
            captured = true;
        }
        pushSettings = foundScooter.pushSettings;
    }

    public override void DrawGUI()
    {
        if (pushSettings == null)
        {
            GUILayout.Label("PushSettings not found");
            GUILayout.Space(4);
            return;
        }
        /*
        // Delay
        GUILayout.BeginHorizontal();
        float newValue = GUILayout.HorizontalSlider(currentDelay, range.Min, range.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
        if (!Mathf.Approximately(newValue, currentDelay))
            pushSettings.delay = Mathf.Clamp(newValue, range.Min, range.Max);
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pushSettings.delay = originalDelay;
        GUILayout.EndHorizontal();
        GUILayout.Space(4);

        // Duration
        GUILayout.BeginHorizontal();
        float currentDuration = pushSettings.duration;
        GUILayout.Label($"Push Duration: {currentDuration:F1}", GUILayout.Width(180));
        var range2 = SliderRanges.PushDuration;
        float newValue2 = GUILayout.HorizontalSlider(currentDuration, range2.Min, range2.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
        if (!Mathf.Approximately(newValue2, currentDuration))
            pushSettings.duration = Mathf.Clamp(newValue2, range2.Min, range2.Max);
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pushSettings.duration = originalDuration;
        GUILayout.EndHorizontal();
        GUILayout.Space(4);*/

        // Initial Push Force
        GUILayout.BeginHorizontal();
        float currentForce = pushSettings.initialPushForce;
        GUILayout.Label($"Initial Push Force: {currentForce:F1}", GUILayout.Width(180));
        var range3 = SliderRanges.PushInitialForce;
        float newValue3 = GUILayout.HorizontalSlider(currentForce, range3.Min, range3.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
        if (!Mathf.Approximately(newValue3, currentForce))
            pushSettings.initialPushForce = Mathf.Clamp(newValue3, range3.Min, range3.Max);
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pushSettings.initialPushForce = originalInitialPush;
        GUILayout.EndHorizontal();

        GUILayout.Space(4);
    }

    public override void ResetToDefaults()
    {
        if (pushSettings == null) return;
        if (captured)
        {
            pushSettings.delay = originalDelay;
            pushSettings.duration = originalDuration;
            pushSettings.initialPushForce = originalInitialPush;
        }
    }

    public override int GetRowCount() => 3;
}

/// <summary>
/// PumpMechanic
/// </summary>
public class PumpSection : TweakSection
{
    private PumpMechanic pumpMechanic;
    private static readonly FieldInfo PumpForceField =
        typeof(PumpMechanic).GetField("pumpingForce", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        ?? typeof(PumpMechanic).GetField("pumpForce", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

    private bool captured = false;
    private float originalPumpTime;
    private float originalPumpingForce;

    public override void FindComponents()
    {
        var found = GameObject.FindObjectOfType<PumpMechanic>();
        if (found == null) return;

        if (!captured)
        {
            originalPumpTime = found.pumpTime;
            if (PumpForceField != null)
                originalPumpingForce = Convert.ToSingle(PumpForceField.GetValue(found));
            captured = true;
        }
        pumpMechanic = found;
    }

    public override void DrawGUI()
    {
        if (pumpMechanic == null)
        {
            GUILayout.Label("PumpMechanic not found");
            GUILayout.Space(4);
            return;
        }
        /*
        // Pump Time
        GUILayout.BeginHorizontal();
        float currentPumpTime = pumpMechanic.pumpTime;
        GUILayout.Label($"Pump Time: {currentPumpTime:F2}", GUILayout.Width(180));
        var range = SliderRanges.PumpTime;
        float newValue = GUILayout.HorizontalSlider(currentPumpTime, range.Min, range.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
        if (!Mathf.Approximately(newValue, currentPumpTime))
            pumpMechanic.pumpTime = Mathf.Clamp(newValue, range.Min, range.Max);
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pumpMechanic.pumpTime = originalPumpTime;
        GUILayout.EndHorizontal();
        GUILayout.Space(4);
        */
        // Pump Force (if field exists)
        if (PumpForceField != null)
        {
            float pumpForce = Convert.ToSingle(PumpForceField.GetValue(pumpMechanic));
            GUILayout.BeginHorizontal();
            GUILayout.Label($"Pump Force: {pumpForce:F1}", GUILayout.Width(180));
            var rangeF = SliderRanges.PumpForce;
            float newValueF = GUILayout.HorizontalSlider(pumpForce, rangeF.Min, rangeF.Max, GUILayout.Width(MenuDisplaySettings.SliderWidth));
            if (!Mathf.Approximately(newValueF, pumpForce))
            {
                pumpForce = Mathf.Clamp(newValueF, rangeF.Min, rangeF.Max);
                PumpForceField.SetValue(pumpMechanic, pumpForce);
            }
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
                PumpForceField.SetValue(pumpMechanic, originalPumpingForce);
            GUILayout.EndHorizontal();
        }
        else
        {
            GUILayout.Label("Pump Force unavailable (field not present in this build)");
        }

        GUILayout.Space(4);
    }

    public override void ResetToDefaults()
    {
        if (pumpMechanic == null) return;

        if (captured)
        {
            pumpMechanic.pumpTime = originalPumpTime;
            if (PumpForceField != null)
                PumpForceField.SetValue(pumpMechanic, originalPumpingForce);
        }
    }

    public override int GetRowCount() => PumpForceField != null ? 2 : 1;
}

/// <summary>
/// Quick controls for sending scooter cosmetic changes over the network.
/// </summary>
public class NetworkScooterSection : TweakSection
{
    private MonoBehaviour scooterSync;
    private MonoBehaviour applyScooter;
    private ScriptableObject customScooterAsset;

    private bool capturedOriginal;
    private int originalSlot;

    private string statusMessage;
    private float statusExpiry;
    private bool autoPush = true;

    private static Type cachedSyncType;
    private static Type cachedApplyType;
    private static readonly Dictionary<Type, PropertyInfo> ownerProps = new Dictionary<Type, PropertyInfo>();
    private static readonly Dictionary<Type, MethodInfo> pushMethods = new Dictionary<Type, MethodInfo>();
    private static readonly Dictionary<Type, MethodInfo> loadMethods = new Dictionary<Type, MethodInfo>();
    private static readonly Dictionary<Type, FieldInfo> applySlotFields = new Dictionary<Type, FieldInfo>();
    private static readonly Dictionary<Type, FieldInfo> applyAssetFields = new Dictionary<Type, FieldInfo>();
    private static readonly Dictionary<Type, FieldInfo> customSlotFields = new Dictionary<Type, FieldInfo>();

    public override void FindComponents()
    {
        Type syncType = GetNetworkScooterSyncType();
        scooterSync = FindComponent(syncType, onlyOwner: true);
        if (scooterSync == null)
        {
            scooterSync = FindComponent(syncType, onlyOwner: false);
        }

        Type applyType = GetApplyCustomScooterType();
        applyScooter = FindComponent(applyType, onlyOwner: false);

        if (applyScooter == null && scooterSync != null && applyType != null)
        {
            Component candidate = scooterSync.GetComponent(applyType) ?? scooterSync.GetComponentInChildren(applyType);
            applyScooter = candidate as MonoBehaviour;
        }

        customScooterAsset = applyScooter != null ? GetCustomScooterAsset(applyScooter) : null;

        if (!capturedOriginal && customScooterAsset != null)
        {
            capturedOriginal = true;
            originalSlot = Mathf.Clamp(GetActiveSlotValue(), 1, 3);
        }
    }

    public override void DrawGUI()
    {
        if (scooterSync == null)
        {
            GUILayout.Label("NetworkScooterSyncAll not found");
            GUILayout.Space(4);
            return;
        }

        int currentSlot = GetActiveSlot();

        GUILayout.BeginHorizontal();
        GUILayout.Label($"Scooter Slot: {currentSlot}", GUILayout.Width(180));

        bool hasAsset = customScooterAsset != null || applyScooter != null;
        GUI.enabled = hasAsset;
        if (GUILayout.Button("Prev", GUILayout.Width(60)))
        {
            CycleSlot(-1);
        }
        if (GUILayout.Button("Next", GUILayout.Width(60)))
        {
            CycleSlot(1);
        }

        GUI.enabled = hasAsset && scooterSync != null;
        if (GUILayout.Button("Push Sync", GUILayout.Width(90)))
        {
            PushCurrentSlot();
        }
        GUI.enabled = true;
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        bool newAutoPush = GUILayout.Toggle(autoPush, "Auto Push", GUILayout.Width(100));
        if (newAutoPush != autoPush)
        {
            autoPush = newAutoPush;
            SetStatus(autoPush ? "Auto push enabled" : "Auto push disabled");
        }

        if (GUILayout.Button("Reload Local", GUILayout.Width(110)))
        {
            ReloadLocal();
        }
        GUILayout.EndHorizontal();

        if (!string.IsNullOrEmpty(statusMessage))
        {
            if (Time.realtimeSinceStartup > statusExpiry)
            {
                statusMessage = null;
            }
            else
            {
                GUILayout.Label(statusMessage);
            }
        }

        GUILayout.Space(4);
    }

    public override void ResetToDefaults()
    {
        if (!capturedOriginal)
        {
            return;
        }

        ApplySlot(originalSlot, true);

        if (autoPush && scooterSync != null)
        {
            PushCurrentSlot();
        }
        else
        {
            SetStatus($"Reset to slot {originalSlot}" + (autoPush ? string.Empty : " (push manually)"));
        }
    }

    public override int GetRowCount() => 3;

    private MonoBehaviour FindComponent(Type type, bool onlyOwner)
    {
        if (type == null)
        {
            return null;
        }

        var behaviours = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>();
        if (behaviours == null || behaviours.Length == 0)
        {
            return null;
        }

        foreach (var behaviour in behaviours)
        {
            if (behaviour == null)
            {
                continue;
            }
            if (!type.IsAssignableFrom(behaviour.GetType()))
            {
                continue;
            }

            if (onlyOwner && !IsOwner(behaviour))
            {
                continue;
            }

            return behaviour;
        }

        return null;
    }

    private bool IsOwner(MonoBehaviour behaviour)
    {
        if (behaviour == null)
        {
            return false;
        }

        Type type = behaviour.GetType();
        PropertyInfo prop;
        if (!ownerProps.TryGetValue(type, out prop))
        {
            prop = type.GetProperty("IsOwner", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            ownerProps[type] = prop;
        }

        if (prop == null)
        {
            return false;
        }

        try
        {
            object value = prop.GetValue(behaviour, null);
            return value is bool b && b;
        }
        catch
        {
            return false;
        }
    }

    private int GetActiveSlot()
    {
        return Mathf.Clamp(GetActiveSlotValue(), 1, 3);
    }

    private int GetActiveSlotValue()
    {
        if (customScooterAsset != null)
        {
            FieldInfo activeField = GetCustomSlotField(customScooterAsset.GetType());
            if (activeField != null)
            {
                object val = activeField.GetValue(customScooterAsset);
                if (val is int i)
                {
                    return i;
                }
            }
        }

        if (applyScooter != null)
        {
            FieldInfo slotField = GetApplySlotField(applyScooter.GetType());
            if (slotField != null)
            {
                object val = slotField.GetValue(applyScooter);
                if (val is int i)
                {
                    return i;
                }
            }
        }

        return 1;
    }

    private void CycleSlot(int delta)
    {
        if (customScooterAsset == null && applyScooter == null)
        {
            SetStatus("Custom scooter data not found");
            return;
        }

        int newSlot = GetActiveSlot() + delta;
        if (newSlot > 3) newSlot = 1;
        if (newSlot < 1) newSlot = 3;

        ApplySlot(newSlot, true);

        if (autoPush)
        {
            PushCurrentSlot();
        }
        else
        {
            SetStatus($"Switched to slot {newSlot}. Push Sync to broadcast.");
        }
    }

    private void ApplySlot(int newSlot, bool reload)
    {
        if (customScooterAsset != null)
        {
            FieldInfo activeField = GetCustomSlotField(customScooterAsset.GetType());
            if (activeField != null)
            {
                activeField.SetValue(customScooterAsset, newSlot);
            }
        }

        if (applyScooter != null)
        {
            FieldInfo slotField = GetApplySlotField(applyScooter.GetType());
            if (slotField != null)
            {
                slotField.SetValue(applyScooter, newSlot);
            }

            ScriptableObject asset = GetCustomScooterAsset(applyScooter);
            if (asset != null)
            {
                FieldInfo activeField = GetCustomSlotField(asset.GetType());
                if (activeField != null)
                {
                    activeField.SetValue(asset, newSlot);
                }
            }

            if (reload)
            {
                InvokeLoadAndApply(applyScooter);
            }
        }
    }

    private void PushCurrentSlot()
    {
        if (scooterSync == null)
        {
            SetStatus("No NetworkScooterSyncAll available");
            return;
        }

        MethodInfo pushMethod = GetPushMethod(scooterSync.GetType());
        if (pushMethod == null)
        {
            SetStatus("Push method not available");
            return;
        }

        try
        {
            pushMethod.Invoke(scooterSync, null);
            SetStatus($"Pushed slot {GetActiveSlot()} to network");
        }
        catch (Exception ex)
        {
            SetStatus($"Push failed: {ex.Message}");
        }
    }

    private void ReloadLocal()
    {
        if (applyScooter != null)
        {
            InvokeLoadAndApply(applyScooter);
            SetStatus("Reloaded current slot locally");
        }
        else
        {
            SetStatus("ApplyCustomScooter not found");
        }
    }

    private void InvokeLoadAndApply(MonoBehaviour target)
    {
        if (target == null)
        {
            return;
        }

        MethodInfo method = GetLoadMethod(target.GetType());
        if (method == null)
        {
            return;
        }

        try
        {
            method.Invoke(target, null);
        }
        catch (Exception ex)
        {
            SetStatus($"Local reload failed: {ex.Message}");
        }
    }

    private ScriptableObject GetCustomScooterAsset(MonoBehaviour target)
    {
        if (target == null)
        {
            return null;
        }

        FieldInfo field = GetApplyAssetField(target.GetType());
        if (field == null)
        {
            return null;
        }

        return field.GetValue(target) as ScriptableObject;
    }

    private static Type GetNetworkScooterSyncType()
    {
        if (cachedSyncType != null)
        {
            return cachedSyncType;
        }

        cachedSyncType = LocateType("NetworkScooterSyncAll");
        return cachedSyncType;
    }

    private static Type GetApplyCustomScooterType()
    {
        if (cachedApplyType != null)
        {
            return cachedApplyType;
        }

        cachedApplyType = LocateType("ApplyCustomScooter");
        return cachedApplyType;
    }

    private static Type LocateType(string typeName)
    {
        if (string.IsNullOrEmpty(typeName))
        {
            return null;
        }

        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            Type found = assembly.GetType(typeName);
            if (found != null)
            {
                return found;
            }
        }

        return null;
    }

    private FieldInfo GetApplySlotField(Type type)
    {
        if (type == null)
        {
            return null;
        }

        FieldInfo field;
        if (!applySlotFields.TryGetValue(type, out field))
        {
            field = type.GetField("customScooterSlot", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            applySlotFields[type] = field;
        }
        return field;
    }

    private FieldInfo GetApplyAssetField(Type type)
    {
        if (type == null)
        {
            return null;
        }

        FieldInfo field;
        if (!applyAssetFields.TryGetValue(type, out field))
        {
            field = type.GetField("customScootersAsset", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            applyAssetFields[type] = field;
        }
        return field;
    }

    private FieldInfo GetCustomSlotField(Type type)
    {
        if (type == null)
        {
            return null;
        }

        FieldInfo field;
        if (!customSlotFields.TryGetValue(type, out field))
        {
            field = type.GetField("activeSlot", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            customSlotFields[type] = field;
        }
        return field;
    }

    private MethodInfo GetPushMethod(Type type)
    {
        if (type == null)
        {
            return null;
        }

        MethodInfo method;
        if (!pushMethods.TryGetValue(type, out method))
        {
            method = type.GetMethod("PushFromLocalActiveSlot", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            pushMethods[type] = method;
        }
        return method;
    }

    private MethodInfo GetLoadMethod(Type type)
    {
        if (type == null)
        {
            return null;
        }

        MethodInfo method;
        if (!loadMethods.TryGetValue(type, out method))
        {
            method = type.GetMethod("LoadAndApplyScooter", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            loadMethods[type] = method;
        }
        return method;
    }

    private void SetStatus(string message)
    {
        statusMessage = message;
        statusExpiry = Time.realtimeSinceStartup + 4f;
    }
}

/* ========================= Inlined AnimatorSpeedController ========================= */

/// <summary>
/// Forces an Animator speed override during LateUpdate so other scripts that assign
/// Animator.speed earlier in the frame do not immediately revert our tweak.
/// (Inlined here so no separate file is needed.)
/// </summary>
public class AnimatorSpeedController : MonoBehaviour
{
    private Animator animator;
    private float? overrideSpeed;
    private float originalSpeed = 1f;
    private bool hasOriginal;

    public float? OverrideSpeed => overrideSpeed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        if (overrideSpeed.HasValue) ClearOverride();
    }

    private void OnDestroy()
    {
        if (overrideSpeed.HasValue) ClearOverride();
    }

    private void LateUpdate()
    {
        if (overrideSpeed.HasValue && animator != null)
            animator.speed = overrideSpeed.Value;
    }

    public void SetOverride(float speed)
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (animator != null && !hasOriginal) { originalSpeed = animator.speed; hasOriginal = true; }

        overrideSpeed = Mathf.Max(0.01f, speed);
        if (animator != null) animator.speed = overrideSpeed.Value;
    }

    public void ClearOverride()
    {
        overrideSpeed = null;
        if (animator != null && hasOriginal)
            animator.speed = originalSpeed;
    }

    public static AnimatorSpeedController GetOrAdd(Animator target)
    {
        if (target == null) return null;
        var controller = target.GetComponent<AnimatorSpeedController>();
        if (controller == null)
            controller = target.gameObject.AddComponent<AnimatorSpeedController>();
        return controller;
    }
}
