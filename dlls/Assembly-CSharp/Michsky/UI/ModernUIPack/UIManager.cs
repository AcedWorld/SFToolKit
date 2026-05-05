using System;
using TMPro;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000325 RID: 805
	[CreateAssetMenu(fileName = "New UI Manager", menuName = "Modern UI Pack/New UI Manager")]
	public class UIManager : ScriptableObject
	{
		// Token: 0x04001622 RID: 5666
		[HideInInspector]
		public bool enableDynamicUpdate = true;

		// Token: 0x04001623 RID: 5667
		[HideInInspector]
		public bool enableExtendedColorPicker = true;

		// Token: 0x04001624 RID: 5668
		[HideInInspector]
		public bool editorHints = true;

		// Token: 0x04001625 RID: 5669
		[HideInInspector]
		public bool changeRootFolder = true;

		// Token: 0x04001626 RID: 5670
		[HideInInspector]
		public string rootFolder = "Modern UI Pack/Prefabs/";

		// Token: 0x04001627 RID: 5671
		public Color animatedIconColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001628 RID: 5672
		public Color contextBackgroundColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001629 RID: 5673
		public UIManager.ButtonThemeType buttonThemeType;

		// Token: 0x0400162A RID: 5674
		public TMP_FontAsset buttonFont;

		// Token: 0x0400162B RID: 5675
		public float buttonFontSize = 22.5f;

		// Token: 0x0400162C RID: 5676
		public Color buttonBorderColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400162D RID: 5677
		public Color buttonFilledColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400162E RID: 5678
		public Color buttonTextBasicColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400162F RID: 5679
		public Color buttonTextColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001630 RID: 5680
		public Color buttonTextHighlightedColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001631 RID: 5681
		public Color buttonIconBasicColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001632 RID: 5682
		public Color buttonIconColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001633 RID: 5683
		public Color buttonIconHighlightedColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001634 RID: 5684
		public TMP_FontAsset dropdownItemFont;

		// Token: 0x04001635 RID: 5685
		public float dropdownItemFontSize = 22.5f;

		// Token: 0x04001636 RID: 5686
		public UIManager.DropdownThemeType dropdownThemeType;

		// Token: 0x04001637 RID: 5687
		public UIManager.DropdownAnimationType dropdownAnimationType;

		// Token: 0x04001638 RID: 5688
		public TMP_FontAsset dropdownFont;

		// Token: 0x04001639 RID: 5689
		public float dropdownFontSize = 22.5f;

		// Token: 0x0400163A RID: 5690
		public Color dropdownColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400163B RID: 5691
		public Color dropdownTextColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400163C RID: 5692
		public Color dropdownIconColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400163D RID: 5693
		public Color dropdownItemColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400163E RID: 5694
		public Color dropdownItemTextColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400163F RID: 5695
		public Color dropdownItemIconColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001640 RID: 5696
		public TMP_FontAsset selectorFont;

		// Token: 0x04001641 RID: 5697
		public float hSelectorFontSize = 28f;

		// Token: 0x04001642 RID: 5698
		public Color selectorColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001643 RID: 5699
		public Color selectorHighlightedColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001644 RID: 5700
		public bool hSelectorInvertAnimation;

		// Token: 0x04001645 RID: 5701
		public bool hSelectorLoopSelection;

		// Token: 0x04001646 RID: 5702
		public TMP_FontAsset inputFieldFont;

		// Token: 0x04001647 RID: 5703
		public float inputFieldFontSize = 28f;

		// Token: 0x04001648 RID: 5704
		public Color inputFieldColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001649 RID: 5705
		public TMP_FontAsset modalWindowTitleFont;

		// Token: 0x0400164A RID: 5706
		public TMP_FontAsset modalWindowContentFont;

		// Token: 0x0400164B RID: 5707
		public UIManager.DropdownThemeType modalThemeType;

		// Token: 0x0400164C RID: 5708
		public Color modalWindowTitleColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400164D RID: 5709
		public Color modalWindowDescriptionColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400164E RID: 5710
		public Color modalWindowIconColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400164F RID: 5711
		public Color modalWindowBackgroundColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001650 RID: 5712
		public Color modalWindowContentPanelColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001651 RID: 5713
		public TMP_FontAsset notificationTitleFont;

		// Token: 0x04001652 RID: 5714
		public float notificationTitleFontSize = 22.5f;

		// Token: 0x04001653 RID: 5715
		public TMP_FontAsset notificationDescriptionFont;

		// Token: 0x04001654 RID: 5716
		public float notificationDescriptionFontSize = 18f;

		// Token: 0x04001655 RID: 5717
		public UIManager.NotificationThemeType notificationThemeType;

		// Token: 0x04001656 RID: 5718
		public Color notificationBackgroundColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001657 RID: 5719
		public Color notificationTitleColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001658 RID: 5720
		public Color notificationDescriptionColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001659 RID: 5721
		public Color notificationIconColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400165A RID: 5722
		public TMP_FontAsset progressBarLabelFont;

		// Token: 0x0400165B RID: 5723
		public float progressBarLabelFontSize = 25f;

		// Token: 0x0400165C RID: 5724
		public Color progressBarColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400165D RID: 5725
		public Color progressBarBackgroundColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400165E RID: 5726
		public Color progressBarLoopBackgroundColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400165F RID: 5727
		public Color progressBarLabelColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001660 RID: 5728
		public Color scrollbarColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001661 RID: 5729
		public Color scrollbarBackgroundColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001662 RID: 5730
		public TMP_FontAsset sliderLabelFont;

		// Token: 0x04001663 RID: 5731
		public float sliderLabelFontSize = 24f;

		// Token: 0x04001664 RID: 5732
		public UIManager.SliderThemeType sliderThemeType;

		// Token: 0x04001665 RID: 5733
		public Color sliderColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001666 RID: 5734
		public Color sliderBackgroundColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001667 RID: 5735
		public Color sliderLabelColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001668 RID: 5736
		public Color sliderPopupLabelColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001669 RID: 5737
		public Color sliderHandleColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400166A RID: 5738
		public Color switchBorderColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400166B RID: 5739
		public Color switchBackgroundColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400166C RID: 5740
		public Color switchHandleOnColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400166D RID: 5741
		public Color switchHandleOffColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x0400166E RID: 5742
		public TMP_FontAsset toggleFont;

		// Token: 0x0400166F RID: 5743
		public float toggleFontSize = 35f;

		// Token: 0x04001670 RID: 5744
		public UIManager.ToggleThemeType toggleThemeType;

		// Token: 0x04001671 RID: 5745
		public Color toggleTextColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001672 RID: 5746
		public Color toggleBorderColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001673 RID: 5747
		public Color toggleBackgroundColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001674 RID: 5748
		public Color toggleCheckColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001675 RID: 5749
		public TMP_FontAsset tooltipFont;

		// Token: 0x04001676 RID: 5750
		public float tooltipFontSize = 22f;

		// Token: 0x04001677 RID: 5751
		public Color tooltipTextColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x04001678 RID: 5752
		public Color tooltipBackgroundColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x02000326 RID: 806
		public enum ButtonThemeType
		{
			// Token: 0x0400167A RID: 5754
			BASIC,
			// Token: 0x0400167B RID: 5755
			CUSTOM
		}

		// Token: 0x02000327 RID: 807
		public enum DropdownThemeType
		{
			// Token: 0x0400167D RID: 5757
			BASIC,
			// Token: 0x0400167E RID: 5758
			CUSTOM
		}

		// Token: 0x02000328 RID: 808
		public enum DropdownAnimationType
		{
			// Token: 0x04001680 RID: 5760
			FADING,
			// Token: 0x04001681 RID: 5761
			SLIDING,
			// Token: 0x04001682 RID: 5762
			STYLISH
		}

		// Token: 0x02000329 RID: 809
		public enum ModalWindowThemeType
		{
			// Token: 0x04001684 RID: 5764
			BASIC,
			// Token: 0x04001685 RID: 5765
			CUSTOM
		}

		// Token: 0x0200032A RID: 810
		public enum NotificationThemeType
		{
			// Token: 0x04001687 RID: 5767
			BASIC,
			// Token: 0x04001688 RID: 5768
			CUSTOM
		}

		// Token: 0x0200032B RID: 811
		public enum SliderThemeType
		{
			// Token: 0x0400168A RID: 5770
			BASIC,
			// Token: 0x0400168B RID: 5771
			CUSTOM
		}

		// Token: 0x0200032C RID: 812
		public enum ToggleThemeType
		{
			// Token: 0x0400168D RID: 5773
			BASIC,
			// Token: 0x0400168E RID: 5774
			CUSTOM
		}
	}
}
