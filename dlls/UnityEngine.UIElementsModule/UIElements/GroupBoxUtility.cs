using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200025C RID: 604
	internal static class GroupBoxUtility
	{
		// Token: 0x06001149 RID: 4425 RVA: 0x0003EA48 File Offset: 0x0003CC48
		public static void RegisterGroupBoxOption<T>(this T option) where T : VisualElement, IGroupBoxOption
		{
			VisualElement visualElement = option;
			IGroupBox groupBox = null;
			for (VisualElement parent = visualElement.hierarchy.parent; parent != null; parent = parent.hierarchy.parent)
			{
				IGroupBox groupBox2 = parent as IGroupBox;
				bool flag = groupBox2 != null;
				if (flag)
				{
					groupBox = groupBox2;
					break;
				}
			}
			IGroupBox groupBox3 = groupBox ?? visualElement.elementPanel;
			IGroupManager groupManager = GroupBoxUtility.FindOrCreateGroupManager(groupBox3);
			groupManager.RegisterOption(option);
			GroupBoxUtility.s_GroupOptionManagerCache[option] = groupManager;
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x0003EADC File Offset: 0x0003CCDC
		public static void UnregisterGroupBoxOption<T>(this T option) where T : VisualElement, IGroupBoxOption
		{
			bool flag = !GroupBoxUtility.s_GroupOptionManagerCache.ContainsKey(option);
			if (!flag)
			{
				GroupBoxUtility.s_GroupOptionManagerCache[option].UnregisterOption(option);
				GroupBoxUtility.s_GroupOptionManagerCache.Remove(option);
			}
		}

		// Token: 0x0600114B RID: 4427 RVA: 0x0003EB30 File Offset: 0x0003CD30
		public static void OnOptionSelected<T>(this T selectedOption) where T : VisualElement, IGroupBoxOption
		{
			bool flag = !GroupBoxUtility.s_GroupOptionManagerCache.ContainsKey(selectedOption);
			if (!flag)
			{
				GroupBoxUtility.s_GroupOptionManagerCache[selectedOption].OnOptionSelectionChanged(selectedOption);
			}
		}

		// Token: 0x0600114C RID: 4428 RVA: 0x0003EB74 File Offset: 0x0003CD74
		public static IGroupBoxOption GetSelectedOption(this IGroupBox groupBox)
		{
			return (!GroupBoxUtility.s_GroupManagers.ContainsKey(groupBox)) ? null : GroupBoxUtility.s_GroupManagers[groupBox].GetSelectedOption();
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x0003EBA8 File Offset: 0x0003CDA8
		public static IGroupManager GetGroupManager(this IGroupBox groupBox)
		{
			return GroupBoxUtility.s_GroupManagers.ContainsKey(groupBox) ? GroupBoxUtility.s_GroupManagers[groupBox] : null;
		}

		// Token: 0x0600114E RID: 4430 RVA: 0x0003EBD8 File Offset: 0x0003CDD8
		private static IGroupManager FindOrCreateGroupManager(IGroupBox groupBox)
		{
			bool flag = GroupBoxUtility.s_GroupManagers.ContainsKey(groupBox);
			IGroupManager result;
			if (flag)
			{
				result = GroupBoxUtility.s_GroupManagers[groupBox];
			}
			else
			{
				Type type = null;
				foreach (Type type2 in groupBox.GetType().GetInterfaces())
				{
					bool flag2 = type2.IsGenericType && GroupBoxUtility.k_GenericGroupBoxType.IsAssignableFrom(type2.GetGenericTypeDefinition());
					if (flag2)
					{
						type = type2.GetGenericArguments()[0];
						break;
					}
				}
				IGroupManager groupManager2;
				if (!(type != null))
				{
					IGroupManager groupManager = new DefaultGroupManager();
					groupManager2 = groupManager;
				}
				else
				{
					groupManager2 = (IGroupManager)Activator.CreateInstance(type);
				}
				IGroupManager groupManager3 = groupManager2;
				groupManager3.Init(groupBox);
				BaseVisualElementPanel baseVisualElementPanel = groupBox as BaseVisualElementPanel;
				bool flag3 = baseVisualElementPanel != null;
				if (flag3)
				{
					baseVisualElementPanel.panelDisposed += GroupBoxUtility.OnPanelDestroyed;
				}
				else
				{
					VisualElement visualElement = groupBox as VisualElement;
					bool flag4 = visualElement != null;
					if (flag4)
					{
						visualElement.RegisterCallback<DetachFromPanelEvent>(new EventCallback<DetachFromPanelEvent>(GroupBoxUtility.OnGroupBoxDetachedFromPanel), TrickleDown.NoTrickleDown);
					}
				}
				GroupBoxUtility.s_GroupManagers[groupBox] = groupManager3;
				result = groupManager3;
			}
			return result;
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x0003ECF2 File Offset: 0x0003CEF2
		private static void OnGroupBoxDetachedFromPanel(DetachFromPanelEvent evt)
		{
			GroupBoxUtility.s_GroupManagers.Remove(evt.currentTarget as IGroupBox);
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x0003ED0B File Offset: 0x0003CF0B
		private static void OnPanelDestroyed(BaseVisualElementPanel panel)
		{
			GroupBoxUtility.s_GroupManagers.Remove(panel);
			panel.panelDisposed -= GroupBoxUtility.OnPanelDestroyed;
		}

		// Token: 0x040007A0 RID: 1952
		private static Dictionary<IGroupBox, IGroupManager> s_GroupManagers = new Dictionary<IGroupBox, IGroupManager>();

		// Token: 0x040007A1 RID: 1953
		private static Dictionary<IGroupBoxOption, IGroupManager> s_GroupOptionManagerCache = new Dictionary<IGroupBoxOption, IGroupManager>();

		// Token: 0x040007A2 RID: 1954
		private static readonly Type k_GenericGroupBoxType = typeof(IGroupBox<>);
	}
}
