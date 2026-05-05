using System;
using System.Collections.Generic;
using UnityEngine.Yoga;

namespace UnityEngine.UIElements
{
	// Token: 0x0200030F RID: 783
	internal static class StyleValueExtensions
	{
		// Token: 0x06001B09 RID: 6921 RVA: 0x0006A4C8 File Offset: 0x000686C8
		internal static string DebugString<T>(this IStyleValue<T> styleValue)
		{
			return (styleValue.keyword != StyleKeyword.Undefined) ? string.Format("{0}", styleValue.keyword) : string.Format("{0}", styleValue.value);
		}

		// Token: 0x06001B0A RID: 6922 RVA: 0x0006A510 File Offset: 0x00068710
		internal static YogaValue ToYogaValue(this Length length)
		{
			bool flag = length.IsAuto();
			YogaValue result;
			if (flag)
			{
				result = YogaValue.Auto();
			}
			else
			{
				bool flag2 = length.IsNone();
				if (flag2)
				{
					result = float.NaN;
				}
				else
				{
					LengthUnit unit = length.unit;
					LengthUnit lengthUnit = unit;
					if (lengthUnit != LengthUnit.Pixel)
					{
						if (lengthUnit != LengthUnit.Percent)
						{
							Debug.LogAssertion(string.Format("Unexpected unit '{0}'", length.unit));
							result = float.NaN;
						}
						else
						{
							result = YogaValue.Percent(length.value);
						}
					}
					else
					{
						result = YogaValue.Point(length.value);
					}
				}
			}
			return result;
		}

		// Token: 0x06001B0B RID: 6923 RVA: 0x0006A5A8 File Offset: 0x000687A8
		internal static Length ToLength(this StyleKeyword keyword)
		{
			StyleKeyword styleKeyword = keyword;
			StyleKeyword styleKeyword2 = styleKeyword;
			Length result;
			if (styleKeyword2 != StyleKeyword.Auto)
			{
				if (styleKeyword2 != StyleKeyword.None)
				{
					Debug.LogAssertion("Unexpected StyleKeyword '" + keyword.ToString() + "'");
					result = default(Length);
				}
				else
				{
					result = Length.None();
				}
			}
			else
			{
				result = Length.Auto();
			}
			return result;
		}

		// Token: 0x06001B0C RID: 6924 RVA: 0x0006A608 File Offset: 0x00068808
		internal static Rotate ToRotate(this StyleKeyword keyword)
		{
			StyleKeyword styleKeyword = keyword;
			StyleKeyword styleKeyword2 = styleKeyword;
			Rotate result;
			if (styleKeyword2 != StyleKeyword.None)
			{
				Debug.LogAssertion("Unexpected StyleKeyword '" + keyword.ToString() + "'");
				result = default(Rotate);
			}
			else
			{
				result = Rotate.None();
			}
			return result;
		}

		// Token: 0x06001B0D RID: 6925 RVA: 0x0006A658 File Offset: 0x00068858
		internal static Scale ToScale(this StyleKeyword keyword)
		{
			StyleKeyword styleKeyword = keyword;
			StyleKeyword styleKeyword2 = styleKeyword;
			Scale result;
			if (styleKeyword2 != StyleKeyword.None)
			{
				Debug.LogAssertion("Unexpected StyleKeyword '" + keyword.ToString() + "'");
				result = default(Scale);
			}
			else
			{
				result = Scale.None();
			}
			return result;
		}

		// Token: 0x06001B0E RID: 6926 RVA: 0x0006A6A8 File Offset: 0x000688A8
		internal static Translate ToTranslate(this StyleKeyword keyword)
		{
			StyleKeyword styleKeyword = keyword;
			StyleKeyword styleKeyword2 = styleKeyword;
			Translate result;
			if (styleKeyword2 != StyleKeyword.None)
			{
				Debug.LogAssertion("Unexpected StyleKeyword '" + keyword.ToString() + "'");
				result = default(Translate);
			}
			else
			{
				result = Translate.None();
			}
			return result;
		}

		// Token: 0x06001B0F RID: 6927 RVA: 0x0006A6F8 File Offset: 0x000688F8
		internal static Length ToLength(this StyleLength styleLength)
		{
			StyleKeyword keyword = styleLength.keyword;
			StyleKeyword styleKeyword = keyword;
			Length result;
			if (styleKeyword - StyleKeyword.Auto > 1)
			{
				result = styleLength.value;
			}
			else
			{
				result = styleLength.keyword.ToLength();
			}
			return result;
		}

		// Token: 0x06001B10 RID: 6928 RVA: 0x0006A732 File Offset: 0x00068932
		internal static void CopyFrom<T>(this List<T> list, List<T> other)
		{
			list.Clear();
			list.AddRange(other);
		}
	}
}
