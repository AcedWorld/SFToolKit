using System;
using UnityEngine;
using Invector.vCharacterController;
using Rewired;

public class Menu : MonoBehaviour
{
    [Header("UI Settings")]
    public Vector2 windowSize = new Vector2(520, 800);
    public float tweakStep = 10f;
    private string tweakStepString;
    public float gravityStep = 0.5f;

    private Rect windowRect;
    private bool isMenuOpen;
    private Vector2 scrollPosition = Vector2.zero;

    // ───────────────────────────────────────────────────────────────────────
    // References to all tweakable components that inherit from MonoBehaviour
    // or otherwise derive from UnityEngine.Object
    // ───────────────────────────────────────────────────────────────────────

    private Hop hop;
    private HopTimerSettings hopTimerSettings;
    private bool hasCapturedOriginalHopTimerSettings = false;
    private float originalHopTime;

    private NormalHopSettings normalHopSettings;
    private bool hasCapturedOriginalNormalHopSettings = false;
    private float originalNormalHopStrength;
    private float originalNormalMinJoystick;

    private LowHopSettings lowHopSettings;
    private bool hasCapturedOriginalLowHopSettings = false;
    private float originalLowHopStrength;
    private float originalLowMaxJoystick;

    private NoseManualHopSettings noseManualHopSettings;
    private bool hasCapturedOriginalNoseManualHopSettings = false;
    private float originalNoseManualStrength;

    private FootJamHopSettings footJamHopSettings;
    private bool hasCapturedOriginalFootJamHopSettings = false;
    private float originalFootJamUpStrength;
    private float originalFootJamForwardStrength;

    private TimeSpeed timeSpeed;
    private bool hasCapturedOriginalTimeSpeed = false;
    private float originalSlowMotion;
    private bool originalAllowPauseTime;

    private ScooterController scooter;
    private bool hasCapturedOriginalScooterCore = false;
    private float originalHopTilt;

    private vThirdPersonMotor invectorController;
    private Animator invectorAnimator;
    private bool hasCapturedOriginalInvector = false;
    private float originalAnimSpeed;
    private float originalSpeedMultiplier;
    private float originalAirSpeed;
    private float originalRollSpeed;
    private float originalRollRotationSpeed;

    private RotationSettings scooterRotSettings;
    private bool hasCapturedOriginalRotSettings = false;
    private float originalFlipSpeed;
    private float originalSpinSpeed;
    private float originalFastSpin;
    private float originalSpinDampen;
    private float originalNormToFastDampen;
    private bool originalDisableLandCorrectionOnFlip;

    private ScooterWheelSettings wheelSettings;
    private bool hasCapturedOriginalWheelSettings = false;
    private float originalMaxSteeringAngle;
    private float originalFakieSteerAngle;
    private float originalSteerDampen;
    private float originalMaxMotorTorque;
    private float originalStopDrag;

    private PushSettings pushSettings;
    private bool hasCapturedOriginalPushSettings = false;
    private float originalPushDelay;
    private float originalPushDuration;
    private float originalInitialPushForce;

    private FakieSettings fakieSettings;
    private bool hasCapturedOriginalFakieSettings = false;
    private float originalFakieThreshold;

    private GroundInformation groundInformation;
    private bool hasCapturedOriginalGroundInformation = false;
    private float originalXDivider;
    private float originalZDivider;
    private bool originalGroundDebug;
    private Vector3 originalRaycastOffset;
    private LayerMask originalGroundLayerMask;

    private FootJamSettings scooterFootJamSettings;
    private bool hasCapturedOriginalScooterFootJamSettings = false;
    private float originalMaxJamAngle;
    private float originalMaxJamFall;
    private float originalWheelDamp;
    private float originalDefaultWheelDamp;

    private VelocityMagnitudeSettings velocityMagnitudeSettings;
    private bool hasCapturedOriginalVelocityMagnitudeSettings = false;
    private float originalVelocityMagnitudeDelay;

    private CrashLandSettings crashLandSettings;
    private bool hasCapturedOriginalCrashLandSettings = false;
    private float originalFrontInsideAlignedAngle;
    private float originalFrontOutsideAlignedAngle;
    private float originalBackInsideAlignedAngle;
    private float originalBackOutsideAlignedAngle;
    private float originalAlignedLandingVelThreshold;
    private float originalFallFlatAngle;
    private float originalFallFlatVelThreshold;

    private RevertSettings revertSettings;
    private bool hasCapturedOriginalRevertSettings = false;
    private float originalCrashAngle;
    private float originalCrashTime;
    private float originalTorqueStart;
    private float originalTorqueEnd;
    private float originalRevertTorque;
    private float originalRevertY;
    private float originalRevertZ;

    private CentreOfMassSettings centreOfMassSettings;
    private bool hasCapturedOriginalCentreOfMassSettings = false;
    private Vector3 originalCentreOfMass;
    private Vector3 originalInAirCOM;
    private Vector3 originalNormalCOM;

    private PumpMechanic pumpMechanic;
    private bool hasCapturedOriginalPumpMechanic = false;
    private bool originalPumpDebug;
    private bool originalAutoPump;
    private float originalPumpTime;
    private float originalPumpForce;

    private Vector3 originalGravity;
    private bool hasCapturedOriginalGravity = false;
    // ───────────────────────────────────────────────────────────────────────

    private void Start()
    {
        tweakStepString = tweakStep.ToString("F1");
        windowRect = new Rect(10, 10, windowSize.x, windowSize.y);
        TryFindAllComponents();
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // If any critical reference is lost, attempt to re-find
        if (invectorController == null
            || invectorAnimator == null
            || scooter == null
            || pumpMechanic == null
            || hop == null
            || timeSpeed == null)
        {
            TryFindAllComponents();
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

        // Draw a window at windowRect; user can drag it around
        windowRect = GUI.Window(0, windowRect, DrawContents, "Scooter Flow Tool-Kit v1.0.1");
    }

    private void DrawContents(int id)
    {
        GUILayout.BeginVertical();
        GUILayout.Label("— General Settings —");

        // ──────────────────────────────────────────────────────────────────────────────────────────
        // 1) Top area: Tweak‐step controls
        // ──────────────────────────────────────────────────────────────────────────────────────────
        GUILayout.BeginHorizontal();
        GUILayout.Label("Tweak Step:", GUILayout.Width(80));

        // Show the TextField, but do NOT parse it immediately:
        tweakStepString = GUILayout.TextField(tweakStepString, GUILayout.Width(80));

        // “Apply” button: only when clicked do we parse & assign:
        if (GUILayout.Button("Apply", GUILayout.Width(60)))
        {
            if (float.TryParse(tweakStepString, out float parsed))
            {
                tweakStep = Mathf.Max(0f, parsed);
            }
            else
            {
                // If parse fails, reset the string back to the last valid:
                tweakStepString = tweakStep.ToString("F1");
            }
        }

        // “Reset” button to restore default 10.0:
        if (GUILayout.Button("Reset", GUILayout.Width(60)))
        {
            tweakStep = 10f;
            tweakStepString = "10.0";
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(8);

        // ──────────────────────────────────────────────────────────────────────────────────────────
        // 2) ScrollView: everything below here is inside a scrollable region
        //    We subtract a fixed number of pixels at the bottom (≈40) so that the “Close” button
        //    and the last sliders are not cut off.
        //
        //    windowSize.y is, by default, 800. We need to leave room for:
        //      • the “General Settings” label + Tweak‐step row (≈ 40 px total),
        //      • plus a few pixels of extra margin so the “Close” (X) button at the bottom
        //        is always visible. I subtracted 60 px in total.
        // ──────────────────────────────────────────────────────────────────────────────────────────
        float headerHeight = 40f;    // approximates: “— General Settings —” + tweak‐step row + spacings
        float footerHeight = 60f;    // approximates: “Close” button area + some margin
        float scrollViewHeight = windowSize.y - headerHeight - footerHeight;

        scrollPosition = GUILayout.BeginScrollView(
            scrollPosition,
            /* alwaysShowHorizontal: */ false,
            /* alwaysShowVertical:   */ true,
            GUILayout.Width(windowSize.x - 20),  // leave ~20px for the vertical bar
            GUILayout.Height(scrollViewHeight)
        );
        {
            GUILayout.BeginVertical();

            //
            // ─── 1) Physics: Gravity ───────────────────────────────────────────
            //
            GUILayout.Label("— Physics: Gravity —");
            DrawSlider(
                $"Gravity Y: {Physics.gravity.y:F1}",
                Physics.gravity.y,
                () => Physics.gravity += Vector3.up * gravityStep,
                () => Physics.gravity -= Vector3.up * gravityStep,
                () =>
                {
                    // Reset gravity if we captured it earlier
                    if (hasCapturedOriginalGravity)
                        Physics.gravity = originalGravity;
                }
            );
            GUILayout.Space(8);

            //
            // ─── 2) Hop & Sub‐Settings ──────────────────────────────────────────
            //
            GUILayout.Label("— Hop & Related Settings —");
            if (hop == null)
            {
                GUILayout.Label("Hop component not found");
            }
            else
            {
                // ----- HopTimerSettings -----
                GUILayout.Label("• HopTimerSettings •");
                if (hopTimerSettings != null)
                {
                    DrawSlider(
                        $"Hop Time: {hopTimerSettings.hopTime:F1}",
                        hopTimerSettings.hopTime,
                        () => hopTimerSettings.hopTime = Mathf.Max(0f, hopTimerSettings.hopTime - tweakStep * 0.1f),
                        () => hopTimerSettings.hopTime += tweakStep * 0.1f,
                        () =>
                        {
                            if (hasCapturedOriginalHopTimerSettings)
                                hopTimerSettings.hopTime = originalHopTime;
                        }
                    );
                }
                else
                {
                    GUILayout.Label("  (HopTimerSettings not found)");
                }
                GUILayout.Space(6);

                // ----- NormalHopSettings -----
                GUILayout.Label("• NormalHopSettings •");
                if (normalHopSettings != null)
                {
                    DrawSlider(
                        $"Normal Strength: {normalHopSettings.strength:F1}",
                        normalHopSettings.strength,
                        () => normalHopSettings.strength = Mathf.Max(0f, normalHopSettings.strength - tweakStep),
                        () => normalHopSettings.strength += tweakStep,
                        () =>
                        {
                            if (hasCapturedOriginalNormalHopSettings)
                                normalHopSettings.strength = originalNormalHopStrength;
                        }
                    );
                    GUILayout.Space(4);
                    DrawSlider(
                        $"Min Joystick: {normalHopSettings.minimumTimeForJoystick:F1}",
                        normalHopSettings.minimumTimeForJoystick,
                        () => normalHopSettings.minimumTimeForJoystick = Mathf.Max(0f, normalHopSettings.minimumTimeForJoystick - tweakStep * 0.1f),
                        () => normalHopSettings.minimumTimeForJoystick += tweakStep * 0.1f,
                        () =>
                        {
                            if (hasCapturedOriginalNormalHopSettings)
                                normalHopSettings.minimumTimeForJoystick = originalNormalMinJoystick;
                        }
                    );
                }
                else
                {
                    GUILayout.Label("  (NormalHopSettings not found)");
                }
                GUILayout.Space(6);

                // ----- LowHopSettings -----
                GUILayout.Label("• LowHopSettings •");
                if (lowHopSettings != null)
                {
                    DrawSlider(
                        $"Low Strength: {lowHopSettings.strength:F1}",
                        lowHopSettings.strength,
                        () => lowHopSettings.strength = Mathf.Max(0f, lowHopSettings.strength - tweakStep),
                        () => lowHopSettings.strength += tweakStep,
                        () =>
                        {
                            if (hasCapturedOriginalLowHopSettings)
                                lowHopSettings.strength = originalLowHopStrength;
                        }
                    );
                    GUILayout.Space(4);
                    DrawSlider(
                        $"Max Joystick: {lowHopSettings.maximumTimeForJoystick:F1}",
                        lowHopSettings.maximumTimeForJoystick,
                        () => lowHopSettings.maximumTimeForJoystick = Mathf.Max(0f, lowHopSettings.maximumTimeForJoystick - tweakStep * 0.1f),
                        () => lowHopSettings.maximumTimeForJoystick += tweakStep * 0.1f,
                        () =>
                        {
                            if (hasCapturedOriginalLowHopSettings)
                                lowHopSettings.maximumTimeForJoystick = originalLowMaxJoystick;
                        }
                    );
                }
                else
                {
                    GUILayout.Label("  (LowHopSettings not found)");
                }
                GUILayout.Space(6);

                // ----- NoseManualHopSettings -----
                GUILayout.Label("• NoseManualHopSettings •");
                if (noseManualHopSettings != null)
                {
                    DrawSlider(
                        $"NoseManual Strength: {noseManualHopSettings.strength:F1}",
                        noseManualHopSettings.strength,
                        () => noseManualHopSettings.strength = Mathf.Max(0f, noseManualHopSettings.strength - tweakStep),
                        () => noseManualHopSettings.strength += tweakStep,
                        () =>
                        {
                            if (hasCapturedOriginalNoseManualHopSettings)
                                noseManualHopSettings.strength = originalNoseManualStrength;
                        }
                    );
                }
                else
                {
                    GUILayout.Label("  (NoseManualHopSettings not found)");
                }
                GUILayout.Space(6);

                // ----- FootJamHopSettings -----
                GUILayout.Label("• FootJamHopSettings •");
                if (footJamHopSettings != null)
                {
                    DrawSlider(
                        $"FootJam Up Str: {footJamHopSettings.upwardStrength:F1}",
                        footJamHopSettings.upwardStrength,
                        () => footJamHopSettings.upwardStrength = Mathf.Max(0f, footJamHopSettings.upwardStrength - tweakStep),
                        () => footJamHopSettings.upwardStrength += tweakStep,
                        () =>
                        {
                            if (hasCapturedOriginalFootJamHopSettings)
                                footJamHopSettings.upwardStrength = originalFootJamUpStrength;
                        }
                    );
                    GUILayout.Space(4);
                    DrawSlider(
                        $"FootJam Fwd Str: {footJamHopSettings.forwardStrength:F1}",
                        footJamHopSettings.forwardStrength,
                        () => footJamHopSettings.forwardStrength = Mathf.Max(0f, footJamHopSettings.forwardStrength - tweakStep),
                        () => footJamHopSettings.forwardStrength += tweakStep,
                        () =>
                        {
                            if (hasCapturedOriginalFootJamHopSettings)
                                footJamHopSettings.forwardStrength = originalFootJamForwardStrength;
                        }
                    );
                }
                else
                {
                    GUILayout.Label("  (FootJamHopSettings not found)");
                }
            }
            GUILayout.Space(8);

            //
            // ─── 3) TimeSpeed ────────────────────────────────────────────────────
            //
            GUILayout.Label("— TimeSpeed —");
            if (timeSpeed == null)
            {
                GUILayout.Label("TimeSpeed not found");
            }
            else
            {
                DrawSlider(
                    $"Slomo Scale: {timeSpeed.slowMotion:F2}",
                    timeSpeed.slowMotion,
                    () => timeSpeed.slowMotion = Mathf.Max(0f, timeSpeed.slowMotion - tweakStep * 0.01f),
                    () => timeSpeed.slowMotion += tweakStep * 0.01f,
                    () =>
                    {
                        if (hasCapturedOriginalTimeSpeed)
                            timeSpeed.slowMotion = originalSlowMotion;
                    }
                );
                GUILayout.Space(4);

                GUILayout.BeginHorizontal();
                timeSpeed.allowPauseTime = GUILayout.Toggle(timeSpeed.allowPauseTime, "Allow PauseTime", GUILayout.ExpandWidth(false));
                if (GUILayout.Button("Reset", GUILayout.Width(60)))
                {
                    if (hasCapturedOriginalTimeSpeed)
                        timeSpeed.allowPauseTime = originalAllowPauseTime;
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.Space(8);

            //
            // ─── 4) Invector Animator & Motor ───────────────────────────────────
            //
            GUILayout.Label("— Invector Animator & Motor —");
            if (invectorAnimator == null || invectorController == null)
            {
                GUILayout.Label("Invector components not found");
            }
            else
            {
                DrawSlider(
                    $"Anim Speed: {invectorAnimator.speed:F1}",
                    invectorAnimator.speed,
                    () => invectorAnimator.speed = Mathf.Max(0.1f, invectorAnimator.speed - tweakStep),
                    () => invectorAnimator.speed += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalInvector)
                            invectorAnimator.speed = originalAnimSpeed;
                    }
                );
                GUILayout.Space(4);

                DrawSlider(
                    $"Walk Mult: {invectorController.speedMultiplier:F1}",
                    invectorController.speedMultiplier,
                    () => invectorController.speedMultiplier = Mathf.Max(0.1f, invectorController.speedMultiplier - tweakStep),
                    () => invectorController.speedMultiplier += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalInvector)
                            invectorController.speedMultiplier = originalSpeedMultiplier;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Air Speed: {invectorController.airSpeed:F1}",
                    invectorController.airSpeed,
                    () => invectorController.airSpeed = Mathf.Max(0f, invectorController.airSpeed - tweakStep),
                    () => invectorController.airSpeed += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalInvector)
                            invectorController.airSpeed = originalAirSpeed;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Roll Speed: {invectorController.rollSpeed:F1}",
                    invectorController.rollSpeed,
                    () => invectorController.rollSpeed = Mathf.Max(0f, invectorController.rollSpeed - tweakStep),
                    () => invectorController.rollSpeed += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalInvector)
                            invectorController.rollSpeed = originalRollSpeed;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Roll Rot Spd: {invectorController.rollRotationSpeed:F1}",
                    invectorController.rollRotationSpeed,
                    () => invectorController.rollRotationSpeed = Mathf.Max(0f, invectorController.rollRotationSpeed - tweakStep),
                    () => invectorController.rollRotationSpeed += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalInvector)
                            invectorController.rollRotationSpeed = originalRollRotationSpeed;
                    }
                );
            }
            GUILayout.Space(8);

            //
            // ─── 5) ScooterController & Its Sub‐Settings ────────────────────────
            //
            GUILayout.Label("— ScooterController Core —");
            if (scooter == null || scooterRotSettings == null)
            {
                GUILayout.Label("ScooterController not found");
            }
            else
            {
                // Hop Tilt
                DrawSlider(
                    $"Hop Tilt: {scooter.hopTilt:F1}",
                    scooter.hopTilt,
                    () => scooter.hopTilt = Mathf.Max(0f, scooter.hopTilt - tweakStep),
                    () => scooter.hopTilt += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalScooterCore)
                            scooter.hopTilt = originalHopTilt;
                    }
                );
            }
            GUILayout.Space(8);

            // ─── RotationSettings ───────────────────────────────────────────────
            GUILayout.Label("— Rotation Settings (Scooter) —");
            if (scooterRotSettings == null)
            {
                GUILayout.Label("RotationSettings not found");
            }
            else
            {
                DrawSlider(
                    $"Flip Speed: {scooterRotSettings.flipSpeed:F1}",
                    scooterRotSettings.flipSpeed,
                    () => scooterRotSettings.flipSpeed = Mathf.Max(0f, scooterRotSettings.flipSpeed - tweakStep),
                    () => scooterRotSettings.flipSpeed += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRotSettings)
                            scooterRotSettings.flipSpeed = originalFlipSpeed;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Spin Speed: {scooterRotSettings.spinSpeed:F1}",
                    scooterRotSettings.spinSpeed,
                    () => scooterRotSettings.spinSpeed = Mathf.Max(0f, scooterRotSettings.spinSpeed - tweakStep),
                    () => scooterRotSettings.spinSpeed += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRotSettings)
                            scooterRotSettings.spinSpeed = originalSpinSpeed;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Fast Spin: {scooterRotSettings.fastSpin:F1}",
                    scooterRotSettings.fastSpin,
                    () => scooterRotSettings.fastSpin = Mathf.Max(0f, scooterRotSettings.fastSpin - tweakStep),
                    () => scooterRotSettings.fastSpin += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRotSettings)
                            scooterRotSettings.fastSpin = originalFastSpin;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Spin Dampen: {scooterRotSettings.spinDampen:F1}",
                    scooterRotSettings.spinDampen,
                    () => scooterRotSettings.spinDampen = Mathf.Max(0f, scooterRotSettings.spinDampen - tweakStep),
                    () => scooterRotSettings.spinDampen += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRotSettings)
                            scooterRotSettings.spinDampen = originalSpinDampen;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Norm→Fast Damp: {scooterRotSettings.normalToFastDampen:F1}",
                    scooterRotSettings.normalToFastDampen,
                    () => scooterRotSettings.normalToFastDampen = Mathf.Max(0f, scooterRotSettings.normalToFastDampen - tweakStep),
                    () => scooterRotSettings.normalToFastDampen += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRotSettings)
                            scooterRotSettings.normalToFastDampen = originalNormToFastDampen;
                    }
                );
                GUILayout.Space(4);

                GUILayout.BeginHorizontal();
                scooterRotSettings.disableLandCorrectionOnFlip = GUILayout.Toggle(
                    scooterRotSettings.disableLandCorrectionOnFlip,
                    "Disable LandCorrection On Flip",
                    GUILayout.ExpandWidth(false)
                );
                if (GUILayout.Button("Reset", GUILayout.Width(60)))
                {
                    if (hasCapturedOriginalRotSettings)
                        scooterRotSettings.disableLandCorrectionOnFlip = originalDisableLandCorrectionOnFlip;
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.Space(8);

            // ─── ScooterWheelSettings ───────────────────────────────────────────
            GUILayout.Label("— ScooterWheel Settings —");
            if (scooter == null || wheelSettings == null)
            {
                GUILayout.Label("ScooterWheelSettings not found");
            }
            else
            {
                DrawSlider(
                    $"Max Steering Angle: {wheelSettings.maxSteeringAngle:F1}",
                    wheelSettings.maxSteeringAngle,
                    () => wheelSettings.maxSteeringAngle = Mathf.Max(0f, wheelSettings.maxSteeringAngle - tweakStep),
                    () => wheelSettings.maxSteeringAngle += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalWheelSettings)
                            wheelSettings.maxSteeringAngle = originalMaxSteeringAngle;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Fakie Steer Angle: {wheelSettings.fakieSteerAngle:F1}",
                    wheelSettings.fakieSteerAngle,
                    () => wheelSettings.fakieSteerAngle = Mathf.Max(0f, wheelSettings.fakieSteerAngle - tweakStep),
                    () => wheelSettings.fakieSteerAngle += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalWheelSettings)
                            wheelSettings.fakieSteerAngle = originalFakieSteerAngle;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Steer Dampen: {wheelSettings.steerDampen:F1}",
                    wheelSettings.steerDampen,
                    () => wheelSettings.steerDampen = Mathf.Max(0f, wheelSettings.steerDampen - tweakStep),
                    () => wheelSettings.steerDampen += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalWheelSettings)
                            wheelSettings.steerDampen = originalSteerDampen;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Max Motor Torque: {wheelSettings.maxMotorTorque:F1}",
                    wheelSettings.maxMotorTorque,
                    () => wheelSettings.maxMotorTorque = Mathf.Max(0f, wheelSettings.maxMotorTorque - tweakStep),
                    () => wheelSettings.maxMotorTorque += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalWheelSettings)
                            wheelSettings.maxMotorTorque = originalMaxMotorTorque;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Stop Drag: {wheelSettings.stopDrag:F1}",
                    wheelSettings.stopDrag,
                    () => wheelSettings.stopDrag = Mathf.Max(0f, wheelSettings.stopDrag - tweakStep),
                    () => wheelSettings.stopDrag += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalWheelSettings)
                            wheelSettings.stopDrag = originalStopDrag;
                    }
                );
            }
            GUILayout.Space(8);

            // ─── PushSettings ────────────────────────────────────────────────────
            GUILayout.Label("— Push Settings —");
            if (scooter == null || pushSettings == null)
            {
                GUILayout.Label("PushSettings not found");
            }
            else
            {
                DrawSlider(
                    $"Push Delay: {pushSettings.delay:F1}",
                    pushSettings.delay,
                    () => pushSettings.delay = Mathf.Max(0f, pushSettings.delay - tweakStep),
                    () => pushSettings.delay += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalPushSettings)
                            pushSettings.delay = originalPushDelay;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Push Duration: {pushSettings.duration:F1}",
                    pushSettings.duration,
                    () => pushSettings.duration = Mathf.Max(0f, pushSettings.duration - tweakStep),
                    () => pushSettings.duration += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalPushSettings)
                            pushSettings.duration = originalPushDuration;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Initial Push Force: {pushSettings.initialPushForce:F1}",
                    pushSettings.initialPushForce,
                    () => pushSettings.initialPushForce = Mathf.Max(0f, pushSettings.initialPushForce - tweakStep),
                    () => pushSettings.initialPushForce += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalPushSettings)
                            pushSettings.initialPushForce = originalInitialPushForce;
                    }
                );
            }
            GUILayout.Space(8);

            // ─── FakieSettings ───────────────────────────────────────────────────
            GUILayout.Label("— Fakie Settings —");
            if (scooter == null || fakieSettings == null)
            {
                GUILayout.Label("FakieSettings not found");
            }
            else
            {
                DrawSlider(
                    $"Fakie Threshold: {fakieSettings.fakieThreshold:F1}",
                    fakieSettings.fakieThreshold,
                    () => fakieSettings.fakieThreshold = Mathf.Max(0f, fakieSettings.fakieThreshold - tweakStep),
                    () => fakieSettings.fakieThreshold += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalFakieSettings)
                            fakieSettings.fakieThreshold = originalFakieThreshold;
                    }
                );
            }
            GUILayout.Space(8);

            // ─── GroundInformation ───────────────────────────────────────────────
            GUILayout.Label("— Ground Information —");
            if (scooter == null || groundInformation == null)
            {
                GUILayout.Label("GroundInformation not found");
            }
            else
            {
                DrawSlider(
                    $"X Divider: {groundInformation.xDivider:F1}",
                    groundInformation.xDivider,
                    () => groundInformation.xDivider = Mathf.Max(0.1f, groundInformation.xDivider - tweakStep),
                    () => groundInformation.xDivider += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalGroundInformation)
                            groundInformation.xDivider = originalXDivider;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Z Divider: {groundInformation.zDivider:F1}",
                    groundInformation.zDivider,
                    () => groundInformation.zDivider = Mathf.Max(0.1f, groundInformation.zDivider - tweakStep),
                    () => groundInformation.zDivider += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalGroundInformation)
                            groundInformation.zDivider = originalZDivider;
                    }
                );
                GUILayout.Space(2);

                GUILayout.BeginHorizontal();
                groundInformation.debug = GUILayout.Toggle(groundInformation.debug, "Debug Raycast", GUILayout.ExpandWidth(false));
                if (GUILayout.Button("Reset", GUILayout.Width(60)))
                {
                    if (hasCapturedOriginalGroundInformation)
                        groundInformation.debug = originalGroundDebug;
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(2);

                GUILayout.Label($"Raycast Offset: ({groundInformation.raycastOffset.x:F1}, {groundInformation.raycastOffset.y:F1}, {groundInformation.raycastOffset.z:F1})");
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("RX -", GUILayout.Width(50))) groundInformation.raycastOffset.x -= tweakStep;
                if (GUILayout.Button("RX +", GUILayout.Width(50))) groundInformation.raycastOffset.x += tweakStep;
                if (GUILayout.Button("RY -", GUILayout.Width(50))) groundInformation.raycastOffset.y -= tweakStep;
                if (GUILayout.Button("RY +", GUILayout.Width(50))) groundInformation.raycastOffset.y += tweakStep;
                if (GUILayout.Button("RZ -", GUILayout.Width(50))) groundInformation.raycastOffset.z -= tweakStep;
                if (GUILayout.Button("RZ +", GUILayout.Width(50))) groundInformation.raycastOffset.z += tweakStep;
                if (GUILayout.Button("Reset", GUILayout.Width(60)))
                {
                    if (hasCapturedOriginalGroundInformation)
                        groundInformation.raycastOffset = originalRaycastOffset;
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(2);

                GUILayout.Label($"LayerMask: {groundInformation.layerMask.value}");
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("LM -", GUILayout.Width(40))) groundInformation.layerMask = ~(~groundInformation.layerMask << 1) >> 1;
                if (GUILayout.Button("LM +", GUILayout.Width(40))) groundInformation.layerMask = (groundInformation.layerMask << 1) | 1;
                if (GUILayout.Button("Reset", GUILayout.Width(60)))
                {
                    if (hasCapturedOriginalGroundInformation)
                        groundInformation.layerMask = originalGroundLayerMask;
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.Space(8);

            // ─── FootJamSettings ─────────────────────────────────────────────────
            GUILayout.Label("— Foot Jam Settings —");
            if (scooter == null || scooterFootJamSettings == null)
            {
                GUILayout.Label("FootJamSettings not found");
            }
            else
            {
                DrawSlider(
                    $"Max Jam Angle: {scooterFootJamSettings.MaxJamAngle:F1}",
                    scooterFootJamSettings.MaxJamAngle,
                    () => scooterFootJamSettings.MaxJamAngle = Mathf.Max(0f, scooterFootJamSettings.MaxJamAngle - tweakStep),
                    () => scooterFootJamSettings.MaxJamAngle += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalScooterFootJamSettings)
                            scooterFootJamSettings.MaxJamAngle = originalMaxJamAngle;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Max Jam Fall: {scooterFootJamSettings.MaxJamFall:F1}",
                    scooterFootJamSettings.MaxJamFall,
                    () => scooterFootJamSettings.MaxJamFall = Mathf.Max(0f, scooterFootJamSettings.MaxJamFall - tweakStep),
                    () => scooterFootJamSettings.MaxJamFall += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalScooterFootJamSettings)
                            scooterFootJamSettings.MaxJamFall = originalMaxJamFall;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Wheel Dampen: {scooterFootJamSettings.WheelDamp:F1}",
                    scooterFootJamSettings.WheelDamp,
                    () => scooterFootJamSettings.WheelDamp = Mathf.Max(0f, scooterFootJamSettings.WheelDamp - tweakStep),
                    () => scooterFootJamSettings.WheelDamp += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalScooterFootJamSettings)
                            scooterFootJamSettings.WheelDamp = originalWheelDamp;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Default Wheel Damp: {scooterFootJamSettings.DefaultWheelDamp:F1}",
                    scooterFootJamSettings.DefaultWheelDamp,
                    () => scooterFootJamSettings.DefaultWheelDamp = Mathf.Max(0f, scooterFootJamSettings.DefaultWheelDamp - tweakStep),
                    () => scooterFootJamSettings.DefaultWheelDamp += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalScooterFootJamSettings)
                            scooterFootJamSettings.DefaultWheelDamp = originalDefaultWheelDamp;
                    }
                );
            }
            GUILayout.Space(8);

            // ─── VelocityMagnitudeSettings ───────────────────────────────────────
            GUILayout.Label("— Velocity Magnitude Settings —");
            if (scooter == null || velocityMagnitudeSettings == null)
            {
                GUILayout.Label("VelocityMagnitudeSettings not found");
            }
            else
            {
                DrawSlider(
                    $"Velocity Delay: {velocityMagnitudeSettings.VelocityMagnitudeDelay:F1}",
                    velocityMagnitudeSettings.VelocityMagnitudeDelay,
                    () => velocityMagnitudeSettings.VelocityMagnitudeDelay = Mathf.Max(0f, velocityMagnitudeSettings.VelocityMagnitudeDelay - tweakStep),
                    () => velocityMagnitudeSettings.VelocityMagnitudeDelay += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalVelocityMagnitudeSettings)
                            velocityMagnitudeSettings.VelocityMagnitudeDelay = originalVelocityMagnitudeDelay;
                    }
                );
            }
            GUILayout.Space(8);

            // ─── CrashLandSettings ───────────────────────────────────────────────
            GUILayout.Label("— Crash Land Settings —");
            if (scooter == null || crashLandSettings == null)
            {
                GUILayout.Label("CrashLandSettings not found");
            }
            else
            {
                DrawSlider(
                    $"Front In Align Angle: {crashLandSettings.FrontInsideAlignedAngle:F1}",
                    crashLandSettings.FrontInsideAlignedAngle,
                    () => crashLandSettings.FrontInsideAlignedAngle = Mathf.Max(0f, crashLandSettings.FrontInsideAlignedAngle - tweakStep),
                    () => crashLandSettings.FrontInsideAlignedAngle += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalCrashLandSettings)
                            crashLandSettings.FrontInsideAlignedAngle = originalFrontInsideAlignedAngle;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Front Out Align Angle: {crashLandSettings.FrontOutsideAlignedAngle:F1}",
                    crashLandSettings.FrontOutsideAlignedAngle,
                    () => crashLandSettings.FrontOutsideAlignedAngle = Mathf.Max(0f, crashLandSettings.FrontOutsideAlignedAngle - tweakStep),
                    () => crashLandSettings.FrontOutsideAlignedAngle += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalCrashLandSettings)
                            crashLandSettings.FrontOutsideAlignedAngle = originalFrontOutsideAlignedAngle;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Back In Align Angle: {crashLandSettings.BackInsideAlignedAngle:F1}",
                    crashLandSettings.BackInsideAlignedAngle,
                    () => crashLandSettings.BackInsideAlignedAngle = Mathf.Max(0f, crashLandSettings.BackInsideAlignedAngle - tweakStep),
                    () => crashLandSettings.BackInsideAlignedAngle += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalCrashLandSettings)
                            crashLandSettings.BackInsideAlignedAngle = originalBackInsideAlignedAngle;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Back Out Align Angle: {crashLandSettings.BackOutsideAlignedAngle:F1}",
                    crashLandSettings.BackOutsideAlignedAngle,
                    () => crashLandSettings.BackOutsideAlignedAngle = Mathf.Max(0f, crashLandSettings.BackOutsideAlignedAngle - tweakStep),
                    () => crashLandSettings.BackOutsideAlignedAngle += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalCrashLandSettings)
                            crashLandSettings.BackOutsideAlignedAngle = originalBackOutsideAlignedAngle;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Align Landing Vel Thresh: {crashLandSettings.AlignedLandingVelThreshold:F1}",
                    crashLandSettings.AlignedLandingVelThreshold,
                    () => crashLandSettings.AlignedLandingVelThreshold = Mathf.Max(0f, crashLandSettings.AlignedLandingVelThreshold - tweakStep),
                    () => crashLandSettings.AlignedLandingVelThreshold += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalCrashLandSettings)
                            crashLandSettings.AlignedLandingVelThreshold = originalAlignedLandingVelThreshold;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Fall Flat Angle: {crashLandSettings.FallFlatAngle:F1}",
                    crashLandSettings.FallFlatAngle,
                    () => crashLandSettings.FallFlatAngle = Mathf.Max(0f, crashLandSettings.FallFlatAngle - tweakStep),
                    () => crashLandSettings.FallFlatAngle += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalCrashLandSettings)
                            crashLandSettings.FallFlatAngle = originalFallFlatAngle;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Fall Flat Vel Thresh: {crashLandSettings.FallFlatVelThreshold:F1}",
                    crashLandSettings.FallFlatVelThreshold,
                    () => crashLandSettings.FallFlatVelThreshold = Mathf.Max(0f, crashLandSettings.FallFlatVelThreshold - tweakStep),
                    () => crashLandSettings.FallFlatVelThreshold += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalCrashLandSettings)
                            crashLandSettings.FallFlatVelThreshold = originalFallFlatVelThreshold;
                    }
                );
            }
            GUILayout.Space(8);

            // ─── RevertSettings ─────────────────────────────────────────────────
            GUILayout.Label("— Revert Settings —");
            if (scooter == null || revertSettings == null)
            {
                GUILayout.Label("RevertSettings not found");
            }
            else
            {
                DrawSlider(
                    $"Crash Angle: {revertSettings.CrashAngle:F1}",
                    revertSettings.CrashAngle,
                    () => revertSettings.CrashAngle = Mathf.Max(0f, revertSettings.CrashAngle - tweakStep),
                    () => revertSettings.CrashAngle += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRevertSettings)
                            revertSettings.CrashAngle = originalCrashAngle;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Crash Time: {revertSettings.CrashTime:F1}",
                    revertSettings.CrashTime,
                    () => revertSettings.CrashTime = Mathf.Max(0f, revertSettings.CrashTime - tweakStep),
                    () => revertSettings.CrashTime += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRevertSettings)
                            revertSettings.CrashTime = originalCrashTime;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Torque Start: {revertSettings.torqueStart:F1}",
                    revertSettings.torqueStart,
                    () => revertSettings.torqueStart = Mathf.Max(0f, revertSettings.torqueStart - tweakStep),
                    () => revertSettings.torqueStart += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRevertSettings)
                            revertSettings.torqueStart = originalTorqueStart;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Torque End: {revertSettings.torqueEnd:F1}",
                    revertSettings.torqueEnd,
                    () => revertSettings.torqueEnd = Mathf.Max(0f, revertSettings.torqueEnd - tweakStep),
                    () => revertSettings.torqueEnd += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRevertSettings)
                            revertSettings.torqueEnd = originalTorqueEnd;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Revert Torque: {revertSettings.RevertTorque:F1}",
                    revertSettings.RevertTorque,
                    () => revertSettings.RevertTorque = Mathf.Max(0f, revertSettings.RevertTorque - tweakStep),
                    () => revertSettings.RevertTorque += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRevertSettings)
                            revertSettings.RevertTorque = originalRevertTorque;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Revert Y: {revertSettings.RevertY:F1}",
                    revertSettings.RevertY,
                    () => revertSettings.RevertY = Mathf.Max(0f, revertSettings.RevertY - tweakStep),
                    () => revertSettings.RevertY += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRevertSettings)
                            revertSettings.RevertY = originalRevertY;
                    }
                );
                GUILayout.Space(2);
                DrawSlider(
                    $"Revert Z: {revertSettings.RevertZ:F1}",
                    revertSettings.RevertZ,
                    () => revertSettings.RevertZ = Mathf.Max(0f, revertSettings.RevertZ - tweakStep),
                    () => revertSettings.RevertZ += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalRevertSettings)
                            revertSettings.RevertZ = originalRevertZ;
                    }
                );
            }
            GUILayout.Space(8);

            // ─── CentreOfMassSettings ────────────────────────────────────────────
            GUILayout.Label("— Centre Of Mass Settings —");
            if (scooter == null || centreOfMassSettings == null)
            {
                GUILayout.Label("CentreOfMassSettings not found");
            }
            else
            {
                GUILayout.Label($"CentreOfMass: ({centreOfMassSettings.CentreOfMass.x:F1}, {centreOfMassSettings.CentreOfMass.y:F1}, {centreOfMassSettings.CentreOfMass.z:F1})");
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("CM X -", GUILayout.Width(65))) centreOfMassSettings.CentreOfMass.x -= tweakStep;
                if (GUILayout.Button("CM X +", GUILayout.Width(65))) centreOfMassSettings.CentreOfMass.x += tweakStep;
                if (GUILayout.Button("CM Y -", GUILayout.Width(65))) centreOfMassSettings.CentreOfMass.y -= tweakStep;
                if (GUILayout.Button("CM Y +", GUILayout.Width(65))) centreOfMassSettings.CentreOfMass.y += tweakStep;
                if (GUILayout.Button("CM Z -", GUILayout.Width(65))) centreOfMassSettings.CentreOfMass.z -= tweakStep;
                if (GUILayout.Button("CM Z +", GUILayout.Width(65))) centreOfMassSettings.CentreOfMass.z += tweakStep;
                if (GUILayout.Button("Reset", GUILayout.Width(60)))
                {
                    if (hasCapturedOriginalCentreOfMassSettings)
                        centreOfMassSettings.CentreOfMass = originalCentreOfMass;
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(4);

                GUILayout.Label($"In Air COM: ({centreOfMassSettings.InAir.x:F1}, {centreOfMassSettings.InAir.y:F1}, {centreOfMassSettings.InAir.z:F1})");
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("IA X -", GUILayout.Width(60))) centreOfMassSettings.InAir.x -= tweakStep;
                if (GUILayout.Button("IA X +", GUILayout.Width(60))) centreOfMassSettings.InAir.x += tweakStep;
                if (GUILayout.Button("IA Y -", GUILayout.Width(60))) centreOfMassSettings.InAir.y -= tweakStep;
                if (GUILayout.Button("IA Y +", GUILayout.Width(60))) centreOfMassSettings.InAir.y += tweakStep;
                if (GUILayout.Button("IA Z -", GUILayout.Width(60))) centreOfMassSettings.InAir.z -= tweakStep;
                if (GUILayout.Button("IA Z +", GUILayout.Width(60))) centreOfMassSettings.InAir.z += tweakStep;
                if (GUILayout.Button("Reset", GUILayout.Width(60)))
                {
                    if (hasCapturedOriginalCentreOfMassSettings)
                        centreOfMassSettings.InAir = originalInAirCOM;
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(4);

                GUILayout.Label($"Normal COM: ({centreOfMassSettings.Normal.x:F1}, {centreOfMassSettings.Normal.y:F1}, {centreOfMassSettings.Normal.z:F1})");
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("N X -", GUILayout.Width(60))) centreOfMassSettings.Normal.x -= tweakStep;
                if (GUILayout.Button("N X +", GUILayout.Width(60))) centreOfMassSettings.Normal.x += tweakStep;
                if (GUILayout.Button("N Y -", GUILayout.Width(60))) centreOfMassSettings.Normal.y -= tweakStep;
                if (GUILayout.Button("N Y +", GUILayout.Width(60))) centreOfMassSettings.Normal.y += tweakStep;
                if (GUILayout.Button("N Z -", GUILayout.Width(60))) centreOfMassSettings.Normal.z -= tweakStep;
                if (GUILayout.Button("N Z +", GUILayout.Width(60))) centreOfMassSettings.Normal.z += tweakStep;
                if (GUILayout.Button("Reset", GUILayout.Width(60)))
                {
                    if (hasCapturedOriginalCentreOfMassSettings)
                        centreOfMassSettings.Normal = originalNormalCOM;
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.Space(8);

            //
            // ─── 6) PumpMechanic ────────────────────────────────────────────────
            //
            GUILayout.Label("— Pump Mechanic Settings —");
            if (pumpMechanic == null)
            {
                GUILayout.Label("PumpMechanic not found");
            }
            else
            {
                GUILayout.BeginHorizontal();
                pumpMechanic.debug = GUILayout.Toggle(pumpMechanic.debug, "Pump Debug", GUILayout.ExpandWidth(false));
                if (GUILayout.Button("Reset", GUILayout.Width(60)))
                {
                    if (hasCapturedOriginalPumpMechanic)
                        pumpMechanic.debug = originalPumpDebug;
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(4);

                GUILayout.BeginHorizontal();
                pumpMechanic.autoPump = GUILayout.Toggle(pumpMechanic.autoPump, "Auto Pump", GUILayout.ExpandWidth(false));
                if (GUILayout.Button("Reset", GUILayout.Width(60)))
                {
                    if (hasCapturedOriginalPumpMechanic)
                        pumpMechanic.autoPump = originalAutoPump;
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(4);

                DrawSlider(
                    $"Pump Time: {pumpMechanic.pumpTime:F1}",
                    pumpMechanic.pumpTime,
                    () => pumpMechanic.pumpTime = Mathf.Max(0f, pumpMechanic.pumpTime - tweakStep * 0.1f),
                    () => pumpMechanic.pumpTime += tweakStep * 0.1f,
                    () =>
                    {
                        if (hasCapturedOriginalPumpMechanic)
                            pumpMechanic.pumpTime = originalPumpTime;
                    }
                );
                GUILayout.Space(2);

                DrawSlider(
                    $"Pump Force: {pumpMechanic.pumpForce:F1}",
                    pumpMechanic.pumpForce,
                    () => pumpMechanic.pumpForce = Mathf.Max(0f, pumpMechanic.pumpForce - tweakStep),
                    () => pumpMechanic.pumpForce += tweakStep,
                    () =>
                    {
                        if (hasCapturedOriginalPumpMechanic)
                            pumpMechanic.pumpForce = originalPumpForce;
                    }
                );
            }
            GUILayout.Space(8);

            GUILayout.EndVertical();
        }
        GUILayout.EndScrollView();

        // ──────────────────────────────────────────────────────────────────────────
        // 3) Footer area: Close button
        // ──────────────────────────────────────────────────────────────────────────
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Close", GUILayout.Width(60)))
            isMenuOpen = false;
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        // Make the window draggable (title bar area = 20 px high)
        GUI.DragWindow(new Rect(0, 0, windowSize.x, 20));
    }

    private void DrawSlider(string label, float current,
                            Action onLeft, Action onRight, Action onReset)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label, GUILayout.Width(180));
        if (GUILayout.Button("<", GUILayout.Width(25))) onLeft?.Invoke();
        if (GUILayout.Button(">", GUILayout.Width(25))) onRight?.Invoke();
        if (GUILayout.Button("Reset", GUILayout.Width(60))) onReset?.Invoke();
        GUILayout.EndHorizontal();
    }

    private void TryFindAllComponents()
    {
        // ─── Hop & All Its Serializable Sub‐fields ─────────────────────────────
        var foundHop = FindObjectOfType<Hop>();
        if (foundHop != null)
        {
            hop = foundHop;

            // HopTimerSettings
            if (foundHop.hopTimerSettings != null)
            {
                if (!hasCapturedOriginalHopTimerSettings)
                {
                    originalHopTime = foundHop.hopTimerSettings.hopTime;
                    hasCapturedOriginalHopTimerSettings = true;
                }
                hopTimerSettings = foundHop.hopTimerSettings;
            }

            // NormalHopSettings
            if (foundHop.normalHopSettings != null)
            {
                if (!hasCapturedOriginalNormalHopSettings)
                {
                    originalNormalHopStrength = foundHop.normalHopSettings.strength;
                    originalNormalMinJoystick = foundHop.normalHopSettings.minimumTimeForJoystick;
                    hasCapturedOriginalNormalHopSettings = true;
                }
                normalHopSettings = foundHop.normalHopSettings;
            }

            // LowHopSettings
            if (foundHop.lowHopSettings != null)
            {
                if (!hasCapturedOriginalLowHopSettings)
                {
                    originalLowHopStrength = foundHop.lowHopSettings.strength;
                    originalLowMaxJoystick = foundHop.lowHopSettings.maximumTimeForJoystick;
                    hasCapturedOriginalLowHopSettings = true;
                }
                lowHopSettings = foundHop.lowHopSettings;
            }

            // NoseManualHopSettings
            if (foundHop.noseManualHopSettings != null)
            {
                if (!hasCapturedOriginalNoseManualHopSettings)
                {
                    originalNoseManualStrength = foundHop.noseManualHopSettings.strength;
                    hasCapturedOriginalNoseManualHopSettings = true;
                }
                noseManualHopSettings = foundHop.noseManualHopSettings;
            }

            // FootJamHopSettings
            if (foundHop.footJamHopSettings != null)
            {
                if (!hasCapturedOriginalFootJamHopSettings)
                {
                    originalFootJamUpStrength = foundHop.footJamHopSettings.upwardStrength;
                    originalFootJamForwardStrength = foundHop.footJamHopSettings.forwardStrength;
                    hasCapturedOriginalFootJamHopSettings = true;
                }
                footJamHopSettings = foundHop.footJamHopSettings;
            }
        }

        // ─── TimeSpeed ────────────────────────────────────────────────────────
        var foundTimeSpeed = FindObjectOfType<TimeSpeed>();
        if (foundTimeSpeed != null)
        {
            if (!hasCapturedOriginalTimeSpeed)
            {
                originalSlowMotion = foundTimeSpeed.slowMotion;
                originalAllowPauseTime = foundTimeSpeed.allowPauseTime;
                hasCapturedOriginalTimeSpeed = true;
            }
            timeSpeed = foundTimeSpeed;
        }

        // ─── ScooterController & Sub‐settings ─────────────────────────────────
        var foundScooter = FindObjectOfType<ScooterController>();
        if (foundScooter != null)
        {
            if (!hasCapturedOriginalScooterCore)
            {
                originalHopTilt = foundScooter.hopTilt;
                hasCapturedOriginalScooterCore = true;
            }
            scooter = foundScooter;

            // Invector (player) / Animator / vThirdPersonMotor
            var invRoot = GameObject.Find("PlayerComponents") ?? GameObject.Find("PlayerComponents(Clone)");
            if (invRoot != null)
            {
                var foundInvController = invRoot.GetComponentInChildren<vThirdPersonMotor>();
                var foundInvAnimator = invRoot.GetComponentInChildren<Animator>();
                if (foundInvController != null && !hasCapturedOriginalInvector)
                {
                    originalSpeedMultiplier = foundInvController.speedMultiplier;
                    originalAirSpeed = foundInvController.airSpeed;
                    originalRollSpeed = foundInvController.rollSpeed;
                    originalRollRotationSpeed = foundInvController.rollRotationSpeed;
                }
                if (foundInvAnimator != null && !hasCapturedOriginalInvector)
                {
                    originalAnimSpeed = foundInvAnimator.speed;
                    hasCapturedOriginalInvector = true;
                }

                invectorController = foundInvController;
                invectorAnimator = foundInvAnimator;
            }

            // RotationSettings (plain class)
            if (foundScooter.rotationSettings != null)
            {
                if (!hasCapturedOriginalRotSettings)
                {
                    var rs = foundScooter.rotationSettings;
                    originalFlipSpeed = rs.flipSpeed;
                    originalSpinSpeed = rs.spinSpeed;
                    originalFastSpin = rs.fastSpin;
                    originalSpinDampen = rs.spinDampen;
                    originalNormToFastDampen = rs.normalToFastDampen;
                    originalDisableLandCorrectionOnFlip = rs.disableLandCorrectionOnFlip;
                    hasCapturedOriginalRotSettings = true;
                }
                scooterRotSettings = foundScooter.rotationSettings;
            }

            // ScooterWheelSettings (plain class)
            if (foundScooter.scooterWheelSettings != null)
            {
                if (!hasCapturedOriginalWheelSettings)
                {
                    var ws = foundScooter.scooterWheelSettings;
                    originalMaxSteeringAngle = ws.maxSteeringAngle;
                    originalFakieSteerAngle = ws.fakieSteerAngle;
                    originalSteerDampen = ws.steerDampen;
                    originalMaxMotorTorque = ws.maxMotorTorque;
                    originalStopDrag = ws.stopDrag;
                    hasCapturedOriginalWheelSettings = true;
                }
                wheelSettings = foundScooter.scooterWheelSettings;
            }

            // PushSettings (plain class)
            if (foundScooter.pushSettings != null)
            {
                if (!hasCapturedOriginalPushSettings)
                {
                    var ps = foundScooter.pushSettings;
                    originalPushDelay = ps.delay;
                    originalPushDuration = ps.duration;
                    originalInitialPushForce = ps.initialPushForce;
                    hasCapturedOriginalPushSettings = true;
                }
                pushSettings = foundScooter.pushSettings;
            }

            // FakieSettings (plain class)
            if (foundScooter.fakieSettings != null)
            {
                if (!hasCapturedOriginalFakieSettings)
                {
                    originalFakieThreshold = foundScooter.fakieSettings.fakieThreshold;
                    hasCapturedOriginalFakieSettings = true;
                }
                fakieSettings = foundScooter.fakieSettings;
            }

            // GroundInformation (plain class)
            if (foundScooter.groundInformation != null)
            {
                if (!hasCapturedOriginalGroundInformation)
                {
                    var gi = foundScooter.groundInformation;
                    originalXDivider = gi.xDivider;
                    originalZDivider = gi.zDivider;
                    originalGroundDebug = gi.debug;
                    originalRaycastOffset = gi.raycastOffset;
                    originalGroundLayerMask = gi.layerMask;
                    hasCapturedOriginalGroundInformation = true;
                }
                groundInformation = foundScooter.groundInformation;
            }

            // FootJamSettings (plain class)
            if (foundScooter.footJamSettings != null)
            {
                if (!hasCapturedOriginalScooterFootJamSettings)
                {
                    var fj = foundScooter.footJamSettings;
                    originalMaxJamAngle = fj.MaxJamAngle;
                    originalMaxJamFall = fj.MaxJamFall;
                    originalWheelDamp = fj.WheelDamp;
                    originalDefaultWheelDamp = fj.DefaultWheelDamp;
                    hasCapturedOriginalScooterFootJamSettings = true;
                }
                scooterFootJamSettings = foundScooter.footJamSettings;
            }

            // VelocityMagnitudeSettings (plain class)
            if (foundScooter.velocityMagnitudeSettings != null)
            {
                if (!hasCapturedOriginalVelocityMagnitudeSettings)
                {
                    originalVelocityMagnitudeDelay = foundScooter.velocityMagnitudeSettings.VelocityMagnitudeDelay;
                    hasCapturedOriginalVelocityMagnitudeSettings = true;
                }
                velocityMagnitudeSettings = foundScooter.velocityMagnitudeSettings;
            }

            // CrashLandSettings (plain class)
            if (foundScooter.crashLandSettings != null)
            {
                if (!hasCapturedOriginalCrashLandSettings)
                {
                    var cl = foundScooter.crashLandSettings;
                    originalFrontInsideAlignedAngle = cl.FrontInsideAlignedAngle;
                    originalFrontOutsideAlignedAngle = cl.FrontOutsideAlignedAngle;
                    originalBackInsideAlignedAngle = cl.BackInsideAlignedAngle;
                    originalBackOutsideAlignedAngle = cl.BackOutsideAlignedAngle;
                    originalAlignedLandingVelThreshold = cl.AlignedLandingVelThreshold;
                    originalFallFlatAngle = cl.FallFlatAngle;
                    originalFallFlatVelThreshold = cl.FallFlatVelThreshold;
                    hasCapturedOriginalCrashLandSettings = true;
                }
                crashLandSettings = foundScooter.crashLandSettings;
            }

            // RevertSettings (plain class)
            if (foundScooter.revertSettings != null)
            {
                if (!hasCapturedOriginalRevertSettings)
                {
                    var rs = foundScooter.revertSettings;
                    originalCrashAngle = rs.CrashAngle;
                    originalCrashTime = rs.CrashTime;
                    originalTorqueStart = rs.torqueStart;
                    originalTorqueEnd = rs.torqueEnd;
                    originalRevertTorque = rs.RevertTorque;
                    originalRevertY = rs.RevertY;
                    originalRevertZ = rs.RevertZ;
                    hasCapturedOriginalRevertSettings = true;
                }
                revertSettings = foundScooter.revertSettings;
            }

            // CentreOfMassSettings (plain class)
            if (foundScooter.centreOfMassSettings != null)
            {
                if (!hasCapturedOriginalCentreOfMassSettings)
                {
                    var com = foundScooter.centreOfMassSettings;
                    originalCentreOfMass = com.CentreOfMass;
                    originalInAirCOM = com.InAir;
                    originalNormalCOM = com.Normal;
                    hasCapturedOriginalCentreOfMassSettings = true;
                }
                centreOfMassSettings = foundScooter.centreOfMassSettings;
            }
        }

        // ─── PumpMechanic ─────────────────────────────────────────────────────
        var foundPump = FindObjectOfType<PumpMechanic>();
        if (foundPump != null)
        {
            if (!hasCapturedOriginalPumpMechanic)
            {
                originalPumpDebug = foundPump.debug;
                originalAutoPump = foundPump.autoPump;
                originalPumpTime = foundPump.pumpTime;
                originalPumpForce = foundPump.pumpForce;
                hasCapturedOriginalPumpMechanic = true;
            }
            pumpMechanic = foundPump;
        }

        // ─── Gravity ─────────────────────────────────────────────────────────
        if (!hasCapturedOriginalGravity)
        {
            originalGravity = Physics.gravity;
            hasCapturedOriginalGravity = true;
        }
    }
}
