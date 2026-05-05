using System;

namespace Rewired.Utils
{
	// Token: 0x02000483 RID: 1155
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SafeAction : SafeDelegate<Action>
	{
		// Token: 0x06002DA6 RID: 11686 RVA: 0x00023272 File Offset: 0x00021472
		public SafeAction()
		{
		}

		// Token: 0x06002DA7 RID: 11687 RVA: 0x0002327A File Offset: 0x0002147A
		public SafeAction(Action<Exception> A_1) : base(A_1)
		{
		}

		// Token: 0x06002DA8 RID: 11688 RVA: 0x00023283 File Offset: 0x00021483
		private SafeAction(SafeAction A_1) : base(A_1)
		{
		}

		// Token: 0x06002DA9 RID: 11689 RVA: 0x000A06FC File Offset: 0x0009E8FC
		public void Invoke()
		{
			try
			{
				base.Invoke(SafeAction.invokeDelegate);
			}
			catch (Exception ex)
			{
				string str = "Error invoking SafeAction base class.\n";
				Exception ex2 = ex;
				Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x06002DAA RID: 11690 RVA: 0x0002328C File Offset: 0x0002148C
		public override object Clone()
		{
			return new SafeAction(this);
		}

		// Token: 0x17000AE6 RID: 2790
		// (get) Token: 0x06002DAB RID: 11691 RVA: 0x00023294 File Offset: 0x00021494
		private static Action<object, Action> invokeDelegate
		{
			get
			{
				Action<object, Action> result;
				if ((result = SafeAction.mSMLsVOPGZXeiFKuaYpkIjIkRykK) == null)
				{
					result = (SafeAction.mSMLsVOPGZXeiFKuaYpkIjIkRykK = new Action<object, Action>(SafeAction.WmlwvGJKbVHcfjhElkVsgcNmiZOoA));
				}
				return result;
			}
		}

		// Token: 0x06002DAC RID: 11692 RVA: 0x000232B1 File Offset: 0x000214B1
		private static void WmlwvGJKbVHcfjhElkVsgcNmiZOoA(object A_0, Action A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			A_1();
		}

		// Token: 0x06002DAD RID: 11693 RVA: 0x000232BD File Offset: 0x000214BD
		public static SafeAction operator +(SafeAction eventList, Action listener)
		{
			if (eventList == null)
			{
				eventList = new SafeAction();
			}
			eventList.AddDelegate(listener);
			return eventList;
		}

		// Token: 0x06002DAE RID: 11694 RVA: 0x000232D1 File Offset: 0x000214D1
		public static SafeAction operator -(SafeAction eventList, Action listener)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(listener);
			return eventList;
		}

		// Token: 0x06002DAF RID: 11695 RVA: 0x000232E0 File Offset: 0x000214E0
		public static implicit operator Action(SafeAction obj)
		{
			if (obj == null)
			{
				return null;
			}
			return obj.GetCombinedDelegate();
		}

		// Token: 0x06002DB0 RID: 11696 RVA: 0x000232ED File Offset: 0x000214ED
		public static implicit operator SafeAction(Action obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafeAction safeAction = new SafeAction();
			safeAction.AddDelegate(obj);
			return safeAction;
		}

		// Token: 0x0400199B RID: 6555
		private static Action<object, Action> mSMLsVOPGZXeiFKuaYpkIjIkRykK;
	}
}
