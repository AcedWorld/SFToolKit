using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x020001AD RID: 429
	[NativeHeader("Runtime/Camera/LightProbeProxyVolume.h")]
	public sealed class LightProbeProxyVolume : Behaviour
	{
		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000FEB RID: 4075
		public static extern bool isFeatureSupported { [NativeName("IsFeatureSupported")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000FEC RID: 4076 RVA: 0x00015C90 File Offset: 0x00013E90
		[NativeName("GlobalAABB")]
		public Bounds boundsGlobal
		{
			get
			{
				Bounds result;
				this.get_boundsGlobal_Injected(out result);
				return result;
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000FED RID: 4077 RVA: 0x00015CA8 File Offset: 0x00013EA8
		// (set) Token: 0x06000FEE RID: 4078 RVA: 0x00015CBE File Offset: 0x00013EBE
		[NativeName("BoundingBoxSizeCustom")]
		public Vector3 sizeCustom
		{
			get
			{
				Vector3 result;
				this.get_sizeCustom_Injected(out result);
				return result;
			}
			set
			{
				this.set_sizeCustom_Injected(ref value);
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000FEF RID: 4079 RVA: 0x00015CC8 File Offset: 0x00013EC8
		// (set) Token: 0x06000FF0 RID: 4080 RVA: 0x00015CDE File Offset: 0x00013EDE
		[NativeName("BoundingBoxOriginCustom")]
		public Vector3 originCustom
		{
			get
			{
				Vector3 result;
				this.get_originCustom_Injected(out result);
				return result;
			}
			set
			{
				this.set_originCustom_Injected(ref value);
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000FF1 RID: 4081
		// (set) Token: 0x06000FF2 RID: 4082
		public extern float probeDensity { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000FF3 RID: 4083
		// (set) Token: 0x06000FF4 RID: 4084
		public extern int gridResolutionX { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000FF5 RID: 4085
		// (set) Token: 0x06000FF6 RID: 4086
		public extern int gridResolutionY { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000FF7 RID: 4087
		// (set) Token: 0x06000FF8 RID: 4088
		public extern int gridResolutionZ { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000FF9 RID: 4089
		// (set) Token: 0x06000FFA RID: 4090
		public extern LightProbeProxyVolume.BoundingBoxMode boundingBoxMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000FFB RID: 4091
		// (set) Token: 0x06000FFC RID: 4092
		public extern LightProbeProxyVolume.ResolutionMode resolutionMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000FFD RID: 4093
		// (set) Token: 0x06000FFE RID: 4094
		public extern LightProbeProxyVolume.ProbePositionMode probePositionMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000FFF RID: 4095
		// (set) Token: 0x06001000 RID: 4096
		public extern LightProbeProxyVolume.RefreshMode refreshMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06001001 RID: 4097
		// (set) Token: 0x06001002 RID: 4098
		public extern LightProbeProxyVolume.QualityMode qualityMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06001003 RID: 4099
		// (set) Token: 0x06001004 RID: 4100
		public extern LightProbeProxyVolume.DataFormat dataFormat { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06001005 RID: 4101 RVA: 0x00015CE8 File Offset: 0x00013EE8
		public void Update()
		{
			this.SetDirtyFlag(true);
		}

		// Token: 0x06001006 RID: 4102
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetDirtyFlag(bool flag);

		// Token: 0x06001008 RID: 4104
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_boundsGlobal_Injected(out Bounds ret);

		// Token: 0x06001009 RID: 4105
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_sizeCustom_Injected(out Vector3 ret);

		// Token: 0x0600100A RID: 4106
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_sizeCustom_Injected(ref Vector3 value);

		// Token: 0x0600100B RID: 4107
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_originCustom_Injected(out Vector3 ret);

		// Token: 0x0600100C RID: 4108
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_originCustom_Injected(ref Vector3 value);

		// Token: 0x020001AE RID: 430
		public enum ResolutionMode
		{
			// Token: 0x040005FB RID: 1531
			Automatic,
			// Token: 0x040005FC RID: 1532
			Custom
		}

		// Token: 0x020001AF RID: 431
		public enum BoundingBoxMode
		{
			// Token: 0x040005FE RID: 1534
			AutomaticLocal,
			// Token: 0x040005FF RID: 1535
			AutomaticWorld,
			// Token: 0x04000600 RID: 1536
			Custom
		}

		// Token: 0x020001B0 RID: 432
		public enum ProbePositionMode
		{
			// Token: 0x04000602 RID: 1538
			CellCorner,
			// Token: 0x04000603 RID: 1539
			CellCenter
		}

		// Token: 0x020001B1 RID: 433
		public enum RefreshMode
		{
			// Token: 0x04000605 RID: 1541
			Automatic,
			// Token: 0x04000606 RID: 1542
			EveryFrame,
			// Token: 0x04000607 RID: 1543
			ViaScripting
		}

		// Token: 0x020001B2 RID: 434
		public enum QualityMode
		{
			// Token: 0x04000609 RID: 1545
			Low,
			// Token: 0x0400060A RID: 1546
			Normal
		}

		// Token: 0x020001B3 RID: 435
		public enum DataFormat
		{
			// Token: 0x0400060C RID: 1548
			HalfFloat,
			// Token: 0x0400060D RID: 1549
			Float
		}
	}
}
