using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000394 RID: 916
	public static class UQueryExtensions
	{
		// Token: 0x06001EE8 RID: 7912 RVA: 0x00076AD4 File Offset: 0x00074CD4
		public static T Q<T>(this VisualElement e, string name = null, params string[] classes) where T : VisualElement
		{
			return e.Query(name, classes).Build().First();
		}

		// Token: 0x06001EE9 RID: 7913 RVA: 0x00076B00 File Offset: 0x00074D00
		public static VisualElement Q(this VisualElement e, string name = null, params string[] classes)
		{
			return e.Query(name, classes).Build().First();
		}

		// Token: 0x06001EEA RID: 7914 RVA: 0x00076B2C File Offset: 0x00074D2C
		public static T Q<T>(this VisualElement e, string name = null, string className = null) where T : VisualElement
		{
			bool flag = e == null;
			if (flag)
			{
				throw new ArgumentNullException("e");
			}
			bool flag2 = typeof(T) == typeof(VisualElement);
			T result;
			if (flag2)
			{
				result = (e.Q(name, className) as T);
			}
			else
			{
				bool flag3 = name == null;
				if (flag3)
				{
					bool flag4 = className == null;
					if (flag4)
					{
						UQueryState<VisualElement> uqueryState = UQueryExtensions.SingleElementTypeQuery.RebuildOn(e);
						uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[0] = StyleSelectorPart.CreatePredicate(UQuery.IsOfType<T>.s_Instance);
						result = (uqueryState.First() as T);
					}
					else
					{
						UQueryState<VisualElement> uqueryState = UQueryExtensions.SingleElementTypeAndClassQuery.RebuildOn(e);
						uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[0] = StyleSelectorPart.CreatePredicate(UQuery.IsOfType<T>.s_Instance);
						uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[1] = StyleSelectorPart.CreateClass(className);
						result = (uqueryState.First() as T);
					}
				}
				else
				{
					bool flag5 = className == null;
					if (flag5)
					{
						UQueryState<VisualElement> uqueryState = UQueryExtensions.SingleElementTypeAndNameQuery.RebuildOn(e);
						uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[0] = StyleSelectorPart.CreatePredicate(UQuery.IsOfType<T>.s_Instance);
						uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[1] = StyleSelectorPart.CreateId(name);
						result = (uqueryState.First() as T);
					}
					else
					{
						UQueryState<VisualElement> uqueryState = UQueryExtensions.SingleElementTypeAndNameAndClassQuery.RebuildOn(e);
						uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[0] = StyleSelectorPart.CreatePredicate(UQuery.IsOfType<T>.s_Instance);
						uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[1] = StyleSelectorPart.CreateId(name);
						uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[2] = StyleSelectorPart.CreateClass(className);
						result = (uqueryState.First() as T);
					}
				}
			}
			return result;
		}

		// Token: 0x06001EEB RID: 7915 RVA: 0x00076D8C File Offset: 0x00074F8C
		internal static T MandatoryQ<T>(this VisualElement e, string name, string className = null) where T : VisualElement
		{
			T t = e.Q(name, className);
			bool flag = t == null;
			if (flag)
			{
				throw new UQueryExtensions.MissingVisualElementException("Element not found: " + name);
			}
			return t;
		}

		// Token: 0x06001EEC RID: 7916 RVA: 0x00076DC8 File Offset: 0x00074FC8
		public static VisualElement Q(this VisualElement e, string name = null, string className = null)
		{
			bool flag = e == null;
			if (flag)
			{
				throw new ArgumentNullException("e");
			}
			bool flag2 = name == null;
			VisualElement result;
			if (flag2)
			{
				bool flag3 = className == null;
				if (flag3)
				{
					result = UQueryExtensions.SingleElementEmptyQuery.RebuildOn(e).First();
				}
				else
				{
					UQueryState<VisualElement> uqueryState = UQueryExtensions.SingleElementClassQuery.RebuildOn(e);
					uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[0] = StyleSelectorPart.CreateClass(className);
					result = uqueryState.First();
				}
			}
			else
			{
				bool flag4 = className == null;
				if (flag4)
				{
					UQueryState<VisualElement> uqueryState = UQueryExtensions.SingleElementNameQuery.RebuildOn(e);
					uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[0] = StyleSelectorPart.CreateId(name);
					result = uqueryState.First();
				}
				else
				{
					UQueryState<VisualElement> uqueryState = UQueryExtensions.SingleElementNameAndClassQuery.RebuildOn(e);
					uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[0] = StyleSelectorPart.CreateId(name);
					uqueryState.m_Matchers[0].complexSelector.selectors[0].parts[1] = StyleSelectorPart.CreateClass(className);
					result = uqueryState.First();
				}
			}
			return result;
		}

		// Token: 0x06001EED RID: 7917 RVA: 0x00076F10 File Offset: 0x00075110
		internal static VisualElement MandatoryQ(this VisualElement e, string name, string className = null)
		{
			VisualElement visualElement = e.Q(name, className);
			bool flag = visualElement == null;
			if (flag)
			{
				throw new UQueryExtensions.MissingVisualElementException("Element not found: " + name);
			}
			return visualElement;
		}

		// Token: 0x06001EEE RID: 7918 RVA: 0x00076F48 File Offset: 0x00075148
		public static UQueryBuilder<VisualElement> Query(this VisualElement e, string name = null, params string[] classes)
		{
			return e.Query(name, classes);
		}

		// Token: 0x06001EEF RID: 7919 RVA: 0x00076F64 File Offset: 0x00075164
		public static UQueryBuilder<VisualElement> Query(this VisualElement e, string name = null, string className = null)
		{
			return e.Query(name, className);
		}

		// Token: 0x06001EF0 RID: 7920 RVA: 0x00076F80 File Offset: 0x00075180
		public static UQueryBuilder<T> Query<T>(this VisualElement e, string name = null, params string[] classes) where T : VisualElement
		{
			bool flag = e == null;
			if (flag)
			{
				throw new ArgumentNullException("e");
			}
			return new UQueryBuilder<VisualElement>(e).OfType<T>(name, classes);
		}

		// Token: 0x06001EF1 RID: 7921 RVA: 0x00076FB8 File Offset: 0x000751B8
		public static UQueryBuilder<T> Query<T>(this VisualElement e, string name = null, string className = null) where T : VisualElement
		{
			bool flag = e == null;
			if (flag)
			{
				throw new ArgumentNullException("e");
			}
			return new UQueryBuilder<VisualElement>(e).OfType<T>(name, className);
		}

		// Token: 0x06001EF2 RID: 7922 RVA: 0x00076FF0 File Offset: 0x000751F0
		public static UQueryBuilder<VisualElement> Query(this VisualElement e)
		{
			bool flag = e == null;
			if (flag)
			{
				throw new ArgumentNullException("e");
			}
			return new UQueryBuilder<VisualElement>(e);
		}

		// Token: 0x04000CC2 RID: 3266
		private static UQueryState<VisualElement> SingleElementEmptyQuery = new UQueryBuilder<VisualElement>(null).Build();

		// Token: 0x04000CC3 RID: 3267
		private static UQueryState<VisualElement> SingleElementNameQuery = new UQueryBuilder<VisualElement>(null).Name(string.Empty).Build();

		// Token: 0x04000CC4 RID: 3268
		private static UQueryState<VisualElement> SingleElementClassQuery = new UQueryBuilder<VisualElement>(null).Class(string.Empty).Build();

		// Token: 0x04000CC5 RID: 3269
		private static UQueryState<VisualElement> SingleElementNameAndClassQuery = new UQueryBuilder<VisualElement>(null).Name(string.Empty).Class(string.Empty).Build();

		// Token: 0x04000CC6 RID: 3270
		private static UQueryState<VisualElement> SingleElementTypeQuery = new UQueryBuilder<VisualElement>(null).SingleBaseType().Build();

		// Token: 0x04000CC7 RID: 3271
		private static UQueryState<VisualElement> SingleElementTypeAndNameQuery = new UQueryBuilder<VisualElement>(null).SingleBaseType().Name(string.Empty).Build();

		// Token: 0x04000CC8 RID: 3272
		private static UQueryState<VisualElement> SingleElementTypeAndClassQuery = new UQueryBuilder<VisualElement>(null).SingleBaseType().Class(string.Empty).Build();

		// Token: 0x04000CC9 RID: 3273
		private static UQueryState<VisualElement> SingleElementTypeAndNameAndClassQuery = new UQueryBuilder<VisualElement>(null).SingleBaseType().Name(string.Empty).Class(string.Empty).Build();

		// Token: 0x02000395 RID: 917
		private class MissingVisualElementException : Exception
		{
			// Token: 0x06001EF4 RID: 7924 RVA: 0x00077149 File Offset: 0x00075349
			public MissingVisualElementException()
			{
			}

			// Token: 0x06001EF5 RID: 7925 RVA: 0x00077153 File Offset: 0x00075353
			public MissingVisualElementException(string message) : base(message)
			{
			}
		}
	}
}
