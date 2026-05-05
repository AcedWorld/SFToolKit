using System;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004CF RID: 1231
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		// Token: 0x17000B35 RID: 2869
		// (get) Token: 0x06003183 RID: 12675 RVA: 0x00025F67 File Offset: 0x00024167
		public uint lastProcessedEventId
		{
			get
			{
				return this.BeNxFXORdDxBuhtTeThRHePDHKbT;
			}
		}

		// Token: 0x17000B36 RID: 2870
		// (get) Token: 0x06003184 RID: 12676 RVA: 0x000AC5D0 File Offset: 0x000AA7D0
		public int count
		{
			get
			{
				object obj = this.dCAkhEcvXmABVZdYaCALYvjVLBJB;
				int count;
				lock (obj)
				{
					count = this.xVuEZKvQokIIiYmuGCvZVppCTqMH.Count;
				}
				return count;
			}
		}

		// Token: 0x06003185 RID: 12677 RVA: 0x000AC618 File Offset: 0x000AA818
		public DualThreadLowLevelInputEventQueue(int A_1, int A_2, int A_3, int A_4)
		{
			this.xVuEZKvQokIIiYmuGCvZVppCTqMH = new LowLevelInputEventQueue(A_1, A_2, A_3, A_4);
			this.LeQIBbqyMnvOzXOvWbkWgTJEeJIFb = new LowLevelInputEventQueue(A_1, A_2, A_3, A_4);
			this.dCAkhEcvXmABVZdYaCALYvjVLBJB = new object();
			this.MGZwNoQeIJNfsDNXCVtBiFLyTJVX = new DualThreadLowLevelInputEventQueue.IDOuzyBvOXcogbnhlwfbpptlJoKp(this.dCAkhEcvXmABVZdYaCALYvjVLBJB);
		}

		// Token: 0x06003186 RID: 12678 RVA: 0x00025F6F File Offset: 0x0002416F
		public DualThreadLowLevelInputEventQueue.INewEventWrapper T_CreateEvent()
		{
			this.MGZwNoQeIJNfsDNXCVtBiFLyTJVX.Lock();
			this.MGZwNoQeIJNfsDNXCVtBiFLyTJVX.item = this.LeQIBbqyMnvOzXOvWbkWgTJEeJIFb.CreateEvent();
			return this.MGZwNoQeIJNfsDNXCVtBiFLyTJVX;
		}

		// Token: 0x06003187 RID: 12679 RVA: 0x000AC668 File Offset: 0x000AA868
		public void Update()
		{
			object obj = this.dCAkhEcvXmABVZdYaCALYvjVLBJB;
			lock (obj)
			{
				this.xVuEZKvQokIIiYmuGCvZVppCTqMH.CopyNewEventsFrom(this.LeQIBbqyMnvOzXOvWbkWgTJEeJIFb);
			}
		}

		// Token: 0x06003188 RID: 12680 RVA: 0x000AC6B4 File Offset: 0x000AA8B4
		public void Clear()
		{
			object obj = this.dCAkhEcvXmABVZdYaCALYvjVLBJB;
			lock (obj)
			{
				this.StopProcessingEvents();
				this.xVuEZKvQokIIiYmuGCvZVppCTqMH.Clear();
				this.LeQIBbqyMnvOzXOvWbkWgTJEeJIFb.Clear();
			}
		}

		// Token: 0x06003189 RID: 12681 RVA: 0x000AC70C File Offset: 0x000AA90C
		public bool ProcessNewEvents()
		{
			if (this.ELkVCUPJIWEetBGiwTXNAWjarVNy == 0)
			{
				this.Update();
				int num = this.xVuEZKvQokIIiYmuGCvZVppCTqMH.FindNextIndex(this.BeNxFXORdDxBuhtTeThRHePDHKbT);
				if (num < 0)
				{
					this.currentEvent = default(LowLevelInputEvent);
					return false;
				}
				this.ELkVCUPJIWEetBGiwTXNAWjarVNy = num;
				this.BSsUvILkACsYRaSxFFOpohjjlZRQ = true;
				this.OQrbmmIfbchNEDxAtkocIASvtMCFb = this.xVuEZKvQokIIiYmuGCvZVppCTqMH.Count;
			}
			if (this.ELkVCUPJIWEetBGiwTXNAWjarVNy >= this.OQrbmmIfbchNEDxAtkocIASvtMCFb)
			{
				this.currentEvent = default(LowLevelInputEvent);
				this.BSsUvILkACsYRaSxFFOpohjjlZRQ = false;
				this.ELkVCUPJIWEetBGiwTXNAWjarVNy = 0;
				return false;
			}
			if (this.xVuEZKvQokIIiYmuGCvZVppCTqMH.TryGetNext(this.ELkVCUPJIWEetBGiwTXNAWjarVNy, out this.currentEvent))
			{
				this.BeNxFXORdDxBuhtTeThRHePDHKbT = this.currentEvent.GetId();
				this.ELkVCUPJIWEetBGiwTXNAWjarVNy++;
				return true;
			}
			this.currentEvent = default(LowLevelInputEvent);
			this.BSsUvILkACsYRaSxFFOpohjjlZRQ = false;
			this.ELkVCUPJIWEetBGiwTXNAWjarVNy = 0;
			return false;
		}

		// Token: 0x0600318A RID: 12682 RVA: 0x00025F98 File Offset: 0x00024198
		public void StopProcessingEvents()
		{
			this.BSsUvILkACsYRaSxFFOpohjjlZRQ = false;
			this.ELkVCUPJIWEetBGiwTXNAWjarVNy = 0;
		}

		// Token: 0x0600318B RID: 12683 RVA: 0x000AC7EC File Offset: 0x000AA9EC
		public void ImportAll(DualThreadLowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (other == this)
			{
				return;
			}
			object obj = this.dCAkhEcvXmABVZdYaCALYvjVLBJB;
			lock (obj)
			{
				object obj2 = other.dCAkhEcvXmABVZdYaCALYvjVLBJB;
				lock (obj2)
				{
					this.xVuEZKvQokIIiYmuGCvZVppCTqMH.CopyAllFrom(other.xVuEZKvQokIIiYmuGCvZVppCTqMH);
					this.LeQIBbqyMnvOzXOvWbkWgTJEeJIFb.CopyAllFrom(other.LeQIBbqyMnvOzXOvWbkWgTJEeJIFb);
					this.BeNxFXORdDxBuhtTeThRHePDHKbT = other.BeNxFXORdDxBuhtTeThRHePDHKbT;
					this.BSsUvILkACsYRaSxFFOpohjjlZRQ = other.BSsUvILkACsYRaSxFFOpohjjlZRQ;
					this.OQrbmmIfbchNEDxAtkocIASvtMCFb = other.OQrbmmIfbchNEDxAtkocIASvtMCFb;
					this.ELkVCUPJIWEetBGiwTXNAWjarVNy = other.ELkVCUPJIWEetBGiwTXNAWjarVNy;
				}
			}
		}

		// Token: 0x0600318C RID: 12684 RVA: 0x00025FA8 File Offset: 0x000241A8
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600318D RID: 12685 RVA: 0x000AC8B4 File Offset: 0x000AAAB4
		~DualThreadLowLevelInputEventQueue()
		{
			this.Dispose(false);
		}

		// Token: 0x0600318E RID: 12686 RVA: 0x000AC8E4 File Offset: 0x000AAAE4
		protected void Dispose(bool disposing)
		{
			if (this.aeDOAbZznNgDpdJMNYNpxgwzbLaP)
			{
				return;
			}
			if (disposing)
			{
				object obj = this.dCAkhEcvXmABVZdYaCALYvjVLBJB;
				lock (obj)
				{
					this.xVuEZKvQokIIiYmuGCvZVppCTqMH.Dispose();
					this.LeQIBbqyMnvOzXOvWbkWgTJEeJIFb.Dispose();
				}
			}
			this.aeDOAbZznNgDpdJMNYNpxgwzbLaP = true;
		}

		// Token: 0x04001B2C RID: 6956
		private readonly LowLevelInputEventQueue xVuEZKvQokIIiYmuGCvZVppCTqMH;

		// Token: 0x04001B2D RID: 6957
		private readonly LowLevelInputEventQueue LeQIBbqyMnvOzXOvWbkWgTJEeJIFb;

		// Token: 0x04001B2E RID: 6958
		private readonly object dCAkhEcvXmABVZdYaCALYvjVLBJB;

		// Token: 0x04001B2F RID: 6959
		private uint BeNxFXORdDxBuhtTeThRHePDHKbT;

		// Token: 0x04001B30 RID: 6960
		private bool BSsUvILkACsYRaSxFFOpohjjlZRQ;

		// Token: 0x04001B31 RID: 6961
		private int OQrbmmIfbchNEDxAtkocIASvtMCFb;

		// Token: 0x04001B32 RID: 6962
		private int ELkVCUPJIWEetBGiwTXNAWjarVNy;

		// Token: 0x04001B33 RID: 6963
		private DualThreadLowLevelInputEventQueue.IDOuzyBvOXcogbnhlwfbpptlJoKp MGZwNoQeIJNfsDNXCVtBiFLyTJVX;

		// Token: 0x04001B34 RID: 6964
		public LowLevelInputEvent currentEvent;

		// Token: 0x04001B35 RID: 6965
		private bool aeDOAbZznNgDpdJMNYNpxgwzbLaP;

		// Token: 0x020004D0 RID: 1232
		private class IDOuzyBvOXcogbnhlwfbpptlJoKp : LockedObject<LowLevelInputEvent>, DualThreadLowLevelInputEventQueue.INewEventWrapper, IDisposable
		{
			// Token: 0x17000B37 RID: 2871
			// (get) Token: 0x0600318F RID: 12687 RVA: 0x00025FB7 File Offset: 0x000241B7
			// (set) Token: 0x06003190 RID: 12688 RVA: 0x00025FBF File Offset: 0x000241BF
			public LowLevelInputEvent Event
			{
				get
				{
					return this.item;
				}
				set
				{
					this.item = value;
				}
			}

			// Token: 0x06003191 RID: 12689 RVA: 0x00025FC8 File Offset: 0x000241C8
			public IDOuzyBvOXcogbnhlwfbpptlJoKp(object A_1) : base(A_1)
			{
			}
		}

		// Token: 0x020004D1 RID: 1233
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public interface INewEventWrapper : IDisposable
		{
			// Token: 0x17000B38 RID: 2872
			// (get) Token: 0x06003192 RID: 12690
			// (set) Token: 0x06003193 RID: 12691
			LowLevelInputEvent Event { get; set; }
		}
	}
}
