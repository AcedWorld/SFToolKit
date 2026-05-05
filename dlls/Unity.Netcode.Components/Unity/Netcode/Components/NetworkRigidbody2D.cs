using System;
using UnityEngine;

namespace Unity.Netcode.Components
{
	// Token: 0x0200001F RID: 31
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(NetworkTransform))]
	[AddComponentMenu("Netcode/Network Rigidbody 2D")]
	public class NetworkRigidbody2D : NetworkBehaviour
	{
		// Token: 0x060000AB RID: 171 RVA: 0x000063AB File Offset: 0x000045AB
		private void Awake()
		{
			this.m_NetworkTransform = base.GetComponent<NetworkTransform>();
			this.m_IsServerAuthoritative = this.m_NetworkTransform.IsServerAuthoritative();
			this.SetupRigidBody();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000063D0 File Offset: 0x000045D0
		private void SetupRigidBody()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody2D>();
			this.m_OriginalInterpolation = this.m_Rigidbody.interpolation;
			this.m_Rigidbody.interpolation = (this.m_IsAuthority ? this.m_OriginalInterpolation : (this.m_NetworkTransform.Interpolate ? RigidbodyInterpolation2D.None : this.m_OriginalInterpolation));
			this.SetIsKinematic(true);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00006432 File Offset: 0x00004632
		private void SetIsKinematic(bool isKinematic)
		{
			this.m_Rigidbody.bodyType = (isKinematic ? RigidbodyType2D.Kinematic : RigidbodyType2D.Dynamic);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00006446 File Offset: 0x00004646
		public override void OnGainedOwnership()
		{
			this.UpdateOwnershipAuthority();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00006446 File Offset: 0x00004646
		public override void OnLostOwnership()
		{
			this.UpdateOwnershipAuthority();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00006450 File Offset: 0x00004650
		private void UpdateOwnershipAuthority()
		{
			if (this.m_IsServerAuthoritative)
			{
				this.m_IsAuthority = base.NetworkManager.IsServer;
			}
			else
			{
				this.m_IsAuthority = base.IsOwner;
			}
			this.SetIsKinematic(!this.m_IsAuthority);
			this.m_Rigidbody.interpolation = (this.m_IsAuthority ? this.m_OriginalInterpolation : RigidbodyInterpolation2D.None);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00006446 File Offset: 0x00004646
		public override void OnNetworkSpawn()
		{
			this.UpdateOwnershipAuthority();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00006446 File Offset: 0x00004646
		public override void OnNetworkDespawn()
		{
			this.UpdateOwnershipAuthority();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000064B0 File Offset: 0x000046B0
		protected override void __initializeVariables()
		{
			base.__initializeVariables();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000639A File Offset: 0x0000459A
		protected override void __initializeRpcs()
		{
			base.__initializeRpcs();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000064C6 File Offset: 0x000046C6
		protected internal override string __getTypeName()
		{
			return "NetworkRigidbody2D";
		}

		// Token: 0x04000088 RID: 136
		private bool m_IsServerAuthoritative;

		// Token: 0x04000089 RID: 137
		private Rigidbody2D m_Rigidbody;

		// Token: 0x0400008A RID: 138
		private NetworkTransform m_NetworkTransform;

		// Token: 0x0400008B RID: 139
		private RigidbodyInterpolation2D m_OriginalInterpolation;

		// Token: 0x0400008C RID: 140
		private bool m_IsAuthority;
	}
}
