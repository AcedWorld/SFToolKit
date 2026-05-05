using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000065 RID: 101
	internal class DebugActionState
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600035E RID: 862 RVA: 0x0000E699 File Offset: 0x0000C899
		// (set) Token: 0x0600035F RID: 863 RVA: 0x0000E6A1 File Offset: 0x0000C8A1
		internal bool runningAction { get; private set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000360 RID: 864 RVA: 0x0000E6AA File Offset: 0x0000C8AA
		// (set) Token: 0x06000361 RID: 865 RVA: 0x0000E6B2 File Offset: 0x0000C8B2
		internal float actionState { get; private set; }

		// Token: 0x06000362 RID: 866 RVA: 0x0000E6BC File Offset: 0x0000C8BC
		private void Trigger(int triggerCount, float state)
		{
			this.actionState = state;
			this.runningAction = true;
			this.m_Timer = 0f;
			this.m_TriggerPressedUp = new bool[triggerCount];
			for (int i = 0; i < this.m_TriggerPressedUp.Length; i++)
			{
				this.m_TriggerPressedUp[i] = false;
			}
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000E70A File Offset: 0x0000C90A
		public void TriggerWithButton(string[] buttons, float state)
		{
			this.m_Type = DebugActionState.DebugActionKeyType.Button;
			this.m_PressedButtons = buttons;
			this.m_PressedAxis = "";
			this.Trigger(buttons.Length, state);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000E72F File Offset: 0x0000C92F
		public void TriggerWithAxis(string axis, float state)
		{
			this.m_Type = DebugActionState.DebugActionKeyType.Axis;
			this.m_PressedAxis = axis;
			this.Trigger(1, state);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000E747 File Offset: 0x0000C947
		public void TriggerWithKey(KeyCode[] keys, float state)
		{
			this.m_Type = DebugActionState.DebugActionKeyType.Key;
			this.m_PressedKeys = keys;
			this.m_PressedAxis = "";
			this.Trigger(keys.Length, state);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0000E76C File Offset: 0x0000C96C
		private void Reset()
		{
			this.runningAction = false;
			this.m_Timer = 0f;
			this.m_TriggerPressedUp = null;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0000E788 File Offset: 0x0000C988
		public void Update(DebugActionDesc desc)
		{
			this.actionState = 0f;
			if (this.m_TriggerPressedUp != null)
			{
				this.m_Timer += Time.deltaTime;
				for (int i = 0; i < this.m_TriggerPressedUp.Length; i++)
				{
					if (this.m_Type == DebugActionState.DebugActionKeyType.Button)
					{
						this.m_TriggerPressedUp[i] |= Input.GetButtonUp(this.m_PressedButtons[i]);
					}
					else if (this.m_Type == DebugActionState.DebugActionKeyType.Axis)
					{
						this.m_TriggerPressedUp[i] |= Mathf.Approximately(Input.GetAxis(this.m_PressedAxis), 0f);
					}
					else
					{
						this.m_TriggerPressedUp[i] |= Input.GetKeyUp(this.m_PressedKeys[i]);
					}
				}
				bool flag = true;
				foreach (bool flag2 in this.m_TriggerPressedUp)
				{
					flag = (flag && flag2);
				}
				if (flag || (this.m_Timer > desc.repeatDelay && desc.repeatMode == DebugActionRepeatMode.Delay))
				{
					this.Reset();
				}
			}
		}

		// Token: 0x040001E9 RID: 489
		private DebugActionState.DebugActionKeyType m_Type;

		// Token: 0x040001EA RID: 490
		private string[] m_PressedButtons;

		// Token: 0x040001EB RID: 491
		private string m_PressedAxis = "";

		// Token: 0x040001EC RID: 492
		private KeyCode[] m_PressedKeys;

		// Token: 0x040001ED RID: 493
		private bool[] m_TriggerPressedUp;

		// Token: 0x040001EE RID: 494
		private float m_Timer;

		// Token: 0x0200016C RID: 364
		private enum DebugActionKeyType
		{
			// Token: 0x04000614 RID: 1556
			Button,
			// Token: 0x04000615 RID: 1557
			Axis,
			// Token: 0x04000616 RID: 1558
			Key
		}
	}
}
