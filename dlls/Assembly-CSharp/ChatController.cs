using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000217 RID: 535
public class ChatController : MonoBehaviour
{
	// Token: 0x06000873 RID: 2163 RVA: 0x0003B515 File Offset: 0x00039715
	private void OnEnable()
	{
		this.ChatInputField.onSubmit.AddListener(new UnityAction<string>(this.AddToChatOutput));
	}

	// Token: 0x06000874 RID: 2164 RVA: 0x0003B533 File Offset: 0x00039733
	private void OnDisable()
	{
		this.ChatInputField.onSubmit.RemoveListener(new UnityAction<string>(this.AddToChatOutput));
	}

	// Token: 0x06000875 RID: 2165 RVA: 0x0003B554 File Offset: 0x00039754
	private void AddToChatOutput(string newText)
	{
		this.ChatInputField.text = string.Empty;
		DateTime now = DateTime.Now;
		string text = string.Concat(new string[]
		{
			"[<#FFFF80>",
			now.Hour.ToString("d2"),
			":",
			now.Minute.ToString("d2"),
			":",
			now.Second.ToString("d2"),
			"</color>] ",
			newText
		});
		if (this.ChatDisplayOutput != null)
		{
			if (this.ChatDisplayOutput.text == string.Empty)
			{
				this.ChatDisplayOutput.text = text;
			}
			else
			{
				TMP_Text chatDisplayOutput = this.ChatDisplayOutput;
				chatDisplayOutput.text = chatDisplayOutput.text + "\n" + text;
			}
		}
		this.ChatInputField.ActivateInputField();
		this.ChatScrollbar.value = 0f;
	}

	// Token: 0x04000EA8 RID: 3752
	public TMP_InputField ChatInputField;

	// Token: 0x04000EA9 RID: 3753
	public TMP_Text ChatDisplayOutput;

	// Token: 0x04000EAA RID: 3754
	public Scrollbar ChatScrollbar;
}
