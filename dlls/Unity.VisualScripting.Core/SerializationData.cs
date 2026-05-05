using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200013B RID: 315
	[Serializable]
	public struct SerializationData
	{
		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000897 RID: 2199 RVA: 0x00026134 File Offset: 0x00024334
		public string json
		{
			get
			{
				return this._json;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000898 RID: 2200 RVA: 0x0002613C File Offset: 0x0002433C
		public Object[] objectReferences
		{
			get
			{
				return this._objectReferences;
			}
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00026144 File Offset: 0x00024344
		public SerializationData(string json, IEnumerable<Object> objectReferences)
		{
			this._json = json;
			this._objectReferences = (((objectReferences != null) ? objectReferences.ToArray<Object>() : null) ?? Empty<Object>.array);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00026168 File Offset: 0x00024368
		public SerializationData(string json, params Object[] objectReferences)
		{
			this = new SerializationData(json, objectReferences);
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x00026172 File Offset: 0x00024372
		internal void Clear()
		{
			this._json = null;
			this._objectReferences = null;
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x00026184 File Offset: 0x00024384
		public string ToString(string title)
		{
			string result;
			using (StringWriter stringWriter = new StringWriter())
			{
				if (!string.IsNullOrEmpty(title))
				{
					stringWriter.WriteLine(title);
					stringWriter.WriteLine();
				}
				stringWriter.WriteLine("Object References: ");
				if (this.objectReferences.Length == 0)
				{
					stringWriter.WriteLine("(None)");
				}
				else
				{
					int num = 0;
					foreach (Object @object in this.objectReferences)
					{
						if (@object.IsUnityNull())
						{
							stringWriter.WriteLine(string.Format("{0}: null", num));
						}
						else if (UnityThread.allowsAPI)
						{
							stringWriter.WriteLine(string.Format("{0}: {1} [{2}] \"{3}\"", new object[]
							{
								num,
								@object.GetType().FullName,
								@object.GetHashCode(),
								@object.name
							}));
						}
						else
						{
							stringWriter.WriteLine(string.Format("{0}: {1} [{2}]", num, @object.GetType().FullName, @object.GetHashCode()));
						}
						num++;
					}
				}
				stringWriter.WriteLine();
				stringWriter.WriteLine("JSON: ");
				stringWriter.WriteLine(Serialization.PrettyPrint(this.json));
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x000262EC File Offset: 0x000244EC
		public override string ToString()
		{
			return this.ToString(null);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x000262F8 File Offset: 0x000244F8
		public void ShowString(string title = null)
		{
			string text = Path.GetTempPath() + Guid.NewGuid().ToString() + ".json";
			File.WriteAllText(text, this.ToString(title));
			Process.Start(text);
		}

		// Token: 0x0400020D RID: 525
		[SerializeField]
		private string _json;

		// Token: 0x0400020E RID: 526
		[SerializeField]
		private Object[] _objectReferences;
	}
}
