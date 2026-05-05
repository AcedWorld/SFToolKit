using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x02000373 RID: 883
	[RequireComponent(typeof(BoxCollider))]
	[vClassHeader("Simple Door", true, "icon_v2", false, "", openClose = false)]
	public class vSimpleDoor : vMonoBehaviour
	{
		// Token: 0x060011E1 RID: 4577 RVA: 0x0005F6D0 File Offset: 0x0005D8D0
		protected virtual void Start()
		{
			if (!this.pivot)
			{
				base.enabled = false;
			}
			if (this.startOpened)
			{
				this.state = vSimpleDoor.DoorState.Closed;
				this.Open();
				return;
			}
			this.onClose.Invoke();
		}

		// Token: 0x060011E2 RID: 4578 RVA: 0x0005F708 File Offset: 0x0005D908
		protected virtual void OnDrawGizmos()
		{
			if (this.pivot)
			{
				Gizmos.DrawSphere(base.transform.position, 0.1f);
				Gizmos.DrawLine(base.transform.position, this.pivot.position);
				Gizmos.DrawSphere(this.pivot.position, 0.1f);
			}
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x0005F767 File Offset: 0x0005D967
		public virtual void SetAutoOpen(bool value)
		{
			this.autoOpen = value;
		}

		// Token: 0x060011E4 RID: 4580 RVA: 0x0005F770 File Offset: 0x0005D970
		public virtual void SetAutoClose(bool value)
		{
			this.autoClose = value;
		}

		// Token: 0x060011E5 RID: 4581 RVA: 0x0005F779 File Offset: 0x0005D979
		public virtual void Open(bool invert)
		{
			this._invertOpenSide = invert;
			this.Open();
		}

		// Token: 0x060011E6 RID: 4582 RVA: 0x0005F788 File Offset: 0x0005D988
		public virtual void Open()
		{
			if (this.state != vSimpleDoor.DoorState.Opening && this.state != vSimpleDoor.DoorState.Opening)
			{
				this.targetDoorAngle = (this.invertOpenSide ? (-this.angleOfOpen) : this.angleOfOpen);
				base.StartCoroutine(this.HandleDoor());
			}
		}

		// Token: 0x060011E7 RID: 4583 RVA: 0x0005F7C6 File Offset: 0x0005D9C6
		public virtual void Close()
		{
			if (this.state != vSimpleDoor.DoorState.Closing && this.state != vSimpleDoor.DoorState.Closed)
			{
				this.targetDoorAngle = 0f;
				base.StartCoroutine(this.HandleDoor());
			}
		}

		// Token: 0x060011E8 RID: 4584 RVA: 0x0005F7F1 File Offset: 0x0005D9F1
		public virtual void ToggleOpenClose()
		{
			if (this.state == vSimpleDoor.DoorState.Closed && this.state != vSimpleDoor.DoorState.Opening)
			{
				this.Open();
				return;
			}
			this.Close();
		}

		// Token: 0x060011E9 RID: 4585 RVA: 0x0005F811 File Offset: 0x0005DA11
		protected virtual IEnumerator HandleDoor()
		{
			bool open = Mathf.Abs(this.targetDoorAngle).Equals(this.angleOfOpen);
			this.state = (open ? vSimpleDoor.DoorState.Opening : vSimpleDoor.DoorState.Closing);
			vSimpleDoor.DoorState doorState = this.state;
			if (doorState != vSimpleDoor.DoorState.Closing)
			{
				if (doorState == vSimpleDoor.DoorState.Opening)
				{
					this.onStartOpen.Invoke();
					if (this.invertOpenSide)
					{
						this.onStartOpenLeft.Invoke();
					}
					else
					{
						this.onStartOpenRight.Invoke();
					}
				}
			}
			else
			{
				this.onStartClose.Invoke();
			}
			this.stopDoor = true;
			yield return new WaitForEndOfFrame();
			this.stopDoor = false;
			while (!this.stopDoor)
			{
				this.currentAngle.y = Mathf.MoveTowardsAngle(this.currentAngle.y, this.targetDoorAngle, open ? this.openSpeed : this.closeSpeed);
				if (Mathf.Abs(this.currentAngle.y - this.targetDoorAngle) < 0.01f)
				{
					this.currentAngle.y = this.targetDoorAngle;
					this.pivot.localEulerAngles = this.currentAngle;
					break;
				}
				this.pivot.localEulerAngles = this.currentAngle;
				yield return null;
			}
			if (!this.stopDoor)
			{
				this.state = (open ? vSimpleDoor.DoorState.Opened : vSimpleDoor.DoorState.Closed);
				if (open && this.autoClose && !this.colliderInTrigger)
				{
					this.CloseWithDelay();
				}
				doorState = this.state;
				if (doorState != vSimpleDoor.DoorState.Closed)
				{
					if (doorState == vSimpleDoor.DoorState.Opened)
					{
						this.onOpen.Invoke();
						if (this.invertOpenSide)
						{
							this.onOpenLeft.Invoke();
						}
						else
						{
							this.onOpenRight.Invoke();
						}
					}
				}
				else
				{
					this.onClose.Invoke();
				}
			}
			yield break;
		}

		// Token: 0x060011EA RID: 4586 RVA: 0x0005F820 File Offset: 0x0005DA20
		protected virtual void OnTriggerStay(Collider other)
		{
			if (this.tagsToOpen.Contains(other.tag) && this.autoOpen && (this.state == vSimpleDoor.DoorState.Closing || this.state == vSimpleDoor.DoorState.Closed))
			{
				if (base.transform.InverseTransformPoint(other.transform.position).z > 0f)
				{
					this._invertOpenSide = false;
				}
				else
				{
					this._invertOpenSide = true;
				}
				this.angle = Mathf.Abs(Vector3.Angle(this._invertOpenSide ? base.transform.forward : (-base.transform.forward), other.transform.forward));
				if (this.angle < this.minAngleToOpen)
				{
					if (!this.colliderInTrigger)
					{
						this.colliderInTrigger = other;
					}
					this.Open();
				}
			}
		}

		// Token: 0x060011EB RID: 4587 RVA: 0x0005F8FC File Offset: 0x0005DAFC
		protected virtual void OnTriggerExit(Collider other)
		{
			if (this.autoClose && this.tagsToOpen.Contains(other.tag) && ((this.colliderInTrigger != null && this.colliderInTrigger.gameObject.Equals(other.gameObject)) || this.colliderInTrigger == null))
			{
				this.colliderInTrigger = null;
				if (!this.closeOnlyWhenOpened || this.state == vSimpleDoor.DoorState.Opened)
				{
					this.CloseWithDelay();
				}
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060011EC RID: 4588 RVA: 0x0005F976 File Offset: 0x0005DB76
		protected virtual bool invertOpenSide
		{
			get
			{
				return this._invertOpenSide && this.openBothSide;
			}
		}

		// Token: 0x060011ED RID: 4589 RVA: 0x0005F988 File Offset: 0x0005DB88
		protected virtual void CloseWithDelay()
		{
			base.CancelInvoke("Close");
			base.Invoke("Close", this.timeToClose);
		}

		// Token: 0x040017C5 RID: 6085
		[vReadOnly(true)]
		public vSimpleDoor.DoorState state;

		// Token: 0x040017C6 RID: 6086
		public Transform pivot;

		// Token: 0x040017C7 RID: 6087
		public bool startOpened;

		// Token: 0x040017C8 RID: 6088
		public bool autoOpen = true;

		// Token: 0x040017C9 RID: 6089
		public bool autoClose = true;

		// Token: 0x040017CA RID: 6090
		[vHideInInspector("autoClose", false)]
		[Tooltip("Close the door only if door is completely opened\n**The TimeToClose will be used yet")]
		public bool closeOnlyWhenOpened;

		// Token: 0x040017CB RID: 6091
		[Tooltip("Target angle of Opened door")]
		public float angleOfOpen = 90f;

		// Token: 0x040017CC RID: 6092
		[vHideInInspector("autoOpen", false)]
		[Tooltip("Min angle between character forward and door that  can auto open")]
		public float minAngleToOpen = 45f;

		// Token: 0x040017CD RID: 6093
		[Tooltip("Door can open to left side and to right side, if false, door will open just in to right side")]
		public bool openBothSide = true;

		// Token: 0x040017CE RID: 6094
		public float closeSpeed = 2f;

		// Token: 0x040017CF RID: 6095
		public float openSpeed = 2f;

		// Token: 0x040017D0 RID: 6096
		[vHideInInspector("autoClose", false)]
		[Tooltip("Time to auto close door after Opened")]
		public float timeToClose = 1f;

		// Token: 0x040017D1 RID: 6097
		[Tooltip("Used when autoOpen or autoClose is checked")]
		public vTagMask tagsToOpen = new List<string>
		{
			"Player"
		};

		// Token: 0x040017D2 RID: 6098
		private Vector3 currentAngle;

		// Token: 0x040017D3 RID: 6099
		private float angle;

		// Token: 0x040017D4 RID: 6100
		private bool _invertOpenSide;

		// Token: 0x040017D5 RID: 6101
		private Collider colliderInTrigger;

		// Token: 0x040017D6 RID: 6102
		public UnityEvent onStartOpen;

		// Token: 0x040017D7 RID: 6103
		public UnityEvent onStartOpenRight;

		// Token: 0x040017D8 RID: 6104
		public UnityEvent onStartOpenLeft;

		// Token: 0x040017D9 RID: 6105
		public UnityEvent onStartClose;

		// Token: 0x040017DA RID: 6106
		public UnityEvent onOpen;

		// Token: 0x040017DB RID: 6107
		public UnityEvent onOpenRight;

		// Token: 0x040017DC RID: 6108
		public UnityEvent onOpenLeft;

		// Token: 0x040017DD RID: 6109
		public UnityEvent onClose;

		// Token: 0x040017DE RID: 6110
		private float targetDoorAngle;

		// Token: 0x040017DF RID: 6111
		private bool stopDoor;

		// Token: 0x02000374 RID: 884
		public enum DoorState
		{
			// Token: 0x040017E1 RID: 6113
			Closed,
			// Token: 0x040017E2 RID: 6114
			Opened,
			// Token: 0x040017E3 RID: 6115
			Closing,
			// Token: 0x040017E4 RID: 6116
			Opening
		}
	}
}
