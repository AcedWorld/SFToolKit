using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unity.VisualScripting
{
	// Token: 0x02000174 RID: 372
	public sealed class UnitPortCollection<TPort> : KeyedCollection<string, TPort>, IUnitPortCollection<TPort>, IKeyedCollection<string, TPort>, ICollection<TPort>, IEnumerable<TPort>, IEnumerable where TPort : IUnitPort
	{
		// Token: 0x17000359 RID: 857
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x00011236 File Offset: 0x0000F436
		public IUnit unit { get; }

		// Token: 0x0600099B RID: 2459 RVA: 0x0001123E File Offset: 0x0000F43E
		public UnitPortCollection(IUnit unit)
		{
			this.unit = unit;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x00011250 File Offset: 0x0000F450
		private void BeforeAdd(TPort port)
		{
			if (port.unit == null)
			{
				port.unit = this.unit;
				return;
			}
			if (port.unit == this.unit)
			{
				throw new InvalidOperationException("Node ports cannot be added multiple time to the same unit.");
			}
			throw new InvalidOperationException("Node ports cannot be shared across nodes.");
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x000112AA File Offset: 0x0000F4AA
		private void AfterAdd(TPort port)
		{
			this.unit.PortsChanged();
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x000112B7 File Offset: 0x0000F4B7
		private void BeforeRemove(TPort port)
		{
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x000112B9 File Offset: 0x0000F4B9
		private void AfterRemove(TPort port)
		{
			port.unit = null;
			this.unit.PortsChanged();
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x000112D4 File Offset: 0x0000F4D4
		public TPort Single()
		{
			if (base.Count != 0)
			{
				throw new InvalidOperationException("Port collection does not have a single port.");
			}
			return base[0];
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000112F0 File Offset: 0x0000F4F0
		protected override string GetKeyForItem(TPort item)
		{
			return item.key;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x000112FF File Offset: 0x0000F4FF
		public new bool TryGetValue(string key, out TPort value)
		{
			if (base.Dictionary == null)
			{
				value = default(TPort);
				return false;
			}
			return base.Dictionary.TryGetValue(key, out value);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0001131F File Offset: 0x0000F51F
		protected override void InsertItem(int index, TPort item)
		{
			this.BeforeAdd(item);
			base.InsertItem(index, item);
			this.AfterAdd(item);
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x00011338 File Offset: 0x0000F538
		protected override void RemoveItem(int index)
		{
			TPort port = base[index];
			this.BeforeRemove(port);
			base.RemoveItem(index);
			this.AfterRemove(port);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x00011362 File Offset: 0x0000F562
		protected override void SetItem(int index, TPort item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x00011369 File Offset: 0x0000F569
		protected override void ClearItems()
		{
			while (base.Count > 0)
			{
				this.RemoveItem(0);
			}
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x0001137D File Offset: 0x0000F57D
		TPort IKeyedCollection<string, !0>.get_Item(string key)
		{
			return base[key];
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x00011386 File Offset: 0x0000F586
		bool IKeyedCollection<string, !0>.Contains(string key)
		{
			return base.Contains(key);
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0001138F File Offset: 0x0000F58F
		bool IKeyedCollection<string, !0>.Remove(string key)
		{
			return base.Remove(key);
		}
	}
}
