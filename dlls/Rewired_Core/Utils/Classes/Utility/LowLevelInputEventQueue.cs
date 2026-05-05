using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004D2 RID: 1234
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		// Token: 0x17000B39 RID: 2873
		// (get) Token: 0x06003194 RID: 12692 RVA: 0x00025FD1 File Offset: 0x000241D1
		public int Count
		{
			get
			{
				return this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.BytesInBuffer / this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb;
			}
		}

		// Token: 0x17000B3A RID: 2874
		// (get) Token: 0x06003195 RID: 12693 RVA: 0x00025FE5 File Offset: 0x000241E5
		public int Capacity
		{
			get
			{
				return this.vMFFQuvrWROFGGTguQMMirLuLgrI;
			}
		}

		// Token: 0x17000B3B RID: 2875
		public LowLevelInputEvent this[int index]
		{
			get
			{
				return new LowLevelInputEvent(this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.GetPointerFromReadPosition(index * this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb), this.LSbXgmHSfvGWmVWagpqjfIJxmEvX, this.InRfwDaTwTdLkqEwhRFyRAlXXtVsA, this.GdAbzOzoCKSCXhjttiBzFIFsKak);
			}
		}

		// Token: 0x06003197 RID: 12695 RVA: 0x000AC948 File Offset: 0x000AAB48
		public LowLevelInputEventQueue(int A_1, int A_2, int A_3, int A_4)
		{
			this.vMFFQuvrWROFGGTguQMMirLuLgrI = A_1;
			this.LSbXgmHSfvGWmVWagpqjfIJxmEvX = A_2;
			this.InRfwDaTwTdLkqEwhRFyRAlXXtVsA = A_3;
			this.GdAbzOzoCKSCXhjttiBzFIFsKak = A_4;
			this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb = LowLevelInputEvent.GetReportSize(A_2, A_3, A_4);
			this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB = new NativeRingBuffer(this.vMFFQuvrWROFGGTguQMMirLuLgrI * this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb);
			this.ypnzrijySrJhbxmbwUGmTzlySaxe = new LowLevelInputEvent(IntPtr.Zero, this.LSbXgmHSfvGWmVWagpqjfIJxmEvX, this.InRfwDaTwTdLkqEwhRFyRAlXXtVsA, A_4);
		}

		// Token: 0x06003198 RID: 12696 RVA: 0x000AC9C0 File Offset: 0x000AABC0
		public LowLevelInputEvent CreateEvent()
		{
			uint num;
			IntPtr intPtr = this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.Allocate(this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb, false, out num);
			LowLevelInputEvent result = new LowLevelInputEvent(intPtr, this.LSbXgmHSfvGWmVWagpqjfIJxmEvX, this.InRfwDaTwTdLkqEwhRFyRAlXXtVsA, this.GdAbzOzoCKSCXhjttiBzFIFsKak);
			result.SetId(this.IibQzChvUJsFlBJBcucfVHPvvtmk = MiscTools.Tick(this.IibQzChvUJsFlBJBcucfVHPvvtmk));
			return result;
		}

		// Token: 0x06003199 RID: 12697 RVA: 0x000ACA18 File Offset: 0x000AAC18
		public int FindNextIndex(uint id)
		{
			int num = this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.BytesInBuffer / this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb;
			if (num == 0)
			{
				return -1;
			}
			this.ypnzrijySrJhbxmbwUGmTzlySaxe._buffer = this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.GetPointerFromReadPosition(0);
			uint num2 = this.ypnzrijySrJhbxmbwUGmTzlySaxe.GetId();
			int num3 = 0;
			if (MiscTools.IsTickNewer(id, num2))
			{
				num3 = (int)MiscTools.TickDifference(id, num2) + 1;
				num2 = MiscTools.Tick(id);
			}
			for (int i = num3; i < num; i++)
			{
				if (MiscTools.IsTickNewer(num2, id))
				{
					return i;
				}
				num2 = MiscTools.Tick(num2);
			}
			return -1;
		}

		// Token: 0x0600319A RID: 12698 RVA: 0x000ACAA0 File Offset: 0x000AACA0
		public bool TryGetNext(int index, out LowLevelInputEvent @event)
		{
			if (index < 0 || index >= this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.BytesInBuffer / this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.GetPointerFromReadPosition(index * this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb), this.LSbXgmHSfvGWmVWagpqjfIJxmEvX, this.InRfwDaTwTdLkqEwhRFyRAlXXtVsA, this.GdAbzOzoCKSCXhjttiBzFIFsKak);
			return true;
		}

		// Token: 0x0600319B RID: 12699 RVA: 0x00026019 File Offset: 0x00024219
		public void Clear()
		{
			this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.Reset();
		}

		// Token: 0x0600319C RID: 12700 RVA: 0x00026026 File Offset: 0x00024226
		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.CopyFrom(other.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB);
			this.IibQzChvUJsFlBJBcucfVHPvvtmk = other.IibQzChvUJsFlBJBcucfVHPvvtmk;
		}

		// Token: 0x0600319D RID: 12701 RVA: 0x000ACB00 File Offset: 0x000AAD00
		public void CopyNewEventsFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			int count = this.Count;
			int count2 = other.Count;
			if (count2 == 0)
			{
				return;
			}
			if (count == 0)
			{
				this.CopyAllFrom(other);
				return;
			}
			uint id = new LowLevelInputEvent(this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.GetPointerFromReadPosition((count - 1) * this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb), this.LSbXgmHSfvGWmVWagpqjfIJxmEvX, this.InRfwDaTwTdLkqEwhRFyRAlXXtVsA, this.GdAbzOzoCKSCXhjttiBzFIFsKak).GetId();
			int num = other.FindNextIndex(id);
			if (num < 0)
			{
				return;
			}
			int num2 = count2 - num;
			if (num2 == 0)
			{
				return;
			}
			for (int i = 0; i < num2; i++)
			{
				uint num3;
				IntPtr buffer = this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.Allocate(this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb, false, out num3);
				other.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.RandomRead(buffer, this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb, this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb, other.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.GetOffsetFromReadPosition((num + i) * this.rVdDueAjCDOqbKXzjoSdSnRaNGQfb));
			}
			this.IibQzChvUJsFlBJBcucfVHPvvtmk = other.IibQzChvUJsFlBJBcucfVHPvvtmk;
		}

		// Token: 0x0600319E RID: 12702 RVA: 0x00026053 File Offset: 0x00024253
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600319F RID: 12703 RVA: 0x000ACBE8 File Offset: 0x000AADE8
		~LowLevelInputEventQueue()
		{
			this.Dispose(false);
		}

		// Token: 0x060031A0 RID: 12704 RVA: 0x00026062 File Offset: 0x00024262
		protected void Dispose(bool disposing)
		{
			if (this.kOSCiuVBwsBRarFhGPkYjOkNjSOGA)
			{
				return;
			}
			if (disposing)
			{
				this.CnkDtBJhWMAwpMHcGpkUhtyjbHXDB.Dispose();
			}
			this.kOSCiuVBwsBRarFhGPkYjOkNjSOGA = true;
		}

		// Token: 0x04001B36 RID: 6966
		private LowLevelInputEvent ypnzrijySrJhbxmbwUGmTzlySaxe;

		// Token: 0x04001B37 RID: 6967
		private readonly NativeRingBuffer CnkDtBJhWMAwpMHcGpkUhtyjbHXDB;

		// Token: 0x04001B38 RID: 6968
		private readonly int LSbXgmHSfvGWmVWagpqjfIJxmEvX;

		// Token: 0x04001B39 RID: 6969
		private readonly int InRfwDaTwTdLkqEwhRFyRAlXXtVsA;

		// Token: 0x04001B3A RID: 6970
		private readonly int GdAbzOzoCKSCXhjttiBzFIFsKak;

		// Token: 0x04001B3B RID: 6971
		private readonly int rVdDueAjCDOqbKXzjoSdSnRaNGQfb;

		// Token: 0x04001B3C RID: 6972
		private readonly int vMFFQuvrWROFGGTguQMMirLuLgrI;

		// Token: 0x04001B3D RID: 6973
		private uint IibQzChvUJsFlBJBcucfVHPvvtmk;

		// Token: 0x04001B3E RID: 6974
		private bool kOSCiuVBwsBRarFhGPkYjOkNjSOGA;
	}
}
