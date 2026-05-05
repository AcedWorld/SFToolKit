using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Invector.vCharacterController;
using SFToolKit;

/// <summary>
/// Base class for any “tweak-section.” Each section finds its own components,
/// captures originals, and draws its own GUI.
/// </summary>
public abstract class TweakSection
{
    /// <summary>
    /// Called by Menu.TryFindAllComponents() every frame to locate components (if they exist)
    /// and capture “original” values if not yet captured.
    /// </summary>
    public abstract void FindComponents();

    /// <summary>
    /// Called by Menu.DrawContents() to draw this section’s GUI (including its header, sliders, etc.).
    /// </summary>
    /// <param name="tweakStep">The current tweakStep value from Menu.</param>
    public abstract void DrawGUI(float tweakStep);

    /// <summary>
    /// Whether this section is currently valid (i.e. all critical references were found).
    /// Useful to show “Not found” if null.
    /// </summary>
    public abstract bool IsValid { get; }
}

/// <summary>
/// “Physics: Gravity” section, with its own fields and original-value logic.
/// </summary>
public class GravitySection : TweakSection
{
    private bool hasCapturedOriginal = false;
    private Vector3 originalGravity;

    // gravityStep is taken from Menu; we’ll assume the Menu instance passes it in DrawGUI.
    public override bool IsValid => true; // always “valid,” since Physics.gravity is static.

    public override void FindComponents()
    {
        if (!hasCapturedOriginal)
        {
            originalGravity = Physics.gravity;
            hasCapturedOriginal = true;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        // Header
        GUILayout.Label("— Physics: Gravity —");
        // Slider row
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Gravity Y: {Physics.gravity.y:F1}", GUILayout.Width(180));

        if (GUILayout.Button("<", GUILayout.Width(25)))
        {
            Physics.gravity -= Vector3.up * tweakStep * 0.1f;
        }
        if (GUILayout.Button(">", GUILayout.Width(25)))
        {
            Physics.gravity += Vector3.up * tweakStep * 0.1f;
        }
        if (GUILayout.Button("Reset", GUILayout.Width(60)))
        {
            if (hasCapturedOriginal)
                Physics.gravity = originalGravity;
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// "Hop & Sub-Settings" section for hop time, hop strengths, and foot jam forces.
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
    private bool capturedTimer = false;
    private float originalHopTime;

    private bool capturedNormal = false;
    private float originalNormalStrength;

    private bool capturedLow = false;
    private float originalLowStrength;

    private bool capturedNose = false;
    private float originalNoseManualStrength;

    private bool capturedFootJam = false;
    private float originalFootJamUp;
    private float originalFootJamFwd;

    public override bool IsValid => hop != null;

    public override void FindComponents()
    {
        var foundHop = GameObject.FindObjectOfType<Hop>();
        if (foundHop != null)
        {
            hop = foundHop;

            // HopTimerSettings
            if (hop.hopTimerSettings != null)
            {
                if (!capturedTimer)
                {
                    originalHopTime = hop.hopTimerSettings.hopTime;
                    capturedTimer = true;
                }
                hopTimerSettings = hop.hopTimerSettings;
            }

            // NormalHopSettings
            if (hop.normalHopSettings != null)
            {
                if (!capturedNormal)
                {
                    originalNormalStrength = hop.normalHopSettings.strength;
                    capturedNormal = true;
                }
                normalHopSettings = hop.normalHopSettings;
            }

            // LowHopSettings
            if (hop.lowHopSettings != null)
            {
                if (!capturedLow)
                {
                    originalLowStrength = hop.lowHopSettings.strength;
                    capturedLow = true;
                }
                lowHopSettings = hop.lowHopSettings;
            }

            // NoseManualHopSettings
            if (hop.noseManualHopSettings != null)
            {
                if (!capturedNose)
                {
                    originalNoseManualStrength = hop.noseManualHopSettings.strength;
                    capturedNose = true;
                }
                noseManualHopSettings = hop.noseManualHopSettings;
            }

            // FootJamHopSettings
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
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Hop & Related Settings —");

        if (!IsValid)
        {
            GUILayout.Label("Hop component not found");
            GUILayout.Space(8);
            return;
        }

        // -- HopTimerSettings --
        GUILayout.Label("• HopTimerSettings •");
        if (hopTimerSettings != null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label($"Hop Time: {hopTimerSettings.hopTime:F1}", GUILayout.Width(180));
            if (GUILayout.Button("<", GUILayout.Width(25)))
                hopTimerSettings.hopTime = Mathf.Max(0f, hopTimerSettings.hopTime - tweakStep * 0.1f);
            if (GUILayout.Button(">", GUILayout.Width(25)))
                hopTimerSettings.hopTime += tweakStep * 0.1f;
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedTimer)
                hopTimerSettings.hopTime = originalHopTime;
            GUILayout.EndHorizontal();
        }
        else
        {
            GUILayout.Label("  (HopTimerSettings not found)");
        }
        GUILayout.Space(6);

        // -- NormalHopSettings --
        GUILayout.Label("• NormalHopSettings •");
        if (normalHopSettings != null)
        {
            // Strength
            GUILayout.BeginHorizontal();
            GUILayout.Label($"Normal Strength: {normalHopSettings.strength:F1}", GUILayout.Width(180));
            if (GUILayout.Button("<", GUILayout.Width(25)))
                normalHopSettings.strength = Mathf.Max(0f, normalHopSettings.strength - tweakStep);
            if (GUILayout.Button(">", GUILayout.Width(25)))
                normalHopSettings.strength += tweakStep;
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedNormal)
                normalHopSettings.strength = originalNormalStrength;
            GUILayout.EndHorizontal();

            GUILayout.Space(4);
        }
        else
        {
            GUILayout.Label("  (NormalHopSettings not found)");
        }
        GUILayout.Space(6);

        // -- LowHopSettings --
        GUILayout.Label("• LowHopSettings •");
        if (lowHopSettings != null)
        {
            // Strength
            GUILayout.BeginHorizontal();
            GUILayout.Label($"Low Strength: {lowHopSettings.strength:F1}", GUILayout.Width(180));
            if (GUILayout.Button("<", GUILayout.Width(25)))
                lowHopSettings.strength = Mathf.Max(0f, lowHopSettings.strength - tweakStep);
            if (GUILayout.Button(">", GUILayout.Width(25)))
                lowHopSettings.strength += tweakStep;
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedLow)
                lowHopSettings.strength = originalLowStrength;
            GUILayout.EndHorizontal();

            GUILayout.Space(4);
        }
        else
        {
            GUILayout.Label("  (LowHopSettings not found)");
        }
        GUILayout.Space(6);

        // -- NoseManualHopSettings --
        GUILayout.Label("• NoseManualHopSettings •");
        if (noseManualHopSettings != null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label($"NoseManual Strength: {noseManualHopSettings.strength:F1}", GUILayout.Width(180));
            if (GUILayout.Button("<", GUILayout.Width(25)))
                noseManualHopSettings.strength = Mathf.Max(0f, noseManualHopSettings.strength - tweakStep);
            if (GUILayout.Button(">", GUILayout.Width(25)))
                noseManualHopSettings.strength += tweakStep;
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedNose)
                noseManualHopSettings.strength = originalNoseManualStrength;
            GUILayout.EndHorizontal();
        }
        else
        {
            GUILayout.Label("  (NoseManualHopSettings not found)");
        }
        GUILayout.Space(6);

        // -- FootJamHopSettings --
        GUILayout.Label("• FootJamHopSettings •");
        if (footJamHopSettings != null)
        {
            // Upward Strength
            GUILayout.BeginHorizontal();
            GUILayout.Label($"FootJam Up Str: {footJamHopSettings.upwardStrength:F1}", GUILayout.Width(180));
            if (GUILayout.Button("<", GUILayout.Width(25)))
                footJamHopSettings.upwardStrength = Mathf.Max(0f, footJamHopSettings.upwardStrength - tweakStep);
            if (GUILayout.Button(">", GUILayout.Width(25)))
                footJamHopSettings.upwardStrength += tweakStep;
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedFootJam)
                footJamHopSettings.upwardStrength = originalFootJamUp;
            GUILayout.EndHorizontal();

            GUILayout.Space(4);

            // Forward Strength
            GUILayout.BeginHorizontal();
            GUILayout.Label($"FootJam Fwd Str: {footJamHopSettings.forwardStrength:F1}", GUILayout.Width(180));
            if (GUILayout.Button("<", GUILayout.Width(25)))
                footJamHopSettings.forwardStrength = Mathf.Max(0f, footJamHopSettings.forwardStrength - tweakStep);
            if (GUILayout.Button(">", GUILayout.Width(25)))
                footJamHopSettings.forwardStrength += tweakStep;
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedFootJam)
                footJamHopSettings.forwardStrength = originalFootJamFwd;
            GUILayout.EndHorizontal();
        }
        else
        {
            GUILayout.Label("  (FootJamHopSettings not found)");
        }

        GUILayout.Space(8);
    }
}

/// <summary>
/// "TimeSpeed" section: adjust the slow-motion scale.
/// </summary>
public class TimeSpeedSection : TweakSection
{
    private TimeSpeed timeSpeed;
    private bool captured = false;
    private float originalSlowMotion;

    public override bool IsValid => timeSpeed != null;

    public override void FindComponents()
    {
        var found = GameObject.FindObjectOfType<TimeSpeed>();
        if (found != null)
        {
            if (!captured)
            {
                originalSlowMotion = found.slowMotion;
                captured = true;
            }
            timeSpeed = found;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— TimeSpeed —");
        if (!IsValid)
        {
            GUILayout.Label("TimeSpeed not found");
            GUILayout.Space(8);
            return;
        }

        // Slomo Scale slider
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Slomo Scale: {timeSpeed.slowMotion:F2}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            timeSpeed.slowMotion = Mathf.Max(0f, timeSpeed.slowMotion - tweakStep * 0.01f);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            timeSpeed.slowMotion += tweakStep * 0.01f;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            timeSpeed.slowMotion = originalSlowMotion;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// "Invector Animator & Motor" section: tweak the animator speed.
/// </summary>
public class InvectorSection : TweakSection
{
    private vThirdPersonMotor invectorController;
    private Animator invectorAnimator;

    private bool captured = false;
    private float originalAnimSpeed;

    public override bool IsValid => (invectorAnimator != null && invectorController != null);

    public override void FindComponents()
    {
        GameObject invRoot = GameObject.Find("PlayerComponents") ?? GameObject.Find("PlayerComponents(Clone)");
        if (invRoot != null)
        {
            var ctrl = invRoot.GetComponentInChildren<vThirdPersonMotor>();
            var anim = invRoot.GetComponentInChildren<Animator>();
            if (ctrl != null && anim != null)
            {
                if (!captured)
                {
                    originalAnimSpeed = anim.speed;
                    captured = true;
                }
                invectorController = ctrl;
                invectorAnimator = anim;
            }
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Invector Animator & Motor —");
        if (!IsValid)
        {
            GUILayout.Label("Invector components not found");
            GUILayout.Space(8);
            return;
        }

        // Anim Speed
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Anim Speed: {invectorAnimator.speed:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            invectorAnimator.speed = Mathf.Max(0.1f, invectorAnimator.speed - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            invectorAnimator.speed += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            invectorAnimator.speed = originalAnimSpeed;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}


/// <summary>
/// "ScooterWheel Settings" section: adjust max motor torque and stop drag.
/// </summary>
public class WheelSection : TweakSection
{
    private ScooterController scooter;
    private ScooterWheelSettings wheelSettings;

    private bool captured = false;
    private float originalMaxMotorTorque;
    private float originalStopDrag;

    public override bool IsValid => (wheelSettings != null);

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter != null && foundScooter.scooterWheelSettings != null)
        {
            if (!captured)
            {
                var ws = foundScooter.scooterWheelSettings;
                originalMaxMotorTorque = ws.maxMotorTorque;
                originalStopDrag = ws.stopDrag;
                captured = true;
            }
            scooter = foundScooter;
            wheelSettings = foundScooter.scooterWheelSettings;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— ScooterWheel Settings —");
        if (!IsValid)
        {
            GUILayout.Label("ScooterWheelSettings not found");
            GUILayout.Space(8);
            return;
        }

        // Max Motor Torque
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Max Motor Torque: {wheelSettings.maxMotorTorque:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            wheelSettings.maxMotorTorque = Mathf.Max(0f, wheelSettings.maxMotorTorque - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            wheelSettings.maxMotorTorque += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            wheelSettings.maxMotorTorque = originalMaxMotorTorque;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Stop Drag
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Stop Drag: {wheelSettings.stopDrag:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            wheelSettings.stopDrag = Mathf.Max(0f, wheelSettings.stopDrag - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            wheelSettings.stopDrag += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            wheelSettings.stopDrag = originalStopDrag;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “Push Settings” section: delay, duration, initialPushForce.
/// </summary>
public class PushSection : TweakSection
{
    private ScooterController scooter;
    private PushSettings pushSettings;

    private bool captured = false;
    private float originalDelay;
    private float originalDuration;
    private float originalInitialPush;

    public override bool IsValid => (pushSettings != null);

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter != null && foundScooter.pushSettings != null)
        {
            if (!captured)
            {
                var ps = foundScooter.pushSettings;
                originalDelay = ps.delay;
                originalDuration = ps.duration;
                originalInitialPush = ps.initialPushForce;
                captured = true;
            }
            scooter = foundScooter;
            pushSettings = foundScooter.pushSettings;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Push Settings —");
        if (!IsValid)
        {
            GUILayout.Label("PushSettings not found");
            GUILayout.Space(8);
            return;
        }

        // Push Delay
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Push Delay: {pushSettings.delay:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            pushSettings.delay = Mathf.Max(0f, pushSettings.delay - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            pushSettings.delay += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pushSettings.delay = originalDelay;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Push Duration
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Push Duration: {pushSettings.duration:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            pushSettings.duration = Mathf.Max(0f, pushSettings.duration - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            pushSettings.duration += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pushSettings.duration = originalDuration;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Initial Push Force
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Initial Push Force: {pushSettings.initialPushForce:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            pushSettings.initialPushForce = Mathf.Max(0f, pushSettings.initialPushForce - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            pushSettings.initialPushForce += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pushSettings.initialPushForce = originalInitialPush;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// "PumpMechanic" section: tweak pump time and pump force.
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

    public override bool IsValid => (pumpMechanic != null);

    public override void FindComponents()
    {
        var found = GameObject.FindObjectOfType<PumpMechanic>();
        if (found != null)
        {
            if (!captured)
            {
                originalPumpTime = found.pumpTime;
                if (PumpForceField != null)
                {
                    originalPumpingForce = Convert.ToSingle(PumpForceField.GetValue(found));
                }
                captured = true;
            }
            pumpMechanic = found;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Pump Mechanic Settings —");
        if (!IsValid)
        {
            GUILayout.Label("PumpMechanic not found");
            GUILayout.Space(8);
            return;
        }

        // Pump Time
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Pump Time: {pumpMechanic.pumpTime:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            pumpMechanic.pumpTime = Mathf.Max(0f, pumpMechanic.pumpTime - tweakStep * 0.1f);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            pumpMechanic.pumpTime += tweakStep * 0.1f;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pumpMechanic.pumpTime = originalPumpTime;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Pump Force
        if (PumpForceField != null)
        {
            float pumpForce = Convert.ToSingle(PumpForceField.GetValue(pumpMechanic));
            GUILayout.BeginHorizontal();
            GUILayout.Label($"Pump Force: {pumpForce:F1}", GUILayout.Width(180));
            if (GUILayout.Button("<", GUILayout.Width(25)))
            {
                pumpForce = Mathf.Max(0f, pumpForce - tweakStep);
                PumpForceField.SetValue(pumpMechanic, pumpForce);
            }
            if (GUILayout.Button(">", GUILayout.Width(25)))
            {
                pumpForce += tweakStep;
                PumpForceField.SetValue(pumpMechanic, pumpForce);
            }
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            {
                PumpForceField.SetValue(pumpMechanic, originalPumpingForce);
            }
            GUILayout.EndHorizontal();
        }
        else
        {
            GUILayout.Label("Pump Force unavailable (field removed in current build)");
        }

        GUILayout.Space(8);
    }
}

/// <summary>
/// "Name Tag" section: edit the local player's displayed name (rich text supported).
/// </summary>
public class NameTagSection : TweakSection
{
    private Component localTag;
    private string nameInput = string.Empty;
    private string statusMessage = string.Empty;
    private float statusTimestamp = -999f;

    public override bool IsValid => localTag != null;

    public override void FindComponents()
    {
        var found = NameTagHelper.FindLocalPlayerTag();
        if (found != null)
        {
            if (localTag != found)
            {
                localTag = found;
                nameInput = NameTagHelper.GetCurrentName(localTag);
            }
            else if (string.IsNullOrEmpty(nameInput))
            {
                nameInput = NameTagHelper.GetCurrentName(localTag);
            }
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("- Name Tag -");
        if (!IsValid)
        {
            GUILayout.Label("Waiting for local player...");
            GUILayout.Space(8);
            return;
        }

        GUILayout.Label("Use TMP rich text for color (e.g. <color=#FF66FF>Your Name</color>).");

        GUILayout.BeginHorizontal();
        nameInput = GUILayout.TextField(nameInput ?? string.Empty, GUILayout.Width(260));
        if (GUILayout.Button("Apply", GUILayout.Width(60)))
        {
            if (NameTagHelper.TryApplyName(nameInput, out string error))
            {
                statusMessage = "Name update sent.";
            }
            else
            {
                statusMessage = error;
            }
            statusTimestamp = Time.time;
        }
        GUILayout.EndHorizontal();

        if (!string.IsNullOrEmpty(statusMessage))
        {
            if (Time.time - statusTimestamp > 4f)
            {
                statusMessage = string.Empty;
            }
            else
            {
                GUILayout.Label(statusMessage);
            }
        }

        GUILayout.Space(8);
    }
}

/// <summary>
/// "Trick Scoring" section: configure display and fade durations.
/// </summary>
public class TrickScoringSection : TweakSection
{
    private const float DefaultDisplayDuration = 4f;
    private const float DefaultFadeDuration = 1.5f;

    public override bool IsValid => TrickScoreController.Instance != null;

    public override void FindComponents()
    {
        // Controller is initialised by the mod's entry point; nothing to resolve here.
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("- Trick Scoring -");
        if (!IsValid)
        {
            GUILayout.Label("Trick scoring controller not found");
            GUILayout.Space(8);
            return;
        }

        var controller = TrickScoreController.Instance;

        GUILayout.Space(4);

        GUILayout.BeginHorizontal();
        GUILayout.Label($"Display Duration: {controller.DisplayDuration:F1}s", GUILayout.Width(200));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            controller.DisplayDuration = Mathf.Max(0f, controller.DisplayDuration - 0.5f);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            controller.DisplayDuration += 0.5f;
        if (GUILayout.Button("Reset", GUILayout.Width(60)))
            controller.DisplayDuration = DefaultDisplayDuration;
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label($"Fade Duration: {controller.FadeDuration:F1}s", GUILayout.Width(200));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            controller.FadeDuration = Mathf.Max(0f, controller.FadeDuration - 0.2f);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            controller.FadeDuration += 0.2f;
        if (GUILayout.Button("Reset", GUILayout.Width(60)))
            controller.FadeDuration = DefaultFadeDuration;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// The main Menu that simply holds a list of TweakSection instances and loops over them.
/// </summary>
public class Menu : MonoBehaviour
{
    [Header("UI Settings")]
    public Vector2 windowSize = new Vector2(520, 800);
    public float tweakStep = 10f;
    private string tweakStepString;
    private Rect windowRect;
    private bool isMenuOpen;
    private Vector2 scrollPosition = Vector2.zero;

    // A dedicated gravityStep (used only by GravitySection)
    public float gravityStep = 0.5f;

    // List of all registered sections. Add/remove here to enable/disable entire sections.
    private List<TweakSection> sections;

    private void Start()
    {
        tweakStepString = tweakStep.ToString("F1");
        windowRect = new Rect(10, 10, windowSize.x, windowSize.y);

        // Instantiate each section and store it in the list.
        sections = new List<TweakSection>
        {
            new GravitySection(),
            new HopSection(),
            new TimeSpeedSection(),
            new InvectorSection(),
            new WheelSection(),
            new PushSection(),
            new PumpSection(),
            new NameTagSection(),
            new TrickScoringSection()
        };
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Every frame, let each section try to find its components (and capture originals).
        foreach (var section in sections)
        {
            section.FindComponents();
        }
    }

    private void OnGUI()
    {
        if (!isMenuOpen)
        {
            if (GUI.Button(new Rect(10, 10, 30, 30), ">"))
                isMenuOpen = true;
            return;
        }

        windowRect = GUI.Window(0, windowRect, DrawContents, "Scooter Flow Tool-Kit v1.0.1");
    }

    private void DrawContents(int id)
    {
        GUILayout.BeginVertical();

        /***************************************
         *  • General Settings                 *
         ***************************************/
        GUILayout.Label("— General Settings —");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Tweak Step:", GUILayout.Width(80));

        // Show the TextField, but parse only when “Apply” is clicked.
        tweakStepString = GUILayout.TextField(tweakStepString, GUILayout.Width(80));
        if (GUILayout.Button("Set", GUILayout.Width(50)))
        {
            if (float.TryParse(tweakStepString, out float parsed))
                tweakStep = Mathf.Max(0f, parsed);
            else
                tweakStepString = tweakStep.ToString("F1");
        }
        if (GUILayout.Button("Reset", GUILayout.Width(60)))
        {
            tweakStep = 10f;
            tweakStepString = "10.0";
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(8);

        /***************************************
         *  • ScrollView (all sections)        *
         ***************************************/
        float headerHeight = 40f; // approx for General + tweak-step row
        float footerHeight = 60f; // approx for “Close” button area
        float scrollViewHeight = windowSize.y - headerHeight - footerHeight;

        scrollPosition = GUILayout.BeginScrollView(
            scrollPosition,
            false,
            true,
            GUILayout.Width(windowSize.x - 20),
            GUILayout.Height(scrollViewHeight)
        );

        {
            GUILayout.BeginVertical();

            // Draw each registered section. Pass tweakStep; GravitySection can ignore or apply its own gravityStep internally.
            foreach (var section in sections)
            {
                section.DrawGUI(tweakStep);
            }

            GUILayout.EndVertical();
        }
        GUILayout.EndScrollView();

        /***************************************
         *  • Footer: “Close” button           *
         ***************************************/
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Close", GUILayout.Width(60)))
            isMenuOpen = false;
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        // Make the window draggable (title bar height = 20 px)
        GUI.DragWindow(new Rect(0, 0, windowSize.x, 20));
    }
}

