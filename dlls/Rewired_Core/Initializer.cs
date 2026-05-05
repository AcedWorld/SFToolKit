using System;
using System.ComponentModel;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	// Token: 0x020000DE RID: 222
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	public sealed class Initializer : MonoBehaviour
	{
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x00008313 File Offset: 0x00006513
		// (set) Token: 0x06000742 RID: 1858 RVA: 0x0000831B File Offset: 0x0000651B
		public GameObject inputManagerPrefab
		{
			get
			{
				return this._inputManagerPrefab;
			}
			set
			{
				this._inputManagerPrefab = value;
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x00008324 File Offset: 0x00006524
		// (set) Token: 0x06000744 RID: 1860 RVA: 0x0000832C File Offset: 0x0000652C
		public bool destroySelf
		{
			get
			{
				return this._destroySelf;
			}
			set
			{
				this._destroySelf = value;
			}
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00008335 File Offset: 0x00006535
		private void Awake()
		{
			this.Initialize();
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0003C49C File Offset: 0x0003A69C
		public bool Initialize()
		{
			bool result;
			try
			{
				if (ReInput.isReady)
				{
					result = false;
				}
				else if (this._inputManagerPrefab == null)
				{
					Logger.LogError("Rewired Input Manager prefab has not been set in the inspector. Cannot initialize Rewired.");
					result = false;
				}
				else if (UnityTools.GetComponentInSelfOrChildren<InputManager_Base>(this._inputManagerPrefab) == null)
				{
					Logger.LogError("Rewired Input Manager component is missing on the prefab.");
					result = false;
				}
				else
				{
					GameObject gameObject = UnityTools.Instantiate<GameObject>(this._inputManagerPrefab, base.transform.parent, false);
					if (gameObject == null)
					{
						Logger.LogError("Error instantiating prefab.");
						result = false;
					}
					else
					{
						string name = gameObject.name;
						if (name.EndsWith("(clone)", StringComparison.OrdinalIgnoreCase))
						{
							gameObject.name = name.Substring(0, name.Length - 7);
						}
						InputManager_Base componentInSelfOrChildren = UnityTools.GetComponentInSelfOrChildren<InputManager_Base>(gameObject);
						if (componentInSelfOrChildren != null)
						{
							componentInSelfOrChildren.DontDestroyOnLoad();
						}
						result = true;
					}
				}
			}
			catch
			{
				result = false;
			}
			finally
			{
				if (this.destroySelf)
				{
					Object.Destroy(base.gameObject);
				}
			}
			return result;
		}

		// Token: 0x040005D7 RID: 1495
		[SerializeField]
		private GameObject _inputManagerPrefab;

		// Token: 0x040005D8 RID: 1496
		[SerializeField]
		private bool _destroySelf = true;
	}
}
