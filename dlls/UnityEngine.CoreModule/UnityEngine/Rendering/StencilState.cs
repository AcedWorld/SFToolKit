using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000479 RID: 1145
	public struct StencilState : IEquatable<StencilState>
	{
		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x060026F3 RID: 9971 RVA: 0x00042F00 File Offset: 0x00041100
		public static StencilState defaultValue
		{
			get
			{
				return new StencilState(true, byte.MaxValue, byte.MaxValue, CompareFunction.Always, StencilOp.Keep, StencilOp.Keep, StencilOp.Keep);
			}
		}

		// Token: 0x060026F4 RID: 9972 RVA: 0x00042F28 File Offset: 0x00041128
		public StencilState(bool enabled = true, byte readMask = 255, byte writeMask = 255, CompareFunction compareFunction = CompareFunction.Always, StencilOp passOperation = StencilOp.Keep, StencilOp failOperation = StencilOp.Keep, StencilOp zFailOperation = StencilOp.Keep)
		{
			this = new StencilState(enabled, readMask, writeMask, compareFunction, passOperation, failOperation, zFailOperation, compareFunction, passOperation, failOperation, zFailOperation);
		}

		// Token: 0x060026F5 RID: 9973 RVA: 0x00042F50 File Offset: 0x00041150
		public StencilState(bool enabled, byte readMask, byte writeMask, CompareFunction compareFunctionFront, StencilOp passOperationFront, StencilOp failOperationFront, StencilOp zFailOperationFront, CompareFunction compareFunctionBack, StencilOp passOperationBack, StencilOp failOperationBack, StencilOp zFailOperationBack)
		{
			this.m_Enabled = Convert.ToByte(enabled);
			this.m_ReadMask = readMask;
			this.m_WriteMask = writeMask;
			this.m_Padding = 0;
			this.m_CompareFunctionFront = (byte)compareFunctionFront;
			this.m_PassOperationFront = (byte)passOperationFront;
			this.m_FailOperationFront = (byte)failOperationFront;
			this.m_ZFailOperationFront = (byte)zFailOperationFront;
			this.m_CompareFunctionBack = (byte)compareFunctionBack;
			this.m_PassOperationBack = (byte)passOperationBack;
			this.m_FailOperationBack = (byte)failOperationBack;
			this.m_ZFailOperationBack = (byte)zFailOperationBack;
		}

		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x060026F6 RID: 9974 RVA: 0x00042FC8 File Offset: 0x000411C8
		// (set) Token: 0x060026F7 RID: 9975 RVA: 0x00042FE5 File Offset: 0x000411E5
		public bool enabled
		{
			get
			{
				return Convert.ToBoolean(this.m_Enabled);
			}
			set
			{
				this.m_Enabled = Convert.ToByte(value);
			}
		}

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x060026F8 RID: 9976 RVA: 0x00042FF4 File Offset: 0x000411F4
		// (set) Token: 0x060026F9 RID: 9977 RVA: 0x0004300C File Offset: 0x0004120C
		public byte readMask
		{
			get
			{
				return this.m_ReadMask;
			}
			set
			{
				this.m_ReadMask = value;
			}
		}

		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x060026FA RID: 9978 RVA: 0x00043018 File Offset: 0x00041218
		// (set) Token: 0x060026FB RID: 9979 RVA: 0x00043030 File Offset: 0x00041230
		public byte writeMask
		{
			get
			{
				return this.m_WriteMask;
			}
			set
			{
				this.m_WriteMask = value;
			}
		}

		// Token: 0x060026FC RID: 9980 RVA: 0x0004303A File Offset: 0x0004123A
		public void SetCompareFunction(CompareFunction value)
		{
			this.compareFunctionFront = value;
			this.compareFunctionBack = value;
		}

		// Token: 0x060026FD RID: 9981 RVA: 0x0004304D File Offset: 0x0004124D
		public void SetPassOperation(StencilOp value)
		{
			this.passOperationFront = value;
			this.passOperationBack = value;
		}

		// Token: 0x060026FE RID: 9982 RVA: 0x00043060 File Offset: 0x00041260
		public void SetFailOperation(StencilOp value)
		{
			this.failOperationFront = value;
			this.failOperationBack = value;
		}

		// Token: 0x060026FF RID: 9983 RVA: 0x00043073 File Offset: 0x00041273
		public void SetZFailOperation(StencilOp value)
		{
			this.zFailOperationFront = value;
			this.zFailOperationBack = value;
		}

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x06002700 RID: 9984 RVA: 0x00043088 File Offset: 0x00041288
		// (set) Token: 0x06002701 RID: 9985 RVA: 0x000430A0 File Offset: 0x000412A0
		public CompareFunction compareFunctionFront
		{
			get
			{
				return (CompareFunction)this.m_CompareFunctionFront;
			}
			set
			{
				this.m_CompareFunctionFront = (byte)value;
			}
		}

		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x06002702 RID: 9986 RVA: 0x000430AC File Offset: 0x000412AC
		// (set) Token: 0x06002703 RID: 9987 RVA: 0x000430C4 File Offset: 0x000412C4
		public StencilOp passOperationFront
		{
			get
			{
				return (StencilOp)this.m_PassOperationFront;
			}
			set
			{
				this.m_PassOperationFront = (byte)value;
			}
		}

		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x06002704 RID: 9988 RVA: 0x000430D0 File Offset: 0x000412D0
		// (set) Token: 0x06002705 RID: 9989 RVA: 0x000430E8 File Offset: 0x000412E8
		public StencilOp failOperationFront
		{
			get
			{
				return (StencilOp)this.m_FailOperationFront;
			}
			set
			{
				this.m_FailOperationFront = (byte)value;
			}
		}

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x06002706 RID: 9990 RVA: 0x000430F4 File Offset: 0x000412F4
		// (set) Token: 0x06002707 RID: 9991 RVA: 0x0004310C File Offset: 0x0004130C
		public StencilOp zFailOperationFront
		{
			get
			{
				return (StencilOp)this.m_ZFailOperationFront;
			}
			set
			{
				this.m_ZFailOperationFront = (byte)value;
			}
		}

		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x06002708 RID: 9992 RVA: 0x00043118 File Offset: 0x00041318
		// (set) Token: 0x06002709 RID: 9993 RVA: 0x00043130 File Offset: 0x00041330
		public CompareFunction compareFunctionBack
		{
			get
			{
				return (CompareFunction)this.m_CompareFunctionBack;
			}
			set
			{
				this.m_CompareFunctionBack = (byte)value;
			}
		}

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x0600270A RID: 9994 RVA: 0x0004313C File Offset: 0x0004133C
		// (set) Token: 0x0600270B RID: 9995 RVA: 0x00043154 File Offset: 0x00041354
		public StencilOp passOperationBack
		{
			get
			{
				return (StencilOp)this.m_PassOperationBack;
			}
			set
			{
				this.m_PassOperationBack = (byte)value;
			}
		}

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x0600270C RID: 9996 RVA: 0x00043160 File Offset: 0x00041360
		// (set) Token: 0x0600270D RID: 9997 RVA: 0x00043178 File Offset: 0x00041378
		public StencilOp failOperationBack
		{
			get
			{
				return (StencilOp)this.m_FailOperationBack;
			}
			set
			{
				this.m_FailOperationBack = (byte)value;
			}
		}

		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x0600270E RID: 9998 RVA: 0x00043184 File Offset: 0x00041384
		// (set) Token: 0x0600270F RID: 9999 RVA: 0x0004319C File Offset: 0x0004139C
		public StencilOp zFailOperationBack
		{
			get
			{
				return (StencilOp)this.m_ZFailOperationBack;
			}
			set
			{
				this.m_ZFailOperationBack = (byte)value;
			}
		}

		// Token: 0x06002710 RID: 10000 RVA: 0x000431A8 File Offset: 0x000413A8
		public bool Equals(StencilState other)
		{
			return this.m_Enabled == other.m_Enabled && this.m_ReadMask == other.m_ReadMask && this.m_WriteMask == other.m_WriteMask && this.m_CompareFunctionFront == other.m_CompareFunctionFront && this.m_PassOperationFront == other.m_PassOperationFront && this.m_FailOperationFront == other.m_FailOperationFront && this.m_ZFailOperationFront == other.m_ZFailOperationFront && this.m_CompareFunctionBack == other.m_CompareFunctionBack && this.m_PassOperationBack == other.m_PassOperationBack && this.m_FailOperationBack == other.m_FailOperationBack && this.m_ZFailOperationBack == other.m_ZFailOperationBack;
		}

		// Token: 0x06002711 RID: 10001 RVA: 0x00043260 File Offset: 0x00041460
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is StencilState && this.Equals((StencilState)obj);
		}

		// Token: 0x06002712 RID: 10002 RVA: 0x00043298 File Offset: 0x00041498
		public override int GetHashCode()
		{
			int num = this.m_Enabled.GetHashCode();
			num = (num * 397 ^ this.m_ReadMask.GetHashCode());
			num = (num * 397 ^ this.m_WriteMask.GetHashCode());
			num = (num * 397 ^ this.m_CompareFunctionFront.GetHashCode());
			num = (num * 397 ^ this.m_PassOperationFront.GetHashCode());
			num = (num * 397 ^ this.m_FailOperationFront.GetHashCode());
			num = (num * 397 ^ this.m_ZFailOperationFront.GetHashCode());
			num = (num * 397 ^ this.m_CompareFunctionBack.GetHashCode());
			num = (num * 397 ^ this.m_PassOperationBack.GetHashCode());
			num = (num * 397 ^ this.m_FailOperationBack.GetHashCode());
			return num * 397 ^ this.m_ZFailOperationBack.GetHashCode();
		}

		// Token: 0x06002713 RID: 10003 RVA: 0x00043380 File Offset: 0x00041580
		public static bool operator ==(StencilState left, StencilState right)
		{
			return left.Equals(right);
		}

		// Token: 0x06002714 RID: 10004 RVA: 0x0004339C File Offset: 0x0004159C
		public static bool operator !=(StencilState left, StencilState right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000EB8 RID: 3768
		private byte m_Enabled;

		// Token: 0x04000EB9 RID: 3769
		private byte m_ReadMask;

		// Token: 0x04000EBA RID: 3770
		private byte m_WriteMask;

		// Token: 0x04000EBB RID: 3771
		private byte m_Padding;

		// Token: 0x04000EBC RID: 3772
		private byte m_CompareFunctionFront;

		// Token: 0x04000EBD RID: 3773
		private byte m_PassOperationFront;

		// Token: 0x04000EBE RID: 3774
		private byte m_FailOperationFront;

		// Token: 0x04000EBF RID: 3775
		private byte m_ZFailOperationFront;

		// Token: 0x04000EC0 RID: 3776
		private byte m_CompareFunctionBack;

		// Token: 0x04000EC1 RID: 3777
		private byte m_PassOperationBack;

		// Token: 0x04000EC2 RID: 3778
		private byte m_FailOperationBack;

		// Token: 0x04000EC3 RID: 3779
		private byte m_ZFailOperationBack;
	}
}
