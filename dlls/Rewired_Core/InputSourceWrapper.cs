using System;
using System.Collections.Generic;
using Rewired.Interfaces;

namespace Rewired
{
	// Token: 0x02000030 RID: 48
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class InputSourceWrapper<T> : IInputSource, IDisposable
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x000039DE File Offset: 0x00001BDE
		public T source
		{
			get
			{
				return this.BHjdDLJLbcvxYjvtpxsdBMULluVl;
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x000039E6 File Offset: 0x00001BE6
		public InputSourceWrapper(T A_1)
		{
			this.BHjdDLJLbcvxYjvtpxsdBMULluVl = A_1;
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060001D7 RID: 471 RVA: 0x000039F5 File Offset: 0x00001BF5
		// (remove) Token: 0x060001D8 RID: 472 RVA: 0x000039F5 File Offset: 0x00001BF5
		public event Action DeviceChangedEvent
		{
			add
			{
				throw new NotImplementedException();
			}
			remove
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00002FF9 File Offset: 0x000011F9
		public void SystemDeviceConnected()
		{
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00002FF9 File Offset: 0x000011F9
		public void SystemDeviceDisconnected()
		{
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000039F5 File Offset: 0x00001BF5
		public void Update()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001DC RID: 476 RVA: 0x000039F5 File Offset: 0x00001BF5
		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001DD RID: 477 RVA: 0x000039F5 File Offset: 0x00001BF5
		public void UpdateFinished()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000039F5 File Offset: 0x00001BF5
		public IList<TJoy> GetJoysticks<TJoy>() where TJoy : class
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000039FC File Offset: 0x00001BFC
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0002DEEC File Offset: 0x0002C0EC
		~InputSourceWrapper()
		{
			this.Dispose(false);
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00003A0B File Offset: 0x00001C0B
		protected virtual void Dispose(bool disposing)
		{
			if (this.tMiBPUtQtbBLQiZQjXZrSbbdzjESA)
			{
				return;
			}
			this.tMiBPUtQtbBLQiZQjXZrSbbdzjESA = true;
		}

		// Token: 0x040000D3 RID: 211
		private T BHjdDLJLbcvxYjvtpxsdBMULluVl;

		// Token: 0x040000D4 RID: 212
		private bool tMiBPUtQtbBLQiZQjXZrSbbdzjESA;
	}
}
