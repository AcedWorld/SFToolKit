using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Unity.Services.Qos.V2.Models;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x0200003A RID: 58
	internal static class ResponseHandler
	{
		// Token: 0x060000EF RID: 239 RVA: 0x00005098 File Offset: 0x00003298
		private static List<IDeserializable> DeserializeListOfJsonObjects(List<object> objectList)
		{
			List<IDeserializable> list = new List<IDeserializable>();
			foreach (object obj in objectList)
			{
				list.Add(new JsonObject(obj));
			}
			return (List<IDeserializable>)list;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000050F8 File Offset: 0x000032F8
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
				result = IsolatedJsonConvert.DeserializeObject<T>(ResponseHandler.GetDeserializedJson(response.Data), settings);
			}
			catch (Exception ex)
			{
				throw new ResponseDeserializationException(response, ex, ex.Message);
			}
			return result;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005150 File Offset: 0x00003350
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
				result = IsolatedJsonConvert.DeserializeObject(ResponseHandler.GetDeserializedJson(response.Data), type, settings);
			}
			catch (Exception ex)
			{
				throw new ResponseDeserializationException(response, ex, ex.Message);
			}
			return result;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000051A8 File Offset: 0x000033A8
		private static string GetDeserializedJson(byte[] data)
		{
			if (data != null)
			{
				return Encoding.UTF8.GetString(data);
			}
			return null;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000051BC File Offset: 0x000033BC
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

		// Token: 0x060000F4 RID: 244 RVA: 0x00005238 File Offset: 0x00003438
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

		// Token: 0x060000F5 RID: 245 RVA: 0x00005310 File Offset: 0x00003510
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

		// Token: 0x060000F6 RID: 246 RVA: 0x00005428 File Offset: 0x00003628
		public static T HandleAsyncResponse<T>(HttpClientResponse response, Dictionary<string, Type> statusCodeToTypeMap) where T : class
		{
			ResponseHandler.HandleAsyncResponse(response, statusCodeToTypeMap);
			T result;
			try
			{
				if (statusCodeToTypeMap[response.StatusCode.ToString()] == typeof(string))
				{
					result = (((response.Data == null) ? null : Encoding.UTF8.GetString(response.Data)) as T);
				}
				else if (statusCodeToTypeMap[response.StatusCode.ToString()] == typeof(Stream))
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
