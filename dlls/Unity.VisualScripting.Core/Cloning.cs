using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200000E RID: 14
	public static class Cloning
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00002804 File Offset: 0x00000A04
		static Cloning()
		{
			Cloning.cloners.Add(Cloning.arrayCloner);
			Cloning.cloners.Add(Cloning.dictionaryCloner);
			Cloning.cloners.Add(Cloning.enumerableCloner);
			Cloning.cloners.Add(Cloning.listCloner);
			Cloning.cloners.Add(Cloning.animationCurveCloner);
			Cloning.cloners.Add(Cloning.gradientCloner);
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000036 RID: 54 RVA: 0x000028D5 File Offset: 0x00000AD5
		public static HashSet<ICloner> cloners { get; } = new HashSet<ICloner>();

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000028DC File Offset: 0x00000ADC
		public static ArrayCloner arrayCloner { get; } = new ArrayCloner();

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000038 RID: 56 RVA: 0x000028E3 File Offset: 0x00000AE3
		public static DictionaryCloner dictionaryCloner { get; } = new DictionaryCloner();

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000028EA File Offset: 0x00000AEA
		public static EnumerableCloner enumerableCloner { get; } = new EnumerableCloner();

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600003A RID: 58 RVA: 0x000028F1 File Offset: 0x00000AF1
		public static ListCloner listCloner { get; } = new ListCloner();

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000028F8 File Offset: 0x00000AF8
		public static AnimationCurveCloner animationCurveCloner { get; } = new AnimationCurveCloner();

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600003C RID: 60 RVA: 0x000028FF File Offset: 0x00000AFF
		internal static GradientCloner gradientCloner { get; } = new GradientCloner();

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002906 File Offset: 0x00000B06
		public static FieldsCloner fieldsCloner { get; } = new FieldsCloner();

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003E RID: 62 RVA: 0x0000290D File Offset: 0x00000B0D
		public static FakeSerializationCloner fakeSerializationCloner { get; } = new FakeSerializationCloner();

		// Token: 0x0600003F RID: 63 RVA: 0x00002914 File Offset: 0x00000B14
		public static object Clone(this object original, ICloner fallbackCloner, bool tryPreserveInstances)
		{
			object result;
			using (CloningContext cloningContext = CloningContext.New(fallbackCloner, tryPreserveInstances))
			{
				result = Cloning.Clone(cloningContext, original);
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002950 File Offset: 0x00000B50
		public static T Clone<T>(this T original, ICloner fallbackCloner, bool tryPreserveInstances)
		{
			return (T)((object)original.Clone(fallbackCloner, tryPreserveInstances));
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002964 File Offset: 0x00000B64
		public static object CloneViaFakeSerialization(this object original)
		{
			return original.Clone(Cloning.fakeSerializationCloner, true);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002972 File Offset: 0x00000B72
		public static T CloneViaFakeSerialization<T>(this T original)
		{
			return (T)((object)original.CloneViaFakeSerialization());
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002984 File Offset: 0x00000B84
		internal static object Clone(CloningContext context, object original)
		{
			object result = null;
			Cloning.CloneInto(context, ref result, original);
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000029A0 File Offset: 0x00000BA0
		internal static void CloneInto(CloningContext context, ref object clone, object original)
		{
			if (original == null)
			{
				clone = null;
				return;
			}
			Type type = original.GetType();
			if (Cloning.Skippable(type))
			{
				clone = original;
				return;
			}
			if (context.clonings.ContainsKey(original))
			{
				clone = context.clonings[original];
				return;
			}
			ICloner cloner = Cloning.GetCloner(original, type, context.fallbackCloner);
			if (clone == null)
			{
				clone = cloner.ConstructClone(type, original);
			}
			context.clonings.Add(original, clone);
			cloner.BeforeClone(type, original);
			cloner.FillClone(type, ref clone, original, context);
			cloner.AfterClone(type, clone);
			context.clonings[original] = clone;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002A38 File Offset: 0x00000C38
		[CanBeNull]
		public static ICloner GetCloner(object original, Type type)
		{
			ISpecifiesCloner specifiesCloner = original as ISpecifiesCloner;
			if (specifiesCloner != null)
			{
				return specifiesCloner.cloner;
			}
			return Cloning.cloners.FirstOrDefault((ICloner cloner) => cloner.Handles(type));
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002A7C File Offset: 0x00000C7C
		private static ICloner GetCloner(object original, Type type, ICloner fallbackCloner)
		{
			ICloner cloner = Cloning.GetCloner(original, type);
			if (cloner != null)
			{
				return cloner;
			}
			Ensure.That("fallbackCloner").IsNotNull<ICloner>(fallbackCloner);
			return fallbackCloner;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002AA8 File Offset: 0x00000CA8
		private static bool Skippable(Type type)
		{
			bool flag;
			if (!Cloning.skippable.TryGetValue(type, out flag))
			{
				flag = (type.IsValueType || type == typeof(string) || typeof(Type).IsAssignableFrom(type) || typeof(Object).IsAssignableFrom(type));
				Cloning.skippable.Add(type, flag);
			}
			return flag;
		}

		// Token: 0x04000005 RID: 5
		private static readonly Dictionary<Type, bool> skippable = new Dictionary<Type, bool>();
	}
}
