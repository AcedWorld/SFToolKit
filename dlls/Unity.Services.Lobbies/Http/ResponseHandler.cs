using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000058 RID: 88
	internal static class ResponseHandler
	{
		// Token: 0x0600024F RID: 591 RVA: 0x00008D3C File Offset: 0x00006F3C
		private static List<IDeserializable> DeserializeListOfJsonObjects(List<object> objectList)
		{
			List<IDeserializable> list = new List<IDeserializable>();
			foreach (object obj in objectList)
			{
				list.Add(new JsonObject(obj));
			}
			return (List<IDeserializable>)list;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00008D9C File Offset: 0x00006F9C
		public static T TryDeserializeResponse<T>(HttpClientResponse response)
		{
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				MissingMemberHandling = MissingMemberHandling.Ignore,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			};
			T result;
			try
			{
				result = JsonConvert.DeserializeObject<T>(ResponseHandler.GetDeserializedJson(response.Data), settings);
			}
			catch (Exception ex)
			{
				throw new ResponseDeserializationException(response, ex, ex.Message);
			}
			return result;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00008DF4 File Offset: 0x00006FF4
		public static object TryDeserializeResponse(HttpClientResponse response, Type type)
		{
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				MissingMemberHandling = MissingMemberHandling.Ignore,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			};
			object result;
			try
			{
				result = JsonConvert.DeserializeObject(ResponseHandler.GetDeserializedJson(response.Data), type, settings);
			}
			catch (Exception ex)
			{
				throw new ResponseDeserializationException(response, ex, ex.Message);
			}
			return result;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00008E4C File Offset: 0x0000704C
		private static string GetDeserializedJson(byte[] data)
		{
			return Encoding.UTF8.GetString(data);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00008E5C File Offset: 0x0000705C
		public static void HandleAsyncResponse(HttpClientResponse response, Dictionary<string, Type> statusCodeToTypeMap)
		{
			if (!statusCodeToTypeMap.ContainsKey(response.StatusCode.ToString()))
			{
				throw new HttpException(response);
			}
			Type type = statusCodeToTypeMap[response.StatusCode.ToString()];
			if ((!(type != null) || !response.IsHttpError) && !response.IsNetworkError)
			{
				return;
			}
			if (typeof(IOneOf).IsAssignableFrom(type))
			{
				throw ResponseHandler.CreateOneOfException(response, type);
			}
			throw ResponseHandler.CreateHttpException(response, type);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00008ED8 File Offset: 0x000070D8
		private static HttpException CreateOneOfException(HttpClientResponse response, Type responseType)
		{
			HttpException result;
			try
			{
				object obj = ResponseHandler.TryDeserializeResponse(response, responseType);
				result = ResponseHandler.CreateHttpException(response, ((IOneOf)obj).Type);
			}
			catch (ArgumentException ex)
			{
				throw new ResponseDeserializationException(response, ex, ex.Message);
			}
			catch (MissingFieldException inner)
			{
				throw new ResponseDeserializationException(response, inner, "Discriminator field not found in the parsed json response.");
			}
			catch (ResponseDeserializationException ex2)
			{
				if (ex2.InnerException.GetType() == typeof(MissingFieldException))
				{
					throw new ResponseDeserializationException(response, ex2.InnerException, "Discriminator field not found in the parsed json response.");
				}
				if (ex2.response == null)
				{
					throw new ResponseDeserializationException(response, ex2.Message);
				}
				throw;
			}
			catch (Exception ex3)
			{
				throw new ResponseDeserializationException(response, ex3, ex3.Message);
			}
			return result;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00008FB0 File Offset: 0x000071B0
		private static HttpException CreateHttpException(HttpClientResponse response, Type responseType)
		{
			Type type = typeof(HttpException<>).MakeGenericType(new Type[]
			{
				responseType
			});
			HttpException result;
			try
			{
				if (responseType == typeof(Stream))
				{
					object obj = (response.Data == null) ? new MemoryStream() : new MemoryStream(response.Data);
					result = (HttpException)Activator.CreateInstance(type, new object[]
					{
						response,
						obj
					});
				}
				else
				{
					object obj2 = ResponseHandler.TryDeserializeResponse(response, responseType);
					result = (HttpException)Activator.CreateInstance(type, new object[]
					{
						response,
						obj2
					});
				}
			}
			catch (ArgumentException ex)
			{
				throw new ResponseDeserializationException(response, ex, ex.Message);
			}
			catch (MissingFieldException inner)
			{
				throw new ResponseDeserializationException(response, inner, "Discriminator field not found in the parsed json response.");
			}
			catch (ResponseDeserializationException ex2)
			{
				if (ex2.response == null)
				{
					throw new ResponseDeserializationException(response, ex2.Message);
				}
				throw;
			}
			catch (Exception ex3)
			{
				throw new ResponseDeserializationException(response, ex3, ex3.Message);
			}
			return result;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x000090C8 File Offset: 0x000072C8
		public static T HandleAsyncResponse<T>(HttpClientResponse response, Dictionary<string, Type> statusCodeToTypeMap) where T : class
		{
			ResponseHandler.HandleAsyncResponse(response, statusCodeToTypeMap);
			T result;
			try
			{
				if (statusCodeToTypeMap[response.StatusCode.ToString()] == typeof(Stream))
				{
					result = (((response.Data == null) ? new MemoryStream() : new MemoryStream(response.Data)) as T);
				}
				else
				{
					result = ResponseHandler.TryDeserializeResponse<T>(response);
				}
			}
			catch (ArgumentException ex)
			{
				throw new ResponseDeserializationException(response, ex.Message);
			}
			catch (MissingFieldException inner)
			{
				throw new ResponseDeserializationException(response, inner, "Discriminator field not found in the parsed json response.");
			}
			catch (ResponseDeserializationException ex2)
			{
				if (ex2.response == null)
				{
					throw new ResponseDeserializationException(response, ex2.Message);
				}
				throw;
			}
			catch (Exception ex3)
			{
				throw new ResponseDeserializationException(response, ex3, ex3.Message);
			}
			return result;
		}
	}
}
