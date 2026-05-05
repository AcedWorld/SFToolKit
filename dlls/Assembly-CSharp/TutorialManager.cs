using System;
using System.Collections;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000B8 RID: 184
public class TutorialManager : MonoBehaviour
{
	// Token: 0x0600031D RID: 797 RVA: 0x000181EC File Offset: 0x000163EC
	private void Start()
	{
		this.playerRigidbody = this.playerObject.GetComponent<Rigidbody>();
		this.challengeList = Object.FindObjectOfType<ChallengeList>();
		this.SetTutorialState(TutorialManager.TutorialState.Intro);
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.teleportPlayer.IsTutorial = true;
	}

	// Token: 0x0600031E RID: 798 RVA: 0x00018240 File Offset: 0x00016440
	public void DisableAllButtons()
	{
		this.Push.SetActive(false);
		this.Stop.SetActive(false);
		this.Left.SetActive(false);
		this.Right.SetActive(false);
		this.Up.SetActive(false);
		this.Down.SetActive(false);
		this.GODpad.SetActive(false);
		this.GOTailWhip.SetActive(false);
		this.GOHeelWhip.SetActive(false);
		this.GOInward.SetActive(false);
		this.GOBriflip.SetActive(false);
		this.GOBarspin.SetActive(false);
		this.GOMultiWhip.SetActive(false);
	}

	// Token: 0x0600031F RID: 799 RVA: 0x000182EC File Offset: 0x000164EC
	public void SetTutorialState(TutorialManager.TutorialState newState)
	{
		this.currentState = newState;
		switch (this.currentState)
		{
		case TutorialManager.TutorialState.Intro:
			this.UpdateTutorialHeader("Welcome to the tutorial");
			this.UpdateTutorialText("press Start to Circle");
			return;
		case TutorialManager.TutorialState.PushAlongGround:
			this.UpdateTutorialHeader("Pushing and gaining speed");
			this.UpdateTutorialText("hold CROSS to push and gain speed");
			return;
		case TutorialManager.TutorialState.Steering:
			this.UpdateTutorialHeader("Steering Practise");
			this.UpdateTutorialText("Use the L-STICK to steer, hold all the way left and right a few times");
			return;
		case TutorialManager.TutorialState.SteeringComplete:
			this.UpdateTutorialHeader("Reset Marker");
			this.UpdateTutorialText("Press DOWN on the D-Pad to RESET and start and continue");
			return;
		case TutorialManager.TutorialState.SteeringCones:
			this.UpdateTutorialHeader("Steering Around cones");
			this.UpdateTutorialText("Collect all the blue MARKERS");
			return;
		case TutorialManager.TutorialState.SteeringConesComplete:
			this.UpdateTutorialText("Press DOWN on the D-Pad to RESET and start and continue");
			return;
		case TutorialManager.TutorialState.Hop:
			this.UpdateTutorialHeader("Jumping / Hopping");
			this.UpdateTutorialText("hold down and then fling up on the R-STICK to HOP");
			return;
		case TutorialManager.TutorialState.HopChallange:
			this.UpdateTutorialHeader("Collect the wheel");
			this.UpdateTutorialText("HOP over the kicker and collect the wheel");
			return;
		case TutorialManager.TutorialState.Manual:
			this.UpdateTutorialHeader("Manuals");
			this.UpdateTutorialText("push the R-STICK DOWN halfway to start the MANUAL");
			return;
		case TutorialManager.TutorialState.NoseManual:
			this.UpdateTutorialHeader("Nose Manuals");
			this.UpdateTutorialText("push the R-STICK Up halfway to start the NOSEMANUAL");
			return;
		case TutorialManager.TutorialState.ManualChallenge:
			this.UpdateTutorialHeader("Manual Pads");
			this.UpdateTutorialText("Hop onto the pad and MANUAL the whole length, Don't let the front wheel touch the pad");
			return;
		case TutorialManager.TutorialState.FootJam:
			this.UpdateTutorialHeader("Footjam");
			this.UpdateTutorialText("push the R-STICK Right halfway to start the footjam");
			return;
		case TutorialManager.TutorialState.TailWhip:
			this.UpdateTutorialHeader("Tailwhip");
			this.UpdateTutorialText("HOP in the air and press R2+RIGHT on the R-STICK to Tailwhip");
			return;
		case TutorialManager.TutorialState.HeelWhip:
			this.UpdateTutorialHeader("Heelwhip");
			this.UpdateTutorialText("HOP in the air and press R2+LEFT on the R-STICK to HEELWHIP");
			return;
		case TutorialManager.TutorialState.Walking:
			this.UpdateTutorialHeader("Walking");
			this.UpdateTutorialText("Press Triangle to get off the scooter and collect the markers on foot");
			return;
		case TutorialManager.TutorialState.FlipsSpins:
			this.UpdateTutorialHeader("Flips and Spins");
			this.UpdateTutorialText("HOP the ramp and pull down on the L-Stick to backflip");
			return;
		case TutorialManager.TutorialState.TricksOverBank:
			this.UpdateTutorialHeader("Fly Out Briflip");
			this.UpdateTutorialText("HOP the ramp and press R2+DOWN on the R-STICK to briflip");
			this.GOBriflip.SetActive(true);
			return;
		case TutorialManager.TutorialState.PerfectTransfer:
			this.UpdateTutorialHeader("Assisted Transfer");
			this.UpdateTutorialText("Flick the L-STICK UP inside the blue box, then HOP inside the RED BOX");
			return;
		case TutorialManager.TutorialState.PerfectAiring:
			this.UpdateTutorialHeader("Assisted Airing");
			this.UpdateTutorialText("Flick the L-STICK DOWN inside the blue box, then HOP inside the RED BOX");
			return;
		case TutorialManager.TutorialState.PerfectHips:
			this.UpdateTutorialHeader("Assisted Hip Transfers");
			this.UpdateTutorialText("Flick the L-STICK Up inside the blue box, then HOP inside the RED BOX");
			return;
		case TutorialManager.TutorialState.Completed:
			this.UpdateTutorialHeader("Tutorial completed!");
			this.UpdateTutorialText("Well done, head back to the main menu and try out some parks!");
			break;
		case TutorialManager.TutorialState.WaitState:
			break;
		default:
			return;
		}
	}

	// Token: 0x06000320 RID: 800 RVA: 0x00018549 File Offset: 0x00016749
	public void UpdateTutorialText(string text)
	{
		if (this.tutorialText != null)
		{
			base.StopAllCoroutines();
			this.tutorialText.text = text;
			base.StartCoroutine(this.FadeInText());
		}
	}

	// Token: 0x06000321 RID: 801 RVA: 0x00018578 File Offset: 0x00016778
	public void UpdateTutorialHeader(string text)
	{
		if (this.tutorialHeader != null)
		{
			this.tutorialHeader.text = text;
		}
	}

	// Token: 0x06000322 RID: 802 RVA: 0x00018594 File Offset: 0x00016794
	private IEnumerator FadeInText()
	{
		CanvasGroup canvasGroup = this.tutorialText.GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = this.tutorialText.gameObject.AddComponent<CanvasGroup>();
		}
		canvasGroup.alpha = 0f;
		float elapsedTime = 0f;
		while (elapsedTime < this.fadeDuration)
		{
			elapsedTime += Time.deltaTime;
			canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / this.fadeDuration);
			yield return null;
		}
		canvasGroup.alpha = 1f;
		yield break;
	}

	// Token: 0x06000323 RID: 803 RVA: 0x000185A3 File Offset: 0x000167A3
	private void PlayDialogue(AudioClip clip)
	{
		if (this.audioSource != null && clip != null)
		{
			this.audioSource.clip = clip;
			this.audioSource.Play();
		}
	}

	// Token: 0x06000324 RID: 804 RVA: 0x000185D3 File Offset: 0x000167D3
	public void PlaySound(AudioClip clip)
	{
		if (this.audioSource != null && clip != null)
		{
			this.audioSource.PlayOneShot(clip);
		}
	}

	// Token: 0x06000325 RID: 805 RVA: 0x000185F8 File Offset: 0x000167F8
	public IEnumerator FadeOutText()
	{
		CanvasGroup canvasGroup = this.tutorialText.GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = this.tutorialText.gameObject.AddComponent<CanvasGroup>();
		}
		canvasGroup.alpha = 1f;
		float elapsedTime = 0f;
		while (elapsedTime < this.fadeDuration)
		{
			elapsedTime += Time.deltaTime;
			canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / this.fadeDuration);
			yield return null;
		}
		canvasGroup.alpha = 0f;
		yield break;
	}

	// Token: 0x06000326 RID: 806 RVA: 0x00018607 File Offset: 0x00016807
	public IEnumerator DelayBeforeNextState(TutorialManager.TutorialState nextState, float delay)
	{
		yield return new WaitForSeconds(delay);
		this.SetTutorialState(nextState);
		yield break;
	}

	// Token: 0x06000327 RID: 807 RVA: 0x00018624 File Offset: 0x00016824
	private void Update()
	{
		switch (this.currentState)
		{
		case TutorialManager.TutorialState.Intro:
			this.Stop.SetActive(true);
			if (this.player.GetButtonDown("Circle"))
			{
				this.PlaySound(this.correctSound);
				this.DisableAllButtons();
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.PushAlongGround, 1f));
				this.challengeList.CompleteChallenge(0);
				return;
			}
			break;
		case TutorialManager.TutorialState.PushAlongGround:
			this.Push.SetActive(true);
			if (this.player.GetButton("Cross"))
			{
				this.holdTime += Time.deltaTime;
				if (this.holdTime >= 0.5f)
				{
					this.PlaySound(this.correctSound);
					base.StartCoroutine(this.FadeOutText());
					this.SetTutorialState(TutorialManager.TutorialState.WaitState);
					this.DisableAllButtons();
					base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.Steering, 1f));
				}
			}
			if (this.player.GetButtonUp("Cross"))
			{
				this.holdTime = 0f;
				return;
			}
			break;
		case TutorialManager.TutorialState.Steering:
			this.Left.SetActive(true);
			this.Right.SetActive(true);
			if (this.player.GetAxis("LeftStickX") < -0.5f)
			{
				this.steerCountLeft++;
			}
			else if (this.player.GetAxis("LeftStickX") > 0.5f)
			{
				this.steerCountRight++;
			}
			if (this.steerCountLeft >= 150 && this.steerCountRight >= 150)
			{
				this.PlaySound(this.smallSuccessSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.SteeringComplete, 1f));
				return;
			}
			break;
		case TutorialManager.TutorialState.SteeringComplete:
			this.GODpad.SetActive(true);
			if (this.player.GetButtonDown("D-PadDown"))
			{
				this.PlaySound(this.correctSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.SteeringCones, 1f));
				return;
			}
			break;
		case TutorialManager.TutorialState.SteeringCones:
			this.Left.SetActive(true);
			this.Right.SetActive(true);
			this.Push.SetActive(true);
			this.ConesChallange.SetActive(true);
			if (GameObject.FindGameObjectsWithTag("markers").Length == 0)
			{
				this.ConesChallange.SetActive(false);
				this.PlaySound(this.smallSuccessSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.SteeringConesComplete, 1f));
				return;
			}
			break;
		case TutorialManager.TutorialState.SteeringConesComplete:
			this.GODpad.SetActive(true);
			if (this.player.GetButtonDown("D-PadDown"))
			{
				this.PlaySound(this.correctSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.Hop, 1f));
				this.challengeList.CompleteChallenge(1);
				return;
			}
			break;
		case TutorialManager.TutorialState.Hop:
			this.Down.SetActive(true);
			this.Up.SetActive(true);
			if (!this.scooterController.isGrounded)
			{
				this.PlaySound(this.smallSuccessSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.HopChallange, 1f));
				return;
			}
			break;
		case TutorialManager.TutorialState.HopChallange:
		{
			this.HopChallangeObject.SetActive(true);
			int num = GameObject.FindGameObjectsWithTag("markers").Length;
			if (num == 0 && this.HopCount == 0f)
			{
				this.HopCount = 1f;
				this.HopChallangeObject.SetActive(false);
			}
			if (num == 0 && this.scooterController.isGrounded)
			{
				this.PlaySound(this.correctSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				this.HopChallangeObject.SetActive(false);
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.Manual, 1f));
				this.challengeList.CompleteChallenge(2);
				return;
			}
			break;
		}
		case TutorialManager.TutorialState.Manual:
			this.Down.SetActive(true);
			if (this.scooterController.Manual && this.ManualCount == 0f)
			{
				this.ManualCount = 1f;
				this.UpdateTutorialText("Let go of the R stick to stop the Manual down");
				this.PlaySound(this.smallSuccessSound);
			}
			if (this.ManualCount == 1f && !this.scooterController.Manual)
			{
				this.PlaySound(this.correctSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.NoseManual, 1f));
				this.challengeList.CompleteChallenge(3);
				return;
			}
			break;
		case TutorialManager.TutorialState.NoseManual:
			this.Up.SetActive(true);
			if (this.scooterController.NoseManual && this.NoseCount == 0f)
			{
				this.NoseCount = 1f;
				this.UpdateTutorialText("Now let go of the R stick to stop the Nose Manual");
				this.PlaySound(this.smallSuccessSound);
			}
			if (this.NoseCount == 1f && !this.scooterController.NoseManual)
			{
				this.PlaySound(this.correctSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				this.ManualChallangeObject.SetActive(true);
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.ManualChallenge, 1f));
				this.challengeList.CompleteChallenge(4);
				return;
			}
			break;
		case TutorialManager.TutorialState.ManualChallenge:
			if (!this.ManualChallangeObject.activeSelf)
			{
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.FootJam, 1f));
				return;
			}
			break;
		case TutorialManager.TutorialState.FootJam:
			if (this.scooterController.FootJam && this.FootJamCount == 0f && !this.scooterController.rearWheelGrounded)
			{
				this.FootJamCount = 1f;
				this.UpdateTutorialText("Awesome! Push the R-STICK all the way across and down, then HOP out of the FOOTJAM");
				this.PlaySound(this.smallSuccessSound);
			}
			if (this.FootJamCount == 1f && !this.scooterController.isGrounded)
			{
				this.FootJamCount = 2f;
				this.PlaySound(this.smallSuccessSound);
			}
			if (this.FootJamCount == 2f && this.scooterController.isGrounded)
			{
				this.PlaySound(this.correctSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.TailWhip, 1f));
				this.challengeList.CompleteChallenge(5);
			}
			if (this.FootJamCount == 1f && this.scooterController.rearWheelGrounded)
			{
				this.FootJamCount = 0f;
				this.PlaySound(this.incorrectSound);
				return;
			}
			break;
		case TutorialManager.TutorialState.TailWhip:
			this.GOTailWhip.SetActive(true);
			if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("TailWhip") && !this.scooterController.isGrounded && this.TailWhipCount == 0f)
			{
				this.TailWhipCount = 1f;
				this.PlaySound(this.smallSuccessSound);
			}
			if (this.scooterController.isGrounded && this.TailWhipCount == 1f)
			{
				this.PlaySound(this.correctSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.HeelWhip, 1f));
				return;
			}
			break;
		case TutorialManager.TutorialState.HeelWhip:
			this.GOHeelWhip.SetActive(true);
			if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("HeelFlip") && !this.scooterController.isGrounded && this.HeelWhipCount == 0f)
			{
				this.HeelWhipCount = 1f;
				this.PlaySound(this.smallSuccessSound);
			}
			if (this.scooterController.isGrounded && this.HeelWhipCount == 1f)
			{
				this.PlaySound(this.correctSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.Walking, 1f));
				this.FlipsAndSpinsObject.SetActive(true);
				return;
			}
			break;
		case TutorialManager.TutorialState.Walking:
			this.GetoffButton.SetActive(true);
			this.WalkingChallenge.SetActive(true);
			if (GameObject.FindGameObjectsWithTag("markers").Length == 0)
			{
				this.WalkingChallenge.SetActive(false);
				this.PlaySound(this.smallSuccessSound);
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.FlipsSpins, 1f));
				return;
			}
			break;
		case TutorialManager.TutorialState.FlipsSpins:
			if (!this.FlipsAndSpinsObject.activeSelf)
			{
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.TricksOverBank, 1f));
				return;
			}
			break;
		case TutorialManager.TutorialState.TricksOverBank:
			this.TricksOverBankObject.SetActive(true);
			if (this.tricksOverBankTutorial.hasTouchedA)
			{
				if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("BriFlip") && !this.scooterController.isGrounded && this.BriflipCount == 0f)
				{
					this.BriflipCount = 1f;
					this.PlaySound(this.smallSuccessSound);
				}
				if (this.scooterController.isGrounded && this.BriflipCount == 1f)
				{
					this.PlaySound(this.correctSound);
					this.DisableAllButtons();
					this.UpdateTutorialHeader("Fly Out Inward");
					this.UpdateTutorialText("HOP the ramp and press R2+UP on the R-STICK");
					this.BriflipCount = 2f;
					this.GOInward.SetActive(true);
				}
				if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Inward Briflip") && !this.scooterController.isGrounded && this.BriflipCount == 2f && this.InwardCount == 0f)
				{
					this.InwardCount = 1f;
					this.PlaySound(this.smallSuccessSound);
				}
				if (this.scooterController.isGrounded && this.InwardCount == 1f)
				{
					this.PlaySound(this.correctSound);
					this.DisableAllButtons();
					this.UpdateTutorialHeader("Bri To Inward combo");
					this.UpdateTutorialText("HOP the ramp and press R2+DOWN & Then R2+UP on the R-STICK");
					this.InwardCount = 2f;
					this.GOInward.SetActive(true);
					this.GOBriflip.SetActive(true);
				}
				if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("BriFlip") && !this.scooterController.isGrounded && this.InwardCount == 2f && this.DoubleOverHeadCount == 0f)
				{
					this.DoubleOverHeadCount = 1f;
					this.PlaySound(this.smallSuccessSound);
				}
				if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Inward Briflip") && !this.scooterController.isGrounded && this.DoubleOverHeadCount == 1f)
				{
					this.DoubleOverHeadCount = 2f;
					this.PlaySound(this.smallSuccessSound);
				}
				if (this.scooterController.isGrounded && this.DoubleOverHeadCount == 2f)
				{
					this.PlaySound(this.correctSound);
					this.DisableAllButtons();
					this.UpdateTutorialHeader("MultiWhip");
					this.UpdateTutorialText("HOP the ramp and HOLD L2+R2+RIGHT on the R-STICK to MULTIWHIP");
					this.DoubleOverHeadCount = 3f;
					this.GOMultiWhip.SetActive(true);
				}
				else if (this.scooterController.isGrounded && this.DoubleOverHeadCount == 1f)
				{
					this.PlaySound(this.incorrectSound);
					this.UpdateTutorialText("Just missed it! Try Again");
					this.DoubleOverHeadCount = 0f;
				}
				if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("ContWhipTree") && !this.scooterController.isGrounded && this.DoubleOverHeadCount == 3f && this.MultiWhipCount == 0f)
				{
					this.MultiWhipCount = 1f;
					this.PlaySound(this.smallSuccessSound);
				}
				if (this.scooterController.isGrounded && this.MultiWhipCount == 1f)
				{
					this.PlaySound(this.correctSound);
					this.DisableAllButtons();
					this.UpdateTutorialHeader("Whip Bar Whip combo");
					this.UpdateTutorialText("HOP the ramp and press R2+Right Then R1+Right then R2+Right");
					this.MultiWhipCount = 2f;
					this.GOTailWhip.SetActive(true);
					this.GOBarspin.SetActive(true);
				}
				if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("TailWhip") && !this.scooterController.isGrounded && this.MultiWhipCount == 2f && this.WhipBarWhipCount == 0f)
				{
					this.WhipBarWhipCount = 1f;
					this.PlaySound(this.smallSuccessSound);
				}
				if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("BarSpin") && !this.scooterController.isGrounded && this.WhipBarWhipCount == 1f)
				{
					this.WhipBarWhipCount = 2f;
					this.PlaySound(this.smallSuccessSound);
				}
				if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("TailWhip") && !this.scooterController.isGrounded && this.WhipBarWhipCount == 2f)
				{
					this.WhipBarWhipCount = 3f;
					this.PlaySound(this.smallSuccessSound);
				}
				if (this.scooterController.isGrounded && this.WhipBarWhipCount == 3f)
				{
					this.PlaySound(this.correctSound);
					base.StartCoroutine(this.FadeOutText());
					this.SetTutorialState(TutorialManager.TutorialState.WaitState);
					this.DisableAllButtons();
					base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.PerfectTransfer, 1f));
					this.TransferChallangeObject.SetActive(true);
					this.TricksOverBankObject.SetActive(false);
					this.WhipBarWhipCount = 4f;
					return;
				}
				if ((this.scooterController.isGrounded && this.WhipBarWhipCount == 1f) || (this.scooterController.isGrounded && this.WhipBarWhipCount == 2f))
				{
					this.PlaySound(this.incorrectSound);
					this.WhipBarWhipCount = 0f;
					return;
				}
			}
			break;
		case TutorialManager.TutorialState.PerfectTransfer:
			if (!this.TransferChallangeObject.activeSelf)
			{
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.PerfectAiring, 1f));
				this.AiringChallangeObject.SetActive(true);
				return;
			}
			break;
		case TutorialManager.TutorialState.PerfectAiring:
			if (!this.AiringChallangeObject.activeSelf)
			{
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.PerfectHips, 1f));
				this.HipsChallangeObject.SetActive(true);
				return;
			}
			break;
		case TutorialManager.TutorialState.PerfectHips:
			if (!this.HipsChallangeObject.activeSelf)
			{
				base.StartCoroutine(this.FadeOutText());
				this.SetTutorialState(TutorialManager.TutorialState.WaitState);
				this.DisableAllButtons();
				base.StartCoroutine(this.DelayBeforeNextState(TutorialManager.TutorialState.Completed, 1f));
				this.TransferChallangeObject.SetActive(true);
			}
			break;
		case TutorialManager.TutorialState.Completed:
			break;
		default:
			return;
		}
	}

	// Token: 0x06000328 RID: 808 RVA: 0x00019595 File Offset: 0x00017795
	private void UnfreezePlayer()
	{
		this.playerRigidbody.constraints = RigidbodyConstraints.None;
	}

	// Token: 0x0400042B RID: 1067
	private int playerId;

	// Token: 0x0400042C RID: 1068
	private Player player;

	// Token: 0x0400042D RID: 1069
	public TutorialManager.TutorialState currentState;

	// Token: 0x0400042E RID: 1070
	public ScooterController scooterController;

	// Token: 0x0400042F RID: 1071
	public TeleportPlayer teleportPlayer;

	// Token: 0x04000430 RID: 1072
	private ChallengeList challengeList;

	// Token: 0x04000431 RID: 1073
	public Animator animator;

	// Token: 0x04000432 RID: 1074
	public GameObject playerObject;

	// Token: 0x04000433 RID: 1075
	public Text tutorialText;

	// Token: 0x04000434 RID: 1076
	public Text tutorialHeader;

	// Token: 0x04000435 RID: 1077
	[Header("Buttons")]
	public GameObject Push;

	// Token: 0x04000436 RID: 1078
	public GameObject Stop;

	// Token: 0x04000437 RID: 1079
	public GameObject GetoffButton;

	// Token: 0x04000438 RID: 1080
	public GameObject Left;

	// Token: 0x04000439 RID: 1081
	public GameObject Right;

	// Token: 0x0400043A RID: 1082
	public GameObject Up;

	// Token: 0x0400043B RID: 1083
	public GameObject Down;

	// Token: 0x0400043C RID: 1084
	public GameObject GODpad;

	// Token: 0x0400043D RID: 1085
	public GameObject GOTailWhip;

	// Token: 0x0400043E RID: 1086
	public GameObject GOHeelWhip;

	// Token: 0x0400043F RID: 1087
	public GameObject GOInward;

	// Token: 0x04000440 RID: 1088
	public GameObject GOBriflip;

	// Token: 0x04000441 RID: 1089
	public GameObject GOBarspin;

	// Token: 0x04000442 RID: 1090
	public GameObject GOMultiWhip;

	// Token: 0x04000443 RID: 1091
	public GameObject GOLup;

	// Token: 0x04000444 RID: 1092
	public GameObject GOLdown;

	// Token: 0x04000445 RID: 1093
	[Header("Sound")]
	public AudioSource audioSource;

	// Token: 0x04000446 RID: 1094
	public AudioClip correctSound;

	// Token: 0x04000447 RID: 1095
	public AudioClip smallSuccessSound;

	// Token: 0x04000448 RID: 1096
	public AudioClip incorrectSound;

	// Token: 0x04000449 RID: 1097
	[Header("ChallengeObjects")]
	public GameObject ConesChallange;

	// Token: 0x0400044A RID: 1098
	public GameObject HopChallangeObject;

	// Token: 0x0400044B RID: 1099
	public GameObject TransferChallangeObject;

	// Token: 0x0400044C RID: 1100
	public GameObject AiringChallangeObject;

	// Token: 0x0400044D RID: 1101
	public GameObject TricksOverBankObject;

	// Token: 0x0400044E RID: 1102
	public GameObject HipsChallangeObject;

	// Token: 0x0400044F RID: 1103
	public GameObject FlipsAndSpinsObject;

	// Token: 0x04000450 RID: 1104
	public GameObject ManualChallangeObject;

	// Token: 0x04000451 RID: 1105
	public GameObject WalkingChallenge;

	// Token: 0x04000452 RID: 1106
	[Header("ChallengeScripts")]
	public TricksOverBankTutorial tricksOverBankTutorial;

	// Token: 0x04000453 RID: 1107
	private Rigidbody playerRigidbody;

	// Token: 0x04000454 RID: 1108
	private MonoBehaviour[] playerScripts;

	// Token: 0x04000455 RID: 1109
	private float holdTime;

	// Token: 0x04000456 RID: 1110
	private int steerCountLeft;

	// Token: 0x04000457 RID: 1111
	private int steerCountRight;

	// Token: 0x04000458 RID: 1112
	[Header("Sequence Segment Counters")]
	private float ManualCount;

	// Token: 0x04000459 RID: 1113
	private float NoseCount;

	// Token: 0x0400045A RID: 1114
	private float FootJamCount;

	// Token: 0x0400045B RID: 1115
	private float HopCount;

	// Token: 0x0400045C RID: 1116
	private float TailWhipCount;

	// Token: 0x0400045D RID: 1117
	private float HeelWhipCount;

	// Token: 0x0400045E RID: 1118
	private float BriflipCount;

	// Token: 0x0400045F RID: 1119
	private float InwardCount;

	// Token: 0x04000460 RID: 1120
	private float DoubleOverHeadCount;

	// Token: 0x04000461 RID: 1121
	private float MultiWhipCount;

	// Token: 0x04000462 RID: 1122
	private float WhipBarWhipCount;

	// Token: 0x04000463 RID: 1123
	public float fadeDuration = 0.5f;

	// Token: 0x020000B9 RID: 185
	public enum TutorialState
	{
		// Token: 0x04000465 RID: 1125
		Intro,
		// Token: 0x04000466 RID: 1126
		PushAlongGround,
		// Token: 0x04000467 RID: 1127
		Steering,
		// Token: 0x04000468 RID: 1128
		SteeringComplete,
		// Token: 0x04000469 RID: 1129
		SteeringCones,
		// Token: 0x0400046A RID: 1130
		SteeringConesComplete,
		// Token: 0x0400046B RID: 1131
		Hop,
		// Token: 0x0400046C RID: 1132
		HopChallange,
		// Token: 0x0400046D RID: 1133
		Manual,
		// Token: 0x0400046E RID: 1134
		NoseManual,
		// Token: 0x0400046F RID: 1135
		ManualChallenge,
		// Token: 0x04000470 RID: 1136
		FootJam,
		// Token: 0x04000471 RID: 1137
		TailWhip,
		// Token: 0x04000472 RID: 1138
		HeelWhip,
		// Token: 0x04000473 RID: 1139
		Walking,
		// Token: 0x04000474 RID: 1140
		FlipsSpins,
		// Token: 0x04000475 RID: 1141
		TricksOverBank,
		// Token: 0x04000476 RID: 1142
		PerfectTransfer,
		// Token: 0x04000477 RID: 1143
		PerfectAiring,
		// Token: 0x04000478 RID: 1144
		PerfectHips,
		// Token: 0x04000479 RID: 1145
		Completed,
		// Token: 0x0400047A RID: 1146
		WaitState
	}
}
