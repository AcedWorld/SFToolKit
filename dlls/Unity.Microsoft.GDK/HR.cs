using System;
using System.Reflection;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200000E RID: 14
	[MovedFrom("Unity.GameCore")]
	public class HR : HR
	{
		// Token: 0x06000232 RID: 562 RVA: 0x00008574 File Offset: 0x00006774
		public static string NameOf(int hr)
		{
			HR obj = new HR();
			foreach (FieldInfo fieldInfo in typeof(HR).GetFields())
			{
				if (fieldInfo.GetValue(obj).Equals(hr))
				{
					return fieldInfo.Name;
				}
			}
			return "";
		}

		// Token: 0x04000033 RID: 51
		public const int E_FAIL = -2147467259;

		// Token: 0x04000034 RID: 52
		public const int HTTP_E_STATUS_NONE_ACCEPTABLE = -2145844842;

		// Token: 0x04000035 RID: 53
		public const int HTTP_E_STATUS_NOT_FOUND = -2145844844;

		// Token: 0x04000036 RID: 54
		public const int HTTP_E_STATUS_NOT_MODIFIED = -2145844944;

		// Token: 0x04000037 RID: 55
		public const int HTTP_E_STATUS_NOT_SUPPORTED = -2145844747;

		// Token: 0x04000038 RID: 56
		public const int HTTP_E_STATUS_PAYMENT_REQ = -2145844846;

		// Token: 0x04000039 RID: 57
		public const int HTTP_E_STATUS_PRECOND_FAILED = -2145844836;

		// Token: 0x0400003A RID: 58
		public const int HTTP_E_STATUS_PROXY_AUTH_REQ = -2145844841;

		// Token: 0x0400003B RID: 59
		public const int E_GAME_MISSING_GAME_CONFIG = -2015035361;

		// Token: 0x0400003C RID: 60
		public const int E_DSTORAGE_BEGIN = -1994129408;

		// Token: 0x0400003D RID: 61
		public const int E_DSTORAGE_END = -1994129153;

		// Token: 0x0400003E RID: 62
		public const int E_GAMERUNTIME_NOT_INITIALIZED = -1994129152;

		// Token: 0x0400003F RID: 63
		public const int E_GAMERUNTIME_DLL_NOT_FOUND = -1994129151;

		// Token: 0x04000040 RID: 64
		public const int E_GAMERUNTIME_VERSION_MISMATCH = -1994129150;

		// Token: 0x04000041 RID: 65
		public const int E_GAMERUNTIME_WINDOW_NOT_FOREGROUND = -1994129149;

		// Token: 0x04000042 RID: 66
		public const int E_GAMERUNTIME_SUSPENDED = -1994129148;

		// Token: 0x04000043 RID: 67
		public const int E_GAMERUNTIME_UNINITIALIZE_ACTIVEOBJECTS = -1994129147;

		// Token: 0x04000044 RID: 68
		public const int E_GAMERUNTIME_MULTIPLAYER_NOT_CONFIGURED = -1994129146;

		// Token: 0x04000045 RID: 69
		public const int E_GAMEUSER_MAX_USERS_ADDED = -1994108672;

		// Token: 0x04000046 RID: 70
		public const int E_GAMEUSER_SIGNED_OUT = -1994108671;

		// Token: 0x04000047 RID: 71
		public const int E_GAMEUSER_RESOLVE_USER_ISSUE_REQUIRED = -1994108670;

		// Token: 0x04000048 RID: 72
		public const int E_GAMEUSER_DEFERRAL_NOT_AVAILABLE = -1994108669;

		// Token: 0x04000049 RID: 73
		public const int E_GAMEUSER_USER_NOT_FOUND = -1994108668;

		// Token: 0x0400004A RID: 74
		public const int E_GAMEUSER_NO_TOKEN_REQUIRED = -1994108667;

		// Token: 0x0400004B RID: 75
		public const int E_GAMEUSER_NO_DEFAULT_USER = -1994108666;

		// Token: 0x0400004C RID: 76
		public const int E_GAMEUSER_FAILED_TO_RESOLVE = -1994108665;

		// Token: 0x0400004D RID: 77
		public const int E_GAMEUSER_NO_TITLE_ID = -1994108664;

		// Token: 0x0400004E RID: 78
		public const int E_GAMEUSER_UNKNOWN_GAME_IDENTITY = -1994108663;

		// Token: 0x0400004F RID: 79
		public const int E_GAMEUSER_NO_PACKAGE_IDENTITY = -1994108656;

		// Token: 0x04000050 RID: 80
		public const int E_GAMEUSER_FAILED_TO_GET_TOKEN = -1994108655;

		// Token: 0x04000051 RID: 81
		public const int E_GAMEPACKAGE_APP_NOT_PACKAGED = -1994108416;

		// Token: 0x04000052 RID: 82
		public const int E_GAMEPACKAGE_NO_INSTALLED_LANGUAGES = -1994108415;

		// Token: 0x04000053 RID: 83
		public const int E_GAMEPACKAGE_NO_STORE_ID = -1994108414;

		// Token: 0x04000054 RID: 84
		public const int E_GAMEPACKAGE_INVALID_SELECTOR = -1994108413;

		// Token: 0x04000055 RID: 85
		public const int E_GAMEPACKAGE_DOWNLOAD_REQUIRED = -1994108412;

		// Token: 0x04000056 RID: 86
		public const int E_GAMEPACKAGE_NO_TAG_CHANGE = -1994108411;

		// Token: 0x04000057 RID: 87
		public const int E_GAMESTORE_LICENSE_ACTION_NOT_APPLICABLE_TO_PRODUCT = -1994108160;

		// Token: 0x04000058 RID: 88
		public const int E_GAMESTORE_NETWORK_ERROR = -1994108159;

		// Token: 0x04000059 RID: 89
		public const int E_GAMESTORE_SERVER_ERROR = -1994108158;

		// Token: 0x0400005A RID: 90
		public const int E_GAMESTORE_INSUFFICIENT_QUANTITY = -1994108157;

		// Token: 0x0400005B RID: 91
		public const int E_GAMESTORE_ALREADY_PURCHASED = -1994108156;

		// Token: 0x0400005C RID: 92
		public const int E_GAMESTREAMING_NOT_INITIALIZED = -1994107904;

		// Token: 0x0400005D RID: 93
		public const int E_GAMESTREAMING_CLIENT_NOT_CONNECTED = -1994107903;

		// Token: 0x0400005E RID: 94
		public const int E_GAMESTREAMING_NO_DATA = -1994107902;

		// Token: 0x0400005F RID: 95
		public const int E_GAMESTREAMING_NO_DATACENTER = -1994107901;

		// Token: 0x04000060 RID: 96
		public const int E_GAMESTREAMING_NOT_STREAMING_CONTROLLER = -1994107900;

		// Token: 0x04000061 RID: 97
		public const int E_GS_INVALID_CONTAINER_NAME = -2138898431;

		// Token: 0x04000062 RID: 98
		public const int E_GS_NO_ACCESS = -2138898430;

		// Token: 0x04000063 RID: 99
		public const int E_GS_OUT_OF_LOCAL_STORAGE = -2138898429;

		// Token: 0x04000064 RID: 100
		public const int E_GS_USER_CANCELED = -2138898428;

		// Token: 0x04000065 RID: 101
		public const int E_GS_UPDATE_TOO_BIG = -2138898427;

		// Token: 0x04000066 RID: 102
		public const int E_GS_QUOTA_EXCEEDED = -2138898426;

		// Token: 0x04000067 RID: 103
		public const int E_GS_PROVIDED_BUFFER_TOO_SMALL = -2138898425;

		// Token: 0x04000068 RID: 104
		public const int E_GS_BLOB_NOT_FOUND = -2138898424;

		// Token: 0x04000069 RID: 105
		public const int E_GS_NO_SERVICE_CONFIGURATION = -2138898423;

		// Token: 0x0400006A RID: 106
		public const int E_GS_CONTAINER_NOT_IN_SYNC = -2138898422;

		// Token: 0x0400006B RID: 107
		public const int E_GS_CONTAINER_SYNC_FAILED = -2138898421;

		// Token: 0x0400006C RID: 108
		public const int E_GS_USER_NOT_REGISTERED_IN_SERVICE = -2138898420;

		// Token: 0x0400006D RID: 109
		public const int E_GS_HANDLE_EXPIRED = -2138898419;

		// Token: 0x0400006E RID: 110
		public const int E_GS_ASYNC_FUNCTION_REQUIRED = -2138898418;

		// Token: 0x0400006F RID: 111
		public const int E_XBL_RUNTIME_ERROR = -1994173952;

		// Token: 0x04000070 RID: 112
		public const int E_XBL_RTA_GENERIC_ERROR = -1994173951;

		// Token: 0x04000071 RID: 113
		public const int E_XBL_RTA_SUBSCRIPTION_LIMIT_REACHED = -1994173950;

		// Token: 0x04000072 RID: 114
		public const int E_XBL_RTA_ACCESS_DENIED = -1994173949;

		// Token: 0x04000073 RID: 115
		public const int E_XBL_AUTH_UNKNOWN_ERROR = -1994173948;

		// Token: 0x04000074 RID: 116
		public const int E_XBL_AUTH_RUNTIME_ERROR = -1994173947;

		// Token: 0x04000075 RID: 117
		public const int E_XBL_AUTH_NO_TOKEN = -1994173946;

		// Token: 0x04000076 RID: 118
		public const int E_XBL_ALREADY_INITIALIZED = -1994173945;

		// Token: 0x04000077 RID: 119
		public const int E_XBL_NOT_INITIALIZED = -1994173944;

		// Token: 0x04000078 RID: 120
		public const int XO_E_CONTENT_ISOLATION = -2146051054;
	}
}
