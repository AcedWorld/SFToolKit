using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.TextCore.Text;

namespace UnityEngine.UIElements
{
	// Token: 0x02000369 RID: 873
	public class PanelTextSettings : TextSettings
	{
		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x06001CF3 RID: 7411 RVA: 0x00070320 File Offset: 0x0006E520
		internal static PanelTextSettings defaultPanelTextSettings
		{
			get
			{
				bool flag = PanelTextSettings.s_DefaultPanelTextSettings == null;
				if (flag)
				{
					bool flag2 = PanelTextSettings.s_DefaultPanelTextSettings == null;
					if (flag2)
					{
						PanelTextSettings.s_DefaultPanelTextSettings = ScriptableObject.CreateInstance<PanelTextSettings>();
					}
				}
				return PanelTextSettings.s_DefaultPanelTextSettings;
			}
		}

		// Token: 0x06001CF4 RID: 7412 RVA: 0x00070364 File Offset: 0x0006E564
		internal static void UpdateLocalizationFontAsset()
		{
			string str = " - Linux";
			Dictionary<SystemLanguage, string> dictionary = new Dictionary<SystemLanguage, string>
			{
				{
					SystemLanguage.English,
					Path.Combine(UIElementsPackageUtility.EditorResourcesBasePath, "UIPackageResources/FontAssets/DynamicOSFontAssets/Localization/English" + str + ".asset")
				},
				{
					SystemLanguage.Japanese,
					Path.Combine(UIElementsPackageUtility.EditorResourcesBasePath, "UIPackageResources/FontAssets/DynamicOSFontAssets/Localization/Japanese" + str + ".asset")
				},
				{
					SystemLanguage.ChineseSimplified,
					Path.Combine(UIElementsPackageUtility.EditorResourcesBasePath, "UIPackageResources/FontAssets/DynamicOSFontAssets/Localization/ChineseSimplified" + str + ".asset")
				},
				{
					SystemLanguage.ChineseTraditional,
					Path.Combine(UIElementsPackageUtility.EditorResourcesBasePath, "UIPackageResources/FontAssets/DynamicOSFontAssets/Localization/ChineseTraditional" + str + ".asset")
				},
				{
					SystemLanguage.Korean,
					Path.Combine(UIElementsPackageUtility.EditorResourcesBasePath, "UIPackageResources/FontAssets/DynamicOSFontAssets/Localization/Korean" + str + ".asset")
				}
			};
			string arg = Path.Combine(UIElementsPackageUtility.EditorResourcesBasePath, "UIPackageResources/FontAssets/DynamicOSFontAssets/GlobalFallback/GlobalFallback" + str + ".asset");
			FontAsset value = PanelTextSettings.EditorGUIUtilityLoad(dictionary[PanelTextSettings.GetCurrentLanguage()]) as FontAsset;
			FontAsset value2 = PanelTextSettings.EditorGUIUtilityLoad(arg) as FontAsset;
			PanelTextSettings.defaultPanelTextSettings.fallbackFontAssets[0] = value;
			PanelTextSettings.defaultPanelTextSettings.fallbackFontAssets[PanelTextSettings.defaultPanelTextSettings.fallbackFontAssets.Count - 1] = value2;
		}

		// Token: 0x06001CF5 RID: 7413 RVA: 0x000704B0 File Offset: 0x0006E6B0
		internal FontAsset GetCachedFontAsset(Font font)
		{
			return base.GetCachedFontAssetInternal(font);
		}

		// Token: 0x04000C33 RID: 3123
		private static PanelTextSettings s_DefaultPanelTextSettings;

		// Token: 0x04000C34 RID: 3124
		internal static Func<string, Object> EditorGUIUtilityLoad;

		// Token: 0x04000C35 RID: 3125
		internal static Func<SystemLanguage> GetCurrentLanguage;

		// Token: 0x04000C36 RID: 3126
		internal static readonly string s_DefaultEditorPanelTextSettingPath = "UIPackageResources/Default Editor Text Settings.asset";
	}
}
