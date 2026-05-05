using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000124 RID: 292
	public class StaticPropertyAccessor<TProperty> : IOptimizedAccessor
	{
		// Token: 0x060007A8 RID: 1960 RVA: 0x00022588 File Offset: 0x00020788
		public StaticPropertyAccessor(PropertyInfo propertyInfo)
		{
			if (OptimizedReflection.safeMode)
			{
				if (propertyInfo == null)
				{
					throw new ArgumentNullException("propertyInfo");
				}
				if (propertyInfo.PropertyType != typeof(TProperty))
				{
					throw new ArgumentException("The property type of the property info doesn't match the generic type.", "propertyInfo");
				}
				if (!propertyInfo.IsStatic())
				{
					throw new ArgumentException("The property isn't static.", "propertyInfo");
				}
			}
			this.propertyInfo = propertyInfo;
			this.targetType = propertyInfo.DeclaringType;
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x00022608 File Offset: 0x00020808
		public void Compile()
		{
			MethodInfo getMethod = this.propertyInfo.GetGetMethod(true);
			MethodInfo setMethod = this.propertyInfo.GetSetMethod(true);
			if (OptimizedReflection.useJit)
			{
				if (getMethod != null)
				{
					MemberExpression body = Expression.Property(null, this.propertyInfo);
					this.getter = Expression.Lambda<Func<TProperty>>(body, Array.Empty<ParameterExpression>()).Compile();
				}
				if (setMethod != null)
				{
					this.setter = (Action<TProperty>)setMethod.CreateDelegate(typeof(Action<TProperty>));
					return;
				}
			}
			else
			{
				if (getMethod != null)
				{
					this.getter = (Func<TProperty>)getMethod.CreateDelegate(typeof(Func<TProperty>));
				}
				if (setMethod != null)
				{
					this.setter = (Action<TProperty>)setMethod.CreateDelegate(typeof(Action<TProperty>));
				}
			}
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x000226D0 File Offset: 0x000208D0
		public object GetValue(object target)
		{
			if (OptimizedReflection.safeMode)
			{
				OptimizedReflection.VerifyStaticTarget(this.targetType, target);
				if (this.getter == null)
				{
					throw new TargetException(string.Format("The property '{0}.{1}' has no get accessor.", this.targetType, this.propertyInfo.Name));
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

		// Token: 0x060007AB RID: 1963 RVA: 0x00022754 File Offset: 0x00020954
		private object GetValueUnsafe(object target)
		{
			return this.getter();
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00022768 File Offset: 0x00020968
		public void SetValue(object target, object value)
		{
			if (OptimizedReflection.safeMode)
			{
				OptimizedReflection.VerifyStaticTarget(this.targetType, target);
				if (this.setter == null)
				{
					throw new TargetException(string.Format("The property '{0}.{1}' has no set accessor.", this.targetType, this.propertyInfo.Name));
				}
				if (!typeof(TProperty).IsAssignableFrom(value))
				{
					string format = "The provided value for '{0}.{1}' does not match the property type.\nProvided: {2}\nExpected: {3}";
					object[] array = new object[4];
					array[0] = this.targetType;
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

		// Token: 0x060007AD RID: 1965 RVA: 0x0002285C File Offset: 0x00020A5C
		private void SetValueUnsafe(object target, object value)
		{
			this.setter((TProperty)((object)value));
		}

		// Token: 0x040001C5 RID: 453
		private readonly PropertyInfo propertyInfo;

		// Token: 0x040001C6 RID: 454
		private Func<TProperty> getter;

		// Token: 0x040001C7 RID: 455
		private Action<TProperty> setter;

		// Token: 0x040001C8 RID: 456
		private Type targetType;
	}
}
