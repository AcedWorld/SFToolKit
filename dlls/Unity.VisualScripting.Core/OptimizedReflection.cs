using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000110 RID: 272
	public static class OptimizedReflection
	{
		// Token: 0x06000707 RID: 1799 RVA: 0x0002052C File Offset: 0x0001E72C
		static OptimizedReflection()
		{
			OptimizedReflection.fieldAccessors = new Dictionary<FieldInfo, IOptimizedAccessor>();
			OptimizedReflection.propertyAccessors = new Dictionary<PropertyInfo, IOptimizedAccessor>();
			OptimizedReflection.methodInvokers = new Dictionary<MethodInfo, IOptimizedInvoker>();
			OptimizedReflection.jitAvailable = PlatformUtility.supportsJit;
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x0002055C File Offset: 0x0001E75C
		internal static bool useJit
		{
			get
			{
				return OptimizedReflection.useJitIfAvailable && OptimizedReflection.jitAvailable;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x0002056C File Offset: 0x0001E76C
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x00020573 File Offset: 0x0001E773
		public static bool useJitIfAvailable
		{
			get
			{
				return OptimizedReflection._useJitIfAvailable;
			}
			set
			{
				OptimizedReflection._useJitIfAvailable = value;
				OptimizedReflection.ClearCache();
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00020580 File Offset: 0x0001E780
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x00020587 File Offset: 0x0001E787
		public static bool safeMode { get; set; }

		// Token: 0x0600070D RID: 1805 RVA: 0x0002058F File Offset: 0x0001E78F
		internal static void OnRuntimeMethodLoad()
		{
			OptimizedReflection.safeMode = (Application.isEditor || Debug.isDebugBuild);
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000205A5 File Offset: 0x0001E7A5
		public static void ClearCache()
		{
			OptimizedReflection.fieldAccessors.Clear();
			OptimizedReflection.propertyAccessors.Clear();
			OptimizedReflection.methodInvokers.Clear();
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x000205C5 File Offset: 0x0001E7C5
		internal static void VerifyStaticTarget(Type targetType, object target)
		{
			OptimizedReflection.VerifyTarget(targetType, target, true);
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x000205CF File Offset: 0x0001E7CF
		internal static void VerifyInstanceTarget<TTArget>(object target)
		{
			OptimizedReflection.VerifyTarget(typeof(TTArget), target, false);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x000205E4 File Offset: 0x0001E7E4
		private static void VerifyTarget(Type targetType, object target, bool @static)
		{
			Ensure.That("targetType").IsNotNull<Type>(targetType);
			if (@static)
			{
				if (target != null)
				{
					throw new TargetException(string.Format("Superfluous target object for '{0}'.", targetType));
				}
			}
			else
			{
				if (target == null)
				{
					throw new TargetException(string.Format("Missing target object for '{0}'.", targetType));
				}
				if (!targetType.IsAssignableFrom(targetType))
				{
					throw new TargetException(string.Format("The target object does not match the target type.\nProvided: {0}\nExpected: {1}", target.GetType(), targetType));
				}
			}
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0002064C File Offset: 0x0001E84C
		private static bool SupportsOptimization(MemberInfo memberInfo)
		{
			return !memberInfo.DeclaringType.IsValueType || memberInfo.IsStatic();
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00020666 File Offset: 0x0001E866
		public static IOptimizedAccessor Prewarm(this FieldInfo fieldInfo)
		{
			return OptimizedReflection.GetFieldAccessor(fieldInfo);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0002066E File Offset: 0x0001E86E
		public static object GetValueOptimized(this FieldInfo fieldInfo, object target)
		{
			return OptimizedReflection.GetFieldAccessor(fieldInfo).GetValue(target);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x0002067C File Offset: 0x0001E87C
		public static void SetValueOptimized(this FieldInfo fieldInfo, object target, object value)
		{
			OptimizedReflection.GetFieldAccessor(fieldInfo).SetValue(target, value);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0002068B File Offset: 0x0001E88B
		public static bool SupportsOptimization(this FieldInfo fieldInfo)
		{
			return OptimizedReflection.SupportsOptimization(fieldInfo);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00020698 File Offset: 0x0001E898
		private static IOptimizedAccessor GetFieldAccessor(FieldInfo fieldInfo)
		{
			Ensure.That("fieldInfo").IsNotNull<FieldInfo>(fieldInfo);
			Dictionary<FieldInfo, IOptimizedAccessor> obj = OptimizedReflection.fieldAccessors;
			IOptimizedAccessor result;
			lock (obj)
			{
				IOptimizedAccessor optimizedAccessor;
				if (!OptimizedReflection.fieldAccessors.TryGetValue(fieldInfo, out optimizedAccessor))
				{
					if (fieldInfo.SupportsOptimization())
					{
						Type type;
						if (fieldInfo.IsStatic)
						{
							type = typeof(StaticFieldAccessor<>).MakeGenericType(new Type[]
							{
								fieldInfo.FieldType
							});
						}
						else
						{
							type = typeof(InstanceFieldAccessor<, >).MakeGenericType(new Type[]
							{
								fieldInfo.DeclaringType,
								fieldInfo.FieldType
							});
						}
						optimizedAccessor = (IOptimizedAccessor)Activator.CreateInstance(type, new object[]
						{
							fieldInfo
						});
					}
					else
					{
						optimizedAccessor = new ReflectionFieldAccessor(fieldInfo);
					}
					optimizedAccessor.Compile();
					OptimizedReflection.fieldAccessors.Add(fieldInfo, optimizedAccessor);
				}
				result = optimizedAccessor;
			}
			return result;
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00020784 File Offset: 0x0001E984
		public static IOptimizedAccessor Prewarm(this PropertyInfo propertyInfo)
		{
			return OptimizedReflection.GetPropertyAccessor(propertyInfo);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0002078C File Offset: 0x0001E98C
		public static object GetValueOptimized(this PropertyInfo propertyInfo, object target)
		{
			return OptimizedReflection.GetPropertyAccessor(propertyInfo).GetValue(target);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0002079A File Offset: 0x0001E99A
		public static void SetValueOptimized(this PropertyInfo propertyInfo, object target, object value)
		{
			OptimizedReflection.GetPropertyAccessor(propertyInfo).SetValue(target, value);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x000207A9 File Offset: 0x0001E9A9
		public static bool SupportsOptimization(this PropertyInfo propertyInfo)
		{
			return OptimizedReflection.SupportsOptimization(propertyInfo);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x000207B8 File Offset: 0x0001E9B8
		private static IOptimizedAccessor GetPropertyAccessor(PropertyInfo propertyInfo)
		{
			Ensure.That("propertyInfo").IsNotNull<PropertyInfo>(propertyInfo);
			Dictionary<PropertyInfo, IOptimizedAccessor> obj = OptimizedReflection.propertyAccessors;
			IOptimizedAccessor result;
			lock (obj)
			{
				IOptimizedAccessor optimizedAccessor;
				if (!OptimizedReflection.propertyAccessors.TryGetValue(propertyInfo, out optimizedAccessor))
				{
					if (propertyInfo.SupportsOptimization())
					{
						Type type;
						if (propertyInfo.IsStatic())
						{
							type = typeof(StaticPropertyAccessor<>).MakeGenericType(new Type[]
							{
								propertyInfo.PropertyType
							});
						}
						else
						{
							type = typeof(InstancePropertyAccessor<, >).MakeGenericType(new Type[]
							{
								propertyInfo.DeclaringType,
								propertyInfo.PropertyType
							});
						}
						optimizedAccessor = (IOptimizedAccessor)Activator.CreateInstance(type, new object[]
						{
							propertyInfo
						});
					}
					else
					{
						optimizedAccessor = new ReflectionPropertyAccessor(propertyInfo);
					}
					optimizedAccessor.Compile();
					OptimizedReflection.propertyAccessors.Add(propertyInfo, optimizedAccessor);
				}
				result = optimizedAccessor;
			}
			return result;
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x000208A4 File Offset: 0x0001EAA4
		public static IOptimizedInvoker Prewarm(this MethodInfo methodInfo)
		{
			return OptimizedReflection.GetMethodInvoker(methodInfo);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x000208AC File Offset: 0x0001EAAC
		public static object InvokeOptimized(this MethodInfo methodInfo, object target, params object[] args)
		{
			return OptimizedReflection.GetMethodInvoker(methodInfo).Invoke(target, args);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x000208BB File Offset: 0x0001EABB
		public static object InvokeOptimized(this MethodInfo methodInfo, object target)
		{
			return OptimizedReflection.GetMethodInvoker(methodInfo).Invoke(target);
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x000208C9 File Offset: 0x0001EAC9
		public static object InvokeOptimized(this MethodInfo methodInfo, object target, object arg0)
		{
			return OptimizedReflection.GetMethodInvoker(methodInfo).Invoke(target, arg0);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x000208D8 File Offset: 0x0001EAD8
		public static object InvokeOptimized(this MethodInfo methodInfo, object target, object arg0, object arg1)
		{
			return OptimizedReflection.GetMethodInvoker(methodInfo).Invoke(target, arg0, arg1);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x000208E8 File Offset: 0x0001EAE8
		public static object InvokeOptimized(this MethodInfo methodInfo, object target, object arg0, object arg1, object arg2)
		{
			return OptimizedReflection.GetMethodInvoker(methodInfo).Invoke(target, arg0, arg1, arg2);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x000208FA File Offset: 0x0001EAFA
		public static object InvokeOptimized(this MethodInfo methodInfo, object target, object arg0, object arg1, object arg2, object arg3)
		{
			return OptimizedReflection.GetMethodInvoker(methodInfo).Invoke(target, arg0, arg1, arg2, arg3);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0002090E File Offset: 0x0001EB0E
		public static object InvokeOptimized(this MethodInfo methodInfo, object target, object arg0, object arg1, object arg2, object arg3, object arg4)
		{
			return OptimizedReflection.GetMethodInvoker(methodInfo).Invoke(target, arg0, arg1, arg2, arg3, arg4);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00020924 File Offset: 0x0001EB24
		public static bool SupportsOptimization(this MethodInfo methodInfo)
		{
			if (!OptimizedReflection.SupportsOptimization(methodInfo))
			{
				return false;
			}
			ParameterInfo[] parameters = methodInfo.GetParameters();
			if (parameters.Length > 5)
			{
				return false;
			}
			return !parameters.Any((ParameterInfo parameter) => parameter.ParameterType.IsByRef) && (OptimizedReflection.jitAvailable || !methodInfo.IsVirtual || methodInfo.IsFinal) && methodInfo.CallingConvention != CallingConventions.VarArgs;
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00020998 File Offset: 0x0001EB98
		private static IOptimizedInvoker GetMethodInvoker(MethodInfo methodInfo)
		{
			Ensure.That("methodInfo").IsNotNull<MethodInfo>(methodInfo);
			Dictionary<MethodInfo, IOptimizedInvoker> obj = OptimizedReflection.methodInvokers;
			IOptimizedInvoker result;
			lock (obj)
			{
				IOptimizedInvoker optimizedInvoker;
				if (!OptimizedReflection.methodInvokers.TryGetValue(methodInfo, out optimizedInvoker))
				{
					if (methodInfo.SupportsOptimization())
					{
						ParameterInfo[] parameters = methodInfo.GetParameters();
						Type type;
						if (methodInfo.ReturnType == typeof(void))
						{
							if (methodInfo.IsStatic)
							{
								if (parameters.Length == 0)
								{
									type = typeof(StaticActionInvoker);
								}
								else if (parameters.Length == 1)
								{
									type = typeof(StaticActionInvoker<>).MakeGenericType(new Type[]
									{
										parameters[0].ParameterType
									});
								}
								else if (parameters.Length == 2)
								{
									type = typeof(StaticActionInvoker<, >).MakeGenericType(new Type[]
									{
										parameters[0].ParameterType,
										parameters[1].ParameterType
									});
								}
								else if (parameters.Length == 3)
								{
									type = typeof(StaticActionInvoker<, , >).MakeGenericType(new Type[]
									{
										parameters[0].ParameterType,
										parameters[1].ParameterType,
										parameters[2].ParameterType
									});
								}
								else if (parameters.Length == 4)
								{
									type = typeof(StaticActionInvoker<, , , >).MakeGenericType(new Type[]
									{
										parameters[0].ParameterType,
										parameters[1].ParameterType,
										parameters[2].ParameterType,
										parameters[3].ParameterType
									});
								}
								else
								{
									if (parameters.Length != 5)
									{
										throw new NotSupportedException();
									}
									type = typeof(StaticActionInvoker<, , , , >).MakeGenericType(new Type[]
									{
										parameters[0].ParameterType,
										parameters[1].ParameterType,
										parameters[2].ParameterType,
										parameters[3].ParameterType,
										parameters[4].ParameterType
									});
								}
							}
							else if (parameters.Length == 0)
							{
								type = typeof(InstanceActionInvoker<>).MakeGenericType(new Type[]
								{
									methodInfo.DeclaringType
								});
							}
							else if (parameters.Length == 1)
							{
								type = typeof(InstanceActionInvoker<, >).MakeGenericType(new Type[]
								{
									methodInfo.DeclaringType,
									parameters[0].ParameterType
								});
							}
							else if (parameters.Length == 2)
							{
								type = typeof(InstanceActionInvoker<, , >).MakeGenericType(new Type[]
								{
									methodInfo.DeclaringType,
									parameters[0].ParameterType,
									parameters[1].ParameterType
								});
							}
							else if (parameters.Length == 3)
							{
								type = typeof(InstanceActionInvoker<, , , >).MakeGenericType(new Type[]
								{
									methodInfo.DeclaringType,
									parameters[0].ParameterType,
									parameters[1].ParameterType,
									parameters[2].ParameterType
								});
							}
							else if (parameters.Length == 4)
							{
								type = typeof(InstanceActionInvoker<, , , , >).MakeGenericType(new Type[]
								{
									methodInfo.DeclaringType,
									parameters[0].ParameterType,
									parameters[1].ParameterType,
									parameters[2].ParameterType,
									parameters[3].ParameterType
								});
							}
							else
							{
								if (parameters.Length != 5)
								{
									throw new NotSupportedException();
								}
								type = typeof(InstanceActionInvoker<, , , , , >).MakeGenericType(new Type[]
								{
									methodInfo.DeclaringType,
									parameters[0].ParameterType,
									parameters[1].ParameterType,
									parameters[2].ParameterType,
									parameters[3].ParameterType,
									parameters[4].ParameterType
								});
							}
						}
						else if (methodInfo.IsStatic)
						{
							if (parameters.Length == 0)
							{
								type = typeof(StaticFunctionInvoker<>).MakeGenericType(new Type[]
								{
									methodInfo.ReturnType
								});
							}
							else if (parameters.Length == 1)
							{
								type = typeof(StaticFunctionInvoker<, >).MakeGenericType(new Type[]
								{
									parameters[0].ParameterType,
									methodInfo.ReturnType
								});
							}
							else if (parameters.Length == 2)
							{
								type = typeof(StaticFunctionInvoker<, , >).MakeGenericType(new Type[]
								{
									parameters[0].ParameterType,
									parameters[1].ParameterType,
									methodInfo.ReturnType
								});
							}
							else if (parameters.Length == 3)
							{
								type = typeof(StaticFunctionInvoker<, , , >).MakeGenericType(new Type[]
								{
									parameters[0].ParameterType,
									parameters[1].ParameterType,
									parameters[2].ParameterType,
									methodInfo.ReturnType
								});
							}
							else if (parameters.Length == 4)
							{
								type = typeof(StaticFunctionInvoker<, , , , >).MakeGenericType(new Type[]
								{
									parameters[0].ParameterType,
									parameters[1].ParameterType,
									parameters[2].ParameterType,
									parameters[3].ParameterType,
									methodInfo.ReturnType
								});
							}
							else
							{
								if (parameters.Length != 5)
								{
									throw new NotSupportedException();
								}
								type = typeof(StaticFunctionInvoker<, , , , , >).MakeGenericType(new Type[]
								{
									parameters[0].ParameterType,
									parameters[1].ParameterType,
									parameters[2].ParameterType,
									parameters[3].ParameterType,
									parameters[4].ParameterType,
									methodInfo.ReturnType
								});
							}
						}
						else if (parameters.Length == 0)
						{
							type = typeof(InstanceFunctionInvoker<, >).MakeGenericType(new Type[]
							{
								methodInfo.DeclaringType,
								methodInfo.ReturnType
							});
						}
						else if (parameters.Length == 1)
						{
							type = typeof(InstanceFunctionInvoker<, , >).MakeGenericType(new Type[]
							{
								methodInfo.DeclaringType,
								parameters[0].ParameterType,
								methodInfo.ReturnType
							});
						}
						else if (parameters.Length == 2)
						{
							type = typeof(InstanceFunctionInvoker<, , , >).MakeGenericType(new Type[]
							{
								methodInfo.DeclaringType,
								parameters[0].ParameterType,
								parameters[1].ParameterType,
								methodInfo.ReturnType
							});
						}
						else if (parameters.Length == 3)
						{
							type = typeof(InstanceFunctionInvoker<, , , , >).MakeGenericType(new Type[]
							{
								methodInfo.DeclaringType,
								parameters[0].ParameterType,
								parameters[1].ParameterType,
								parameters[2].ParameterType,
								methodInfo.ReturnType
							});
						}
						else if (parameters.Length == 4)
						{
							type = typeof(InstanceFunctionInvoker<, , , , , >).MakeGenericType(new Type[]
							{
								methodInfo.DeclaringType,
								parameters[0].ParameterType,
								parameters[1].ParameterType,
								parameters[2].ParameterType,
								parameters[3].ParameterType,
								methodInfo.ReturnType
							});
						}
						else
						{
							if (parameters.Length != 5)
							{
								throw new NotSupportedException();
							}
							type = typeof(InstanceFunctionInvoker<, , , , , , >).MakeGenericType(new Type[]
							{
								methodInfo.DeclaringType,
								parameters[0].ParameterType,
								parameters[1].ParameterType,
								parameters[2].ParameterType,
								parameters[3].ParameterType,
								parameters[4].ParameterType,
								methodInfo.ReturnType
							});
						}
						optimizedInvoker = (IOptimizedInvoker)Activator.CreateInstance(type, new object[]
						{
							methodInfo
						});
					}
					else
					{
						optimizedInvoker = new ReflectionInvoker(methodInfo);
					}
					optimizedInvoker.Compile();
					OptimizedReflection.methodInvokers.Add(methodInfo, optimizedInvoker);
				}
				result = optimizedInvoker;
			}
			return result;
		}

		// Token: 0x040001AB RID: 427
		private static readonly Dictionary<FieldInfo, IOptimizedAccessor> fieldAccessors;

		// Token: 0x040001AC RID: 428
		private static readonly Dictionary<PropertyInfo, IOptimizedAccessor> propertyAccessors;

		// Token: 0x040001AD RID: 429
		private static readonly Dictionary<MethodInfo, IOptimizedInvoker> methodInvokers;

		// Token: 0x040001AE RID: 430
		public static readonly bool jitAvailable;

		// Token: 0x040001AF RID: 431
		private static bool _useJitIfAvailable = true;
	}
}
