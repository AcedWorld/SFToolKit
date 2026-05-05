using System;

namespace UnityEngine.Assertions
{
	// Token: 0x020004F4 RID: 1268
	internal class AssertionMessageUtil
	{
		// Token: 0x06002C45 RID: 11333 RVA: 0x0004A614 File Offset: 0x00048814
		public static string GetMessage(string failureMessage)
		{
			return UnityString.Format("{0} {1}", new object[]
			{
				"Assertion failure.",
				failureMessage
			});
		}

		// Token: 0x06002C46 RID: 11334 RVA: 0x0004A644 File Offset: 0x00048844
		public static string GetMessage(string failureMessage, string expected)
		{
			return AssertionMessageUtil.GetMessage(UnityString.Format("{0}{1}{2} {3}", new object[]
			{
				failureMessage,
				Environment.NewLine,
				"Expected:",
				expected
			}));
		}

		// Token: 0x06002C47 RID: 11335 RVA: 0x0004A684 File Offset: 0x00048884
		public static string GetEqualityMessage(object actual, object expected, bool expectEqual)
		{
			return AssertionMessageUtil.GetMessage(UnityString.Format("Values are {0}equal.", new object[]
			{
				expectEqual ? "not " : ""
			}), UnityString.Format("{0} {2} {1}", new object[]
			{
				actual,
				expected,
				expectEqual ? "==" : "!="
			}));
		}

		// Token: 0x06002C48 RID: 11336 RVA: 0x0004A6E8 File Offset: 0x000488E8
		public static string NullFailureMessage(object value, bool expectNull)
		{
			return AssertionMessageUtil.GetMessage(UnityString.Format("Value was {0}Null", new object[]
			{
				expectNull ? "not " : ""
			}), UnityString.Format("Value was {0}Null", new object[]
			{
				expectNull ? "" : "not "
			}));
		}

		// Token: 0x06002C49 RID: 11337 RVA: 0x0004A744 File Offset: 0x00048944
		public static string BooleanFailureMessage(bool expected)
		{
			return AssertionMessageUtil.GetMessage("Value was " + (!expected).ToString(), expected.ToString());
		}

		// Token: 0x04001125 RID: 4389
		private const string k_Expected = "Expected:";

		// Token: 0x04001126 RID: 4390
		private const string k_AssertionFailed = "Assertion failure.";
	}
}
