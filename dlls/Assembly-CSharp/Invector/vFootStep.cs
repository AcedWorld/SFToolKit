using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000341 RID: 833
	public class vFootStep : vFootStepBase
	{
		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06001122 RID: 4386 RVA: 0x0005CE1A File Offset: 0x0005B01A
		// (set) Token: 0x06001123 RID: 4387 RVA: 0x0005CE22 File Offset: 0x0005B022
		public float Volume
		{
			get
			{
				return this._volume;
			}
			set
			{
				this._volume = value;
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06001124 RID: 4388 RVA: 0x0005CE2B File Offset: 0x0005B02B
		// (set) Token: 0x06001125 RID: 4389 RVA: 0x0005CE33 File Offset: 0x0005B033
		public bool SpawnParticle
		{
			get
			{
				return this._spawnParticle;
			}
			set
			{
				this._spawnParticle = value;
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06001126 RID: 4390 RVA: 0x0005CE3C File Offset: 0x0005B03C
		// (set) Token: 0x06001127 RID: 4391 RVA: 0x0005CE44 File Offset: 0x0005B044
		public bool SpawnStepMark
		{
			get
			{
				return this._spawnStepMark;
			}
			set
			{
				this._spawnStepMark = value;
			}
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x0005CE4D File Offset: 0x0005B04D
		protected virtual void Start()
		{
			this.InitFootStep();
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x0005CE58 File Offset: 0x0005B058
		public virtual void InitFootStep()
		{
			Collider[] componentsInChildren = base.GetComponentsInChildren<Collider>();
			if (this.animationType != AnimationType.Humanoid)
			{
				foreach (Collider collider in componentsInChildren)
				{
					for (int j = 0; j < this.footStepTriggers.Count; j++)
					{
						vFootStepTrigger vFootStepTrigger = this.footStepTriggers[j];
						vFootStepTrigger.trigger.isTrigger = true;
						if (collider.enabled && collider.gameObject != vFootStepTrigger.gameObject)
						{
							Physics.IgnoreCollision(vFootStepTrigger.trigger, collider);
						}
					}
				}
				return;
			}
			if (this.leftFootTrigger == null && this.rightFootTrigger == null)
			{
				Debug.Log("Missing FootStep Sphere Trigger, please unfold the FootStep Component to create the triggers.");
				return;
			}
			this.leftFootTrigger.trigger.isTrigger = true;
			this.rightFootTrigger.trigger.isTrigger = true;
			Physics.IgnoreCollision(this.leftFootTrigger.trigger, this.rightFootTrigger.trigger);
			foreach (Collider collider2 in componentsInChildren)
			{
				if (collider2.enabled && collider2.gameObject != this.leftFootTrigger.gameObject)
				{
					Physics.IgnoreCollision(this.leftFootTrigger.trigger, collider2);
				}
				if (collider2.enabled && collider2.gameObject != this.rightFootTrigger.gameObject)
				{
					Physics.IgnoreCollision(this.rightFootTrigger.trigger, collider2);
				}
			}
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x0005CFC8 File Offset: 0x0005B1C8
		protected virtual void UpdateTerrainInfo(Terrain newTerrain)
		{
			if (this.terrain == null || this.terrain != newTerrain)
			{
				this.terrain = newTerrain;
				if (this.terrain != null)
				{
					this.terrainData = this.terrain.terrainData;
					this.terrainPos = this.terrain.transform.position;
					this.terrainCollider = this.terrain.GetComponent<TerrainCollider>();
				}
			}
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x0005D040 File Offset: 0x0005B240
		protected virtual float[] GetTextureMix(FootStepObject footStepObj)
		{
			this.UpdateTerrainInfo(footStepObj.terrain);
			Vector3 position = footStepObj.sender.position;
			int x = (int)((position.x - this.terrainPos.x) / this.terrainData.size.x * (float)this.terrainData.alphamapWidth);
			int y = (int)((position.z - this.terrainPos.z) / this.terrainData.size.z * (float)this.terrainData.alphamapHeight);
			if (!this.terrainCollider.bounds.Contains(position))
			{
				return new float[0];
			}
			float[,,] alphamaps = this.terrainData.GetAlphamaps(x, y, 1, 1);
			float[] array = new float[alphamaps.GetUpperBound(2) + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = alphamaps[0, 0, i];
			}
			return array;
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x0005D12C File Offset: 0x0005B32C
		protected virtual int GetMainTexture(FootStepObject footStepObj)
		{
			float[] textureMix = this.GetTextureMix(footStepObj);
			if (textureMix == null)
			{
				return -1;
			}
			float num = 0f;
			int result = 0;
			for (int i = 0; i < textureMix.Length; i++)
			{
				if (textureMix[i] > num)
				{
					result = i;
					num = textureMix[i];
				}
			}
			return result;
		}

		// Token: 0x0600112D RID: 4397 RVA: 0x0005D16C File Offset: 0x0005B36C
		protected virtual void OnDestroy()
		{
			if (this.leftFootTrigger != null)
			{
				Object.Destroy(this.leftFootTrigger.gameObject);
			}
			if (this.rightFootTrigger != null)
			{
				Object.Destroy(this.rightFootTrigger.gameObject);
			}
			if (this.footStepTriggers != null && this.footStepTriggers.Count > 0)
			{
				foreach (vFootStepTrigger vFootStepTrigger in this.footStepTriggers)
				{
					Object.Destroy(vFootStepTrigger.gameObject);
				}
			}
		}

		// Token: 0x0600112E RID: 4398 RVA: 0x0005D214 File Offset: 0x0005B414
		public override void StepOnTerrain(FootStepObject footStepObject)
		{
			if (this.currentStep != null && this.currentStep == footStepObject.sender && this._useTriggerEnter)
			{
				return;
			}
			this.currentStep = footStepObject.sender;
			this.surfaceIndex = this.GetMainTexture(footStepObject);
			if (this.surfaceIndex != -1)
			{
				string text = (this.terrainData != null && this.terrainData.terrainLayers.Length != 0) ? this.terrainData.terrainLayers[this.surfaceIndex].diffuseTexture.name : "";
				footStepObject.name = text;
				this.currentFootStep = footStepObject;
				if (this._useTriggerEnter)
				{
					this.PlayFootStepEffect();
					if (this.debugTextureName)
					{
						Debug.Log(this.terrain.name + " " + text);
					}
				}
			}
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x0005D2EC File Offset: 0x0005B4EC
		public override void StepOnMesh(FootStepObject footStepObject)
		{
			if (this.currentStep != null && this.currentStep == footStepObject.sender && this._useTriggerEnter)
			{
				return;
			}
			this.currentStep = footStepObject.sender;
			this.currentFootStep = footStepObject;
			if (this._useTriggerEnter)
			{
				this.PlayFootStepEffect();
				if (this.debugTextureName)
				{
					Debug.Log(footStepObject.name);
				}
			}
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x0005D358 File Offset: 0x0005B558
		public override void PlayFootStepEffect()
		{
			if (this.currentFootStep != null)
			{
				this.currentFootStep.volume = this.Volume;
				this.currentFootStep.spawnParticleEffect = this.SpawnParticle;
				this.currentFootStep.spawnStepMarkEffect = this.SpawnStepMark;
				this.SpawnSurfaceEffect(this.currentFootStep);
			}
		}

		// Token: 0x06001131 RID: 4401 RVA: 0x0005D3AC File Offset: 0x0005B5AC
		public override void PlayFootStep(AnimationEvent evt)
		{
			if ((double)evt.animatorClipInfo.weight > 0.5)
			{
				this.PlayFootStepEffect();
			}
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x0005D3DC File Offset: 0x0005B5DC
		public override void PlayFootStepLeft(AnimationEvent evt)
		{
			if ((double)evt.animatorClipInfo.weight > 0.5)
			{
				this.currentFootStep.sender = this.leftFootTrigger.transform;
				this.PlayFootStepEffect();
			}
		}

		// Token: 0x06001133 RID: 4403 RVA: 0x0005D420 File Offset: 0x0005B620
		public override void PlayFootStepRight(AnimationEvent evt)
		{
			if ((double)evt.animatorClipInfo.weight > 0.15)
			{
				this.currentFootStep.sender = this.rightFootTrigger.transform;
				this.PlayFootStepEffect();
			}
		}

		// Token: 0x040016FD RID: 5885
		public AnimationType animationType;

		// Token: 0x040016FE RID: 5886
		public bool debugTextureName;

		// Token: 0x040016FF RID: 5887
		[SerializeField]
		[Range(0f, 1f)]
		protected float _volume = 1f;

		// Token: 0x04001700 RID: 5888
		[vHelpBox("Enable or disable spawn particle when foot step is triggered", vHelpBoxAttribute.MessageType.None)]
		[SerializeField]
		protected bool _spawnParticle = true;

		// Token: 0x04001701 RID: 5889
		[vHelpBox("Enable or disable spawn step mark when foot step is triggered", vHelpBoxAttribute.MessageType.None)]
		[SerializeField]
		protected bool _spawnStepMark = true;

		// Token: 0x04001702 RID: 5890
		[vHelpBox("The step effect is spawned from on trigger enter event of the Foot Step Triggers. If you need to play step sound only by external events you need to disable this variable.<b>\n*Disable this to play step sound using animation events</b>", vHelpBoxAttribute.MessageType.None)]
		[SerializeField]
		protected bool _useTriggerEnter = true;

		// Token: 0x04001703 RID: 5891
		protected int surfaceIndex;

		// Token: 0x04001704 RID: 5892
		protected Terrain terrain;

		// Token: 0x04001705 RID: 5893
		protected TerrainCollider terrainCollider;

		// Token: 0x04001706 RID: 5894
		protected TerrainData terrainData;

		// Token: 0x04001707 RID: 5895
		protected Vector3 terrainPos;

		// Token: 0x04001708 RID: 5896
		public vFootStepTrigger leftFootTrigger;

		// Token: 0x04001709 RID: 5897
		public vFootStepTrigger rightFootTrigger;

		// Token: 0x0400170A RID: 5898
		public Transform currentStep;

		// Token: 0x0400170B RID: 5899
		public List<vFootStepTrigger> footStepTriggers;

		// Token: 0x0400170C RID: 5900
		protected FootStepObject currentFootStep;
	}
}
