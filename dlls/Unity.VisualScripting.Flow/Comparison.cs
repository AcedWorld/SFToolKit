using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000B8 RID: 184
	[UnitCategory("Logic")]
	[UnitTitle("Comparison")]
	[UnitShortTitle("Comparison")]
	[UnitOrder(99)]
	public sealed class Comparison : Unit
	{
		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x0000B3E3 File Offset: 0x000095E3
		// (set) Token: 0x06000563 RID: 1379 RVA: 0x0000B3EB File Offset: 0x000095EB
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x0000B3F4 File Offset: 0x000095F4
		// (set) Token: 0x06000565 RID: 1381 RVA: 0x0000B3FC File Offset: 0x000095FC
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x0000B405 File Offset: 0x00009605
		// (set) Token: 0x06000567 RID: 1383 RVA: 0x0000B40D File Offset: 0x0000960D
		[Serialize]
		[Inspectable]
		public bool numeric { get; set; } = true;

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x0000B416 File Offset: 0x00009616
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x0000B41E File Offset: 0x0000961E
		[DoNotSerialize]
		[PortLabel("A < B")]
		public ValueOutput aLessThanB { get; private set; }

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x0000B427 File Offset: 0x00009627
		// (set) Token: 0x0600056B RID: 1387 RVA: 0x0000B42F File Offset: 0x0000962F
		[DoNotSerialize]
		[PortLabel("A ≤ B")]
		public ValueOutput aLessThanOrEqualToB { get; private set; }

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x0000B438 File Offset: 0x00009638
		// (set) Token: 0x0600056D RID: 1389 RVA: 0x0000B440 File Offset: 0x00009640
		[DoNotSerialize]
		[PortLabel("A = B")]
		public ValueOutput aEqualToB { get; private set; }

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x0000B449 File Offset: 0x00009649
		// (set) Token: 0x0600056F RID: 1391 RVA: 0x0000B451 File Offset: 0x00009651
		[DoNotSerialize]
		[PortLabel("A ≠ B")]
		public ValueOutput aNotEqualToB { get; private set; }

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x0000B45A File Offset: 0x0000965A
		// (set) Token: 0x06000571 RID: 1393 RVA: 0x0000B462 File Offset: 0x00009662
		[DoNotSerialize]
		[PortLabel("A ≥ B")]
		public ValueOutput aGreaterThanOrEqualToB { get; private set; }

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x0000B46B File Offset: 0x0000966B
		// (set) Token: 0x06000573 RID: 1395 RVA: 0x0000B473 File Offset: 0x00009673
		[DoNotSerialize]
		[PortLabel("A > B")]
		public ValueOutput aGreatherThanB { get; private set; }

		// Token: 0x06000574 RID: 1396 RVA: 0x0000B47C File Offset: 0x0000967C
		protected override void Definition()
		{
			if (this.numeric)
			{
				this.a = base.ValueInput<float>("a");
				this.b = base.ValueInput<float>("b", 0f);
				this.aLessThanB = base.ValueOutput<bool>("aLessThanB", (Flow flow) => this.NumericLess(flow.GetValue<float>(this.a), flow.GetValue<float>(this.b))).Predictable();
				this.aLessThanOrEqualToB = base.ValueOutput<bool>("aLessThanOrEqualToB", (Flow flow) => this.NumericLessOrEqual(flow.GetValue<float>(this.a), flow.GetValue<float>(this.b))).Predictable();
				this.aEqualToB = base.ValueOutput<bool>("aEqualToB", (Flow flow) => this.NumericEqual(flow.GetValue<float>(this.a), flow.GetValue<float>(this.b))).Predictable();
				this.aNotEqualToB = base.ValueOutput<bool>("aNotEqualToB", (Flow flow) => this.NumericNotEqual(flow.GetValue<float>(this.a), flow.GetValue<float>(this.b))).Predictable();
				this.aGreaterThanOrEqualToB = base.ValueOutput<bool>("aGreaterThanOrEqualToB", (Flow flow) => this.NumericGreaterOrEqual(flow.GetValue<float>(this.a), flow.GetValue<float>(this.b))).Predictable();
				this.aGreatherThanB = base.ValueOutput<bool>("aGreatherThanB", (Flow flow) => this.NumericGreater(flow.GetValue<float>(this.a), flow.GetValue<float>(this.b))).Predictable();
			}
			else
			{
				this.a = base.ValueInput<object>("a").AllowsNull();
				this.b = base.ValueInput<object>("b").AllowsNull();
				this.aLessThanB = base.ValueOutput<bool>("aLessThanB", (Flow flow) => this.GenericLess(flow.GetValue(this.a), flow.GetValue(this.b)));
				this.aLessThanOrEqualToB = base.ValueOutput<bool>("aLessThanOrEqualToB", (Flow flow) => this.GenericLessOrEqual(flow.GetValue(this.a), flow.GetValue(this.b)));
				this.aEqualToB = base.ValueOutput<bool>("aEqualToB", (Flow flow) => this.GenericEqual(flow.GetValue(this.a), flow.GetValue(this.b)));
				this.aNotEqualToB = base.ValueOutput<bool>("aNotEqualToB", (Flow flow) => this.GenericNotEqual(flow.GetValue(this.a), flow.GetValue(this.b)));
				this.aGreaterThanOrEqualToB = base.ValueOutput<bool>("aGreaterThanOrEqualToB", (Flow flow) => this.GenericGreaterOrEqual(flow.GetValue(this.a), flow.GetValue(this.b)));
				this.aGreatherThanB = base.ValueOutput<bool>("aGreatherThanB", (Flow flow) => this.GenericGreater(flow.GetValue(this.a), flow.GetValue(this.b)));
			}
			base.Requirement(this.a, this.aLessThanB);
			base.Requirement(this.b, this.aLessThanB);
			base.Requirement(this.a, this.aLessThanOrEqualToB);
			base.Requirement(this.b, this.aLessThanOrEqualToB);
			base.Requirement(this.a, this.aEqualToB);
			base.Requirement(this.b, this.aEqualToB);
			base.Requirement(this.a, this.aNotEqualToB);
			base.Requirement(this.b, this.aNotEqualToB);
			base.Requirement(this.a, this.aGreaterThanOrEqualToB);
			base.Requirement(this.b, this.aGreaterThanOrEqualToB);
			base.Requirement(this.a, this.aGreatherThanB);
			base.Requirement(this.b, this.aGreatherThanB);
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0000B73E File Offset: 0x0000993E
		private bool NumericLess(float a, float b)
		{
			return a < b;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0000B744 File Offset: 0x00009944
		private bool NumericLessOrEqual(float a, float b)
		{
			return a < b || Mathf.Approximately(a, b);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0000B753 File Offset: 0x00009953
		private bool NumericEqual(float a, float b)
		{
			return Mathf.Approximately(a, b);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0000B75C File Offset: 0x0000995C
		private bool NumericNotEqual(float a, float b)
		{
			return !Mathf.Approximately(a, b);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0000B768 File Offset: 0x00009968
		private bool NumericGreaterOrEqual(float a, float b)
		{
			return a > b || Mathf.Approximately(a, b);
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0000B777 File Offset: 0x00009977
		private bool NumericGreater(float a, float b)
		{
			return a > b;
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0000B77D File Offset: 0x0000997D
		private bool GenericLess(object a, object b)
		{
			return OperatorUtility.LessThan(a, b);
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0000B786 File Offset: 0x00009986
		private bool GenericLessOrEqual(object a, object b)
		{
			return OperatorUtility.LessThanOrEqual(a, b);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0000B78F File Offset: 0x0000998F
		private bool GenericEqual(object a, object b)
		{
			return OperatorUtility.Equal(a, b);
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0000B798 File Offset: 0x00009998
		private bool GenericNotEqual(object a, object b)
		{
			return OperatorUtility.NotEqual(a, b);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0000B7A1 File Offset: 0x000099A1
		private bool GenericGreaterOrEqual(object a, object b)
		{
			return OperatorUtility.GreaterThanOrEqual(a, b);
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0000B7AA File Offset: 0x000099AA
		private bool GenericGreater(object a, object b)
		{
			return OperatorUtility.GreaterThan(a, b);
		}
	}
}
