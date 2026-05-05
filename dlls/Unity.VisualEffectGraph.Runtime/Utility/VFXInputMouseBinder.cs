using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200002E RID: 46
	[AddComponentMenu("VFX/Property Binders/Input Mouse Binder")]
	[VFXBinder("Input/Mouse")]
	internal class VFXInputMouseBinder : VFXBinderBase
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000108 RID: 264 RVA: 0x000078C9 File Offset: 0x00005AC9
		// (set) Token: 0x06000109 RID: 265 RVA: 0x000078D6 File Offset: 0x00005AD6
		public string MouseLeftClickProperty
		{
			get
			{
				return (string)this.m_MouseLeftClickProperty;
			}
			set
			{
				this.m_MouseLeftClickProperty = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600010A RID: 266 RVA: 0x000078E4 File Offset: 0x00005AE4
		// (set) Token: 0x0600010B RID: 267 RVA: 0x000078F1 File Offset: 0x00005AF1
		public string MouseRightClickProperty
		{
			get
			{
				return (string)this.m_MouseRightClickProperty;
			}
			set
			{
				this.m_MouseRightClickProperty = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600010C RID: 268 RVA: 0x000078FF File Offset: 0x00005AFF
		// (set) Token: 0x0600010D RID: 269 RVA: 0x0000790C File Offset: 0x00005B0C
		public string PositionProperty
		{
			get
			{
				return (string)this.m_PositionProperty;
			}
			set
			{
				this.m_PositionProperty = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600010E RID: 270 RVA: 0x0000791A File Offset: 0x00005B1A
		// (set) Token: 0x0600010F RID: 271 RVA: 0x00007927 File Offset: 0x00005B27
		public string VelocityProperty
		{
			get
			{
				return (string)this.m_VelocityProperty;
			}
			set
			{
				this.m_VelocityProperty = value;
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00007938 File Offset: 0x00005B38
		public override bool IsValid(VisualEffect component)
		{
			return component.HasVector3(this.m_PositionProperty) && (!this.CheckLeftClick || component.HasBool(this.m_MouseLeftClickProperty)) && (!this.CheckRightClick || component.HasBool(this.m_MouseRightClickProperty)) && (!this.SetVelocity || component.HasVector3(this.m_VelocityProperty));
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000079B4 File Offset: 0x00005BB4
		public override void UpdateBinding(VisualEffect component)
		{
			Vector3 vector = Vector3.zero;
			if (this.CheckLeftClick)
			{
				component.SetBool(this.MouseLeftClickProperty, this.IsLeftClickPressed());
			}
			if (this.CheckRightClick)
			{
				component.SetBool(this.MouseRightClickProperty, this.IsRightClickPressed());
			}
			if (this.Target != null)
			{
				Vector3 position = this.GetMousePosition();
				position.z = this.Distance;
				vector = this.Target.ScreenToWorldPoint(position);
			}
			else
			{
				vector = this.GetMousePosition();
			}
			component.SetVector3(this.m_PositionProperty, vector);
			if (this.SetVelocity)
			{
				component.SetVector3(this.m_VelocityProperty, (vector - this.m_PreviousPosition) / Time.deltaTime);
			}
			this.m_PreviousPosition = vector;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00007A85 File Offset: 0x00005C85
		private bool IsRightClickPressed()
		{
			return Input.GetMouseButton(1);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00007A8D File Offset: 0x00005C8D
		private bool IsLeftClickPressed()
		{
			return Input.GetMouseButton(0);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00007A95 File Offset: 0x00005C95
		private Vector2 GetMousePosition()
		{
			return Input.mousePosition;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00007AA1 File Offset: 0x00005CA1
		public override string ToString()
		{
			return string.Format("Mouse: '{0}' -> {1}", this.m_PositionProperty, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x040000C0 RID: 192
		[VFXPropertyBinding(new string[]
		{
			"System.Boolean"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_MouseLeftClickParameter")]
		protected ExposedProperty m_MouseLeftClickProperty = "LeftClick";

		// Token: 0x040000C1 RID: 193
		[VFXPropertyBinding(new string[]
		{
			"System.Boolean"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_MouseRightClickParameter")]
		protected ExposedProperty m_MouseRightClickProperty = "RightClick";

		// Token: 0x040000C2 RID: 194
		[VFXPropertyBinding(new string[]
		{
			"UnityEditor.VFX.Position",
			"UnityEngine.Vector3"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_PositionParameter")]
		protected ExposedProperty m_PositionProperty = "Position";

		// Token: 0x040000C3 RID: 195
		[VFXPropertyBinding(new string[]
		{
			"UnityEngine.Vector3"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_VelocityParameter")]
		protected ExposedProperty m_VelocityProperty = "Velocity";

		// Token: 0x040000C4 RID: 196
		public Camera Target;

		// Token: 0x040000C5 RID: 197
		public float Distance = 10f;

		// Token: 0x040000C6 RID: 198
		public bool SetVelocity;

		// Token: 0x040000C7 RID: 199
		public bool CheckLeftClick = true;

		// Token: 0x040000C8 RID: 200
		public bool CheckRightClick;

		// Token: 0x040000C9 RID: 201
		private Vector3 m_PreviousPosition;
	}
}
