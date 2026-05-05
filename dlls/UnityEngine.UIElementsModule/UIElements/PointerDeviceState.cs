using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000210 RID: 528
	internal static class PointerDeviceState
	{
		// Token: 0x06000F53 RID: 3923 RVA: 0x00039028 File Offset: 0x00037228
		internal static void Reset()
		{
			for (int i = 0; i < PointerId.maxPointers; i++)
			{
				PointerDeviceState.s_PlayerPointerLocations[i].SetLocation(Vector2.zero, null);
				PointerDeviceState.s_PressedButtons[i] = 0;
				PointerDeviceState.s_PlayerPanelWithSoftPointerCapture[i] = null;
			}
		}

		// Token: 0x06000F54 RID: 3924 RVA: 0x00039074 File Offset: 0x00037274
		internal static void RemovePanelData(IPanel panel)
		{
			for (int i = 0; i < PointerId.maxPointers; i++)
			{
				bool flag = PointerDeviceState.s_PlayerPointerLocations[i].Panel == panel;
				if (flag)
				{
					PointerDeviceState.s_PlayerPointerLocations[i].SetLocation(Vector2.zero, null);
				}
				bool flag2 = PointerDeviceState.s_PlayerPanelWithSoftPointerCapture[i] == panel;
				if (flag2)
				{
					PointerDeviceState.s_PlayerPanelWithSoftPointerCapture[i] = null;
				}
			}
		}

		// Token: 0x06000F55 RID: 3925 RVA: 0x000390DC File Offset: 0x000372DC
		public static void SavePointerPosition(int pointerId, Vector2 position, IPanel panel, ContextType contextType)
		{
			if (contextType > ContextType.Editor)
			{
			}
			PointerDeviceState.s_PlayerPointerLocations[pointerId].SetLocation(position, panel);
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x00039109 File Offset: 0x00037309
		public static void PressButton(int pointerId, int buttonId)
		{
			Debug.Assert(buttonId >= 0);
			Debug.Assert(buttonId < 32);
			PointerDeviceState.s_PressedButtons[pointerId] |= 1 << buttonId;
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x00039139 File Offset: 0x00037339
		public static void ReleaseButton(int pointerId, int buttonId)
		{
			Debug.Assert(buttonId >= 0);
			Debug.Assert(buttonId < 32);
			PointerDeviceState.s_PressedButtons[pointerId] &= ~(1 << buttonId);
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x0003916A File Offset: 0x0003736A
		public static void ReleaseAllButtons(int pointerId)
		{
			PointerDeviceState.s_PressedButtons[pointerId] = 0;
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x00039178 File Offset: 0x00037378
		public static Vector2 GetPointerPosition(int pointerId, ContextType contextType)
		{
			if (contextType > ContextType.Editor)
			{
			}
			return PointerDeviceState.s_PlayerPointerLocations[pointerId].Position;
		}

		// Token: 0x06000F5A RID: 3930 RVA: 0x000391A4 File Offset: 0x000373A4
		public static IPanel GetPanel(int pointerId, ContextType contextType)
		{
			if (contextType > ContextType.Editor)
			{
			}
			return PointerDeviceState.s_PlayerPointerLocations[pointerId].Panel;
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x000391D0 File Offset: 0x000373D0
		private static bool HasFlagFast(PointerDeviceState.LocationFlag flagSet, PointerDeviceState.LocationFlag flag)
		{
			return (flagSet & flag) == flag;
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x000391E8 File Offset: 0x000373E8
		public static bool HasLocationFlag(int pointerId, ContextType contextType, PointerDeviceState.LocationFlag flag)
		{
			if (contextType > ContextType.Editor)
			{
			}
			return PointerDeviceState.HasFlagFast(PointerDeviceState.s_PlayerPointerLocations[pointerId].Flags, flag);
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x0003921C File Offset: 0x0003741C
		public static int GetPressedButtons(int pointerId)
		{
			return PointerDeviceState.s_PressedButtons[pointerId];
		}

		// Token: 0x06000F5E RID: 3934 RVA: 0x00039238 File Offset: 0x00037438
		internal static bool HasAdditionalPressedButtons(int pointerId, int exceptButtonId)
		{
			return (PointerDeviceState.s_PressedButtons[pointerId] & ~(1 << exceptButtonId)) != 0;
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x0003925C File Offset: 0x0003745C
		internal static void SetPlayerPanelWithSoftPointerCapture(int pointerId, IPanel panel)
		{
			PointerDeviceState.s_PlayerPanelWithSoftPointerCapture[pointerId] = panel;
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x00039268 File Offset: 0x00037468
		internal static IPanel GetPlayerPanelWithSoftPointerCapture(int pointerId)
		{
			return PointerDeviceState.s_PlayerPanelWithSoftPointerCapture[pointerId];
		}

		// Token: 0x040006E9 RID: 1769
		private static PointerDeviceState.PointerLocation[] s_PlayerPointerLocations = new PointerDeviceState.PointerLocation[PointerId.maxPointers];

		// Token: 0x040006EA RID: 1770
		private static int[] s_PressedButtons = new int[PointerId.maxPointers];

		// Token: 0x040006EB RID: 1771
		private static readonly IPanel[] s_PlayerPanelWithSoftPointerCapture = new IPanel[PointerId.maxPointers];

		// Token: 0x02000211 RID: 529
		[Flags]
		internal enum LocationFlag
		{
			// Token: 0x040006ED RID: 1773
			None = 0,
			// Token: 0x040006EE RID: 1774
			OutsidePanel = 1
		}

		// Token: 0x02000212 RID: 530
		private struct PointerLocation
		{
			// Token: 0x1700032D RID: 813
			// (get) Token: 0x06000F62 RID: 3938 RVA: 0x000392B0 File Offset: 0x000374B0
			// (set) Token: 0x06000F63 RID: 3939 RVA: 0x000392B8 File Offset: 0x000374B8
			internal Vector2 Position { readonly get; private set; }

			// Token: 0x1700032E RID: 814
			// (get) Token: 0x06000F64 RID: 3940 RVA: 0x000392C1 File Offset: 0x000374C1
			// (set) Token: 0x06000F65 RID: 3941 RVA: 0x000392C9 File Offset: 0x000374C9
			internal IPanel Panel { readonly get; private set; }

			// Token: 0x1700032F RID: 815
			// (get) Token: 0x06000F66 RID: 3942 RVA: 0x000392D2 File Offset: 0x000374D2
			// (set) Token: 0x06000F67 RID: 3943 RVA: 0x000392DA File Offset: 0x000374DA
			internal PointerDeviceState.LocationFlag Flags { readonly get; private set; }

			// Token: 0x06000F68 RID: 3944 RVA: 0x000392E4 File Offset: 0x000374E4
			internal void SetLocation(Vector2 position, IPanel panel)
			{
				this.Position = position;
				this.Panel = panel;
				this.Flags = PointerDeviceState.LocationFlag.None;
				bool flag = panel == null || !panel.visualTree.layout.Contains(position);
				if (flag)
				{
					this.Flags |= PointerDeviceState.LocationFlag.OutsidePanel;
				}
			}
		}
	}
}
