using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x0200005A RID: 90
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[SaveDuringPlay]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineImpulseSourceOverview.html")]
	public class CinemachineImpulseSource : MonoBehaviour
	{
		// Token: 0x0600039B RID: 923 RVA: 0x00016803 File Offset: 0x00014A03
		private void OnValidate()
		{
			this.m_ImpulseDefinition.OnValidate();
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00016810 File Offset: 0x00014A10
		private void Reset()
		{
			this.m_ImpulseDefinition = new CinemachineImpulseDefinition
			{
				m_ImpulseChannel = 1,
				m_ImpulseShape = CinemachineImpulseDefinition.ImpulseShapes.Bump,
				m_CustomImpulseShape = new AnimationCurve(),
				m_ImpulseDuration = 0.2f,
				m_ImpulseType = CinemachineImpulseDefinition.ImpulseTypes.Uniform,
				m_DissipationDistance = 100f,
				m_DissipationRate = 0.25f,
				m_PropagationSpeed = 343f
			};
			this.m_DefaultVelocity = Vector3.down;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0001687F File Offset: 0x00014A7F
		public void GenerateImpulseAtPositionWithVelocity(Vector3 position, Vector3 velocity)
		{
			if (this.m_ImpulseDefinition != null)
			{
				this.m_ImpulseDefinition.CreateEvent(position, velocity);
			}
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00016896 File Offset: 0x00014A96
		public void GenerateImpulseWithVelocity(Vector3 velocity)
		{
			this.GenerateImpulseAtPositionWithVelocity(base.transform.position, velocity);
		}

		// Token: 0x0600039F RID: 927 RVA: 0x000168AA File Offset: 0x00014AAA
		public void GenerateImpulseWithForce(float force)
		{
			this.GenerateImpulseAtPositionWithVelocity(base.transform.position, this.m_DefaultVelocity * force);
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x000168C9 File Offset: 0x00014AC9
		public void GenerateImpulse()
		{
			this.GenerateImpulseWithVelocity(this.m_DefaultVelocity);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x000168D7 File Offset: 0x00014AD7
		public void GenerateImpulseAt(Vector3 position, Vector3 velocity)
		{
			this.GenerateImpulseAtPositionWithVelocity(position, velocity);
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x000168E1 File Offset: 0x00014AE1
		public void GenerateImpulse(Vector3 velocity)
		{
			this.GenerateImpulseWithVelocity(velocity);
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x000168EA File Offset: 0x00014AEA
		public void GenerateImpulse(float force)
		{
			this.GenerateImpulseWithForce(force);
		}

		// Token: 0x0400027B RID: 635
		public CinemachineImpulseDefinition m_ImpulseDefinition = new CinemachineImpulseDefinition();

		// Token: 0x0400027C RID: 636
		[Header("Default Invocation")]
		[Tooltip("The default direction and force of the Impulse Signal in the absense of any specified overrides.  Overrides can be specified by calling the appropriate GenerateImpulse method in the API.")]
		public Vector3 m_DefaultVelocity = Vector3.down;
	}
}
