using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x0200051F RID: 1311
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorValue<T>
	{
		// Token: 0x17000C14 RID: 3092
		// (get) Token: 0x0600360B RID: 13835 RVA: 0x0002A4FA File Offset: 0x000286FA
		public bool isSet
		{
			get
			{
				return this.dsLDEfXXyYHxVrOFzCDYDtfsihUG;
			}
		}

		// Token: 0x17000C15 RID: 3093
		// (get) Token: 0x0600360C RID: 13836 RVA: 0x0002A502 File Offset: 0x00028702
		// (set) Token: 0x0600360D RID: 13837 RVA: 0x0002A50A File Offset: 0x0002870A
		public T value
		{
			get
			{
				return this.PqWaNtUjaFgGQiNIRKDLsuUmLOAW;
			}
			set
			{
				this.PqWaNtUjaFgGQiNIRKDLsuUmLOAW = value;
				this.dsLDEfXXyYHxVrOFzCDYDtfsihUG = true;
			}
		}

		// Token: 0x0600360E RID: 13838 RVA: 0x0002A51A File Offset: 0x0002871A
		public bool SetIfChanged(T value)
		{
			if (!this.dsLDEfXXyYHxVrOFzCDYDtfsihUG)
			{
				this.value = value;
				return false;
			}
			if (!EqualityComparer<T>.Default.Equals(this.PqWaNtUjaFgGQiNIRKDLsuUmLOAW, value))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		// Token: 0x0600360F RID: 13839 RVA: 0x0002A54A File Offset: 0x0002874A
		public void Clear()
		{
			this.dsLDEfXXyYHxVrOFzCDYDtfsihUG = false;
			this.PqWaNtUjaFgGQiNIRKDLsuUmLOAW = default(T);
		}

		// Token: 0x04001C7A RID: 7290
		private T PqWaNtUjaFgGQiNIRKDLsuUmLOAW;

		// Token: 0x04001C7B RID: 7291
		private bool dsLDEfXXyYHxVrOFzCDYDtfsihUG;
	}
}
