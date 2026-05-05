using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Unity.Services.Relay.Models;

namespace Unity.Services.Relay.Http
{
	// Token: 0x02000040 RID: 64
	internal static class ResponseHandler
	{
		// Token: 0x06000109 RID: 265 RVA: 0x00004758 File Offset: 0x00002958
		private static List<IDeserializable> DeserializeListOfJsonObjects(List<object> objectList)
		{
			List<IDeserializable> list = new List<IDeserializable>();
			foreach (object obj in objectList)
			{
				list.Add(new JsonObject(obj));
			}
			return (List<IDeserializable>)list;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000047B8 File Offset: 0x000029B8
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

		// Token: 0x0600010B RID: 267 RVA: 0x00004810 File Offset: 0x00002A10
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

		// Token: 0x0600010C RID: 268 RVA: 0x00004868 File Offset: 0x00002A68
		private static string GetDeserializedJson(byte[] data)
		{
			return Encoding.UTF8.GetString(data);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00004878 File Offset: 0x00002A78
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

		// Token: 0x0600010E RID: 270 RVA: 0x000048F4 File Offset: 0x00002AF4
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

		// Token: 0x0600010F RID: 271 RVA: 0x000049CC File Offset: 0x00002BCC
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

		// Token: 0x06000110 RID: 272 RVA: 0x00004AE4 File Offset: 0x00002CE4
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
