using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Unity.Services.Qos.Models;

namespace Unity.Services.Qos.Http
{
	// Token: 0x0200006A RID: 106
	internal static class ResponseHandler
	{
		// Token: 0x060001E7 RID: 487 RVA: 0x000076B8 File Offset: 0x000058B8
		private static List<IDeserializable> DeserializeListOfJsonObjects(List<object> objectList)
		{
			List<IDeserializable> list = new List<IDeserializable>();
			foreach (object obj in objectList)
			{
				list.Add(new JsonObject(obj));
			}
			return (List<IDeserializable>)list;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00007718 File Offset: 0x00005918
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

		// Token: 0x060001E9 RID: 489 RVA: 0x00007770 File Offset: 0x00005970
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

		// Token: 0x060001EA RID: 490 RVA: 0x000077C8 File Offset: 0x000059C8
		private static string GetDeserializedJson(byte[] data)
		{
			return Encoding.UTF8.GetString(data);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x000077D8 File Offset: 0x000059D8
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

		// Token: 0x060001EC RID: 492 RVA: 0x00007854 File Offset: 0x00005A54
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

		// Token: 0x060001ED RID: 493 RVA: 0x0000792C File Offset: 0x00005B2C
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

		// Token: 0x060001EE RID: 494 RVA: 0x00007A44 File Offset: 0x00005C44
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
