using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200010C RID: 268
	public class InstancePropertyAccessor<TTarget, TProperty> : IOptimizedAccessor
	{
		// Token: 0x060006E7 RID: 1767 RVA: 0x00020070 File Offset: 0x0001E270
		public InstancePropertyAccessor(PropertyInfo propertyInfo)
		{
			if (OptimizedReflection.safeMode)
			{
				Ensure.That("propertyInfo").IsNotNull<PropertyInfo>(propertyInfo);
				if (propertyInfo.DeclaringType != typeof(TTarget))
				{
					throw new ArgumentException("The declaring type of the property info doesn't match the generic type.", "propertyInfo");
				}
				if (propertyInfo.PropertyType != typeof(TProperty))
				{
					throw new ArgumentException("The property type of the property info doesn't match the generic type.", "propertyInfo");
				}
				if (propertyInfo.IsStatic())
				{
					throw new ArgumentException("The property is static.", "propertyInfo");
				}
			}
			this.propertyInfo = propertyInfo;
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00020108 File Offset: 0x0001E308
		public void Compile()
		{
			MethodInfo getMethod = this.propertyInfo.GetGetMethod(true);
			MethodInfo setMethod = this.propertyInfo.GetSetMethod(true);
			if (OptimizedReflection.useJit)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TTarget), "target");
				if (getMethod != null)
				{
					MemberExpression body = Expression.Property(parameterExpression, this.propertyInfo);
					this.getter = Expression.Lambda<Func<TTarget, TProperty>>(body, new ParameterExpression[]
					{
						parameterExpression
					}).Compile();
				}
				if (setMethod != null)
				{
					this.setter = (Action<TTarget, TProperty>)setMethod.CreateDelegate(typeof(Action<TTarget, TProperty>));
					return;
				}
			}
			else
			{
				if (getMethod != null)
				{
					this.getter = (Func<TTarget, TProperty>)getMethod.CreateDelegate(typeof(Func<TTarget, TProperty>));
				}
				if (setMethod != null)
				{
					this.setter = (Action<TTarget, TProperty>)setMethod.CreateDelegate(typeof(Action<TTarget, TProperty>));
				}
			}
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x000201EC File Offset: 0x0001E3EC
		public object GetValue(object target)
		{
			if (OptimizedReflection.safeMode)
			{
				OptimizedReflection.VerifyInstanceTarget<TTarget>(target);
				if (this.getter == null)
				{
					throw new TargetException(string.Format("The property '{0}.{1}' has no get accessor.", typeof(TTarget), this.propertyInfo.Name));
				}
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

		// Token: 0x060006EA RID: 1770 RVA: 0x0002026C File Offset: 0x0001E46C
		private object GetValueUnsafe(object target)
		{
			return this.getter((TTarget)((object)target));
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00020284 File Offset: 0x0001E484
		public void SetValue(object target, object value)
		{
			if (OptimizedReflection.safeMode)
			{
				OptimizedReflection.VerifyInstanceTarget<TTarget>(target);
				if (this.setter == null)
				{
					throw new TargetException(string.Format("The property '{0}.{1}' has no set accessor.", typeof(TTarget), this.propertyInfo.Name));
				}
				if (!typeof(TProperty).IsAssignableFrom(value))
				{
					string format = "The provided value for '{0}.{1}' does not match the property type.\nProvided: {2}\nExpected: {3}";
					object[] array = new object[4];
					array[0] = typeof(TTarget);
					array[1] = this.propertyInfo.Name;
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
					array[3] = typeof(TProperty);
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

		// Token: 0x060006EC RID: 1772 RVA: 0x0002037C File Offset: 0x0001E57C
		private void SetValueUnsafe(object target, object value)
		{
			this.setter((TTarget)((object)target), (TProperty)((object)value));
		}

		// Token: 0x040001A6 RID: 422
		private readonly PropertyInfo propertyInfo;

		// Token: 0x040001A7 RID: 423
		private Func<TTarget, TProperty> getter;

		// Token: 0x040001A8 RID: 424
		private Action<TTarget, TProperty> setter;
	}
}
