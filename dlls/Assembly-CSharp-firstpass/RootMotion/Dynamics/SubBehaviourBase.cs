using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200004D RID: 77
	[Serializable]
	public abstract class SubBehaviourBase
	{
		// Token: 0x06000210 RID: 528 RVA: 0x00007E33 File Offset: 0x00006033
		protected static Vector2 XZ(Vector3 v)
		{
			return new Vector2(v.x, v.z);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000BD71 File Offset: 0x00009F71
		protected static Vector3 XYZ(Vector2 v)
		{
			return new Vector3(v.x, 0f, v.y);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000BD89 File Offset: 0x00009F89
		protected static Vector3 Flatten(Vector3 v)
		{
			return new Vector3(v.x, 0f, v.z);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000BDA1 File Offset: 0x00009FA1
		protected static Vector3 SetY(Vector3 v, float y)
		{
			return new Vector3(v.x, y, v.z);
		}

		// Token: 0x040001D8 RID: 472
		protected BehaviourBase behaviour;
	}
}
