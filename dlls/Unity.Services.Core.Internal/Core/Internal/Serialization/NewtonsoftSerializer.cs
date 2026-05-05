using System;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Unity.Services.Core.Internal.Serialization
{
	// Token: 0x02000059 RID: 89
	internal class NewtonsoftSerializer : IJsonSerializer
	{
		// Token: 0x06000199 RID: 409 RVA: 0x000041D9 File Offset: 0x000023D9
		public NewtonsoftSerializer(JsonSerializerSettings settings = null) : this(JsonSerializer.Create(settings))
		{
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000041E7 File Offset: 0x000023E7
		internal NewtonsoftSerializer(JsonSerializer serializer)
		{
			this.m_Serializer = serializer;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000041F8 File Offset: 0x000023F8
		public string SerializeObject<T>(T value)
		{
			string result;
			using (StringWriter stringWriter = new StringWriter(new StringBuilder(256), CultureInfo.InvariantCulture))
			{
				using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
				{
					jsonTextWriter.Formatting = this.m_Serializer.Formatting;
					this.m_Serializer.Serialize(jsonTextWriter, value, typeof(T));
					result = stringWriter.ToString();
				}
			}
			return result;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00004288 File Offset: 0x00002488
		public T DeserializeObject<T>(string value)
		{
			T result;
			using (JsonTextReader jsonTextReader = new JsonTextReader(new StringReader(value)))
			{
				result = (T)((object)this.m_Serializer.Deserialize(jsonTextReader, typeof(T)));
			}
			return result;
		}

		// Token: 0x04000079 RID: 121
		private readonly JsonSerializer m_Serializer;
	}
}
