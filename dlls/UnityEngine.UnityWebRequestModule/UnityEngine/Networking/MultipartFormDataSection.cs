using System;
using System.Text;

namespace UnityEngine.Networking
{
	// Token: 0x0200000B RID: 11
	public class MultipartFormDataSection : IMultipartFormSection
	{
		// Token: 0x06000069 RID: 105 RVA: 0x000038B8 File Offset: 0x00001AB8
		public MultipartFormDataSection(string name, byte[] data, string contentType)
		{
			bool flag = data == null || data.Length < 1;
			if (flag)
			{
				throw new ArgumentException("Cannot create a multipart form data section without body data");
			}
			this.name = name;
			this.data = data;
			this.content = contentType;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000038FE File Offset: 0x00001AFE
		public MultipartFormDataSection(string name, byte[] data) : this(name, data, null)
		{
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000390B File Offset: 0x00001B0B
		public MultipartFormDataSection(byte[] data) : this(null, data)
		{
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003918 File Offset: 0x00001B18
		public MultipartFormDataSection(string name, string data, Encoding encoding, string contentType)
		{
			bool flag = string.IsNullOrEmpty(data);
			if (flag)
			{
				throw new ArgumentException("Cannot create a multipart form data section without body data");
			}
			byte[] bytes = encoding.GetBytes(data);
			this.name = name;
			this.data = bytes;
			bool flag2 = contentType != null && !contentType.Contains("encoding=");
			if (flag2)
			{
				contentType = contentType.Trim() + "; encoding=" + encoding.WebName;
			}
			this.content = contentType;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003996 File Offset: 0x00001B96
		public MultipartFormDataSection(string name, string data, string contentType) : this(name, data, Encoding.UTF8, contentType)
		{
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000039A8 File Offset: 0x00001BA8
		public MultipartFormDataSection(string name, string data) : this(name, data, "text/plain")
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000039B9 File Offset: 0x00001BB9
		public MultipartFormDataSection(string data) : this(null, data)
		{
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000039C8 File Offset: 0x00001BC8
		public string sectionName
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000039E0 File Offset: 0x00001BE0
		public byte[] sectionData
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000039F8 File Offset: 0x00001BF8
		public string fileName
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00003A0C File Offset: 0x00001C0C
		public string contentType
		{
			get
			{
				return this.content;
			}
		}

		// Token: 0x0400001C RID: 28
		private string name;

		// Token: 0x0400001D RID: 29
		private byte[] data;

		// Token: 0x0400001E RID: 30
		private string content;
	}
}
