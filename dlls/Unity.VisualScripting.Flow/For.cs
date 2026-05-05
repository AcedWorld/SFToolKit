using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000037 RID: 55
	[UnitTitle("For Loop")]
	[UnitCategory("Control")]
	[UnitOrder(9)]
	public sealed class For : LoopUnit
	{
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000218 RID: 536 RVA: 0x000068AF File Offset: 0x00004AAF
		// (set) Token: 0x06000219 RID: 537 RVA: 0x000068B7 File Offset: 0x00004AB7
		[PortLabel("First")]
		[DoNotSerialize]
		public ValueInput firstIndex { get; private set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600021A RID: 538 RVA: 0x000068C0 File Offset: 0x00004AC0
		// (set) Token: 0x0600021B RID: 539 RVA: 0x000068C8 File Offset: 0x00004AC8
		[PortLabel("Last")]
		[DoNotSerialize]
		public ValueInput lastIndex { get; private set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600021C RID: 540 RVA: 0x000068D1 File Offset: 0x00004AD1
		// (set) Token: 0x0600021D RID: 541 RVA: 0x000068D9 File Offset: 0x00004AD9
		[DoNotSerialize]
		public ValueInput step { get; private set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600021E RID: 542 RVA: 0x000068E2 File Offset: 0x00004AE2
		// (set) Token: 0x0600021F RID: 543 RVA: 0x000068EA File Offset: 0x00004AEA
		[PortLabel("Index")]
		[DoNotSerialize]
		public ValueOutput currentIndex { get; private set; }

		// Token: 0x06000220 RID: 544 RVA: 0x000068F4 File Offset: 0x00004AF4
		protected override void Definition()
		{
			this.firstIndex = base.ValueInput<int>("firstIndex", 0);
			this.lastIndex = base.ValueInput<int>("lastIndex", 10);
			this.step = base.ValueInput<int>("step", 1);
			this.currentIndex = base.ValueOutput<int>("currentIndex");
			base.Definition();
			base.Requirement(this.firstIndex, base.enter);
			base.Requirement(this.lastIndex, base.enter);
			base.Requirement(this.step, base.enter);
			base.Assignment(base.enter, this.currentIndex);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00006998 File Offset: 0x00004B98
		private int Start(Flow flow, out int currentIndex, out int lastIndex, out bool ascending)
		{
			int value = flow.GetValue<int>(this.firstIndex);
			lastIndex = flow.GetValue<int>(this.lastIndex);
			ascending = (value <= lastIndex);
			currentIndex = value;
			flow.SetValue(this.currentIndex, currentIndex);
			return flow.EnterLoop();
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000069E7 File Offset: 0x00004BE7
		private bool CanMoveNext(int currentIndex, int lastIndex, bool ascending)
		{
			if (ascending)
			{
				return currentIndex < lastIndex;
			}
			return currentIndex > lastIndex;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000069F5 File Offset: 0x00004BF5
		private void MoveNext(Flow flow, ref int currentIndex)
		{
			currentIndex += flow.GetValue<int>(this.step);
			flow.SetValue(this.currentIndex, currentIndex);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00006A1C File Offset: 0x00004C1C
		protected override ControlOutput Loop(Flow flow)
		{
			int currentIndex;
			int lastIndex;
			bool ascending;
			int loop = this.Start(flow, out currentIndex, out lastIndex, out ascending);
			if (!this.IsStepValueZero())
			{
				GraphStack stack = flow.PreserveStack();
				while (flow.LoopIsNotBroken(loop) && this.CanMoveNext(currentIndex, lastIndex, ascending))
				{
					flow.Invoke(base.body);
					flow.RestoreStack(stack);
					this.MoveNext(flow, ref currentIndex);
				}
				flow.DisposePreservedStack(stack);
			}
			flow.ExitLoop(loop);
			return base.exit;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00006A8F File Offset: 0x00004C8F
		protected override IEnumerator LoopCoroutine(Flow flow)
		{
			int currentIndex;
			int lastIndex;
			bool ascending;
			int loop = this.Start(flow, out currentIndex, out lastIndex, out ascending);
			GraphStack stack = flow.PreserveStack();
			while (flow.LoopIsNotBroken(loop) && this.CanMoveNext(currentIndex, lastIndex, ascending))
			{
				yield return base.body;
				flow.RestoreStack(stack);
				this.MoveNext(flow, ref currentIndex);
			}
			flow.DisposePreservedStack(stack);
			flow.ExitLoop(loop);
			yield return base.exit;
			yield break;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00006AA8 File Offset: 0x00004CA8
		public bool IsStepValueZero()
		{
			bool flag = !this.step.hasValidConnection && (int)base.defaultValues[this.step.key] == 0;
			bool flag2 = false;
			if (this.step.hasValidConnection)
			{
				Literal literal = this.step.connection.source.unit as Literal;
				if (literal != null && Convert.ToInt32(literal.value) == 0)
				{
					flag2 = true;
				}
			}
			return flag || flag2;
		}
	}
}
