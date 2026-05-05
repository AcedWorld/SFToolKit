using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000132 RID: 306
	[UnitCategory("Time")]
	[UnitOrder(6)]
	[TypeIcon(typeof(WaitUnit))]
	public sealed class WaitForFlow : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000824 RID: 2084 RVA: 0x0000F390 File Offset: 0x0000D590
		// (set) Token: 0x06000825 RID: 2085 RVA: 0x0000F398 File Offset: 0x0000D598
		[Serialize]
		[Inspectable]
		public bool resetOnExit { get; set; }

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x0000F3A1 File Offset: 0x0000D5A1
		// (set) Token: 0x06000827 RID: 2087 RVA: 0x0000F3A9 File Offset: 0x0000D5A9
		[DoNotSerialize]
		[Inspectable]
		[UnitHeaderInspectable("Inputs")]
		public int inputCount
		{
			get
			{
				return this._inputCount;
			}
			set
			{
				this._inputCount = Mathf.Clamp(value, 2, 10);
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000828 RID: 2088 RVA: 0x0000F3BA File Offset: 0x0000D5BA
		// (set) Token: 0x06000829 RID: 2089 RVA: 0x0000F3C2 File Offset: 0x0000D5C2
		[DoNotSerialize]
		public ReadOnlyCollection<ControlInput> awaitedInputs { get; private set; }

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x0000F3CB File Offset: 0x0000D5CB
		// (set) Token: 0x0600082B RID: 2091 RVA: 0x0000F3D3 File Offset: 0x0000D5D3
		[DoNotSerialize]
		public ControlInput reset { get; private set; }

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x0600082C RID: 2092 RVA: 0x0000F3DC File Offset: 0x0000D5DC
		// (set) Token: 0x0600082D RID: 2093 RVA: 0x0000F3E4 File Offset: 0x0000D5E4
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x0600082E RID: 2094 RVA: 0x0000F3F0 File Offset: 0x0000D5F0
		protected override void Definition()
		{
			List<ControlInput> list = new List<ControlInput>();
			this.awaitedInputs = list.AsReadOnly();
			this.exit = base.ControlOutput("exit");
			for (int i = 0; i < this.inputCount; i++)
			{
				int _i = i;
				ControlInput controlInput = base.ControlInputCoroutine(_i.ToString(), (Flow flow) => this.Enter(flow, _i), (Flow flow) => this.EnterCoroutine(flow, _i));
				list.Add(controlInput);
				base.Succession(controlInput, this.exit);
			}
			this.reset = base.ControlInput("reset", new Func<Flow, ControlOutput>(this.Reset));
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x0000F4A0 File Offset: 0x0000D6A0
		public IGraphElementData CreateData()
		{
			return new WaitForFlow.Data
			{
				inputsActivated = new bool[this.inputCount]
			};
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0000F4B8 File Offset: 0x0000D6B8
		private ControlOutput Enter(Flow flow, int index)
		{
			flow.stack.GetElementData<WaitForFlow.Data>(this).inputsActivated[index] = true;
			if (this.CheckActivated(flow))
			{
				if (this.resetOnExit)
				{
					this.Reset(flow);
				}
				return this.exit;
			}
			return null;
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0000F4F0 File Offset: 0x0000D6F0
		private bool CheckActivated(Flow flow)
		{
			WaitForFlow.Data elementData = flow.stack.GetElementData<WaitForFlow.Data>(this);
			for (int i = 0; i < elementData.inputsActivated.Length; i++)
			{
				if (!elementData.inputsActivated[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0000F52A File Offset: 0x0000D72A
		private IEnumerator EnterCoroutine(Flow flow, int index)
		{
			WaitForFlow.Data data = flow.stack.GetElementData<WaitForFlow.Data>(this);
			data.inputsActivated[index] = true;
			if (data.isWaitingCoroutine)
			{
				yield break;
			}
			if (!this.CheckActivated(flow))
			{
				data.isWaitingCoroutine = true;
				yield return new WaitUntil(() => this.CheckActivated(flow));
				data.isWaitingCoroutine = false;
			}
			if (this.resetOnExit)
			{
				this.Reset(flow);
			}
			yield return this.exit;
			yield break;
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0000F548 File Offset: 0x0000D748
		private ControlOutput Reset(Flow flow)
		{
			WaitForFlow.Data elementData = flow.stack.GetElementData<WaitForFlow.Data>(this);
			for (int i = 0; i < elementData.inputsActivated.Length; i++)
			{
				elementData.inputsActivated[i] = false;
			}
			return null;
		}

		// Token: 0x040001DA RID: 474
		[SerializeAs("inputCount")]
		private int _inputCount = 2;

		// Token: 0x020001C1 RID: 449
		public sealed class Data : IGraphElementData
		{
			// Token: 0x040003C7 RID: 967
			public bool[] inputsActivated;

			// Token: 0x040003C8 RID: 968
			public bool isWaitingCoroutine;
		}
	}
}
