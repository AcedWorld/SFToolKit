using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000038 RID: 56
	[UnitTitle("For Each Loop")]
	[UnitCategory("Control")]
	[UnitOrder(10)]
	public class ForEach : LoopUnit
	{
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00006B29 File Offset: 0x00004D29
		// (set) Token: 0x06000229 RID: 553 RVA: 0x00006B31 File Offset: 0x00004D31
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput collection { get; private set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00006B3A File Offset: 0x00004D3A
		// (set) Token: 0x0600022B RID: 555 RVA: 0x00006B42 File Offset: 0x00004D42
		[DoNotSerialize]
		[PortLabel("Index")]
		public ValueOutput currentIndex { get; private set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600022C RID: 556 RVA: 0x00006B4B File Offset: 0x00004D4B
		// (set) Token: 0x0600022D RID: 557 RVA: 0x00006B53 File Offset: 0x00004D53
		[DoNotSerialize]
		[PortLabel("Key")]
		public ValueOutput currentKey { get; private set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00006B5C File Offset: 0x00004D5C
		// (set) Token: 0x0600022F RID: 559 RVA: 0x00006B64 File Offset: 0x00004D64
		[DoNotSerialize]
		[PortLabel("Item")]
		public ValueOutput currentItem { get; private set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000230 RID: 560 RVA: 0x00006B6D File Offset: 0x00004D6D
		// (set) Token: 0x06000231 RID: 561 RVA: 0x00006B75 File Offset: 0x00004D75
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable("Dictionary")]
		[InspectorToggleLeft]
		public bool dictionary { get; set; }

		// Token: 0x06000232 RID: 562 RVA: 0x00006B80 File Offset: 0x00004D80
		protected override void Definition()
		{
			base.Definition();
			if (this.dictionary)
			{
				this.collection = base.ValueInput<IDictionary>("collection");
			}
			else
			{
				this.collection = base.ValueInput<IEnumerable>("collection");
			}
			this.currentIndex = base.ValueOutput<int>("currentIndex");
			if (this.dictionary)
			{
				this.currentKey = base.ValueOutput<object>("currentKey");
			}
			this.currentItem = base.ValueOutput<object>("currentItem");
			base.Requirement(this.collection, base.enter);
			base.Assignment(base.enter, this.currentIndex);
			base.Assignment(base.enter, this.currentItem);
			if (this.dictionary)
			{
				base.Assignment(base.enter, this.currentKey);
			}
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00006C4C File Offset: 0x00004E4C
		private int Start(Flow flow, out IEnumerator enumerator, out IDictionaryEnumerator dictionaryEnumerator, out int currentIndex)
		{
			if (this.dictionary)
			{
				dictionaryEnumerator = flow.GetValue<IDictionary>(this.collection).GetEnumerator();
				enumerator = dictionaryEnumerator;
			}
			else
			{
				enumerator = flow.GetValue<IEnumerable>(this.collection).GetEnumerator();
				dictionaryEnumerator = null;
			}
			currentIndex = -1;
			return flow.EnterLoop();
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00006C9C File Offset: 0x00004E9C
		private bool MoveNext(Flow flow, IEnumerator enumerator, IDictionaryEnumerator dictionaryEnumerator, ref int currentIndex)
		{
			bool flag = enumerator.MoveNext();
			if (flag)
			{
				if (this.dictionary)
				{
					flow.SetValue(this.currentKey, dictionaryEnumerator.Key);
					flow.SetValue(this.currentItem, dictionaryEnumerator.Value);
				}
				else
				{
					flow.SetValue(this.currentItem, enumerator.Current);
				}
				currentIndex++;
				flow.SetValue(this.currentIndex, currentIndex);
			}
			return flag;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00006D10 File Offset: 0x00004F10
		protected override ControlOutput Loop(Flow flow)
		{
			IEnumerator enumerator;
			IDictionaryEnumerator dictionaryEnumerator;
			int num;
			int loop = this.Start(flow, out enumerator, out dictionaryEnumerator, out num);
			GraphStack stack = flow.PreserveStack();
			try
			{
				while (flow.LoopIsNotBroken(loop) && this.MoveNext(flow, enumerator, dictionaryEnumerator, ref num))
				{
					flow.Invoke(base.body);
					flow.RestoreStack(stack);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			flow.DisposePreservedStack(stack);
			flow.ExitLoop(loop);
			return base.exit;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00006D98 File Offset: 0x00004F98
		protected override IEnumerator LoopCoroutine(Flow flow)
		{
			IEnumerator enumerator;
			IDictionaryEnumerator dictionaryEnumerator;
			int currentIndex;
			int loop = this.Start(flow, out enumerator, out dictionaryEnumerator, out currentIndex);
			GraphStack stack = flow.PreserveStack();
			try
			{
				while (flow.LoopIsNotBroken(loop) && this.MoveNext(flow, enumerator, dictionaryEnumerator, ref currentIndex))
				{
					yield return base.body;
					flow.RestoreStack(stack);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			flow.DisposePreservedStack(stack);
			flow.ExitLoop(loop);
			yield return base.exit;
			yield break;
			yield break;
		}
	}
}
