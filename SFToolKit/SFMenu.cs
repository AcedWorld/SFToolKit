using System;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using Rewired;

/// <summary>
/// Base class for any “tweak‐section.” Each section finds its own components,
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
/// “Physics: Gravity” section, with its own fields and original‐value logic.
/// </summary>
public class GravitySection : TweakSection
{
    private bool hasCapturedOriginal = false;
    private Vector3 originalGravity;
    private bool found = false;

    // gravityStep is taken from Menu; we’ll assume the Menu instance passes it in DrawGUI.
    public override bool IsValid => true; // always “valid,” since Physics.gravity is static.

    public override void FindComponents()
    {
        if (!hasCapturedOriginal)
        {
            originalGravity = Physics.gravity;
            hasCapturedOriginal = true;
        }
        found = true;
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
/// “Hop & Sub‐Settings” section.
/// Finds a Hop instance, its sub‐settings (HopTimerSettings, NormalHopSettings, etc.),
/// captures originals, and draws all the sliders under one foldout header.
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
    private float originalNormalMinJoystick;

    private bool capturedLow = false;
    private float originalLowStrength;
    private float originalLowMaxJoystick;

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
                    originalNormalMinJoystick = hop.normalHopSettings.minimumTimeForJoystick;
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
                    originalLowMaxJoystick = hop.lowHopSettings.maximumTimeForJoystick;
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

        // ── HopTimerSettings ──
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

        // ── NormalHopSettings ──
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

            // Min Joystick
            GUILayout.BeginHorizontal();
            GUILayout.Label($"Min Joystick: {normalHopSettings.minimumTimeForJoystick:F1}", GUILayout.Width(180));
            if (GUILayout.Button("<", GUILayout.Width(25)))
                normalHopSettings.minimumTimeForJoystick = Mathf.Max(0f, normalHopSettings.minimumTimeForJoystick - tweakStep * 0.1f);
            if (GUILayout.Button(">", GUILayout.Width(25)))
                normalHopSettings.minimumTimeForJoystick += tweakStep * 0.1f;
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedNormal)
                normalHopSettings.minimumTimeForJoystick = originalNormalMinJoystick;
            GUILayout.EndHorizontal();
        }
        else
        {
            GUILayout.Label("  (NormalHopSettings not found)");
        }
        GUILayout.Space(6);

        // ── LowHopSettings ──
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

            // Max Joystick
            GUILayout.BeginHorizontal();
            GUILayout.Label($"Max Joystick: {lowHopSettings.maximumTimeForJoystick:F1}", GUILayout.Width(180));
            if (GUILayout.Button("<", GUILayout.Width(25)))
                lowHopSettings.maximumTimeForJoystick = Mathf.Max(0f, lowHopSettings.maximumTimeForJoystick - tweakStep * 0.1f);
            if (GUILayout.Button(">", GUILayout.Width(25)))
                lowHopSettings.maximumTimeForJoystick += tweakStep * 0.1f;
            if (GUILayout.Button("Reset", GUILayout.Width(60)) && capturedLow)
                lowHopSettings.maximumTimeForJoystick = originalLowMaxJoystick;
            GUILayout.EndHorizontal();
        }
        else
        {
            GUILayout.Label("  (LowHopSettings not found)");
        }
        GUILayout.Space(6);

        // ── NoseManualHopSettings ──
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

        // ── FootJamHopSettings ──
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
/// “TimeSpeed” section: slomo scale + allowPauseTime toggle.
/// </summary>
public class TimeSpeedSection : TweakSection
{
    private TimeSpeed timeSpeed;
    private bool captured = false;
    private float originalSlowMotion;
    private bool originalAllowPauseTime;

    public override bool IsValid => timeSpeed != null;

    public override void FindComponents()
    {
        var found = GameObject.FindObjectOfType<TimeSpeed>();
        if (found != null)
        {
            if (!captured)
            {
                originalSlowMotion = found.slowMotion;
                originalAllowPauseTime = found.allowPauseTime;
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
        GUILayout.Space(4);

        // allowPauseTime toggle
        GUILayout.BeginHorizontal();
        timeSpeed.allowPauseTime = GUILayout.Toggle(timeSpeed.allowPauseTime, "Allow PauseTime", GUILayout.ExpandWidth(false));
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
        {
            timeSpeed.allowPauseTime = originalAllowPauseTime;
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “Invector Animator & Motor” section: anim speed, speedMultiplier, airSpeed, rollSpeed, rollRotationSpeed.
/// </summary>
public class InvectorSection : TweakSection
{
    private vThirdPersonMotor invectorController;
    private Animator invectorAnimator;

    private bool captured = false;
    private float originalAnimSpeed;
    private float originalSpeedMultiplier;
    private float originalAirSpeed;
    private float originalRollSpeed;
    private float originalRollRotSpeed;

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
                    originalSpeedMultiplier = ctrl.speedMultiplier;
                    originalAirSpeed = ctrl.airSpeed;
                    originalRollSpeed = ctrl.rollSpeed;
                    originalRollRotSpeed = ctrl.rollRotationSpeed;
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
        GUILayout.Space(4);

        // Walk Mult (speedMultiplier)
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Walk Mult: {invectorController.speedMultiplier:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            invectorController.speedMultiplier = Mathf.Max(0.1f, invectorController.speedMultiplier - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            invectorController.speedMultiplier += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            invectorController.speedMultiplier = originalSpeedMultiplier;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Air Speed
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Air Speed: {invectorController.airSpeed:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            invectorController.airSpeed = Mathf.Max(0f, invectorController.airSpeed - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            invectorController.airSpeed += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            invectorController.airSpeed = originalAirSpeed;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Roll Speed
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Roll Speed: {invectorController.rollSpeed:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            invectorController.rollSpeed = Mathf.Max(0f, invectorController.rollSpeed - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            invectorController.rollSpeed += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            invectorController.rollSpeed = originalRollSpeed;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Roll Rot Speed
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Roll Rot Spd: {invectorController.rollRotationSpeed:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            invectorController.rollRotationSpeed = Mathf.Max(0f, invectorController.rollRotationSpeed - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            invectorController.rollRotationSpeed += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            invectorController.rollRotationSpeed = originalRollRotSpeed;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “ScooterController Core” section: just hopTilt for now.
/// </summary>
public class ScooterCoreSection : TweakSection
{
    private ScooterController scooter;
    private bool captured = false;
    private float originalHopTilt;

    public override bool IsValid => (scooter != null);

    public override void FindComponents()
    {
        var found = GameObject.FindObjectOfType<ScooterController>();
        if (found != null)
        {
            if (!captured)
            {
                originalHopTilt = found.hopTilt;
                captured = true;
            }
            scooter = found;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— ScooterController Core —");
        if (!IsValid)
        {
            GUILayout.Label("ScooterController not found");
            GUILayout.Space(8);
            return;
        }

        GUILayout.BeginHorizontal();
        GUILayout.Label($"Hop Tilt: {scooter.hopTilt:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            scooter.hopTilt = Mathf.Max(0f, scooter.hopTilt - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            scooter.hopTilt += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            scooter.hopTilt = originalHopTilt;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “RotationSettings (Scooter)” section, controlling flipSpeed, spinSpeed, etc.
/// </summary>
public class RotationSection : TweakSection
{
    private ScooterController scooter;
    private RotationSettings rotSettings;

    private bool captured = false;
    private float originalFlipSpeed;
    private float originalSpinSpeed;
    private float originalFastSpin;
    private float originalSpinDampen;
    private float originalNormToFastDampen;
    private bool originalDisableLandCorrectionOnFlip;

    public override bool IsValid => (rotSettings != null);

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter != null && foundScooter.rotationSettings != null)
        {
            if (!captured)
            {
                var rs = foundScooter.rotationSettings;
                originalFlipSpeed = rs.flipSpeed;
                originalSpinSpeed = rs.spinSpeed;
                originalFastSpin = rs.fastSpin;
                originalSpinDampen = rs.spinDampen;
                originalNormToFastDampen = rs.normalToFastDampen;
                originalDisableLandCorrectionOnFlip = rs.disableLandCorrectionOnFlip;
                captured = true;
            }
            scooter = foundScooter;
            rotSettings = foundScooter.rotationSettings;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Rotation Settings (Scooter) —");
        if (!IsValid)
        {
            GUILayout.Label("RotationSettings not found");
            GUILayout.Space(8);
            return;
        }

        // Flip Speed
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Flip Speed: {rotSettings.flipSpeed:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            rotSettings.flipSpeed = Mathf.Max(0f, rotSettings.flipSpeed - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            rotSettings.flipSpeed += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            rotSettings.flipSpeed = originalFlipSpeed;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Spin Speed
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Spin Speed: {rotSettings.spinSpeed:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            rotSettings.spinSpeed = Mathf.Max(0f, rotSettings.spinSpeed - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            rotSettings.spinSpeed += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            rotSettings.spinSpeed = originalSpinSpeed;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Fast Spin
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Fast Spin: {rotSettings.fastSpin:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            rotSettings.fastSpin = Mathf.Max(0f, rotSettings.fastSpin - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            rotSettings.fastSpin += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            rotSettings.fastSpin = originalFastSpin;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Spin Dampen
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Spin Dampen: {rotSettings.spinDampen:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            rotSettings.spinDampen = Mathf.Max(0f, rotSettings.spinDampen - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            rotSettings.spinDampen += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            rotSettings.spinDampen = originalSpinDampen;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Norm→Fast Dampen
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Norm→Fast Damp: {rotSettings.normalToFastDampen:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            rotSettings.normalToFastDampen = Mathf.Max(0f, rotSettings.normalToFastDampen - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            rotSettings.normalToFastDampen += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            rotSettings.normalToFastDampen = originalNormToFastDampen;
        GUILayout.EndHorizontal();
        GUILayout.Space(4);

        // disableLandCorrectionOnFlip toggle
        GUILayout.BeginHorizontal();
        rotSettings.disableLandCorrectionOnFlip = GUILayout.Toggle(
            rotSettings.disableLandCorrectionOnFlip,
            "Disable LandCorrection On Flip",
            GUILayout.ExpandWidth(false)
        );
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            rotSettings.disableLandCorrectionOnFlip = originalDisableLandCorrectionOnFlip;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “ScooterWheel Settings” section: maxSteeringAngle, fakieSteerAngle, steerDampen, maxMotorTorque, stopDrag.
/// </summary>
public class WheelSection : TweakSection
{
    private ScooterController scooter;
    private ScooterWheelSettings wheelSettings;

    private bool captured = false;
    private float originalMaxSteer;
    private float originalFakieSteer;
    private float originalSteerDampen;
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
                originalMaxSteer = ws.maxSteeringAngle;
                originalFakieSteer = ws.fakieSteerAngle;
                originalSteerDampen = ws.steerDampen;
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

        // Max Steering Angle
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Max Steering Angle: {wheelSettings.maxSteeringAngle:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            wheelSettings.maxSteeringAngle = Mathf.Max(0f, wheelSettings.maxSteeringAngle - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            wheelSettings.maxSteeringAngle += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            wheelSettings.maxSteeringAngle = originalMaxSteer;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Fakie Steer Angle
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Fakie Steer Angle: {wheelSettings.fakieSteerAngle:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            wheelSettings.fakieSteerAngle = Mathf.Max(0f, wheelSettings.fakieSteerAngle - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            wheelSettings.fakieSteerAngle += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            wheelSettings.fakieSteerAngle = originalFakieSteer;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Steer Dampen
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Steer Dampen: {wheelSettings.steerDampen:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            wheelSettings.steerDampen = Mathf.Max(0f, wheelSettings.steerDampen - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            wheelSettings.steerDampen += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            wheelSettings.steerDampen = originalSteerDampen;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

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
/// “Fakie Settings” section: fakieThreshold.
/// </summary>
public class FakieSection : TweakSection
{
    private ScooterController scooter;
    private FakieSettings fakieSettings;

    private bool captured = false;
    private float originalThreshold;

    public override bool IsValid => (fakieSettings != null);

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter != null && foundScooter.fakieSettings != null)
        {
            if (!captured)
            {
                originalThreshold = foundScooter.fakieSettings.fakieThreshold;
                captured = true;
            }
            scooter = foundScooter;
            fakieSettings = foundScooter.fakieSettings;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Fakie Settings —");
        if (!IsValid)
        {
            GUILayout.Label("FakieSettings not found");
            GUILayout.Space(8);
            return;
        }

        GUILayout.BeginHorizontal();
        GUILayout.Label($"Fakie Threshold: {fakieSettings.fakieThreshold:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            fakieSettings.fakieThreshold = Mathf.Max(0f, fakieSettings.fakieThreshold - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            fakieSettings.fakieThreshold += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            fakieSettings.fakieThreshold = originalThreshold;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “Ground Information” section: xDivider, zDivider, debug toggle, raycastOffset xyz, layerMask.
/// </summary>
public class GroundSection : TweakSection
{
    private ScooterController scooter;
    private GroundInformation groundInformation;

    private bool captured = false;
    private float originalXDivider;
    private float originalZDivider;
    private bool originalDebug;
    private Vector3 originalRaycastOffset;
    private LayerMask originalLayerMask;

    public override bool IsValid => (groundInformation != null);

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter != null && foundScooter.groundInformation != null)
        {
            if (!captured)
            {
                var gi = foundScooter.groundInformation;
                originalXDivider = gi.xDivider;
                originalZDivider = gi.zDivider;
                originalDebug = gi.debug;
                originalRaycastOffset = gi.raycastOffset;
                originalLayerMask = gi.layerMask;
                captured = true;
            }
            scooter = foundScooter;
            groundInformation = foundScooter.groundInformation;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Ground Information —");
        if (!IsValid)
        {
            GUILayout.Label("GroundInformation not found");
            GUILayout.Space(8);
            return;
        }

        // X Divider
        GUILayout.BeginHorizontal();
        GUILayout.Label($"X Divider: {groundInformation.xDivider:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            groundInformation.xDivider = Mathf.Max(0.1f, groundInformation.xDivider - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            groundInformation.xDivider += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            groundInformation.xDivider = originalXDivider;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Z Divider
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Z Divider: {groundInformation.zDivider:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            groundInformation.zDivider = Mathf.Max(0.1f, groundInformation.zDivider - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            groundInformation.zDivider += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            groundInformation.zDivider = originalZDivider;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Debug Raycast toggle
        GUILayout.BeginHorizontal();
        groundInformation.debug = GUILayout.Toggle(groundInformation.debug, "Debug Raycast", GUILayout.ExpandWidth(false));
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            groundInformation.debug = originalDebug;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Raycast Offset vector
        GUILayout.Label($"Raycast Offset: ({groundInformation.raycastOffset.x:F1}, {groundInformation.raycastOffset.y:F1}, {groundInformation.raycastOffset.z:F1})");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("RX -", GUILayout.Width(50))) groundInformation.raycastOffset.x -= tweakStep;
        if (GUILayout.Button("RX +", GUILayout.Width(50))) groundInformation.raycastOffset.x += tweakStep;
        if (GUILayout.Button("RY -", GUILayout.Width(50))) groundInformation.raycastOffset.y -= tweakStep;
        if (GUILayout.Button("RY +", GUILayout.Width(50))) groundInformation.raycastOffset.y += tweakStep;
        if (GUILayout.Button("RZ -", GUILayout.Width(50))) groundInformation.raycastOffset.z -= tweakStep;
        if (GUILayout.Button("RZ +", GUILayout.Width(50))) groundInformation.raycastOffset.z += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            groundInformation.raycastOffset = originalRaycastOffset;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // LayerMask
        GUILayout.Label($"LayerMask: {groundInformation.layerMask.value}");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("LM -", GUILayout.Width(40)))
            groundInformation.layerMask = ~(~groundInformation.layerMask << 1) >> 1;
        if (GUILayout.Button("LM +", GUILayout.Width(40)))
            groundInformation.layerMask = (groundInformation.layerMask << 1) | 1;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            groundInformation.layerMask = originalLayerMask;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “FootJam Settings (scooter)” section: MaxJamAngle, MaxJamFall, WheelDamp, DefaultWheelDamp.
/// </summary>
public class FootJamSection : TweakSection
{
    private ScooterController scooter;
    private FootJamSettings footJamSettings;

    private bool captured = false;
    private float originalMaxJamAngle;
    private float originalMaxJamFall;
    private float originalWheelDamp;
    private float originalDefaultWheelDamp;

    public override bool IsValid => (footJamSettings != null);

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter != null && foundScooter.footJamSettings != null)
        {
            if (!captured)
            {
                var fj = foundScooter.footJamSettings;
                originalMaxJamAngle = fj.MaxJamAngle;
                originalMaxJamFall = fj.MaxJamFall;
                originalWheelDamp = fj.WheelDamp;
                originalDefaultWheelDamp = fj.DefaultWheelDamp;
                captured = true;
            }
            scooter = foundScooter;
            footJamSettings = foundScooter.footJamSettings;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Foot Jam Settings —");
        if (!IsValid)
        {
            GUILayout.Label("FootJamSettings not found");
            GUILayout.Space(8);
            return;
        }

        // Max Jam Angle
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Max Jam Angle: {footJamSettings.MaxJamAngle:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            footJamSettings.MaxJamAngle = Mathf.Max(0f, footJamSettings.MaxJamAngle - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            footJamSettings.MaxJamAngle += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            footJamSettings.MaxJamAngle = originalMaxJamAngle;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Max Jam Fall
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Max Jam Fall: {footJamSettings.MaxJamFall:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            footJamSettings.MaxJamFall = Mathf.Max(0f, footJamSettings.MaxJamFall - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            footJamSettings.MaxJamFall += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            footJamSettings.MaxJamFall = originalMaxJamFall;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Wheel Dampen
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Wheel Dampen: {footJamSettings.WheelDamp:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            footJamSettings.WheelDamp = Mathf.Max(0f, footJamSettings.WheelDamp - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            footJamSettings.WheelDamp += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            footJamSettings.WheelDamp = originalWheelDamp;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Default Wheel Dampen
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Default Wheel Damp: {footJamSettings.DefaultWheelDamp:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            footJamSettings.DefaultWheelDamp = Mathf.Max(0f, footJamSettings.DefaultWheelDamp - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            footJamSettings.DefaultWheelDamp += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            footJamSettings.DefaultWheelDamp = originalDefaultWheelDamp;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “VelocityMagnitudeSettings” section: VelocityMagnitudeDelay.
/// </summary>
public class VelocityMagnitudeSection : TweakSection
{
    private ScooterController scooter;
    private VelocityMagnitudeSettings velocityMagnitudeSettings;

    private bool captured = false;
    private float originalDelay;

    public override bool IsValid => (velocityMagnitudeSettings != null);

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter != null && foundScooter.velocityMagnitudeSettings != null)
        {
            if (!captured)
            {
                originalDelay = foundScooter.velocityMagnitudeSettings.VelocityMagnitudeDelay;
                captured = true;
            }
            scooter = foundScooter;
            velocityMagnitudeSettings = foundScooter.velocityMagnitudeSettings;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Velocity Magnitude Settings —");
        if (!IsValid)
        {
            GUILayout.Label("VelocityMagnitudeSettings not found");
            GUILayout.Space(8);
            return;
        }

        GUILayout.BeginHorizontal();
        GUILayout.Label($"Velocity Delay: {velocityMagnitudeSettings.VelocityMagnitudeDelay:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            velocityMagnitudeSettings.VelocityMagnitudeDelay = Mathf.Max(0f, velocityMagnitudeSettings.VelocityMagnitudeDelay - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            velocityMagnitudeSettings.VelocityMagnitudeDelay += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            velocityMagnitudeSettings.VelocityMagnitudeDelay = originalDelay;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “CrashLandSettings” section: FrontInsideAlignedAngle, FrontOutsideAlignedAngle, BackInsideAlignedAngle, BackOutsideAlignedAngle,
/// AlignedLandingVelThreshold, FallFlatAngle, FallFlatVelThreshold.
/// </summary>
public class CrashLandSection : TweakSection
{
    private ScooterController scooter;
    private CrashLandSettings crashLandSettings;

    private bool captured = false;
    private float originalFrontIn;
    private float originalFrontOut;
    private float originalBackIn;
    private float originalBackOut;
    private float originalAlignVel;
    private float originalFallFlatAngle;
    private float originalFallFlatVel;

    public override bool IsValid => (crashLandSettings != null);

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter != null && foundScooter.crashLandSettings != null)
        {
            if (!captured)
            {
                var cl = foundScooter.crashLandSettings;
                originalFrontIn = cl.FrontInsideAlignedAngle;
                originalFrontOut = cl.FrontOutsideAlignedAngle;
                originalBackIn = cl.BackInsideAlignedAngle;
                originalBackOut = cl.BackOutsideAlignedAngle;
                originalAlignVel = cl.AlignedLandingVelThreshold;
                originalFallFlatAngle = cl.FallFlatAngle;
                originalFallFlatVel = cl.FallFlatVelThreshold;
                captured = true;
            }
            scooter = foundScooter;
            crashLandSettings = foundScooter.crashLandSettings;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Crash Land Settings —");
        if (!IsValid)
        {
            GUILayout.Label("CrashLandSettings not found");
            GUILayout.Space(8);
            return;
        }

        // Front In Align Angle
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Front In Align Angle: {crashLandSettings.FrontInsideAlignedAngle:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            crashLandSettings.FrontInsideAlignedAngle = Mathf.Max(0f, crashLandSettings.FrontInsideAlignedAngle - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            crashLandSettings.FrontInsideAlignedAngle += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            crashLandSettings.FrontInsideAlignedAngle = originalFrontIn;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Front Out Align Angle
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Front Out Align Angle: {crashLandSettings.FrontOutsideAlignedAngle:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            crashLandSettings.FrontOutsideAlignedAngle = Mathf.Max(0f, crashLandSettings.FrontOutsideAlignedAngle - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            crashLandSettings.FrontOutsideAlignedAngle += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            crashLandSettings.FrontOutsideAlignedAngle = originalFrontOut;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Back In Align Angle
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Back In Align Angle: {crashLandSettings.BackInsideAlignedAngle:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            crashLandSettings.BackInsideAlignedAngle = Mathf.Max(0f, crashLandSettings.BackInsideAlignedAngle - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            crashLandSettings.BackInsideAlignedAngle += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            crashLandSettings.BackInsideAlignedAngle = originalBackIn;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Back Out Align Angle
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Back Out Align Angle: {crashLandSettings.BackOutsideAlignedAngle:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            crashLandSettings.BackOutsideAlignedAngle = Mathf.Max(0f, crashLandSettings.BackOutsideAlignedAngle - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            crashLandSettings.BackOutsideAlignedAngle += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            crashLandSettings.BackOutsideAlignedAngle = originalBackOut;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Align Landing Vel Threshold
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Align Landing Vel Thresh: {crashLandSettings.AlignedLandingVelThreshold:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            crashLandSettings.AlignedLandingVelThreshold = Mathf.Max(0f, crashLandSettings.AlignedLandingVelThreshold - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            crashLandSettings.AlignedLandingVelThreshold += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            crashLandSettings.AlignedLandingVelThreshold = originalAlignVel;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Fall Flat Angle
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Fall Flat Angle: {crashLandSettings.FallFlatAngle:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            crashLandSettings.FallFlatAngle = Mathf.Max(0f, crashLandSettings.FallFlatAngle - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            crashLandSettings.FallFlatAngle += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            crashLandSettings.FallFlatAngle = originalFallFlatAngle;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Fall Flat Vel Threshold
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Fall Flat Vel Thresh: {crashLandSettings.FallFlatVelThreshold:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            crashLandSettings.FallFlatVelThreshold = Mathf.Max(0f, crashLandSettings.FallFlatVelThreshold - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            crashLandSettings.FallFlatVelThreshold += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            crashLandSettings.FallFlatVelThreshold = originalFallFlatVel;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “RevertSettings” section: CrashAngle, CrashTime, torqueStart, torqueEnd, RevertTorque, RevertY, RevertZ.
/// </summary>
public class RevertSection : TweakSection
{
    private ScooterController scooter;
    private RevertSettings revertSettings;

    private bool captured = false;
    private float originalCrashAngle;
    private float originalCrashTime;
    private float originalTorqueStart;
    private float originalTorqueEnd;
    private float originalRevertTorque;
    private float originalRevertY;
    private float originalRevertZ;

    public override bool IsValid => (revertSettings != null);

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter != null && foundScooter.revertSettings != null)
        {
            if (!captured)
            {
                var rs = foundScooter.revertSettings;
                originalCrashAngle = rs.CrashAngle;
                originalCrashTime = rs.CrashTime;
                originalTorqueStart = rs.torqueStart;
                originalTorqueEnd = rs.torqueEnd;
                originalRevertTorque = rs.RevertTorque;
                originalRevertY = rs.RevertY;
                originalRevertZ = rs.RevertZ;
                captured = true;
            }
            scooter = foundScooter;
            revertSettings = foundScooter.revertSettings;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Revert Settings —");
        if (!IsValid)
        {
            GUILayout.Label("RevertSettings not found");
            GUILayout.Space(8);
            return;
        }

        // Crash Angle
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Crash Angle: {revertSettings.CrashAngle:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            revertSettings.CrashAngle = Mathf.Max(0f, revertSettings.CrashAngle - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            revertSettings.CrashAngle += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            revertSettings.CrashAngle = originalCrashAngle;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Crash Time
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Crash Time: {revertSettings.CrashTime:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            revertSettings.CrashTime = Mathf.Max(0f, revertSettings.CrashTime - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            revertSettings.CrashTime += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            revertSettings.CrashTime = originalCrashTime;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Torque Start
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Torque Start: {revertSettings.torqueStart:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            revertSettings.torqueStart = Mathf.Max(0f, revertSettings.torqueStart - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            revertSettings.torqueStart += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            revertSettings.torqueStart = originalTorqueStart;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Torque End
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Torque End: {revertSettings.torqueEnd:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            revertSettings.torqueEnd = Mathf.Max(0f, revertSettings.torqueEnd - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            revertSettings.torqueEnd += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            revertSettings.torqueEnd = originalTorqueEnd;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Revert Torque
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Revert Torque: {revertSettings.RevertTorque:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            revertSettings.RevertTorque = Mathf.Max(0f, revertSettings.RevertTorque - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            revertSettings.RevertTorque += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            revertSettings.RevertTorque = originalRevertTorque;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Revert Y
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Revert Y: {revertSettings.RevertY:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            revertSettings.RevertY = Mathf.Max(0f, revertSettings.RevertY - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            revertSettings.RevertY += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            revertSettings.RevertY = originalRevertY;
        GUILayout.EndHorizontal();
        GUILayout.Space(2);

        // Revert Z
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Revert Z: {revertSettings.RevertZ:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            revertSettings.RevertZ = Mathf.Max(0f, revertSettings.RevertZ - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            revertSettings.RevertZ += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            revertSettings.RevertZ = originalRevertZ;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “CentreOfMassSettings” section: CentreOfMass (x,y,z), InAir (x,y,z), Normal (x,y,z).
/// </summary>
public class CentreOfMassSection : TweakSection
{
    private ScooterController scooter;
    private CentreOfMassSettings comSettings;

    private bool captured = false;
    private Vector3 originalCentre;
    private Vector3 originalInAir;
    private Vector3 originalNormal;

    public override bool IsValid => (comSettings != null);

    public override void FindComponents()
    {
        var foundScooter = GameObject.FindObjectOfType<ScooterController>();
        if (foundScooter != null && foundScooter.centreOfMassSettings != null)
        {
            if (!captured)
            {
                var com = foundScooter.centreOfMassSettings;
                originalCentre = com.CentreOfMass;
                originalInAir = com.InAir;
                originalNormal = com.Normal;
                captured = true;
            }
            scooter = foundScooter;
            comSettings = foundScooter.centreOfMassSettings;
        }
    }

    public override void DrawGUI(float tweakStep)
    {
        GUILayout.Label("— Centre Of Mass Settings —");
        if (!IsValid)
        {
            GUILayout.Label("CentreOfMassSettings not found");
            GUILayout.Space(8);
            return;
        }

        // CentreOfMass vector
        GUILayout.Label($"CentreOfMass: ({comSettings.CentreOfMass.x:F1}, {comSettings.CentreOfMass.y:F1}, {comSettings.CentreOfMass.z:F1})");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("CM X -", GUILayout.Width(65)))
            comSettings.CentreOfMass.x -= tweakStep;
        if (GUILayout.Button("CM X +", GUILayout.Width(65)))
            comSettings.CentreOfMass.x += tweakStep;
        if (GUILayout.Button("CM Y -", GUILayout.Width(65)))
            comSettings.CentreOfMass.y -= tweakStep;
        if (GUILayout.Button("CM Y +", GUILayout.Width(65)))
            comSettings.CentreOfMass.y += tweakStep;
        if (GUILayout.Button("CM Z -", GUILayout.Width(65)))
            comSettings.CentreOfMass.z -= tweakStep;
        if (GUILayout.Button("CM Z +", GUILayout.Width(65)))
            comSettings.CentreOfMass.z += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            comSettings.CentreOfMass = originalCentre;
        GUILayout.EndHorizontal();
        GUILayout.Space(4);

        // InAir vector
        GUILayout.Label($"In Air COM: ({comSettings.InAir.x:F1}, {comSettings.InAir.y:F1}, {comSettings.InAir.z:F1})");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("IA X -", GUILayout.Width(60)))
            comSettings.InAir.x -= tweakStep;
        if (GUILayout.Button("IA X +", GUILayout.Width(60)))
            comSettings.InAir.x += tweakStep;
        if (GUILayout.Button("IA Y -", GUILayout.Width(60)))
            comSettings.InAir.y -= tweakStep;
        if (GUILayout.Button("IA Y +", GUILayout.Width(60)))
            comSettings.InAir.y += tweakStep;
        if (GUILayout.Button("IA Z -", GUILayout.Width(60)))
            comSettings.InAir.z -= tweakStep;
        if (GUILayout.Button("IA Z +", GUILayout.Width(60)))
            comSettings.InAir.z += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            comSettings.InAir = originalInAir;
        GUILayout.EndHorizontal();
        GUILayout.Space(4);

        // Normal vector
        GUILayout.Label($"Normal COM: ({comSettings.Normal.x:F1}, {comSettings.Normal.y:F1}, {comSettings.Normal.z:F1})");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("N X -", GUILayout.Width(60)))
            comSettings.Normal.x -= tweakStep;
        if (GUILayout.Button("N X +", GUILayout.Width(60)))
            comSettings.Normal.x += tweakStep;
        if (GUILayout.Button("N Y -", GUILayout.Width(60)))
            comSettings.Normal.y -= tweakStep;
        if (GUILayout.Button("N Y +", GUILayout.Width(60)))
            comSettings.Normal.y += tweakStep;
        if (GUILayout.Button("N Z -", GUILayout.Width(60)))
            comSettings.Normal.z -= tweakStep;
        if (GUILayout.Button("N Z +", GUILayout.Width(60)))
            comSettings.Normal.z += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            comSettings.Normal = originalNormal;
        GUILayout.EndHorizontal();

        GUILayout.Space(8);
    }
}

/// <summary>
/// “PumpMechanic” section: debug toggle, autoPump toggle, pumpTime, pumpForce.
/// </summary>
public class PumpSection : TweakSection
{
    private PumpMechanic pumpMechanic;

    private bool captured = false;
    private bool originalDebug;
    private bool originalAutoPump;
    private float originalPumpTime;
    private float originalPumpForce;

    public override bool IsValid => (pumpMechanic != null);

    public override void FindComponents()
    {
        var found = GameObject.FindObjectOfType<PumpMechanic>();
        if (found != null)
        {
            if (!captured)
            {
                originalDebug = found.debug;
                originalAutoPump = found.autoPump;
                originalPumpTime = found.pumpTime;
                originalPumpForce = found.pumpForce;
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

        // Pump debug toggle
        GUILayout.BeginHorizontal();
        pumpMechanic.debug = GUILayout.Toggle(pumpMechanic.debug, "Pump Debug", GUILayout.ExpandWidth(false));
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pumpMechanic.debug = originalDebug;
        GUILayout.EndHorizontal();
        GUILayout.Space(4);

        // Auto pump toggle
        GUILayout.BeginHorizontal();
        pumpMechanic.autoPump = GUILayout.Toggle(pumpMechanic.autoPump, "Auto Pump", GUILayout.ExpandWidth(false));
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pumpMechanic.autoPump = originalAutoPump;
        GUILayout.EndHorizontal();
        GUILayout.Space(4);

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
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Pump Force: {pumpMechanic.pumpForce:F1}", GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25)))
            pumpMechanic.pumpForce = Mathf.Max(0f, pumpMechanic.pumpForce - tweakStep);
        if (GUILayout.Button(">", GUILayout.Width(25)))
            pumpMechanic.pumpForce += tweakStep;
        if (GUILayout.Button("Reset", GUILayout.Width(60)) && captured)
            pumpMechanic.pumpForce = originalPumpForce;
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
            new ScooterCoreSection(),
            new RotationSection(),
            new WheelSection(),
            new PushSection(),
            new FakieSection(),
            new GroundSection(),
            new FootJamSection(),
            new VelocityMagnitudeSection(),
            new CrashLandSection(),
            new RevertSection(),
            new CentreOfMassSection(),
            new PumpSection()
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
        if (GUILayout.Button("Apply", GUILayout.Width(60)))
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
