using System;
using UnityEngine;

namespace Unity.Netcode.Components
{
	// Token: 0x0200001E RID: 30
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(NetworkTransform))]
	[AddComponentMenu("Netcode/Network Rigidbody")]
	public class NetworkRigidbody : NetworkBehaviour
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x00006263 File Offset: 0x00004463
		private void Awake()
		{
			this.m_NetworkTransform = base.GetComponent<NetworkTransform>();
			this.m_IsServerAuthoritative = this.m_NetworkTransform.IsServerAuthoritative();
			this.SetupRigidBody();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00006288 File Offset: 0x00004488
		private void SetupRigidBody()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_OriginalInterpolation = this.m_Rigidbody.interpolation;
			this.m_Rigidbody.interpolation = (this.m_IsAuthority ? this.m_OriginalInterpolation : (this.m_NetworkTransform.Interpolate ? RigidbodyInterpolation.None : this.m_OriginalInterpolation));
			this.m_Rigidbody.isKinematic = true;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000062EF File Offset: 0x000044EF
		public override void OnGainedOwnership()
		{
			this.UpdateOwnershipAuthority();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000062EF File Offset: 0x000044EF
		public override void OnLostOwnership()
		{
			this.UpdateOwnershipAuthority();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000062F8 File Offset: 0x000044F8
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
			this.m_Rigidbody.isKinematic = !this.m_IsAuthority;
			this.m_Rigidbody.interpolation = (this.m_IsAuthority ? this.m_OriginalInterpolation : RigidbodyInterpolation.None);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000062EF File Offset: 0x000044EF
		public override void OnNetworkSpawn()
		{
			this.UpdateOwnershipAuthority();
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000635C File Offset: 0x0000455C
		public override void OnNetworkDespawn()
		{
			this.m_Rigidbody.interpolation = this.m_OriginalInterpolation;
			this.m_Rigidbody.isKinematic = true;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00006384 File Offset: 0x00004584
		protected override void __initializeVariables()
		{
			base.__initializeVariables();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000639A File Offset: 0x0000459A
		protected override void __initializeRpcs()
		{
			base.__initializeRpcs();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000063A4 File Offset: 0x000045A4
		protected internal override string __getTypeName()
		{
			return "NetworkRigidbody";
		}

		// Token: 0x04000083 RID: 131
		private bool m_IsServerAuthoritative;

		// Token: 0x04000084 RID: 132
		private Rigidbody m_Rigidbody;

		// Token: 0x04000085 RID: 133
		private NetworkTransform m_NetworkTransform;

		// Token: 0x04000086 RID: 134
		private RigidbodyInterpolation m_OriginalInterpolation;

		// Token: 0x04000087 RID: 135
		private bool m_IsAuthority;
	}
}
