using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.UIElements
{
	// Token: 0x02000271 RID: 625
	public class KeyboardNavigationManipulator : Manipulator
	{
		// Token: 0x060011BA RID: 4538 RVA: 0x000405CC File Offset: 0x0003E7CC
		public KeyboardNavigationManipulator(Action<KeyboardNavigationOperation, EventBase> action)
		{
			this.m_Action = action;
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x000405E0 File Offset: 0x0003E7E0
		protected override void RegisterCallbacksOnTarget()
		{
			base.target.RegisterCallback<NavigationMoveEvent>(new EventCallback<NavigationMoveEvent>(this.OnNavigationMove), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<NavigationSubmitEvent>(new EventCallback<NavigationSubmitEvent>(this.OnNavigationSubmit), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<NavigationCancelEvent>(new EventCallback<NavigationCancelEvent>(this.OnNavigationCancel), TrickleDown.NoTrickleDown);
			base.target.RegisterCallback<KeyDownEvent>(new EventCallback<KeyDownEvent>(this.OnKeyDown), TrickleDown.NoTrickleDown);
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x00040654 File Offset: 0x0003E854
		protected override void UnregisterCallbacksFromTarget()
		{
			base.target.UnregisterCallback<NavigationMoveEvent>(new EventCallback<NavigationMoveEvent>(this.OnNavigationMove), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<NavigationSubmitEvent>(new EventCallback<NavigationSubmitEvent>(this.OnNavigationSubmit), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<NavigationCancelEvent>(new EventCallback<NavigationCancelEvent>(this.OnNavigationCancel), TrickleDown.NoTrickleDown);
			base.target.UnregisterCallback<KeyDownEvent>(new EventCallback<KeyDownEvent>(this.OnKeyDown), TrickleDown.NoTrickleDown);
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x000406C8 File Offset: 0x0003E8C8
		internal void OnKeyDown(KeyDownEvent evt)
		{
			KeyboardNavigationManipulator.<>c__DisplayClass4_0 CS$<>8__locals1;
			CS$<>8__locals1.evt = evt;
			KeyboardNavigationOperation keyboardNavigationOperation = KeyboardNavigationManipulator.<OnKeyDown>g__GetOperation|4_0(ref CS$<>8__locals1);
			bool flag = keyboardNavigationOperation > KeyboardNavigationOperation.None;
			if (flag)
			{
				this.Invoke(keyboardNavigationOperation, CS$<>8__locals1.evt);
			}
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x000406FF File Offset: 0x0003E8FF
		private void OnNavigationCancel(NavigationCancelEvent evt)
		{
			this.Invoke(KeyboardNavigationOperation.Cancel, evt);
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x0004070B File Offset: 0x0003E90B
		private void OnNavigationSubmit(NavigationSubmitEvent evt)
		{
			this.Invoke(KeyboardNavigationOperation.Submit, evt);
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x00040718 File Offset: 0x0003E918
		private void OnNavigationMove(NavigationMoveEvent evt)
		{
			switch (evt.direction)
			{
			case NavigationMoveEvent.Direction.Left:
				this.Invoke(KeyboardNavigationOperation.MoveLeft, evt);
				break;
			case NavigationMoveEvent.Direction.Up:
				this.Invoke(KeyboardNavigationOperation.Previous, evt);
				break;
			case NavigationMoveEvent.Direction.Right:
				this.Invoke(KeyboardNavigationOperation.MoveRight, evt);
				break;
			case NavigationMoveEvent.Direction.Down:
				this.Invoke(KeyboardNavigationOperation.Next, evt);
				break;
			}
		}

		// Token: 0x060011C1 RID: 4545 RVA: 0x00040775 File Offset: 0x0003E975
		private void Invoke(KeyboardNavigationOperation operation, EventBase evt)
		{
			Action<KeyboardNavigationOperation, EventBase> action = this.m_Action;
			if (action != null)
			{
				action(operation, evt);
			}
		}

		// Token: 0x060011C2 RID: 4546 RVA: 0x0004078C File Offset: 0x0003E98C
		[CompilerGenerated]
		internal static KeyboardNavigationOperation <OnKeyDown>g__GetOperation|4_0(ref KeyboardNavigationManipulator.<>c__DisplayClass4_0 A_0)
		{
			KeyCode keyCode = A_0.evt.keyCode;
			KeyCode keyCode2 = keyCode;
			if (keyCode2 != KeyCode.A)
			{
				switch (keyCode2)
				{
				case KeyCode.UpArrow:
				case KeyCode.DownArrow:
				case KeyCode.RightArrow:
				case KeyCode.LeftArrow:
					A_0.evt.StopPropagation();
					break;
				case KeyCode.Home:
					return KeyboardNavigationOperation.Begin;
				case KeyCode.End:
					return KeyboardNavigationOperation.End;
				case KeyCode.PageUp:
					return KeyboardNavigationOperation.PageUp;
				case KeyCode.PageDown:
					return KeyboardNavigationOperation.PageDown;
				}
			}
			else if (A_0.evt.actionKey)
			{
				return KeyboardNavigationOperation.SelectAll;
			}
			return KeyboardNavigationOperation.None;
		}

		// Token: 0x040007DF RID: 2015
		private readonly Action<KeyboardNavigationOperation, EventBase> m_Action;
	}
}
