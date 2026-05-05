using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000179 RID: 377
	public sealed class Callback<T> : Callback, IDisposable
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000890 RID: 2192 RVA: 0x0000C904 File Offset: 0x0000AB04
		// (remove) Token: 0x06000891 RID: 2193 RVA: 0x0000C93C File Offset: 0x0000AB3C
		private event Callback<T>.DispatchDelegate m_Func;

		// Token: 0x06000892 RID: 2194 RVA: 0x0000C971 File Offset: 0x0000AB71
		public static Callback<T> Create(Callback<T>.DispatchDelegate func)
		{
			return new Callback<T>(func, false);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x0000C97A File Offset: 0x0000AB7A
		public static Callback<T> CreateGameServer(Callback<T>.DispatchDelegate func)
		{
			return new Callback<T>(func, true);
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0000C983 File Offset: 0x0000AB83
		public Callback(Callback<T>.DispatchDelegate func, bool bGameServer = false)
		{
			this.m_bGameServer = bGameServer;
			this.Register(func);
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0000C99C File Offset: 0x0000AB9C
		~Callback()
		{
			this.Dispose();
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0000C9C8 File Offset: 0x0000ABC8
		public void Dispose()
		{
			if (this.m_bDisposed)
			{
				return;
			}
			GC.SuppressFinalize(this);
			if (this.m_bIsRegistered)
			{
				this.Unregister();
			}
			this.m_bDisposed = true;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0000C9EE File Offset: 0x0000ABEE
		public void Register(Callback<T>.DispatchDelegate func)
		{
			if (func == null)
			{
				throw new Exception("Callback function must not be null.");
			}
			if (this.m_bIsRegistered)
			{
				this.Unregister();
			}
			this.m_Func = func;
			CallbackDispatcher.Register(this);
			this.m_bIsRegistered = true;
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0000CA20 File Offset: 0x0000AC20
		public void Unregister()
		{
			CallbackDispatcher.Unregister(this);
			this.m_bIsRegistered = false;
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000899 RID: 2201 RVA: 0x0000CA2F File Offset: 0x0000AC2F
		public override bool IsGameServer
		{
			get
			{
				return this.m_bGameServer;
			}
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0000CA37 File Offset: 0x0000AC37
		internal override Type GetCallbackType()
		{
			return typeof(T);
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0000CA44 File Offset: 0x0000AC44
		internal override void OnRunCallback(IntPtr pvParam)
		{
			try
			{
				this.m_Func((T)((object)Marshal.PtrToStructure(pvParam, typeof(T))));
			}
			catch (Exception e)
			{
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0000CA8C File Offset: 0x0000AC8C
		internal override void SetUnregistered()
		{
			this.m_bIsRegistered = false;
		}

		// Token: 0x040009EA RID: 2538
		private bool m_bGameServer;

		// Token: 0x040009EB RID: 2539
		private bool m_bIsRegistered;

		// Token: 0x040009EC RID: 2540
		private bool m_bDisposed;

		// Token: 0x020001C9 RID: 457
		// (Invoke) Token: 0x06000B60 RID: 2912
		public delegate void DispatchDelegate(T param);
	}
}
