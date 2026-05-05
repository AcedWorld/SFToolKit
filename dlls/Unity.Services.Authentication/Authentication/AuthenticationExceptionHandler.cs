using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unity.Services.Authentication.Shared;
using Unity.Services.Core;

namespace Unity.Services.Authentication
{
	// Token: 0x0200000B RID: 11
	internal class AuthenticationExceptionHandler : IAuthenticationExceptionHandler
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000040EF File Offset: 0x000022EF
		private IAuthenticationMetrics Metrics { get; }

		// Token: 0x0600009E RID: 158 RVA: 0x000040F7 File Offset: 0x000022F7
		public AuthenticationExceptionHandler(IAuthenticationMetrics metrics)
		{
			this.Metrics = metrics;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004108 File Offset: 0x00002308
		public RequestFailedException BuildClientInvalidStateException(AuthenticationState state)
		{
			string message = string.Empty;
			switch (state)
			{
			case AuthenticationState.SignedOut:
				message = "Invalid state for this operation. The player is signed out.";
				break;
			case AuthenticationState.SigningIn:
				message = "Invalid state for this operation. The player is already signing in.";
				break;
			case AuthenticationState.Authorized:
			case AuthenticationState.Refreshing:
				message = "Invalid state for this operation. The player is already signed in.";
				break;
			case AuthenticationState.Expired:
				message = "Invalid state for this operation. The player session has expired.";
				break;
			}
			this.Metrics.SendClientInvalidStateExceptionMetric();
			return AuthenticationException.Create(AuthenticationErrorCodes.ClientInvalidUserState, message, null);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000416C File Offset: 0x0000236C
		public RequestFailedException BuildClientInvalidProfileException()
		{
			return AuthenticationException.Create(AuthenticationErrorCodes.ClientInvalidProfile, "Invalid profile name. The profile may only contain alphanumeric values, '-', '_', and must be no longer than 30 characters.", null);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000417E File Offset: 0x0000237E
		public RequestFailedException BuildClientUnlinkExternalIdNotFoundException()
		{
			this.Metrics.SendUnlinkExternalIdNotFoundExceptionMetric();
			return AuthenticationException.Create(AuthenticationErrorCodes.ClientUnlinkExternalIdNotFound, "No external id was found to unlink from the provider. Use GetPlayerInfoAsync to load the linked external ids.", null);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000419B File Offset: 0x0000239B
		public RequestFailedException BuildClientSessionTokenNotExistsException()
		{
			this.Metrics.SendClientSessionTokenNotExistsExceptionMetric();
			return AuthenticationException.Create(AuthenticationErrorCodes.ClientNoActiveSession, "There is no cached session token.", null);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000041B8 File Offset: 0x000023B8
		public RequestFailedException BuildUnknownException(string error)
		{
			return AuthenticationException.Create(0, error, null);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000041C2 File Offset: 0x000023C2
		public RequestFailedException BuildInvalidIdProviderNameException()
		{
			return AuthenticationException.Create(AuthenticationErrorCodes.InvalidParameters, "Invalid IdProviderName. The Id Provider name should start with 'oidc-' and have between 6 and 20 characters (including 'oidc-')", null);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000041D4 File Offset: 0x000023D4
		public RequestFailedException BuildInvalidPlayerNameException()
		{
			return AuthenticationException.Create(AuthenticationErrorCodes.InvalidParameters, "Invalid Player Name. Player names cannot be empty or contain spaces.", null);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000041E6 File Offset: 0x000023E6
		public RequestFailedException BuildInvalidCredentialsException()
		{
			return AuthenticationException.Create(AuthenticationErrorCodes.InvalidParameters, "Username and/or Password are not in the correct format", null);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000041F8 File Offset: 0x000023F8
		public RequestFailedException ConvertException(WebRequestException exception)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string value = string.Format("Request failed: {0}, {1}", exception.ResponseCode, exception.Message);
			stringBuilder.Append(value);
			string str;
			if (exception.ResponseHeaders != null && exception.ResponseHeaders.TryGetValue("x-request-id", out str))
			{
				stringBuilder.Append(", request-id: " + str);
			}
			Logger.Log(stringBuilder.ToString());
			if (exception.NetworkError)
			{
				this.Metrics.SendNetworkErrorMetric();
				return AuthenticationException.Create(1, "Network Error: " + exception.Message, exception);
			}
			RequestFailedException result;
			try
			{
				AuthenticationErrorResponse authenticationErrorResponse = IsolatedJsonConvert.DeserializeObject<AuthenticationErrorResponse>(exception.Message, SerializerSettings.DefaultSerializerSettings);
				int errorCode = this.MapErrorCodes(authenticationErrorResponse.Title);
				List<Notification> notifications = AuthenticationExceptionHandler.ParseNotifications(authenticationErrorResponse.Details);
				result = AuthenticationException.Create(errorCode, authenticationErrorResponse.Detail, notifications, exception);
			}
			catch (JsonException innerException)
			{
				result = AuthenticationException.Create(0, "Failed to deserialize server response.", innerException);
			}
			catch (Exception)
			{
				result = AuthenticationException.Create(0, "Unknown error deserializing server response. ", exception);
			}
			return result;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00004314 File Offset: 0x00002514
		public RequestFailedException ConvertException(ApiException exception)
		{
			ApiExceptionType? apiExceptionType = (exception != null) ? new ApiExceptionType?(exception.Type) : null;
			if (apiExceptionType != null)
			{
				switch (apiExceptionType.GetValueOrDefault())
				{
				case ApiExceptionType.InvalidParameters:
					return AuthenticationException.Create(AuthenticationErrorCodes.InvalidParameters, exception.Message, null);
				case ApiExceptionType.Network:
					return AuthenticationExceptionHandler.CreateNetworkException(exception);
				case ApiExceptionType.Http:
					return AuthenticationExceptionHandler.CreateHttpException(exception);
				case ApiExceptionType.Deserialization:
					return AuthenticationException.Create(0, exception.Message, null);
				}
			}
			return AuthenticationExceptionHandler.CreateUnknownException(exception);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004398 File Offset: 0x00002598
		private static RequestFailedException CreateNetworkException(ApiException exception)
		{
			int? num;
			if (exception == null)
			{
				num = null;
			}
			else
			{
				IApiResponse response = exception.Response;
				num = ((response != null) ? new int?(response.StatusCode) : null);
			}
			int? num2 = num;
			if (num2 != null)
			{
				int valueOrDefault = num2.GetValueOrDefault();
				if (valueOrDefault == 503)
				{
					return AuthenticationException.Create(3, exception.Message, null);
				}
				if (valueOrDefault == 504)
				{
					return AuthenticationException.Create(2, exception.Message, null);
				}
			}
			return AuthenticationException.Create(1, exception.Message, null);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00004420 File Offset: 0x00002620
		private static RequestFailedException CreateHttpException(ApiException exception)
		{
			int? num;
			if (exception == null)
			{
				num = null;
			}
			else
			{
				IApiResponse response = exception.Response;
				num = ((response != null) ? new int?(response.StatusCode) : null);
			}
			int? num2 = num;
			if (num2 != null)
			{
				int valueOrDefault = num2.GetValueOrDefault();
				switch (valueOrDefault)
				{
				case 400:
					return AuthenticationException.Create(55, exception.Message, null);
				case 401:
					return AuthenticationException.Create(51, exception.Message, null);
				case 402:
				case 405:
				case 406:
				case 407:
					break;
				case 403:
					return AuthenticationException.Create(53, exception.Message, null);
				case 404:
					return AuthenticationException.Create(54, exception.Message, null);
				case 408:
					return AuthenticationException.Create(2, exception.Message, null);
				case 409:
					return AuthenticationException.Create(58, exception.Message, null);
				default:
					if (valueOrDefault == 429)
					{
						return AuthenticationException.Create(50, exception.Message, null);
					}
					break;
				}
			}
			return AuthenticationException.Create(55, exception.Message, null);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00004523 File Offset: 0x00002723
		private static RequestFailedException CreateUnknownException(Exception exception)
		{
			return AuthenticationException.Create(0, "Unknown Error: " + exception.Message, null);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000453C File Offset: 0x0000273C
		private int MapErrorCodes(string serverErrorTitle)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(serverErrorTitle);
			if (num <= 2745047103U)
			{
				if (num <= 2190220901U)
				{
					if (num != 1805790060U)
					{
						if (num != 2190220901U)
						{
							return 0;
						}
						if (!(serverErrorTitle == "INVALID_SESSION_TOKEN"))
						{
							return 0;
						}
						return AuthenticationErrorCodes.InvalidSessionToken;
					}
					else
					{
						if (!(serverErrorTitle == "PERMISSION_DENIED"))
						{
							return 0;
						}
						return AuthenticationErrorCodes.InvalidParameters;
					}
				}
				else if (num != 2618821525U)
				{
					if (num != 2745047103U)
					{
						return 0;
					}
					if (!(serverErrorTitle == "ENTITY_EXISTS"))
					{
						return 0;
					}
					return AuthenticationErrorCodes.AccountAlreadyLinked;
				}
				else if (!(serverErrorTitle == "BANNED_USER"))
				{
					return 0;
				}
			}
			else if (num <= 3049788673U)
			{
				if (num != 2747878492U)
				{
					if (num != 3049788673U)
					{
						return 0;
					}
					if (!(serverErrorTitle == "INVALID_PARAMETERS"))
					{
						return 0;
					}
					return AuthenticationErrorCodes.InvalidParameters;
				}
				else
				{
					if (!(serverErrorTitle == "LINKED_ACCOUNT_LIMIT_EXCEEDED"))
					{
						return 0;
					}
					return AuthenticationErrorCodes.AccountLinkLimitExceeded;
				}
			}
			else if (num != 3471759869U)
			{
				if (num != 3739771583U)
				{
					return 0;
				}
				if (!(serverErrorTitle == "PERMANENTLY_BANNED_USER"))
				{
					return 0;
				}
			}
			else
			{
				if (!(serverErrorTitle == "UNAUTHORIZED_REQUEST"))
				{
					return 0;
				}
				return 51;
			}
			return AuthenticationErrorCodes.BannedUser;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00004668 File Offset: 0x00002868
		private static List<Notification> ParseNotifications(List<object> details)
		{
			if (details != null && details.Count > 0)
			{
				foreach (object obj in details)
				{
					try
					{
						JObject jobject = obj as JObject;
						return IsolatedJsonConvert.DeserializeObject<GetNotificationsResponse>((jobject != null) ? jobject.ToString() : null).ToNotificationList();
					}
					catch
					{
					}
				}
			}
			return null;
		}
	}
}
