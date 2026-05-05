using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x02000099 RID: 153
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class Vector2IntField : BaseCompositeField<Vector2Int, IntegerField, int>
	{
		// Token: 0x060005CA RID: 1482 RVA: 0x00016240 File Offset: 0x00014440
		internal override BaseCompositeField<Vector2Int, IntegerField, int>.FieldDescription[] DescribeFields()
		{
			BaseCompositeField<Vector2Int, IntegerField, int>.FieldDescription[] array = new BaseCompositeField<Vector2Int, IntegerField, int>.FieldDescription[2];
			array[0] = new BaseCompositeField<Vector2Int, IntegerField, int>.FieldDescription("X", "unity-x-input", (Vector2Int r) => r.x, delegate(ref Vector2Int r, int v)
			{
				r.x = v;
			});
			array[1] = new BaseCompositeField<Vector2Int, IntegerField, int>.FieldDescription("Y", "unity-y-input", (Vector2Int r) => r.y, delegate(ref Vector2Int r, int v)
			{
				r.y = v;
			});
			return array;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00016300 File Offset: 0x00014500
		public Vector2IntField() : this(null)
		{
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0001630B File Offset: 0x0001450B
		public Vector2IntField(string label) : base(label, 2)
		{
			base.AddToClassList(Vector2IntField.ussClassName);
			base.labelElement.AddToClassList(Vector2IntField.labelUssClassName);
			base.visualInput.AddToClassList(Vector2IntField.inputUssClassName);
		}

		// Token: 0x04000270 RID: 624
		public new static readonly string ussClassName = "unity-vector2-int-field";

		// Token: 0x04000271 RID: 625
		public new static readonly string labelUssClassName = Vector2IntField.ussClassName + "__label";

		// Token: 0x04000272 RID: 626
		public new static readonly string inputUssClassName = Vector2IntField.ussClassName + "__input";

		// Token: 0x0200009A RID: 154
		public new class UxmlFactory : UxmlFactory<Vector2IntField, Vector2IntField.UxmlTraits>
		{
		}

		// Token: 0x0200009B RID: 155
		public new class UxmlTraits : BaseField<Vector2Int>.UxmlTraits
		{
			// Token: 0x060005CF RID: 1487 RVA: 0x00016384 File Offset: 0x00014584
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				Vector2IntField vector2IntField = (Vector2IntField)ve;
				vector2IntField.SetValueWithoutNotify(new Vector2Int(this.m_XValue.GetValueFromBag(bag, cc), this.m_YValue.GetValueFromBag(bag, cc)));
			}

			// Token: 0x04000273 RID: 627
			private UxmlIntAttributeDescription m_XValue = new UxmlIntAttributeDescription
			{
				name = "x"
			};

			// Token: 0x04000274 RID: 628
			private UxmlIntAttributeDescription m_YValue = new UxmlIntAttributeDescription
			{
				name = "y"
			};
		}
	}
}
