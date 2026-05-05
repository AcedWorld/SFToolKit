using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001EE RID: 494
	[RequiredByNativeCode]
	[NativeHeader("Runtime/Export/Math/Gradient.bindings.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class Gradient : IEquatable<Gradient>
	{
		// Token: 0x06001528 RID: 5416
		[FreeFunction(Name = "Gradient_Bindings::Init", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Init();

		// Token: 0x06001529 RID: 5417
		[FreeFunction(Name = "Gradient_Bindings::Cleanup", IsThreadSafe = true, HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Cleanup();

		// Token: 0x0600152A RID: 5418
		[FreeFunction("Gradient_Bindings::Internal_Equals", IsThreadSafe = true, HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool Internal_Equals(IntPtr other);

		// Token: 0x0600152B RID: 5419 RVA: 0x0001FBCF File Offset: 0x0001DDCF
		[RequiredByNativeCode]
		public Gradient()
		{
			this.m_Ptr = Gradient.Init();
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x0001FBE4 File Offset: 0x0001DDE4
		~Gradient()
		{
			this.Cleanup();
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x0001FC14 File Offset: 0x0001DE14
		[FreeFunction(Name = "Gradient_Bindings::Evaluate", IsThreadSafe = true, HasExplicitThis = true)]
		public Color Evaluate(float time)
		{
			Color result;
			this.Evaluate_Injected(time, out result);
			return result;
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x0600152E RID: 5422
		// (set) Token: 0x0600152F RID: 5423
		public extern GradientColorKey[] colorKeys { [FreeFunction("Gradient_Bindings::GetColorKeys", IsThreadSafe = true, HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction("Gradient_Bindings::SetColorKeys", IsThreadSafe = true, HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] [param: Unmarshalled] set; }

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06001530 RID: 5424
		// (set) Token: 0x06001531 RID: 5425
		public extern GradientAlphaKey[] alphaKeys { [FreeFunction("Gradient_Bindings::GetAlphaKeys", IsThreadSafe = true, HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction("Gradient_Bindings::SetAlphaKeys", IsThreadSafe = true, HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] [param: Unmarshalled] set; }

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06001532 RID: 5426
		// (set) Token: 0x06001533 RID: 5427
		[NativeProperty(IsThreadSafe = true)]
		public extern GradientMode mode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06001534 RID: 5428
		// (set) Token: 0x06001535 RID: 5429
		[NativeProperty(IsThreadSafe = true)]
		public extern ColorSpace colorSpace { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06001536 RID: 5430
		[FreeFunction(Name = "Gradient_Bindings::SetKeys", IsThreadSafe = true, HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetKeys([Unmarshalled] GradientColorKey[] colorKeys, [Unmarshalled] GradientAlphaKey[] alphaKeys);

		// Token: 0x06001537 RID: 5431 RVA: 0x0001FC2C File Offset: 0x0001DE2C
		public override bool Equals(object o)
		{
			bool flag = o == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this == o;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = o.GetType() != base.GetType();
					result = (!flag3 && this.Equals((Gradient)o));
				}
			}
			return result;
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x0001FC80 File Offset: 0x0001DE80
		public bool Equals(Gradient other)
		{
			bool flag = other == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this == other;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = this.m_Ptr.Equals(other.m_Ptr);
					result = (flag3 || this.Internal_Equals(other.m_Ptr));
				}
			}
			return result;
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x0001FCD8 File Offset: 0x0001DED8
		public override int GetHashCode()
		{
			return this.m_Ptr.GetHashCode();
		}

		// Token: 0x0600153A RID: 5434
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Evaluate_Injected(float time, out Color ret);

		// Token: 0x040007E3 RID: 2019
		internal IntPtr m_Ptr;
	}
}
