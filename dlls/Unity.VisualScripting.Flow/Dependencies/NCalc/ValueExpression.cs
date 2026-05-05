using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x02000197 RID: 407
	public class ValueExpression : LogicalExpression
	{
		// Token: 0x06000B4F RID: 2895 RVA: 0x0001A01C File Offset: 0x0001821C
		public ValueExpression(object value, ValueType type)
		{
			this.Value = value;
			this.Type = type;
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0001A034 File Offset: 0x00018234
		public ValueExpression(object value)
		{
			switch (System.Type.GetTypeCode(value.GetType()))
			{
			case TypeCode.Boolean:
				this.Type = ValueType.Boolean;
				goto IL_A5;
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
				this.Type = ValueType.Integer;
				goto IL_A5;
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				this.Type = ValueType.Float;
				goto IL_A5;
			case TypeCode.DateTime:
				this.Type = ValueType.DateTime;
				goto IL_A5;
			case TypeCode.String:
				this.Type = ValueType.String;
				goto IL_A5;
			}
			throw new EvaluationException("This value could not be handled: " + ((value != null) ? value.ToString() : null));
			IL_A5:
			this.Value = value;
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0001A0ED File Offset: 0x000182ED
		public ValueExpression(string value)
		{
			this.Value = value;
			this.Type = ValueType.String;
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0001A103 File Offset: 0x00018303
		public ValueExpression(int value)
		{
			this.Value = value;
			this.Type = ValueType.Integer;
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x0001A11E File Offset: 0x0001831E
		public ValueExpression(float value)
		{
			this.Value = value;
			this.Type = ValueType.Float;
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x0001A139 File Offset: 0x00018339
		public ValueExpression(DateTime value)
		{
			this.Value = value;
			this.Type = ValueType.DateTime;
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x0001A154 File Offset: 0x00018354
		public ValueExpression(bool value)
		{
			this.Value = value;
			this.Type = ValueType.Boolean;
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000B56 RID: 2902 RVA: 0x0001A16F File Offset: 0x0001836F
		// (set) Token: 0x06000B57 RID: 2903 RVA: 0x0001A177 File Offset: 0x00018377
		public object Value { get; set; }

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000B58 RID: 2904 RVA: 0x0001A180 File Offset: 0x00018380
		// (set) Token: 0x06000B59 RID: 2905 RVA: 0x0001A188 File Offset: 0x00018388
		public ValueType Type { get; set; }

		// Token: 0x06000B5A RID: 2906 RVA: 0x0001A191 File Offset: 0x00018391
		public override void Accept(LogicalExpressionVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
