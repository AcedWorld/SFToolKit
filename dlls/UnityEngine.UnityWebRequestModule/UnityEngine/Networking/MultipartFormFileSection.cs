using System;
using System.Text;

namespace UnityEngine.Networking
{
	// Token: 0x0200000C RID: 12
	public class MultipartFormFileSection : IMultipartFormSection
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00003A24 File Offset: 0x00001C24
		private void Init(string name, byte[] data, string fileName, string contentType)
		{
			this.name = name;
			this.data = data;
			this.file = fileName;
			this.content = contentType;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003A44 File Offset: 0x00001C44
		public MultipartFormFileSection(string name, byte[] data, string fileName, string contentType)
		{
			bool flag = data == null || data.Length < 1;
			if (flag)
			{
				throw new ArgumentException("Cannot create a multipart form file section without body data");
			}
			bool flag2 = string.IsNullOrEmpty(fileName);
			if (flag2)
			{
				fileName = "file.dat";
			}
			bool flag3 = string.IsNullOrEmpty(contentType);
			if (flag3)
			{
				contentType = "application/octet-stream";
			}
			this.Init(name, data, fileName, contentType);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003AA8 File Offset: 0x00001CA8
		public MultipartFormFileSection(byte[] data) : this(null, data, null, null)
		{
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003AB6 File Offset: 0x00001CB6
		public MultipartFormFileSection(string fileName, byte[] data) : this(null, data, fileName, null)
		{
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003AC4 File Offset: 0x00001CC4
		public MultipartFormFileSection(string name, string data, Encoding dataEncoding, string fileName)
		{
			bool flag = string.IsNullOrEmpty(data);
			if (flag)
			{
				throw new ArgumentException("Cannot create a multipart form file section without body data");
			}
			bool flag2 = dataEncoding == null;
			if (flag2)
			{
				dataEncoding = Encoding.UTF8;
			}
			byte[] bytes = dataEncoding.GetBytes(data);
			bool flag3 = string.IsNullOrEmpty(fileName);
			if (flag3)
			{
				fileName = "file.txt";
			}
			bool flag4 = string.IsNullOrEmpty(this.content);
			if (flag4)
			{
				this.content = "text/plain; charset=" + dataEncoding.WebName;
			}
			this.Init(name, bytes, fileName, this.content);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003B56 File Offset: 0x00001D56
		public MultipartFormFileSection(string data, Encoding dataEncoding, string fileName) : this(null, data, dataEncoding, fileName)
		{
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003B64 File Offset: 0x00001D64
		public MultipartFormFileSection(string data, string fileName) : this(data, null, fileName)
		{
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00003B74 File Offset: 0x00001D74
		public string sectionName
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00003B8C File Offset: 0x00001D8C
		public byte[] sectionData
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00003BA4 File Offset: 0x00001DA4
		public string fileName
		{
			get
			{
				return this.file;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003BBC File Offset: 0x00001DBC
		public string contentType
		{
			get
			{
				return this.content;
			}
		}

		// Token: 0x0400001F RID: 31
		private string name;

		// Token: 0x04000020 RID: 32
		private byte[] data;

		// Token: 0x04000021 RID: 33
		private string file;

		// Token: 0x04000022 RID: 34
		private string content;
	}
}
