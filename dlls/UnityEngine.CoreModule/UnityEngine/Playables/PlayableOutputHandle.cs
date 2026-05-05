using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Playables
{
	// Token: 0x020004A8 RID: 1192
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[NativeHeader("Runtime/Export/Director/PlayableOutputHandle.bindings.h")]
	[UsedByNativeCode]
	[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
	public struct PlayableOutputHandle : IEquatable<PlayableOutputHandle>
	{
		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x0600298C RID: 10636 RVA: 0x00046874 File Offset: 0x00044A74
		public static PlayableOutputHandle Null
		{
			get
			{
				return PlayableOutputHandle.m_Null;
			}
		}

		// Token: 0x0600298D RID: 10637 RVA: 0x0004688C File Offset: 0x00044A8C
		[VisibleToOtherModules]
		internal bool IsPlayableOutputOfType<T>()
		{
			return this.GetPlayableOutputType() == typeof(T);
		}

		// Token: 0x0600298E RID: 10638 RVA: 0x000468B4 File Offset: 0x00044AB4
		public override int GetHashCode()
		{
			return this.m_Handle.GetHashCode() ^ this.m_Version.GetHashCode();
		}

		// Token: 0x0600298F RID: 10639 RVA: 0x000468E0 File Offset: 0x00044AE0
		public static bool operator ==(PlayableOutputHandle lhs, PlayableOutputHandle rhs)
		{
			return PlayableOutputHandle.CompareVersion(lhs, rhs);
		}

		// Token: 0x06002990 RID: 10640 RVA: 0x000468FC File Offset: 0x00044AFC
		public static bool operator !=(PlayableOutputHandle lhs, PlayableOutputHandle rhs)
		{
			return !PlayableOutputHandle.CompareVersion(lhs, rhs);
		}

		// Token: 0x06002991 RID: 10641 RVA: 0x00046918 File Offset: 0x00044B18
		public override bool Equals(object p)
		{
			return p is PlayableOutputHandle && this.Equals((PlayableOutputHandle)p);
		}

		// Token: 0x06002992 RID: 10642 RVA: 0x00046944 File Offset: 0x00044B44
		public bool Equals(PlayableOutputHandle other)
		{
			return PlayableOutputHandle.CompareVersion(this, other);
		}

		// Token: 0x06002993 RID: 10643 RVA: 0x00046964 File Offset: 0x00044B64
		internal static bool CompareVersion(PlayableOutputHandle lhs, PlayableOutputHandle rhs)
		{
			return lhs.m_Handle == rhs.m_Handle && lhs.m_Version == rhs.m_Version;
		}

		// Token: 0x06002994 RID: 10644 RVA: 0x0004699A File Offset: 0x00044B9A
		[VisibleToOtherModules]
		internal bool IsNull()
		{
			return PlayableOutputHandle.IsNull_Injected(ref this);
		}

		// Token: 0x06002995 RID: 10645 RVA: 0x000469A2 File Offset: 0x00044BA2
		[VisibleToOtherModules]
		internal bool IsValid()
		{
			return PlayableOutputHandle.IsValid_Injected(ref this);
		}

		// Token: 0x06002996 RID: 10646 RVA: 0x000469AA File Offset: 0x00044BAA
		[FreeFunction("PlayableOutputHandleBindings::GetPlayableOutputType", HasExplicitThis = true, ThrowsException = true)]
		internal Type GetPlayableOutputType()
		{
			return PlayableOutputHandle.GetPlayableOutputType_Injected(ref this);
		}

		// Token: 0x06002997 RID: 10647 RVA: 0x000469B2 File Offset: 0x00044BB2
		[FreeFunction("PlayableOutputHandleBindings::GetReferenceObject", HasExplicitThis = true, ThrowsException = true)]
		internal Object GetReferenceObject()
		{
			return PlayableOutputHandle.GetReferenceObject_Injected(ref this);
		}

		// Token: 0x06002998 RID: 10648 RVA: 0x000469BA File Offset: 0x00044BBA
		[FreeFunction("PlayableOutputHandleBindings::SetReferenceObject", HasExplicitThis = true, ThrowsException = true)]
		internal void SetReferenceObject(Object target)
		{
			PlayableOutputHandle.SetReferenceObject_Injected(ref this, target);
		}

		// Token: 0x06002999 RID: 10649 RVA: 0x000469C3 File Offset: 0x00044BC3
		[FreeFunction("PlayableOutputHandleBindings::GetUserData", HasExplicitThis = true, ThrowsException = true)]
		internal Object GetUserData()
		{
			return PlayableOutputHandle.GetUserData_Injected(ref this);
		}

		// Token: 0x0600299A RID: 10650 RVA: 0x000469CB File Offset: 0x00044BCB
		[FreeFunction("PlayableOutputHandleBindings::SetUserData", HasExplicitThis = true, ThrowsException = true)]
		internal void SetUserData([Writable] Object target)
		{
			PlayableOutputHandle.SetUserData_Injected(ref this, target);
		}

		// Token: 0x0600299B RID: 10651 RVA: 0x000469D4 File Offset: 0x00044BD4
		[FreeFunction("PlayableOutputHandleBindings::GetSourcePlayable", HasExplicitThis = true, ThrowsException = true)]
		internal PlayableHandle GetSourcePlayable()
		{
			PlayableHandle result;
			PlayableOutputHandle.GetSourcePlayable_Injected(ref this, out result);
			return result;
		}

		// Token: 0x0600299C RID: 10652 RVA: 0x000469EA File Offset: 0x00044BEA
		[FreeFunction("PlayableOutputHandleBindings::SetSourcePlayable", HasExplicitThis = true, ThrowsException = true)]
		internal void SetSourcePlayable(PlayableHandle target, int port)
		{
			PlayableOutputHandle.SetSourcePlayable_Injected(ref this, ref target, port);
		}

		// Token: 0x0600299D RID: 10653 RVA: 0x000469F5 File Offset: 0x00044BF5
		[FreeFunction("PlayableOutputHandleBindings::GetSourceOutputPort", HasExplicitThis = true, ThrowsException = true)]
		internal int GetSourceOutputPort()
		{
			return PlayableOutputHandle.GetSourceOutputPort_Injected(ref this);
		}

		// Token: 0x0600299E RID: 10654 RVA: 0x000469FD File Offset: 0x00044BFD
		[FreeFunction("PlayableOutputHandleBindings::GetWeight", HasExplicitThis = true, ThrowsException = true)]
		internal float GetWeight()
		{
			return PlayableOutputHandle.GetWeight_Injected(ref this);
		}

		// Token: 0x0600299F RID: 10655 RVA: 0x00046A05 File Offset: 0x00044C05
		[FreeFunction("PlayableOutputHandleBindings::SetWeight", HasExplicitThis = true, ThrowsException = true)]
		internal void SetWeight(float weight)
		{
			PlayableOutputHandle.SetWeight_Injected(ref this, weight);
		}

		// Token: 0x060029A0 RID: 10656 RVA: 0x00046A0E File Offset: 0x00044C0E
		[FreeFunction("PlayableOutputHandleBindings::PushNotification", HasExplicitThis = true, ThrowsException = true)]
		internal void PushNotification(PlayableHandle origin, INotification notification, object context)
		{
			PlayableOutputHandle.PushNotification_Injected(ref this, ref origin, notification, context);
		}

		// Token: 0x060029A1 RID: 10657 RVA: 0x00046A1A File Offset: 0x00044C1A
		[FreeFunction("PlayableOutputHandleBindings::GetNotificationReceivers", HasExplicitThis = true, ThrowsException = true)]
		internal INotificationReceiver[] GetNotificationReceivers()
		{
			return PlayableOutputHandle.GetNotificationReceivers_Injected(ref this);
		}

		// Token: 0x060029A2 RID: 10658 RVA: 0x00046A22 File Offset: 0x00044C22
		[FreeFunction("PlayableOutputHandleBindings::AddNotificationReceiver", HasExplicitThis = true, ThrowsException = true)]
		internal void AddNotificationReceiver(INotificationReceiver receiver)
		{
			PlayableOutputHandle.AddNotificationReceiver_Injected(ref this, receiver);
		}

		// Token: 0x060029A3 RID: 10659 RVA: 0x00046A2B File Offset: 0x00044C2B
		[FreeFunction("PlayableOutputHandleBindings::RemoveNotificationReceiver", HasExplicitThis = true, ThrowsException = true)]
		internal void RemoveNotificationReceiver(INotificationReceiver receiver)
		{
			PlayableOutputHandle.RemoveNotificationReceiver_Injected(ref this, receiver);
		}

		// Token: 0x060029A5 RID: 10661
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsNull_Injected(ref PlayableOutputHandle _unity_self);

		// Token: 0x060029A6 RID: 10662
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsValid_Injected(ref PlayableOutputHandle _unity_self);

		// Token: 0x060029A7 RID: 10663
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Type GetPlayableOutputType_Injected(ref PlayableOutputHandle _unity_self);

		// Token: 0x060029A8 RID: 10664
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object GetReferenceObject_Injected(ref PlayableOutputHandle _unity_self);

		// Token: 0x060029A9 RID: 10665
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetReferenceObject_Injected(ref PlayableOutputHandle _unity_self, Object target);

		// Token: 0x060029AA RID: 10666
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object GetUserData_Injected(ref PlayableOutputHandle _unity_self);

		// Token: 0x060029AB RID: 10667
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetUserData_Injected(ref PlayableOutputHandle _unity_self, [Writable] Object target);

		// Token: 0x060029AC RID: 10668
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSourcePlayable_Injected(ref PlayableOutputHandle _unity_self, out PlayableHandle ret);

		// Token: 0x060029AD RID: 10669
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourcePlayable_Injected(ref PlayableOutputHandle _unity_self, ref PlayableHandle target, int port);

		// Token: 0x060029AE RID: 10670
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetSourceOutputPort_Injected(ref PlayableOutputHandle _unity_self);

		// Token: 0x060029AF RID: 10671
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetWeight_Injected(ref PlayableOutputHandle _unity_self);

		// Token: 0x060029B0 RID: 10672
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetWeight_Injected(ref PlayableOutputHandle _unity_self, float weight);

		// Token: 0x060029B1 RID: 10673
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PushNotification_Injected(ref PlayableOutputHandle _unity_self, ref PlayableHandle origin, INotification notification, object context);

		// Token: 0x060029B2 RID: 10674
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern INotificationReceiver[] GetNotificationReceivers_Injected(ref PlayableOutputHandle _unity_self);

		// Token: 0x060029B3 RID: 10675
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddNotificationReceiver_Injected(ref PlayableOutputHandle _unity_self, INotificationReceiver receiver);

		// Token: 0x060029B4 RID: 10676
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveNotificationReceiver_Injected(ref PlayableOutputHandle _unity_self, INotificationReceiver receiver);

		// Token: 0x04000F7F RID: 3967
		internal IntPtr m_Handle;

		// Token: 0x04000F80 RID: 3968
		internal uint m_Version;

		// Token: 0x04000F81 RID: 3969
		private static readonly PlayableOutputHandle m_Null = default(PlayableOutputHandle);
	}
}
