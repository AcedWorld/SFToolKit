using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000FE RID: 254
	[HelpURL("https://www.youtube.com/watch?v=-TDZpNjt2mk&index=15&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Interaction System/Interaction Trigger")]
	public class InteractionTrigger : MonoBehaviour
	{
		// Token: 0x060008AD RID: 2221 RVA: 0x00036379 File Offset: 0x00034579
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page10.html");
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x000385D9 File Offset: 0x000367D9
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_interaction_trigger.html");
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x000363B5 File Offset: 0x000345B5
		[ContextMenu("TUTORIAL VIDEO")]
		private void OpenTutorial4()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=-TDZpNjt2mk&index=15&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6");
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x000385E8 File Offset: 0x000367E8
		public int GetBestRangeIndex(Transform character, Transform raycastFrom, RaycastHit raycastHit)
		{
			if (base.GetComponent<Collider>() == null)
			{
				Warning.Log("Using the InteractionTrigger requires a Collider component.", base.transform, false);
				return -1;
			}
			int result = -1;
			float num = 180f;
			float num2 = 0f;
			for (int i = 0; i < this.ranges.Length; i++)
			{
				if (this.ranges[i].IsInRange(character, raycastFrom, raycastHit, base.transform, out num2) && num2 <= num)
				{
					num = num2;
					result = i;
				}
			}
			return result;
		}

		// Token: 0x040007FB RID: 2043
		[Tooltip("The valid ranges of the character's and/or its camera's position for triggering interaction when the character is in contact with the collider of this trigger.")]
		public InteractionTrigger.Range[] ranges = new InteractionTrigger.Range[0];

		// Token: 0x020000FF RID: 255
		[Serializable]
		public class CharacterPosition
		{
			// Token: 0x170000FD RID: 253
			// (get) Token: 0x060008B4 RID: 2228 RVA: 0x0003866E File Offset: 0x0003686E
			public Vector3 offset3D
			{
				get
				{
					return new Vector3(this.offset.x, 0f, this.offset.y);
				}
			}

			// Token: 0x170000FE RID: 254
			// (get) Token: 0x060008B5 RID: 2229 RVA: 0x00038690 File Offset: 0x00036890
			public Vector3 direction3D
			{
				get
				{
					return Quaternion.AngleAxis(this.angleOffset, Vector3.up) * Vector3.forward;
				}
			}

			// Token: 0x060008B6 RID: 2230 RVA: 0x000386AC File Offset: 0x000368AC
			public bool IsInRange(Transform character, Transform trigger, out float error)
			{
				error = 0f;
				if (!this.use)
				{
					return true;
				}
				error = 180f;
				if (this.radius <= 0f)
				{
					return false;
				}
				if (this.maxAngle <= 0f)
				{
					return false;
				}
				Vector3 forward = trigger.forward;
				if (this.fixYAxis)
				{
					forward.y = 0f;
				}
				if (forward == Vector3.zero)
				{
					return false;
				}
				Vector3 vector = this.fixYAxis ? Vector3.up : trigger.up;
				Quaternion rotation = Quaternion.LookRotation(forward, vector);
				Vector3 vector2 = trigger.position + rotation * this.offset3D;
				Vector3 b = this.orbit ? trigger.position : vector2;
				Vector3 vector3 = character.position - b;
				Vector3.OrthoNormalize(ref vector, ref vector3);
				vector3 *= Vector3.Project(character.position - b, vector3).magnitude;
				if (this.orbit)
				{
					float magnitude = this.offset.magnitude;
					float magnitude2 = vector3.magnitude;
					if (magnitude2 < magnitude - this.radius || magnitude2 > magnitude + this.radius)
					{
						return false;
					}
				}
				else if (vector3.magnitude > this.radius)
				{
					return false;
				}
				Vector3 vector4 = rotation * this.direction3D;
				Vector3.OrthoNormalize(ref vector, ref vector4);
				if (this.orbit)
				{
					Vector3 vector5 = vector2 - trigger.position;
					if (vector5 == Vector3.zero)
					{
						vector5 = Vector3.forward;
					}
					vector3 = Quaternion.Inverse(Quaternion.LookRotation(vector5, vector)) * vector3;
					vector4 = Quaternion.AngleAxis(Mathf.Atan2(vector3.x, vector3.z) * 57.29578f, vector) * vector4;
				}
				float num = Vector3.Angle(vector4, character.forward);
				if (num > this.maxAngle)
				{
					return false;
				}
				error = num / this.maxAngle * 180f;
				return true;
			}

			// Token: 0x040007FC RID: 2044
			[Tooltip("If false, will not care where the character stands, as long as it is in contact with the trigger collider.")]
			public bool use;

			// Token: 0x040007FD RID: 2045
			[Tooltip("The offset of the character's position relative to the trigger in XZ plane. Y position of the character is unlimited as long as it is contact with the collider.")]
			public Vector2 offset;

			// Token: 0x040007FE RID: 2046
			[Tooltip("Angle offset from the default forward direction.")]
			[Range(-180f, 180f)]
			public float angleOffset;

			// Token: 0x040007FF RID: 2047
			[Tooltip("Max angular offset of the character's forward from the direction of this trigger.")]
			[Range(0f, 180f)]
			public float maxAngle = 45f;

			// Token: 0x04000800 RID: 2048
			[Tooltip("Max offset of the character's position from this range's center.")]
			public float radius = 0.5f;

			// Token: 0x04000801 RID: 2049
			[Tooltip("If true, will rotate the trigger around its Y axis relative to the position of the character, so the object can be interacted with from all sides.")]
			public bool orbit;

			// Token: 0x04000802 RID: 2050
			[Tooltip("Fixes the Y axis of the trigger to Vector3.up. This makes the trigger symmetrical relative to the object. For example a gun will be able to be picked up from the same direction relative to the barrel no matter which side the gun is resting on.")]
			public bool fixYAxis;
		}

		// Token: 0x02000100 RID: 256
		[Serializable]
		public class CameraPosition
		{
			// Token: 0x060008B8 RID: 2232 RVA: 0x000388B8 File Offset: 0x00036AB8
			public Quaternion GetRotation()
			{
				Vector3 forward = this.lookAtTarget.transform.forward;
				if (this.fixYAxis)
				{
					forward.y = 0f;
				}
				if (forward == Vector3.zero)
				{
					return Quaternion.identity;
				}
				Vector3 upwards = this.fixYAxis ? Vector3.up : this.lookAtTarget.transform.up;
				return Quaternion.LookRotation(forward, upwards);
			}

			// Token: 0x060008B9 RID: 2233 RVA: 0x00038924 File Offset: 0x00036B24
			public bool IsInRange(Transform raycastFrom, RaycastHit hit, Transform trigger, out float error)
			{
				error = 0f;
				if (this.lookAtTarget == null)
				{
					return true;
				}
				error = 180f;
				if (raycastFrom == null)
				{
					return false;
				}
				if (hit.collider != this.lookAtTarget)
				{
					return false;
				}
				if (hit.distance > this.maxDistance)
				{
					return false;
				}
				if (this.direction == Vector3.zero)
				{
					return false;
				}
				if (this.maxDistance <= 0f)
				{
					return false;
				}
				if (this.maxAngle <= 0f)
				{
					return false;
				}
				Vector3 to = this.GetRotation() * this.direction;
				float num = Vector3.Angle(raycastFrom.position - hit.point, to);
				if (num > this.maxAngle)
				{
					return false;
				}
				error = num / this.maxAngle * 180f;
				return true;
			}

			// Token: 0x04000803 RID: 2051
			[Tooltip("What the camera should be looking at to trigger the interaction? If null, this camera position will not be used.")]
			public Collider lookAtTarget;

			// Token: 0x04000804 RID: 2052
			[Tooltip("The direction from the lookAtTarget towards the camera (in lookAtTarget's space).")]
			public Vector3 direction = -Vector3.forward;

			// Token: 0x04000805 RID: 2053
			[Tooltip("Max distance from the lookAtTarget to the camera.")]
			public float maxDistance = 0.5f;

			// Token: 0x04000806 RID: 2054
			[Tooltip("Max angle between the direction and the direction towards the camera.")]
			[Range(0f, 180f)]
			public float maxAngle = 45f;

			// Token: 0x04000807 RID: 2055
			[Tooltip("Fixes the Y axis of the trigger to Vector3.up. This makes the trigger symmetrical relative to the object.")]
			public bool fixYAxis;
		}

		// Token: 0x02000101 RID: 257
		[Serializable]
		public class Range
		{
			// Token: 0x060008BB RID: 2235 RVA: 0x00038A2C File Offset: 0x00036C2C
			public bool IsInRange(Transform character, Transform raycastFrom, RaycastHit raycastHit, Transform trigger, out float maxError)
			{
				maxError = 0f;
				float a = 0f;
				float b = 0f;
				if (!this.characterPosition.IsInRange(character, trigger, out a))
				{
					return false;
				}
				if (!this.cameraPosition.IsInRange(raycastFrom, raycastHit, trigger, out b))
				{
					return false;
				}
				maxError = Mathf.Max(a, b);
				return true;
			}

			// Token: 0x04000808 RID: 2056
			[HideInInspector]
			public string name;

			// Token: 0x04000809 RID: 2057
			[HideInInspector]
			public bool show = true;

			// Token: 0x0400080A RID: 2058
			[Tooltip("The range for the character's position and rotation.")]
			public InteractionTrigger.CharacterPosition characterPosition;

			// Token: 0x0400080B RID: 2059
			[Tooltip("The range for the character camera's position and rotation.")]
			public InteractionTrigger.CameraPosition cameraPosition;

			// Token: 0x0400080C RID: 2060
			[Tooltip("Definitions of the interactions associated with this range.")]
			public InteractionTrigger.Range.Interaction[] interactions;

			// Token: 0x02000102 RID: 258
			[Serializable]
			public class Interaction
			{
				// Token: 0x0400080D RID: 2061
				[Tooltip("The InteractionObject to interact with.")]
				public InteractionObject interactionObject;

				// Token: 0x0400080E RID: 2062
				[Tooltip("The effectors to interact with.")]
				public FullBodyBipedEffector[] effectors;
			}
		}
	}
}
