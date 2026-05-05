using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001A0 RID: 416
public class PlayerScoring : MonoBehaviour
{
	// Token: 0x06000687 RID: 1671 RVA: 0x00031944 File Offset: 0x0002FB44
	private void Start()
	{
		this.lastRotation = base.transform.localRotation;
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x00031958 File Offset: 0x0002FB58
	private void Update()
	{
		if (!this.scooterController.isGrounded)
		{
			this.UpdateInAirRotation();
			this.hasLanded = false;
		}
		else if (!this.hasLanded && this.scooterController.frontWheelGrounded && this.scooterController.rearWheelGrounded)
		{
			this.Land();
		}
		if (this.lockRotation.isGrinding)
		{
			this.AddScore("Grind", 250);
		}
		this.UpdateScoreUI();
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x000319CC File Offset: 0x0002FBCC
	private void UpdateInAirRotation()
	{
		Quaternion localRotation = base.transform.localRotation;
		Vector3 eulerAngles = (Quaternion.Inverse(this.lastRotation) * localRotation).eulerAngles;
		float num = this.NormalizeAngle(eulerAngles.y);
		float num2 = this.NormalizeAngle(eulerAngles.x);
		this.spinsCount += Mathf.Abs(num);
		this.flipsCount += Mathf.Abs(num2);
		this.flipMultiplier = Mathf.FloorToInt(Mathf.Abs(this.flipsCount + 180f) / 360f);
		this.spinsCountRounded = (float)((Mathf.Abs(this.spinsCount) > 45f) ? (Mathf.RoundToInt(this.spinsCount / 90f) * 90) : 0);
		float num3 = Mathf.Abs(this.spinsCount);
		if (num3 > 135f)
		{
			if (num3 <= 360f)
			{
				this.spinsCountRounded = (float)(Mathf.RoundToInt(num3 / 90f) * 90);
			}
			else
			{
				this.spinsCountRounded = (float)(Mathf.RoundToInt(num3 / 180f) * 180);
			}
		}
		else
		{
			this.spinsCountRounded = 0f;
		}
		if (string.IsNullOrEmpty(this.flipDirection) && Mathf.Abs(this.flipsCount) > 45f)
		{
			this.flipDirection = ((num2 > 0f) ? "Backflip" : "Frontflip");
		}
		if (string.IsNullOrEmpty(this.spinDirection) && Mathf.Abs(this.spinsCount) > 45f)
		{
			this.spinDirection = ((num > 0f) ? "FS" : "BS");
		}
		this.currentFlipPoints = ((Mathf.Abs(this.flipsCount) > 45f) ? Mathf.FloorToInt(this.flipsCount) : 0);
		this.currentSpinPoints = ((Mathf.Abs(this.spinsCount) > 45f) ? Mathf.FloorToInt(this.spinsCount) : 0);
		this.totalScore = (int)Mathf.Round((float)(this.score + this.currentFlipPoints + this.currentSpinPoints) / 10f) * 10;
		this.lastRotation = localRotation;
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x00031BE4 File Offset: 0x0002FDE4
	private void Land()
	{
		this.hasLanded = true;
		this.landedScore = this.totalScore;
		this.score = 0;
		this.flipsCount = 0f;
		this.spinsCount = 0f;
		this.currentFlipPoints = 0;
		this.currentSpinPoints = 0;
		this.flipDirection = "";
		this.spinDirection = "";
		this.completedTricks.Clear();
		if (this.scoreText != null)
		{
			string text = string.Format("{0} LANDED", this.landedScore);
			this.scoreText.text = text;
		}
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x00031C80 File Offset: 0x0002FE80
	private void UpdateScoreUI()
	{
		if (!this.hasLanded)
		{
			string text = (this.totalScore > 0) ? string.Format("{0}  COMBO", this.totalScore) : "0  Combo";
			string text2 = (this.flipMultiplier >= 1) ? string.Format("{0} x{1}", this.flipDirection, this.flipMultiplier) : "No Flips";
			string text3 = (this.spinDirection != "") ? string.Format("{0} {1}", this.spinDirection, Mathf.FloorToInt(this.spinsCountRounded)) : "No Spins";
			string text4 = (this.completedTricks.Count > 0) ? string.Join(" + ", this.completedTricks) : "No Tricks";
			this.scoreText.text = string.Concat(new string[]
			{
				text,
				"\n",
				text2,
				"\n",
				text3,
				"\n",
				text4
			});
			this.scoreText.color = Color.white;
		}
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x00031D98 File Offset: 0x0002FF98
	public void AddScore(string trickName, int points)
	{
		this.score += points;
		this.currentTrick = trickName;
		this.completedTricks.Add(trickName);
		this.currentTrickPoints = points;
		this.UpdateScoreUI();
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x00031DC8 File Offset: 0x0002FFC8
	private float NormalizeAngle(float angle)
	{
		if (angle > 180f)
		{
			angle -= 360f;
		}
		return angle;
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x00031DDC File Offset: 0x0002FFDC
	private Color HexToColor(string hex)
	{
		Color result;
		if (ColorUtility.TryParseHtmlString(hex, out result))
		{
			return result;
		}
		return Color.white;
	}

	// Token: 0x04000B65 RID: 2917
	public ScooterController scooterController;

	// Token: 0x04000B66 RID: 2918
	public LockRotation lockRotation;

	// Token: 0x04000B67 RID: 2919
	public Text scoreText;

	// Token: 0x04000B68 RID: 2920
	private Quaternion lastRotation;

	// Token: 0x04000B69 RID: 2921
	public string flipDirection = "";

	// Token: 0x04000B6A RID: 2922
	public float flipsCount;

	// Token: 0x04000B6B RID: 2923
	public int flipMultiplier;

	// Token: 0x04000B6C RID: 2924
	public int currentFlipPoints;

	// Token: 0x04000B6D RID: 2925
	public string spinDirection = "";

	// Token: 0x04000B6E RID: 2926
	public float spinsCount;

	// Token: 0x04000B6F RID: 2927
	public float spinsCountRounded;

	// Token: 0x04000B70 RID: 2928
	public int currentSpinPoints;

	// Token: 0x04000B71 RID: 2929
	private int score;

	// Token: 0x04000B72 RID: 2930
	private int totalScore;

	// Token: 0x04000B73 RID: 2931
	private int landedScore;

	// Token: 0x04000B74 RID: 2932
	private string currentTrick = "";

	// Token: 0x04000B75 RID: 2933
	public int currentTrickPoints;

	// Token: 0x04000B76 RID: 2934
	private bool hasLanded;

	// Token: 0x04000B77 RID: 2935
	private List<string> completedTricks = new List<string>();
}
