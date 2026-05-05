using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x0200016F RID: 367
	[Singleton(Name = "VisualScripting SceneVariables", Automatic = true, Persistent = false)]
	[RequireComponent(typeof(Variables))]
	[DisableAnnotation]
	[AddComponentMenu("")]
	[IncludeInSettings(false)]
	public sealed class SceneVariables : MonoBehaviour, ISingleton
	{
		// Token: 0x060009C4 RID: 2500 RVA: 0x0002965C File Offset: 0x0002785C
		public static SceneVariables Instance(Scene scene)
		{
			return SceneSingleton<SceneVariables>.InstanceIn(scene);
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x00029664 File Offset: 0x00027864
		public static bool InstantiatedIn(Scene scene)
		{
			return SceneSingleton<SceneVariables>.InstantiatedIn(scene);
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0002966C File Offset: 0x0002786C
		public static VariableDeclarations For(Scene? scene)
		{
			Ensure.That("scene").IsNotNull<Scene>(scene);
			return SceneVariables.Instance(scene.Value).variables.declarations;
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x00029694 File Offset: 0x00027894
		private void Awake()
		{
			SceneSingleton<SceneVariables>.Awake(this);
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0002969C File Offset: 0x0002789C
		private void OnDestroy()
		{
			SceneSingleton<SceneVariables>.OnDestroy(this);
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060009C9 RID: 2505 RVA: 0x000296A4 File Offset: 0x000278A4
		public Variables variables
		{
			get
			{
				if (this._variables == null)
				{
					this._variables = base.gameObject.GetOrAddComponent<Variables>();
				}
				return this._variables;
			}
		}

		// Token: 0x0400024A RID: 586
		private Variables _variables;
	}
}
