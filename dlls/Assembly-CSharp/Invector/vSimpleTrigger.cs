using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x02000377 RID: 887
	[RequireComponent(typeof(BoxCollider))]
	[vClassHeader("SimpleTrigger", true, "icon_v2", false, "", openClose = false, useHelpBox = true, helpBoxText = "Tags and Layer To Detect : Use this to filter tags and layer that can interact with trigger, Select Nothing  to ignore filter")]
	public class vSimpleTrigger : vMonoBehaviour
	{
		// Token: 0x060011F7 RID: 4599 RVA: 0x0005FC73 File Offset: 0x0005DE73
		public void ToggleGizmos()
		{
			vSimpleTrigger.drawGizmos = !vSimpleTrigger.drawGizmos;
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x060011F8 RID: 4600 RVA: 0x0005FC84 File Offset: 0x0005DE84
		// (set) Token: 0x060011F9 RID: 4601 RVA: 0x0005FCE8 File Offset: 0x0005DEE8
		public virtual BoxCollider selfCollider
		{
			get
			{
				if (!this._selfCollider && base.transform.GetComponent<BoxCollider>() == null)
				{
					this._selfCollider = base.gameObject.AddComponent<BoxCollider>();
				}
				else if (!this._selfCollider)
				{
					this._selfCollider = base.transform.GetComponent<BoxCollider>();
				}
				return this._selfCollider;
			}
			protected set
			{
				this._selfCollider = value;
			}
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x0005FCF4 File Offset: 0x0005DEF4
		protected virtual void OnDrawGizmos()
		{
			if (!vSimpleTrigger.drawGizmos)
			{
				return;
			}
			Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.lossyScale);
			Vector3 center = this.selfCollider.center;
			Vector3 one = Vector3.one;
			one.x *= this.selfCollider.size.x;
			one.y *= this.selfCollider.size.y;
			one.z *= this.selfCollider.size.z;
			Gizmos.color = Color.green * 0.8f;
			Gizmos.DrawWireCube(center, one);
			Color color = new Color(1f, 0f, 0f, 0.2f);
			Color color2 = new Color(0f, 1f, 0f, 0.2f);
			Gizmos.color = ((this.inCollision && Application.isPlaying) ? color : color2);
			Gizmos.DrawCube(center, one);
		}

		// Token: 0x060011FB RID: 4603 RVA: 0x0005FE05 File Offset: 0x0005E005
		protected virtual void Start()
		{
			this.inCollision = false;
			this.selfCollider.isTrigger = true;
		}

		// Token: 0x060011FC RID: 4604 RVA: 0x0005FE1C File Offset: 0x0005E01C
		protected virtual void OnTriggerEnter(Collider other)
		{
			if (this.other == null && this.IsInTagMask(other.gameObject.tag) && this.IsInLayerMask(other.gameObject.layer))
			{
				this.inCollision = true;
				this.other = other;
				this.onTriggerEnter.Invoke(other);
				if (this.debugMode)
				{
					Debug.Log(other.gameObject.name + "TriggerEnter");
				}
				if (base.enabled && base.gameObject.activeInHierarchy)
				{
					base.StartCoroutine(this.TriggerStayRoutine());
				}
			}
		}

		// Token: 0x060011FD RID: 4605 RVA: 0x0005FEC0 File Offset: 0x0005E0C0
		protected virtual void OnTriggerExit(Collider other)
		{
			if (this.other != null && this.other.gameObject == other.gameObject)
			{
				this.inCollision = false;
				this.onTriggerExit.Invoke(other);
				if (this.debugMode)
				{
					Debug.Log(other.gameObject.name + "TriggerExit");
				}
				this.other = null;
			}
		}

		// Token: 0x060011FE RID: 4606 RVA: 0x0005FF2F File Offset: 0x0005E12F
		protected virtual bool IsInTagMask(string tag)
		{
			return this.tagsToDetect.Count == 0 || this.tagsToDetect.Contains(tag);
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x0005FF4C File Offset: 0x0005E14C
		protected virtual bool IsInLayerMask(int layer)
		{
			return this.layersToDetect.value == 0 || (this.layersToDetect.value & 1 << layer) > 0;
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x0005FF72 File Offset: 0x0005E172
		protected IEnumerator TriggerStayRoutine()
		{
			while (this.other != null)
			{
				if (this.other == null || !this.other.gameObject.activeInHierarchy)
				{
					this.OnTriggerExit(this.other);
					break;
				}
				this.onTriggerStay.Invoke(this.other);
				if (this.debugMode)
				{
					Debug.Log(this.other.gameObject.name + "TriggerStay");
				}
				yield return null;
			}
			yield break;
		}

		// Token: 0x040017EB RID: 6123
		public static bool drawGizmos = true;

		// Token: 0x040017EC RID: 6124
		[vButton("ToggleGizmos", "ToggleGizmos", typeof(vSimpleTrigger), false)]
		public bool useFilter = true;

		// Token: 0x040017ED RID: 6125
		public bool debugMode;

		// Token: 0x040017EE RID: 6126
		public vTagMask tagsToDetect = new List<string>
		{
			"Player"
		};

		// Token: 0x040017EF RID: 6127
		public LayerMask layersToDetect = 0;

		// Token: 0x040017F0 RID: 6128
		public vSimpleTrigger.vTriggerEvent onTriggerEnter;

		// Token: 0x040017F1 RID: 6129
		public vSimpleTrigger.vTriggerEvent onTriggerExit;

		// Token: 0x040017F2 RID: 6130
		public vSimpleTrigger.vTriggerEvent onTriggerStay;

		// Token: 0x040017F3 RID: 6131
		protected bool inCollision;

		// Token: 0x040017F4 RID: 6132
		protected bool triggerStay;

		// Token: 0x040017F5 RID: 6133
		protected Collider other;

		// Token: 0x040017F6 RID: 6134
		protected BoxCollider _selfCollider;

		// Token: 0x02000378 RID: 888
		[Serializable]
		public class vTriggerEvent : UnityEvent<Collider>
		{
		}
	}
}
