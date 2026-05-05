using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Lobby
{
	// Token: 0x02000066 RID: 102
	[Preserve]
	internal class LobbyApiBaseRequest
	{
		// Token: 0x060002AC RID: 684 RVA: 0x0000980A File Offset: 0x00007A0A
		[Preserve]
		public List<string> AddParamsToQueryParams(List<string> queryParams, string key, string value)
		{
			key = UnityWebRequest.EscapeURL(key);
			value = UnityWebRequest.EscapeURL(value);
			queryParams.Add(key + "=" + value);
			return queryParams;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00009830 File Offset: 0x00007A30
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

		// Token: 0x060002AE RID: 686 RVA: 0x00009908 File Offset: 0x00007B08
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

		// Token: 0x060002AF RID: 687 RVA: 0x0000997C File Offset: 0x00007B7C
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

		// Token: 0x060002B0 RID: 688 RVA: 0x000099C4 File Offset: 0x00007BC4
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

		// Token: 0x060002B1 RID: 689 RVA: 0x00009A34 File Offset: 0x00007C34
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

		// Token: 0x060002B2 RID: 690 RVA: 0x00009A78 File Offset: 0x00007C78
		public byte[] ConstructBody(string s)
		{
			return Encoding.UTF8.GetBytes(s);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00009A85 File Offset: 0x00007C85
		public byte[] ConstructBody(object o)
		{
			return JsonSerialization.Serialize<object>(o);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00009A90 File Offset: 0x00007C90
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

		// Token: 0x060002B5 RID: 693 RVA: 0x00009AD4 File Offset: 0x00007CD4
		public string GenerateContentTypeHeader(string[] contentTypes)
		{
			if (contentTypes.Length == 0)
			{
				return null;
			}
			for (int i = 0; i < contentTypes.Length; i++)
			{
				if (!string.IsNullOrWhiteSpace(contentTypes[i]) && LobbyApiBaseRequest.JsonRegex.IsMatch(contentTypes[i]))
				{
					return contentTypes[i];
				}
			}
			return contentTypes[0];
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00009B15 File Offset: 0x00007D15
		public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, FileStream stream, string contentType)
		{
			return new MultipartFormFileSection(paramName, this.ConstructBody(stream), this.GetFileName(stream.Name), contentType);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00009B34 File Offset: 0x00007D34
		public IMultipartFormSection GenerateMultipartFormFileSection(string paramName, Stream stream, string contentType)
		{
			return new MultipartFormFileSection(paramName, this.ConstructBody(stream), Guid.NewGuid().ToString(), contentType);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00009B62 File Offset: 0x00007D62
		private string GetFileName(string filePath)
		{
			return Path.GetFileName(filePath);
		}

		// Token: 0x04000133 RID: 307
		private static readonly Regex JsonRegex = new Regex("application\\/json(;\\s)?((charset=utf8|q=[0-1]\\.\\d)(\\s)?)*");
	}
}
