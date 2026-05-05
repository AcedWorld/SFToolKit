using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x0200008D RID: 141
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class Vector2Field : BaseCompositeField<Vector2, FloatField, float>
	{
		// Token: 0x0600059D RID: 1437 RVA: 0x00015AC0 File Offset: 0x00013CC0
		internal override BaseCompositeField<Vector2, FloatField, float>.FieldDescription[] DescribeFields()
		{
			BaseCompositeField<Vector2, FloatField, float>.FieldDescription[] array = new BaseCompositeField<Vector2, FloatField, float>.FieldDescription[2];
			array[0] = new BaseCompositeField<Vector2, FloatField, float>.FieldDescription("X", "unity-x-input", (Vector2 r) => r.x, delegate(ref Vector2 r, float v)
			{
				r.x = v;
			});
			array[1] = new BaseCompositeField<Vector2, FloatField, float>.FieldDescription("Y", "unity-y-input", (Vector2 r) => r.y, delegate(ref Vector2 r, float v)
			{
				r.y = v;
			});
			return array;
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00015B80 File Offset: 0x00013D80
		public Vector2Field() : this(null)
		{
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x00015B8B File Offset: 0x00013D8B
		public Vector2Field(string label) : base(label, 2)
		{
			base.AddToClassList(Vector2Field.ussClassName);
			base.labelElement.AddToClassList(Vector2Field.labelUssClassName);
			base.visualInput.AddToClassList(Vector2Field.inputUssClassName);
		}

		// Token: 0x04000249 RID: 585
		public new static readonly string ussClassName = "unity-vector2-field";

		// Token: 0x0400024A RID: 586
		public new static readonly string labelUssClassName = Vector2Field.ussClassName + "__label";

		// Token: 0x0400024B RID: 587
		public new static readonly string inputUssClassName = Vector2Field.ussClassName + "__input";

		// Token: 0x0200008E RID: 142
		public new class UxmlFactory : UxmlFactory<Vector2Field, Vector2Field.UxmlTraits>
		{
		}

		// Token: 0x0200008F RID: 143
		public new class UxmlTraits : BaseField<Vector2>.UxmlTraits
		{
			// Token: 0x060005A2 RID: 1442 RVA: 0x00015C04 File Offset: 0x00013E04
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				Vector2Field vector2Field = (Vector2Field)ve;
				vector2Field.SetValueWithoutNotify(new Vector2(this.m_XValue.GetValueFromBag(bag, cc), this.m_YValue.GetValueFromBag(bag, cc)));
			}

			// Token: 0x0400024C RID: 588
			private UxmlFloatAttributeDescription m_XValue = new UxmlFloatAttributeDescription
			{
				name = "x"
			};

			// Token: 0x0400024D RID: 589
			private UxmlFloatAttributeDescription m_YValue = new UxmlFloatAttributeDescription
			{
				name = "y"
			};
		}
	}
}
