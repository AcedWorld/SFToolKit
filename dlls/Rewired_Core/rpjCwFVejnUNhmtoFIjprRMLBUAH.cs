using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

// Token: 0x0200054C RID: 1356
internal sealed class rpjCwFVejnUNhmtoFIjprRMLBUAH : IElementIdentifierTool
{
	// Token: 0x060036D1 RID: 14033 RVA: 0x0002ABD3 File Offset: 0x00028DD3
	public void Initialize(GUIText text)
	{
		this.FhSxppCZYMMuGmaZysbzOeEmSmxC = text;
	}

	// Token: 0x060036D2 RID: 14034 RVA: 0x000BB504 File Offset: 0x000B9704
	public void Start()
	{
		string[] joystickNames = Input.GetJoystickNames();
		string text = "Detected " + joystickNames.Length.ToString() + " attached joysticks";
		if (joystickNames.Length != 0)
		{
			text += ":\n";
		}
		foreach (string str in joystickNames)
		{
			text = text + "\"" + str + "\"\n";
		}
		Logger.Log(text);
	}

	// Token: 0x060036D3 RID: 14035 RVA: 0x000BB570 File Offset: 0x000B9770
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			this.KHLQIhvBjfkmTDltIThTJuMgBVTn++;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			this.KHLQIhvBjfkmTDltIThTJuMgBVTn--;
		}
		if (this.KHLQIhvBjfkmTDltIThTJuMgBVTn <= 0)
		{
			this.KHLQIhvBjfkmTDltIThTJuMgBVTn = 16;
		}
		else if (this.KHLQIhvBjfkmTDltIThTJuMgBVTn > 16)
		{
			this.KHLQIhvBjfkmTDltIThTJuMgBVTn = 1;
		}
		this.dYNnbCukvVwcFPUuTTtUwZFKwman = "Unity Joystick Element Identifier:\n\n";
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length != 0)
		{
			this.dYNnbCukvVwcFPUuTTtUwZFKwman += "Connected joysticks:\n";
		}
		else
		{
			this.dYNnbCukvVwcFPUuTTtUwZFKwman += "No joysticks detected.\n";
		}
		for (int i = 0; i < joystickNames.Length; i++)
		{
			this.dYNnbCukvVwcFPUuTTtUwZFKwman = string.Concat(new string[]
			{
				this.dYNnbCukvVwcFPUuTTtUwZFKwman,
				"[",
				i.ToString(),
				"] \"",
				joystickNames[i],
				"\""
			});
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(joystickNames[i]))
			{
				this.dYNnbCukvVwcFPUuTTtUwZFKwman += " [UNITY PRE-CONFIGURED]";
			}
			this.dYNnbCukvVwcFPUuTTtUwZFKwman += "\n";
		}
		this.dYNnbCukvVwcFPUuTTtUwZFKwman += "\n";
		this.dYNnbCukvVwcFPUuTTtUwZFKwman = this.dYNnbCukvVwcFPUuTTtUwZFKwman + "Current Unity Joystick Id: " + this.KHLQIhvBjfkmTDltIThTJuMgBVTn.ToString() + "\n";
		this.dYNnbCukvVwcFPUuTTtUwZFKwman += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j.ToString();
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(this.KHLQIhvBjfkmTDltIThTJuMgBVTn, j);
			this.QticzAKQIfcmfQKqWXFkJCaJUxXI(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k.ToString();
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(this.KHLQIhvBjfkmTDltIThTJuMgBVTn, k);
			this.QticzAKQIfcmfQKqWXFkJCaJUxXI(text2, joystickButtonValueByJoystickId);
		}
		this.FhSxppCZYMMuGmaZysbzOeEmSmxC.text = this.dYNnbCukvVwcFPUuTTtUwZFKwman;
	}

	// Token: 0x060036D4 RID: 14036 RVA: 0x00002FF9 File Offset: 0x000011F9
	public void OnDestroy()
	{
	}

	// Token: 0x060036D5 RID: 14037 RVA: 0x0002ABDC File Offset: 0x00028DDC
	private void QticzAKQIfcmfQKqWXFkJCaJUxXI(string A_1, object A_2)
	{
		this.dYNnbCukvVwcFPUuTTtUwZFKwman = string.Concat(new string[]
		{
			this.dYNnbCukvVwcFPUuTTtUwZFKwman,
			A_1,
			" = ",
			A_2.ToString(),
			"\n"
		});
	}

	// Token: 0x04001CB4 RID: 7348
	private GUIText FhSxppCZYMMuGmaZysbzOeEmSmxC;

	// Token: 0x04001CB5 RID: 7349
	private string dYNnbCukvVwcFPUuTTtUwZFKwman;

	// Token: 0x04001CB6 RID: 7350
	private int KHLQIhvBjfkmTDltIThTJuMgBVTn = 1;
}
