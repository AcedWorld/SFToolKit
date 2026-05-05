using System;
using System.Diagnostics;

namespace UnityEngine.UIElements
{
	// Token: 0x02000103 RID: 259
	[Serializable]
	public class SortColumnDescription
	{
		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060008ED RID: 2285 RVA: 0x00022DB9 File Offset: 0x00020FB9
		// (set) Token: 0x060008EE RID: 2286 RVA: 0x00022DC4 File Offset: 0x00020FC4
		public string columnName
		{
			get
			{
				return this.m_ColumnName;
			}
			set
			{
				bool flag = this.m_ColumnName == value;
				if (!flag)
				{
					this.m_ColumnName = value;
					Action<SortColumnDescription> action = this.changed;
					if (action != null)
					{
						action(this);
					}
				}
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x00022DFE File Offset: 0x00020FFE
		// (set) Token: 0x060008F0 RID: 2288 RVA: 0x00022E08 File Offset: 0x00021008
		public int columnIndex
		{
			get
			{
				return this.m_ColumnIndex;
			}
			set
			{
				bool flag = this.m_ColumnIndex == value;
				if (!flag)
				{
					this.m_ColumnIndex = value;
					Action<SortColumnDescription> action = this.changed;
					if (action != null)
					{
						action(this);
					}
				}
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060008F1 RID: 2289 RVA: 0x00022E3F File Offset: 0x0002103F
		// (set) Token: 0x060008F2 RID: 2290 RVA: 0x00022E47 File Offset: 0x00021047
		public Column column { get; internal set; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060008F3 RID: 2291 RVA: 0x00022E50 File Offset: 0x00021050
		// (set) Token: 0x060008F4 RID: 2292 RVA: 0x00022E58 File Offset: 0x00021058
		public SortDirection direction
		{
			get
			{
				return this.m_SortDirection;
			}
			set
			{
				bool flag = this.m_SortDirection == value;
				if (!flag)
				{
					this.m_SortDirection = value;
					Action<SortColumnDescription> action = this.changed;
					if (action != null)
					{
						action(this);
					}
				}
			}
		}

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x060008F5 RID: 2293 RVA: 0x00022E90 File Offset: 0x00021090
		// (remove) Token: 0x060008F6 RID: 2294 RVA: 0x00022EC8 File Offset: 0x000210C8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<SortColumnDescription> changed;

		// Token: 0x060008F7 RID: 2295 RVA: 0x00022EFD File Offset: 0x000210FD
		public SortColumnDescription()
		{
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00022F0E File Offset: 0x0002110E
		public SortColumnDescription(int columnIndex, SortDirection direction)
		{
			this.columnIndex = columnIndex;
			this.direction = direction;
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00022F2F File Offset: 0x0002112F
		public SortColumnDescription(string columnName, SortDirection direction)
		{
			this.columnName = columnName;
			this.direction = direction;
		}

		// Token: 0x04000406 RID: 1030
		[SerializeField]
		private int m_ColumnIndex = -1;

		// Token: 0x04000407 RID: 1031
		[SerializeField]
		private string m_ColumnName;

		// Token: 0x04000408 RID: 1032
		[SerializeField]
		private SortDirection m_SortDirection;

		// Token: 0x02000104 RID: 260
		internal class UxmlObjectFactory<T> : UxmlObjectFactory<T, SortColumnDescription.UxmlObjectTraits<T>> where T : SortColumnDescription, new()
		{
		}

		// Token: 0x02000105 RID: 261
		internal class UxmlObjectTraits<T> : UnityEngine.UIElements.UxmlObjectTraits<T> where T : SortColumnDescription
		{
			// Token: 0x060008FB RID: 2299 RVA: 0x00022F5C File Offset: 0x0002115C
			public override void Init(ref T obj, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ref obj, bag, cc);
				obj.columnName = this.m_ColumnName.GetValueFromBag(bag, cc);
				obj.columnIndex = this.m_ColumnIndex.GetValueFromBag(bag, cc);
				obj.direction = this.m_SortDescription.GetValueFromBag(bag, cc);
			}

			// Token: 0x0400040B RID: 1035
			private readonly UxmlStringAttributeDescription m_ColumnName = new UxmlStringAttributeDescription
			{
				name = "column-name"
			};

			// Token: 0x0400040C RID: 1036
			private readonly UxmlIntAttributeDescription m_ColumnIndex = new UxmlIntAttributeDescription
			{
				name = "column-index",
				defaultValue = -1
			};

			// Token: 0x0400040D RID: 1037
			private readonly UxmlEnumAttributeDescription<SortDirection> m_SortDescription = new UxmlEnumAttributeDescription<SortDirection>
			{
				name = "direction",
				defaultValue = SortDirection.Ascending
			};
		}
	}
}
