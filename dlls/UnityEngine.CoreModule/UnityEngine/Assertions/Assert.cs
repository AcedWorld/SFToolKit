using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine.Assertions.Comparers;

namespace UnityEngine.Assertions
{
	// Token: 0x020004F2 RID: 1266
	[DebuggerStepThrough]
	public static class Assert
	{
		// Token: 0x06002C01 RID: 11265 RVA: 0x00049CE4 File Offset: 0x00047EE4
		private static void Fail(string message, string userMessage)
		{
			bool flag = !Assert.raiseExceptions;
			if (flag)
			{
				bool flag2 = message == null;
				if (flag2)
				{
					message = "Assertion has failed\n";
				}
				bool flag3 = userMessage != null;
				if (flag3)
				{
					message = userMessage + "\n" + message;
				}
				Debug.LogAssertion(message);
				return;
			}
			throw new AssertionException(message, userMessage);
		}

		// Token: 0x06002C02 RID: 11266 RVA: 0x00049D35 File Offset: 0x00047F35
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Assert.Equals should not be used for Assertions", true)]
		public new static bool Equals(object obj1, object obj2)
		{
			throw new InvalidOperationException("Assert.Equals should not be used for Assertions");
		}

		// Token: 0x06002C03 RID: 11267 RVA: 0x00049D42 File Offset: 0x00047F42
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Assert.ReferenceEquals should not be used for Assertions", true)]
		public new static bool ReferenceEquals(object obj1, object obj2)
		{
			throw new InvalidOperationException("Assert.ReferenceEquals should not be used for Assertions");
		}

		// Token: 0x06002C04 RID: 11268 RVA: 0x00049D50 File Offset: 0x00047F50
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsTrue(bool condition)
		{
			bool flag = !condition;
			if (flag)
			{
				Assert.IsTrue(condition, null);
			}
		}

		// Token: 0x06002C05 RID: 11269 RVA: 0x00049D70 File Offset: 0x00047F70
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsTrue(bool condition, string message)
		{
			bool flag = !condition;
			if (flag)
			{
				Assert.Fail(AssertionMessageUtil.BooleanFailureMessage(true), message);
			}
		}

		// Token: 0x06002C06 RID: 11270 RVA: 0x00049D94 File Offset: 0x00047F94
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsFalse(bool condition)
		{
			if (condition)
			{
				Assert.IsFalse(condition, null);
			}
		}

		// Token: 0x06002C07 RID: 11271 RVA: 0x00049DB0 File Offset: 0x00047FB0
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsFalse(bool condition, string message)
		{
			if (condition)
			{
				Assert.Fail(AssertionMessageUtil.BooleanFailureMessage(false), message);
			}
		}

		// Token: 0x06002C08 RID: 11272 RVA: 0x00049DD0 File Offset: 0x00047FD0
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreApproximatelyEqual(float expected, float actual)
		{
			Assert.AreEqual<float>(expected, actual, null, FloatComparer.s_ComparerWithDefaultTolerance);
		}

		// Token: 0x06002C09 RID: 11273 RVA: 0x00049DE1 File Offset: 0x00047FE1
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreApproximatelyEqual(float expected, float actual, string message)
		{
			Assert.AreEqual<float>(expected, actual, message, FloatComparer.s_ComparerWithDefaultTolerance);
		}

		// Token: 0x06002C0A RID: 11274 RVA: 0x00049DF2 File Offset: 0x00047FF2
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreApproximatelyEqual(float expected, float actual, float tolerance)
		{
			Assert.AreApproximatelyEqual(expected, actual, tolerance, null);
		}

		// Token: 0x06002C0B RID: 11275 RVA: 0x00049DFF File Offset: 0x00047FFF
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message)
		{
			Assert.AreEqual<float>(expected, actual, message, new FloatComparer(tolerance));
		}

		// Token: 0x06002C0C RID: 11276 RVA: 0x00049E11 File Offset: 0x00048011
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotApproximatelyEqual(float expected, float actual)
		{
			Assert.AreNotEqual<float>(expected, actual, null, FloatComparer.s_ComparerWithDefaultTolerance);
		}

		// Token: 0x06002C0D RID: 11277 RVA: 0x00049E22 File Offset: 0x00048022
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotApproximatelyEqual(float expected, float actual, string message)
		{
			Assert.AreNotEqual<float>(expected, actual, message, FloatComparer.s_ComparerWithDefaultTolerance);
		}

		// Token: 0x06002C0E RID: 11278 RVA: 0x00049E33 File Offset: 0x00048033
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, tolerance, null);
		}

		// Token: 0x06002C0F RID: 11279 RVA: 0x00049E40 File Offset: 0x00048040
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message)
		{
			Assert.AreNotEqual<float>(expected, actual, message, new FloatComparer(tolerance));
		}

		// Token: 0x06002C10 RID: 11280 RVA: 0x00049E52 File Offset: 0x00048052
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual<T>(T expected, T actual)
		{
			Assert.AreEqual<T>(expected, actual, null);
		}

		// Token: 0x06002C11 RID: 11281 RVA: 0x00049E5E File Offset: 0x0004805E
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual<T>(T expected, T actual, string message)
		{
			Assert.AreEqual<T>(expected, actual, message, EqualityComparer<T>.Default);
		}

		// Token: 0x06002C12 RID: 11282 RVA: 0x00049E70 File Offset: 0x00048070
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual<T>(T expected, T actual, string message, IEqualityComparer<T> comparer)
		{
			bool flag = typeof(Object).IsAssignableFrom(typeof(T));
			if (flag)
			{
				Assert.AreEqual(expected as Object, actual as Object, message);
			}
			else
			{
				bool flag2 = !comparer.Equals(actual, expected);
				if (flag2)
				{
					Assert.Fail(AssertionMessageUtil.GetEqualityMessage(actual, expected, true), message);
				}
			}
		}

		// Token: 0x06002C13 RID: 11283 RVA: 0x00049EE4 File Offset: 0x000480E4
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(Object expected, Object actual, string message)
		{
			bool flag = actual != expected;
			if (flag)
			{
				Assert.Fail(AssertionMessageUtil.GetEqualityMessage(actual, expected, true), message);
			}
		}

		// Token: 0x06002C14 RID: 11284 RVA: 0x00049F0C File Offset: 0x0004810C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual<T>(T expected, T actual)
		{
			Assert.AreNotEqual<T>(expected, actual, null);
		}

		// Token: 0x06002C15 RID: 11285 RVA: 0x00049F18 File Offset: 0x00048118
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual<T>(T expected, T actual, string message)
		{
			Assert.AreNotEqual<T>(expected, actual, message, EqualityComparer<T>.Default);
		}

		// Token: 0x06002C16 RID: 11286 RVA: 0x00049F2C File Offset: 0x0004812C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual<T>(T expected, T actual, string message, IEqualityComparer<T> comparer)
		{
			bool flag = typeof(Object).IsAssignableFrom(typeof(T));
			if (flag)
			{
				Assert.AreNotEqual(expected as Object, actual as Object, message);
			}
			else
			{
				bool flag2 = comparer.Equals(actual, expected);
				if (flag2)
				{
					Assert.Fail(AssertionMessageUtil.GetEqualityMessage(actual, expected, false), message);
				}
			}
		}

		// Token: 0x06002C17 RID: 11287 RVA: 0x00049F9C File Offset: 0x0004819C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(Object expected, Object actual, string message)
		{
			bool flag = actual == expected;
			if (flag)
			{
				Assert.Fail(AssertionMessageUtil.GetEqualityMessage(actual, expected, false), message);
			}
		}

		// Token: 0x06002C18 RID: 11288 RVA: 0x00049FC4 File Offset: 0x000481C4
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNull<T>(T value) where T : class
		{
			Assert.IsNull<T>(value, null);
		}

		// Token: 0x06002C19 RID: 11289 RVA: 0x00049FD0 File Offset: 0x000481D0
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNull<T>(T value, string message) where T : class
		{
			bool flag = typeof(Object).IsAssignableFrom(typeof(T));
			if (flag)
			{
				Assert.IsNull(value as Object, message);
			}
			else
			{
				bool flag2 = value != null;
				if (flag2)
				{
					Assert.Fail(AssertionMessageUtil.NullFailureMessage(value, true), message);
				}
			}
		}

		// Token: 0x06002C1A RID: 11290 RVA: 0x0004A034 File Offset: 0x00048234
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNull(Object value, string message)
		{
			bool flag = value != null;
			if (flag)
			{
				Assert.Fail(AssertionMessageUtil.NullFailureMessage(value, true), message);
			}
		}

		// Token: 0x06002C1B RID: 11291 RVA: 0x0004A05B File Offset: 0x0004825B
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNotNull<T>(T value) where T : class
		{
			Assert.IsNotNull<T>(value, null);
		}

		// Token: 0x06002C1C RID: 11292 RVA: 0x0004A068 File Offset: 0x00048268
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNotNull<T>(T value, string message) where T : class
		{
			bool flag = typeof(Object).IsAssignableFrom(typeof(T));
			if (flag)
			{
				Assert.IsNotNull(value as Object, message);
			}
			else
			{
				bool flag2 = value == null;
				if (flag2)
				{
					Assert.Fail(AssertionMessageUtil.NullFailureMessage(value, false), message);
				}
			}
		}

		// Token: 0x06002C1D RID: 11293 RVA: 0x0004A0CC File Offset: 0x000482CC
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNotNull(Object value, string message)
		{
			bool flag = value == null;
			if (flag)
			{
				Assert.Fail(AssertionMessageUtil.NullFailureMessage(value, false), message);
			}
		}

		// Token: 0x06002C1E RID: 11294 RVA: 0x0004A0F4 File Offset: 0x000482F4
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(sbyte expected, sbyte actual)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<sbyte>(expected, actual, null);
			}
		}

		// Token: 0x06002C1F RID: 11295 RVA: 0x0004A118 File Offset: 0x00048318
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(sbyte expected, sbyte actual, string message)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<sbyte>(expected, actual, message);
			}
		}

		// Token: 0x06002C20 RID: 11296 RVA: 0x0004A13C File Offset: 0x0004833C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(sbyte expected, sbyte actual)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<sbyte>(expected, actual, null);
			}
		}

		// Token: 0x06002C21 RID: 11297 RVA: 0x0004A15C File Offset: 0x0004835C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(sbyte expected, sbyte actual, string message)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<sbyte>(expected, actual, message);
			}
		}

		// Token: 0x06002C22 RID: 11298 RVA: 0x0004A17C File Offset: 0x0004837C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(byte expected, byte actual)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<byte>(expected, actual, null);
			}
		}

		// Token: 0x06002C23 RID: 11299 RVA: 0x0004A1A0 File Offset: 0x000483A0
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(byte expected, byte actual, string message)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<byte>(expected, actual, message);
			}
		}

		// Token: 0x06002C24 RID: 11300 RVA: 0x0004A1C4 File Offset: 0x000483C4
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(byte expected, byte actual)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<byte>(expected, actual, null);
			}
		}

		// Token: 0x06002C25 RID: 11301 RVA: 0x0004A1E4 File Offset: 0x000483E4
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(byte expected, byte actual, string message)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<byte>(expected, actual, message);
			}
		}

		// Token: 0x06002C26 RID: 11302 RVA: 0x0004A204 File Offset: 0x00048404
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(char expected, char actual)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<char>(expected, actual, null);
			}
		}

		// Token: 0x06002C27 RID: 11303 RVA: 0x0004A228 File Offset: 0x00048428
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(char expected, char actual, string message)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<char>(expected, actual, message);
			}
		}

		// Token: 0x06002C28 RID: 11304 RVA: 0x0004A24C File Offset: 0x0004844C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(char expected, char actual)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<char>(expected, actual, null);
			}
		}

		// Token: 0x06002C29 RID: 11305 RVA: 0x0004A26C File Offset: 0x0004846C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(char expected, char actual, string message)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<char>(expected, actual, message);
			}
		}

		// Token: 0x06002C2A RID: 11306 RVA: 0x0004A28C File Offset: 0x0004848C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(short expected, short actual)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<short>(expected, actual, null);
			}
		}

		// Token: 0x06002C2B RID: 11307 RVA: 0x0004A2B0 File Offset: 0x000484B0
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(short expected, short actual, string message)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<short>(expected, actual, message);
			}
		}

		// Token: 0x06002C2C RID: 11308 RVA: 0x0004A2D4 File Offset: 0x000484D4
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(short expected, short actual)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<short>(expected, actual, null);
			}
		}

		// Token: 0x06002C2D RID: 11309 RVA: 0x0004A2F4 File Offset: 0x000484F4
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(short expected, short actual, string message)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<short>(expected, actual, message);
			}
		}

		// Token: 0x06002C2E RID: 11310 RVA: 0x0004A314 File Offset: 0x00048514
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(ushort expected, ushort actual)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<ushort>(expected, actual, null);
			}
		}

		// Token: 0x06002C2F RID: 11311 RVA: 0x0004A338 File Offset: 0x00048538
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(ushort expected, ushort actual, string message)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<ushort>(expected, actual, message);
			}
		}

		// Token: 0x06002C30 RID: 11312 RVA: 0x0004A35C File Offset: 0x0004855C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(ushort expected, ushort actual)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<ushort>(expected, actual, null);
			}
		}

		// Token: 0x06002C31 RID: 11313 RVA: 0x0004A37C File Offset: 0x0004857C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(ushort expected, ushort actual, string message)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<ushort>(expected, actual, message);
			}
		}

		// Token: 0x06002C32 RID: 11314 RVA: 0x0004A39C File Offset: 0x0004859C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(int expected, int actual)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<int>(expected, actual, null);
			}
		}

		// Token: 0x06002C33 RID: 11315 RVA: 0x0004A3C0 File Offset: 0x000485C0
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(int expected, int actual, string message)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<int>(expected, actual, message);
			}
		}

		// Token: 0x06002C34 RID: 11316 RVA: 0x0004A3E4 File Offset: 0x000485E4
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(int expected, int actual)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<int>(expected, actual, null);
			}
		}

		// Token: 0x06002C35 RID: 11317 RVA: 0x0004A404 File Offset: 0x00048604
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(int expected, int actual, string message)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<int>(expected, actual, message);
			}
		}

		// Token: 0x06002C36 RID: 11318 RVA: 0x0004A424 File Offset: 0x00048624
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(uint expected, uint actual)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<uint>(expected, actual, null);
			}
		}

		// Token: 0x06002C37 RID: 11319 RVA: 0x0004A448 File Offset: 0x00048648
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(uint expected, uint actual, string message)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<uint>(expected, actual, message);
			}
		}

		// Token: 0x06002C38 RID: 11320 RVA: 0x0004A46C File Offset: 0x0004866C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(uint expected, uint actual)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<uint>(expected, actual, null);
			}
		}

		// Token: 0x06002C39 RID: 11321 RVA: 0x0004A48C File Offset: 0x0004868C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(uint expected, uint actual, string message)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<uint>(expected, actual, message);
			}
		}

		// Token: 0x06002C3A RID: 11322 RVA: 0x0004A4AC File Offset: 0x000486AC
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(long expected, long actual)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<long>(expected, actual, null);
			}
		}

		// Token: 0x06002C3B RID: 11323 RVA: 0x0004A4D0 File Offset: 0x000486D0
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(long expected, long actual, string message)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<long>(expected, actual, message);
			}
		}

		// Token: 0x06002C3C RID: 11324 RVA: 0x0004A4F4 File Offset: 0x000486F4
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(long expected, long actual)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<long>(expected, actual, null);
			}
		}

		// Token: 0x06002C3D RID: 11325 RVA: 0x0004A514 File Offset: 0x00048714
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(long expected, long actual, string message)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<long>(expected, actual, message);
			}
		}

		// Token: 0x06002C3E RID: 11326 RVA: 0x0004A534 File Offset: 0x00048734
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(ulong expected, ulong actual)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<ulong>(expected, actual, null);
			}
		}

		// Token: 0x06002C3F RID: 11327 RVA: 0x0004A558 File Offset: 0x00048758
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(ulong expected, ulong actual, string message)
		{
			bool flag = expected != actual;
			if (flag)
			{
				Assert.AreEqual<ulong>(expected, actual, message);
			}
		}

		// Token: 0x06002C40 RID: 11328 RVA: 0x0004A57C File Offset: 0x0004877C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(ulong expected, ulong actual)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<ulong>(expected, actual, null);
			}
		}

		// Token: 0x06002C41 RID: 11329 RVA: 0x0004A59C File Offset: 0x0004879C
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual(ulong expected, ulong actual, string message)
		{
			bool flag = expected == actual;
			if (flag)
			{
				Assert.AreNotEqual<ulong>(expected, actual, message);
			}
		}

		// Token: 0x04001122 RID: 4386
		internal const string UNITY_ASSERTIONS = "UNITY_ASSERTIONS";

		// Token: 0x04001123 RID: 4387
		[Obsolete("Future versions of Unity are expected to always throw exceptions and not have this field.")]
		public static bool raiseExceptions = true;
	}
}
