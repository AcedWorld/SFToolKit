using System;
using UnityEngine;

// Token: 0x020000F7 RID: 247
public class TrickButtonLogic : MonoBehaviour
{
	// Token: 0x06000408 RID: 1032 RVA: 0x0001D1E3 File Offset: 0x0001B3E3
	private void Start()
	{
		this.UpdateTrickIcons();
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x0001D1EB File Offset: 0x0001B3EB
	public void UpdateTrickIcons()
	{
		this.updateJoystickPosition();
		this.updateTrickName();
		this.updateTriggerOneImages();
		this.updateTriggerTwoImages();
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x0001D205 File Offset: 0x0001B405
	public void updateTrickName()
	{
		this.references.trickNameText.text = base.gameObject.name;
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x0001D224 File Offset: 0x0001B424
	public void updateJoystickPosition()
	{
		string a = this.JoystickDirection.ToString();
		if (a == "Up")
		{
			this.references.joystick.localPosition = new Vector3(0f, 20f, 0f);
		}
		if (a == "Left")
		{
			this.references.joystick.localPosition = new Vector3(-20f, 0f, 0f);
		}
		if (a == "Right")
		{
			this.references.joystick.localPosition = new Vector3(20f, 0f, 0f);
		}
		if (a == "Down")
		{
			this.references.joystick.localPosition = new Vector3(0f, -20f, 0f);
		}
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x0001D308 File Offset: 0x0001B508
	public void updateTriggerOneImages()
	{
		string a = this.ButtonOne.ToString();
		if (this.ControllerType == 0)
		{
			if (a == "L1")
			{
				this.references.FirstInput.sprite = this.components.L1;
			}
			if (a == "L2")
			{
				this.references.FirstInput.sprite = this.components.L2;
			}
			if (a == "R1")
			{
				this.references.FirstInput.sprite = this.components.R1;
			}
			if (a == "R2")
			{
				this.references.FirstInput.sprite = this.components.R2;
			}
		}
		if (this.ControllerType == 1)
		{
			if (a == "L1")
			{
				this.references.FirstInput.sprite = this.componentsXbox.L1;
			}
			if (a == "L2")
			{
				this.references.FirstInput.sprite = this.componentsXbox.L2;
			}
			if (a == "R1")
			{
				this.references.FirstInput.sprite = this.componentsXbox.R1;
			}
			if (a == "R2")
			{
				this.references.FirstInput.sprite = this.componentsXbox.R2;
			}
		}
		this.references.FirstInput.SetNativeSize();
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x0001D490 File Offset: 0x0001B690
	public void updateTriggerTwoImages()
	{
		string a = this.ButtonTwo.ToString();
		if (a == "Unnassigned")
		{
			this.ChangeToSingleInput();
		}
		if (this.ControllerType == 0)
		{
			if (a == "L1")
			{
				this.references.SecondInput.sprite = this.components.L1;
			}
			if (a == "L2")
			{
				this.references.SecondInput.sprite = this.components.L2;
			}
			if (a == "R1")
			{
				this.references.SecondInput.sprite = this.components.R1;
			}
			if (a == "R2")
			{
				this.references.SecondInput.sprite = this.components.R2;
			}
		}
		if (this.ControllerType == 1)
		{
			if (a == "L1")
			{
				this.references.SecondInput.sprite = this.componentsXbox.L1;
			}
			if (a == "L2")
			{
				this.references.SecondInput.sprite = this.componentsXbox.L2;
			}
			if (a == "R1")
			{
				this.references.SecondInput.sprite = this.componentsXbox.R1;
			}
			if (a == "R2")
			{
				this.references.SecondInput.sprite = this.componentsXbox.R2;
			}
		}
		this.references.SecondInput.SetNativeSize();
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x0001D62C File Offset: 0x0001B82C
	public void ChangeToSingleInput()
	{
		this.references.SecondInput.gameObject.SetActive(false);
		this.references.LeftButton.localPosition = new Vector3(-40f, 12.5f, 0f);
		this.references.RightButton.localPosition = new Vector3(40f, 12.5f, 0f);
	}

	// Token: 0x040005FF RID: 1535
	[SerializeField]
	private TrickButtonOne ButtonOne;

	// Token: 0x04000600 RID: 1536
	[SerializeField]
	private TrickButtonTwo ButtonTwo;

	// Token: 0x04000601 RID: 1537
	[SerializeField]
	private TrickJoystick JoystickDirection;

	// Token: 0x04000602 RID: 1538
	public TrickButtonComponents components;

	// Token: 0x04000603 RID: 1539
	public TrickButtonComponentsXbox componentsXbox;

	// Token: 0x04000604 RID: 1540
	public TrickButtonReferences references;

	// Token: 0x04000605 RID: 1541
	public int ControllerType;
}
