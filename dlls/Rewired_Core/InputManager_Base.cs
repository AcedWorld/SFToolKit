using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	// Token: 0x020000E8 RID: 232
	[AddComponentMenu("")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExecuteInEditMode]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public abstract class InputManager_Base : MonoBehaviour
	{
		// Token: 0x17000287 RID: 647
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x000083AB File Offset: 0x000065AB
		// (set) Token: 0x0600075E RID: 1886 RVA: 0x000083B3 File Offset: 0x000065B3
		public UserData userData
		{
			get
			{
				return this._userData;
			}
			internal set
			{
				this._userData = value;
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x000083BC File Offset: 0x000065BC
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x000083C4 File Offset: 0x000065C4
		public ControllerDataFiles dataFiles
		{
			get
			{
				return this._controllerDataFiles;
			}
			set
			{
				if (ReInput.isReady)
				{
					Logger.LogError("Controller Data Files cannot be set while Rewired is initialized. Disable the GameObject or the Input Manager component before setting this value.");
					return;
				}
				this._controllerDataFiles = value;
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x000083DF File Offset: 0x000065DF
		// (set) Token: 0x06000762 RID: 1890 RVA: 0x000083F1 File Offset: 0x000065F1
		public bool runInEditMode
		{
			get
			{
				return this._userData.ConfigVars.runInEditMode;
			}
			set
			{
				this._userData.ConfigVars.runInEditMode = value;
				if (Application.isPlaying)
				{
					return;
				}
				if (!UnityTools.IsActiveAndEnabled(this))
				{
					return;
				}
				if (!UnityTools.IsObjectInScene<InputManager_Base>(this))
				{
					return;
				}
				if (value)
				{
					this.TryStartRunInEditMode();
					return;
				}
				this.TryStopRunInEditMode();
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x0000842E File Offset: 0x0000662E
		internal bool isRunningInEditMode
		{
			get
			{
				return ReInput.isRunningInEditMode && ReInput.rewiredInputManager == this;
			}
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x00008444 File Offset: 0x00006644
		internal void DontDestroyOnLoad()
		{
			this._dontDestroyOnLoad = true;
			if (this._dontDestroyOnLoad && Application.isPlaying)
			{
				Object.DontDestroyOnLoad(base.transform.root.gameObject);
			}
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x00008471 File Offset: 0x00006671
		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			this.loUJrpvXVSAfnWhzEbhUsvvyWLbY = true;
			if (!Application.isPlaying && !this._userData.ConfigVars.runInEditMode)
			{
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			this.ZcSOqkcXMsAPDXrqvbiSNChFGKpb();
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0003C864 File Offset: 0x0003AA64
		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying && !this._userData.ConfigVars.runInEditMode)
			{
				return;
			}
			if (Application.isPlaying && !this.loUJrpvXVSAfnWhzEbhUsvvyWLbY)
			{
				return;
			}
			if (this.syHSLMkaIozHPmjjJfZQNOzMfYYdA || this.WVRNGnzVNLEebhmgkbrdssprrRwL)
			{
				return;
			}
			this.gopflBeMCymNkdRemHXBcGzFgkPb();
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x000084A3 File Offset: 0x000066A3
		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (!Application.isPlaying && !this._userData.ConfigVars.runInEditMode)
			{
				return;
			}
			this.umJcSAgTMvtftObbOaBApRrHeyOgb(true);
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x000084C6 File Offset: 0x000066C6
		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			this.umJcSAgTMvtftObbOaBApRrHeyOgb(false);
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0003C8B4 File Offset: 0x0003AAB4
		private void umJcSAgTMvtftObbOaBApRrHeyOgb(bool A_1)
		{
			this.syHSLMkaIozHPmjjJfZQNOzMfYYdA = false;
			this.GjgCeqToluMxbBRJsyQxkQueKDEK = false;
			this.WVRNGnzVNLEebhmgkbrdssprrRwL = false;
			try
			{
				if (ReInput.rewiredInputManager == this)
				{
					ReInput.tMJbUxCypzEODHhfVhxcdReGBqwt();
				}
			}
			catch (Exception ex)
			{
				this.uIQfNCfFUrvlRBdttWVsgMStIniI(InputManager_Base.WjQRdFjqiuCqQpYylkigMqDUdRMjA.Destroy, "destruction", ex);
			}
			this.OnDeinitialized();
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x000084CF File Offset: 0x000066CF
		[CustomObfuscation(rename = false)]
		private void OnApplicationFocus(bool isFocused)
		{
			if (this.GjgCeqToluMxbBRJsyQxkQueKDEK)
			{
				return;
			}
			ReInput.sZHNYKxEmFyWVOXAFXBTSQkdnmuG(isFocused);
			bool flag = this.syHSLMkaIozHPmjjJfZQNOzMfYYdA;
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x000084E7 File Offset: 0x000066E7
		[CustomObfuscation(rename = false)]
		private void OnApplicationPause(bool isPaused)
		{
			if (this.GjgCeqToluMxbBRJsyQxkQueKDEK)
			{
				return;
			}
			ReInput.EDEGnlihHGIDPbxrrLhmNmibJTVDb(isPaused);
			bool flag = this.syHSLMkaIozHPmjjJfZQNOzMfYYdA;
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x000084FF File Offset: 0x000066FF
		[CustomObfuscation(rename = false)]
		private void Start()
		{
			if (UnityTools.isEditor && !Application.isPlaying)
			{
				return;
			}
			if (!this.syHSLMkaIozHPmjjJfZQNOzMfYYdA || this.WVRNGnzVNLEebhmgkbrdssprrRwL)
			{
				return;
			}
			ReInput.RMwCHkpUbSjwbNFhSEelNdzYhyos();
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00008526 File Offset: 0x00006726
		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (!this.syHSLMkaIozHPmjjJfZQNOzMfYYdA || this.WVRNGnzVNLEebhmgkbrdssprrRwL)
			{
				return;
			}
			if (UnityTools.isEditor && !Application.isPlaying)
			{
				return;
			}
			if (this._userData.ConfigVars.updateMode == UpdateMode.Manual)
			{
				return;
			}
			this.DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00008564 File Offset: 0x00006764
		[CustomObfuscation(rename = false)]
		private void FixedUpdate()
		{
			if (!this.syHSLMkaIozHPmjjJfZQNOzMfYYdA || this.WVRNGnzVNLEebhmgkbrdssprrRwL)
			{
				return;
			}
			if (UnityTools.isEditor && !Application.isPlaying)
			{
				return;
			}
			if (this._userData.ConfigVars.updateMode == UpdateMode.Manual)
			{
				return;
			}
			this.DoUpdate(UpdateLoopType.FixedUpdate, UpdateLoopSetting.FixedUpdate);
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0003C910 File Offset: 0x0003AB10
		[CustomObfuscation(rename = false)]
		private void LateUpdate()
		{
			if (!this.syHSLMkaIozHPmjjJfZQNOzMfYYdA || this.WVRNGnzVNLEebhmgkbrdssprrRwL)
			{
				return;
			}
			if (UnityTools.isEditor && !Application.isPlaying)
			{
				return;
			}
			try
			{
				ReInput.ZYyfjQuhMAOmwHcTKuUXdgutbQobA();
			}
			catch (Exception ex)
			{
				this.uIQfNCfFUrvlRBdttWVsgMStIniI(InputManager_Base.WjQRdFjqiuCqQpYylkigMqDUdRMjA.Update, "update (Late Update)", ex);
			}
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0003C968 File Offset: 0x0003AB68
		internal void OnGUIUpdate()
		{
			if (!this.syHSLMkaIozHPmjjJfZQNOzMfYYdA || this.WVRNGnzVNLEebhmgkbrdssprrRwL)
			{
				return;
			}
			if (UnityTools.isEditor && !Application.isPlaying)
			{
				return;
			}
			if (this._userData.ConfigVars.updateMode == UpdateMode.Manual)
			{
				return;
			}
			if ((this._userData.ConfigVars.updateLoop & UpdateLoopSetting.OnGUI) == UpdateLoopSetting.None)
			{
				return;
			}
			this.DoUpdate(UpdateLoopType.OnGUI, UpdateLoopSetting.OnGUI);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0003C9C8 File Offset: 0x0003ABC8
		internal void DoUpdate(UpdateLoopType updateLoopType, UpdateLoopSetting updateLoopSettingBit)
		{
			if (!this.syHSLMkaIozHPmjjJfZQNOzMfYYdA || this.WVRNGnzVNLEebhmgkbrdssprrRwL)
			{
				return;
			}
			try
			{
				this.CheckRecompile();
				ReInput.hRANSqleHeWEahqjEjemJLBiZksV(updateLoopType);
				if ((this._userData.ConfigVars.updateLoop & updateLoopSettingBit) != UpdateLoopSetting.None)
				{
					ReInput.hRnHdeFgUwAFYALaqmMboOkfprTrA(updateLoopType);
				}
			}
			catch (Exception ex)
			{
				this.uIQfNCfFUrvlRBdttWVsgMStIniI(InputManager_Base.WjQRdFjqiuCqQpYylkigMqDUdRMjA.Update, "update (" + updateLoopType.ToString() + ")", ex);
			}
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0003CA48 File Offset: 0x0003AC48
		internal void TryStartRunInEditMode()
		{
			if (this.syHSLMkaIozHPmjjJfZQNOzMfYYdA)
			{
				return;
			}
			if (!Application.isEditor || Application.isPlaying)
			{
				return;
			}
			if (ReInput.isReady)
			{
				Logger.LogWarning("Rewired is already running in Edit mode. Do you have multiple Rewired Input Managers in the scene? If you want to run this Rewired Input Manager, you must stop the one currently running first.");
				return;
			}
			if (this._userData.ConfigVars.alwaysUseUnityInput)
			{
				Logger.LogWarning("Rewired cannot run in Edit mode when native input is disabled.");
				return;
			}
			if (!this.IsEditModeSupported())
			{
				Logger.LogWarning("Rewired cannot run in Edit mode on this editor platform with the current settings.");
				return;
			}
			string text = null;
			bool flag;
			bool flag2;
			bool flag3;
			this.GetSupportedEditModeControllerTypes(out flag, out flag2, out flag3);
			if (!flag)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ", ";
				}
				text += "Keyboard";
			}
			if (!flag2)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ", ";
				}
				text += "Mouse";
			}
			if (!flag3)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ", ";
				}
				text += "Joystick";
			}
			if (!string.IsNullOrEmpty(text))
			{
				Logger.LogWarning("The current editor platform and/or input source settings do not support the following input devices in Edit mode:\n" + text);
			}
			this.GjgCeqToluMxbBRJsyQxkQueKDEK = false;
			this.gopflBeMCymNkdRemHXBcGzFgkPb();
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x000085A2 File Offset: 0x000067A2
		internal void TryStopRunInEditMode()
		{
			if (!Application.isEditor || Application.isPlaying)
			{
				return;
			}
			if (!ReInput.isReady)
			{
				return;
			}
			this.umJcSAgTMvtftObbOaBApRrHeyOgb(false);
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x000085C2 File Offset: 0x000067C2
		private bool gopflBeMCymNkdRemHXBcGzFgkPb()
		{
			if (this.syHSLMkaIozHPmjjJfZQNOzMfYYdA)
			{
				return true;
			}
			this.ZcSOqkcXMsAPDXrqvbiSNChFGKpb();
			if (this.syHSLMkaIozHPmjjJfZQNOzMfYYdA)
			{
				ReInput.RMwCHkpUbSjwbNFhSEelNdzYhyos();
			}
			return this.syHSLMkaIozHPmjjJfZQNOzMfYYdA;
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0003CB4C File Offset: 0x0003AD4C
		private void ZcSOqkcXMsAPDXrqvbiSNChFGKpb()
		{
			InputManager_Base.mbKQSdFWXHWtxjRvdkATOZfeLQGm mbKQSdFWXHWtxjRvdkATOZfeLQGm = new InputManager_Base.mbKQSdFWXHWtxjRvdkATOZfeLQGm();
			mbKQSdFWXHWtxjRvdkATOZfeLQGm.sANAYMhHoohMyfFtKeOHMkBhmiwwb = this;
			if (this.GjgCeqToluMxbBRJsyQxkQueKDEK)
			{
				return;
			}
			try
			{
				if (this.fyjkRsoYKEleDqzVFIEuutYlgeRP())
				{
					if (this._dontDestroyOnLoad && Application.isPlaying)
					{
						Object.DontDestroyOnLoad(base.transform.root.gameObject);
					}
					this.DetectPlatform();
					if (this._userData == null || this._userData.ConfigVars == null || this._controllerDataFiles == null)
					{
						Logger.LogError("Error! DataFiles is missing or corrupt! Make sure you have the DataFiles file linked in the inspector.");
					}
					else
					{
						if ((this._userData.ConfigVars.updateLoop & UpdateLoopSetting.Update) == UpdateLoopSetting.None)
						{
							this.userData.ConfigVars.updateLoop |= UpdateLoopSetting.Update;
						}
						if (this._userData.ConfigVars.updateMode == UpdateMode.Manual)
						{
							this.userData.ConfigVars.updateLoop = UpdateLoopSetting.Update;
						}
						if ((this._userData.ConfigVars.updateLoop & UpdateLoopSetting.OnGUI) == UpdateLoopSetting.OnGUI && base.gameObject.GetComponent<OnGUIHelper>() == null)
						{
							OnGUIHelper onGUIHelper = base.gameObject.AddComponent<OnGUIHelper>();
							onGUIHelper.hideFlags = HideFlags.HideAndDontSave;
							onGUIHelper.hideFlags |= HideFlags.HideInInspector;
						}
						Platform platform = this.platform;
						mbKQSdFWXHWtxjRvdkATOZfeLQGm.xzWafwgeKnJHXfoLCvhIvOjJfbTmc = this.AEtfewbJEhDyQMZJwGaYEStuqQtWA();
						mbKQSdFWXHWtxjRvdkATOZfeLQGm.LLwSWQqDdYvDqDTuAozTNCWKOzdR = new UnityTools.YlequFlwSpDLySjTazqSoKcKCanv(platform, this.platform, this.editorPlatform, this.isEditor, this.webplayerPlatform, this.scriptingBackend, this.scriptingAPILevel, this.GetExternalTools());
						Action<InputManager_Base.kFIKoXCPTEfvCHTKZIiWTCvYMHssA> action = new Action<InputManager_Base.kFIKoXCPTEfvCHTKZIiWTCvYMHssA>(mbKQSdFWXHWtxjRvdkATOZfeLQGm.emFKqoKmCDVJxJOFkzWOrapmKhIA);
						UnityTools.lrutRDBRTqRQPWEynTmVnBSYKYnJ(mbKQSdFWXHWtxjRvdkATOZfeLQGm.LLwSWQqDdYvDqDTuAozTNCWKOzdR);
						ReInput.LrPfCUVWJCfAxiipijJsjVEdbrreb(this, new Func<ConfigVars, object>(this.yiAbldquXZJnVrFGyBYtbPBlJxsDb), this._userData.ConfigVars, this._controllerDataFiles, this._userData, new Func<UnityTools.YlequFlwSpDLySjTazqSoKcKCanv>(mbKQSdFWXHWtxjRvdkATOZfeLQGm.XIebbeJalRJSIxKAxlfupulGRPTG), new Action<Platform>(this.BwEUgcYzIhyMbeWndWLsTEQtVFPi), action);
						this.syHSLMkaIozHPmjjJfZQNOzMfYYdA = true;
						this.WVRNGnzVNLEebhmgkbrdssprrRwL = false;
						if (!string.IsNullOrEmpty(mbKQSdFWXHWtxjRvdkATOZfeLQGm.xzWafwgeKnJHXfoLCvhIvOjJfbTmc))
						{
							Logger.LogWarning(mbKQSdFWXHWtxjRvdkATOZfeLQGm.xzWafwgeKnJHXfoLCvhIvOjJfbTmc);
						}
						this.OnInitialized();
					}
				}
			}
			catch (Exception ex)
			{
				this.uIQfNCfFUrvlRBdttWVsgMStIniI(InputManager_Base.WjQRdFjqiuCqQpYylkigMqDUdRMjA.Initialization, "initialization", ex);
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x000085E7 File Offset: 0x000067E7
		private void BwEUgcYzIhyMbeWndWLsTEQtVFPi(Platform A_1)
		{
			this.platform = A_1;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0003CD70 File Offset: 0x0003AF70
		private object yiAbldquXZJnVrFGyBYtbPBlJxsDb(ConfigVars A_1)
		{
			List<Assembly> list;
			if (UnityTools.unityVersion < UnityTools.UnityVersion.UNITY_5_0)
			{
				list = this.ggeegNeOhAMrCTErbmxmhZyahUlk();
			}
			else
			{
				list = null;
			}
			return sDhSoBMwkZfQWoCQcGBWjPdebVsz.pbiZtCyRQNBsJgpcFRGSyfIagThC(this.xLodiaFVMdJpyBtGbnYqgjxaKTDe(), list, A_1);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0003CDA0 File Offset: 0x0003AFA0
		private List<Assembly> ggeegNeOhAMrCTErbmxmhZyahUlk()
		{
			List<TextAsset> list = new List<TextAsset>();
			this.YBtZwhGPdpSuHYteqnSXLxAoJmuM(list, UnityTools.GetCurrentPlatformResourecesDLLPaths());
			List<Assembly> list2 = new List<Assembly>();
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				if (!(list[i] == null))
				{
					Assembly item = Assembly.Load(list[i].bytes);
					list2.Add(item);
				}
			}
			if (list2 == null || list2.Count == 0)
			{
				return null;
			}
			return list2;
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0003CE10 File Offset: 0x0003B010
		private List<Assembly> llrkplnByghvLqoOdAKXdZQxXnyuA()
		{
			bool flag = false;
			List<Assembly> result;
			try
			{
				if (string.IsNullOrEmpty(this.xLodiaFVMdJpyBtGbnYqgjxaKTDe()))
				{
					result = null;
				}
				else
				{
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					if (assemblies == null)
					{
						flag = true;
						throw new Exception();
					}
					Assembly assembly = Array.Find<Assembly>(assemblies, new Predicate<Assembly>(this.gRKREJgfltPDSUYfQFgFHFXpFtnK));
					if (assembly == null)
					{
						flag = true;
						throw new Exception();
					}
					result = new List<Assembly>
					{
						assembly
					};
				}
			}
			catch
			{
				if (flag)
				{
					Logger.LogError("Failed to initialize native input libraries. Falling back to Unity input. Controllers support will be limited and many special features will not be available. " + (UnityTools.isStandalonePlatform ? "If this is an IL2CPP build, Rewired does not support native input in an IL2CPP Standalone build at this time due to technical issues. This issue is being worked on." : ""));
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0003CEB4 File Offset: 0x0003B0B4
		private byte[] fsYzeeMQLVDSEOljrMpPxyCGSczE()
		{
			byte[] result;
			try
			{
				string text = this.xLodiaFVMdJpyBtGbnYqgjxaKTDe();
				if (string.IsNullOrEmpty(text))
				{
					result = null;
				}
				else
				{
					string assemblyName = text + "_Lib";
					string classPath = "Rewired.Internal.PlatformDLL";
					if (!ReflectionTools.IsAssemblyLoaded(assemblyName, true, true))
					{
						result = null;
					}
					else
					{
						Type typeInAssembly = ReflectionTools.GetTypeInAssembly(classPath, assemblyName, false);
						if (typeInAssembly == null)
						{
							result = null;
						}
						else
						{
							result = (typeInAssembly.InvokeMember("GetBytes", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, null) as byte[]);
						}
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0003CF40 File Offset: 0x0003B140
		private void YBtZwhGPdpSuHYteqnSXLxAoJmuM(List<TextAsset> A_1, List<string> A_2)
		{
			if (A_1 == null || A_2 == null)
			{
				return;
			}
			for (int i = 0; i < A_2.Count; i++)
			{
				string text = A_2[i];
				if (!string.IsNullOrEmpty(text))
				{
					TextAsset textAsset = (TextAsset)Resources.Load(text);
					if (textAsset == null)
					{
						Logger.LogError(A_2[i] + " not found in Resources!");
						return;
					}
					A_1.Add(textAsset);
				}
			}
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0003CFA8 File Offset: 0x0003B1A8
		private string AEtfewbJEhDyQMZJwGaYEStuqQtWA()
		{
			if (this.editorPlatform == EditorPlatform.None)
			{
				return null;
			}
			if (this.soSYwIYMyUdaBhREyrhXpGyHQnjm())
			{
				return null;
			}
			string result = string.Format("The current build target is set to {0}. Controller capabilities in the Unity editor may not accurately reflect those in a {0} build.", this.platform.ToString());
			switch (this.editorPlatform)
			{
			case EditorPlatform.OSX:
				this.platform = Platform.OSX;
				break;
			case EditorPlatform.Windows:
				this.platform = Platform.Windows;
				break;
			case EditorPlatform.Linux:
				this.platform = Platform.Linux;
				break;
			default:
				result = "Unsupported Unity editor platform detected. Input is not guarateed to function in the editor.";
				break;
			}
			return result;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0003D024 File Offset: 0x0003B224
		private bool soSYwIYMyUdaBhREyrhXpGyHQnjm()
		{
			switch (this.editorPlatform)
			{
			case EditorPlatform.OSX:
				if (this.platform == Platform.OSX)
				{
					return true;
				}
				break;
			case EditorPlatform.Windows:
				if (this.platform == Platform.Windows)
				{
					return true;
				}
				break;
			case EditorPlatform.Linux:
				if (this.platform == Platform.Linux)
				{
					return true;
				}
				break;
			}
			return false;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0003D070 File Offset: 0x0003B270
		private string xLodiaFVMdJpyBtGbnYqgjxaKTDe()
		{
			if (!ReInput.isEditor && ReInput.webplayerPlatform != WebplayerPlatform.None)
			{
				return string.Empty;
			}
			Platform currentPlatform = ReInput.currentPlatform;
			if (currentPlatform == Platform.Windows)
			{
				return "Rewired_Windows";
			}
			if (currentPlatform == Platform.OSX)
			{
				return "Rewired_OSX";
			}
			if (currentPlatform != Platform.Linux)
			{
				return string.Empty;
			}
			return "Rewired_Linux";
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0003D0BC File Offset: 0x0003B2BC
		private bool fyjkRsoYKEleDqzVFIEuutYlgeRP()
		{
			this.GjgCeqToluMxbBRJsyQxkQueKDEK = false;
			if (!ReInput.isReady)
			{
				return true;
			}
			if (Application.isPlaying)
			{
				if (Application.isEditor)
				{
					Logger.LogWarning("Only one Rewired Input Manager may exist in a scene. This additional Rewired Input Manager game object will be deleted. You may see this warning if you are loading a new level that contains a Rewired Input Manager. If that's the case, you can safely ignore this warning. This warning will never be logged in a build.");
				}
				Object.Destroy(base.gameObject);
				return false;
			}
			this.GjgCeqToluMxbBRJsyQxkQueKDEK = true;
			Logger.LogWarning("Only one Rewired Input Manager may exist in a scene.");
			return false;
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x000085F0 File Offset: 0x000067F0
		protected void RecompileStart()
		{
			ReInput.DkmfHRmcTuUFQmKAifxmYQwHWrHh();
			ReInput.tMJbUxCypzEODHhfVhxcdReGBqwt();
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x000085FC File Offset: 0x000067FC
		protected void RecompileEnd()
		{
			if (!Application.isPlaying)
			{
				bool runInEditMode = this.userData.ConfigVars.runInEditMode;
				return;
			}
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00008617 File Offset: 0x00006817
		protected void OnSceneLoaded()
		{
			if (ReInput.isReady)
			{
				ReInput.JIqejkCFJSXNogQeDZEPnNMCBeoUA();
			}
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0003D110 File Offset: 0x0003B310
		private void uIQfNCfFUrvlRBdttWVsgMStIniI(InputManager_Base.WjQRdFjqiuCqQpYylkigMqDUdRMjA A_1, string A_2, Exception A_3)
		{
			A_2 = "An exception occurred during " + A_2 + ".";
			bool flag = false;
			if (A_1 == InputManager_Base.WjQRdFjqiuCqQpYylkigMqDUdRMjA.Initialization || A_1 == InputManager_Base.WjQRdFjqiuCqQpYylkigMqDUdRMjA.Destroy)
			{
				A_2 += " Input will not function.";
				flag = true;
			}
			else
			{
				A_2 += " Rewired will attempt to continue running.";
			}
			Exception exception = (A_3.InnerException != null) ? A_3.InnerException : A_3;
			string str = A_2;
			string str2 = "\n\nException:\n";
			Exception ex = (A_3.InnerException != null) ? A_3.InnerException : A_3;
			Logger.LogException(exception, str + str2 + ((ex != null) ? ex.ToString() : null));
			if (flag)
			{
				this.WVRNGnzVNLEebhmgkbrdssprrRwL = true;
			}
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00008625 File Offset: 0x00006825
		[CustomObfuscation(rename = false)]
		internal void ResetAll()
		{
			this.umJcSAgTMvtftObbOaBApRrHeyOgb(false);
			this.gopflBeMCymNkdRemHXBcGzFgkPb();
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00008635 File Offset: 0x00006835
		[CustomObfuscation(rename = false)]
		internal EditorPlatform GetEditorPlatform()
		{
			if (!this.syHSLMkaIozHPmjjJfZQNOzMfYYdA && !this._detectedPlatformInEditor)
			{
				this.DetectPlatform();
			}
			this._detectedPlatformInEditor = true;
			return this.editorPlatform;
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0003D1A0 File Offset: 0x0003B3A0
		[CustomObfuscation(rename = false)]
		internal void GetSupportedEditModeControllerTypes(out bool keyboardSupported, out bool mouseSupported, out bool joystickSupported)
		{
			keyboardSupported = this._userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, this.editorPlatform);
			mouseSupported = this._userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, this.editorPlatform);
			joystickSupported = this._userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, this.editorPlatform);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0003D1F8 File Offset: 0x0003B3F8
		[CustomObfuscation(rename = false)]
		internal bool IsEditModeSupported()
		{
			if (this.editorPlatform == EditorPlatform.None)
			{
				this.GetEditorPlatform();
			}
			bool flag = this._userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, this.editorPlatform);
			bool flag2 = this._userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, this.editorPlatform);
			bool flag3 = this._userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, this.editorPlatform);
			return flag || flag2 || flag3;
		}

		// Token: 0x06000788 RID: 1928
		protected abstract void OnInitialized();

		// Token: 0x06000789 RID: 1929
		protected abstract void OnDeinitialized();

		// Token: 0x0600078A RID: 1930
		protected abstract void DetectPlatform();

		// Token: 0x0600078B RID: 1931
		protected abstract void CheckRecompile();

		// Token: 0x0600078C RID: 1932
		protected abstract IExternalTools GetExternalTools();

		// Token: 0x0600078E RID: 1934 RVA: 0x0000867B File Offset: 0x0000687B
		[CompilerGenerated]
		private bool gRKREJgfltPDSUYfQFgFHFXpFtnK(Assembly A_1)
		{
			return string.Equals(A_1.GetName().Name, this.xLodiaFVMdJpyBtGbnYqgjxaKTDe(), StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x0400061C RID: 1564
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _dontDestroyOnLoad = true;

		// Token: 0x0400061D RID: 1565
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UserData _userData = new UserData();

		// Token: 0x0400061E RID: 1566
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerDataFiles _controllerDataFiles;

		// Token: 0x0400061F RID: 1567
		protected bool isCompiling;

		// Token: 0x04000620 RID: 1568
		[NonSerialized]
		private bool syHSLMkaIozHPmjjJfZQNOzMfYYdA;

		// Token: 0x04000621 RID: 1569
		[NonSerialized]
		private bool WVRNGnzVNLEebhmgkbrdssprrRwL;

		// Token: 0x04000622 RID: 1570
		[NonSerialized]
		protected EditorPlatform editorPlatform;

		// Token: 0x04000623 RID: 1571
		[NonSerialized]
		protected Platform platform;

		// Token: 0x04000624 RID: 1572
		[NonSerialized]
		protected WebplayerPlatform webplayerPlatform;

		// Token: 0x04000625 RID: 1573
		[NonSerialized]
		protected bool isEditor;

		// Token: 0x04000626 RID: 1574
		[NonSerialized]
		protected bool _detectedPlatformInEditor;

		// Token: 0x04000627 RID: 1575
		[CustomObfuscation(rename = false)]
		[NonSerialized]
		protected ScriptingBackend scriptingBackend = ScriptingBackend.DotNet;

		// Token: 0x04000628 RID: 1576
		[CustomObfuscation(rename = false)]
		[NonSerialized]
		protected ScriptingAPILevel scriptingAPILevel;

		// Token: 0x04000629 RID: 1577
		[NonSerialized]
		private bool GjgCeqToluMxbBRJsyQxkQueKDEK;

		// Token: 0x0400062A RID: 1578
		private bool loUJrpvXVSAfnWhzEbhUsvvyWLbY;

		// Token: 0x020000E9 RID: 233
		private enum WjQRdFjqiuCqQpYylkigMqDUdRMjA
		{
			// Token: 0x0400062C RID: 1580
			Initialization,
			// Token: 0x0400062D RID: 1581
			Update,
			// Token: 0x0400062E RID: 1582
			Destroy
		}

		// Token: 0x020000EA RID: 234
		internal struct kFIKoXCPTEfvCHTKZIiWTCvYMHssA
		{
			// Token: 0x0400062F RID: 1583
			public Platform qWYCnTEYhFRanTPFQEGWdCtLqEaW;

			// Token: 0x04000630 RID: 1584
			public EditorPlatform pKDaAWbSYGKYgeEmfJYZUkBdLHBLA;

			// Token: 0x04000631 RID: 1585
			public WebplayerPlatform jFjBRbQMUmMEjGHcepRjdUnqYyqi;
		}

		// Token: 0x020000EB RID: 235
		[CompilerGenerated]
		private sealed class mbKQSdFWXHWtxjRvdkATOZfeLQGm
		{
			// Token: 0x06000790 RID: 1936 RVA: 0x0003D260 File Offset: 0x0003B460
			internal void emFKqoKmCDVJxJOFkzWOrapmKhIA(InputManager_Base.kFIKoXCPTEfvCHTKZIiWTCvYMHssA A_1)
			{
				this.sANAYMhHoohMyfFtKeOHMkBhmiwwb.platform = A_1.qWYCnTEYhFRanTPFQEGWdCtLqEaW;
				this.sANAYMhHoohMyfFtKeOHMkBhmiwwb.editorPlatform = A_1.pKDaAWbSYGKYgeEmfJYZUkBdLHBLA;
				this.sANAYMhHoohMyfFtKeOHMkBhmiwwb.webplayerPlatform = A_1.jFjBRbQMUmMEjGHcepRjdUnqYyqi;
				this.LLwSWQqDdYvDqDTuAozTNCWKOzdR.PUBMBpURbtrqwjMzKnkdubHBAasQ = A_1.qWYCnTEYhFRanTPFQEGWdCtLqEaW;
				this.LLwSWQqDdYvDqDTuAozTNCWKOzdR.DDtpBOjtOpADRjqPsRYiTmiWmpVm = A_1.pKDaAWbSYGKYgeEmfJYZUkBdLHBLA;
				this.LLwSWQqDdYvDqDTuAozTNCWKOzdR.kzWArcCGSwWIHywpausYDnllCKan = A_1.jFjBRbQMUmMEjGHcepRjdUnqYyqi;
				UnityTools.lrutRDBRTqRQPWEynTmVnBSYKYnJ(this.LLwSWQqDdYvDqDTuAozTNCWKOzdR);
				this.xzWafwgeKnJHXfoLCvhIvOjJfbTmc = null;
			}

			// Token: 0x06000791 RID: 1937 RVA: 0x00008694 File Offset: 0x00006894
			internal UnityTools.YlequFlwSpDLySjTazqSoKcKCanv XIebbeJalRJSIxKAxlfupulGRPTG()
			{
				return this.LLwSWQqDdYvDqDTuAozTNCWKOzdR;
			}

			// Token: 0x04000632 RID: 1586
			public InputManager_Base sANAYMhHoohMyfFtKeOHMkBhmiwwb;

			// Token: 0x04000633 RID: 1587
			public UnityTools.YlequFlwSpDLySjTazqSoKcKCanv LLwSWQqDdYvDqDTuAozTNCWKOzdR;

			// Token: 0x04000634 RID: 1588
			public string xzWafwgeKnJHXfoLCvhIvOjJfbTmc;
		}
	}
}
