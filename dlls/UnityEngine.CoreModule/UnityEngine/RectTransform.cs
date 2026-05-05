using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200029C RID: 668
	[NativeHeader("Runtime/Transform/RectTransform.h")]
	[NativeClass("UI::RectTransform")]
	public sealed class RectTransform : Transform
	{
		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06001C34 RID: 7220 RVA: 0x0002EDEC File Offset: 0x0002CFEC
		// (remove) Token: 0x06001C35 RID: 7221 RVA: 0x0002EE20 File Offset: 0x0002D020
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event RectTransform.ReapplyDrivenProperties reapplyDrivenProperties;

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x06001C36 RID: 7222 RVA: 0x0002EE54 File Offset: 0x0002D054
		public Rect rect
		{
			get
			{
				Rect result;
				this.get_rect_Injected(out result);
				return result;
			}
		}

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x06001C37 RID: 7223 RVA: 0x0002EE6C File Offset: 0x0002D06C
		// (set) Token: 0x06001C38 RID: 7224 RVA: 0x0002EE82 File Offset: 0x0002D082
		public Vector2 anchorMin
		{
			get
			{
				Vector2 result;
				this.get_anchorMin_Injected(out result);
				return result;
			}
			set
			{
				this.set_anchorMin_Injected(ref value);
			}
		}

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06001C39 RID: 7225 RVA: 0x0002EE8C File Offset: 0x0002D08C
		// (set) Token: 0x06001C3A RID: 7226 RVA: 0x0002EEA2 File Offset: 0x0002D0A2
		public Vector2 anchorMax
		{
			get
			{
				Vector2 result;
				this.get_anchorMax_Injected(out result);
				return result;
			}
			set
			{
				this.set_anchorMax_Injected(ref value);
			}
		}

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x06001C3B RID: 7227 RVA: 0x0002EEAC File Offset: 0x0002D0AC
		// (set) Token: 0x06001C3C RID: 7228 RVA: 0x0002EEC2 File Offset: 0x0002D0C2
		public Vector2 anchoredPosition
		{
			get
			{
				Vector2 result;
				this.get_anchoredPosition_Injected(out result);
				return result;
			}
			set
			{
				this.set_anchoredPosition_Injected(ref value);
			}
		}

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x06001C3D RID: 7229 RVA: 0x0002EECC File Offset: 0x0002D0CC
		// (set) Token: 0x06001C3E RID: 7230 RVA: 0x0002EEE2 File Offset: 0x0002D0E2
		public Vector2 sizeDelta
		{
			get
			{
				Vector2 result;
				this.get_sizeDelta_Injected(out result);
				return result;
			}
			set
			{
				this.set_sizeDelta_Injected(ref value);
			}
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x06001C3F RID: 7231 RVA: 0x0002EEEC File Offset: 0x0002D0EC
		// (set) Token: 0x06001C40 RID: 7232 RVA: 0x0002EF02 File Offset: 0x0002D102
		public Vector2 pivot
		{
			get
			{
				Vector2 result;
				this.get_pivot_Injected(out result);
				return result;
			}
			set
			{
				this.set_pivot_Injected(ref value);
			}
		}

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06001C41 RID: 7233 RVA: 0x0002EF0C File Offset: 0x0002D10C
		// (set) Token: 0x06001C42 RID: 7234 RVA: 0x0002EF44 File Offset: 0x0002D144
		public Vector3 anchoredPosition3D
		{
			get
			{
				Vector2 anchoredPosition = this.anchoredPosition;
				return new Vector3(anchoredPosition.x, anchoredPosition.y, base.localPosition.z);
			}
			set
			{
				this.anchoredPosition = new Vector2(value.x, value.y);
				Vector3 localPosition = base.localPosition;
				localPosition.z = value.z;
				base.localPosition = localPosition;
			}
		}

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06001C43 RID: 7235 RVA: 0x0002EF88 File Offset: 0x0002D188
		// (set) Token: 0x06001C44 RID: 7236 RVA: 0x0002EFB8 File Offset: 0x0002D1B8
		public Vector2 offsetMin
		{
			get
			{
				return this.anchoredPosition - Vector2.Scale(this.sizeDelta, this.pivot);
			}
			set
			{
				Vector2 vector = value - (this.anchoredPosition - Vector2.Scale(this.sizeDelta, this.pivot));
				this.sizeDelta -= vector;
				this.anchoredPosition += Vector2.Scale(vector, Vector2.one - this.pivot);
			}
		}

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06001C45 RID: 7237 RVA: 0x0002F024 File Offset: 0x0002D224
		// (set) Token: 0x06001C46 RID: 7238 RVA: 0x0002F05C File Offset: 0x0002D25C
		public Vector2 offsetMax
		{
			get
			{
				return this.anchoredPosition + Vector2.Scale(this.sizeDelta, Vector2.one - this.pivot);
			}
			set
			{
				Vector2 vector = value - (this.anchoredPosition + Vector2.Scale(this.sizeDelta, Vector2.one - this.pivot));
				this.sizeDelta += vector;
				this.anchoredPosition += Vector2.Scale(vector, this.pivot);
			}
		}

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06001C47 RID: 7239
		// (set) Token: 0x06001C48 RID: 7240
		public extern Object drivenByObject { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] internal set; }

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06001C49 RID: 7241
		// (set) Token: 0x06001C4A RID: 7242
		internal extern DrivenTransformProperties drivenProperties { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06001C4B RID: 7243
		[NativeMethod("UpdateIfTransformDispatchIsDirty")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void ForceUpdateRectTransforms();

		// Token: 0x06001C4C RID: 7244 RVA: 0x0002F0C8 File Offset: 0x0002D2C8
		public void GetLocalCorners(Vector3[] fourCornersArray)
		{
			bool flag = fourCornersArray == null || fourCornersArray.Length < 4;
			if (flag)
			{
				Debug.LogError("Calling GetLocalCorners with an array that is null or has less than 4 elements.");
			}
			else
			{
				Rect rect = this.rect;
				float x = rect.x;
				float y = rect.y;
				float xMax = rect.xMax;
				float yMax = rect.yMax;
				fourCornersArray[0] = new Vector3(x, y, 0f);
				fourCornersArray[1] = new Vector3(x, yMax, 0f);
				fourCornersArray[2] = new Vector3(xMax, yMax, 0f);
				fourCornersArray[3] = new Vector3(xMax, y, 0f);
			}
		}

		// Token: 0x06001C4D RID: 7245 RVA: 0x0002F16C File Offset: 0x0002D36C
		public void GetWorldCorners(Vector3[] fourCornersArray)
		{
			bool flag = fourCornersArray == null || fourCornersArray.Length < 4;
			if (flag)
			{
				Debug.LogError("Calling GetWorldCorners with an array that is null or has less than 4 elements.");
			}
			else
			{
				this.GetLocalCorners(fourCornersArray);
				Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
				for (int i = 0; i < 4; i++)
				{
					fourCornersArray[i] = localToWorldMatrix.MultiplyPoint(fourCornersArray[i]);
				}
			}
		}

		// Token: 0x06001C4E RID: 7246 RVA: 0x0002F1D4 File Offset: 0x0002D3D4
		public void SetInsetAndSizeFromParentEdge(RectTransform.Edge edge, float inset, float size)
		{
			int index = (edge == RectTransform.Edge.Top || edge == RectTransform.Edge.Bottom) ? 1 : 0;
			bool flag = edge == RectTransform.Edge.Top || edge == RectTransform.Edge.Right;
			float value = (float)(flag ? 1 : 0);
			Vector2 vector = this.anchorMin;
			vector[index] = value;
			this.anchorMin = vector;
			vector = this.anchorMax;
			vector[index] = value;
			this.anchorMax = vector;
			Vector2 sizeDelta = this.sizeDelta;
			sizeDelta[index] = size;
			this.sizeDelta = sizeDelta;
			Vector2 anchoredPosition = this.anchoredPosition;
			anchoredPosition[index] = (flag ? (-inset - size * (1f - this.pivot[index])) : (inset + size * this.pivot[index]));
			this.anchoredPosition = anchoredPosition;
		}

		// Token: 0x06001C4F RID: 7247 RVA: 0x0002F2A0 File Offset: 0x0002D4A0
		public void SetSizeWithCurrentAnchors(RectTransform.Axis axis, float size)
		{
			Vector2 sizeDelta = this.sizeDelta;
			sizeDelta[(int)axis] = size - this.GetParentSize()[(int)axis] * (this.anchorMax[(int)axis] - this.anchorMin[(int)axis]);
			this.sizeDelta = sizeDelta;
		}

		// Token: 0x06001C50 RID: 7248 RVA: 0x0002F2F9 File Offset: 0x0002D4F9
		[RequiredByNativeCode]
		internal static void SendReapplyDrivenProperties(RectTransform driven)
		{
			RectTransform.ReapplyDrivenProperties reapplyDrivenProperties = RectTransform.reapplyDrivenProperties;
			if (reapplyDrivenProperties != null)
			{
				reapplyDrivenProperties(driven);
			}
		}

		// Token: 0x06001C51 RID: 7249 RVA: 0x0002F310 File Offset: 0x0002D510
		internal Rect GetRectInParentSpace()
		{
			Rect rect = this.rect;
			Vector2 vector = this.offsetMin + Vector2.Scale(this.pivot, rect.size);
			bool flag = base.transform.parent;
			if (flag)
			{
				RectTransform component = base.transform.parent.GetComponent<RectTransform>();
				bool flag2 = component;
				if (flag2)
				{
					vector += Vector2.Scale(this.anchorMin, component.rect.size);
				}
			}
			rect.x += vector.x;
			rect.y += vector.y;
			return rect;
		}

		// Token: 0x06001C52 RID: 7250 RVA: 0x0002F3C8 File Offset: 0x0002D5C8
		private Vector2 GetParentSize()
		{
			RectTransform rectTransform = base.parent as RectTransform;
			bool flag = !rectTransform;
			Vector2 result;
			if (flag)
			{
				result = Vector2.zero;
			}
			else
			{
				result = rectTransform.rect.size;
			}
			return result;
		}

		// Token: 0x06001C54 RID: 7252
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_rect_Injected(out Rect ret);

		// Token: 0x06001C55 RID: 7253
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_anchorMin_Injected(out Vector2 ret);

		// Token: 0x06001C56 RID: 7254
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_anchorMin_Injected(ref Vector2 value);

		// Token: 0x06001C57 RID: 7255
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_anchorMax_Injected(out Vector2 ret);

		// Token: 0x06001C58 RID: 7256
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_anchorMax_Injected(ref Vector2 value);

		// Token: 0x06001C59 RID: 7257
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_anchoredPosition_Injected(out Vector2 ret);

		// Token: 0x06001C5A RID: 7258
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_anchoredPosition_Injected(ref Vector2 value);

		// Token: 0x06001C5B RID: 7259
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_sizeDelta_Injected(out Vector2 ret);

		// Token: 0x06001C5C RID: 7260
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_sizeDelta_Injected(ref Vector2 value);

		// Token: 0x06001C5D RID: 7261
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_pivot_Injected(out Vector2 ret);

		// Token: 0x06001C5E RID: 7262
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_pivot_Injected(ref Vector2 value);

		// Token: 0x0200029D RID: 669
		public enum Edge
		{
			// Token: 0x0400098B RID: 2443
			Left,
			// Token: 0x0400098C RID: 2444
			Right,
			// Token: 0x0400098D RID: 2445
			Top,
			// Token: 0x0400098E RID: 2446
			Bottom
		}

		// Token: 0x0200029E RID: 670
		public enum Axis
		{
			// Token: 0x04000990 RID: 2448
			Horizontal,
			// Token: 0x04000991 RID: 2449
			Vertical
		}

		// Token: 0x0200029F RID: 671
		// (Invoke) Token: 0x06001C60 RID: 7264
		public delegate void ReapplyDrivenProperties(RectTransform driven);
	}
}
