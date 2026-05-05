using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200002F RID: 47
	[AddComponentMenu("VFX/Property Binders/Input Touch Binder")]
	[VFXBinder("Input/Touch")]
	internal class VFXInputTouchBinder : VFXBinderBase
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00007B39 File Offset: 0x00005D39
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00007B46 File Offset: 0x00005D46
		public string TouchEnabledProperty
		{
			get
			{
				return (string)this.m_TouchEnabledProperty;
			}
			set
			{
				this.m_TouchEnabledProperty = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00007B54 File Offset: 0x00005D54
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00007B61 File Offset: 0x00005D61
		public string Parameter
		{
			get
			{
				return (string)this.m_Parameter;
			}
			set
			{
				this.m_Parameter = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00007B6F File Offset: 0x00005D6F
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00007B7C File Offset: 0x00005D7C
		public string VelocityParameter
		{
			get
			{
				return (string)this.m_VelocityParameter;
			}
			set
			{
				this.m_VelocityParameter = value;
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00007B8C File Offset: 0x00005D8C
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && component.HasVector3(this.m_Parameter) && component.HasBool(this.m_TouchEnabledProperty) && (!this.SetVelocity || component.HasVector3(this.m_VelocityParameter));
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00007BEC File Offset: 0x00005DEC
		public override void UpdateBinding(VisualEffect component)
		{
			Vector3 vector = Vector3.zero;
			bool previousTouch;
			if (this.GetTouchCount() > this.TouchIndex)
			{
				Vector2 touchPosition = this.GetTouchPosition(this.TouchIndex);
				previousTouch = true;
				Vector3 position = touchPosition;
				position.z = this.Distance;
				vector = this.Target.ScreenToWorldPoint(position);
				component.SetBool(this.m_TouchEnabledProperty, true);
				component.SetVector3(this.m_Parameter, vector);
			}
			else
			{
				previousTouch = false;
				component.SetBool(this.m_TouchEnabledProperty, false);
				component.SetVector3(this.m_Parameter, Vector3.zero);
			}
			if (this.SetVelocity)
			{
				if (this.m_PreviousTouch)
				{
					component.SetVector3(this.m_VelocityParameter, (vector - this.m_PreviousPosition) / Time.deltaTime);
				}
				else
				{
					component.SetVector3(this.m_VelocityParameter, Vector3.zero);
				}
			}
			this.m_PreviousTouch = previousTouch;
			this.m_PreviousPosition = vector;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00007CEA File Offset: 0x00005EEA
		private int GetTouchCount()
		{
			return Input.touchCount;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00007CF4 File Offset: 0x00005EF4
		private Vector2 GetTouchPosition(int touchIndex)
		{
			return Input.GetTouch(this.TouchIndex).position;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00007D14 File Offset: 0x00005F14
		public override string ToString()
		{
			return string.Format("Touch #{2} : '{0}' -> {1}", this.m_Parameter, (this.Target == null) ? "(null)" : this.Target.name, this.TouchIndex);
		}

		// Token: 0x040000CA RID: 202
		[VFXPropertyBinding(new string[]
		{
			"System.Boolean"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_TouchEnabledParameter")]
		protected ExposedProperty m_TouchEnabledProperty = "TouchEnabled";

		// Token: 0x040000CB RID: 203
		[VFXPropertyBinding(new string[]
		{
			"UnityEditor.VFX.Position",
			"UnityEngine.Vector3"
		})]
		[SerializeField]
		protected ExposedProperty m_Parameter = "Position";

		// Token: 0x040000CC RID: 204
		[VFXPropertyBinding(new string[]
		{
			"UnityEngine.Vector3"
		})]
		[SerializeField]
		protected ExposedProperty m_VelocityParameter = "Velocity";

		// Token: 0x040000CD RID: 205
		public int TouchIndex;

		// Token: 0x040000CE RID: 206
		public Camera Target;

		// Token: 0x040000CF RID: 207
		public float Distance = 10f;

		// Token: 0x040000D0 RID: 208
		public bool SetVelocity;

		// Token: 0x040000D1 RID: 209
		private Vector3 m_PreviousPosition;

		// Token: 0x040000D2 RID: 210
		private bool m_PreviousTouch;
	}
}
