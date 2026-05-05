using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200045B RID: 1115
	public struct LODParameters : IEquatable<LODParameters>
	{
		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06002575 RID: 9589 RVA: 0x0003FE9C File Offset: 0x0003E09C
		// (set) Token: 0x06002576 RID: 9590 RVA: 0x0003FEB9 File Offset: 0x0003E0B9
		public bool isOrthographic
		{
			get
			{
				return Convert.ToBoolean(this.m_IsOrthographic);
			}
			set
			{
				this.m_IsOrthographic = Convert.ToInt32(value);
			}
		}

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06002577 RID: 9591 RVA: 0x0003FEC8 File Offset: 0x0003E0C8
		// (set) Token: 0x06002578 RID: 9592 RVA: 0x0003FEE0 File Offset: 0x0003E0E0
		public Vector3 cameraPosition
		{
			get
			{
				return this.m_CameraPosition;
			}
			set
			{
				this.m_CameraPosition = value;
			}
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06002579 RID: 9593 RVA: 0x0003FEEC File Offset: 0x0003E0EC
		// (set) Token: 0x0600257A RID: 9594 RVA: 0x0003FF04 File Offset: 0x0003E104
		public float fieldOfView
		{
			get
			{
				return this.m_FieldOfView;
			}
			set
			{
				this.m_FieldOfView = value;
			}
		}

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x0600257B RID: 9595 RVA: 0x0003FF10 File Offset: 0x0003E110
		// (set) Token: 0x0600257C RID: 9596 RVA: 0x0003FF28 File Offset: 0x0003E128
		public float orthoSize
		{
			get
			{
				return this.m_OrthoSize;
			}
			set
			{
				this.m_OrthoSize = value;
			}
		}

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x0600257D RID: 9597 RVA: 0x0003FF34 File Offset: 0x0003E134
		// (set) Token: 0x0600257E RID: 9598 RVA: 0x0003FF4C File Offset: 0x0003E14C
		public int cameraPixelHeight
		{
			get
			{
				return this.m_CameraPixelHeight;
			}
			set
			{
				this.m_CameraPixelHeight = value;
			}
		}

		// Token: 0x0600257F RID: 9599 RVA: 0x0003FF58 File Offset: 0x0003E158
		public bool Equals(LODParameters other)
		{
			return this.m_IsOrthographic == other.m_IsOrthographic && this.m_CameraPosition.Equals(other.m_CameraPosition) && this.m_FieldOfView.Equals(other.m_FieldOfView) && this.m_OrthoSize.Equals(other.m_OrthoSize) && this.m_CameraPixelHeight == other.m_CameraPixelHeight;
		}

		// Token: 0x06002580 RID: 9600 RVA: 0x0003FFC4 File Offset: 0x0003E1C4
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is LODParameters && this.Equals((LODParameters)obj);
		}

		// Token: 0x06002581 RID: 9601 RVA: 0x0003FFFC File Offset: 0x0003E1FC
		public override int GetHashCode()
		{
			int num = this.m_IsOrthographic;
			num = (num * 397 ^ this.m_CameraPosition.GetHashCode());
			num = (num * 397 ^ this.m_FieldOfView.GetHashCode());
			num = (num * 397 ^ this.m_OrthoSize.GetHashCode());
			return num * 397 ^ this.m_CameraPixelHeight;
		}

		// Token: 0x06002582 RID: 9602 RVA: 0x00040068 File Offset: 0x0003E268
		public static bool operator ==(LODParameters left, LODParameters right)
		{
			return left.Equals(right);
		}

		// Token: 0x06002583 RID: 9603 RVA: 0x00040084 File Offset: 0x0003E284
		public static bool operator !=(LODParameters left, LODParameters right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000E23 RID: 3619
		private int m_IsOrthographic;

		// Token: 0x04000E24 RID: 3620
		private Vector3 m_CameraPosition;

		// Token: 0x04000E25 RID: 3621
		private float m_FieldOfView;

		// Token: 0x04000E26 RID: 3622
		private float m_OrthoSize;

		// Token: 0x04000E27 RID: 3623
		private int m_CameraPixelHeight;
	}
}
