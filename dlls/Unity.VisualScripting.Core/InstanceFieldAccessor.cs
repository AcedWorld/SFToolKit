using System;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000103 RID: 259
	public class InstanceFieldAccessor<TTarget, TField> : IOptimizedAccessor
	{
		// Token: 0x060006B0 RID: 1712 RVA: 0x0001F50C File Offset: 0x0001D70C
		public InstanceFieldAccessor(FieldInfo fieldInfo)
		{
			if (OptimizedReflection.safeMode)
			{
				Ensure.That("fieldInfo").IsNotNull<FieldInfo>(fieldInfo);
				if (fieldInfo.DeclaringType != typeof(TTarget))
				{
					throw new ArgumentException("Declaring type of field info doesn't match generic type.", "fieldInfo");
				}
				if (fieldInfo.FieldType != typeof(TField))
				{
					throw new ArgumentException("Field type of field info doesn't match generic type.", "fieldInfo");
				}
				if (fieldInfo.IsStatic)
				{
					throw new ArgumentException("The field is static.", "fieldInfo");
				}
			}
			this.fieldInfo = fieldInfo;
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0001F5A4 File Offset: 0x0001D7A4
		public void Compile()
		{
			if (OptimizedReflection.useJit)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TTarget), "target");
				MemberExpression memberExpression = Expression.Field(parameterExpression, this.fieldInfo);
				this.getter = Expression.Lambda<Func<TTarget, TField>>(memberExpression, new ParameterExpression[]
				{
					parameterExpression
				}).Compile();
				if (!this.fieldInfo.CanWrite())
				{
					return;
				}
				try
				{
					ParameterExpression parameterExpression2 = Expression.Parameter(typeof(TField));
					BinaryExpression body = Expression.Assign(memberExpression, parameterExpression2);
					this.setter = Expression.Lambda<Action<TTarget, TField>>(body, new ParameterExpression[]
					{
						parameterExpression,
						parameterExpression2
					}).Compile();
					return;
				}
				catch
				{
					string str = "Failed instance field: ";
					FieldInfo fieldInfo = this.fieldInfo;
					Debug.Log(str + ((fieldInfo != null) ? fieldInfo.ToString() : null));
					throw;
				}
			}
			this.getter = ((TTarget instance) => (TField)((object)this.fieldInfo.GetValue(instance)));
			if (this.fieldInfo.CanWrite())
			{
				this.setter = delegate(TTarget instance, TField value)
				{
					this.fieldInfo.SetValue(instance, value);
				};
			}
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x0001F6A8 File Offset: 0x0001D8A8
		public object GetValue(object target)
		{
			if (OptimizedReflection.safeMode)
			{
				OptimizedReflection.VerifyInstanceTarget<TTarget>(target);
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

		// Token: 0x060006B3 RID: 1715 RVA: 0x0001F6FC File Offset: 0x0001D8FC
		private object GetValueUnsafe(object target)
		{
			return this.getter((TTarget)((object)target));
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0001F714 File Offset: 0x0001D914
		public void SetValue(object target, object value)
		{
			if (OptimizedReflection.safeMode)
			{
				OptimizedReflection.VerifyInstanceTarget<TTarget>(target);
				if (this.setter == null)
				{
					throw new TargetException(string.Format("The field '{0}.{1}' cannot be assigned.", typeof(TTarget), this.fieldInfo.Name));
				}
				if (!typeof(TField).IsAssignableFrom(value))
				{
					string format = "The provided value for '{0}.{1}' does not match the field type.\nProvided: {2}\nExpected: {3}";
					object[] array = new object[4];
					array[0] = typeof(TTarget);
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

		// Token: 0x060006B5 RID: 1717 RVA: 0x0001F80C File Offset: 0x0001DA0C
		private void SetValueUnsafe(object target, object value)
		{
			this.setter((TTarget)((object)target), (TField)((object)value));
		}

		// Token: 0x0400019D RID: 413
		private readonly FieldInfo fieldInfo;

		// Token: 0x0400019E RID: 414
		private Func<TTarget, TField> getter;

		// Token: 0x0400019F RID: 415
		private Action<TTarget, TField> setter;
	}
}
