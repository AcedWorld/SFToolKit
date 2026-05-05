using System;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000006 RID: 6
	internal static class PlayerAccountsExceptionHandler
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020E0 File Offset: 0x000002E0
		public static PlayerAccountsException HandleError(string error, string description = null, Exception innerException = null)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(error);
			if (num <= 2308839955U)
			{
				if (num <= 1253514083U)
				{
					if (num != 218607290U)
					{
						if (num == 1253514083U)
						{
							if (error == "invalid_scope")
							{
								return PlayerAccountsException.Create(10104, error, null);
							}
						}
					}
					else if (error == "invalid_request")
					{
						return PlayerAccountsException.Create(10105, error, null);
					}
				}
				else if (num != 1590132005U)
				{
					if (num == 2308839955U)
					{
						if (error == "unauthorized_client")
						{
							return PlayerAccountsException.Create(10108, error, null);
						}
					}
				}
				else if (error == "invalid_grant")
				{
					return PlayerAccountsException.Create(10106, description, innerException);
				}
			}
			else if (num <= 3184086822U)
			{
				if (num != 2687378355U)
				{
					if (num == 3184086822U)
					{
						if (error == "invalid_client")
						{
							return PlayerAccountsException.Create(10103, description, innerException);
						}
					}
				}
				else if (error == "unsupported_response_type")
				{
					return PlayerAccountsException.Create(10110, error, null);
				}
			}
			else if (num != 3276049326U)
			{
				if (num == 3973329822U)
				{
					if (error == "invalid_state")
					{
						return PlayerAccountsException.Create(10101, error, null);
					}
				}
			}
			else if (error == "unsupported_grant_type")
			{
				return PlayerAccountsException.Create(10109, description, innerException);
			}
			return PlayerAccountsException.Create(10100, error, null);
		}
	}
}
