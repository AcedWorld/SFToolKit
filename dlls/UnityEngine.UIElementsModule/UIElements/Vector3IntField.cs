using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x0200009D RID: 157
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class Vector3IntField : BaseCompositeField<Vector3Int, IntegerField, int>
	{
		// Token: 0x060005D7 RID: 1495 RVA: 0x00016434 File Offset: 0x00014634
		internal override BaseCompositeField<Vector3Int, IntegerField, int>.FieldDescription[] DescribeFields()
		{
			BaseCompositeField<Vector3Int, IntegerField, int>.FieldDescription[] array = new BaseCompositeField<Vector3Int, IntegerField, int>.FieldDescription[3];
			array[0] = new BaseCompositeField<Vector3Int, IntegerField, int>.FieldDescription("X", "unity-x-input", (Vector3Int r) => r.x, delegate(ref Vector3Int r, int v)
			{
				r.x = v;
			});
			array[1] = new BaseCompositeField<Vector3Int, IntegerField, int>.FieldDescription("Y", "unity-y-input", (Vector3Int r) => r.y, delegate(ref Vector3Int r, int v)
			{
				r.y = v;
			});
			array[2] = new BaseCompositeField<Vector3Int, IntegerField, int>.FieldDescription("Z", "unity-z-input", (Vector3Int r) => r.z, delegate(ref Vector3Int r, int v)
			{
				r.z = v;
			});
			return array;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00016548 File Offset: 0x00014748
		public Vector3IntField() : this(null)
		{
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00016553 File Offset: 0x00014753
		public Vector3IntField(string label) : base(label, 3)
		{
			base.AddToClassList(Vector3IntField.ussClassName);
			base.labelElement.AddToClassList(Vector3IntField.labelUssClassName);
			base.visualInput.AddToClassList(Vector3IntField.inputUssClassName);
		}

		// Token: 0x0400027A RID: 634
		public new static readonly string ussClassName = "unity-vector3-int-field";

		// Token: 0x0400027B RID: 635
		public new static readonly string labelUssClassName = Vector3IntField.ussClassName + "__label";

		// Token: 0x0400027C RID: 636
		public new static readonly string inputUssClassName = Vector3IntField.ussClassName + "__input";

		// Token: 0x0200009E RID: 158
		public new class UxmlFactory : UxmlFactory<Vector3IntField, Vector3IntField.UxmlTraits>
		{
		}

		// Token: 0x0200009F RID: 159
		public new class UxmlTraits : BaseField<Vector3Int>.UxmlTraits
		{
			// Token: 0x060005DC RID: 1500 RVA: 0x000165CC File Offset: 0x000147CC
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				Vector3IntField vector3IntField = (Vector3IntField)ve;
				vector3IntField.SetValueWithoutNotify(new Vector3Int(this.m_XValue.GetValueFromBag(bag, cc), this.m_YValue.GetValueFromBag(bag, cc), this.m_ZValue.GetValueFromBag(bag, cc)));
			}

			// Token: 0x0400027D RID: 637
			private UxmlIntAttributeDescription m_XValue = new UxmlIntAttributeDescription
			{
				name = "x"
			};

			// Token: 0x0400027E RID: 638
			private UxmlIntAttributeDescription m_YValue = new UxmlIntAttributeDescription
			{
				name = "y"
			};

			// Token: 0x0400027F RID: 639
			private UxmlIntAttributeDescription m_ZValue = new UxmlIntAttributeDescription
			{
				name = "z"
			};
		}
	}
}
