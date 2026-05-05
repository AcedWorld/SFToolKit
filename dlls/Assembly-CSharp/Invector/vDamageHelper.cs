using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x0200036A RID: 874
	public static class vDamageHelper
	{
		// Token: 0x060011B5 RID: 4533 RVA: 0x0005EC88 File Offset: 0x0005CE88
		public static void ApplyDamage(this GameObject receiver, vDamage damage)
		{
			vIDamageReceiver[] components = receiver.GetComponents<vIDamageReceiver>();
			if (components != null)
			{
				for (int i = 0; i < components.Length; i++)
				{
					components[i].TakeDamage(damage);
				}
			}
		}

		// Token: 0x060011B6 RID: 4534 RVA: 0x0005ECB6 File Offset: 0x0005CEB6
		public static bool CanReceiveDamage(this GameObject receiver)
		{
			return receiver.GetComponent<vIDamageReceiver>() != null;
		}

		// Token: 0x060011B7 RID: 4535 RVA: 0x0005ECC4 File Offset: 0x0005CEC4
		public static float HitAngle(this Transform transform, Vector3 hitpoint, bool normalized = true)
		{
			Vector3 vector = transform.InverseTransformPoint(hitpoint);
			int num = (int)(Mathf.Atan2(vector.x, vector.z) * 57.29578f);
			if (!normalized)
			{
				return (float)num;
			}
			if (num <= 45 && num >= -45)
			{
				num = 0;
			}
			else if (num > 45 && num < 135)
			{
				num = 90;
			}
			else if (num >= 135 || num <= -135)
			{
				num = 180;
			}
			else if (num < -45 && num > -135)
			{
				num = -90;
			}
			return (float)num;
		}
	}
}
