using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000004 RID: 4
	[ExcludeFromDocs]
	[NativeHeader("UnityAnalyticsScriptingClasses.h")]
	[NativeHeader("Modules/UnityAnalytics/RemoteSettings/RemoteSettings.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class RemoteConfigSettings : IDisposable
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000026 RID: 38 RVA: 0x000023C8 File Offset: 0x000005C8
		// (remove) Token: 0x06000027 RID: 39 RVA: 0x00002400 File Offset: 0x00000600
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<bool> Updated;

		// Token: 0x06000028 RID: 40 RVA: 0x00002435 File Offset: 0x00000635
		private RemoteConfigSettings()
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000243F File Offset: 0x0000063F
		public RemoteConfigSettings(string configKey)
		{
			this.m_Ptr = RemoteConfigSettings.Internal_Create(this, configKey);
			this.Updated = null;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002460 File Offset: 0x00000660
		~RemoteConfigSettings()
		{
			this.Destroy();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002490 File Offset: 0x00000690
		private void Destroy()
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				RemoteConfigSettings.Internal_Destroy(this.m_Ptr);
				this.m_Ptr = IntPtr.Zero;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000024CB File Offset: 0x000006CB
		public void Dispose()
		{
			this.Destroy();
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600002D RID: 45
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr Internal_Create(RemoteConfigSettings rcs, string configKey);

		// Token: 0x0600002E RID: 46
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Destroy(IntPtr ptr);

		// Token: 0x0600002F RID: 47 RVA: 0x000024DC File Offset: 0x000006DC
		[RequiredByNativeCode]
		internal static void RemoteConfigSettingsUpdated(RemoteConfigSettings rcs, bool wasLastUpdatedFromServer)
		{
			Action<bool> updated = rcs.Updated;
			bool flag = updated != null;
			if (flag)
			{
				updated(wasLastUpdatedFromServer);
			}
		}

		// Token: 0x06000030 RID: 48
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool QueueConfig(string name, object param, int ver = 1, string prefix = "");

		// Token: 0x06000031 RID: 49
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool SendDeviceInfoInConfigRequest();

		// Token: 0x06000032 RID: 50
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void AddSessionTag(string tag);

		// Token: 0x06000033 RID: 51
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void ForceUpdate();

		// Token: 0x06000034 RID: 52
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool WasLastUpdatedFromServer();

		// Token: 0x06000035 RID: 53 RVA: 0x00002504 File Offset: 0x00000704
		[ExcludeFromDocs]
		public int GetInt(string key)
		{
			return this.GetInt(key, 0);
		}

		// Token: 0x06000036 RID: 54
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetInt(string key, [DefaultValue("0")] int defaultValue);

		// Token: 0x06000037 RID: 55 RVA: 0x00002520 File Offset: 0x00000720
		[ExcludeFromDocs]
		public long GetLong(string key)
		{
			return this.GetLong(key, 0L);
		}

		// Token: 0x06000038 RID: 56
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern long GetLong(string key, [DefaultValue("0")] long defaultValue);

		// Token: 0x06000039 RID: 57 RVA: 0x0000253C File Offset: 0x0000073C
		[ExcludeFromDocs]
		public float GetFloat(string key)
		{
			return this.GetFloat(key, 0f);
		}

		// Token: 0x0600003A RID: 58
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern float GetFloat(string key, [DefaultValue("0.0F")] float defaultValue);

		// Token: 0x0600003B RID: 59 RVA: 0x0000255C File Offset: 0x0000075C
		[ExcludeFromDocs]
		public string GetString(string key)
		{
			return this.GetString(key, "");
		}

		// Token: 0x0600003C RID: 60
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern string GetString(string key, [DefaultValue("\"\"")] string defaultValue);

		// Token: 0x0600003D RID: 61 RVA: 0x0000257C File Offset: 0x0000077C
		[ExcludeFromDocs]
		public bool GetBool(string key)
		{
			return this.GetBool(key, false);
		}

		// Token: 0x0600003E RID: 62
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool GetBool(string key, [DefaultValue("false")] bool defaultValue);

		// Token: 0x0600003F RID: 63
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool HasKey(string key);

		// Token: 0x06000040 RID: 64
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetCount();

		// Token: 0x06000041 RID: 65
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern string[] GetKeys();

		// Token: 0x06000042 RID: 66 RVA: 0x00002598 File Offset: 0x00000798
		public T GetObject<T>(string key = "")
		{
			return (T)((object)this.GetObject(typeof(T), key));
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000025C0 File Offset: 0x000007C0
		public object GetObject(Type type, string key = "")
		{
			bool flag = type == null;
			if (flag)
			{
				throw new ArgumentNullException("type");
			}
			bool flag2 = type.IsAbstract || type.IsSubclassOf(typeof(Object));
			if (flag2)
			{
				throw new ArgumentException("Cannot deserialize to new instances of type '" + type.Name + ".'");
			}
			return this.GetAsScriptingObject(type, null, key);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000262C File Offset: 0x0000082C
		public object GetObject(string key, object defaultValue)
		{
			bool flag = defaultValue == null;
			if (flag)
			{
				throw new ArgumentNullException("defaultValue");
			}
			Type type = defaultValue.GetType();
			bool flag2 = type.IsAbstract || type.IsSubclassOf(typeof(Object));
			if (flag2)
			{
				throw new ArgumentException("Cannot deserialize to new instances of type '" + type.Name + ".'");
			}
			return this.GetAsScriptingObject(type, defaultValue, key);
		}

		// Token: 0x06000045 RID: 69
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern object GetAsScriptingObject(Type t, object defaultValue, string key);

		// Token: 0x06000046 RID: 70 RVA: 0x0000269C File Offset: 0x0000089C
		public IDictionary<string, object> GetDictionary(string key = "")
		{
			this.UseSafeLock();
			IDictionary<string, object> dictionary = RemoteConfigSettingsHelper.GetDictionary(this.GetSafeTopMap(), key);
			this.ReleaseSafeLock();
			return dictionary;
		}

		// Token: 0x06000047 RID: 71
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void UseSafeLock();

		// Token: 0x06000048 RID: 72
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void ReleaseSafeLock();

		// Token: 0x06000049 RID: 73
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern IntPtr GetSafeTopMap();

		// Token: 0x04000004 RID: 4
		[NonSerialized]
		internal IntPtr m_Ptr;
	}
}
