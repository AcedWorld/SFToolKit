using System;
using UnityEngine;

namespace Rewired.Components
{
	// Token: 0x020003D0 RID: 976
	[AddComponentMenu("")]
	[Serializable]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		// Token: 0x17000920 RID: 2336
		// (get) Token: 0x060026CB RID: 9931 RVA: 0x0001CE28 File Offset: 0x0001B028
		protected T source
		{
			get
			{
				return this.VNErOJWwnSkHCmJwPjoAFDqjFwzg;
			}
		}

		// Token: 0x17000921 RID: 2337
		// (get) Token: 0x060026CC RID: 9932 RVA: 0x0001CE30 File Offset: 0x0001B030
		protected bool initialized
		{
			get
			{
				return this.PFKJrkmivIaMFfVqLOEaRgmgDNedb;
			}
		}

		// Token: 0x060026CD RID: 9933 RVA: 0x0001CE38 File Offset: 0x0001B038
		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			this.OnAwake();
			this.OnAwakeFinished();
		}

		// Token: 0x060026CE RID: 9934 RVA: 0x0001CE46 File Offset: 0x0001B046
		[CustomObfuscation(rename = false)]
		private void Start()
		{
			this.OnStart();
		}

		// Token: 0x060026CF RID: 9935 RVA: 0x0001CE4E File Offset: 0x0001B04E
		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			this.OnEnabled();
		}

		// Token: 0x060026D0 RID: 9936 RVA: 0x0001CE56 File Offset: 0x0001B056
		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			this.OnDisabled();
		}

		// Token: 0x060026D1 RID: 9937 RVA: 0x0001CE5E File Offset: 0x0001B05E
		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			this.OnDestroyed();
		}

		// Token: 0x060026D2 RID: 9938 RVA: 0x0001CE66 File Offset: 0x0001B066
		[CustomObfuscation(rename = false)]
		private void Reset()
		{
			this.OnReset();
		}

		// Token: 0x060026D3 RID: 9939 RVA: 0x0001CE6E File Offset: 0x0001B06E
		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			this.OnValidated();
		}

		// Token: 0x060026D4 RID: 9940 RVA: 0x0001CE76 File Offset: 0x0001B076
		protected virtual void OnAwake()
		{
			ReInput.InitializedEvent += this.CrLCqKCVuwIgJIeQrPlJVriPbUDYA;
			this.Initialize();
		}

		// Token: 0x060026D5 RID: 9941 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void OnAwakeFinished()
		{
		}

		// Token: 0x060026D6 RID: 9942 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void OnStart()
		{
		}

		// Token: 0x060026D7 RID: 9943 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void OnEnabled()
		{
		}

		// Token: 0x060026D8 RID: 9944 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void OnDisabled()
		{
		}

		// Token: 0x060026D9 RID: 9945 RVA: 0x0001CE8F File Offset: 0x0001B08F
		protected virtual void OnDestroyed()
		{
			this.Unsubscribe();
			ReInput.InitializedEvent -= this.CrLCqKCVuwIgJIeQrPlJVriPbUDYA;
		}

		// Token: 0x060026DA RID: 9946 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void OnReset()
		{
		}

		// Token: 0x060026DB RID: 9947 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void OnValidated()
		{
		}

		// Token: 0x060026DC RID: 9948 RVA: 0x0001CEA8 File Offset: 0x0001B0A8
		protected virtual void Initialize()
		{
			if (!this.TryInitialize())
			{
				return;
			}
			this.PFKJrkmivIaMFfVqLOEaRgmgDNedb = true;
			this.PostInitialize();
		}

		// Token: 0x060026DD RID: 9949 RVA: 0x0001CEC0 File Offset: 0x0001B0C0
		protected virtual bool TryInitialize()
		{
			if (this.PFKJrkmivIaMFfVqLOEaRgmgDNedb)
			{
				return false;
			}
			this.VNErOJWwnSkHCmJwPjoAFDqjFwzg = this.CreateSource(this.GetCreateSourceArgs());
			if (this.VNErOJWwnSkHCmJwPjoAFDqjFwzg == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			this.PFKJrkmivIaMFfVqLOEaRgmgDNedb = true;
			return true;
		}

		// Token: 0x060026DE RID: 9950
		protected abstract T CreateSource(object args);

		// Token: 0x060026DF RID: 9951
		protected abstract object GetCreateSourceArgs();

		// Token: 0x060026E0 RID: 9952 RVA: 0x0001CEFF File Offset: 0x0001B0FF
		protected virtual void PostInitialize()
		{
			this.Subscribe();
		}

		// Token: 0x060026E1 RID: 9953 RVA: 0x0001CF07 File Offset: 0x0001B107
		protected virtual void Deinitialize()
		{
			this.PFKJrkmivIaMFfVqLOEaRgmgDNedb = false;
			this.Unsubscribe();
			this.VNErOJWwnSkHCmJwPjoAFDqjFwzg = default(T);
		}

		// Token: 0x060026E2 RID: 9954 RVA: 0x0001CF22 File Offset: 0x0001B122
		protected virtual void Subscribe()
		{
			this.Unsubscribe();
			ReInput.ShutDownEvent += this.sggQPiiUKZGBwnSDHyrDvPiFeAtg;
		}

		// Token: 0x060026E3 RID: 9955 RVA: 0x0001CF3B File Offset: 0x0001B13B
		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= this.sggQPiiUKZGBwnSDHyrDvPiFeAtg;
		}

		// Token: 0x060026E4 RID: 9956 RVA: 0x0001CF4E File Offset: 0x0001B14E
		private void sggQPiiUKZGBwnSDHyrDvPiFeAtg()
		{
			this.Deinitialize();
		}

		// Token: 0x060026E5 RID: 9957 RVA: 0x0001CF56 File Offset: 0x0001B156
		private void CrLCqKCVuwIgJIeQrPlJVriPbUDYA()
		{
			this.Initialize();
		}

		// Token: 0x040016DF RID: 5855
		[NonSerialized]
		private T VNErOJWwnSkHCmJwPjoAFDqjFwzg;

		// Token: 0x040016E0 RID: 5856
		[NonSerialized]
		private bool PFKJrkmivIaMFfVqLOEaRgmgDNedb;
	}
}
