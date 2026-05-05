using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x020003A3 RID: 931
	public static class vLookTargetHelper
	{
		// Token: 0x060012B1 RID: 4785 RVA: 0x000629DC File Offset: 0x00060BDC
		private static vLookTargetHelper.LookPoints GetLookPoints(vLookTarget lookTarget)
		{
			vLookTargetHelper.LookPoints lookPoints = default(vLookTargetHelper.LookPoints);
			Vector3 centerArea = lookTarget.centerArea;
			Vector3 sizeArea = lookTarget.sizeArea;
			Transform transform = lookTarget.transform;
			lookPoints.frontTopLeft = new Vector3(centerArea.x - sizeArea.x, centerArea.y + sizeArea.y, centerArea.z - sizeArea.z);
			lookPoints.frontTopRight = new Vector3(centerArea.x + sizeArea.x, centerArea.y + sizeArea.y, centerArea.z - sizeArea.z);
			lookPoints.frontBottomLeft = new Vector3(centerArea.x - sizeArea.x, centerArea.y - sizeArea.y, centerArea.z - sizeArea.z);
			lookPoints.frontBottomRight = new Vector3(centerArea.x + sizeArea.x, centerArea.y - sizeArea.y, centerArea.z - sizeArea.z);
			lookPoints.backTopLeft = new Vector3(centerArea.x - sizeArea.x, centerArea.y + sizeArea.y, centerArea.z + sizeArea.z);
			lookPoints.backTopRight = new Vector3(centerArea.x + sizeArea.x, centerArea.y + sizeArea.y, centerArea.z + sizeArea.z);
			lookPoints.backBottomLeft = new Vector3(centerArea.x - sizeArea.x, centerArea.y - sizeArea.y, centerArea.z + sizeArea.z);
			lookPoints.backBottomRight = new Vector3(centerArea.x + sizeArea.x, centerArea.y - sizeArea.y, centerArea.z + sizeArea.z);
			lookPoints.frontTopLeft = transform.TransformPoint(lookPoints.frontTopLeft);
			lookPoints.frontTopRight = transform.TransformPoint(lookPoints.frontTopRight);
			lookPoints.frontBottomLeft = transform.TransformPoint(lookPoints.frontBottomLeft);
			lookPoints.frontBottomRight = transform.TransformPoint(lookPoints.frontBottomRight);
			lookPoints.backTopLeft = transform.TransformPoint(lookPoints.backTopLeft);
			lookPoints.backTopRight = transform.TransformPoint(lookPoints.backTopRight);
			lookPoints.backBottomLeft = transform.TransformPoint(lookPoints.backBottomLeft);
			lookPoints.backBottomRight = transform.TransformPoint(lookPoints.backBottomRight);
			return lookPoints;
		}

		// Token: 0x060012B2 RID: 4786 RVA: 0x00062C38 File Offset: 0x00060E38
		public static bool IsVisible(this vLookTarget lookTarget, Vector3 from, LayerMask layerMask, bool debug = false)
		{
			if (lookTarget.HideObject)
			{
				return false;
			}
			if (lookTarget.visibleCheckType == vLookTarget.VisibleCheckType.None)
			{
				return !lookTarget.useLimitToDetect || Vector3.Distance(from, lookTarget.transform.position) <= lookTarget.minDistanceToDetect;
			}
			if (lookTarget.visibleCheckType == vLookTarget.VisibleCheckType.SingleCast)
			{
				return (!lookTarget.useLimitToDetect || Vector3.Distance(from, lookTarget.centerArea) <= lookTarget.minDistanceToDetect) && vLookTargetHelper.CastPoint(from, lookTarget.transform.TransformPoint(lookTarget.centerArea), lookTarget.transform, layerMask, debug);
			}
			if (lookTarget.visibleCheckType == vLookTarget.VisibleCheckType.BoxCast)
			{
				if (lookTarget.useLimitToDetect && Vector3.Distance(from, lookTarget.transform.position) > lookTarget.minDistanceToDetect)
				{
					return false;
				}
				vLookTargetHelper.LookPoints lookPoints = vLookTargetHelper.GetLookPoints(lookTarget);
				if (vLookTargetHelper.CastPoint(from, lookPoints.frontTopLeft, lookTarget.transform, layerMask, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.frontTopRight, lookTarget.transform, layerMask, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.frontBottomLeft, lookTarget.transform, layerMask, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.frontBottomRight, lookTarget.transform, layerMask, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.backTopLeft, lookTarget.transform, layerMask, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.backTopRight, lookTarget.transform, layerMask, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.backBottomLeft, lookTarget.transform, layerMask, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.backBottomRight, lookTarget.transform, layerMask, debug))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x00062DC0 File Offset: 0x00060FC0
		public static bool IsVisible(this vLookTarget lookTarget, Vector3 from, bool debug = false)
		{
			if (lookTarget.HideObject)
			{
				return false;
			}
			vLookTargetHelper.LookPoints lookPoints = vLookTargetHelper.GetLookPoints(lookTarget);
			if (lookTarget.visibleCheckType == vLookTarget.VisibleCheckType.None)
			{
				return true;
			}
			if (lookTarget.visibleCheckType == vLookTarget.VisibleCheckType.SingleCast)
			{
				return vLookTargetHelper.CastPoint(from, lookTarget.transform.TransformPoint(lookTarget.centerArea), lookTarget.transform, debug);
			}
			if (lookTarget.visibleCheckType == vLookTarget.VisibleCheckType.BoxCast)
			{
				if (vLookTargetHelper.CastPoint(from, lookPoints.frontTopLeft, lookTarget.transform, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.frontTopRight, lookTarget.transform, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.frontBottomLeft, lookTarget.transform, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.frontBottomRight, lookTarget.transform, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.backTopLeft, lookTarget.transform, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.backTopRight, lookTarget.transform, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.backBottomLeft, lookTarget.transform, debug))
				{
					return true;
				}
				if (vLookTargetHelper.CastPoint(from, lookPoints.backBottomRight, lookTarget.transform, debug))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x00062EDC File Offset: 0x000610DC
		private static bool CastPoint(Vector3 from, Vector3 point, Transform lookTarget, LayerMask layerMask, bool debug = false)
		{
			RaycastHit raycastHit;
			if (!Physics.Linecast(from, point, out raycastHit, layerMask))
			{
				if (debug)
				{
					Debug.DrawLine(from, point, Color.green);
				}
				return true;
			}
			if (raycastHit.transform != lookTarget.transform)
			{
				if (debug)
				{
					Debug.DrawLine(from, raycastHit.point, Color.red);
				}
				return false;
			}
			if (debug)
			{
				Debug.DrawLine(from, raycastHit.point, Color.green);
			}
			return true;
		}

		// Token: 0x060012B5 RID: 4789 RVA: 0x00062F50 File Offset: 0x00061150
		private static bool CastPoint(Vector3 from, Vector3 point, Transform lookTarget, bool debug = false)
		{
			RaycastHit raycastHit;
			if (!Physics.Linecast(from, point, out raycastHit))
			{
				if (debug)
				{
					Debug.DrawLine(from, point, Color.green);
				}
				return true;
			}
			if (raycastHit.transform != lookTarget.transform)
			{
				if (debug)
				{
					Debug.DrawLine(from, raycastHit.point, Color.red);
				}
				return false;
			}
			if (debug)
			{
				Debug.DrawLine(from, raycastHit.point, Color.green);
			}
			return true;
		}

		// Token: 0x020003A4 RID: 932
		private struct LookPoints
		{
			// Token: 0x04001877 RID: 6263
			public Vector3 frontTopLeft;

			// Token: 0x04001878 RID: 6264
			public Vector3 frontTopRight;

			// Token: 0x04001879 RID: 6265
			public Vector3 frontBottomLeft;

			// Token: 0x0400187A RID: 6266
			public Vector3 frontBottomRight;

			// Token: 0x0400187B RID: 6267
			public Vector3 backTopLeft;

			// Token: 0x0400187C RID: 6268
			public Vector3 backTopRight;

			// Token: 0x0400187D RID: 6269
			public Vector3 backBottomLeft;

			// Token: 0x0400187E RID: 6270
			public Vector3 backBottomRight;
		}
	}
}
