using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x0200036D RID: 877
	public static class vHealthControllerHelper
	{
		// Token: 0x060011C3 RID: 4547 RVA: 0x0005ED4A File Offset: 0x0005CF4A
		private static vIHealthController GetHealthController(this GameObject gameObject)
		{
			return gameObject.GetComponent<vIHealthController>();
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x0005ED54 File Offset: 0x0005CF54
		public static void AddHealth(this GameObject receiver, int health)
		{
			vIHealthController healthController = receiver.GetHealthController();
			if (healthController != null)
			{
				healthController.AddHealth(health);
			}
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x0005ED74 File Offset: 0x0005CF74
		public static void ChangeHealth(this GameObject receiver, int health)
		{
			vIHealthController healthController = receiver.GetHealthController();
			if (healthController != null)
			{
				healthController.ChangeHealth(health);
			}
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x0005ED94 File Offset: 0x0005CF94
		public static void ChangeMaxHealth(this GameObject receiver, int health)
		{
			vIHealthController healthController = receiver.GetHealthController();
			if (healthController != null)
			{
				healthController.ChangeMaxHealth(health);
			}
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x0005EDB2 File Offset: 0x0005CFB2
		public static bool HasHealth(this GameObject gameObject)
		{
			return gameObject.GetHealthController() != null;
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x0005EDC0 File Offset: 0x0005CFC0
		public static bool IsDead(this GameObject gameObject)
		{
			vIHealthController healthController = gameObject.GetHealthController();
			return healthController == null || healthController.isDead;
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x0005EDE0 File Offset: 0x0005CFE0
		public static void ResetHealth(this GameObject receiver, float health)
		{
			vIHealthController healthController = receiver.GetHealthController();
			if (healthController != null)
			{
				healthController.ResetHealth(health);
			}
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x0005EE00 File Offset: 0x0005D000
		public static void ResetHealth(this GameObject receiver)
		{
			vIHealthController healthController = receiver.GetHealthController();
			if (healthController != null)
			{
				healthController.ResetHealth();
			}
		}
	}
}
