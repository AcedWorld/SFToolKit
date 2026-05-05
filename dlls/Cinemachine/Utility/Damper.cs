using System;
using UnityEngine;

namespace Cinemachine.Utility
{
	// Token: 0x02000065 RID: 101
	public static class Damper
	{
		// Token: 0x060003D7 RID: 983 RVA: 0x0001760A File Offset: 0x0001580A
		private static float DecayConstant(float time, float residual)
		{
			return Mathf.Log(1f / residual) / time;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0001761A File Offset: 0x0001581A
		private static float DecayedRemainder(float initial, float decayConstant, float deltaTime)
		{
			return initial / Mathf.Exp(decayConstant * deltaTime);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00017628 File Offset: 0x00015828
		public static float Damp(float initial, float dampTime, float deltaTime)
		{
			if (dampTime < 0.0001f || Mathf.Abs(initial) < 0.0001f)
			{
				return initial;
			}
			if (deltaTime < 0.0001f)
			{
				return 0f;
			}
			float num = 4.6051702f / dampTime;
			return initial * (1f - Mathf.Exp(-num * deltaTime));
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00017674 File Offset: 0x00015874
		public static Vector3 Damp(Vector3 initial, Vector3 dampTime, float deltaTime)
		{
			for (int i = 0; i < 3; i++)
			{
				initial[i] = Damper.Damp(initial[i], dampTime[i], deltaTime);
			}
			return initial;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000176AC File Offset: 0x000158AC
		public static Vector3 Damp(Vector3 initial, float dampTime, float deltaTime)
		{
			for (int i = 0; i < 3; i++)
			{
				initial[i] = Damper.Damp(initial[i], dampTime, deltaTime);
			}
			return initial;
		}

		// Token: 0x04000298 RID: 664
		private const float Epsilon = 0.0001f;

		// Token: 0x04000299 RID: 665
		public const float kNegligibleResidual = 0.01f;

		// Token: 0x0400029A RID: 666
		private const float kLogNegligibleResidual = -4.6051702f;
	}
}
