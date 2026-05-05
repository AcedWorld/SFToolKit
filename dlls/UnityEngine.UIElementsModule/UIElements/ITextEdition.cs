using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000373 RID: 883
	public interface ITextEdition
	{
		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x06001DB0 RID: 7600
		// (set) Token: 0x06001DB1 RID: 7601
		bool multiline { get; set; }

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x06001DB2 RID: 7602
		// (set) Token: 0x06001DB3 RID: 7603
		bool isReadOnly { get; set; }

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x06001DB4 RID: 7604
		// (set) Token: 0x06001DB5 RID: 7605
		int maxLength { get; set; }

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x06001DB6 RID: 7606
		// (set) Token: 0x06001DB7 RID: 7607
		bool isDelayed { get; set; }

		// Token: 0x06001DB8 RID: 7608
		void ResetValueAndText();

		// Token: 0x06001DB9 RID: 7609
		void SaveValueAndText();

		// Token: 0x06001DBA RID: 7610
		void RestoreValueAndText();

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x06001DBB RID: 7611
		// (set) Token: 0x06001DBC RID: 7612
		Func<char, bool> AcceptCharacter { get; set; }

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x06001DBD RID: 7613
		// (set) Token: 0x06001DBE RID: 7614
		Action<bool> UpdateScrollOffset { get; set; }

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x06001DBF RID: 7615
		// (set) Token: 0x06001DC0 RID: 7616
		Action UpdateValueFromText { get; set; }

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x06001DC1 RID: 7617
		// (set) Token: 0x06001DC2 RID: 7618
		Action UpdateTextFromValue { get; set; }

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x06001DC3 RID: 7619
		// (set) Token: 0x06001DC4 RID: 7620
		Action MoveFocusToCompositeRoot { get; set; }

		// Token: 0x06001DC5 RID: 7621
		void UpdateText(string value);

		// Token: 0x06001DC6 RID: 7622
		string CullString(string s);

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x06001DC7 RID: 7623
		// (set) Token: 0x06001DC8 RID: 7624
		char maskChar { get; set; }

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x06001DC9 RID: 7625
		// (set) Token: 0x06001DCA RID: 7626
		bool isPassword { get; set; }

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x06001DCB RID: 7627 RVA: 0x00073CE0 File Offset: 0x00071EE0
		// (set) Token: 0x06001DCC RID: 7628 RVA: 0x00073D13 File Offset: 0x00071F13
		bool autoCorrection
		{
			get
			{
				Debug.Log("Type " + base.GetType().Name + " implementing interface ITextEdition is missing the implementation for autoCorrection. Calling ITextEdition.autoCorrection of this type will always return false.");
				return false;
			}
			set
			{
				Debug.Log("Type " + base.GetType().Name + " implementing interface ITextEdition is missing the implementation for autoCorrection. Assigning a value to ITextEdition.autoCorrection will not update its value.");
			}
		}

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x06001DCD RID: 7629 RVA: 0x00073D38 File Offset: 0x00071F38
		// (set) Token: 0x06001DCE RID: 7630 RVA: 0x00073D6B File Offset: 0x00071F6B
		bool hideMobileInput
		{
			get
			{
				Debug.Log("Type " + base.GetType().Name + " implementing interface ITextEdition is missing the implementation for hideMobileInput. Calling ITextEdition.hideMobileInput of this type will always return false.");
				return false;
			}
			set
			{
				Debug.Log("Type " + base.GetType().Name + " implementing interface ITextEdition is missing the implementation for hideMobileInput. Assigning a value to ITextEdition.hideMobileInput will not update its value.");
			}
		}

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x06001DCF RID: 7631 RVA: 0x00073D90 File Offset: 0x00071F90
		TouchScreenKeyboard touchScreenKeyboard
		{
			get
			{
				Debug.Log("Type " + base.GetType().Name + " implementing interface ITextEdition is missing the implementation for touchScreenKeyboard. Calling ITextEdition.touchScreenKeyboard of this type will always return null.");
				return null;
			}
		}

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x06001DD0 RID: 7632 RVA: 0x00073DC4 File Offset: 0x00071FC4
		// (set) Token: 0x06001DD1 RID: 7633 RVA: 0x00073DF7 File Offset: 0x00071FF7
		TouchScreenKeyboardType keyboardType
		{
			get
			{
				Debug.Log("Type " + base.GetType().Name + " implementing interface ITextEdition is missing the implementation for keyboardType. Calling ITextEdition.keyboardType of this type will always return Default.");
				return TouchScreenKeyboardType.Default;
			}
			set
			{
				Debug.Log("Type " + base.GetType().Name + " implementing interface ITextEdition is missing the implementation for keyboardType. Assigning a value to ITextEdition.keyboardType will not update its value.");
			}
		}
	}
}
