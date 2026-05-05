using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200000D RID: 13
	public abstract class ReflectedCloner : Cloner<object>
	{
		// Token: 0x0600002D RID: 45 RVA: 0x0000254B File Offset: 0x0000074B
		public override bool Handles(Type type)
		{
			return false;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002550 File Offset: 0x00000750
		public override void FillClone(Type type, ref object clone, object original, CloningContext context)
		{
			if (PlatformUtility.supportsJit)
			{
				foreach (IOptimizedAccessor optimizedAccessor in this.GetOptimizedAccessors(type))
				{
					if (context.tryPreserveInstances)
					{
						object value = optimizedAccessor.GetValue(clone);
						Cloning.CloneInto(context, ref value, optimizedAccessor.GetValue(original));
						optimizedAccessor.SetValue(clone, value);
					}
					else
					{
						optimizedAccessor.SetValue(clone, Cloning.Clone(context, optimizedAccessor.GetValue(original)));
					}
				}
				return;
			}
			foreach (MemberInfo memberInfo in this.GetAccessors(type))
			{
				if (memberInfo is FieldInfo)
				{
					FieldInfo fieldInfo = (FieldInfo)memberInfo;
					if (context.tryPreserveInstances)
					{
						object value2 = fieldInfo.GetValue(clone);
						Cloning.CloneInto(context, ref value2, fieldInfo.GetValue(original));
						fieldInfo.SetValue(clone, value2);
					}
					else
					{
						fieldInfo.SetValue(clone, Cloning.Clone(context, fieldInfo.GetValue(original)));
					}
				}
				else if (memberInfo is PropertyInfo)
				{
					PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
					if (context.tryPreserveInstances)
					{
						object value3 = propertyInfo.GetValue(clone, null);
						Cloning.CloneInto(context, ref value3, propertyInfo.GetValue(original, null));
						propertyInfo.SetValue(clone, value3, null);
					}
					else
					{
						propertyInfo.SetValue(clone, Cloning.Clone(context, propertyInfo.GetValue(original, null)), null);
					}
				}
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000026A5 File Offset: 0x000008A5
		private MemberInfo[] GetAccessors(Type type)
		{
			if (!this.accessors.ContainsKey(type))
			{
				this.accessors.Add(type, this.GetMembers(type).ToArray<MemberInfo>());
			}
			return this.accessors[type];
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000026DC File Offset: 0x000008DC
		private IOptimizedAccessor[] GetOptimizedAccessors(Type type)
		{
			if (!this.optimizedAccessors.ContainsKey(type))
			{
				List<IOptimizedAccessor> list = new List<IOptimizedAccessor>();
				foreach (MemberInfo memberInfo in this.GetMembers(type))
				{
					if (memberInfo is FieldInfo)
					{
						list.Add(((FieldInfo)memberInfo).Prewarm());
					}
					else if (memberInfo is PropertyInfo)
					{
						list.Add(((PropertyInfo)memberInfo).Prewarm());
					}
				}
				this.optimizedAccessors.Add(type, list.ToArray());
			}
			return this.optimizedAccessors[type];
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000278C File Offset: 0x0000098C
		protected virtual IEnumerable<MemberInfo> GetMembers(Type type)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			IEnumerable[] array = new IEnumerable[2];
			array[0] = type.GetFields(bindingAttr).Where(new Func<FieldInfo, bool>(this.IncludeField));
			IEnumerable[] array2 = array;
			array2[1] = type.GetProperties(bindingAttr).Where(new Func<PropertyInfo, bool>(this.IncludeProperty));
			return LinqUtility.Concat<MemberInfo>(array2);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000027DF File Offset: 0x000009DF
		protected virtual bool IncludeField(FieldInfo field)
		{
			return false;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000027E2 File Offset: 0x000009E2
		protected virtual bool IncludeProperty(PropertyInfo property)
		{
			return false;
		}

		// Token: 0x04000003 RID: 3
		private readonly Dictionary<Type, MemberInfo[]> accessors = new Dictionary<Type, MemberInfo[]>();

		// Token: 0x04000004 RID: 4
		private readonly Dictionary<Type, IOptimizedAccessor[]> optimizedAccessors = new Dictionary<Type, IOptimizedAccessor[]>();
	}
}
