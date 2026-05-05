using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200011B RID: 283
	public class StaticFieldAccessor<TField> : IOptimizedAccessor
	{
		// Token: 0x0600076B RID: 1899 RVA: 0x00021A74 File Offset: 0x0001FC74
		public StaticFieldAccessor(FieldInfo fieldInfo)
		{
			if (OptimizedReflection.safeMode)
			{
				if (fieldInfo == null)
				{
					throw new ArgumentNullException("fieldInfo");
				}
				if (fieldInfo.FieldType != typeof(TField))
				{
					throw new ArgumentException("Field type of field info doesn't match generic type.", "fieldInfo");
				}
				if (!fieldInfo.IsStatic)
				{
					throw new ArgumentException("The field isn't static.", "fieldInfo");
				}
			}
			this.fieldInfo = fieldInfo;
			this.targetType = fieldInfo.DeclaringType;
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00021AF4 File Offset: 0x0001FCF4
		public void Compile()
		{
			if (this.fieldInfo.IsLiteral)
			{
				TField constant = (TField)((object)this.fieldInfo.GetValue(null));
				this.getter = (() => constant);
				return;
			}
			if (OptimizedReflection.useJit)
			{
				MemberExpression memberExpression = Expression.Field(null, this.fieldInfo);
				this.getter = Expression.Lambda<Func<TField>>(memberExpression, Array.Empty<ParameterExpression>()).Compile();
				if (this.fieldInfo.CanWrite())
				{
					ParameterExpression parameterExpression = Expression.Parameter(typeof(TField));
					BinaryExpression body = Expression.Assign(memberExpression, parameterExpression);
					this.setter = Expression.Lambda<Action<TField>>(body, new ParameterExpression[]
					{
						parameterExpression
					}).Compile();
					return;
				}
			}
			else
			{
				this.getter = (() => (TField)((object)this.fieldInfo.GetValue(null)));
				if (this.fieldInfo.CanWrite())
				{
					this.setter = delegate(TField value)
					{
						this.fieldInfo.SetValue(null, value);
					};
				}
			}
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00021BDC File Offset: 0x0001FDDC
		public object GetValue(object target)
		{
			if (OptimizedReflection.safeMode)
			{
				OptimizedReflection.VerifyStaticTarget(this.targetType, target);
				try
				{
					return this.GetValueUnsafe(target);
				}
				catch (TargetInvocationException)
				{
					throw;
				}
				catch (Exception inner)
				{
					throw new TargetInvocationException(inner);
				}
			}
			return this.GetValueUnsafe(target);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00021C34 File Offset: 0x0001FE34
		private object GetValueUnsafe(object target)
		{
			return this.getter();
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x00021C48 File Offset: 0x0001FE48
		public void SetValue(object target, object value)
		{
			if (OptimizedReflection.safeMode)
			{
				OptimizedReflection.VerifyStaticTarget(this.targetType, target);
				if (this.setter == null)
				{
					throw new TargetException(string.Format("The field '{0}.{1}' cannot be assigned.", this.targetType, this.fieldInfo.Name));
				}
				if (!typeof(TField).IsAssignableFrom(value))
				{
					string format = "The provided value for '{0}.{1}' does not match the field type.\nProvided: {2}\nExpected: {3}";
					object[] array = new object[4];
					array[0] = this.targetType;
					array[1] = this.fieldInfo.Name;
					int num = 2;
					object obj;
					if (value == null)
					{
						obj = null;
					}
					else
					{
						Type type = value.GetType();
						obj = ((type != null) ? type.ToString() : null);
					}
					array[num] = (obj ?? "null");
					array[3] = typeof(TField);
					throw new ArgumentException(string.Format(format, array));
				}
				try
				{
					this.SetValueUnsafe(target, value);
					return;
				}
				catch (TargetInvocationException)
				{
					throw;
				}
				catch (Exception inner)
				{
					throw new TargetInvocationException(inner);
				}
			}
			this.SetValueUnsafe(target, value);
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x00021D3C File Offset: 0x0001FF3C
		private void SetValueUnsafe(object target, object value)
		{
			this.setter((TField)((object)value));
		}

		// Token: 0x040001BB RID: 443
		private readonly FieldInfo fieldInfo;

		// Token: 0x040001BC RID: 444
		private Func<TField> getter;

		// Token: 0x040001BD RID: 445
		private Action<TField> setter;

		// Token: 0x040001BE RID: 446
		private Type targetType;
	}
}
