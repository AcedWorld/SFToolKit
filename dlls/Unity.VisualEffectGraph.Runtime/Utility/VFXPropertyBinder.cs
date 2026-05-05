using System;
using System.Collections.Generic;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200003F RID: 63
	[RequireComponent(typeof(VisualEffect))]
	[DefaultExecutionOrder(1)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	public class VFXPropertyBinder : MonoBehaviour
	{
		// Token: 0x06000193 RID: 403 RVA: 0x00008FB7 File Offset: 0x000071B7
		private void OnEnable()
		{
			this.Reload();
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00008FBF File Offset: 0x000071BF
		private void OnValidate()
		{
			this.Reload();
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00008FC7 File Offset: 0x000071C7
		private static void SafeDestroy(Object toDelete)
		{
			Object.Destroy(toDelete);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00008FCF File Offset: 0x000071CF
		private void Reload()
		{
			this.m_VisualEffect = base.GetComponent<VisualEffect>();
			this.m_Bindings = new List<VFXBinderBase>();
			this.m_Bindings.AddRange(base.gameObject.GetComponents<VFXBinderBase>());
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00008FFE File Offset: 0x000071FE
		private void Reset()
		{
			this.Reload();
			this.ClearPropertyBinders();
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000900C File Offset: 0x0000720C
		private void LateUpdate()
		{
			if (!this.m_ExecuteInEditor && Application.isEditor && !Application.isPlaying)
			{
				return;
			}
			for (int i = 0; i < this.m_Bindings.Count; i++)
			{
				VFXBinderBase vfxbinderBase = this.m_Bindings[i];
				if (vfxbinderBase == null)
				{
					Debug.LogWarning(string.Format("Parameter binder at index {0} of GameObject {1} is null or missing", i, base.gameObject.name));
				}
				else if (vfxbinderBase.IsValid(this.m_VisualEffect))
				{
					vfxbinderBase.UpdateBinding(this.m_VisualEffect);
				}
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00009098 File Offset: 0x00007298
		public T AddPropertyBinder<T>() where T : VFXBinderBase
		{
			return base.gameObject.AddComponent<T>();
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000090A5 File Offset: 0x000072A5
		[Obsolete("Use AddPropertyBinder<T>() instead")]
		public T AddParameterBinder<T>() where T : VFXBinderBase
		{
			return this.AddPropertyBinder<T>();
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000090B0 File Offset: 0x000072B0
		public void ClearPropertyBinders()
		{
			VFXBinderBase[] components = base.GetComponents<VFXBinderBase>();
			for (int i = 0; i < components.Length; i++)
			{
				VFXPropertyBinder.SafeDestroy(components[i]);
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x000090DA File Offset: 0x000072DA
		[Obsolete("Please use ClearPropertyBinders() instead")]
		public void ClearParameterBinders()
		{
			this.ClearPropertyBinders();
		}

		// Token: 0x0600019D RID: 413 RVA: 0x000090E2 File Offset: 0x000072E2
		public void RemovePropertyBinder(VFXBinderBase binder)
		{
			if (binder.gameObject == base.gameObject)
			{
				VFXPropertyBinder.SafeDestroy(binder);
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000090FD File Offset: 0x000072FD
		[Obsolete("Please use RemovePropertyBinder() instead")]
		public void RemoveParameterBinder(VFXBinderBase binder)
		{
			this.RemovePropertyBinder(binder);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00009108 File Offset: 0x00007308
		public void RemovePropertyBinders<T>() where T : VFXBinderBase
		{
			foreach (VFXBinderBase vfxbinderBase in base.GetComponents<VFXBinderBase>())
			{
				if (vfxbinderBase is T)
				{
					VFXPropertyBinder.SafeDestroy(vfxbinderBase);
				}
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000913C File Offset: 0x0000733C
		[Obsolete("Please use RemovePropertyBinders<T>() instead")]
		public void RemoveParameterBinders<T>() where T : VFXBinderBase
		{
			this.RemovePropertyBinders<T>();
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00009144 File Offset: 0x00007344
		public IEnumerable<T> GetPropertyBinders<T>() where T : VFXBinderBase
		{
			foreach (VFXBinderBase vfxbinderBase in this.m_Bindings)
			{
				if (vfxbinderBase is T)
				{
					yield return vfxbinderBase as T;
				}
			}
			List<VFXBinderBase>.Enumerator enumerator = default(List<VFXBinderBase>.Enumerator);
			yield break;
			yield break;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00009154 File Offset: 0x00007354
		[Obsolete("Please use GetPropertyBinders<T>() instead")]
		public IEnumerable<T> GetParameterBinders<T>() where T : VFXBinderBase
		{
			return this.GetPropertyBinders<T>();
		}

		// Token: 0x04000111 RID: 273
		[SerializeField]
		protected bool m_ExecuteInEditor = true;

		// Token: 0x04000112 RID: 274
		public List<VFXBinderBase> m_Bindings = new List<VFXBinderBase>();

		// Token: 0x04000113 RID: 275
		[SerializeField]
		protected VisualEffect m_VisualEffect;
	}
}
