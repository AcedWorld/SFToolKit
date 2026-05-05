using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x02000520 RID: 1312
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorListValue<T>
	{
		// Token: 0x17000C16 RID: 3094
		// (get) Token: 0x06003611 RID: 13841 RVA: 0x0002A55F File Offset: 0x0002875F
		public bool isSet
		{
			get
			{
				return this.JNdHCAZPLyDFlVfQWQgAodQWDdrDA;
			}
		}

		// Token: 0x17000C17 RID: 3095
		// (get) Token: 0x06003612 RID: 13842 RVA: 0x0002A567 File Offset: 0x00028767
		// (set) Token: 0x06003613 RID: 13843 RVA: 0x0002A56F File Offset: 0x0002876F
		public IList<T> value
		{
			get
			{
				return this.OJCMrXzRxJejHFoYTbQqKLhwEgAJA;
			}
			set
			{
				this.OJCMrXzRxJejHFoYTbQqKLhwEgAJA = value;
				this.JNdHCAZPLyDFlVfQWQgAodQWDdrDA = true;
				this.zBnDRbgnRwhaEWJmwKEcRTWZRQfvA.Clear();
				if (this.OJCMrXzRxJejHFoYTbQqKLhwEgAJA != null)
				{
					this.zBnDRbgnRwhaEWJmwKEcRTWZRQfvA.AddRange(this.OJCMrXzRxJejHFoYTbQqKLhwEgAJA);
				}
			}
		}

		// Token: 0x06003614 RID: 13844 RVA: 0x0002A5A3 File Offset: 0x000287A3
		public bool SetIfChanged(IList<T> value)
		{
			if (!this.JNdHCAZPLyDFlVfQWQgAodQWDdrDA)
			{
				this.value = value;
				return false;
			}
			if (this.OJCMrXzRxJejHFoYTbQqKLhwEgAJA != value)
			{
				this.value = value;
				return true;
			}
			if (!InspectorListValue<T>.zNbEARFsdNVhcvexyGsGxnblUtUD(value, this.zBnDRbgnRwhaEWJmwKEcRTWZRQfvA))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		// Token: 0x06003615 RID: 13845 RVA: 0x0002A5E0 File Offset: 0x000287E0
		public void Clear()
		{
			this.JNdHCAZPLyDFlVfQWQgAodQWDdrDA = false;
			this.OJCMrXzRxJejHFoYTbQqKLhwEgAJA = null;
			this.zBnDRbgnRwhaEWJmwKEcRTWZRQfvA.Clear();
		}

		// Token: 0x06003616 RID: 13846 RVA: 0x000B63C4 File Offset: 0x000B45C4
		private static bool zNbEARFsdNVhcvexyGsGxnblUtUD(IList<T> A_0, IList<T> A_1)
		{
			if (A_0 == A_1)
			{
				return true;
			}
			if (A_0 == null != (A_1 == null))
			{
				return false;
			}
			if (A_0.Count != A_1.Count)
			{
				return false;
			}
			for (int i = 0; i < A_0.Count; i++)
			{
				if (!EqualityComparer<T>.Default.Equals(A_0[i], A_1[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04001C7C RID: 7292
		private IList<T> OJCMrXzRxJejHFoYTbQqKLhwEgAJA;

		// Token: 0x04001C7D RID: 7293
		private readonly List<T> zBnDRbgnRwhaEWJmwKEcRTWZRQfvA = new List<T>();

		// Token: 0x04001C7E RID: 7294
		private bool JNdHCAZPLyDFlVfQWQgAodQWDdrDA;
	}
}
