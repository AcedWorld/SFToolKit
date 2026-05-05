using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.QosDiscovery
{
	// Token: 0x02000046 RID: 70
	[Preserve]
	internal class QosDiscoveryApiBaseRequest
	{
		// Token: 0x06000147 RID: 327 RVA: 0x00005B02 File Offset: 0x00003D02
		[Preserve]
		public List<string> AddParamsToQueryParams(List<string> queryParams, string key, string value)
		{
			key = UnityWebRequest.EscapeURL(key);
			value = UnityWebRequest.EscapeURL(value);
			queryParams.Add(key + "=" + value);
			return queryParams;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00005B28 File Offset: 0x00003D28
		[Preserve]
		public List<string> AddParamsToQueryParams(List<string> queryParams, string key, List<string> values, string style, bool explode)
		{
			if (explode)
			{
				using (List<string>.Enumerator enumerator = values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						string s = enumerator.Current;
						string str = UnityWebRequest.EscapeURL(s);
						queryParams.Add(UnityWebRequest.EscapeURL(key) + "=" + str);
					}
					return queryParams;
				}
			}
			string text = UnityWebRequest.EscapeURL(key) + "=";
			foreach (string s2 in values)
			{
				text = text + UnityWebRequest.EscapeURL(s2) + ",";
			}
			text = text.Remove(text.Length - 1);
			queryParams.Add(text);
			return queryParams;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00005C00 File Offset: 0x00003E00
		[Preserve]
		public List<string> AddParamsToQueryParams(List<string> queryParams, Dictionary<string, string> modelVars)
		{
			foreach (string text in modelVars.Keys)
			{
				string str = UnityWebRequest.EscapeURL(modelVars[text]);
				queryParams.Add(UnityWebRequest.EscapeURL(text) + "=" + str);
			}
			return queryParams;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00005C74 File Offset: 0x00003E74
		[Preserve]
		public List<string> AddParamsToQueryParams<T>(List<string> queryParams, string key, T value)
		{
			if (queryParams == null)
			{
				queryParams = new List<string>();
			}
			key = UnityWebRequest.EscapeURL(key);
			string str = UnityWebRequest.EscapeURL(value.ToString());
			queryParams.Add(key + "=" + str);
			return queryParams;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00005CBC File Offset: 0x00003EBC
		[Preserve]
		public string GetPathParamString(List<string> pathParam)
		{
			string text = "";
			foreach (string s in pathParam)
			{
				text = text + UnityWebRequest.EscapeURL(s) + ",";
			}
			text = text.Remove(text.Length - 1);
			return text;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00005D2C File Offset: 0x00003F2C
		public byte[] ConstructBody(Stream stream)
		{
			if (stream != null)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					stream.CopyTo(memoryStream);
					return memoryStream.ToArray();
				}
			}
			return null;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00005D70 File Offset: 0x00003F70
		public byte[] ConstructBody(string s)
		{
			return Encoding.UTF8.GetBytes(s);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00005D7D File Offset: 0x00003F7D
		public byte[] ConstructBody(object o)
		{
			return JsonSerialization.Serialize<object>(o);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00005D88 File Offset: 0x00003F88
		public string GenerateAcceptHeader(string[] accepts)
		{
			if (accepts.Length == 0)
			{
				return null;
			}
			for (int i = 0; i < accepts.Length; i++)
			{
				if (string.Equals(accepts[i], "application/json", StringComparison.OrdinalIgnoreCase))
				{
					return "application/json";
				}
			}
			return string.Join(", ", accepts);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00005DCC File Offset: 0x00003FCC
		public string GenerateContentTypeHeader(string[] contentTypes)
		{
			if (contentTypes.Length == 0)
			{
				return null;
			}
			for (int i = 0; i < contentTypes.Length; i++)
			{
				if (!string.IsNullOrWhiteSpace(contentTypes[i]) && QosDiscoveryApiBaseRequest.JsonRegex.IsMatch(contentTypes[i]))
				{
					return contentTypes[i];
				}
			}
			return contentTypes[0];
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00005E0D File Offset: 0x0000400D
		public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, FileStream stream, string contentType)
		{
			return new MultipartFormFileSection(paramName, this.ConstructBody(stream), this.GetFileName(stream.Name), contentType);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00005E2C File Offset: 0x0000402C
		public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, Stream stream, string contentType)
		{
			return new MultipartFormFileSection(paramName, this.ConstructBody(stream), Guid.NewGuid().ToString(), contentType);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00005E5A File Offset: 0x0000405A
		private string GetFileName(string filePath)
		{
			return Path.GetFileName(filePath);
		}

		// Token: 0x040000A4 RID: 164
		private static readonly Regex JsonRegex = new Regex("application\\/json(;\\s)?((charset=utf8|q=[0-1]\\.\\d)(\\s)?)*");
	}
}
