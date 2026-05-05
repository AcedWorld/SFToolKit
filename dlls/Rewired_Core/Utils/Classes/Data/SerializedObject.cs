using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x020004F9 RID: 1273
	[Preserve]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SerializedObject : IEnumerable<SerializedObject.Field>, IEnumerable, IExportToXml, IExportToJson, IAddValue<object>, IAddKeyValue<string, object>
	{
		// Token: 0x060033F5 RID: 13301 RVA: 0x00027EF3 File Offset: 0x000260F3
		[CustomObfuscation(rename = false)]
		private SerializedObject() : this(0)
		{
		}

		// Token: 0x060033F6 RID: 13302 RVA: 0x00027EFC File Offset: 0x000260FC
		private SerializedObject(int A_1)
		{
			this.DACIrtfBTenFaoSkcLCSYVGuKwjeA = SerializedObject.ObjectType.List;
			this.QKOxGOZeKAxbbnFXjZuJglfzqNLN = new IndexedDictionary<string, SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA>(A_1, true);
		}

		// Token: 0x060033F7 RID: 13303 RVA: 0x00027F18 File Offset: 0x00026118
		public SerializedObject(Type A_1, SerializedObject.ObjectType A_2) : this(A_1, A_2, 0)
		{
		}

		// Token: 0x060033F8 RID: 13304 RVA: 0x00027F23 File Offset: 0x00026123
		public SerializedObject(Type A_1, SerializedObject.ObjectType A_2, int A_3) : this(A_3)
		{
			this.YAGKBjptpojxIwbWwsmquHXZGCmV = A_1;
			this.objectType = A_2;
		}

		// Token: 0x060033F9 RID: 13305 RVA: 0x000B11A4 File Offset: 0x000AF3A4
		public SerializedObject(Type A_1, IDictionary<string, object> A_2, SerializedObject.ObjectType A_3) : this(A_1, A_3, (A_2 != null) ? A_2.Count : 0)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<string, object> keyValuePair in A_2)
			{
				this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.Add(keyValuePair.Key, new SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA((keyValuePair.Value != null) ? keyValuePair.Value.GetType() : null, keyValuePair.Value, SerializedObject.FieldOptions.None));
			}
		}

		// Token: 0x17000BE0 RID: 3040
		// (get) Token: 0x060033FA RID: 13306 RVA: 0x00027F3A File Offset: 0x0002613A
		private bool allowDuplicateKeys
		{
			get
			{
				return this.DACIrtfBTenFaoSkcLCSYVGuKwjeA == SerializedObject.ObjectType.List;
			}
		}

		// Token: 0x17000BE1 RID: 3041
		// (get) Token: 0x060033FB RID: 13307 RVA: 0x00027F45 File Offset: 0x00026145
		// (set) Token: 0x060033FC RID: 13308 RVA: 0x00027F4D File Offset: 0x0002614D
		public SerializedObject.ObjectType objectType
		{
			get
			{
				return this.DACIrtfBTenFaoSkcLCSYVGuKwjeA;
			}
			set
			{
				if (value == this.DACIrtfBTenFaoSkcLCSYVGuKwjeA)
				{
					return;
				}
				this.DACIrtfBTenFaoSkcLCSYVGuKwjeA = value;
				this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.AllowDuplicateKeys = this.allowDuplicateKeys;
			}
		}

		// Token: 0x17000BE2 RID: 3042
		// (get) Token: 0x060033FD RID: 13309 RVA: 0x00027F71 File Offset: 0x00026171
		public Type type
		{
			get
			{
				return this.YAGKBjptpojxIwbWwsmquHXZGCmV;
			}
		}

		// Token: 0x17000BE3 RID: 3043
		// (get) Token: 0x060033FE RID: 13310 RVA: 0x00027F79 File Offset: 0x00026179
		// (set) Token: 0x060033FF RID: 13311 RVA: 0x00027F81 File Offset: 0x00026181
		public SerializedObject.XmlInfo xmlInfo
		{
			get
			{
				return this.IxoBqzEMYXrSXulbNkPQgYShZYCvA;
			}
			set
			{
				this.IxoBqzEMYXrSXulbNkPQgYShZYCvA = value;
			}
		}

		// Token: 0x17000BE4 RID: 3044
		// (get) Token: 0x06003400 RID: 13312 RVA: 0x00027F8A File Offset: 0x0002618A
		public int count
		{
			get
			{
				return this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.Count;
			}
		}

		// Token: 0x17000BE5 RID: 3045
		public SerializedObject.Field this[int index]
		{
			get
			{
				SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA ePuzKMqGVGxTbTqnjDctRAPwgMThA = this.QKOxGOZeKAxbbnFXjZuJglfzqNLN[index];
				return new SerializedObject.Field(this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.GetKeyAt(index), ePuzKMqGVGxTbTqnjDctRAPwgMThA.yShCLJXrSscxUmhcDBnIxQPjIaku, ePuzKMqGVGxTbTqnjDctRAPwgMThA.XbvBSGBHPBMclatbIGUMnrWPcAmaA, ePuzKMqGVGxTbTqnjDctRAPwgMThA.ndQlHJYCRDBPNwIDhImYeyPteOi);
			}
		}

		// Token: 0x06003402 RID: 13314 RVA: 0x00027F97 File Offset: 0x00026197
		public void Add<T>(string fieldName, T value, SerializedObject.FieldOptions options = SerializedObject.FieldOptions.None)
		{
			this.Add(typeof(T), fieldName, value, options);
		}

		// Token: 0x06003403 RID: 13315 RVA: 0x000B1284 File Offset: 0x000AF484
		public void Add(Type type, string fieldName, object value, SerializedObject.FieldOptions options = SerializedObject.FieldOptions.None)
		{
			if (type != null && value != null && type != value.GetType())
			{
				throw new Exception("Type does not match value type.");
			}
			if (string.IsNullOrEmpty(fieldName))
			{
				if (this.DACIrtfBTenFaoSkcLCSYVGuKwjeA != SerializedObject.ObjectType.List)
				{
					throw new ArgumentNullException("fieldName");
				}
				fieldName = "value";
			}
			if (this.allowDuplicateKeys)
			{
				this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.Add(fieldName, new SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA(type, value, options));
				return;
			}
			if (!this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.ContainsKey(fieldName))
			{
				this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.Add(fieldName, new SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA(type, value, options));
				return;
			}
			this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.SetValue(fieldName, new SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA(type, value, options));
		}

		// Token: 0x06003404 RID: 13316 RVA: 0x00027FB1 File Offset: 0x000261B1
		public void Add(string fieldName, object value)
		{
			this.Add((value != null) ? value.GetType() : null, fieldName, value, SerializedObject.FieldOptions.None);
		}

		// Token: 0x06003405 RID: 13317 RVA: 0x00027FC8 File Offset: 0x000261C8
		public bool Remove(string fieldName)
		{
			return !string.IsNullOrEmpty(fieldName) && this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.Remove(fieldName);
		}

		// Token: 0x06003406 RID: 13318 RVA: 0x00027FE0 File Offset: 0x000261E0
		public bool Contains(string fieldName)
		{
			return !string.IsNullOrEmpty(fieldName) && this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.ContainsKey(fieldName);
		}

		// Token: 0x06003407 RID: 13319 RVA: 0x000B132C File Offset: 0x000AF52C
		public Type GetDataType(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return null;
			}
			SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA ePuzKMqGVGxTbTqnjDctRAPwgMThA;
			if (!this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.TryGetValue(fieldName, out ePuzKMqGVGxTbTqnjDctRAPwgMThA))
			{
				return null;
			}
			return ePuzKMqGVGxTbTqnjDctRAPwgMThA.XbvBSGBHPBMclatbIGUMnrWPcAmaA;
		}

		// Token: 0x06003408 RID: 13320 RVA: 0x000B135C File Offset: 0x000AF55C
		public bool TryGetOriginalValue(string fieldName, out object value)
		{
			value = null;
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA ePuzKMqGVGxTbTqnjDctRAPwgMThA;
			if (!this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.TryGetValue(fieldName, out ePuzKMqGVGxTbTqnjDctRAPwgMThA))
			{
				return false;
			}
			value = ePuzKMqGVGxTbTqnjDctRAPwgMThA.yShCLJXrSscxUmhcDBnIxQPjIaku;
			return true;
		}

		// Token: 0x06003409 RID: 13321 RVA: 0x000B1394 File Offset: 0x000AF594
		public SerializedObject.Field GetEntry(string fieldName)
		{
			KeyValuePair<string, SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA> entry = this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.GetEntry(fieldName);
			return new SerializedObject.Field(entry.Key, entry.Value.yShCLJXrSscxUmhcDBnIxQPjIaku, entry.Value.XbvBSGBHPBMclatbIGUMnrWPcAmaA, entry.Value.ndQlHJYCRDBPNwIDhImYeyPteOi);
		}

		// Token: 0x0600340A RID: 13322 RVA: 0x000B13E0 File Offset: 0x000AF5E0
		public object GetOriginalValue(string fieldName)
		{
			return this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.GetEntry(fieldName).Value.yShCLJXrSscxUmhcDBnIxQPjIaku;
		}

		// Token: 0x0600340B RID: 13323 RVA: 0x00027FF8 File Offset: 0x000261F8
		public object GetOriginalValue(int index)
		{
			return this.QKOxGOZeKAxbbnFXjZuJglfzqNLN[index].yShCLJXrSscxUmhcDBnIxQPjIaku;
		}

		// Token: 0x0600340C RID: 13324 RVA: 0x0002800B File Offset: 0x0002620B
		public T GetOriginalValue<T>(string fieldName)
		{
			return (T)((object)this.GetOriginalValue(fieldName));
		}

		// Token: 0x0600340D RID: 13325 RVA: 0x00028019 File Offset: 0x00026219
		public T GetOriginalValue<T>(int index)
		{
			return (T)((object)this.GetOriginalValue(index));
		}

		// Token: 0x0600340E RID: 13326 RVA: 0x000B1408 File Offset: 0x000AF608
		public bool TryGetDeserializedValue<T>(string fieldName, out T value)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				value = default(T);
				return false;
			}
			SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA ePuzKMqGVGxTbTqnjDctRAPwgMThA;
			if (!this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.TryGetValue(fieldName, out ePuzKMqGVGxTbTqnjDctRAPwgMThA))
			{
				value = default(T);
				return false;
			}
			return SerializedObject.hrNEkyCtcZztAmSQOAJkDvSZznlH<T>(ePuzKMqGVGxTbTqnjDctRAPwgMThA.yShCLJXrSscxUmhcDBnIxQPjIaku, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		// Token: 0x0600340F RID: 13327 RVA: 0x000B1458 File Offset: 0x000AF658
		public bool TryGetDeserializedValue<T>(int index, out T value)
		{
			if (index > this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.Count)
			{
				value = default(T);
				return false;
			}
			return SerializedObject.hrNEkyCtcZztAmSQOAJkDvSZznlH<T>(this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.GetEntryAt(index).Value.yShCLJXrSscxUmhcDBnIxQPjIaku, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		// Token: 0x06003410 RID: 13328 RVA: 0x000B14A8 File Offset: 0x000AF6A8
		public bool TryGetDeserializedValueByRef<T>(string fieldName, ref T value)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			T t;
			if (!this.TryGetDeserializedValue<T>(fieldName, out t))
			{
				return false;
			}
			value = t;
			return true;
		}

		// Token: 0x06003411 RID: 13329 RVA: 0x000B14D4 File Offset: 0x000AF6D4
		public bool TryGetDeserializedValueByRef<T>(int index, ref T value)
		{
			if (index > this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.Count)
			{
				return false;
			}
			T t;
			if (!this.TryGetDeserializedValue<T>(index, out t))
			{
				return false;
			}
			value = t;
			return true;
		}

		// Token: 0x06003412 RID: 13330 RVA: 0x000B1508 File Offset: 0x000AF708
		public string ToXmlString(bool writeDocumentTag)
		{
			if (this.IxoBqzEMYXrSXulbNkPQgYShZYCvA == null)
			{
				throw new Exception("XmlInfo is null. Cannot write Xml without XmlInfo.");
			}
			string result = string.Empty;
			using (StringWriter stringWriter = new StringWriter())
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
				{
					if (writeDocumentTag)
					{
						xmlWriter.WriteStartDocument();
					}
					this.XuYwYbWaDrAssHvmXvfJHetsMGYeA(xmlWriter);
					xmlWriter.Flush();
				}
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x06003413 RID: 13331 RVA: 0x00028027 File Offset: 0x00026227
		public string ToJsonString()
		{
			return JsonWriter.ToJson(this);
		}

		// Token: 0x06003414 RID: 13332 RVA: 0x000B1590 File Offset: 0x000AF790
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("count = ");
			stringBuilder.Append(this.count.ToString());
			stringBuilder.Append("\n");
			stringBuilder.Append("type = ");
			stringBuilder.Append((this.YAGKBjptpojxIwbWwsmquHXZGCmV != null) ? this.YAGKBjptpojxIwbWwsmquHXZGCmV.Name : "NULL\n");
			stringBuilder.Append("objectType = ");
			stringBuilder.Append(this.DACIrtfBTenFaoSkcLCSYVGuKwjeA.ToString());
			stringBuilder.Append("\n");
			stringBuilder.Append("xmlInfo = ");
			stringBuilder.Append((this.IxoBqzEMYXrSXulbNkPQgYShZYCvA != null) ? this.IxoBqzEMYXrSXulbNkPQgYShZYCvA.ToString() : "NULL\n");
			stringBuilder.Append("\n");
			for (int i = 0; i < this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.Count; i++)
			{
				string keyAt = this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.GetKeyAt(i);
				stringBuilder.Append("key = ");
				stringBuilder.Append((keyAt != null) ? keyAt : "NULL");
				stringBuilder.Append(", value = ");
				stringBuilder.Append(this.QKOxGOZeKAxbbnFXjZuJglfzqNLN[i].ToString());
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06003415 RID: 13333 RVA: 0x0002802F File Offset: 0x0002622F
		private void XuYwYbWaDrAssHvmXvfJHetsMGYeA(XmlWriter A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("writer");
			}
			A_1.WriteStartElement(this.type.Name, "http://guavaman.com/rewired");
			this.BETcERFUKnKqOHwJHlsAekIHqCeA(A_1);
			A_1.WriteEndElement();
		}

		// Token: 0x06003416 RID: 13334 RVA: 0x000B16F0 File Offset: 0x000AF8F0
		private void BETcERFUKnKqOHwJHlsAekIHqCeA(XmlWriter A_1)
		{
			int num = (this.xmlInfo != null) ? this.xmlInfo.attributes.Count : 0;
			for (int i = 0; i < num; i++)
			{
				SerializedObject.XmlInfo.oJHDRzAtXKnwfdsseCCuHcTJyEqGB oJHDRzAtXKnwfdsseCCuHcTJyEqGB = this.xmlInfo.attributes[i];
				if (!(oJHDRzAtXKnwfdsseCCuHcTJyEqGB is SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP))
				{
					throw new NotImplementedException();
				}
				SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP lngACPpwshkKROSusbBaVylbemLP = oJHDRzAtXKnwfdsseCCuHcTJyEqGB as SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP;
				if (!string.IsNullOrEmpty(lngACPpwshkKROSusbBaVylbemLP.RYjXkEgviKdbPKjefiQAbwFNRXTlA))
				{
					A_1.WriteAttributeString(lngACPpwshkKROSusbBaVylbemLP.RYjXkEgviKdbPKjefiQAbwFNRXTlA, lngACPpwshkKROSusbBaVylbemLP.icHQGefQbedChDWtubHCUkbucRzbb, lngACPpwshkKROSusbBaVylbemLP.YulEumEWpPNPEIqyPwfvMWtcRrsFA, lngACPpwshkKROSusbBaVylbemLP.hQsdIPBPqieQLwIOlxlBAUDVYhDFA);
				}
				else if (!string.IsNullOrEmpty(lngACPpwshkKROSusbBaVylbemLP.YulEumEWpPNPEIqyPwfvMWtcRrsFA))
				{
					A_1.WriteAttributeString(lngACPpwshkKROSusbBaVylbemLP.icHQGefQbedChDWtubHCUkbucRzbb, lngACPpwshkKROSusbBaVylbemLP.YulEumEWpPNPEIqyPwfvMWtcRrsFA, lngACPpwshkKROSusbBaVylbemLP.hQsdIPBPqieQLwIOlxlBAUDVYhDFA);
				}
				else
				{
					A_1.WriteAttributeString(lngACPpwshkKROSusbBaVylbemLP.icHQGefQbedChDWtubHCUkbucRzbb, lngACPpwshkKROSusbBaVylbemLP.hQsdIPBPqieQLwIOlxlBAUDVYhDFA);
				}
			}
			for (int j = 0; j < this.count; j++)
			{
				SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA ePuzKMqGVGxTbTqnjDctRAPwgMThA = this.QKOxGOZeKAxbbnFXjZuJglfzqNLN[j];
				string text = this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.GetKeyAt(j);
				if ((ePuzKMqGVGxTbTqnjDctRAPwgMThA.ndQlHJYCRDBPNwIDhImYeyPteOi & SerializedObject.FieldOptions.ExculdeFromXml) == SerializedObject.FieldOptions.None)
				{
					if (string.IsNullOrEmpty(text))
					{
						if (ePuzKMqGVGxTbTqnjDctRAPwgMThA.XbvBSGBHPBMclatbIGUMnrWPcAmaA != null)
						{
							text = ePuzKMqGVGxTbTqnjDctRAPwgMThA.GetType().Name;
						}
						else if (ePuzKMqGVGxTbTqnjDctRAPwgMThA.yShCLJXrSscxUmhcDBnIxQPjIaku != null)
						{
							text = ePuzKMqGVGxTbTqnjDctRAPwgMThA.yShCLJXrSscxUmhcDBnIxQPjIaku.GetType().Name;
						}
						else
						{
							text = "value";
						}
					}
					SerializationTools.WriteXmlElement(A_1, text, ePuzKMqGVGxTbTqnjDctRAPwgMThA.yShCLJXrSscxUmhcDBnIxQPjIaku);
				}
			}
		}

		// Token: 0x17000BE6 RID: 3046
		// (get) Token: 0x06003417 RID: 13335 RVA: 0x000042E2 File Offset: 0x000024E2
		bool IExportToXml.writesOwnElementTag
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06003418 RID: 13336 RVA: 0x00028062 File Offset: 0x00026262
		void IExportToXml.ydDmcYalzKSEzefOcRVAxCiGGzchA(XmlWriter A_1)
		{
			this.XuYwYbWaDrAssHvmXvfJHetsMGYeA(A_1);
		}

		// Token: 0x06003419 RID: 13337 RVA: 0x000B1860 File Offset: 0x000AFA60
		void IExportToJson.gkgVBlSJypPcJyUfhjhDjiIMWmhN(StringBuilder A_1, Action<StringBuilder, object> A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("stringBuilder");
			}
			if (A_2 == null)
			{
				throw new ArgumentNullException("appendValueDelegate");
			}
			int count = this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.Count;
			if (this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.ContainsDuplicateKeys)
			{
				A_1.Append('[');
				bool flag = true;
				for (int i = 0; i < count; i++)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						A_1.Append(',');
					}
					A_2(A_1, this.QKOxGOZeKAxbbnFXjZuJglfzqNLN[i].yShCLJXrSscxUmhcDBnIxQPjIaku);
				}
				A_1.Append(']');
				return;
			}
			A_1.Append('{');
			bool flag2 = true;
			for (int j = 0; j < count; j++)
			{
				if (flag2)
				{
					flag2 = false;
				}
				else
				{
					A_1.Append(',');
				}
				SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA ePuzKMqGVGxTbTqnjDctRAPwgMThA = this.QKOxGOZeKAxbbnFXjZuJglfzqNLN[j];
				string value = this.QKOxGOZeKAxbbnFXjZuJglfzqNLN.GetKeyAt(j);
				if (string.IsNullOrEmpty(value))
				{
					value = j.ToString();
				}
				A_1.Append('"');
				A_1.Append(value);
				A_1.Append("\":");
				A_2(A_1, ePuzKMqGVGxTbTqnjDctRAPwgMThA.yShCLJXrSscxUmhcDBnIxQPjIaku);
			}
			A_1.Append('}');
		}

		// Token: 0x0600341A RID: 13338 RVA: 0x0002806B File Offset: 0x0002626B
		void IAddValue<object>.HPMrSRLGUSzAmUifoPATDtddIewQ(object A_1)
		{
			this.Add(null, A_1);
		}

		// Token: 0x0600341B RID: 13339 RVA: 0x00028075 File Offset: 0x00026275
		void IAddKeyValue<string, object>.sfFEABRPXYfvSgHWhExCRaYfAzvvA(string A_1, object A_2)
		{
			this.Add(A_1, A_2);
		}

		// Token: 0x0600341C RID: 13340 RVA: 0x0002807F File Offset: 0x0002627F
		IEnumerator<SerializedObject.Field> IEnumerable<SerializedObject.Field>.GetEnumerator()
		{
			return new SerializedObject.Enumerator(this.QKOxGOZeKAxbbnFXjZuJglfzqNLN);
		}

		// Token: 0x0600341D RID: 13341 RVA: 0x0002807F File Offset: 0x0002627F
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new SerializedObject.Enumerator(this.QKOxGOZeKAxbbnFXjZuJglfzqNLN);
		}

		// Token: 0x0600341E RID: 13342 RVA: 0x000B197C File Offset: 0x000AFB7C
		private static bool hrNEkyCtcZztAmSQOAJkDvSZznlH<\u0001>(object A_0, out \u0001 A_1, NumberStyles A_2 = NumberStyles.Any, CultureInfo A_3 = null)
		{
			object obj;
			if (!SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(typeof(\u0001), A_0, out obj, A_2, A_3))
			{
				A_1 = default(\u0001);
				return false;
			}
			A_1 = (\u0001)((object)obj);
			return true;
		}

		// Token: 0x0600341F RID: 13343 RVA: 0x000B19B8 File Offset: 0x000AFBB8
		private static bool EjLpdzsCKTDDqCqcRGyXcVZqaARW(Type A_0, object A_1, out object A_2, NumberStyles A_3 = NumberStyles.Any, CultureInfo A_4 = null)
		{
			A_2 = null;
			if (A_1 == null)
			{
				if (A_0 == typeof(string))
				{
					A_2 = string.Empty;
					return true;
				}
				return !ReflectionTools.IsValueType(A_0) || Nullable.GetUnderlyingType(A_0) != null;
			}
			else
			{
				Type type = A_1.GetType();
				if (A_0 == type)
				{
					A_2 = A_1;
					return true;
				}
				try
				{
					if (A_0 == typeof(string))
					{
						A_2 = A_1.ToString();
						return true;
					}
					if (A_0 == typeof(int))
					{
						if (type == typeof(float))
						{
							A_2 = (int)((float)A_1);
						}
						else if (type == typeof(uint))
						{
							A_2 = (int)((uint)A_1);
						}
						else if (type == typeof(long))
						{
							A_2 = (int)((long)A_1);
						}
						else if (type == typeof(ulong))
						{
							A_2 = (int)((ulong)A_1);
						}
						else if (type == typeof(double))
						{
							A_2 = (int)((double)A_1);
						}
						else if (type == typeof(decimal))
						{
							A_2 = (int)((decimal)A_1);
						}
						else if (type == typeof(short))
						{
							A_2 = (int)((short)A_1);
						}
						else if (type == typeof(ushort))
						{
							A_2 = (int)((ushort)A_1);
						}
						else if (type == typeof(byte))
						{
							A_2 = (int)((byte)A_1);
						}
						else if (type == typeof(sbyte))
						{
							A_2 = (int)((sbyte)A_1);
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							int num;
							if (A_4 != null)
							{
								if (!int.TryParse(A_1.ToString(), A_3, A_4, out num))
								{
									return false;
								}
							}
							else if (!int.TryParse(A_1.ToString(), out num))
							{
								return false;
							}
							A_2 = num;
						}
						return true;
					}
					if (A_0 == typeof(float))
					{
						if (type == typeof(int))
						{
							A_2 = (float)((int)A_1);
						}
						else if (type == typeof(uint))
						{
							A_2 = (uint)A_1;
						}
						else if (type == typeof(long))
						{
							A_2 = (float)((long)A_1);
						}
						else if (type == typeof(ulong))
						{
							A_2 = (ulong)A_1;
						}
						else if (type == typeof(double))
						{
							A_2 = (float)((double)A_1);
						}
						else if (type == typeof(decimal))
						{
							A_2 = (float)((decimal)A_1);
						}
						else if (type == typeof(short))
						{
							A_2 = (float)((short)A_1);
						}
						else if (type == typeof(ushort))
						{
							A_2 = (float)((ushort)A_1);
						}
						else if (type == typeof(byte))
						{
							A_2 = (float)((byte)A_1);
						}
						else if (type == typeof(sbyte))
						{
							A_2 = (float)((sbyte)A_1);
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							float num2;
							if (A_4 != null)
							{
								if (!float.TryParse(A_1.ToString(), A_3, A_4, out num2))
								{
									return false;
								}
							}
							else if (!float.TryParse(A_1.ToString(), out num2))
							{
								return false;
							}
							A_2 = num2;
						}
						return true;
					}
					if (ReflectionTools.IsEnum(A_0))
					{
						object value;
						if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(ReflectionTools.GetUnderlyingEnumType(A_0), A_1, out value, A_3, A_4))
						{
							A_2 = Enum.ToObject(A_0, value);
							return true;
						}
						if (type != typeof(string))
						{
							goto IL_1CBF;
						}
						try
						{
							A_2 = Enum.Parse(A_0, (string)A_1, true);
							return true;
						}
						catch
						{
							A_2 = null;
							return false;
						}
					}
					if (A_0 == typeof(uint))
					{
						if (type == typeof(int))
						{
							A_2 = (uint)((int)A_1);
						}
						else if (type == typeof(float))
						{
							A_2 = (uint)((float)A_1);
						}
						else if (type == typeof(long))
						{
							A_2 = (uint)((long)A_1);
						}
						else if (type == typeof(ulong))
						{
							A_2 = (uint)((ulong)A_1);
						}
						else if (type == typeof(double))
						{
							A_2 = (uint)((double)A_1);
						}
						else if (type == typeof(decimal))
						{
							A_2 = (uint)((decimal)A_1);
						}
						else if (type == typeof(short))
						{
							A_2 = (uint)((short)A_1);
						}
						else if (type == typeof(ushort))
						{
							A_2 = (uint)((ushort)A_1);
						}
						else if (type == typeof(byte))
						{
							A_2 = (uint)((byte)A_1);
						}
						else if (type == typeof(sbyte))
						{
							A_2 = (uint)((sbyte)A_1);
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							uint num3;
							if (A_4 != null)
							{
								if (!uint.TryParse(A_1.ToString(), A_3, A_4, out num3))
								{
									return false;
								}
							}
							else if (!uint.TryParse(A_1.ToString(), out num3))
							{
								return false;
							}
							A_2 = num3;
						}
						return true;
					}
					if (A_0 == typeof(double))
					{
						if (type == typeof(float))
						{
							A_2 = (double)((float)A_1);
						}
						else if (type == typeof(int))
						{
							A_2 = (double)((int)A_1);
						}
						else if (type == typeof(uint))
						{
							A_2 = (uint)A_1;
						}
						else if (type == typeof(long))
						{
							A_2 = (double)((long)A_1);
						}
						else if (type == typeof(ulong))
						{
							A_2 = (ulong)A_1;
						}
						else if (type == typeof(short))
						{
							A_2 = (double)((short)A_1);
						}
						else if (type == typeof(ushort))
						{
							A_2 = (double)((ushort)A_1);
						}
						else if (type == typeof(byte))
						{
							A_2 = (double)((byte)A_1);
						}
						else if (type == typeof(sbyte))
						{
							A_2 = (double)((sbyte)A_1);
						}
						else if (type == typeof(decimal))
						{
							A_2 = (double)((decimal)A_1);
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							double num4;
							if (A_4 != null)
							{
								if (!double.TryParse(A_1.ToString(), A_3, A_4, out num4))
								{
									return false;
								}
							}
							else if (!double.TryParse(A_1.ToString(), out num4))
							{
								return false;
							}
							A_2 = num4;
						}
						return true;
					}
					if (A_0 == typeof(bool))
					{
						if (type == typeof(int))
						{
							A_2 = ((int)A_1 > 0);
						}
						else if (type == typeof(float))
						{
							A_2 = ((float)A_1 > 0f);
						}
						else if (type == typeof(uint))
						{
							A_2 = ((uint)A_1 > 0U);
						}
						else if (type == typeof(long))
						{
							A_2 = ((long)A_1 > 0L);
						}
						else if (type == typeof(ulong))
						{
							A_2 = ((ulong)A_1 > 0UL);
						}
						else if (type == typeof(double))
						{
							A_2 = ((double)A_1 > 0.0);
						}
						else if (type == typeof(decimal))
						{
							A_2 = ((decimal)A_1 > 0m);
						}
						else if (type == typeof(short))
						{
							A_2 = ((short)A_1 > 0);
						}
						else if (type == typeof(ushort))
						{
							A_2 = ((ushort)A_1 > 0);
						}
						else if (type == typeof(byte))
						{
							A_2 = ((byte)A_1 > 0);
						}
						else if (type == typeof(sbyte))
						{
							A_2 = ((sbyte)A_1 > 0);
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							if (string.Equals((string)A_1, "true", StringComparison.OrdinalIgnoreCase))
							{
								A_2 = true;
							}
							else
							{
								if (!string.Equals((string)A_1, "false", StringComparison.OrdinalIgnoreCase))
								{
									return false;
								}
								A_2 = false;
							}
						}
						return true;
					}
					if (A_0 == typeof(long))
					{
						if (type == typeof(int))
						{
							A_2 = (long)((int)A_1);
						}
						else if (type == typeof(ulong))
						{
							A_2 = (long)((ulong)A_1);
						}
						else if (type == typeof(float))
						{
							A_2 = (long)((float)A_1);
						}
						else if (type == typeof(uint))
						{
							A_2 = (long)((ulong)((uint)A_1));
						}
						else if (type == typeof(double))
						{
							A_2 = (long)((double)A_1);
						}
						else if (type == typeof(decimal))
						{
							A_2 = (long)((decimal)A_1);
						}
						else if (type == typeof(short))
						{
							A_2 = (long)((short)A_1);
						}
						else if (type == typeof(ushort))
						{
							A_2 = (long)((ulong)((ushort)A_1));
						}
						else if (type == typeof(byte))
						{
							A_2 = (long)((ulong)((byte)A_1));
						}
						else if (type == typeof(sbyte))
						{
							A_2 = (long)((sbyte)A_1);
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							long num5;
							if (A_4 != null)
							{
								if (!long.TryParse(A_1.ToString(), A_3, A_4, out num5))
								{
									return false;
								}
							}
							else if (!long.TryParse(A_1.ToString(), out num5))
							{
								return false;
							}
							A_2 = num5;
						}
						return true;
					}
					if (A_0 == typeof(ulong))
					{
						if (type == typeof(long))
						{
							A_2 = (ulong)((long)A_1);
						}
						else if (type == typeof(int))
						{
							A_2 = (ulong)((long)((int)A_1));
						}
						else if (type == typeof(float))
						{
							A_2 = (ulong)((float)A_1);
						}
						else if (type == typeof(uint))
						{
							A_2 = (ulong)((uint)A_1);
						}
						else if (type == typeof(double))
						{
							A_2 = (ulong)((double)A_1);
						}
						else if (type == typeof(decimal))
						{
							A_2 = (ulong)((decimal)A_1);
						}
						else if (type == typeof(short))
						{
							A_2 = (ulong)((long)((short)A_1));
						}
						else if (type == typeof(ushort))
						{
							A_2 = (ulong)((ushort)A_1);
						}
						else if (type == typeof(byte))
						{
							A_2 = (ulong)((byte)A_1);
						}
						else if (type == typeof(sbyte))
						{
							A_2 = (ulong)((long)((sbyte)A_1));
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							ulong num6;
							if (A_4 != null)
							{
								if (!ulong.TryParse(A_1.ToString(), A_3, A_4, out num6))
								{
									return false;
								}
							}
							else if (!ulong.TryParse(A_1.ToString(), out num6))
							{
								return false;
							}
							A_2 = num6;
						}
						return true;
					}
					if (A_0 == typeof(short))
					{
						if (type == typeof(ushort))
						{
							A_2 = (short)((ushort)A_1);
						}
						else if (type == typeof(int))
						{
							A_2 = (short)((int)A_1);
						}
						else if (type == typeof(uint))
						{
							A_2 = (short)((uint)A_1);
						}
						else if (type == typeof(long))
						{
							A_2 = (short)((long)A_1);
						}
						else if (type == typeof(ulong))
						{
							A_2 = (short)((ulong)A_1);
						}
						else if (type == typeof(float))
						{
							A_2 = (short)((float)A_1);
						}
						else if (type == typeof(double))
						{
							A_2 = (short)((double)A_1);
						}
						else if (type == typeof(decimal))
						{
							A_2 = (short)((decimal)A_1);
						}
						else if (type == typeof(byte))
						{
							A_2 = (short)((byte)A_1);
						}
						else if (type == typeof(sbyte))
						{
							A_2 = (short)((sbyte)A_1);
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							short num7;
							if (A_4 != null)
							{
								if (!short.TryParse(A_1.ToString(), A_3, A_4, out num7))
								{
									return false;
								}
							}
							else if (!short.TryParse(A_1.ToString(), out num7))
							{
								return false;
							}
							A_2 = num7;
						}
						return true;
					}
					if (A_0 == typeof(ushort))
					{
						if (type == typeof(short))
						{
							A_2 = (ushort)((short)A_1);
						}
						else if (type == typeof(int))
						{
							A_2 = (ushort)((int)A_1);
						}
						else if (type == typeof(uint))
						{
							A_2 = (ushort)((uint)A_1);
						}
						else if (type == typeof(long))
						{
							A_2 = (ushort)((long)A_1);
						}
						else if (type == typeof(ulong))
						{
							A_2 = (ushort)((ulong)A_1);
						}
						else if (type == typeof(float))
						{
							A_2 = (ushort)((float)A_1);
						}
						else if (type == typeof(double))
						{
							A_2 = (ushort)((double)A_1);
						}
						else if (type == typeof(decimal))
						{
							A_2 = (ushort)((decimal)A_1);
						}
						else if (type == typeof(byte))
						{
							A_2 = (ushort)((byte)A_1);
						}
						else if (type == typeof(sbyte))
						{
							A_2 = (ushort)((sbyte)A_1);
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							ushort num8;
							if (A_4 != null)
							{
								if (!ushort.TryParse(A_1.ToString(), A_3, A_4, out num8))
								{
									return false;
								}
							}
							else if (!ushort.TryParse(A_1.ToString(), out num8))
							{
								return false;
							}
							A_2 = num8;
						}
						return true;
					}
					if (A_0 == typeof(byte))
					{
						if (type == typeof(sbyte))
						{
							A_2 = (byte)((sbyte)A_1);
						}
						else if (type == typeof(int))
						{
							A_2 = (byte)((int)A_1);
						}
						else if (type == typeof(uint))
						{
							A_2 = (byte)((uint)A_1);
						}
						else if (type == typeof(long))
						{
							A_2 = (byte)((long)A_1);
						}
						else if (type == typeof(ulong))
						{
							A_2 = (byte)((ulong)A_1);
						}
						else if (type == typeof(float))
						{
							A_2 = (byte)((float)A_1);
						}
						else if (type == typeof(double))
						{
							A_2 = (byte)((double)A_1);
						}
						else if (type == typeof(decimal))
						{
							A_2 = (byte)((decimal)A_1);
						}
						else if (type == typeof(short))
						{
							A_2 = (byte)((short)A_1);
						}
						else if (type == typeof(ushort))
						{
							A_2 = (byte)((ushort)A_1);
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							byte b;
							if (A_4 != null)
							{
								if (!byte.TryParse(A_1.ToString(), A_3, A_4, out b))
								{
									return false;
								}
							}
							else if (!byte.TryParse(A_1.ToString(), out b))
							{
								return false;
							}
							A_2 = b;
						}
						return true;
					}
					if (A_0 == typeof(sbyte))
					{
						if (type == typeof(byte))
						{
							A_2 = (sbyte)((byte)A_1);
						}
						else if (type == typeof(int))
						{
							A_2 = (sbyte)((int)A_1);
						}
						else if (type == typeof(uint))
						{
							A_2 = (sbyte)((uint)A_1);
						}
						else if (type == typeof(long))
						{
							A_2 = (sbyte)((long)A_1);
						}
						else if (type == typeof(ulong))
						{
							A_2 = (sbyte)((ulong)A_1);
						}
						else if (type == typeof(float))
						{
							A_2 = (sbyte)((float)A_1);
						}
						else if (type == typeof(double))
						{
							A_2 = (sbyte)((double)A_1);
						}
						else if (type == typeof(decimal))
						{
							A_2 = (sbyte)((decimal)A_1);
						}
						else if (type == typeof(short))
						{
							A_2 = (sbyte)((short)A_1);
						}
						else if (type == typeof(ushort))
						{
							A_2 = (sbyte)((ushort)A_1);
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							sbyte b2;
							if (A_4 != null)
							{
								if (!sbyte.TryParse(A_1.ToString(), A_3, A_4, out b2))
								{
									return false;
								}
							}
							else if (!sbyte.TryParse(A_1.ToString(), out b2))
							{
								return false;
							}
							A_2 = b2;
						}
						return true;
					}
					if (A_0 == typeof(decimal))
					{
						if (type == typeof(float))
						{
							A_2 = (decimal)((float)A_1);
						}
						else if (type == typeof(double))
						{
							A_2 = (decimal)((double)A_1);
						}
						else if (type == typeof(int))
						{
							A_2 = (int)A_1;
						}
						else if (type == typeof(long))
						{
							A_2 = (long)A_1;
						}
						else if (type == typeof(uint))
						{
							A_2 = (uint)A_1;
						}
						else if (type == typeof(ulong))
						{
							A_2 = (ulong)A_1;
						}
						else if (type == typeof(short))
						{
							A_2 = (short)A_1;
						}
						else if (type == typeof(ushort))
						{
							A_2 = (ushort)A_1;
						}
						else if (type == typeof(byte))
						{
							A_2 = (byte)A_1;
						}
						else if (type == typeof(sbyte))
						{
							A_2 = (sbyte)A_1;
						}
						else
						{
							if (type != typeof(string))
							{
								return false;
							}
							decimal num9;
							if (A_4 != null)
							{
								if (!decimal.TryParse(A_1.ToString(), A_3, A_4, out num9))
								{
									return false;
								}
							}
							else if (!decimal.TryParse(A_1.ToString(), out num9))
							{
								return false;
							}
							A_2 = num9;
						}
						return true;
					}
					if (A_0 == typeof(char))
					{
						A_2 = A_1.ToString();
						return true;
					}
					if (A_0 == typeof(Guid))
					{
						if (type == typeof(string))
						{
							A_2 = StringTools.ToGuid((string)A_1);
							return true;
						}
						return false;
					}
					else if (ReflectionTools.IsArray(A_0))
					{
						Type elementType = A_0.GetElementType();
						if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
						{
							SerializedObject serializedObject = A_1 as SerializedObject;
							if (serializedObject == null)
							{
								return false;
							}
							Array array = Array.CreateInstance(elementType, serializedObject.count);
							for (int i = 0; i < serializedObject.count; i++)
							{
								object value2;
								if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(elementType, serializedObject[i].value, out value2, A_3, A_4))
								{
									array.SetValue(value2, i);
								}
							}
							A_2 = array;
							return true;
						}
						else if (ReflectionTools.DoesTypeImplement(type, typeof(IReadOnlyList)))
						{
							IReadOnlyList readOnlyList = A_1 as IReadOnlyList;
							if (readOnlyList == null)
							{
								return false;
							}
							Array array2 = Array.CreateInstance(elementType, readOnlyList.Count);
							for (int j = 0; j < readOnlyList.Count; j++)
							{
								object value3;
								if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(elementType, readOnlyList[j], out value3, A_3, A_4))
								{
									array2.SetValue(value3, j);
								}
							}
							A_2 = array2;
							return true;
						}
						else if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
						{
							IList list = A_1 as IList;
							if (list == null)
							{
								return false;
							}
							Array array3 = Array.CreateInstance(elementType, list.Count);
							for (int k = 0; k < list.Count; k++)
							{
								object value4;
								if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(elementType, list[k], out value4, A_3, A_4))
								{
									array3.SetValue(value4, k);
								}
							}
							A_2 = array3;
							return true;
						}
						else
						{
							if (ReflectionTools.DoesTypeImplement(type, typeof(Array)))
							{
								Array array4 = A_1 as Array;
								Array array5 = Array.CreateInstance(elementType, array4.Length);
								for (int l = 0; l < array4.Length; l++)
								{
									object value5;
									if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(elementType, array4.GetValue(l), out value5, A_3, A_4))
									{
										array5.SetValue(value5, l);
									}
								}
								A_2 = array5;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
							{
								Type type2 = ReflectionTools.GetGenericArguments(A_0)[1];
								IDictionary dictionary = A_1 as IDictionary;
								Array array6 = Array.CreateInstance(elementType, dictionary.Count);
								int num10 = 0;
								foreach (object obj in dictionary.Values)
								{
									object value6;
									if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(type2, obj, out value6, A_3, A_4))
									{
										array6.SetValue(value6, num10);
										num10++;
									}
								}
								A_2 = array6;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(ICollection)))
							{
								ICollection collection = A_1 as ICollection;
								Array array7 = Array.CreateInstance(elementType, collection.Count);
								int num11 = 0;
								foreach (object obj2 in collection)
								{
									object value7;
									if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(elementType, obj2, out value7, A_3, A_4))
									{
										array7.SetValue(value7, num11);
										num11++;
									}
								}
								A_2 = array7;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
							{
								IEnumerable enumerable = A_1 as IEnumerable;
								int num12 = 0;
								foreach (object obj3 in enumerable)
								{
									num12++;
								}
								Array array8 = Array.CreateInstance(elementType, num12);
								int num13 = 0;
								foreach (object obj4 in enumerable)
								{
									object value8;
									if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(elementType, obj4, out value8, A_3, A_4))
									{
										array8.SetValue(value8, num13);
										num13++;
									}
								}
								A_2 = array8;
								return true;
							}
							return false;
						}
					}
					else if (ReflectionTools.IsGenericType(A_0))
					{
						Type genericTypeDefinition = A_0.GetGenericTypeDefinition();
						if (ReflectionTools.DoesTypeImplement(A_0, typeof(IList)))
						{
							Type type3 = ReflectionTools.GetGenericArguments(A_0)[0];
							if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
							{
								SerializedObject serializedObject2 = A_1 as SerializedObject;
								IList list2 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(new Type[]
								{
									type3
								}), null);
								for (int m = 0; m < serializedObject2.count; m++)
								{
									object value9;
									if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(type3, serializedObject2[m].value, out value9, A_3, A_4))
									{
										list2.Add(value9);
									}
								}
								A_2 = list2;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(IReadOnlyList)))
							{
								IReadOnlyList readOnlyList2 = A_1 as IReadOnlyList;
								IList list3 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(new Type[]
								{
									type3
								}), null);
								for (int n = 0; n < readOnlyList2.Count; n++)
								{
									object value10;
									if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(type3, readOnlyList2[n], out value10, A_3, A_4))
									{
										list3.Add(value10);
									}
								}
								A_2 = list3;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
							{
								IList list4 = A_1 as IList;
								IList list5 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(new Type[]
								{
									type3
								}), null);
								for (int num14 = 0; num14 < list4.Count; num14++)
								{
									object value11;
									if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(type3, list4[num14], out value11, A_3, A_4))
									{
										list5.Add(value11);
									}
								}
								A_2 = list5;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(Array)))
							{
								Array array9 = A_1 as Array;
								IList list6 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(new Type[]
								{
									type3
								}), null);
								for (int num15 = 0; num15 < array9.Length; num15++)
								{
									object value12;
									if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(type3, array9.GetValue(num15), out value12, A_3, A_4))
									{
										list6.Add(value12);
									}
								}
								A_2 = list6;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
							{
								IEnumerable enumerable2 = A_1 as IEnumerable;
								IList list7 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(new Type[]
								{
									type3
								}), null);
								foreach (object obj5 in enumerable2)
								{
									object value13;
									if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(type3, obj5, out value13, A_3, A_4))
									{
										list7.Add(value13);
									}
								}
								A_2 = list7;
								return true;
							}
						}
						else if (ReflectionTools.DoesTypeImplement(genericTypeDefinition, typeof(IDictionary)))
						{
							Type[] genericArguments = ReflectionTools.GetGenericArguments(A_0);
							Type type4 = genericArguments[0];
							Type type5 = genericArguments[1];
							IDictionary dictionary2 = A_1 as IDictionary;
							if (dictionary2 == null)
							{
								return false;
							}
							IDictionary dictionary3 = (IDictionary)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(new Type[]
							{
								type4,
								type5
							}), null);
							foreach (object obj6 in dictionary2.Keys)
							{
								object key;
								object value14;
								if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(type4, obj6, out key, A_3, A_4) && SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(type5, dictionary2[obj6], out value14, A_3, A_4))
								{
									dictionary3.Add(key, value14);
								}
							}
							A_2 = dictionary3;
							return true;
						}
					}
					IL_1CBF:
					if (A_0 == typeof(object))
					{
						A_2 = A_1;
						return true;
					}
					if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
					{
						if (!SerializedObject.uaVoxGWDdqgcUcMXnqHFjDIHjPwEB(A_0, A_1 as SerializedObject, out A_1, NumberStyles.Any, null))
						{
							return false;
						}
						A_2 = A_1;
						return true;
					}
				}
				catch (Exception message)
				{
					Debug.LogError(message);
				}
				return false;
			}
		}

		// Token: 0x06003420 RID: 13344 RVA: 0x000B379C File Offset: 0x000B199C
		private static bool uaVoxGWDdqgcUcMXnqHFjDIHjPwEB(Type A_0, SerializedObject A_1, out object A_2, NumberStyles A_3 = NumberStyles.Any, CultureInfo A_4 = null)
		{
			if (A_1 == null || A_0 == null)
			{
				A_2 = null;
				return false;
			}
			A_2 = Factory.CreateInstance(A_0, null);
			Dictionary<string, FieldInfo> dictionary;
			if (!SerializedObject.VpaPJLpYhSYoJsTFiHrwjRPDeRGl.TryGetValue(A_0, out dictionary))
			{
				dictionary = ReflectionTools.GetFields(A_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(new Func<FieldInfo, bool>(SerializedObject.VDsQWjzJxksoWyEcHOoarJNxTTpw.<>9.RfbpuWLQyztsQSsCNkHrwbhXXQQL)).ToDictionary(new Func<FieldInfo, string>(SerializedObject.VDsQWjzJxksoWyEcHOoarJNxTTpw.<>9.qQvJjSDdMBmdzpgabBEGYuNwhdFK));
				SerializedObject.VpaPJLpYhSYoJsTFiHrwjRPDeRGl.Add(A_0, dictionary);
			}
			Dictionary<string, PropertyInfo> dictionary2;
			if (!SerializedObject.YpjUrroboETtbWnTqJPTUKmTgevbA.TryGetValue(A_0, out dictionary2))
			{
				dictionary2 = ReflectionTools.GetProperties(A_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(new Func<PropertyInfo, bool>(SerializedObject.VDsQWjzJxksoWyEcHOoarJNxTTpw.<>9.YtNAGImXteXdLammrKgdRxpnBwAC)).ToDictionary(new Func<PropertyInfo, string>(SerializedObject.VDsQWjzJxksoWyEcHOoarJNxTTpw.<>9.qARxKwErrIHvjtZVfpUqSbLeBNsBA));
				SerializedObject.YpjUrroboETtbWnTqJPTUKmTgevbA.Add(A_0, dictionary2);
			}
			foreach (SerializedObject.Field field in ((IEnumerable<SerializedObject.Field>)A_1))
			{
				string name = field.name;
				object value = field.value;
				FieldInfo fieldInfo;
				object value2;
				PropertyInfo propertyInfo;
				if (dictionary.TryGetValue(name, out fieldInfo))
				{
					if (SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(fieldInfo.FieldType, value, out value2, A_3, A_4))
					{
						fieldInfo.SetValue(A_2, value2);
					}
				}
				else if (dictionary2.TryGetValue(name, out propertyInfo) && propertyInfo.CanWrite && SerializedObject.EjLpdzsCKTDDqCqcRGyXcVZqaARW(propertyInfo.PropertyType, value, out value2, A_3, A_4))
				{
					propertyInfo.SetValue(A_2, value2, null);
				}
			}
			ISerializationCallbackReceiver serializationCallbackReceiver = A_2 as ISerializationCallbackReceiver;
			if (serializationCallbackReceiver != null)
			{
				try
				{
					serializationCallbackReceiver.OnAfterDeserialize();
				}
				catch (Exception ex)
				{
					Logger.LogError(ex.ToString(), true);
				}
			}
			return true;
		}

		// Token: 0x06003421 RID: 13345 RVA: 0x000B3974 File Offset: 0x000B1B74
		public static SerializedObject FromJson(Type type, string jsonString)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				throw new ArgumentNullException("jsonString");
			}
			SerializedObject serializedObject = JsonParser.FromJson<SerializedObject>(jsonString, typeof(SerializedObject));
			if (serializedObject == null || serializedObject.count == 0)
			{
				throw new Exception("No data found in Json string.");
			}
			return serializedObject;
		}

		// Token: 0x06003422 RID: 13346 RVA: 0x000B39D0 File Offset: 0x000B1BD0
		public static SerializedObject FromXml(Type type, string xmlString)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				throw new ArgumentNullException("xmlString");
			}
			SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU pcwNwcgtdevsbgoPfBUVugxwOeFU = new SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU(xmlString);
			if (!pcwNwcgtdevsbgoPfBUVugxwOeFU.nMofIUOFGaYVuXkFYjlahhQKRoyo)
			{
				throw new Exception("Failed to parse XML string.");
			}
			if (pcwNwcgtdevsbgoPfBUVugxwOeFU.CgGHdVfxjMkNnrLBFIRecKYifOxEc.aohlTAhpykTFbjXzVbLZlSWTrszA == 0)
			{
				throw new Exception("No data found in XML string.");
			}
			SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd sNJVXMUspUVtKqtMNAjYwCczjJgd = pcwNwcgtdevsbgoPfBUVugxwOeFU.CgGHdVfxjMkNnrLBFIRecKYifOxEc.XKWiJGvVTTgkujJlzNPTqaTriLDQ(type.Name);
			if (sNJVXMUspUVtKqtMNAjYwCczjJgd == null)
			{
				throw new Exception("Main element not found in XML string.");
			}
			SerializedObject serializedObject = sNJVXMUspUVtKqtMNAjYwCczjJgd.gDGAVDqPiRdqvdKxedsKzUlYaSvj() as SerializedObject;
			if (serializedObject == null || serializedObject.count == 0)
			{
				throw new Exception("No data found in XML string.");
			}
			return serializedObject;
		}

		// Token: 0x04001BD4 RID: 7124
		private readonly IndexedDictionary<string, SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA> QKOxGOZeKAxbbnFXjZuJglfzqNLN;

		// Token: 0x04001BD5 RID: 7125
		private SerializedObject.XmlInfo IxoBqzEMYXrSXulbNkPQgYShZYCvA;

		// Token: 0x04001BD6 RID: 7126
		private Type YAGKBjptpojxIwbWwsmquHXZGCmV;

		// Token: 0x04001BD7 RID: 7127
		private SerializedObject.ObjectType DACIrtfBTenFaoSkcLCSYVGuKwjeA;

		// Token: 0x04001BD8 RID: 7128
		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> VpaPJLpYhSYoJsTFiHrwjRPDeRGl = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		// Token: 0x04001BD9 RID: 7129
		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> YpjUrroboETtbWnTqJPTUKmTgevbA = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		// Token: 0x020004FA RID: 1274
		[CustomObfuscation(rename = false)]
		public enum ObjectType
		{
			// Token: 0x04001BDB RID: 7131
			[CustomObfuscation(rename = false)]
			Object,
			// Token: 0x04001BDC RID: 7132
			[CustomObfuscation(rename = false)]
			List
		}

		// Token: 0x020004FB RID: 1275
		[Flags]
		[CustomObfuscation(rename = false)]
		public enum FieldOptions
		{
			// Token: 0x04001BDE RID: 7134
			[CustomObfuscation(rename = false)]
			None = 0,
			// Token: 0x04001BDF RID: 7135
			[CustomObfuscation(rename = false)]
			ExculdeFromXml = 1
		}

		// Token: 0x020004FC RID: 1276
		private struct ePuzKMqGVGxTbTqnjDctRAPwgMThA
		{
			// Token: 0x06003424 RID: 13348 RVA: 0x000280A7 File Offset: 0x000262A7
			public ePuzKMqGVGxTbTqnjDctRAPwgMThA(Type A_1, object A_2, SerializedObject.FieldOptions A_3)
			{
				this.XbvBSGBHPBMclatbIGUMnrWPcAmaA = A_1;
				this.yShCLJXrSscxUmhcDBnIxQPjIaku = A_2;
				this.ndQlHJYCRDBPNwIDhImYeyPteOi = A_3;
			}

			// Token: 0x06003425 RID: 13349 RVA: 0x000B3A78 File Offset: 0x000B1C78
			public string FqhXPRFuhTNcrpMhUAegdkZhOLtKA()
			{
				return "" + "type = " + ((this.XbvBSGBHPBMclatbIGUMnrWPcAmaA != null) ? this.XbvBSGBHPBMclatbIGUMnrWPcAmaA.Name : "NULL") + "\n" + "value = " + ((this.yShCLJXrSscxUmhcDBnIxQPjIaku != null) ? this.yShCLJXrSscxUmhcDBnIxQPjIaku.ToString() : "NULL") + "\n" + "options = " + this.ndQlHJYCRDBPNwIDhImYeyPteOi.ToString() + "\n";
			}

			// Token: 0x04001BE0 RID: 7136
			public Type XbvBSGBHPBMclatbIGUMnrWPcAmaA;

			// Token: 0x04001BE1 RID: 7137
			public object yShCLJXrSscxUmhcDBnIxQPjIaku;

			// Token: 0x04001BE2 RID: 7138
			public SerializedObject.FieldOptions ndQlHJYCRDBPNwIDhImYeyPteOi;
		}

		// Token: 0x020004FD RID: 1277
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Field
		{
			// Token: 0x06003426 RID: 13350 RVA: 0x000280BE File Offset: 0x000262BE
			public Field(string A_1, object A_2, Type A_3, SerializedObject.FieldOptions A_4)
			{
				this.name = A_1;
				this.value = A_2;
				this.type = A_3;
				this.options = A_4;
			}

			// Token: 0x06003427 RID: 13351 RVA: 0x000B3B04 File Offset: 0x000B1D04
			public override string ToString()
			{
				return "name = " + ((this.name != null) ? this.name : "NULL") + "\n" + "value = " + ((this.value != null) ? this.value.ToString() : "NULL") + "\n" + "type = " + ((this.type != null) ? this.type.Name : "NULL") + "\n" + "options = " + this.options.ToString() + "\n";
			}

			// Token: 0x04001BE3 RID: 7139
			public string name;

			// Token: 0x04001BE4 RID: 7140
			public object value;

			// Token: 0x04001BE5 RID: 7141
			public Type type;

			// Token: 0x04001BE6 RID: 7142
			public SerializedObject.FieldOptions options;
		}

		// Token: 0x020004FE RID: 1278
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public class XmlInfo
		{
			// Token: 0x17000BE7 RID: 3047
			// (get) Token: 0x06003428 RID: 13352 RVA: 0x000B3BB0 File Offset: 0x000B1DB0
			public List<SerializedObject.XmlInfo.oJHDRzAtXKnwfdsseCCuHcTJyEqGB> attributes
			{
				get
				{
					List<SerializedObject.XmlInfo.oJHDRzAtXKnwfdsseCCuHcTJyEqGB> result;
					if ((result = this.eXqviTmvLnNUdmLvlMrNFfzpISxl) == null)
					{
						result = (this.eXqviTmvLnNUdmLvlMrNFfzpISxl = new List<SerializedObject.XmlInfo.oJHDRzAtXKnwfdsseCCuHcTJyEqGB>());
					}
					return result;
				}
			}

			// Token: 0x0600342A RID: 13354 RVA: 0x000B3BD8 File Offset: 0x000B1DD8
			public override string ToString()
			{
				string text = "Attributes:\n";
				if (this.eXqviTmvLnNUdmLvlMrNFfzpISxl != null)
				{
					for (int i = 0; i < this.eXqviTmvLnNUdmLvlMrNFfzpISxl.Count; i++)
					{
						text = text + this.eXqviTmvLnNUdmLvlMrNFfzpISxl[i].ToString() + "\n";
					}
				}
				return text;
			}

			// Token: 0x04001BE7 RID: 7143
			private List<SerializedObject.XmlInfo.oJHDRzAtXKnwfdsseCCuHcTJyEqGB> eXqviTmvLnNUdmLvlMrNFfzpISxl;

			// Token: 0x020004FF RID: 1279
			public abstract class oJHDRzAtXKnwfdsseCCuHcTJyEqGB
			{
			}

			// Token: 0x02000500 RID: 1280
			public class LNgACPpwshkKROSusbBaVylbemLP : SerializedObject.XmlInfo.oJHDRzAtXKnwfdsseCCuHcTJyEqGB
			{
				// Token: 0x0600342C RID: 13356 RVA: 0x000B3C28 File Offset: 0x000B1E28
				public virtual string uePWvgIewGFzMORTXutarcLhHVoH()
				{
					return "" + "prefix = " + this.RYjXkEgviKdbPKjefiQAbwFNRXTlA + "\n" + "localName = " + this.icHQGefQbedChDWtubHCUkbucRzbb + "\n" + "ns = " + this.YulEumEWpPNPEIqyPwfvMWtcRrsFA + "\n" + "value = " + this.hQsdIPBPqieQLwIOlxlBAUDVYhDFA + "\n";
				}

				// Token: 0x04001BE8 RID: 7144
				public string RYjXkEgviKdbPKjefiQAbwFNRXTlA;

				// Token: 0x04001BE9 RID: 7145
				public string icHQGefQbedChDWtubHCUkbucRzbb;

				// Token: 0x04001BEA RID: 7146
				public string YulEumEWpPNPEIqyPwfvMWtcRrsFA;

				// Token: 0x04001BEB RID: 7147
				public string hQsdIPBPqieQLwIOlxlBAUDVYhDFA;
			}
		}

		// Token: 0x02000501 RID: 1281
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<SerializedObject.Field>, IEnumerator, IDisposable
		{
			// Token: 0x0600342E RID: 13358 RVA: 0x000280E5 File Offset: 0x000262E5
			internal Enumerator(object A_1)
			{
				this.puXpFDplCuvnAMMoWbbHuyVbFJhq = (IndexedDictionary<string, SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA>)A_1;
				this.yczcWtBpIMjJOnewqwoTiiIaaMNZ = default(SerializedObject.Field);
				this.UXhCZefmLfNIIbNXefXFCAJdyaJuB = this.puXpFDplCuvnAMMoWbbHuyVbFJhq.GetEnumerator();
			}

			// Token: 0x0600342F RID: 13359 RVA: 0x000B3C90 File Offset: 0x000B1E90
			public bool MoveNext()
			{
				if (!this.UXhCZefmLfNIIbNXefXFCAJdyaJuB.MoveNext())
				{
					return false;
				}
				KeyValuePair<string, SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA> keyValuePair = this.UXhCZefmLfNIIbNXefXFCAJdyaJuB.Current;
				this.yczcWtBpIMjJOnewqwoTiiIaaMNZ = new SerializedObject.Field(keyValuePair.Key, keyValuePair.Value.yShCLJXrSscxUmhcDBnIxQPjIaku, keyValuePair.Value.XbvBSGBHPBMclatbIGUMnrWPcAmaA, keyValuePair.Value.ndQlHJYCRDBPNwIDhImYeyPteOi);
				return true;
			}

			// Token: 0x17000BE8 RID: 3048
			// (get) Token: 0x06003430 RID: 13360 RVA: 0x00028110 File Offset: 0x00026310
			public SerializedObject.Field Current
			{
				get
				{
					return this.yczcWtBpIMjJOnewqwoTiiIaaMNZ;
				}
			}

			// Token: 0x06003431 RID: 13361 RVA: 0x00002FF9 File Offset: 0x000011F9
			public void Dispose()
			{
			}

			// Token: 0x17000BE9 RID: 3049
			// (get) Token: 0x06003432 RID: 13362 RVA: 0x00028118 File Offset: 0x00026318
			object IEnumerator.Current
			{
				get
				{
					return this.yczcWtBpIMjJOnewqwoTiiIaaMNZ;
				}
			}

			// Token: 0x06003433 RID: 13363 RVA: 0x00028125 File Offset: 0x00026325
			void IEnumerator.Reset()
			{
				this.yczcWtBpIMjJOnewqwoTiiIaaMNZ = default(SerializedObject.Field);
				this.UXhCZefmLfNIIbNXefXFCAJdyaJuB = this.puXpFDplCuvnAMMoWbbHuyVbFJhq.GetEnumerator();
			}

			// Token: 0x04001BEC RID: 7148
			private IndexedDictionary<string, SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA> puXpFDplCuvnAMMoWbbHuyVbFJhq;

			// Token: 0x04001BED RID: 7149
			private SerializedObject.Field yczcWtBpIMjJOnewqwoTiiIaaMNZ;

			// Token: 0x04001BEE RID: 7150
			private IEnumerator<KeyValuePair<string, SerializedObject.ePuzKMqGVGxTbTqnjDctRAPwgMThA>> UXhCZefmLfNIIbNXefXFCAJdyaJuB;
		}

		// Token: 0x02000502 RID: 1282
		private class PcwNwcgtdevsbgoPfBUVugxwOeFU
		{
			// Token: 0x17000BEA RID: 3050
			// (get) Token: 0x06003434 RID: 13364 RVA: 0x00028144 File Offset: 0x00026344
			public SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd CgGHdVfxjMkNnrLBFIRecKYifOxEc
			{
				get
				{
					return this.dbZdHULOexhoLFidLFwuBtqgFuPXb;
				}
			}

			// Token: 0x17000BEB RID: 3051
			// (get) Token: 0x06003435 RID: 13365 RVA: 0x0002814C File Offset: 0x0002634C
			public bool nMofIUOFGaYVuXkFYjlahhQKRoyo
			{
				get
				{
					return this.dbZdHULOexhoLFidLFwuBtqgFuPXb != null;
				}
			}

			// Token: 0x06003436 RID: 13366 RVA: 0x000B3CF0 File Offset: 0x000B1EF0
			public PcwNwcgtdevsbgoPfBUVugxwOeFU(string A_1)
			{
				if (string.IsNullOrEmpty(A_1))
				{
					throw new ArgumentNullException("xml");
				}
				try
				{
					using (StringReader stringReader = new StringReader(A_1))
					{
						XmlReader xmlReader = XmlReader.Create(stringReader);
						if (xmlReader == null)
						{
							throw new ArgumentNullException("reader");
						}
						this.dbZdHULOexhoLFidLFwuBtqgFuPXb = new SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd("Root", null);
						this.kqyAFPVrTQbIdBLqwAuZdhDduSSqA(xmlReader);
					}
				}
				catch
				{
					this.dbZdHULOexhoLFidLFwuBtqgFuPXb = null;
				}
			}

			// Token: 0x06003437 RID: 13367 RVA: 0x000B3D80 File Offset: 0x000B1F80
			private void kqyAFPVrTQbIdBLqwAuZdhDduSSqA(XmlReader A_1)
			{
				SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd sNJVXMUspUVtKqtMNAjYwCczjJgd = this.dbZdHULOexhoLFidLFwuBtqgFuPXb;
				int num = 0;
				while (A_1.Read())
				{
					XmlNodeType nodeType = A_1.NodeType;
					if (nodeType == XmlNodeType.Comment || nodeType == XmlNodeType.XmlDeclaration)
					{
						num++;
					}
					else
					{
						bool flag = false;
						if (A_1.NodeType == XmlNodeType.Element)
						{
							if (A_1.IsStartElement())
							{
								bool isEmptyElement = A_1.IsEmptyElement;
								sNJVXMUspUVtKqtMNAjYwCczjJgd = new SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd(A_1.LocalName, sNJVXMUspUVtKqtMNAjYwCczjJgd);
								for (int i = 0; i < A_1.AttributeCount; i++)
								{
									A_1.MoveToNextAttribute();
									sNJVXMUspUVtKqtMNAjYwCczjJgd.mwhMGDfwWayXlEUNdHuWqyoPTVOC(A_1.Name, A_1.Value);
								}
								if (A_1.IsEmptyElement)
								{
									flag = true;
								}
							}
						}
						else if (A_1.NodeType == XmlNodeType.Text)
						{
							if (!A_1.IsEmptyElement && A_1.HasValue)
							{
								sNJVXMUspUVtKqtMNAjYwCczjJgd.UaKyPMQSvwFAZKCwTwMzjiYSbZBW = A_1.ReadContentAsString();
							}
							else
							{
								flag = true;
							}
						}
						else
						{
							XmlNodeType nodeType2 = A_1.NodeType;
						}
						if ((flag || A_1.NodeType == XmlNodeType.EndElement) && sNJVXMUspUVtKqtMNAjYwCczjJgd != null && sNJVXMUspUVtKqtMNAjYwCczjJgd != this.dbZdHULOexhoLFidLFwuBtqgFuPXb && A_1.Name == sNJVXMUspUVtKqtMNAjYwCczjJgd.WSdFEiKKsSZZwSfGXNLqnGiuzMfCA)
						{
							sNJVXMUspUVtKqtMNAjYwCczjJgd = sNJVXMUspUVtKqtMNAjYwCczjJgd.TBQNwcYIqnRmiseDJDajEpcEkoFJ;
						}
						num++;
					}
				}
			}

			// Token: 0x06003438 RID: 13368 RVA: 0x00028157 File Offset: 0x00026357
			public virtual string xxPoXPQuOJnblspdwHvkMvTLtrre()
			{
				if (this.dbZdHULOexhoLFidLFwuBtqgFuPXb == null || this.dbZdHULOexhoLFidLFwuBtqgFuPXb.aohlTAhpykTFbjXzVbLZlSWTrszA == 0)
				{
					return "Document is empty.";
				}
				return this.dbZdHULOexhoLFidLFwuBtqgFuPXb.ToString();
			}

			// Token: 0x04001BEF RID: 7151
			private readonly SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd dbZdHULOexhoLFidLFwuBtqgFuPXb;

			// Token: 0x02000503 RID: 1283
			public class sNJVXMUspUVtKqtMNAjYwCczjJgd
			{
				// Token: 0x17000BEC RID: 3052
				// (get) Token: 0x06003439 RID: 13369 RVA: 0x0002817F File Offset: 0x0002637F
				public int aohlTAhpykTFbjXzVbLZlSWTrszA
				{
					get
					{
						if (this.YuZVdABLmqobGrcyDtyvqQxRfpSn == null)
						{
							return 0;
						}
						return this.YuZVdABLmqobGrcyDtyvqQxRfpSn.Count;
					}
				}

				// Token: 0x17000BED RID: 3053
				// (get) Token: 0x0600343A RID: 13370 RVA: 0x00028196 File Offset: 0x00026396
				public int jXUNmkWvWzQoprrSHZvqzHucAsAc
				{
					get
					{
						if (this.kCfqHnATdyCafrUVQbabgUXOQloS == null)
						{
							return 0;
						}
						return this.kCfqHnATdyCafrUVQbabgUXOQloS.Count;
					}
				}

				// Token: 0x0600343B RID: 13371 RVA: 0x000281AD File Offset: 0x000263AD
				public sNJVXMUspUVtKqtMNAjYwCczjJgd(string A_1, SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd A_2)
				{
					this.WSdFEiKKsSZZwSfGXNLqnGiuzMfCA = A_1;
					this.TBQNwcYIqnRmiseDJDajEpcEkoFJ = A_2;
					if (A_2 != null)
					{
						A_2.FzwapeGGbuqhhSFejeOvuOXuqwffA(this);
					}
				}

				// Token: 0x0600343C RID: 13372 RVA: 0x000281CD File Offset: 0x000263CD
				public void FzwapeGGbuqhhSFejeOvuOXuqwffA(SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd A_1)
				{
					if (A_1 == null)
					{
						return;
					}
					if (this.YuZVdABLmqobGrcyDtyvqQxRfpSn == null)
					{
						this.YuZVdABLmqobGrcyDtyvqQxRfpSn = new List<SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd>();
					}
					this.YuZVdABLmqobGrcyDtyvqQxRfpSn.Add(A_1);
				}

				// Token: 0x0600343D RID: 13373 RVA: 0x000B3E90 File Offset: 0x000B2090
				public void mwhMGDfwWayXlEUNdHuWqyoPTVOC(string A_1, string A_2)
				{
					if (string.IsNullOrEmpty(A_1))
					{
						return;
					}
					if (this.kCfqHnATdyCafrUVQbabgUXOQloS == null)
					{
						this.kCfqHnATdyCafrUVQbabgUXOQloS = new Dictionary<string, string>();
					}
					if (this.kCfqHnATdyCafrUVQbabgUXOQloS.ContainsKey(A_1))
					{
						this.kCfqHnATdyCafrUVQbabgUXOQloS[A_1] = A_2;
						return;
					}
					this.kCfqHnATdyCafrUVQbabgUXOQloS.Add(A_1, A_2);
				}

				// Token: 0x0600343E RID: 13374 RVA: 0x000281F2 File Offset: 0x000263F2
				public bool WPdFWAfJObbJHFDmzGAlnGZNKbwHA(string A_1)
				{
					return this.XKWiJGvVTTgkujJlzNPTqaTriLDQ(A_1) != null;
				}

				// Token: 0x0600343F RID: 13375 RVA: 0x000B3EE4 File Offset: 0x000B20E4
				public SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd XKWiJGvVTTgkujJlzNPTqaTriLDQ(string A_1)
				{
					if (this.aohlTAhpykTFbjXzVbLZlSWTrszA == 0)
					{
						return null;
					}
					for (int i = 0; i < this.YuZVdABLmqobGrcyDtyvqQxRfpSn.Count; i++)
					{
						if (string.Equals(this.YuZVdABLmqobGrcyDtyvqQxRfpSn[i].WSdFEiKKsSZZwSfGXNLqnGiuzMfCA, A_1, StringComparison.Ordinal))
						{
							return this.YuZVdABLmqobGrcyDtyvqQxRfpSn[i];
						}
					}
					return null;
				}

				// Token: 0x06003440 RID: 13376 RVA: 0x000B3F3C File Offset: 0x000B213C
				public object gDGAVDqPiRdqvdKxedsKzUlYaSvj()
				{
					if (this.aohlTAhpykTFbjXzVbLZlSWTrszA == 0)
					{
						return this.UaKyPMQSvwFAZKCwTwMzjiYSbZBW;
					}
					SerializedObject serializedObject = new SerializedObject(null, SerializedObject.ObjectType.List);
					for (int i = 0; i < this.aohlTAhpykTFbjXzVbLZlSWTrszA; i++)
					{
						SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd sNJVXMUspUVtKqtMNAjYwCczjJgd = this.YuZVdABLmqobGrcyDtyvqQxRfpSn[i];
						if (sNJVXMUspUVtKqtMNAjYwCczjJgd != null)
						{
							serializedObject.Add(sNJVXMUspUVtKqtMNAjYwCczjJgd.WSdFEiKKsSZZwSfGXNLqnGiuzMfCA, sNJVXMUspUVtKqtMNAjYwCczjJgd.gDGAVDqPiRdqvdKxedsKzUlYaSvj());
						}
					}
					return serializedObject;
				}

				// Token: 0x06003441 RID: 13377 RVA: 0x000281FE File Offset: 0x000263FE
				public virtual string rmElDLOFbJCIywcHIIiCcRmdmWIX()
				{
					return this.IqPVOSHKQGPuwrgwqxUZgnbctrAh("", 0);
				}

				// Token: 0x06003442 RID: 13378 RVA: 0x000B3F94 File Offset: 0x000B2194
				private string IqPVOSHKQGPuwrgwqxUZgnbctrAh(string A_1, int A_2)
				{
					string text = "";
					for (int i = 0; i < A_2; i++)
					{
						text += "    ";
					}
					A_1 = string.Concat(new string[]
					{
						A_1,
						text,
						"Name = ",
						this.WSdFEiKKsSZZwSfGXNLqnGiuzMfCA,
						"\n"
					});
					A_1 = string.Concat(new string[]
					{
						A_1,
						text,
						"Content = ",
						(this.UaKyPMQSvwFAZKCwTwMzjiYSbZBW == null) ? "NULL" : this.UaKyPMQSvwFAZKCwTwMzjiYSbZBW.ToString(),
						"\n"
					});
					A_1 = string.Concat(new string[]
					{
						A_1,
						text,
						"Attribute Count = ",
						this.jXUNmkWvWzQoprrSHZvqzHucAsAc.ToString(),
						"\n"
					});
					if (this.kCfqHnATdyCafrUVQbabgUXOQloS != null)
					{
						foreach (KeyValuePair<string, string> keyValuePair in this.kCfqHnATdyCafrUVQbabgUXOQloS)
						{
							A_1 = string.Concat(new string[]
							{
								A_1,
								text,
								"Attribute ",
								keyValuePair.Key,
								": = ",
								keyValuePair.Value,
								"\n"
							});
						}
					}
					A_1 = string.Concat(new string[]
					{
						A_1,
						text,
						"Child Count = ",
						this.aohlTAhpykTFbjXzVbLZlSWTrszA.ToString(),
						"\n"
					});
					if (this.YuZVdABLmqobGrcyDtyvqQxRfpSn != null)
					{
						string text2 = "";
						foreach (SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd sNJVXMUspUVtKqtMNAjYwCczjJgd in this.YuZVdABLmqobGrcyDtyvqQxRfpSn)
						{
							text2 += "\n";
							text2 = sNJVXMUspUVtKqtMNAjYwCczjJgd.IqPVOSHKQGPuwrgwqxUZgnbctrAh(text2, A_2 + 1);
						}
						A_1 += text2;
					}
					return A_1;
				}

				// Token: 0x04001BF0 RID: 7152
				public readonly string WSdFEiKKsSZZwSfGXNLqnGiuzMfCA;

				// Token: 0x04001BF1 RID: 7153
				public readonly SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd TBQNwcYIqnRmiseDJDajEpcEkoFJ;

				// Token: 0x04001BF2 RID: 7154
				public string UaKyPMQSvwFAZKCwTwMzjiYSbZBW;

				// Token: 0x04001BF3 RID: 7155
				public Dictionary<string, string> kCfqHnATdyCafrUVQbabgUXOQloS;

				// Token: 0x04001BF4 RID: 7156
				public List<SerializedObject.PcwNwcgtdevsbgoPfBUVugxwOeFU.sNJVXMUspUVtKqtMNAjYwCczjJgd> YuZVdABLmqobGrcyDtyvqQxRfpSn;
			}
		}

		// Token: 0x02000504 RID: 1284
		[CompilerGenerated]
		[Serializable]
		private sealed class VDsQWjzJxksoWyEcHOoarJNxTTpw
		{
			// Token: 0x06003445 RID: 13381 RVA: 0x000AAFB4 File Offset: 0x000A91B4
			internal bool RfbpuWLQyztsQSsCNkHrwbhXXQQL(FieldInfo A_1)
			{
				return (A_1.IsPublic || A_1.IsDefined(typeof(SerializeAttribute), true) || A_1.IsDefined(typeof(SerializeField), true)) && !A_1.IsDefined(typeof(NonSerializedAttribute), true) && !A_1.IsDefined(typeof(DoNotSerializeAttribute), true);
			}

			// Token: 0x06003446 RID: 13382 RVA: 0x000AB018 File Offset: 0x000A9218
			internal string qQvJjSDdMBmdzpgabBEGYuNwhdFK(FieldInfo A_1)
			{
				string name;
				if (A_1.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue<object>(A_1.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
				{
					return name;
				}
				return A_1.Name;
			}

			// Token: 0x06003447 RID: 13383 RVA: 0x0002561E File Offset: 0x0002381E
			internal bool YtNAGImXteXdLammrKgdRxpnBwAC(PropertyInfo A_1)
			{
				return A_1.CanWrite && A_1.IsDefined(typeof(SerializeAttribute), true) && !A_1.IsDefined(typeof(DoNotSerializeAttribute), true);
			}

			// Token: 0x06003448 RID: 13384 RVA: 0x000AB018 File Offset: 0x000A9218
			internal string qARxKwErrIHvjtZVfpUqSbLeBNsBA(PropertyInfo A_1)
			{
				string name;
				if (A_1.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue<object>(A_1.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
				{
					return name;
				}
				return A_1.Name;
			}

			// Token: 0x04001BF5 RID: 7157
			public static readonly SerializedObject.VDsQWjzJxksoWyEcHOoarJNxTTpw <>9 = new SerializedObject.VDsQWjzJxksoWyEcHOoarJNxTTpw();

			// Token: 0x04001BF6 RID: 7158
			public static Func<FieldInfo, bool> <>9__63_0;

			// Token: 0x04001BF7 RID: 7159
			public static Func<FieldInfo, string> <>9__63_1;

			// Token: 0x04001BF8 RID: 7160
			public static Func<PropertyInfo, bool> <>9__63_2;

			// Token: 0x04001BF9 RID: 7161
			public static Func<PropertyInfo, string> <>9__63_3;
		}
	}
}
