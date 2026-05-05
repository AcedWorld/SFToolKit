using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004C8 RID: 1224
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LockedObject<T> : IDisposable
	{
		// Token: 0x06003137 RID: 12599 RVA: 0x00025BBC File Offset: 0x00023DBC
		public LockedObject()
		{
			this.zHZDHNYkMlJzTxrKBXtifYCBIHfA = new object();
		}

		// Token: 0x06003138 RID: 12600 RVA: 0x00025BCF File Offset: 0x00023DCF
		public LockedObject(object A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			this.zHZDHNYkMlJzTxrKBXtifYCBIHfA = A_1;
		}

		// Token: 0x06003139 RID: 12601 RVA: 0x00025BEC File Offset: 0x00023DEC
		public void Lock()
		{
			if (this.KngyDOLjJzFoGgwAYrOdFPyYMkNc)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(this.zHZDHNYkMlJzTxrKBXtifYCBIHfA);
			this.KngyDOLjJzFoGgwAYrOdFPyYMkNc = true;
		}

		// Token: 0x0600313A RID: 12602 RVA: 0x00025C13 File Offset: 0x00023E13
		public void Unlock()
		{
			if (!this.KngyDOLjJzFoGgwAYrOdFPyYMkNc)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(this.zHZDHNYkMlJzTxrKBXtifYCBIHfA);
			this.KngyDOLjJzFoGgwAYrOdFPyYMkNc = false;
		}

		// Token: 0x0600313B RID: 12603 RVA: 0x00025C3A File Offset: 0x00023E3A
		void IDisposable.Dispose()
		{
			this.Unlock();
		}

		// Token: 0x04001AF8 RID: 6904
		public T item;

		// Token: 0x04001AF9 RID: 6905
		private readonly object zHZDHNYkMlJzTxrKBXtifYCBIHfA;

		// Token: 0x04001AFA RID: 6906
		private bool KngyDOLjJzFoGgwAYrOdFPyYMkNc;
	}
}
