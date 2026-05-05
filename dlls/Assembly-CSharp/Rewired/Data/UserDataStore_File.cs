using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Rewired.Utils.Libraries.CLZF2;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x02000274 RID: 628
	public class UserDataStore_File : UserDataStore_KeyValue
	{
		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000C0D RID: 3085 RVA: 0x000440EC File Offset: 0x000422EC
		// (set) Token: 0x06000C0E RID: 3086 RVA: 0x0004411B File Offset: 0x0004231B
		public string directory
		{
			get
			{
				if (string.IsNullOrEmpty(this.__directory))
				{
					return this.__directory = Application.persistentDataPath;
				}
				return this.__directory;
			}
			set
			{
				this.__directory = value;
				if (this._initialized)
				{
					this.OnDataSourceChanged();
				}
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000C0F RID: 3087 RVA: 0x00044132 File Offset: 0x00042332
		// (set) Token: 0x06000C10 RID: 3088 RVA: 0x0004413A File Offset: 0x0004233A
		public string fileName
		{
			get
			{
				return this._fileName;
			}
			set
			{
				this._fileName = value;
				if (this._initialized)
				{
					this.OnDataSourceChanged();
				}
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000C11 RID: 3089 RVA: 0x00044151 File Offset: 0x00042351
		// (set) Token: 0x06000C12 RID: 3090 RVA: 0x00044159 File Offset: 0x00042359
		public UserDataStore_File.DataFormat dataFormat
		{
			get
			{
				return this._dataFormat;
			}
			set
			{
				this._dataFormat = value;
				if (this._initialized)
				{
					this.OnDataSourceChanged();
				}
			}
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000C13 RID: 3091 RVA: 0x00044170 File Offset: 0x00042370
		// (set) Token: 0x06000C14 RID: 3092 RVA: 0x000441AD File Offset: 0x000423AD
		protected UserDataStore_File.IDataHandler dataHandler
		{
			get
			{
				if (this.__dataHandler == null)
				{
					return this.__dataHandler = new UserDataStore_File.LocalFileDataHandler(() => this._dataFormat, new UserDataStore_File.CLZF2());
				}
				return this.__dataHandler;
			}
			set
			{
				this.__dataHandler = value;
				if (this._initialized)
				{
					this.OnDataSourceChanged();
				}
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000C15 RID: 3093 RVA: 0x000441C4 File Offset: 0x000423C4
		protected override UserDataStore_KeyValue.IDataStore dataStore
		{
			get
			{
				return this._dataStore;
			}
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x000020BE File Offset: 0x000002BE
		protected virtual void SetInitialValues()
		{
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x000441CC File Offset: 0x000423CC
		protected override void OnInitialize()
		{
			this.SetInitialValues();
			this._initialized = true;
			this.OnDataSourceChanged();
			base.OnInitialize();
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x000441E7 File Offset: 0x000423E7
		private void OnDataSourceChanged()
		{
			this._dataStore = new UserDataStore_File.DataStore((!string.IsNullOrEmpty(this._fileName)) ? this._fileName : "RewiredSaveData.json", this.directory, this.dataHandler);
		}

		// Token: 0x0400120F RID: 4623
		private static readonly string thisScriptName = typeof(UserDataStore_File).Name;

		// Token: 0x04001210 RID: 4624
		private const string logPrefix = "Rewired: ";

		// Token: 0x04001211 RID: 4625
		private const string defaultExtensionText = ".json";

		// Token: 0x04001212 RID: 4626
		private const string defaultExtensionBinary = ".bin";

		// Token: 0x04001213 RID: 4627
		private const string defaultFileName = "RewiredSaveData.json";

		// Token: 0x04001214 RID: 4628
		[Tooltip("The data file name. Changing this will make saved data already stored with the old file name no longer accessible.")]
		[SerializeField]
		private string _fileName = "RewiredSaveData.json";

		// Token: 0x04001215 RID: 4629
		[Tooltip("Determines if the file should be stored as binary or text. Changing this will make saved data already stored no longer accessible.")]
		[SerializeField]
		private UserDataStore_File.DataFormat _dataFormat;

		// Token: 0x04001216 RID: 4630
		[NonSerialized]
		private string __directory;

		// Token: 0x04001217 RID: 4631
		[NonSerialized]
		private UserDataStore_File.DataStore _dataStore;

		// Token: 0x04001218 RID: 4632
		[NonSerialized]
		private UserDataStore_File.IDataHandler __dataHandler;

		// Token: 0x04001219 RID: 4633
		[NonSerialized]
		private bool _initialized;

		// Token: 0x02000275 RID: 629
		private sealed class DataStore : UserDataStore_KeyValue.IDataStore
		{
			// Token: 0x06000C1C RID: 3100 RVA: 0x00044243 File Offset: 0x00042443
			public DataStore(string fileName, string absDirectory, UserDataStore_File.IDataHandler dataHandler)
			{
				this._absFilePath = Path.Combine(absDirectory, fileName);
				if (dataHandler == null)
				{
					throw new ArgumentNullException("dataHandler");
				}
				this._dataHandler = dataHandler;
				this._data = new Dictionary<string, object>();
				this.Load();
			}

			// Token: 0x06000C1D RID: 3101 RVA: 0x0004427F File Offset: 0x0004247F
			public bool TryGetValue(string key, out object value)
			{
				if (string.IsNullOrEmpty(key))
				{
					value = null;
					return false;
				}
				return this._data.TryGetValue(key, out value);
			}

			// Token: 0x06000C1E RID: 3102 RVA: 0x0004429B File Offset: 0x0004249B
			public bool SetValue(string key, object value)
			{
				if (string.IsNullOrEmpty(key))
				{
					return false;
				}
				this._data[key] = value;
				return true;
			}

			// Token: 0x06000C1F RID: 3103 RVA: 0x000442B8 File Offset: 0x000424B8
			public bool Save()
			{
				bool result;
				try
				{
					result = this._dataHandler.Save(this._absFilePath, JsonWriter.ToJson(this._data));
				}
				catch (Exception message)
				{
					Debug.LogError(message);
					result = false;
				}
				return result;
			}

			// Token: 0x06000C20 RID: 3104 RVA: 0x00044300 File Offset: 0x00042500
			public bool Load()
			{
				bool result;
				try
				{
					string json;
					bool flag = this._dataHandler.Load(this._absFilePath, out json);
					if (flag)
					{
						Dictionary<string, object> dictionary = JsonParser.FromJson<Dictionary<string, object>>(json);
						if (dictionary == null)
						{
							dictionary = new Dictionary<string, object>();
						}
						this._data = dictionary;
					}
					result = flag;
				}
				catch (Exception message)
				{
					Debug.LogError(message);
					result = false;
				}
				return result;
			}

			// Token: 0x06000C21 RID: 3105 RVA: 0x00044358 File Offset: 0x00042558
			public bool Clear()
			{
				bool result;
				try
				{
					result = this._dataHandler.Clear(this._absFilePath);
				}
				catch (Exception message)
				{
					Debug.LogError(message);
					result = false;
				}
				this._data.Clear();
				return result;
			}

			// Token: 0x0400121A RID: 4634
			private Dictionary<string, object> _data;

			// Token: 0x0400121B RID: 4635
			private readonly string _absFilePath;

			// Token: 0x0400121C RID: 4636
			private UserDataStore_File.IDataHandler _dataHandler;
		}

		// Token: 0x02000276 RID: 630
		private sealed class LocalFileDataHandler : UserDataStore_File.IDataHandler
		{
			// Token: 0x06000C22 RID: 3106 RVA: 0x000443A0 File Offset: 0x000425A0
			public LocalFileDataHandler(Func<UserDataStore_File.DataFormat> dataFormatDelegate, UserDataStore_File.Codec codec)
			{
				if (dataFormatDelegate == null)
				{
					throw new ArgumentNullException("dataFormatDelegate");
				}
				this._dataFormatDelegate = dataFormatDelegate;
				if (codec == null)
				{
					codec = new UserDataStore_File.UTF8Text();
				}
				this._codec = codec;
			}

			// Token: 0x06000C23 RID: 3107 RVA: 0x000443D0 File Offset: 0x000425D0
			public bool Load(string absoluteFilePath, out string data)
			{
				data = null;
				if (string.IsNullOrEmpty(absoluteFilePath))
				{
					return false;
				}
				if (!File.Exists(absoluteFilePath))
				{
					return false;
				}
				bool result;
				try
				{
					UserDataStore_File.DataFormat dataFormat = this._dataFormatDelegate();
					if (dataFormat != UserDataStore_File.DataFormat.Text)
					{
						if (dataFormat != UserDataStore_File.DataFormat.Binary)
						{
							throw new NotImplementedException();
						}
						byte[] array = File.ReadAllBytes(absoluteFilePath);
						data = this._codec.Decode(array);
						result = (array != null && array.Length != 0);
					}
					else
					{
						data = File.ReadAllText(absoluteFilePath);
						result = !string.IsNullOrEmpty(data);
					}
				}
				catch (Exception message)
				{
					Debug.LogError(message);
					result = false;
				}
				return result;
			}

			// Token: 0x06000C24 RID: 3108 RVA: 0x00044460 File Offset: 0x00042660
			public bool Save(string absoluteFilePath, string data)
			{
				if (string.IsNullOrEmpty(absoluteFilePath))
				{
					return false;
				}
				bool result;
				try
				{
					if (!Directory.Exists(Path.GetDirectoryName(absoluteFilePath)))
					{
						Directory.CreateDirectory(Path.GetDirectoryName(absoluteFilePath));
					}
					UserDataStore_File.DataFormat dataFormat = this._dataFormatDelegate();
					if (dataFormat != UserDataStore_File.DataFormat.Text)
					{
						if (dataFormat != UserDataStore_File.DataFormat.Binary)
						{
							throw new NotImplementedException();
						}
						File.WriteAllBytes(absoluteFilePath, this._codec.Encode(data));
					}
					else
					{
						File.WriteAllText(absoluteFilePath, data);
					}
					result = true;
				}
				catch (Exception message)
				{
					Debug.LogError(message);
					result = false;
				}
				return result;
			}

			// Token: 0x06000C25 RID: 3109 RVA: 0x000444E8 File Offset: 0x000426E8
			public bool Clear(string absoluteFilePath)
			{
				if (string.IsNullOrEmpty(absoluteFilePath))
				{
					return false;
				}
				try
				{
					if (File.Exists(absoluteFilePath))
					{
						File.Delete(absoluteFilePath);
						return true;
					}
				}
				catch (Exception message)
				{
					Debug.LogError(message);
				}
				return false;
			}

			// Token: 0x0400121D RID: 4637
			private readonly Func<UserDataStore_File.DataFormat> _dataFormatDelegate;

			// Token: 0x0400121E RID: 4638
			private readonly UserDataStore_File.Codec _codec;
		}

		// Token: 0x02000277 RID: 631
		private abstract class Codec
		{
			// Token: 0x06000C26 RID: 3110
			public abstract byte[] Encode(string @string);

			// Token: 0x06000C27 RID: 3111
			public abstract string Decode(byte[] data);
		}

		// Token: 0x02000278 RID: 632
		private sealed class UTF8Text : UserDataStore_File.Codec
		{
			// Token: 0x06000C29 RID: 3113 RVA: 0x00044530 File Offset: 0x00042730
			public override byte[] Encode(string @string)
			{
				return Encoding.UTF8.GetBytes(@string);
			}

			// Token: 0x06000C2A RID: 3114 RVA: 0x0004453D File Offset: 0x0004273D
			public override string Decode(byte[] data)
			{
				return Encoding.UTF8.GetString(data);
			}
		}

		// Token: 0x02000279 RID: 633
		private sealed class CLZF2 : UserDataStore_File.Codec
		{
			// Token: 0x06000C2C RID: 3116 RVA: 0x00044552 File Offset: 0x00042752
			public CLZF2()
			{
				this._cLZF2 = new Rewired.Utils.Libraries.CLZF2.CLZF2();
			}

			// Token: 0x06000C2D RID: 3117 RVA: 0x00044565 File Offset: 0x00042765
			public override byte[] Encode(string @string)
			{
				return this._cLZF2.Compress(Encoding.UTF8.GetBytes(@string));
			}

			// Token: 0x06000C2E RID: 3118 RVA: 0x0004457D File Offset: 0x0004277D
			public override string Decode(byte[] data)
			{
				return Encoding.UTF8.GetString(this._cLZF2.Decompress(data));
			}

			// Token: 0x0400121F RID: 4639
			private readonly Rewired.Utils.Libraries.CLZF2.CLZF2 _cLZF2;
		}

		// Token: 0x0200027A RID: 634
		public interface IDataHandler
		{
			// Token: 0x06000C2F RID: 3119
			bool Load(string absoluteFilePath, out string data);

			// Token: 0x06000C30 RID: 3120
			bool Save(string absoluteFilePath, string data);

			// Token: 0x06000C31 RID: 3121
			bool Clear(string absoluteFilePath);
		}

		// Token: 0x0200027B RID: 635
		public enum DataFormat
		{
			// Token: 0x04001221 RID: 4641
			Text,
			// Token: 0x04001222 RID: 4642
			Binary
		}
	}
}
