using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.RelayAllocations
{
	// Token: 0x0200004C RID: 76
	[Preserve]
	internal class RelayAllocationsApiBaseRequest
	{
		// Token: 0x06000161 RID: 353 RVA: 0x0000516E File Offset: 0x0000336E
		[Preserve]
		public List<string> AddParamsToQueryParams(List<string> queryParams, string key, string value)
		{
			key = UnityWebRequest.EscapeURL(key);
			value = UnityWebRequest.EscapeURL(value);
			queryParams.Add(key + "=" + value);
			return queryParams;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00005194 File Offset: 0x00003394
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

		// Token: 0x06000163 RID: 355 RVA: 0x0000526C File Offset: 0x0000346C
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

		// Token: 0x06000164 RID: 356 RVA: 0x000052E0 File Offset: 0x000034E0
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

		// Token: 0x06000165 RID: 357 RVA: 0x00005328 File Offset: 0x00003528
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

		// Token: 0x06000166 RID: 358 RVA: 0x00005398 File Offset: 0x00003598
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

		// Token: 0x06000167 RID: 359 RVA: 0x000053DC File Offset: 0x000035DC
		public byte[] ConstructBody(string s)
		{
			return Encoding.UTF8.GetBytes(s);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000053E9 File Offset: 0x000035E9
		public byte[] ConstructBody(object o)
		{
			return JsonSerialization.Serialize<object>(o);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000053F4 File Offset: 0x000035F4
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

		// Token: 0x0600016A RID: 362 RVA: 0x00005438 File Offset: 0x00003638
		public string GenerateContentTypeHeader(string[] contentTypes)
		{
			if (contentTypes.Length == 0)
			{
				return null;
			}
			for (int i = 0; i < contentTypes.Length; i++)
			{
				if (!string.IsNullOrWhiteSpace(contentTypes[i]) && RelayAllocationsApiBaseRequest.JsonRegex.IsMatch(contentTypes[i]))
				{
					return contentTypes[i];
				}
			}
			return contentTypes[0];
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00005479 File Offset: 0x00003679
		public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, FileStream stream, string contentType)
		{
			return new MultipartFormFileSection(paramName, this.ConstructBody(stream), this.GetFileName(stream.Name), contentType);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00005498 File Offset: 0x00003698
		public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, Stream stream, string contentType)
		{
			return new MultipartFormFileSection(paramName, this.ConstructBody(stream), Guid.NewGuid().ToString(), contentType);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000054C6 File Offset: 0x000036C6
		private string GetFileName(string filePath)
		{
			return Path.GetFileName(filePath);
		}

		// Token: 0x040000A8 RID: 168
		private static readonly Regex JsonRegex = new Regex("application\\/json(;\\s)?((charset=utf8|q=[0-1]\\.\\d)(\\s)?)*");
	}
}
