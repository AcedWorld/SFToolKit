using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Playables
{
	// Token: 0x020004A5 RID: 1189
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
	[UsedByNativeCode]
	[NativeHeader("Runtime/Export/Director/PlayableHandle.bindings.h")]
	public struct PlayableHandle : IEquatable<PlayableHandle>
	{
		// Token: 0x0600290B RID: 10507 RVA: 0x00046054 File Offset: 0x00044254
		internal T GetObject<T>() where T : class, IPlayableBehaviour
		{
			bool flag = !this.IsValid();
			T result;
			if (flag)
			{
				result = default(T);
			}
			else
			{
				object scriptInstance = this.GetScriptInstance();
				bool flag2 = scriptInstance == null;
				if (flag2)
				{
					result = default(T);
				}
				else
				{
					result = (T)((object)scriptInstance);
				}
			}
			return result;
		}

		// Token: 0x0600290C RID: 10508 RVA: 0x000460A4 File Offset: 0x000442A4
		[VisibleToOtherModules]
		internal bool IsPlayableOfType<T>()
		{
			return this.GetPlayableType() == typeof(T);
		}

		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x0600290D RID: 10509 RVA: 0x000460CC File Offset: 0x000442CC
		public static PlayableHandle Null
		{
			get
			{
				return PlayableHandle.m_Null;
			}
		}

		// Token: 0x0600290E RID: 10510 RVA: 0x000460E4 File Offset: 0x000442E4
		internal Playable GetInput(int inputPort)
		{
			return new Playable(this.GetInputHandle(inputPort));
		}

		// Token: 0x0600290F RID: 10511 RVA: 0x00046104 File Offset: 0x00044304
		internal Playable GetOutput(int outputPort)
		{
			return new Playable(this.GetOutputHandle(outputPort));
		}

		// Token: 0x06002910 RID: 10512 RVA: 0x00046124 File Offset: 0x00044324
		internal bool SetInputWeight(int inputIndex, float weight)
		{
			bool flag = this.CheckInputBounds(inputIndex);
			bool result;
			if (flag)
			{
				this.SetInputWeightFromIndex(inputIndex, weight);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06002911 RID: 10513 RVA: 0x00046150 File Offset: 0x00044350
		internal float GetInputWeight(int inputIndex)
		{
			bool flag = this.CheckInputBounds(inputIndex);
			float result;
			if (flag)
			{
				result = this.GetInputWeightFromIndex(inputIndex);
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x06002912 RID: 10514 RVA: 0x00046180 File Offset: 0x00044380
		internal void Destroy()
		{
			this.GetGraph().DestroyPlayable<Playable>(new Playable(this));
		}

		// Token: 0x06002913 RID: 10515 RVA: 0x000461A8 File Offset: 0x000443A8
		public static bool operator ==(PlayableHandle x, PlayableHandle y)
		{
			return PlayableHandle.CompareVersion(x, y);
		}

		// Token: 0x06002914 RID: 10516 RVA: 0x000461C4 File Offset: 0x000443C4
		public static bool operator !=(PlayableHandle x, PlayableHandle y)
		{
			return !PlayableHandle.CompareVersion(x, y);
		}

		// Token: 0x06002915 RID: 10517 RVA: 0x000461E0 File Offset: 0x000443E0
		public override bool Equals(object p)
		{
			return p is PlayableHandle && this.Equals((PlayableHandle)p);
		}

		// Token: 0x06002916 RID: 10518 RVA: 0x0004620C File Offset: 0x0004440C
		public bool Equals(PlayableHandle other)
		{
			return PlayableHandle.CompareVersion(this, other);
		}

		// Token: 0x06002917 RID: 10519 RVA: 0x0004622C File Offset: 0x0004442C
		public override int GetHashCode()
		{
			return this.m_Handle.GetHashCode() ^ this.m_Version.GetHashCode();
		}

		// Token: 0x06002918 RID: 10520 RVA: 0x00046258 File Offset: 0x00044458
		internal static bool CompareVersion(PlayableHandle lhs, PlayableHandle rhs)
		{
			return lhs.m_Handle == rhs.m_Handle && lhs.m_Version == rhs.m_Version;
		}

		// Token: 0x06002919 RID: 10521 RVA: 0x00046290 File Offset: 0x00044490
		internal bool CheckInputBounds(int inputIndex)
		{
			return this.CheckInputBounds(inputIndex, false);
		}

		// Token: 0x0600291A RID: 10522 RVA: 0x000462AC File Offset: 0x000444AC
		internal bool CheckInputBounds(int inputIndex, bool acceptAny)
		{
			bool flag = inputIndex == -1 && acceptAny;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = inputIndex < 0;
				if (flag2)
				{
					throw new IndexOutOfRangeException("Index must be greater than 0");
				}
				bool flag3 = this.GetInputCount() <= inputIndex;
				if (flag3)
				{
					throw new IndexOutOfRangeException(string.Concat(new string[]
					{
						"inputIndex ",
						inputIndex.ToString(),
						" is greater than the number of available inputs (",
						this.GetInputCount().ToString(),
						")."
					}));
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600291B RID: 10523 RVA: 0x00046337 File Offset: 0x00044537
		[VisibleToOtherModules]
		internal bool IsNull()
		{
			return PlayableHandle.IsNull_Injected(ref this);
		}

		// Token: 0x0600291C RID: 10524 RVA: 0x0004633F File Offset: 0x0004453F
		[VisibleToOtherModules]
		internal bool IsValid()
		{
			return PlayableHandle.IsValid_Injected(ref this);
		}

		// Token: 0x0600291D RID: 10525 RVA: 0x00046347 File Offset: 0x00044547
		[FreeFunction("PlayableHandleBindings::GetPlayableType", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal Type GetPlayableType()
		{
			return PlayableHandle.GetPlayableType_Injected(ref this);
		}

		// Token: 0x0600291E RID: 10526 RVA: 0x0004634F File Offset: 0x0004454F
		[FreeFunction("PlayableHandleBindings::GetJobType", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal Type GetJobType()
		{
			return PlayableHandle.GetJobType_Injected(ref this);
		}

		// Token: 0x0600291F RID: 10527 RVA: 0x00046357 File Offset: 0x00044557
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::SetScriptInstance", HasExplicitThis = true, ThrowsException = true)]
		internal void SetScriptInstance(object scriptInstance)
		{
			PlayableHandle.SetScriptInstance_Injected(ref this, scriptInstance);
		}

		// Token: 0x06002920 RID: 10528 RVA: 0x00046360 File Offset: 0x00044560
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::CanChangeInputs", HasExplicitThis = true, ThrowsException = true)]
		internal bool CanChangeInputs()
		{
			return PlayableHandle.CanChangeInputs_Injected(ref this);
		}

		// Token: 0x06002921 RID: 10529 RVA: 0x00046368 File Offset: 0x00044568
		[FreeFunction("PlayableHandleBindings::CanSetWeights", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal bool CanSetWeights()
		{
			return PlayableHandle.CanSetWeights_Injected(ref this);
		}

		// Token: 0x06002922 RID: 10530 RVA: 0x00046370 File Offset: 0x00044570
		[FreeFunction("PlayableHandleBindings::CanDestroy", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal bool CanDestroy()
		{
			return PlayableHandle.CanDestroy_Injected(ref this);
		}

		// Token: 0x06002923 RID: 10531 RVA: 0x00046378 File Offset: 0x00044578
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetPlayState", HasExplicitThis = true, ThrowsException = true)]
		internal PlayState GetPlayState()
		{
			return PlayableHandle.GetPlayState_Injected(ref this);
		}

		// Token: 0x06002924 RID: 10532 RVA: 0x00046380 File Offset: 0x00044580
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::Play", HasExplicitThis = true, ThrowsException = true)]
		internal void Play()
		{
			PlayableHandle.Play_Injected(ref this);
		}

		// Token: 0x06002925 RID: 10533 RVA: 0x00046388 File Offset: 0x00044588
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::Pause", HasExplicitThis = true, ThrowsException = true)]
		internal void Pause()
		{
			PlayableHandle.Pause_Injected(ref this);
		}

		// Token: 0x06002926 RID: 10534 RVA: 0x00046390 File Offset: 0x00044590
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetSpeed", HasExplicitThis = true, ThrowsException = true)]
		internal double GetSpeed()
		{
			return PlayableHandle.GetSpeed_Injected(ref this);
		}

		// Token: 0x06002927 RID: 10535 RVA: 0x00046398 File Offset: 0x00044598
		[FreeFunction("PlayableHandleBindings::SetSpeed", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal void SetSpeed(double value)
		{
			PlayableHandle.SetSpeed_Injected(ref this, value);
		}

		// Token: 0x06002928 RID: 10536 RVA: 0x000463A1 File Offset: 0x000445A1
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetTime", HasExplicitThis = true, ThrowsException = true)]
		internal double GetTime()
		{
			return PlayableHandle.GetTime_Injected(ref this);
		}

		// Token: 0x06002929 RID: 10537 RVA: 0x000463A9 File Offset: 0x000445A9
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::SetTime", HasExplicitThis = true, ThrowsException = true)]
		internal void SetTime(double value)
		{
			PlayableHandle.SetTime_Injected(ref this, value);
		}

		// Token: 0x0600292A RID: 10538 RVA: 0x000463B2 File Offset: 0x000445B2
		[FreeFunction("PlayableHandleBindings::IsDone", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal bool IsDone()
		{
			return PlayableHandle.IsDone_Injected(ref this);
		}

		// Token: 0x0600292B RID: 10539 RVA: 0x000463BA File Offset: 0x000445BA
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::SetDone", HasExplicitThis = true, ThrowsException = true)]
		internal void SetDone(bool value)
		{
			PlayableHandle.SetDone_Injected(ref this, value);
		}

		// Token: 0x0600292C RID: 10540 RVA: 0x000463C3 File Offset: 0x000445C3
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetDuration", HasExplicitThis = true, ThrowsException = true)]
		internal double GetDuration()
		{
			return PlayableHandle.GetDuration_Injected(ref this);
		}

		// Token: 0x0600292D RID: 10541 RVA: 0x000463CB File Offset: 0x000445CB
		[FreeFunction("PlayableHandleBindings::SetDuration", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal void SetDuration(double value)
		{
			PlayableHandle.SetDuration_Injected(ref this, value);
		}

		// Token: 0x0600292E RID: 10542 RVA: 0x000463D4 File Offset: 0x000445D4
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetPropagateSetTime", HasExplicitThis = true, ThrowsException = true)]
		internal bool GetPropagateSetTime()
		{
			return PlayableHandle.GetPropagateSetTime_Injected(ref this);
		}

		// Token: 0x0600292F RID: 10543 RVA: 0x000463DC File Offset: 0x000445DC
		[FreeFunction("PlayableHandleBindings::SetPropagateSetTime", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal void SetPropagateSetTime(bool value)
		{
			PlayableHandle.SetPropagateSetTime_Injected(ref this, value);
		}

		// Token: 0x06002930 RID: 10544 RVA: 0x000463E8 File Offset: 0x000445E8
		[FreeFunction("PlayableHandleBindings::GetGraph", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal PlayableGraph GetGraph()
		{
			PlayableGraph result;
			PlayableHandle.GetGraph_Injected(ref this, out result);
			return result;
		}

		// Token: 0x06002931 RID: 10545 RVA: 0x000463FE File Offset: 0x000445FE
		[FreeFunction("PlayableHandleBindings::GetInputCount", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal int GetInputCount()
		{
			return PlayableHandle.GetInputCount_Injected(ref this);
		}

		// Token: 0x06002932 RID: 10546 RVA: 0x00046406 File Offset: 0x00044606
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::SetInputCount", HasExplicitThis = true, ThrowsException = true)]
		internal void SetInputCount(int value)
		{
			PlayableHandle.SetInputCount_Injected(ref this, value);
		}

		// Token: 0x06002933 RID: 10547 RVA: 0x0004640F File Offset: 0x0004460F
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetOutputCount", HasExplicitThis = true, ThrowsException = true)]
		internal int GetOutputCount()
		{
			return PlayableHandle.GetOutputCount_Injected(ref this);
		}

		// Token: 0x06002934 RID: 10548 RVA: 0x00046417 File Offset: 0x00044617
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::SetOutputCount", HasExplicitThis = true, ThrowsException = true)]
		internal void SetOutputCount(int value)
		{
			PlayableHandle.SetOutputCount_Injected(ref this, value);
		}

		// Token: 0x06002935 RID: 10549 RVA: 0x00046420 File Offset: 0x00044620
		[FreeFunction("PlayableHandleBindings::SetInputWeight", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal void SetInputWeight(PlayableHandle input, float weight)
		{
			PlayableHandle.SetInputWeight_Injected(ref this, ref input, weight);
		}

		// Token: 0x06002936 RID: 10550 RVA: 0x0004642B File Offset: 0x0004462B
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::SetDelay", HasExplicitThis = true, ThrowsException = true)]
		internal void SetDelay(double delay)
		{
			PlayableHandle.SetDelay_Injected(ref this, delay);
		}

		// Token: 0x06002937 RID: 10551 RVA: 0x00046434 File Offset: 0x00044634
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetDelay", HasExplicitThis = true, ThrowsException = true)]
		internal double GetDelay()
		{
			return PlayableHandle.GetDelay_Injected(ref this);
		}

		// Token: 0x06002938 RID: 10552 RVA: 0x0004643C File Offset: 0x0004463C
		[FreeFunction("PlayableHandleBindings::IsDelayed", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal bool IsDelayed()
		{
			return PlayableHandle.IsDelayed_Injected(ref this);
		}

		// Token: 0x06002939 RID: 10553 RVA: 0x00046444 File Offset: 0x00044644
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetPreviousTime", HasExplicitThis = true, ThrowsException = true)]
		internal double GetPreviousTime()
		{
			return PlayableHandle.GetPreviousTime_Injected(ref this);
		}

		// Token: 0x0600293A RID: 10554 RVA: 0x0004644C File Offset: 0x0004464C
		[FreeFunction("PlayableHandleBindings::SetLeadTime", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal void SetLeadTime(float value)
		{
			PlayableHandle.SetLeadTime_Injected(ref this, value);
		}

		// Token: 0x0600293B RID: 10555 RVA: 0x00046455 File Offset: 0x00044655
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetLeadTime", HasExplicitThis = true, ThrowsException = true)]
		internal float GetLeadTime()
		{
			return PlayableHandle.GetLeadTime_Injected(ref this);
		}

		// Token: 0x0600293C RID: 10556 RVA: 0x0004645D File Offset: 0x0004465D
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetTraversalMode", HasExplicitThis = true, ThrowsException = true)]
		internal PlayableTraversalMode GetTraversalMode()
		{
			return PlayableHandle.GetTraversalMode_Injected(ref this);
		}

		// Token: 0x0600293D RID: 10557 RVA: 0x00046465 File Offset: 0x00044665
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::SetTraversalMode", HasExplicitThis = true, ThrowsException = true)]
		internal void SetTraversalMode(PlayableTraversalMode mode)
		{
			PlayableHandle.SetTraversalMode_Injected(ref this, mode);
		}

		// Token: 0x0600293E RID: 10558 RVA: 0x0004646E File Offset: 0x0004466E
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetJobData", HasExplicitThis = true, ThrowsException = true)]
		internal IntPtr GetJobData()
		{
			return PlayableHandle.GetJobData_Injected(ref this);
		}

		// Token: 0x0600293F RID: 10559 RVA: 0x00046476 File Offset: 0x00044676
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::GetTimeWrapMode", HasExplicitThis = true, ThrowsException = true)]
		internal DirectorWrapMode GetTimeWrapMode()
		{
			return PlayableHandle.GetTimeWrapMode_Injected(ref this);
		}

		// Token: 0x06002940 RID: 10560 RVA: 0x0004647E File Offset: 0x0004467E
		[VisibleToOtherModules]
		[FreeFunction("PlayableHandleBindings::SetTimeWrapMode", HasExplicitThis = true, ThrowsException = true)]
		internal void SetTimeWrapMode(DirectorWrapMode mode)
		{
			PlayableHandle.SetTimeWrapMode_Injected(ref this, mode);
		}

		// Token: 0x06002941 RID: 10561 RVA: 0x00046487 File Offset: 0x00044687
		[FreeFunction("PlayableHandleBindings::GetScriptInstance", HasExplicitThis = true, ThrowsException = true)]
		private object GetScriptInstance()
		{
			return PlayableHandle.GetScriptInstance_Injected(ref this);
		}

		// Token: 0x06002942 RID: 10562 RVA: 0x00046490 File Offset: 0x00044690
		[FreeFunction("PlayableHandleBindings::GetInputHandle", HasExplicitThis = true, ThrowsException = true)]
		private PlayableHandle GetInputHandle(int index)
		{
			PlayableHandle result;
			PlayableHandle.GetInputHandle_Injected(ref this, index, out result);
			return result;
		}

		// Token: 0x06002943 RID: 10563 RVA: 0x000464A8 File Offset: 0x000446A8
		[FreeFunction("PlayableHandleBindings::GetOutputHandle", HasExplicitThis = true, ThrowsException = true)]
		private PlayableHandle GetOutputHandle(int index)
		{
			PlayableHandle result;
			PlayableHandle.GetOutputHandle_Injected(ref this, index, out result);
			return result;
		}

		// Token: 0x06002944 RID: 10564 RVA: 0x000464BF File Offset: 0x000446BF
		[FreeFunction("PlayableHandleBindings::SetInputWeightFromIndex", HasExplicitThis = true, ThrowsException = true)]
		private void SetInputWeightFromIndex(int index, float weight)
		{
			PlayableHandle.SetInputWeightFromIndex_Injected(ref this, index, weight);
		}

		// Token: 0x06002945 RID: 10565 RVA: 0x000464C9 File Offset: 0x000446C9
		[FreeFunction("PlayableHandleBindings::GetInputWeightFromIndex", HasExplicitThis = true, ThrowsException = true)]
		private float GetInputWeightFromIndex(int index)
		{
			return PlayableHandle.GetInputWeightFromIndex_Injected(ref this, index);
		}

		// Token: 0x06002947 RID: 10567
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsNull_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002948 RID: 10568
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsValid_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002949 RID: 10569
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Type GetPlayableType_Injected(ref PlayableHandle _unity_self);

		// Token: 0x0600294A RID: 10570
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Type GetJobType_Injected(ref PlayableHandle _unity_self);

		// Token: 0x0600294B RID: 10571
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetScriptInstance_Injected(ref PlayableHandle _unity_self, object scriptInstance);

		// Token: 0x0600294C RID: 10572
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CanChangeInputs_Injected(ref PlayableHandle _unity_self);

		// Token: 0x0600294D RID: 10573
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CanSetWeights_Injected(ref PlayableHandle _unity_self);

		// Token: 0x0600294E RID: 10574
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CanDestroy_Injected(ref PlayableHandle _unity_self);

		// Token: 0x0600294F RID: 10575
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern PlayState GetPlayState_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002950 RID: 10576
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Play_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002951 RID: 10577
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Pause_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002952 RID: 10578
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double GetSpeed_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002953 RID: 10579
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSpeed_Injected(ref PlayableHandle _unity_self, double value);

		// Token: 0x06002954 RID: 10580
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double GetTime_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002955 RID: 10581
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTime_Injected(ref PlayableHandle _unity_self, double value);

		// Token: 0x06002956 RID: 10582
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsDone_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002957 RID: 10583
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDone_Injected(ref PlayableHandle _unity_self, bool value);

		// Token: 0x06002958 RID: 10584
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double GetDuration_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002959 RID: 10585
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDuration_Injected(ref PlayableHandle _unity_self, double value);

		// Token: 0x0600295A RID: 10586
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetPropagateSetTime_Injected(ref PlayableHandle _unity_self);

		// Token: 0x0600295B RID: 10587
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPropagateSetTime_Injected(ref PlayableHandle _unity_self, bool value);

		// Token: 0x0600295C RID: 10588
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetGraph_Injected(ref PlayableHandle _unity_self, out PlayableGraph ret);

		// Token: 0x0600295D RID: 10589
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetInputCount_Injected(ref PlayableHandle _unity_self);

		// Token: 0x0600295E RID: 10590
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetInputCount_Injected(ref PlayableHandle _unity_self, int value);

		// Token: 0x0600295F RID: 10591
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetOutputCount_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002960 RID: 10592
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetOutputCount_Injected(ref PlayableHandle _unity_self, int value);

		// Token: 0x06002961 RID: 10593
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetInputWeight_Injected(ref PlayableHandle _unity_self, ref PlayableHandle input, float weight);

		// Token: 0x06002962 RID: 10594
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetDelay_Injected(ref PlayableHandle _unity_self, double delay);

		// Token: 0x06002963 RID: 10595
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double GetDelay_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002964 RID: 10596
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsDelayed_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002965 RID: 10597
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double GetPreviousTime_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002966 RID: 10598
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLeadTime_Injected(ref PlayableHandle _unity_self, float value);

		// Token: 0x06002967 RID: 10599
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetLeadTime_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002968 RID: 10600
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern PlayableTraversalMode GetTraversalMode_Injected(ref PlayableHandle _unity_self);

		// Token: 0x06002969 RID: 10601
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTraversalMode_Injected(ref PlayableHandle _unity_self, PlayableTraversalMode mode);

		// Token: 0x0600296A RID: 10602
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetJobData_Injected(ref PlayableHandle _unity_self);

		// Token: 0x0600296B RID: 10603
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern DirectorWrapMode GetTimeWrapMode_Injected(ref PlayableHandle _unity_self);

		// Token: 0x0600296C RID: 10604
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTimeWrapMode_Injected(ref PlayableHandle _unity_self, DirectorWrapMode mode);

		// Token: 0x0600296D RID: 10605
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object GetScriptInstance_Injected(ref PlayableHandle _unity_self);

		// Token: 0x0600296E RID: 10606
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetInputHandle_Injected(ref PlayableHandle _unity_self, int index, out PlayableHandle ret);

		// Token: 0x0600296F RID: 10607
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetOutputHandle_Injected(ref PlayableHandle _unity_self, int index, out PlayableHandle ret);

		// Token: 0x06002970 RID: 10608
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetInputWeightFromIndex_Injected(ref PlayableHandle _unity_self, int index, float weight);

		// Token: 0x06002971 RID: 10609
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetInputWeightFromIndex_Injected(ref PlayableHandle _unity_self, int index);

		// Token: 0x04000F7A RID: 3962
		internal IntPtr m_Handle;

		// Token: 0x04000F7B RID: 3963
		internal uint m_Version;

		// Token: 0x04000F7C RID: 3964
		private static readonly PlayableHandle m_Null = default(PlayableHandle);
	}
}
