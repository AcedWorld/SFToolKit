using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000230 RID: 560
	public class ObjectSpin : MonoBehaviour
	{
		// Token: 0x060008BF RID: 2239 RVA: 0x0003D50C File Offset: 0x0003B70C
		private void Awake()
		{
			this.m_transform = base.transform;
			this.m_initial_Rotation = this.m_transform.rotation.eulerAngles;
			this.m_initial_Position = this.m_transform.position;
			Light component = base.GetComponent<Light>();
			this.m_lightColor = ((component != null) ? component.color : Color.black);
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0003D578 File Offset: 0x0003B778
		private void Update()
		{
			if (this.Motion == ObjectSpin.MotionType.Rotation)
			{
				this.m_transform.Rotate(0f, this.SpinSpeed * Time.deltaTime, 0f);
				return;
			}
			if (this.Motion == ObjectSpin.MotionType.BackAndForth)
			{
				this.m_time += this.SpinSpeed * Time.deltaTime;
				this.m_transform.rotation = Quaternion.Euler(this.m_initial_Rotation.x, Mathf.Sin(this.m_time) * (float)this.RotationRange + this.m_initial_Rotation.y, this.m_initial_Rotation.z);
				return;
			}
			this.m_time += this.SpinSpeed * Time.deltaTime;
			float x = 15f * Mathf.Cos(this.m_time * 0.95f);
			float z = 10f;
			float y = 0f;
			this.m_transform.position = this.m_initial_Position + new Vector3(x, y, z);
			this.m_prevPOS = this.m_transform.position;
			this.frames++;
		}

		// Token: 0x04000F13 RID: 3859
		public float SpinSpeed = 5f;

		// Token: 0x04000F14 RID: 3860
		public int RotationRange = 15;

		// Token: 0x04000F15 RID: 3861
		private Transform m_transform;

		// Token: 0x04000F16 RID: 3862
		private float m_time;

		// Token: 0x04000F17 RID: 3863
		private Vector3 m_prevPOS;

		// Token: 0x04000F18 RID: 3864
		private Vector3 m_initial_Rotation;

		// Token: 0x04000F19 RID: 3865
		private Vector3 m_initial_Position;

		// Token: 0x04000F1A RID: 3866
		private Color32 m_lightColor;

		// Token: 0x04000F1B RID: 3867
		private int frames;

		// Token: 0x04000F1C RID: 3868
		public ObjectSpin.MotionType Motion;

		// Token: 0x02000231 RID: 561
		public enum MotionType
		{
			// Token: 0x04000F1E RID: 3870
			Rotation,
			// Token: 0x04000F1F RID: 3871
			BackAndForth,
			// Token: 0x04000F20 RID: 3872
			Translation
		}
	}
}
