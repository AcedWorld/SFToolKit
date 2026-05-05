using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000CE RID: 206
	public static class AttributeUtility
	{
		// Token: 0x060004EC RID: 1260 RVA: 0x0000AFA0 File Offset: 0x000091A0
		private static AttributeUtility.AttributeCache GetAttributeCache(MemberInfo element)
		{
			Ensure.That("element").IsNotNull<MemberInfo>(element);
			Dictionary<object, AttributeUtility.AttributeCache> obj = AttributeUtility.optimizedCaches;
			AttributeUtility.AttributeCache result;
			lock (obj)
			{
				AttributeUtility.AttributeCache attributeCache;
				if (!AttributeUtility.optimizedCaches.TryGetValue(element, out attributeCache))
				{
					attributeCache = new AttributeUtility.AttributeCache(element);
					AttributeUtility.optimizedCaches.Add(element, attributeCache);
				}
				result = attributeCache;
			}
			return result;
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0000B014 File Offset: 0x00009214
		private static AttributeUtility.AttributeCache GetAttributeCache(ParameterInfo element)
		{
			Ensure.That("element").IsNotNull<ParameterInfo>(element);
			Dictionary<object, AttributeUtility.AttributeCache> obj = AttributeUtility.optimizedCaches;
			AttributeUtility.AttributeCache result;
			lock (obj)
			{
				AttributeUtility.AttributeCache attributeCache;
				if (!AttributeUtility.optimizedCaches.TryGetValue(element, out attributeCache))
				{
					attributeCache = new AttributeUtility.AttributeCache(element);
					AttributeUtility.optimizedCaches.Add(element, attributeCache);
				}
				result = attributeCache;
			}
			return result;
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0000B088 File Offset: 0x00009288
		private static AttributeUtility.AttributeCache GetAttributeCache(IAttributeProvider element)
		{
			Ensure.That("element").IsNotNull<IAttributeProvider>(element);
			Dictionary<object, AttributeUtility.AttributeCache> obj = AttributeUtility.optimizedCaches;
			AttributeUtility.AttributeCache result;
			lock (obj)
			{
				AttributeUtility.AttributeCache attributeCache;
				if (!AttributeUtility.optimizedCaches.TryGetValue(element, out attributeCache))
				{
					attributeCache = new AttributeUtility.AttributeCache(element);
					AttributeUtility.optimizedCaches.Add(element, attributeCache);
				}
				result = attributeCache;
			}
			return result;
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0000B0FC File Offset: 0x000092FC
		public static void CacheAttributes(MemberInfo element)
		{
			AttributeUtility.GetAttributeCache(element);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0000B105 File Offset: 0x00009305
		internal static IEnumerable<T> GetAttributeOfEnumMember<T>(this Enum enumVal) where T : Attribute
		{
			return enumVal.GetType().GetMember(enumVal.ToString())[0].GetCustomAttributes(typeof(T), false).Cast<T>();
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0000B12F File Offset: 0x0000932F
		public static bool HasAttribute(this MemberInfo element, Type attributeType, bool inherit = true)
		{
			return AttributeUtility.GetAttributeCache(element).HasAttribute(attributeType, inherit);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0000B13E File Offset: 0x0000933E
		public static Attribute GetAttribute(this MemberInfo element, Type attributeType, bool inherit = true)
		{
			return AttributeUtility.GetAttributeCache(element).GetAttribute(attributeType, inherit);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0000B14D File Offset: 0x0000934D
		public static IEnumerable<Attribute> GetAttributes(this MemberInfo element, Type attributeType, bool inherit = true)
		{
			return AttributeUtility.GetAttributeCache(element).GetAttributes(attributeType, inherit);
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0000B15C File Offset: 0x0000935C
		public static bool HasAttribute<TAttribute>(this MemberInfo element, bool inherit = true) where TAttribute : Attribute
		{
			return AttributeUtility.GetAttributeCache(element).HasAttribute<TAttribute>(inherit);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0000B16A File Offset: 0x0000936A
		public static TAttribute GetAttribute<TAttribute>(this MemberInfo element, bool inherit = true) where TAttribute : Attribute
		{
			return AttributeUtility.GetAttributeCache(element).GetAttribute<TAttribute>(inherit);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0000B178 File Offset: 0x00009378
		public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo element, bool inherit = true) where TAttribute : Attribute
		{
			return AttributeUtility.GetAttributeCache(element).GetAttributes<TAttribute>(inherit);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0000B186 File Offset: 0x00009386
		public static void CacheAttributes(ParameterInfo element)
		{
			AttributeUtility.GetAttributeCache(element);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0000B18F File Offset: 0x0000938F
		public static bool HasAttribute(this ParameterInfo element, Type attributeType, bool inherit = true)
		{
			return AttributeUtility.GetAttributeCache(element).HasAttribute(attributeType, inherit);
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0000B19E File Offset: 0x0000939E
		public static Attribute GetAttribute(this ParameterInfo element, Type attributeType, bool inherit = true)
		{
			return AttributeUtility.GetAttributeCache(element).GetAttribute(attributeType, inherit);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0000B1AD File Offset: 0x000093AD
		public static IEnumerable<Attribute> GetAttributes(this ParameterInfo element, Type attributeType, bool inherit = true)
		{
			return AttributeUtility.GetAttributeCache(element).GetAttributes(attributeType, inherit);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0000B1BC File Offset: 0x000093BC
		public static bool HasAttribute<TAttribute>(this ParameterInfo element, bool inherit = true) where TAttribute : Attribute
		{
			return AttributeUtility.GetAttributeCache(element).HasAttribute<TAttribute>(inherit);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0000B1CA File Offset: 0x000093CA
		public static TAttribute GetAttribute<TAttribute>(this ParameterInfo element, bool inherit = true) where TAttribute : Attribute
		{
			return AttributeUtility.GetAttributeCache(element).GetAttribute<TAttribute>(inherit);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0000B1D8 File Offset: 0x000093D8
		public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this ParameterInfo element, bool inherit = true) where TAttribute : Attribute
		{
			return AttributeUtility.GetAttributeCache(element).GetAttributes<TAttribute>(inherit);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0000B1E6 File Offset: 0x000093E6
		public static void CacheAttributes(IAttributeProvider element)
		{
			AttributeUtility.GetAttributeCache(element);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0000B1EF File Offset: 0x000093EF
		public static bool HasAttribute(this IAttributeProvider element, Type attributeType, bool inherit = true)
		{
			return AttributeUtility.GetAttributeCache(element).HasAttribute(attributeType, inherit);
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0000B1FE File Offset: 0x000093FE
		public static Attribute GetAttribute(this IAttributeProvider element, Type attributeType, bool inherit = true)
		{
			return AttributeUtility.GetAttributeCache(element).GetAttribute(attributeType, inherit);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0000B20D File Offset: 0x0000940D
		public static IEnumerable<Attribute> GetAttributes(this IAttributeProvider element, Type attributeType, bool inherit = true)
		{
			return AttributeUtility.GetAttributeCache(element).GetAttributes(attributeType, inherit);
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0000B21C File Offset: 0x0000941C
		public static bool HasAttribute<TAttribute>(this IAttributeProvider element, bool inherit = true) where TAttribute : Attribute
		{
			return AttributeUtility.GetAttributeCache(element).HasAttribute<TAttribute>(inherit);
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0000B22A File Offset: 0x0000942A
		public static TAttribute GetAttribute<TAttribute>(this IAttributeProvider element, bool inherit = true) where TAttribute : Attribute
		{
			return AttributeUtility.GetAttributeCache(element).GetAttribute<TAttribute>(inherit);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0000B238 File Offset: 0x00009438
		public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this IAttributeProvider element, bool inherit = true) where TAttribute : Attribute
		{
			return AttributeUtility.GetAttributeCache(element).GetAttributes<TAttribute>(inherit);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0000B248 File Offset: 0x00009448
		public static bool CheckCondition(Type type, object target, string conditionMemberName, bool fallback)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			bool result;
			try
			{
				if (target != null && !type.IsInstanceOfType(target))
				{
					throw new ArgumentException("Target is not an instance of type.", "target");
				}
				if (conditionMemberName == null)
				{
					result = fallback;
				}
				else
				{
					MemberInfo memberInfo = type.GetMember(conditionMemberName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault<MemberInfo>();
					Member member = (memberInfo != null) ? memberInfo.ToManipulator() : null;
					if (member == null)
					{
						throw new MissingMemberException(type.ToString(), conditionMemberName);
					}
					result = member.Get<bool>(target);
				}
			}
			catch (Exception ex)
			{
				string str = "Failed to check attribute condition: \n";
				Exception ex2 = ex;
				Debug.LogWarning(str + ((ex2 != null) ? ex2.ToString() : null));
				result = fallback;
			}
			return result;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0000B2F4 File Offset: 0x000094F4
		public static bool CheckCondition<T>(T target, string conditionMemberName, bool fallback)
		{
			return AttributeUtility.CheckCondition(((target != null) ? target.GetType() : null) ?? typeof(T), target, conditionMemberName, fallback);
		}

		// Token: 0x04000122 RID: 290
		private static readonly Dictionary<object, AttributeUtility.AttributeCache> optimizedCaches = new Dictionary<object, AttributeUtility.AttributeCache>();

		// Token: 0x020001CB RID: 459
		private class AttributeCache
		{
			// Token: 0x1700020A RID: 522
			// (get) Token: 0x06000C0A RID: 3082 RVA: 0x0003242A File Offset: 0x0003062A
			public List<Attribute> inheritedAttributes { get; } = new List<Attribute>();

			// Token: 0x1700020B RID: 523
			// (get) Token: 0x06000C0B RID: 3083 RVA: 0x00032432 File Offset: 0x00030632
			public List<Attribute> definedAttributes { get; } = new List<Attribute>();

			// Token: 0x06000C0C RID: 3084 RVA: 0x0003243C File Offset: 0x0003063C
			public AttributeCache(MemberInfo element)
			{
				Ensure.That("element").IsNotNull<MemberInfo>(element);
				try
				{
					try
					{
						this.Cache(Attribute.GetCustomAttributes(element, true), this.inheritedAttributes);
					}
					catch (InvalidCastException arg)
					{
						this.Cache(element.GetCustomAttributes(true).Cast<Attribute>().ToArray<Attribute>(), this.inheritedAttributes);
						Debug.LogWarning(string.Format("Failed to fetch inherited attributes on {0}.\n{1}", element, arg));
					}
				}
				catch (Exception arg2)
				{
					Debug.LogWarning(string.Format("Failed to fetch inherited attributes on {0}.\n{1}", element, arg2));
				}
				try
				{
					try
					{
						this.Cache(Attribute.GetCustomAttributes(element, false), this.definedAttributes);
					}
					catch (InvalidCastException)
					{
						this.Cache(element.GetCustomAttributes(false).Cast<Attribute>().ToArray<Attribute>(), this.definedAttributes);
					}
				}
				catch (Exception arg3)
				{
					Debug.LogWarning(string.Format("Failed to fetch defined attributes on {0}.\n{1}", element, arg3));
				}
			}

			// Token: 0x06000C0D RID: 3085 RVA: 0x00032554 File Offset: 0x00030754
			public AttributeCache(ParameterInfo element)
			{
				Ensure.That("element").IsNotNull<ParameterInfo>(element);
				try
				{
					try
					{
						this.Cache(Attribute.GetCustomAttributes(element, true), this.inheritedAttributes);
					}
					catch (InvalidCastException arg)
					{
						this.Cache(element.GetCustomAttributes(true).Cast<Attribute>().ToArray<Attribute>(), this.inheritedAttributes);
						Debug.LogWarning(string.Format("Failed to fetch inherited attributes on {0}.\n{1}", element, arg));
					}
				}
				catch (Exception arg2)
				{
					Debug.LogWarning(string.Format("Failed to fetch inherited attributes on {0}.\n{1}", element, arg2));
				}
				try
				{
					try
					{
						this.Cache(Attribute.GetCustomAttributes(element, false), this.definedAttributes);
					}
					catch (InvalidCastException)
					{
						this.Cache(element.GetCustomAttributes(false).Cast<Attribute>().ToArray<Attribute>(), this.definedAttributes);
					}
				}
				catch (Exception arg3)
				{
					Debug.LogWarning(string.Format("Failed to fetch defined attributes on {0}.\n{1}", element, arg3));
				}
			}

			// Token: 0x06000C0E RID: 3086 RVA: 0x0003266C File Offset: 0x0003086C
			public AttributeCache(IAttributeProvider element)
			{
				Ensure.That("element").IsNotNull<IAttributeProvider>(element);
				try
				{
					this.Cache(element.GetCustomAttributes(true), this.inheritedAttributes);
				}
				catch (Exception arg)
				{
					Debug.LogWarning(string.Format("Failed to fetch inherited attributes on {0}.\n{1}", element, arg));
				}
				try
				{
					this.Cache(element.GetCustomAttributes(false), this.definedAttributes);
				}
				catch (Exception arg2)
				{
					Debug.LogWarning(string.Format("Failed to fetch defined attributes on {0}.\n{1}", element, arg2));
				}
			}

			// Token: 0x06000C0F RID: 3087 RVA: 0x00032714 File Offset: 0x00030914
			private void Cache(Attribute[] attributeObjects, List<Attribute> cache)
			{
				foreach (Attribute item in attributeObjects)
				{
					cache.Add(item);
				}
			}

			// Token: 0x06000C10 RID: 3088 RVA: 0x0003273C File Offset: 0x0003093C
			private bool HasAttribute(Type attributeType, List<Attribute> cache)
			{
				for (int i = 0; i < cache.Count; i++)
				{
					Attribute o = cache[i];
					if (attributeType.IsInstanceOfType(o))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x06000C11 RID: 3089 RVA: 0x00032770 File Offset: 0x00030970
			private Attribute GetAttribute(Type attributeType, List<Attribute> cache)
			{
				for (int i = 0; i < cache.Count; i++)
				{
					Attribute attribute = cache[i];
					if (attributeType.IsInstanceOfType(attribute))
					{
						return attribute;
					}
				}
				return null;
			}

			// Token: 0x06000C12 RID: 3090 RVA: 0x000327A2 File Offset: 0x000309A2
			private IEnumerable<Attribute> GetAttributes(Type attributeType, List<Attribute> cache)
			{
				int num;
				for (int i = 0; i < cache.Count; i = num + 1)
				{
					Attribute attribute = cache[i];
					if (attributeType.IsInstanceOfType(attribute))
					{
						yield return attribute;
					}
					num = i;
				}
				yield break;
			}

			// Token: 0x06000C13 RID: 3091 RVA: 0x000327B9 File Offset: 0x000309B9
			public bool HasAttribute(Type attributeType, bool inherit = true)
			{
				if (inherit)
				{
					return this.HasAttribute(attributeType, this.inheritedAttributes);
				}
				return this.HasAttribute(attributeType, this.definedAttributes);
			}

			// Token: 0x06000C14 RID: 3092 RVA: 0x000327D9 File Offset: 0x000309D9
			public Attribute GetAttribute(Type attributeType, bool inherit = true)
			{
				if (inherit)
				{
					return this.GetAttribute(attributeType, this.inheritedAttributes);
				}
				return this.GetAttribute(attributeType, this.definedAttributes);
			}

			// Token: 0x06000C15 RID: 3093 RVA: 0x000327F9 File Offset: 0x000309F9
			public IEnumerable<Attribute> GetAttributes(Type attributeType, bool inherit = true)
			{
				if (inherit)
				{
					return this.GetAttributes(attributeType, this.inheritedAttributes);
				}
				return this.GetAttributes(attributeType, this.definedAttributes);
			}

			// Token: 0x06000C16 RID: 3094 RVA: 0x00032819 File Offset: 0x00030A19
			public bool HasAttribute<TAttribute>(bool inherit = true) where TAttribute : Attribute
			{
				return this.HasAttribute(typeof(TAttribute), inherit);
			}

			// Token: 0x06000C17 RID: 3095 RVA: 0x0003282C File Offset: 0x00030A2C
			public TAttribute GetAttribute<TAttribute>(bool inherit = true) where TAttribute : Attribute
			{
				return (TAttribute)((object)this.GetAttribute(typeof(TAttribute), inherit));
			}

			// Token: 0x06000C18 RID: 3096 RVA: 0x00032844 File Offset: 0x00030A44
			public IEnumerable<TAttribute> GetAttributes<TAttribute>(bool inherit = true) where TAttribute : Attribute
			{
				return this.GetAttributes(typeof(TAttribute), inherit).Cast<TAttribute>();
			}
		}
	}
}
