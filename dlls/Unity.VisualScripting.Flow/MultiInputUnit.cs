using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200015D RID: 349
	public abstract class MultiInputUnit<T> : Unit, IMultiInputUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x17000316 RID: 790
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x00010594 File Offset: 0x0000E794
		[DoNotSerialize]
		protected virtual int minInputCount
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x0600090B RID: 2315 RVA: 0x00010597 File Offset: 0x0000E797
		// (set) Token: 0x0600090C RID: 2316 RVA: 0x0001059F File Offset: 0x0000E79F
		[DoNotSerialize]
		[Inspectable]
		[UnitHeaderInspectable("Inputs")]
		public virtual int inputCount
		{
			get
			{
				return this._inputCount;
			}
			set
			{
				this._inputCount = Mathf.Clamp(value, this.minInputCount, 10);
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x0600090D RID: 2317 RVA: 0x000105B5 File Offset: 0x0000E7B5
		// (set) Token: 0x0600090E RID: 2318 RVA: 0x000105BD File Offset: 0x0000E7BD
		[DoNotSerialize]
		public ReadOnlyCollection<ValueInput> multiInputs { get; protected set; }

		// Token: 0x0600090F RID: 2319 RVA: 0x000105C8 File Offset: 0x0000E7C8
		protected override void Definition()
		{
			List<ValueInput> list = new List<ValueInput>();
			this.multiInputs = list.AsReadOnly();
			for (int i = 0; i < this.inputCount; i++)
			{
				list.Add(base.ValueInput<T>(i.ToString()));
			}
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0001060C File Offset: 0x0000E80C
		protected void InputsAllowNull()
		{
			foreach (ValueInput valueInput in this.multiInputs)
			{
				valueInput.AllowsNull();
			}
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00010667 File Offset: 0x0000E867
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}

		// Token: 0x040001FC RID: 508
		[SerializeAs("inputCount")]
		private int _inputCount = 2;
	}
}
