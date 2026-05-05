using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001D7 RID: 471
	public class KeyDownEvent : KeyboardEventBase<KeyDownEvent>
	{
		// Token: 0x06000E3F RID: 3647 RVA: 0x00036A6B File Offset: 0x00034C6B
		static KeyDownEvent()
		{
			EventBase<KeyDownEvent>.SetCreateFunction(() => new KeyDownEvent());
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x00036A84 File Offset: 0x00034C84
		internal void GetEquivalentImguiEvent(Event outImguiEvent)
		{
			bool flag = base.imguiEvent != null;
			if (flag)
			{
				outImguiEvent.CopyFrom(base.imguiEvent);
			}
			else
			{
				outImguiEvent.type = EventType.KeyDown;
				outImguiEvent.modifiers = base.modifiers;
				outImguiEvent.character = base.character;
				outImguiEvent.keyCode = base.keyCode;
			}
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x00036AE4 File Offset: 0x00034CE4
		protected internal override void PostDispatch(IPanel panel)
		{
			base.PostDispatch(panel);
			bool flag;
			if (panel.contextType == ContextType.Editor)
			{
				Event imguiEvent = base.imguiEvent;
				flag = (imguiEvent == null || imguiEvent.type != EventType.Used);
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			if (flag2)
			{
				this.SendEquivalentNavigationEventIfAny(panel);
			}
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x00036B30 File Offset: 0x00034D30
		private void SendEquivalentNavigationEventIfAny(IPanel panel)
		{
			bool flag = base.character == '\n' || base.character == '\u0003' || base.character == '\n' || base.character == ' ';
			if (flag)
			{
				using (NavigationSubmitEvent pooled = NavigationEventBase<NavigationSubmitEvent>.GetPooled(NavigationDeviceType.Keyboard, base.modifiers))
				{
					pooled.target = base.leafTarget;
					panel.visualTree.SendEvent(pooled);
				}
			}
			else
			{
				bool flag2 = base.keyCode == KeyCode.Escape;
				if (flag2)
				{
					using (NavigationCancelEvent pooled2 = NavigationEventBase<NavigationCancelEvent>.GetPooled(NavigationDeviceType.Keyboard, base.modifiers))
					{
						pooled2.target = base.leafTarget;
						panel.visualTree.SendEvent(pooled2);
					}
				}
				else
				{
					bool flag3 = this.ShouldSendNavigationMoveEvent();
					if (flag3)
					{
						using (NavigationMoveEvent pooled3 = NavigationMoveEvent.GetPooled(base.shiftKey ? NavigationMoveEvent.Direction.Previous : NavigationMoveEvent.Direction.Next, NavigationDeviceType.Keyboard, base.modifiers))
						{
							pooled3.target = base.leafTarget;
							panel.visualTree.SendEvent(pooled3);
						}
					}
					else
					{
						bool flag4 = base.keyCode == KeyCode.RightArrow || base.keyCode == KeyCode.LeftArrow || base.keyCode == KeyCode.UpArrow || base.keyCode == KeyCode.DownArrow;
						if (flag4)
						{
							Vector2 moveVector = (base.keyCode == KeyCode.RightArrow) ? Vector2.right : ((base.keyCode == KeyCode.LeftArrow) ? Vector2.left : ((base.keyCode == KeyCode.UpArrow) ? Vector2.up : Vector2.down));
							using (NavigationMoveEvent pooled4 = NavigationMoveEvent.GetPooled(moveVector, NavigationDeviceType.Keyboard, base.modifiers))
							{
								pooled4.target = base.leafTarget;
								panel.visualTree.SendEvent(pooled4);
							}
						}
					}
				}
			}
		}
	}
}
