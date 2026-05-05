using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UnityEngine.EventSystems
{
	// Token: 0x02000072 RID: 114
	[AddComponentMenu("Event/Physics Raycaster")]
	[RequireComponent(typeof(Camera))]
	public class PhysicsRaycaster : BaseRaycaster
	{
		// Token: 0x0600067D RID: 1661 RVA: 0x0001B96D File Offset: 0x00019B6D
		protected PhysicsRaycaster()
		{
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x0001B981 File Offset: 0x00019B81
		public override Camera eventCamera
		{
			get
			{
				if (this.m_EventCamera == null)
				{
					this.m_EventCamera = base.GetComponent<Camera>();
				}
				if (this.m_EventCamera == null)
				{
					return Camera.main;
				}
				return this.m_EventCamera;
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x0001B9B7 File Offset: 0x00019BB7
		public virtual int depth
		{
			get
			{
				if (!(this.eventCamera != null))
				{
					return 16777215;
				}
				return (int)this.eventCamera.depth;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x0001B9D9 File Offset: 0x00019BD9
		public int finalEventMask
		{
			get
			{
				if (!(this.eventCamera != null))
				{
					return -1;
				}
				return this.eventCamera.cullingMask & this.m_EventMask;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x0001BA02 File Offset: 0x00019C02
		// (set) Token: 0x06000682 RID: 1666 RVA: 0x0001BA0A File Offset: 0x00019C0A
		public LayerMask eventMask
		{
			get
			{
				return this.m_EventMask;
			}
			set
			{
				this.m_EventMask = value;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x0001BA13 File Offset: 0x00019C13
		// (set) Token: 0x06000684 RID: 1668 RVA: 0x0001BA1B File Offset: 0x00019C1B
		public int maxRayIntersections
		{
			get
			{
				return this.m_MaxRayIntersections;
			}
			set
			{
				this.m_MaxRayIntersections = value;
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0001BA24 File Offset: 0x00019C24
		protected bool ComputeRayAndDistance(PointerEventData eventData, ref Ray ray, ref int eventDisplayIndex, ref float distanceToClipPlane)
		{
			if (this.eventCamera == null)
			{
				return false;
			}
			Vector3 vector = MultipleDisplayUtilities.RelativeMouseAtScaled(eventData.position, eventData.displayIndex);
			if (vector != Vector3.zero)
			{
				eventDisplayIndex = (int)vector.z;
				if (eventDisplayIndex != this.eventCamera.targetDisplay)
				{
					return false;
				}
			}
			else
			{
				vector = eventData.position;
			}
			if (!this.eventCamera.pixelRect.Contains(vector))
			{
				return false;
			}
			ray = this.eventCamera.ScreenPointToRay(vector);
			float z = ray.direction.z;
			distanceToClipPlane = (Mathf.Approximately(0f, z) ? float.PositiveInfinity : Mathf.Abs((this.eventCamera.farClipPlane - this.eventCamera.nearClipPlane) / z));
			return true;
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0001BAF4 File Offset: 0x00019CF4
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			Ray r = default(Ray);
			int displayIndex = 0;
			float f = 0f;
			if (!this.ComputeRayAndDistance(eventData, ref r, ref displayIndex, ref f))
			{
				return;
			}
			int num;
			if (this.m_MaxRayIntersections == 0)
			{
				if (ReflectionMethodsCache.Singleton.raycast3DAll == null)
				{
					return;
				}
				this.m_Hits = ReflectionMethodsCache.Singleton.raycast3DAll(r, f, this.finalEventMask);
				num = this.m_Hits.Length;
			}
			else
			{
				if (ReflectionMethodsCache.Singleton.getRaycastNonAlloc == null)
				{
					return;
				}
				if (this.m_LastMaxRayIntersections != this.m_MaxRayIntersections)
				{
					this.m_Hits = new RaycastHit[this.m_MaxRayIntersections];
					this.m_LastMaxRayIntersections = this.m_MaxRayIntersections;
				}
				num = ReflectionMethodsCache.Singleton.getRaycastNonAlloc(r, this.m_Hits, f, this.finalEventMask);
			}
			if (num != 0)
			{
				if (num > 1)
				{
					Array.Sort<RaycastHit>(this.m_Hits, 0, num, PhysicsRaycaster.RaycastHitComparer.instance);
				}
				int i = 0;
				int num2 = num;
				while (i < num2)
				{
					RaycastResult item = new RaycastResult
					{
						gameObject = this.m_Hits[i].collider.gameObject,
						module = this,
						distance = this.m_Hits[i].distance,
						worldPosition = this.m_Hits[i].point,
						worldNormal = this.m_Hits[i].normal,
						screenPosition = eventData.position,
						displayIndex = displayIndex,
						index = (float)resultAppendList.Count,
						sortingLayer = 0,
						sortingOrder = 0
					};
					resultAppendList.Add(item);
					i++;
				}
			}
		}

		// Token: 0x04000232 RID: 562
		protected const int kNoEventMaskSet = -1;

		// Token: 0x04000233 RID: 563
		protected Camera m_EventCamera;

		// Token: 0x04000234 RID: 564
		[SerializeField]
		protected LayerMask m_EventMask = -1;

		// Token: 0x04000235 RID: 565
		[SerializeField]
		protected int m_MaxRayIntersections;

		// Token: 0x04000236 RID: 566
		protected int m_LastMaxRayIntersections;

		// Token: 0x04000237 RID: 567
		private RaycastHit[] m_Hits;

		// Token: 0x020000CB RID: 203
		private class RaycastHitComparer : IComparer<RaycastHit>
		{
			// Token: 0x0600076A RID: 1898 RVA: 0x0001CE1C File Offset: 0x0001B01C
			public int Compare(RaycastHit x, RaycastHit y)
			{
				return x.distance.CompareTo(y.distance);
			}

			// Token: 0x0400035D RID: 861
			public static PhysicsRaycaster.RaycastHitComparer instance = new PhysicsRaycaster.RaycastHitComparer();
		}
	}
}
