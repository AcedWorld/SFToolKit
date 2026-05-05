using System;
using System.Diagnostics;

namespace UnityEngine.Assertions.Must
{
	// Token: 0x020004F5 RID: 1269
	[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
	[DebuggerStepThrough]
	public static class MustExtensions
	{
		// Token: 0x06002C4B RID: 11339 RVA: 0x0004A778 File Offset: 0x00048978
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustBeTrue(this bool value)
		{
			Assert.IsTrue(value);
		}

		// Token: 0x06002C4C RID: 11340 RVA: 0x0004A782 File Offset: 0x00048982
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustBeTrue(this bool value, string message)
		{
			Assert.IsTrue(value, message);
		}

		// Token: 0x06002C4D RID: 11341 RVA: 0x0004A78D File Offset: 0x0004898D
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustBeFalse(this bool value)
		{
			Assert.IsFalse(value);
		}

		// Token: 0x06002C4E RID: 11342 RVA: 0x0004A797 File Offset: 0x00048997
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		[Conditional("UNITY_ASSERTIONS")]
		public static void MustBeFalse(this bool value, string message)
		{
			Assert.IsFalse(value, message);
		}

		// Token: 0x06002C4F RID: 11343 RVA: 0x0004A7A2 File Offset: 0x000489A2
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustBeApproximatelyEqual(this float actual, float expected)
		{
			Assert.AreApproximatelyEqual(actual, expected);
		}

		// Token: 0x06002C50 RID: 11344 RVA: 0x0004A7AD File Offset: 0x000489AD
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		[Conditional("UNITY_ASSERTIONS")]
		public static void MustBeApproximatelyEqual(this float actual, float expected, string message)
		{
			Assert.AreApproximatelyEqual(actual, expected, message);
		}

		// Token: 0x06002C51 RID: 11345 RVA: 0x0004A7B9 File Offset: 0x000489B9
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustBeApproximatelyEqual(this float actual, float expected, float tolerance)
		{
			Assert.AreApproximatelyEqual(actual, expected, tolerance);
		}

		// Token: 0x06002C52 RID: 11346 RVA: 0x0004A7C5 File Offset: 0x000489C5
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		[Conditional("UNITY_ASSERTIONS")]
		public static void MustBeApproximatelyEqual(this float actual, float expected, float tolerance, string message)
		{
			Assert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		// Token: 0x06002C53 RID: 11347 RVA: 0x0004A7D2 File Offset: 0x000489D2
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustNotBeApproximatelyEqual(this float actual, float expected)
		{
			Assert.AreNotApproximatelyEqual(expected, actual);
		}

		// Token: 0x06002C54 RID: 11348 RVA: 0x0004A7DD File Offset: 0x000489DD
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustNotBeApproximatelyEqual(this float actual, float expected, string message)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, message);
		}

		// Token: 0x06002C55 RID: 11349 RVA: 0x0004A7E9 File Offset: 0x000489E9
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		[Conditional("UNITY_ASSERTIONS")]
		public static void MustNotBeApproximatelyEqual(this float actual, float expected, float tolerance)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, tolerance);
		}

		// Token: 0x06002C56 RID: 11350 RVA: 0x0004A7F5 File Offset: 0x000489F5
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		[Conditional("UNITY_ASSERTIONS")]
		public static void MustNotBeApproximatelyEqual(this float actual, float expected, float tolerance, string message)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		// Token: 0x06002C57 RID: 11351 RVA: 0x0004A802 File Offset: 0x00048A02
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustBeEqual<T>(this T actual, T expected)
		{
			Assert.AreEqual<T>(actual, expected);
		}

		// Token: 0x06002C58 RID: 11352 RVA: 0x0004A80D File Offset: 0x00048A0D
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustBeEqual<T>(this T actual, T expected, string message)
		{
			Assert.AreEqual<T>(expected, actual, message);
		}

		// Token: 0x06002C59 RID: 11353 RVA: 0x0004A819 File Offset: 0x00048A19
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustNotBeEqual<T>(this T actual, T expected)
		{
			Assert.AreNotEqual<T>(actual, expected);
		}

		// Token: 0x06002C5A RID: 11354 RVA: 0x0004A824 File Offset: 0x00048A24
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustNotBeEqual<T>(this T actual, T expected, string message)
		{
			Assert.AreNotEqual<T>(expected, actual, message);
		}

		// Token: 0x06002C5B RID: 11355 RVA: 0x0004A830 File Offset: 0x00048A30
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		[Conditional("UNITY_ASSERTIONS")]
		public static void MustBeNull<T>(this T expected) where T : class
		{
			Assert.IsNull<T>(expected);
		}

		// Token: 0x06002C5C RID: 11356 RVA: 0x0004A83A File Offset: 0x00048A3A
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustBeNull<T>(this T expected, string message) where T : class
		{
			Assert.IsNull<T>(expected, message);
		}

		// Token: 0x06002C5D RID: 11357 RVA: 0x0004A845 File Offset: 0x00048A45
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		[Conditional("UNITY_ASSERTIONS")]
		public static void MustNotBeNull<T>(this T expected) where T : class
		{
			Assert.IsNotNull<T>(expected);
		}

		// Token: 0x06002C5E RID: 11358 RVA: 0x0004A84F File Offset: 0x00048A4F
		[Conditional("UNITY_ASSERTIONS")]
		[Obsolete("Must extensions are deprecated. Use UnityEngine.Assertions.Assert instead")]
		public static void MustNotBeNull<T>(this T expected, string message) where T : class
		{
			Assert.IsNotNull<T>(expected, message);
		}
	}
}
