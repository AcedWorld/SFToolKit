using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.Android
{
	// Token: 0x02000016 RID: 22
	public class DownloadAssetPackAsyncOperation : CustomYieldInstruction
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000226 RID: 550 RVA: 0x000095A8 File Offset: 0x000077A8
		public override bool keepWaiting
		{
			get
			{
				Dictionary<string, AndroidAssetPackInfo> assetPackInfos = this.m_AssetPackInfos;
				bool result;
				lock (assetPackInfos)
				{
					foreach (AndroidAssetPackInfo androidAssetPackInfo in this.m_AssetPackInfos.Values)
					{
						bool flag2 = androidAssetPackInfo == null;
						if (flag2)
						{
							return true;
						}
						bool flag3 = androidAssetPackInfo.status != AndroidAssetPackStatus.Canceled && androidAssetPackInfo.status != AndroidAssetPackStatus.Completed && androidAssetPackInfo.status != AndroidAssetPackStatus.Failed && androidAssetPackInfo.status > AndroidAssetPackStatus.Unknown;
						if (flag3)
						{
							return true;
						}
					}
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00009674 File Offset: 0x00007874
		public bool isDone
		{
			get
			{
				return !this.keepWaiting;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00009680 File Offset: 0x00007880
		public float progress
		{
			get
			{
				Dictionary<string, AndroidAssetPackInfo> assetPackInfos = this.m_AssetPackInfos;
				float result;
				lock (assetPackInfos)
				{
					float num = 0f;
					float num2 = 0f;
					foreach (AndroidAssetPackInfo androidAssetPackInfo in this.m_AssetPackInfos.Values)
					{
						bool flag2 = androidAssetPackInfo == null;
						if (!flag2)
						{
							bool flag3 = androidAssetPackInfo.status == AndroidAssetPackStatus.Canceled || androidAssetPackInfo.status == AndroidAssetPackStatus.Completed || androidAssetPackInfo.status == AndroidAssetPackStatus.Failed || androidAssetPackInfo.status == AndroidAssetPackStatus.Unknown;
							if (flag3)
							{
								num += 1f;
								num2 += 1f;
							}
							else
							{
								double num3 = androidAssetPackInfo.bytesDownloaded / androidAssetPackInfo.size;
								num += (float)num3;
								num2 += androidAssetPackInfo.transferProgress;
							}
						}
					}
					result = Mathf.Clamp((num * 0.8f + num2 * 0.2f) / (float)this.m_AssetPackInfos.Count, 0f, 1f);
				}
				return result;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000229 RID: 553 RVA: 0x000097C0 File Offset: 0x000079C0
		public string[] downloadedAssetPacks
		{
			get
			{
				Dictionary<string, AndroidAssetPackInfo> assetPackInfos = this.m_AssetPackInfos;
				string[] result;
				lock (assetPackInfos)
				{
					List<string> list = new List<string>();
					foreach (AndroidAssetPackInfo androidAssetPackInfo in this.m_AssetPackInfos.Values)
					{
						bool flag2 = androidAssetPackInfo == null;
						if (!flag2)
						{
							bool flag3 = androidAssetPackInfo.status == AndroidAssetPackStatus.Completed;
							if (flag3)
							{
								list.Add(androidAssetPackInfo.name);
							}
						}
					}
					result = list.ToArray();
				}
				return result;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00009880 File Offset: 0x00007A80
		public string[] downloadFailedAssetPacks
		{
			get
			{
				Dictionary<string, AndroidAssetPackInfo> assetPackInfos = this.m_AssetPackInfos;
				string[] result;
				lock (assetPackInfos)
				{
					List<string> list = new List<string>();
					foreach (KeyValuePair<string, AndroidAssetPackInfo> keyValuePair in this.m_AssetPackInfos)
					{
						AndroidAssetPackInfo value = keyValuePair.Value;
						bool flag2 = value == null;
						if (flag2)
						{
							list.Add(keyValuePair.Key);
						}
						else
						{
							bool flag3 = value.status == AndroidAssetPackStatus.Canceled || value.status == AndroidAssetPackStatus.Failed || value.status == AndroidAssetPackStatus.Unknown;
							if (flag3)
							{
								list.Add(value.name);
							}
						}
					}
					result = list.ToArray();
				}
				return result;
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000996C File Offset: 0x00007B6C
		internal DownloadAssetPackAsyncOperation(string[] assetPackNames)
		{
			this.m_AssetPackInfos = assetPackNames.ToDictionary((string name) => name, (string name) => null);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000099CC File Offset: 0x00007BCC
		internal void OnUpdate(AndroidAssetPackInfo info)
		{
			Dictionary<string, AndroidAssetPackInfo> assetPackInfos = this.m_AssetPackInfos;
			lock (assetPackInfos)
			{
				this.m_AssetPackInfos[info.name] = info;
			}
		}

		// Token: 0x04000046 RID: 70
		private Dictionary<string, AndroidAssetPackInfo> m_AssetPackInfos;
	}
}
