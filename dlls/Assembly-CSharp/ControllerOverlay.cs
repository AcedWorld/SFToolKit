using System;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000AD RID: 173
public class ControllerOverlay : MonoBehaviour
{
	// Token: 0x060002DC RID: 732 RVA: 0x0001693C File Offset: 0x00014B3C
	private void Start()
	{
		this.leftStickDefaultPos = this.leftStick.anchoredPosition;
		this.rightStickDefaultPos = this.rightStick.anchoredPosition;
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.buttonA.gameObject.SetActive(false);
		this.buttonB.gameObject.SetActive(false);
		this.buttonX.gameObject.SetActive(false);
		this.buttonY.gameObject.SetActive(false);
		this.buttonStart.gameObject.SetActive(false);
		this.buttonSelect.gameObject.SetActive(false);
		this.buttonL1.gameObject.SetActive(false);
		this.buttonL2.gameObject.SetActive(false);
		this.buttonR1.gameObject.SetActive(false);
		this.buttonR2.gameObject.SetActive(false);
		this.DpadUp.gameObject.SetActive(false);
		this.DpadDown.gameObject.SetActive(false);
		this.DpadLeft.gameObject.SetActive(false);
		this.DpadRight.gameObject.SetActive(false);
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00016A6F File Offset: 0x00014C6F
	private void Update()
	{
		this.HandleLeftStickInput();
		this.HandleRightStickInput();
		this.HandleButtonInput();
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00016A84 File Offset: 0x00014C84
	private void HandleLeftStickInput()
	{
		Vector2 input = new Vector2(this.player.GetAxis("LeftStickX"), this.player.GetAxis("LeftStickY"));
		this.HandleStickMovement(this.leftStick, this.leftStickDefaultPos, input);
	}

	// Token: 0x060002DF RID: 735 RVA: 0x00016ACC File Offset: 0x00014CCC
	private void HandleRightStickInput()
	{
		Vector2 input = new Vector2(this.player.GetAxis("RightStickX"), this.player.GetAxis("RightStickY"));
		this.HandleStickMovement(this.rightStick, this.rightStickDefaultPos, input);
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x00016B14 File Offset: 0x00014D14
	private void HandleStickMovement(RectTransform stick, Vector2 defaultPosition, Vector2 input)
	{
		Vector2 b = input * this.maxStickDistance;
		stick.anchoredPosition = Vector2.Lerp(stick.anchoredPosition, defaultPosition + b, Time.deltaTime * 10f);
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x00016B54 File Offset: 0x00014D54
	private void HandleButtonInput()
	{
		this.buttonA.gameObject.SetActive(this.player.GetButton("Cross"));
		this.buttonB.gameObject.SetActive(this.player.GetButton("Circle"));
		this.buttonX.gameObject.SetActive(this.player.GetButton("Square"));
		this.buttonY.gameObject.SetActive(this.player.GetButton("Triangle"));
		this.buttonStart.gameObject.SetActive(this.player.GetButton("Start"));
		this.buttonSelect.gameObject.SetActive(this.player.GetButton("Select"));
		this.buttonL1.gameObject.SetActive(this.player.GetButton("L1"));
		this.buttonL2.gameObject.SetActive(this.player.GetButton("L2"));
		this.buttonR1.gameObject.SetActive(this.player.GetButton("R1"));
		this.buttonR2.gameObject.SetActive(this.player.GetButton("R2"));
		this.DpadUp.gameObject.SetActive(this.player.GetButton("D-PadUp"));
		this.DpadDown.gameObject.SetActive(this.player.GetButton("D-PadDown"));
		this.DpadLeft.gameObject.SetActive(this.player.GetButton("D-PadLeft"));
		this.DpadRight.gameObject.SetActive(this.player.GetButton("D-PadRight"));
	}

	// Token: 0x04000397 RID: 919
	[Header("Analog Stick Settings")]
	public RectTransform leftStick;

	// Token: 0x04000398 RID: 920
	public RectTransform rightStick;

	// Token: 0x04000399 RID: 921
	public float maxStickDistance = 50f;

	// Token: 0x0400039A RID: 922
	[Header("Buttons")]
	public Image buttonA;

	// Token: 0x0400039B RID: 923
	public Image buttonB;

	// Token: 0x0400039C RID: 924
	public Image buttonX;

	// Token: 0x0400039D RID: 925
	public Image buttonY;

	// Token: 0x0400039E RID: 926
	public Image buttonStart;

	// Token: 0x0400039F RID: 927
	public Image buttonSelect;

	// Token: 0x040003A0 RID: 928
	public Image buttonL1;

	// Token: 0x040003A1 RID: 929
	public Image buttonL2;

	// Token: 0x040003A2 RID: 930
	public Image buttonR1;

	// Token: 0x040003A3 RID: 931
	public Image buttonR2;

	// Token: 0x040003A4 RID: 932
	public Image DpadUp;

	// Token: 0x040003A5 RID: 933
	public Image DpadDown;

	// Token: 0x040003A6 RID: 934
	public Image DpadLeft;

	// Token: 0x040003A7 RID: 935
	public Image DpadRight;

	// Token: 0x040003A8 RID: 936
	private Vector2 leftStickDefaultPos;

	// Token: 0x040003A9 RID: 937
	private Vector2 rightStickDefaultPos;

	// Token: 0x040003AA RID: 938
	private int playerId;

	// Token: 0x040003AB RID: 939
	private Player player;
}
