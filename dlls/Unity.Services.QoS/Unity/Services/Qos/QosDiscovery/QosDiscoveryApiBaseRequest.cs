using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.QosDiscovery
{
	// Token: 0x02000076 RID: 118
	[Preserve]
	internal class QosDiscoveryApiBaseRequest
	{
		// Token: 0x0600023F RID: 575 RVA: 0x000080CE File Offset: 0x000062CE
		[Preserve]
		public List<string> AddParamsToQueryParams(List<string> queryParams, string key, string value)
		{
			key = UnityWebRequest.EscapeURL(key);
			value = UnityWebRequest.EscapeURL(value);
			queryParams.Add(key + "=" + value);
			return queryParams;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000080F4 File Offset: 0x000062F4
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

		// Token: 0x06000241 RID: 577 RVA: 0x000081CC File Offset: 0x000063CC
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

		// Token: 0x06000242 RID: 578 RVA: 0x00008240 File Offset: 0x00006440
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

		// Token: 0x06000243 RID: 579 RVA: 0x00008288 File Offset: 0x00006488
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

		// Token: 0x06000244 RID: 580 RVA: 0x000082F8 File Offset: 0x000064F8
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

		// Token: 0x06000245 RID: 581 RVA: 0x0000833C File Offset: 0x0000653C
		public byte[] ConstructBody(string s)
		{
			return Encoding.UTF8.GetBytes(s);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00008349 File Offset: 0x00006549
		public byte[] ConstructBody(object o)
		{
			return JsonSerialization.Serialize<object>(o);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00008354 File Offset: 0x00006554
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

		// Token: 0x06000248 RID: 584 RVA: 0x00008398 File Offset: 0x00006598
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

		// Token: 0x06000249 RID: 585 RVA: 0x000083D9 File Offset: 0x000065D9
		public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, FileStream stream, string contentType)
		{
			return new MultipartFormFileSection(paramName, this.ConstructBody(stream), this.GetFileName(stream.Name), contentType);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x000083F8 File Offset: 0x000065F8
		public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, Stream stream, string contentType)
		{
			return new MultipartFormFileSection(paramName, this.ConstructBody(stream), Guid.NewGuid().ToString(), contentType);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00008426 File Offset: 0x00006626
		private string GetFileName(string filePath)
		{
			return Path.GetFileName(filePath);
		}

		// Token: 0x040000E8 RID: 232
		private static readonly Regex JsonRegex = new Regex("application\\/json(;\\s)?((charset=utf8|q=[0-1]\\.\\d)(\\s)?)*");
	}
}
