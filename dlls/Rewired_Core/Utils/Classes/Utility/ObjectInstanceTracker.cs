using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004CD RID: 1229
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		// Token: 0x17000B34 RID: 2868
		// (get) Token: 0x06003176 RID: 12662 RVA: 0x00025EB8 File Offset: 0x000240B8
		public static ObjectInstanceTracker Default
		{
			get
			{
				ObjectInstanceTracker result;
				if ((result = ObjectInstanceTracker.dtGBSEqjFKiiHQfqKGahaCERyyfK) == null)
				{
					result = (ObjectInstanceTracker.dtGBSEqjFKiiHQfqKGahaCERyyfK = new ObjectInstanceTracker());
				}
				return result;
			}
		}

		// Token: 0x06003177 RID: 12663 RVA: 0x000AC3F0 File Offset: 0x000AA5F0
		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			this.HVcFzEkmAznWAZdNRlzqmQSpNDDl++;
			uint num = this.wzzGaJepILFpLYsknHyzCvpmaTCAA;
			this.wzzGaJepILFpLYsknHyzCvpmaTCAA = num + 1U;
			uint num2 = num;
			this.TTHNLfRGpralVERTvRwkBvUQCNgo.Add(num2, instance);
			return num2;
		}

		// Token: 0x06003178 RID: 12664 RVA: 0x000AC43C File Offset: 0x000AA63C
		public void Unregister(uint instanceId)
		{
			this.HVcFzEkmAznWAZdNRlzqmQSpNDDl--;
			if (this.HVcFzEkmAznWAZdNRlzqmQSpNDDl < 0)
			{
				this.HVcFzEkmAznWAZdNRlzqmQSpNDDl = 0;
			}
			object paKeIPIEkgchkVPaXkcBUbeYbLBh = this.PaKeIPIEkgchkVPaXkcBUbeYbLBh;
			lock (paKeIPIEkgchkVPaXkcBUbeYbLBh)
			{
				this.TTHNLfRGpralVERTvRwkBvUQCNgo.Remove(instanceId);
			}
		}

		// Token: 0x06003179 RID: 12665 RVA: 0x000AC4A4 File Offset: 0x000AA6A4
		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			object paKeIPIEkgchkVPaXkcBUbeYbLBh = this.PaKeIPIEkgchkVPaXkcBUbeYbLBh;
			bool result;
			lock (paKeIPIEkgchkVPaXkcBUbeYbLBh)
			{
				object obj;
				if (!this.TTHNLfRGpralVERTvRwkBvUQCNgo.TryGetValue(instanceId, out obj))
				{
					instance = default(T);
					result = false;
				}
				else if (obj is T)
				{
					instance = (T)((object)obj);
					result = true;
				}
				else
				{
					instance = default(T);
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600317A RID: 12666 RVA: 0x00025ECE File Offset: 0x000240CE
		public void Dispose()
		{
			this.mYQoMhpwjHouuQKVspMVywrQPYdb(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600317B RID: 12667 RVA: 0x00025EDD File Offset: 0x000240DD
		private void mYQoMhpwjHouuQKVspMVywrQPYdb(bool A_1)
		{
			if (this.nfAvECQOqOwSjcGadjctBbVmpatMA)
			{
				return;
			}
			if (this == ObjectInstanceTracker.dtGBSEqjFKiiHQfqKGahaCERyyfK)
			{
				ObjectInstanceTracker.dtGBSEqjFKiiHQfqKGahaCERyyfK = null;
			}
			this.nfAvECQOqOwSjcGadjctBbVmpatMA = true;
		}

		// Token: 0x0600317C RID: 12668 RVA: 0x000AC51C File Offset: 0x000AA71C
		~ObjectInstanceTracker()
		{
			this.mYQoMhpwjHouuQKVspMVywrQPYdb(false);
		}

		// Token: 0x04001B22 RID: 6946
		private static ObjectInstanceTracker dtGBSEqjFKiiHQfqKGahaCERyyfK;

		// Token: 0x04001B23 RID: 6947
		private readonly Dictionary<uint, object> TTHNLfRGpralVERTvRwkBvUQCNgo = new Dictionary<uint, object>();

		// Token: 0x04001B24 RID: 6948
		private readonly object PaKeIPIEkgchkVPaXkcBUbeYbLBh = new object();

		// Token: 0x04001B25 RID: 6949
		private uint wzzGaJepILFpLYsknHyzCvpmaTCAA;

		// Token: 0x04001B26 RID: 6950
		private int HVcFzEkmAznWAZdNRlzqmQSpNDDl;

		// Token: 0x04001B27 RID: 6951
		private bool nfAvECQOqOwSjcGadjctBbVmpatMA;

		// Token: 0x020004CE RID: 1230
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			// Token: 0x0600317E RID: 12670 RVA: 0x00025F1D File Offset: 0x0002411D
			public Wrapper(T A_1) : this(A_1, ObjectInstanceTracker.Default)
			{
			}

			// Token: 0x0600317F RID: 12671 RVA: 0x000AC54C File Offset: 0x000AA74C
			public Wrapper(T A_1, ObjectInstanceTracker A_2)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("instance");
				}
				if (A_2 == null)
				{
					throw new ArgumentNullException("tracker");
				}
				this.instance = A_1;
				this.DMQKVfhChMPMBPKjgVbXZoAMAwch = A_2;
				this.instanceId = A_2.Register(A_1);
			}

			// Token: 0x06003180 RID: 12672 RVA: 0x00025F2B File Offset: 0x0002412B
			public void Dispose()
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}

			// Token: 0x06003181 RID: 12673 RVA: 0x000AC5A0 File Offset: 0x000AA7A0
			~Wrapper()
			{
				this.Dispose(false);
			}

			// Token: 0x06003182 RID: 12674 RVA: 0x00025F3A File Offset: 0x0002413A
			protected virtual void Dispose(bool disposing)
			{
				if (this.PXRoZViHHQRglDIoJgoremDRLTQpA)
				{
					return;
				}
				if (this.DMQKVfhChMPMBPKjgVbXZoAMAwch != null)
				{
					this.DMQKVfhChMPMBPKjgVbXZoAMAwch.Unregister(this.instanceId);
				}
				this.PXRoZViHHQRglDIoJgoremDRLTQpA = true;
			}

			// Token: 0x04001B28 RID: 6952
			public readonly T instance;

			// Token: 0x04001B29 RID: 6953
			public readonly uint instanceId;

			// Token: 0x04001B2A RID: 6954
			private readonly ObjectInstanceTracker DMQKVfhChMPMBPKjgVbXZoAMAwch;

			// Token: 0x04001B2B RID: 6955
			private bool PXRoZViHHQRglDIoJgoremDRLTQpA;
		}
	}
}
