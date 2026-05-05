using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000202 RID: 514
	public class NavigationMoveEvent : NavigationEventBase<NavigationMoveEvent>
	{
		// Token: 0x06000F24 RID: 3876 RVA: 0x00038B43 File Offset: 0x00036D43
		static NavigationMoveEvent()
		{
			EventBase<NavigationMoveEvent>.SetCreateFunction(() => new NavigationMoveEvent());
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x00038B5C File Offset: 0x00036D5C
		internal static NavigationMoveEvent.Direction DetermineMoveDirection(float x, float y, float deadZone = 0.6f)
		{
			bool flag = new Vector2(x, y).sqrMagnitude < deadZone * deadZone;
			NavigationMoveEvent.Direction result;
			if (flag)
			{
				result = NavigationMoveEvent.Direction.None;
			}
			else
			{
				bool flag2 = Mathf.Abs(x) > Mathf.Abs(y);
				if (flag2)
				{
					bool flag3 = x > 0f;
					if (flag3)
					{
						result = NavigationMoveEvent.Direction.Right;
					}
					else
					{
						result = NavigationMoveEvent.Direction.Left;
					}
				}
				else
				{
					bool flag4 = y > 0f;
					if (flag4)
					{
						result = NavigationMoveEvent.Direction.Up;
					}
					else
					{
						result = NavigationMoveEvent.Direction.Down;
					}
				}
			}
			return result;
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000F26 RID: 3878 RVA: 0x00038BC7 File Offset: 0x00036DC7
		// (set) Token: 0x06000F27 RID: 3879 RVA: 0x00038BCF File Offset: 0x00036DCF
		public NavigationMoveEvent.Direction direction { get; private set; }

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000F28 RID: 3880 RVA: 0x00038BD8 File Offset: 0x00036DD8
		// (set) Token: 0x06000F29 RID: 3881 RVA: 0x00038BE0 File Offset: 0x00036DE0
		public Vector2 move { get; private set; }

		// Token: 0x06000F2A RID: 3882 RVA: 0x00038BEC File Offset: 0x00036DEC
		public static NavigationMoveEvent GetPooled(Vector2 moveVector, EventModifiers modifiers = EventModifiers.None)
		{
			NavigationMoveEvent pooled = NavigationEventBase<NavigationMoveEvent>.GetPooled(NavigationDeviceType.Unknown, modifiers);
			pooled.direction = NavigationMoveEvent.DetermineMoveDirection(moveVector.x, moveVector.y, 0.6f);
			pooled.move = moveVector;
			return pooled;
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x00038C2C File Offset: 0x00036E2C
		internal static NavigationMoveEvent GetPooled(Vector2 moveVector, NavigationDeviceType deviceType, EventModifiers modifiers = EventModifiers.None)
		{
			NavigationMoveEvent pooled = NavigationEventBase<NavigationMoveEvent>.GetPooled(deviceType, modifiers);
			pooled.direction = NavigationMoveEvent.DetermineMoveDirection(moveVector.x, moveVector.y, 0.6f);
			pooled.move = moveVector;
			return pooled;
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x00038C6C File Offset: 0x00036E6C
		public static NavigationMoveEvent GetPooled(NavigationMoveEvent.Direction direction, EventModifiers modifiers = EventModifiers.None)
		{
			NavigationMoveEvent pooled = NavigationEventBase<NavigationMoveEvent>.GetPooled(NavigationDeviceType.Unknown, modifiers);
			pooled.direction = direction;
			pooled.move = Vector2.zero;
			return pooled;
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x00038C9C File Offset: 0x00036E9C
		internal static NavigationMoveEvent GetPooled(NavigationMoveEvent.Direction direction, NavigationDeviceType deviceType, EventModifiers modifiers = EventModifiers.None)
		{
			NavigationMoveEvent pooled = NavigationEventBase<NavigationMoveEvent>.GetPooled(deviceType, modifiers);
			pooled.direction = direction;
			pooled.move = Vector2.zero;
			return pooled;
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x00038CCB File Offset: 0x00036ECB
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x00038CDC File Offset: 0x00036EDC
		public NavigationMoveEvent()
		{
			this.LocalInit();
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x00038CED File Offset: 0x00036EED
		private void LocalInit()
		{
			this.direction = NavigationMoveEvent.Direction.None;
			this.move = Vector2.zero;
		}

		// Token: 0x02000203 RID: 515
		public enum Direction
		{
			// Token: 0x040006DB RID: 1755
			None,
			// Token: 0x040006DC RID: 1756
			Left,
			// Token: 0x040006DD RID: 1757
			Up,
			// Token: 0x040006DE RID: 1758
			Right,
			// Token: 0x040006DF RID: 1759
			Down,
			// Token: 0x040006E0 RID: 1760
			Next,
			// Token: 0x040006E1 RID: 1761
			Previous
		}
	}
}
