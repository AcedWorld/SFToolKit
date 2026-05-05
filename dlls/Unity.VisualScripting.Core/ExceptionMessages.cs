using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200004E RID: 78
	public static class ExceptionMessages
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00005D9A File Offset: 0x00003F9A
		public static string Common_IsNull_Failed { get; } = "Value must be null.";

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00005DA1 File Offset: 0x00003FA1
		public static string Common_IsNotNull_Failed { get; } = "Value cannot be null.";

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600023A RID: 570 RVA: 0x00005DA8 File Offset: 0x00003FA8
		public static string Booleans_IsTrueFailed { get; } = "Expected an expression that evaluates to true.";

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00005DAF File Offset: 0x00003FAF
		public static string Booleans_IsFalseFailed { get; } = "Expected an expression that evaluates to false.";

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00005DB6 File Offset: 0x00003FB6
		public static string Collections_Any_Failed { get; } = "The predicate did not match any elements.";

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00005DBD File Offset: 0x00003FBD
		public static string Collections_ContainsKey_Failed { get; } = "{1} '{0}' was not found.";

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00005DC4 File Offset: 0x00003FC4
		public static string Collections_HasItemsFailed { get; } = "Empty collection is not allowed.";

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600023F RID: 575 RVA: 0x00005DCB File Offset: 0x00003FCB
		public static string Collections_HasNoNullItemFailed { get; } = "Collection with null items is not allowed.";

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000240 RID: 576 RVA: 0x00005DD2 File Offset: 0x00003FD2
		public static string Collections_SizeIs_Failed { get; } = "Expected size '{0}' but found '{1}'.";

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000241 RID: 577 RVA: 0x00005DD9 File Offset: 0x00003FD9
		public static string Comp_Is_Failed { get; } = "Value '{0}' is not '{1}'.";

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000242 RID: 578 RVA: 0x00005DE0 File Offset: 0x00003FE0
		public static string Comp_IsNot_Failed { get; } = "Value '{0}' is '{1}', which was not expected.";

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000243 RID: 579 RVA: 0x00005DE7 File Offset: 0x00003FE7
		public static string Comp_IsNotLt { get; } = "Value '{0}' is not lower than limit '{1}'.";

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000244 RID: 580 RVA: 0x00005DEE File Offset: 0x00003FEE
		public static string Comp_IsNotLte { get; } = "Value '{0}' is not lower than or equal to limit '{1}'.";

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000245 RID: 581 RVA: 0x00005DF5 File Offset: 0x00003FF5
		public static string Comp_IsNotGt { get; } = "Value '{0}' is not greater than limit '{1}'.";

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00005DFC File Offset: 0x00003FFC
		public static string Comp_IsNotGte { get; } = "Value '{0}' is not greater than or equal to limit '{1}'.";

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000247 RID: 583 RVA: 0x00005E03 File Offset: 0x00004003
		public static string Comp_IsNotInRange_ToLow { get; } = "Value '{0}' is < min '{1}'.";

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000248 RID: 584 RVA: 0x00005E0A File Offset: 0x0000400A
		public static string Comp_IsNotInRange_ToHigh { get; } = "Value '{0}' is > max '{1}'.";

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000249 RID: 585 RVA: 0x00005E11 File Offset: 0x00004011
		public static string Guids_IsNotEmpty_Failed { get; } = "An empty GUID is not allowed.";

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600024A RID: 586 RVA: 0x00005E18 File Offset: 0x00004018
		public static string Strings_IsEqualTo_Failed { get; } = "Value '{0}' is not '{1}'.";

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00005E1F File Offset: 0x0000401F
		public static string Strings_IsNotEqualTo_Failed { get; } = "Value '{0}' is '{1}', which was not expected.";

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600024C RID: 588 RVA: 0x00005E26 File Offset: 0x00004026
		public static string Strings_SizeIs_Failed { get; } = "Expected length '{0}' but got '{1}'.";

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00005E2D File Offset: 0x0000402D
		public static string Strings_IsNotNullOrWhiteSpace_Failed { get; } = "The string can't be left empty, null or consist of only whitespaces.";

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600024E RID: 590 RVA: 0x00005E34 File Offset: 0x00004034
		public static string Strings_IsNotNullOrEmpty_Failed { get; } = "The string can't be null or empty.";

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00005E3B File Offset: 0x0000403B
		public static string Strings_HasLengthBetween_Failed_ToShort { get; } = "The string is not long enough. Must be between '{0}' and '{1}' but was '{2}' characters long.";

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000250 RID: 592 RVA: 0x00005E42 File Offset: 0x00004042
		public static string Strings_HasLengthBetween_Failed_ToLong { get; } = "The string is too long. Must be between '{0}' and  '{1}'. Must be between '{0}' and '{1}' but was '{2}' characters long.";

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000251 RID: 593 RVA: 0x00005E49 File Offset: 0x00004049
		public static string Strings_Matches_Failed { get; } = "Value '{0}' does not match '{1}'";

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00005E50 File Offset: 0x00004050
		public static string Strings_IsNotEmpty_Failed { get; } = "Empty String is not allowed.";

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000253 RID: 595 RVA: 0x00005E57 File Offset: 0x00004057
		public static string Strings_IsGuid_Failed { get; } = "Value '{0}' is not a valid GUID.";

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000254 RID: 596 RVA: 0x00005E5E File Offset: 0x0000405E
		public static string Types_IsOfType_Failed { get; } = "Expected a '{0}' but got '{1}'.";

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00005E65 File Offset: 0x00004065
		public static string Reflection_HasAttribute_Failed { get; } = "Type '{0}' does not define the [{1}] attribute.";

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000256 RID: 598 RVA: 0x00005E6C File Offset: 0x0000406C
		public static string Reflection_HasConstructor_Failed { get; } = "Type '{0}' does not provide a constructor accepting ({1}).";

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00005E73 File Offset: 0x00004073
		public static string Reflection_HasPublicConstructor_Failed { get; } = "Type '{0}' does not provide a public constructor accepting ({1}).";

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000258 RID: 600 RVA: 0x00005E7A File Offset: 0x0000407A
		public static string ValueTypes_IsNotDefault_Failed { get; } = "The param was expected to not be of default value.";
	}
}
