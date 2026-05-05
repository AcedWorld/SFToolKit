using System;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.Internal.Localization
{
	// Token: 0x02000455 RID: 1109
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class LocalizationManager
	{
		// Token: 0x06002C4D RID: 11341 RVA: 0x00022017 File Offset: 0x00020217
		public static void Initialize()
		{
			if (LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA != null)
			{
				throw new Exception("Already initialized");
			}
			LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA = new LocalizationManager.BmoixDUFxsdIFszFXAYTGDPljlPj();
		}

		// Token: 0x06002C4E RID: 11342 RVA: 0x00022035 File Offset: 0x00020235
		public static void Deinitialize()
		{
			if (LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA != null)
			{
				LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA = null;
			}
		}

		// Token: 0x17000A7F RID: 2687
		// (get) Token: 0x06002C4F RID: 11343 RVA: 0x00022044 File Offset: 0x00020244
		public static bool isEnabled
		{
			get
			{
				return LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA != null && LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.LvwHTdPtYahfjfsnpSuZAWwYnFNl != null;
			}
		}

		// Token: 0x17000A80 RID: 2688
		// (get) Token: 0x06002C50 RID: 11344 RVA: 0x0002205C File Offset: 0x0002025C
		public static uint version
		{
			get
			{
				LocalizationManager.uBERxVfSjQntyoQBlNCZRBbLABMs();
				return LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.pGkXsntoQAEdPHqekLBbnUtjSDMWA;
			}
		}

		// Token: 0x17000A81 RID: 2689
		// (get) Token: 0x06002C51 RID: 11345 RVA: 0x0002206D File Offset: 0x0002026D
		// (set) Token: 0x06002C52 RID: 11346 RVA: 0x0002207E File Offset: 0x0002027E
		public static ILocalizedStringProvider localizedStringProvider
		{
			get
			{
				LocalizationManager.uBERxVfSjQntyoQBlNCZRBbLABMs();
				return LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.LvwHTdPtYahfjfsnpSuZAWwYnFNl;
			}
			set
			{
				LocalizationManager.uBERxVfSjQntyoQBlNCZRBbLABMs();
				LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.gcwJzFycgxodkJTnhGUyfmHnnRFu(value);
			}
		}

		// Token: 0x17000A82 RID: 2690
		// (get) Token: 0x06002C53 RID: 11347 RVA: 0x00022090 File Offset: 0x00020290
		// (set) Token: 0x06002C54 RID: 11348 RVA: 0x000220A1 File Offset: 0x000202A1
		public static bool autoPrefetch
		{
			get
			{
				LocalizationManager.uBERxVfSjQntyoQBlNCZRBbLABMs();
				return LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.zSeFVjfFQkwHGknnPbwQDcKmXrYY;
			}
			set
			{
				LocalizationManager.uBERxVfSjQntyoQBlNCZRBbLABMs();
				LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.HdBwodcZpQGJwCgZHuKyKpsDPgxB(value);
			}
		}

		// Token: 0x06002C55 RID: 11349 RVA: 0x000220B3 File Offset: 0x000202B3
		public static void Add(qRARPoZhenAEzvKQshZvLFcmqQCG obj, ref Id id)
		{
			LocalizationManager.uBERxVfSjQntyoQBlNCZRBbLABMs();
			id = LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.HgaYefWvBTQbMtnlRvHhjTnjGUuR(obj);
		}

		// Token: 0x06002C56 RID: 11350 RVA: 0x000220D0 File Offset: 0x000202D0
		public static bool Remove(ref Id id)
		{
			LocalizationManager.uBERxVfSjQntyoQBlNCZRBbLABMs();
			bool result = LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.AzEqnsSkKUdeiBVAFtatKHorbRIC(id);
			id = 0U;
			return result;
		}

		// Token: 0x06002C57 RID: 11351 RVA: 0x000220F8 File Offset: 0x000202F8
		public static void Prefetch()
		{
			LocalizationManager.uBERxVfSjQntyoQBlNCZRBbLABMs();
			LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.IBCiluytNEzJsIEEnlbgADYLPuOf();
		}

		// Token: 0x06002C58 RID: 11352 RVA: 0x00022109 File Offset: 0x00020309
		public static void Reload()
		{
			LocalizationManager.uBERxVfSjQntyoQBlNCZRBbLABMs();
			LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.ctYJVwGDwKaTDnAZzygzvjqbjuFb();
		}

		// Token: 0x06002C59 RID: 11353 RVA: 0x0002211A File Offset: 0x0002031A
		private static void uBERxVfSjQntyoQBlNCZRBbLABMs()
		{
			if (LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA == null)
			{
				throw new Exception(typeof(LocalizationManager).Name + " is not initialized.");
			}
		}

		// Token: 0x06002C5A RID: 11354 RVA: 0x0009E608 File Offset: 0x0009C808
		public static bool TryGetCachedLocalizedString(LocalizedString localizedString, string fallback, uint localizationVersion, uint dependenciesVersion, out bool localizationVersionChanged, out string result)
		{
			if (LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.LvwHTdPtYahfjfsnpSuZAWwYnFNl == null)
			{
				result = fallback;
				localizationVersionChanged = false;
				return false;
			}
			if (localizedString.TryGetLocalizedValue(null, LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.LvwHTdPtYahfjfsnpSuZAWwYnFNl, LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.pGkXsntoQAEdPHqekLBbnUtjSDMWA, dependenciesVersion, out localizationVersionChanged, out result))
			{
				return true;
			}
			result = fallback;
			return false;
		}

		// Token: 0x06002C5B RID: 11355 RVA: 0x0009E654 File Offset: 0x0009C854
		public static bool TryLocalizeString(LocalizedString localizedString, string key, uint localizationVersion, uint dependenciesVersion, out string result)
		{
			if (LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.LvwHTdPtYahfjfsnpSuZAWwYnFNl != null)
			{
				localizedString.Clear();
				bool flag;
				return localizedString.TryGetLocalizedValue(key, LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.LvwHTdPtYahfjfsnpSuZAWwYnFNl, LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.pGkXsntoQAEdPHqekLBbnUtjSDMWA, dependenciesVersion, out flag, out result);
			}
			result = null;
			return false;
		}

		// Token: 0x06002C5C RID: 11356 RVA: 0x0009E69C File Offset: 0x0009C89C
		public static LocalizationManager.GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, IReadOnlyList<string> parentKeys, string keyCategory, string fallback, out string result)
		{
			if (LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.LvwHTdPtYahfjfsnpSuZAWwYnFNl == null)
			{
				result = fallback;
				return LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			bool flag;
			LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags;
			if (LocalizationManager.TryGetCachedLocalizedString(localizedString, fallback, LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.pGkXsntoQAEdPHqekLBbnUtjSDMWA, 0U, out flag, out result))
			{
				getAndUpdateLocalizedStringResultFlags = LocalizationManager.GetAndUpdateLocalizedStringResultFlags.IsCachedValue;
			}
			else
			{
				getAndUpdateLocalizedStringResultFlags = LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			if (!localizedString.hasCachedValue || flag)
			{
				getAndUpdateLocalizedStringResultFlags |= LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed;
				if (LocalizationManager.NQOWCHAGsmpDebOAvbKdDkuQlreI(localizedString, parentKeys, keyCategory, fallback, out result))
				{
					getAndUpdateLocalizedStringResultFlags |= LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized;
					getAndUpdateLocalizedStringResultFlags &= (LocalizationManager.GetAndUpdateLocalizedStringResultFlags)(-2);
				}
				else
				{
					getAndUpdateLocalizedStringResultFlags |= LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Failed;
				}
			}
			return getAndUpdateLocalizedStringResultFlags;
		}

		// Token: 0x06002C5D RID: 11357 RVA: 0x0009E708 File Offset: 0x0009C908
		public static LocalizationManager.GetAndUpdateLocalizedStringResultFlags GetAndUpdateLocalizedString(LocalizedString localizedString, string key, string keyCategory, IReadOnlyList<string> parentKeys, string fallback, out string result)
		{
			if (LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.LvwHTdPtYahfjfsnpSuZAWwYnFNl == null)
			{
				result = fallback;
				return LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			bool flag;
			LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags;
			if (LocalizationManager.TryGetCachedLocalizedString(localizedString, fallback, LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.pGkXsntoQAEdPHqekLBbnUtjSDMWA, 0U, out flag, out result))
			{
				getAndUpdateLocalizedStringResultFlags = LocalizationManager.GetAndUpdateLocalizedStringResultFlags.IsCachedValue;
			}
			else
			{
				getAndUpdateLocalizedStringResultFlags = LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Failed;
			}
			if (!localizedString.hasCachedValue || flag)
			{
				getAndUpdateLocalizedStringResultFlags |= LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed;
				if (LocalizationManager.hFBwCYxeJSGzHHweEaDdzDBryqxE(localizedString, key, keyCategory, fallback, parentKeys, out result))
				{
					getAndUpdateLocalizedStringResultFlags |= LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized;
					getAndUpdateLocalizedStringResultFlags &= (LocalizationManager.GetAndUpdateLocalizedStringResultFlags)(-2);
				}
				else
				{
					getAndUpdateLocalizedStringResultFlags |= LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Failed;
				}
			}
			return getAndUpdateLocalizedStringResultFlags;
		}

		// Token: 0x06002C5E RID: 11358 RVA: 0x0009E778 File Offset: 0x0009C978
		private static bool NQOWCHAGsmpDebOAvbKdDkuQlreI(LocalizedString A_0, IReadOnlyList<string> A_1, string A_2, string A_3, out string A_4)
		{
			if (A_1 == null)
			{
				A_4 = A_3;
				return false;
			}
			bool result = false;
			bool flag = !string.IsNullOrEmpty(A_2);
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			for (int i = 0; i < A_1.Count; i++)
			{
				if (!string.IsNullOrEmpty(A_1[i]))
				{
					sharedStringBuilder.Length = 0;
					if (flag)
					{
						sharedStringBuilder.Append(A_2);
					}
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_1[i]);
					if (LocalizationManager.TryLocalizeString(A_0, sharedStringBuilder.ToString(), LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.pGkXsntoQAEdPHqekLBbnUtjSDMWA, 0U, out A_4))
					{
						result = true;
						IL_7D:
						A_0.cachedValue = A_4;
						return result;
					}
				}
			}
			A_4 = A_3;
			goto IL_7D;
		}

		// Token: 0x06002C5F RID: 11359 RVA: 0x0009E80C File Offset: 0x0009CA0C
		private static bool hFBwCYxeJSGzHHweEaDdzDBryqxE(LocalizedString A_0, string A_1, string A_2, string A_3, IReadOnlyList<string> A_4, out string A_5)
		{
			if (string.IsNullOrEmpty(A_1))
			{
				A_5 = A_3;
				return false;
			}
			bool result = false;
			uint dependenciesVersion = 0U;
			bool flag = !string.IsNullOrEmpty(A_2);
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			if (A_4 != null)
			{
				for (int i = 0; i < A_4.Count; i++)
				{
					if (!string.IsNullOrEmpty(A_4[i]))
					{
						sharedStringBuilder.Length = 0;
						if (flag)
						{
							sharedStringBuilder.Append(A_2);
						}
						LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_4[i]);
						LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_1);
						if (LocalizationManager.TryLocalizeString(A_0, sharedStringBuilder.ToString(), LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.pGkXsntoQAEdPHqekLBbnUtjSDMWA, dependenciesVersion, out A_5))
						{
							result = true;
							goto IL_DF;
						}
					}
				}
			}
			if (A_4 == null || A_4.Count == 0)
			{
				sharedStringBuilder.Length = 0;
				if (flag)
				{
					sharedStringBuilder.Append(A_2);
				}
				LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_1);
				if (LocalizationManager.TryLocalizeString(A_0, sharedStringBuilder.ToString(), LocalizationManager.CTtRgHGzdjnuxMrjjhSDfnAJGFEKA.pGkXsntoQAEdPHqekLBbnUtjSDMWA, dependenciesVersion, out A_5))
				{
					result = true;
					goto IL_DF;
				}
			}
			A_5 = A_3;
			IL_DF:
			A_0.cachedValue = A_5;
			return result;
		}

		// Token: 0x06002C60 RID: 11360 RVA: 0x00022142 File Offset: 0x00020342
		public static string ConcatenateKeyStrings(string a, string b)
		{
			if (string.IsNullOrEmpty(a))
			{
				return b;
			}
			if (string.IsNullOrEmpty(b))
			{
				return a;
			}
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			sharedStringBuilder.Append(a);
			sharedStringBuilder.Append('_');
			sharedStringBuilder.Append(b);
			return sharedStringBuilder.ToString();
		}

		// Token: 0x06002C61 RID: 11361 RVA: 0x0002217B File Offset: 0x0002037B
		public static string AppendToKeyAsPath(string a, string b)
		{
			if (string.IsNullOrEmpty(a))
			{
				return b;
			}
			if (string.IsNullOrEmpty(b))
			{
				return a;
			}
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			sharedStringBuilder.Append(a);
			sharedStringBuilder.Append('/');
			sharedStringBuilder.Append(b);
			return sharedStringBuilder.ToString();
		}

		// Token: 0x06002C62 RID: 11362 RVA: 0x000221B4 File Offset: 0x000203B4
		public static StringBuilder AppendToKeyAsPath(StringBuilder sb, string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return sb;
			}
			if (sb.Length > 0)
			{
				sb.Append('/');
			}
			sb.Append(value);
			return sb;
		}

		// Token: 0x06002C63 RID: 11363 RVA: 0x000221DB File Offset: 0x000203DB
		public static string AppendToKeyAxisPole(string a, Pole pole)
		{
			if (string.IsNullOrEmpty(a))
			{
				return string.Empty;
			}
			return LocalizationManager.AppendToKeyAsPath(a, (pole == Pole.Positive) ? "positive" : "negative");
		}

		// Token: 0x06002C64 RID: 11364 RVA: 0x00022200 File Offset: 0x00020400
		public static string AppendToNameAxisPole(string text, Pole pole)
		{
			if (pole == Pole.Positive)
			{
				return text + " +";
			}
			if (pole != Pole.Negative)
			{
				return text;
			}
			return text + " -";
		}

		// Token: 0x06002C65 RID: 11365 RVA: 0x00022224 File Offset: 0x00020424
		public static string AppendToKeyAxisDirection(string a, AxisDirection direction)
		{
			if (string.IsNullOrEmpty(a))
			{
				return string.Empty;
			}
			return LocalizationManager.AppendToKeyAsPath(a, (direction == AxisDirection.Vertical) ? "vertical" : "horizontal");
		}

		// Token: 0x06002C66 RID: 11366 RVA: 0x00022249 File Offset: 0x00020449
		public static string AppendToNameAxisDirection(string a, AxisDirection direction)
		{
			if (string.IsNullOrEmpty(a))
			{
				return string.Empty;
			}
			return a + " " + ((direction == AxisDirection.Vertical) ? "Vertical" : "Horizontal");
		}

		// Token: 0x06002C67 RID: 11367 RVA: 0x00022273 File Offset: 0x00020473
		public static string FormatKey(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			return StringTools.AddSpacesToCamelCase(text).Replace(' ', '_').ToLowerInvariant();
		}

		// Token: 0x06002C68 RID: 11368 RVA: 0x00022293 File Offset: 0x00020493
		[CustomObfuscation(rename = false)]
		public static StringBuilder GetSharedStringBuilder()
		{
			if (LocalizationManager.fMqQHjXnNLIzxEmEFfkAEJrgUYUFc != null)
			{
				LocalizationManager.fMqQHjXnNLIzxEmEFfkAEJrgUYUFc.Length = 0;
				return LocalizationManager.fMqQHjXnNLIzxEmEFfkAEJrgUYUFc;
			}
			return LocalizationManager.fMqQHjXnNLIzxEmEFfkAEJrgUYUFc = new StringBuilder();
		}

		// Token: 0x04001925 RID: 6437
		private const char HPEVbnlCkIurAsGcaPcwcDHBAgAi = '_';

		// Token: 0x04001926 RID: 6438
		private const char vnrWnDuKPKgZUlAYfcaAwBzDRwHL = '/';

		// Token: 0x04001927 RID: 6439
		private const string GLMxhepqREBKUdZCYfHgUfDatPEWA = "/";

		// Token: 0x04001928 RID: 6440
		internal const string hardwareTypeKey_universalKeyboard = "keyboard";

		// Token: 0x04001929 RID: 6441
		internal const string hardwareTypeKey_universalMouse = "mouse";

		// Token: 0x0400192A RID: 6442
		internal const string hardwareTypeKey_unknownController = "unknown_controller";

		// Token: 0x0400192B RID: 6443
		internal const string localizationKeyAxisPoleSuffix_positive = "positive";

		// Token: 0x0400192C RID: 6444
		internal const string localizationKeyAxisPoleSuffix_negative = "negative";

		// Token: 0x0400192D RID: 6445
		internal const string localizationKeyAxisDirectionSuffix_horizontal = "horizontal";

		// Token: 0x0400192E RID: 6446
		internal const string localizationKeyAxisDirectionSuffix_vertical = "vertical";

		// Token: 0x0400192F RID: 6447
		internal const string localizationAndGlyphKeyCategory_controller = "controller";

		// Token: 0x04001930 RID: 6448
		internal const string localizationAndGlyphKeyCategory_customController = "controller/custom";

		// Token: 0x04001931 RID: 6449
		internal const string localizationAndGlyphKeyCategory_controllerTemplate = "controller/template";

		// Token: 0x04001932 RID: 6450
		internal const string localizationAndGlyphKeyCategory_action = "action";

		// Token: 0x04001933 RID: 6451
		internal const string localizationAndGlyphKeyCategory_inputActionCategory = "action/category";

		// Token: 0x04001934 RID: 6452
		internal const string localizationAndGlyphKeyCategory_controllerMap = "controller_map";

		// Token: 0x04001935 RID: 6453
		internal const string localizationAndGlyphKeyCategory_controllerMapCategory = "controller_map/category";

		// Token: 0x04001936 RID: 6454
		internal const string localizationAndGlyphKeyCategory_layout = "controller_map/layout";

		// Token: 0x04001937 RID: 6455
		internal const string localizationAndGlyphKeyCategory_player = "player";

		// Token: 0x04001938 RID: 6456
		internal const string localizationAndGlyphKeyCategory_controllerElement = "controller/element";

		// Token: 0x04001939 RID: 6457
		internal const string nonLocalizedDisplayNameAxisDirectionSuffix_horizontal = "Horizontal";

		// Token: 0x0400193A RID: 6458
		internal const string nonLocalizedDisplayNameAxisDirectionSuffix_vertical = "Vertical";

		// Token: 0x0400193B RID: 6459
		private static LocalizationManager.BmoixDUFxsdIFszFXAYTGDPljlPj CTtRgHGzdjnuxMrjjhSDfnAJGFEKA;

		// Token: 0x0400193C RID: 6460
		private static StringBuilder fMqQHjXnNLIzxEmEFfkAEJrgUYUFc;

		// Token: 0x02000456 RID: 1110
		private sealed class BmoixDUFxsdIFszFXAYTGDPljlPj
		{
			// Token: 0x06002C69 RID: 11369 RVA: 0x0009E904 File Offset: 0x0009CB04
			public BmoixDUFxsdIFszFXAYTGDPljlPj()
			{
				this.AEVqypbEgyqIEZpfcaTUnBzUxKVP = new RvmIJGbAvRTGQGQgDEFpplYzZpWu<qRARPoZhenAEzvKQshZvLFcmqQCG>(60f);
				this.pGkXsntoQAEdPHqekLBbnUtjSDMWA = 0U;
				this.rTxaJrgsaMQNmuLkjAkTdJsBFCtnc = 1U;
			}

			// Token: 0x06002C6A RID: 11370 RVA: 0x000222B8 File Offset: 0x000204B8
			public void gcwJzFycgxodkJTnhGUyfmHnnRFu(ILocalizedStringProvider A_1)
			{
				this.LvwHTdPtYahfjfsnpSuZAWwYnFNl = A_1;
				if (A_1 != null)
				{
					this.pGkXsntoQAEdPHqekLBbnUtjSDMWA = this.rTxaJrgsaMQNmuLkjAkTdJsBFCtnc.id;
					this.rTxaJrgsaMQNmuLkjAkTdJsBFCtnc.Increment();
				}
				else
				{
					this.pGkXsntoQAEdPHqekLBbnUtjSDMWA = 0U;
				}
				this.VameCJiBnzCvWqFnMtrNdYAeiATeA();
			}

			// Token: 0x06002C6B RID: 11371 RVA: 0x000222EF File Offset: 0x000204EF
			public void HdBwodcZpQGJwCgZHuKyKpsDPgxB(bool A_1)
			{
				if (A_1 == this.zSeFVjfFQkwHGknnPbwQDcKmXrYY)
				{
					return;
				}
				this.zSeFVjfFQkwHGknnPbwQDcKmXrYY = A_1;
				if (A_1)
				{
					this.IBCiluytNEzJsIEEnlbgADYLPuOf();
				}
			}

			// Token: 0x06002C6C RID: 11372 RVA: 0x0002230B File Offset: 0x0002050B
			public void IBCiluytNEzJsIEEnlbgADYLPuOf()
			{
				if (this.LvwHTdPtYahfjfsnpSuZAWwYnFNl == null)
				{
					return;
				}
				this.AEVqypbEgyqIEZpfcaTUnBzUxKVP.zAXkItAZChRgPbCJeFkkCtqIPkzMA(this.CSlnfQROAOjGeNYxqXOzvblHdHHL);
			}

			// Token: 0x06002C6D RID: 11373 RVA: 0x00022327 File Offset: 0x00020527
			public void ctYJVwGDwKaTDnAZzygzvjqbjuFb()
			{
				if (this.LvwHTdPtYahfjfsnpSuZAWwYnFNl == null)
				{
					return;
				}
				this.pGkXsntoQAEdPHqekLBbnUtjSDMWA = this.rTxaJrgsaMQNmuLkjAkTdJsBFCtnc.id;
				this.rTxaJrgsaMQNmuLkjAkTdJsBFCtnc.Increment();
				if (this.zSeFVjfFQkwHGknnPbwQDcKmXrYY)
				{
					this.IBCiluytNEzJsIEEnlbgADYLPuOf();
					return;
				}
				this.VameCJiBnzCvWqFnMtrNdYAeiATeA();
			}

			// Token: 0x06002C6E RID: 11374 RVA: 0x00022363 File Offset: 0x00020563
			public uint HgaYefWvBTQbMtnlRvHhjTnjGUuR(qRARPoZhenAEzvKQshZvLFcmqQCG A_1)
			{
				return this.AEVqypbEgyqIEZpfcaTUnBzUxKVP.aMahfZqbBrbegzXkZEXwZfqhtBZj(A_1);
			}

			// Token: 0x06002C6F RID: 11375 RVA: 0x00022371 File Offset: 0x00020571
			public bool AzEqnsSkKUdeiBVAFtatKHorbRIC(uint A_1)
			{
				return this.AEVqypbEgyqIEZpfcaTUnBzUxKVP.rzTgCniDYAFMijOABRyLzSxcXWZjB(A_1);
			}

			// Token: 0x06002C70 RID: 11376 RVA: 0x0002237F File Offset: 0x0002057F
			public void VameCJiBnzCvWqFnMtrNdYAeiATeA()
			{
				this.AEVqypbEgyqIEZpfcaTUnBzUxKVP.JzGoTFqpGdYkTUxcryLnTUHbIotE();
			}

			// Token: 0x0400193D RID: 6461
			private const float RHaMNaRyMeivPoUnUBHsLkitOEtp = 60f;

			// Token: 0x0400193E RID: 6462
			private readonly RvmIJGbAvRTGQGQgDEFpplYzZpWu<qRARPoZhenAEzvKQshZvLFcmqQCG> AEVqypbEgyqIEZpfcaTUnBzUxKVP;

			// Token: 0x0400193F RID: 6463
			public bool zSeFVjfFQkwHGknnPbwQDcKmXrYY;

			// Token: 0x04001940 RID: 6464
			public ILocalizedStringProvider LvwHTdPtYahfjfsnpSuZAWwYnFNl;

			// Token: 0x04001941 RID: 6465
			public uint pGkXsntoQAEdPHqekLBbnUtjSDMWA;

			// Token: 0x04001942 RID: 6466
			private Action<qRARPoZhenAEzvKQshZvLFcmqQCG> CSlnfQROAOjGeNYxqXOzvblHdHHL = new Action<qRARPoZhenAEzvKQshZvLFcmqQCG>(LocalizationManager.BmoixDUFxsdIFszFXAYTGDPljlPj.NDoXRSKKycMJcdUUbKAwKjAmLji.<>9.biwEcFdJdWflkifuZQzpKCqTHcWE);

			// Token: 0x04001943 RID: 6467
			private Id rTxaJrgsaMQNmuLkjAkTdJsBFCtnc;

			// Token: 0x02000457 RID: 1111
			[CompilerGenerated]
			[Serializable]
			private sealed class NDoXRSKKycMJcdUUbKAwKjAmLji
			{
				// Token: 0x06002C73 RID: 11379 RVA: 0x00022398 File Offset: 0x00020598
				internal void biwEcFdJdWflkifuZQzpKCqTHcWE(qRARPoZhenAEzvKQshZvLFcmqQCG A_1)
				{
					A_1.Localize();
				}

				// Token: 0x04001944 RID: 6468
				public static readonly LocalizationManager.BmoixDUFxsdIFszFXAYTGDPljlPj.NDoXRSKKycMJcdUUbKAwKjAmLji <>9 = new LocalizationManager.BmoixDUFxsdIFszFXAYTGDPljlPj.NDoXRSKKycMJcdUUbKAwKjAmLji();

				// Token: 0x04001945 RID: 6469
				public static Action<qRARPoZhenAEzvKQshZvLFcmqQCG> <>9__7_0;
			}
		}

		// Token: 0x02000458 RID: 1112
		[CustomObfuscation(rename = false)]
		public enum GetAndUpdateLocalizedStringResultFlags
		{
			// Token: 0x04001947 RID: 6471
			None,
			// Token: 0x04001948 RID: 6472
			Failed,
			// Token: 0x04001949 RID: 6473
			IsCachedValue,
			// Token: 0x0400194A RID: 6474
			Changed = 4,
			// Token: 0x0400194B RID: 6475
			JustLocalized = 8
		}
	}
}
