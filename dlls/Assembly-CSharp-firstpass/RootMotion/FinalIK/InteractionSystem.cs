using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace RootMotion.FinalIK
{
	// Token: 0x020000F8 RID: 248
	[HelpURL("https://www.youtube.com/watch?v=r5jiZnsDH3M")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Interaction System/Interaction System")]
	public class InteractionSystem : MonoBehaviour
	{
		// Token: 0x06000857 RID: 2135 RVA: 0x00036379 File Offset: 0x00034579
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page10.html");
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00036E0B File Offset: 0x0003500B
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_interaction_system.html");
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00036391 File Offset: 0x00034591
		[ContextMenu("TUTORIAL VIDEO (PART 1: BASICS)")]
		private void OpenTutorial1()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=r5jiZnsDH3M");
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0003639D File Offset: 0x0003459D
		[ContextMenu("TUTORIAL VIDEO (PART 2: PICKING UP...)")]
		private void OpenTutorial2()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=eP9-zycoHLk");
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x000363A9 File Offset: 0x000345A9
		[ContextMenu("TUTORIAL VIDEO (PART 3: ANIMATION)")]
		private void OpenTutorial3()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=sQfB2RcT1T4&index=14&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6");
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x000363B5 File Offset: 0x000345B5
		[ContextMenu("TUTORIAL VIDEO (PART 4: TRIGGERS)")]
		private void OpenTutorial4()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=-TDZpNjt2mk&index=15&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6");
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x00036E18 File Offset: 0x00035018
		public bool inInteraction
		{
			get
			{
				if (!this.IsValid(true))
				{
					return false;
				}
				for (int i = 0; i < this.interactionEffectors.Length; i++)
				{
					if (this.interactionEffectors[i].inInteraction && !this.interactionEffectors[i].isPaused)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00036E64 File Offset: 0x00035064
		public bool IsInInteraction(FullBodyBipedEffector effectorType)
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType)
				{
					return this.interactionEffectors[i].inInteraction && !this.interactionEffectors[i].isPaused;
				}
			}
			return false;
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00036EC4 File Offset: 0x000350C4
		public bool IsPaused(FullBodyBipedEffector effectorType)
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType)
				{
					return this.interactionEffectors[i].inInteraction && this.interactionEffectors[i].isPaused;
				}
			}
			return false;
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x00036F20 File Offset: 0x00035120
		public bool IsPaused()
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].inInteraction && this.interactionEffectors[i].isPaused)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x00036F6C File Offset: 0x0003516C
		public bool IsInSync()
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].isPaused)
				{
					for (int j = 0; j < this.interactionEffectors.Length; j++)
					{
						if (j != i && this.interactionEffectors[j].inInteraction && !this.interactionEffectors[j].isPaused)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x00036FE0 File Offset: 0x000351E0
		public bool StartInteraction(FullBodyBipedEffector effectorType, InteractionObject interactionObject, bool interrupt)
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			if (interactionObject == null)
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType)
				{
					return this.interactionEffectors[i].Start(interactionObject, this.targetTag, this.fadeInTime, interrupt);
				}
			}
			return false;
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x00037044 File Offset: 0x00035244
		public bool StartInteractionWithClosestTarget(FullBodyBipedEffector effectorType, InteractionObject interactionObject, bool interrupt)
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			if (interactionObject == null)
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType && this.GetClosestTargetIndex(effectorType, interactionObject) != -1)
				{
					return this.interactionEffectors[i].Start(interactionObject, interactionObject.GetTargets()[i], this.fadeInTime, interrupt);
				}
			}
			return false;
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x000370B4 File Offset: 0x000352B4
		private int GetClosestTargetIndex(FullBodyBipedEffector effectorType, InteractionObject obj)
		{
			int result = -1;
			float num = float.PositiveInfinity;
			Quaternion rotation = this.ik.solver.GetEffector(effectorType).bone.rotation;
			for (int i = 0; i < obj.GetTargets().Length; i++)
			{
				float num2 = Quaternion.Angle(rotation, obj.GetTargets()[i].transform.rotation);
				if (num2 < num)
				{
					num = num2;
					result = i;
				}
			}
			return result;
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00037120 File Offset: 0x00035320
		public bool StartInteraction(FullBodyBipedEffector effectorType, InteractionObject interactionObject, InteractionTarget target, bool interrupt)
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			if (interactionObject == null)
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType)
				{
					return this.interactionEffectors[i].Start(interactionObject, target, this.fadeInTime, interrupt);
				}
			}
			return false;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00037180 File Offset: 0x00035380
		public bool PauseInteraction(FullBodyBipedEffector effectorType)
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType)
				{
					return this.interactionEffectors[i].Pause();
				}
			}
			return false;
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x000371CC File Offset: 0x000353CC
		public bool ResumeInteraction(FullBodyBipedEffector effectorType)
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType)
				{
					return this.interactionEffectors[i].Resume();
				}
			}
			return false;
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00037218 File Offset: 0x00035418
		public bool StopInteraction(FullBodyBipedEffector effectorType)
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType)
				{
					return this.interactionEffectors[i].Stop();
				}
			}
			return false;
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00037264 File Offset: 0x00035464
		public void PauseAll()
		{
			if (!this.IsValid(true))
			{
				return;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				this.interactionEffectors[i].Pause();
			}
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x0003729C File Offset: 0x0003549C
		public void ResumeAll()
		{
			if (!this.IsValid(true))
			{
				return;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				this.interactionEffectors[i].Resume();
			}
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x000372D4 File Offset: 0x000354D4
		public void StopAll()
		{
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				this.interactionEffectors[i].Stop();
			}
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00037304 File Offset: 0x00035504
		public InteractionObject GetInteractionObject(FullBodyBipedEffector effectorType)
		{
			if (!this.IsValid(true))
			{
				return null;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType)
				{
					return this.interactionEffectors[i].interactionObject;
				}
			}
			return null;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00037350 File Offset: 0x00035550
		public float GetProgress(FullBodyBipedEffector effectorType)
		{
			if (!this.IsValid(true))
			{
				return 0f;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType)
				{
					return this.interactionEffectors[i].progress;
				}
			}
			return 0f;
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x000373A4 File Offset: 0x000355A4
		public float GetMinActiveProgress()
		{
			if (!this.IsValid(true))
			{
				return 0f;
			}
			float num = 1f;
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].inInteraction)
				{
					float progress = this.interactionEffectors[i].progress;
					if (progress > 0f && progress < num)
					{
						num = progress;
					}
				}
			}
			return num;
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00037408 File Offset: 0x00035608
		public bool TriggerInteraction(int index, bool interrupt)
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			if (!this.TriggerIndexIsValid(index))
			{
				return false;
			}
			bool result = true;
			InteractionTrigger.Range range = this.triggersInRange[index].ranges[this.bestRangeIndexes[index]];
			for (int i = 0; i < range.interactions.Length; i++)
			{
				for (int j = 0; j < range.interactions[i].effectors.Length; j++)
				{
					if (!this.StartInteraction(range.interactions[i].effectors[j], range.interactions[i].interactionObject, interrupt))
					{
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x000374A4 File Offset: 0x000356A4
		public bool TriggerInteraction(int index, bool interrupt, out InteractionObject interactionObject)
		{
			interactionObject = null;
			if (!this.IsValid(true))
			{
				return false;
			}
			if (!this.TriggerIndexIsValid(index))
			{
				return false;
			}
			bool result = true;
			InteractionTrigger.Range range = this.triggersInRange[index].ranges[this.bestRangeIndexes[index]];
			for (int i = 0; i < range.interactions.Length; i++)
			{
				for (int j = 0; j < range.interactions[i].effectors.Length; j++)
				{
					interactionObject = range.interactions[i].interactionObject;
					if (!this.StartInteraction(range.interactions[i].effectors[j], interactionObject, interrupt))
					{
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00037544 File Offset: 0x00035744
		public bool TriggerInteraction(int index, bool interrupt, out InteractionTarget interactionTarget)
		{
			interactionTarget = null;
			if (!this.IsValid(true))
			{
				return false;
			}
			if (!this.TriggerIndexIsValid(index))
			{
				return false;
			}
			bool result = true;
			InteractionTrigger.Range range = this.triggersInRange[index].ranges[this.bestRangeIndexes[index]];
			for (int i = 0; i < range.interactions.Length; i++)
			{
				for (int j = 0; j < range.interactions[i].effectors.Length; j++)
				{
					InteractionObject interactionObject = range.interactions[i].interactionObject;
					Transform target = interactionObject.GetTarget(range.interactions[i].effectors[j], base.tag);
					if (target != null)
					{
						interactionTarget = target.GetComponent<InteractionTarget>();
					}
					if (!this.StartInteraction(range.interactions[i].effectors[j], interactionObject, interrupt))
					{
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00037618 File Offset: 0x00035818
		public InteractionTrigger.Range GetClosestInteractionRange()
		{
			if (!this.IsValid(true))
			{
				return null;
			}
			int closestTriggerIndex = this.GetClosestTriggerIndex();
			if (closestTriggerIndex < 0 || closestTriggerIndex >= this.triggersInRange.Count)
			{
				return null;
			}
			return this.triggersInRange[closestTriggerIndex].ranges[this.bestRangeIndexes[closestTriggerIndex]];
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0003766C File Offset: 0x0003586C
		public InteractionObject GetClosestInteractionObjectInRange()
		{
			InteractionTrigger.Range closestInteractionRange = this.GetClosestInteractionRange();
			if (closestInteractionRange == null)
			{
				return null;
			}
			return closestInteractionRange.interactions[0].interactionObject;
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00037694 File Offset: 0x00035894
		public InteractionTarget GetClosestInteractionTargetInRange()
		{
			InteractionTrigger.Range closestInteractionRange = this.GetClosestInteractionRange();
			if (closestInteractionRange == null)
			{
				return null;
			}
			return closestInteractionRange.interactions[0].interactionObject.GetTarget(closestInteractionRange.interactions[0].effectors[0], this);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x000376D0 File Offset: 0x000358D0
		public InteractionObject[] GetClosestInteractionObjectsInRange()
		{
			InteractionTrigger.Range closestInteractionRange = this.GetClosestInteractionRange();
			if (closestInteractionRange == null)
			{
				return new InteractionObject[0];
			}
			InteractionObject[] array = new InteractionObject[closestInteractionRange.interactions.Length];
			for (int i = 0; i < closestInteractionRange.interactions.Length; i++)
			{
				array[i] = closestInteractionRange.interactions[i].interactionObject;
			}
			return array;
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00037720 File Offset: 0x00035920
		public InteractionTarget[] GetClosestInteractionTargetsInRange()
		{
			InteractionTrigger.Range closestInteractionRange = this.GetClosestInteractionRange();
			if (closestInteractionRange == null)
			{
				return new InteractionTarget[0];
			}
			List<InteractionTarget> list = new List<InteractionTarget>();
			foreach (InteractionTrigger.Range.Interaction interaction in closestInteractionRange.interactions)
			{
				foreach (FullBodyBipedEffector effectorType in interaction.effectors)
				{
					list.Add(interaction.interactionObject.GetTarget(effectorType, this));
				}
			}
			return list.ToArray();
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x0003779C File Offset: 0x0003599C
		public bool TriggerEffectorsReady(int index)
		{
			if (!this.IsValid(true))
			{
				return false;
			}
			if (!this.TriggerIndexIsValid(index))
			{
				return false;
			}
			for (int i = 0; i < this.triggersInRange[index].ranges.Length; i++)
			{
				InteractionTrigger.Range range = this.triggersInRange[index].ranges[i];
				for (int j = 0; j < range.interactions.Length; j++)
				{
					for (int k = 0; k < range.interactions[j].effectors.Length; k++)
					{
						if (this.IsInInteraction(range.interactions[j].effectors[k]))
						{
							return false;
						}
					}
				}
				for (int l = 0; l < range.interactions.Length; l++)
				{
					for (int m = 0; m < range.interactions[l].effectors.Length; m++)
					{
						if (this.IsPaused(range.interactions[l].effectors[m]))
						{
							for (int n = 0; n < range.interactions[l].effectors.Length; n++)
							{
								if (n != m && !this.IsPaused(range.interactions[l].effectors[n]))
								{
									return false;
								}
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x000378D0 File Offset: 0x00035AD0
		public InteractionTrigger.Range GetTriggerRange(int index)
		{
			if (!this.IsValid(true))
			{
				return null;
			}
			if (index < 0 || index >= this.bestRangeIndexes.Count)
			{
				Warning.Log("Index out of range.", base.transform, false);
				return null;
			}
			return this.triggersInRange[index].ranges[this.bestRangeIndexes[index]];
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x0003792C File Offset: 0x00035B2C
		public int GetClosestTriggerIndex()
		{
			if (!this.IsValid(true))
			{
				return -1;
			}
			if (this.triggersInRange.Count == 0)
			{
				return -1;
			}
			if (this.triggersInRange.Count == 1)
			{
				return 0;
			}
			int result = -1;
			float num = float.PositiveInfinity;
			for (int i = 0; i < this.triggersInRange.Count; i++)
			{
				if (this.triggersInRange[i] != null)
				{
					float num2 = Vector3.SqrMagnitude(this.triggersInRange[i].transform.position - base.transform.position);
					if (num2 < num)
					{
						result = i;
						num = num2;
					}
				}
			}
			return result;
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x000379CC File Offset: 0x00035BCC
		public void StoreDefaults()
		{
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				this.interactionEffectors[i].StoreDefaults();
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600087D RID: 2173 RVA: 0x000379F9 File Offset: 0x00035BF9
		// (set) Token: 0x0600087E RID: 2174 RVA: 0x00037A01 File Offset: 0x00035C01
		public FullBodyBipedIK ik
		{
			get
			{
				return this.fullBody;
			}
			set
			{
				this.fullBody = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600087F RID: 2175 RVA: 0x00037A0A File Offset: 0x00035C0A
		// (set) Token: 0x06000880 RID: 2176 RVA: 0x00037A12 File Offset: 0x00035C12
		public List<InteractionTrigger> triggersInRange { get; private set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000881 RID: 2177 RVA: 0x00037A1B File Offset: 0x00035C1B
		// (set) Token: 0x06000882 RID: 2178 RVA: 0x00037A23 File Offset: 0x00035C23
		public bool initiated { get; private set; }

		// Token: 0x06000883 RID: 2179 RVA: 0x00037A2C File Offset: 0x00035C2C
		public void Start()
		{
			if (this.fullBody == null)
			{
				this.fullBody = base.GetComponent<FullBodyBipedIK>();
			}
			if (this.fullBody == null)
			{
				Warning.Log("InteractionSystem can not find a FullBodyBipedIK component", base.transform, false);
				return;
			}
			IKSolverFullBodyBiped solver = this.fullBody.solver;
			solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnPreFBBIK));
			IKSolverFullBodyBiped solver2 = this.fullBody.solver;
			solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostFBBIK));
			IKSolverFullBodyBiped solver3 = this.fullBody.solver;
			solver3.OnFixTransforms = (IKSolver.UpdateDelegate)Delegate.Combine(solver3.OnFixTransforms, new IKSolver.UpdateDelegate(this.OnFixTransforms));
			this.OnInteractionStart = (InteractionSystem.InteractionDelegate)Delegate.Combine(this.OnInteractionStart, new InteractionSystem.InteractionDelegate(this.LookAtInteraction));
			this.OnInteractionPause = (InteractionSystem.InteractionDelegate)Delegate.Combine(this.OnInteractionPause, new InteractionSystem.InteractionDelegate(this.InteractionPause));
			this.OnInteractionResume = (InteractionSystem.InteractionDelegate)Delegate.Combine(this.OnInteractionResume, new InteractionSystem.InteractionDelegate(this.InteractionResume));
			this.OnInteractionStop = (InteractionSystem.InteractionDelegate)Delegate.Combine(this.OnInteractionStop, new InteractionSystem.InteractionDelegate(this.InteractionStop));
			InteractionEffector[] array = this.interactionEffectors;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Initiate(this);
			}
			this.triggersInRange = new List<InteractionTrigger>();
			this.c = base.GetComponent<Collider>();
			this.UpdateTriggerEventBroadcasting();
			this.initiated = true;
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00037BC1 File Offset: 0x00035DC1
		private void InteractionPause(FullBodyBipedEffector effector, InteractionObject interactionObject)
		{
			this.lookAt.isPaused = true;
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00037BCF File Offset: 0x00035DCF
		private void InteractionResume(FullBodyBipedEffector effector, InteractionObject interactionObject)
		{
			this.lookAt.isPaused = false;
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x00037BCF File Offset: 0x00035DCF
		private void InteractionStop(FullBodyBipedEffector effector, InteractionObject interactionObject)
		{
			this.lookAt.isPaused = false;
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00037BDD File Offset: 0x00035DDD
		private void LookAtInteraction(FullBodyBipedEffector effector, InteractionObject interactionObject)
		{
			this.lookAt.Look(interactionObject.lookAtTarget, Time.time + interactionObject.length * 0.5f);
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00037C04 File Offset: 0x00035E04
		public void OnTriggerEnter(Collider c)
		{
			if (this.fullBody == null)
			{
				return;
			}
			InteractionTrigger component = c.GetComponent<InteractionTrigger>();
			if (component == null)
			{
				return;
			}
			if (this.inContact.Contains(component))
			{
				return;
			}
			this.inContact.Add(component);
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00037C4C File Offset: 0x00035E4C
		public void OnTriggerExit(Collider c)
		{
			if (this.fullBody == null)
			{
				return;
			}
			InteractionTrigger component = c.GetComponent<InteractionTrigger>();
			if (component == null)
			{
				return;
			}
			this.inContact.Remove(component);
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00037C88 File Offset: 0x00035E88
		private bool ContactIsInRange(int index, out int bestRangeIndex)
		{
			bestRangeIndex = -1;
			if (!this.IsValid(true))
			{
				return false;
			}
			if (index < 0 || index >= this.inContact.Count)
			{
				Warning.Log("Index out of range.", base.transform, false);
				return false;
			}
			if (this.inContact[index] == null)
			{
				Warning.Log("The InteractionTrigger in the list 'inContact' has been destroyed", base.transform, false);
				return false;
			}
			bestRangeIndex = this.inContact[index].GetBestRangeIndex(base.transform, this.FPSCamera, this.raycastHit);
			return bestRangeIndex != -1;
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00037D1C File Offset: 0x00035F1C
		private void OnDrawGizmosSelected()
		{
			if (Application.isPlaying)
			{
				return;
			}
			if (this.fullBody == null)
			{
				this.fullBody = base.GetComponent<FullBodyBipedIK>();
			}
			if (this.characterCollider == null)
			{
				this.characterCollider = base.GetComponent<Collider>();
			}
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00037D5C File Offset: 0x00035F5C
		public void Update()
		{
			if (this.fullBody == null)
			{
				return;
			}
			this.UpdateTriggerEventBroadcasting();
			this.Raycasting();
			this.triggersInRange.Clear();
			this.bestRangeIndexes.Clear();
			for (int i = 0; i < this.inContact.Count; i++)
			{
				int item = -1;
				if (this.inContact[i] != null && this.inContact[i].gameObject.activeInHierarchy && this.ContactIsInRange(i, out item))
				{
					this.triggersInRange.Add(this.inContact[i]);
					this.bestRangeIndexes.Add(item);
				}
			}
			this.lookAt.Update();
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00037E18 File Offset: 0x00036018
		private void Raycasting()
		{
			if (this.camRaycastLayers == -1)
			{
				return;
			}
			if (this.FPSCamera == null)
			{
				return;
			}
			Physics.Raycast(this.FPSCamera.position, this.FPSCamera.forward, out this.raycastHit, this.camRaycastDistance, this.camRaycastLayers);
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00037E78 File Offset: 0x00036078
		private void UpdateTriggerEventBroadcasting()
		{
			if (this.characterCollider == null)
			{
				this.characterCollider = this.c;
			}
			if (this.characterCollider != null && this.characterCollider != this.c)
			{
				if (this.characterCollider.GetComponent<TriggerEventBroadcaster>() == null)
				{
					this.characterCollider.gameObject.AddComponent<TriggerEventBroadcaster>().target = base.gameObject;
				}
				if (this.lastCollider != null && this.lastCollider != this.c && this.lastCollider != this.characterCollider)
				{
					TriggerEventBroadcaster component = this.lastCollider.GetComponent<TriggerEventBroadcaster>();
					if (component != null)
					{
						Object.Destroy(component);
					}
				}
			}
			this.lastCollider = this.characterCollider;
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00037F4C File Offset: 0x0003614C
		private void OnEnable()
		{
			this.lastTime = Time.time;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00037F5C File Offset: 0x0003615C
		private void UpdateEffectors()
		{
			if (this.fullBody == null)
			{
				return;
			}
			float deltaTime = Time.time - this.lastTime;
			this.lastTime = Time.time;
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				this.interactionEffectors[i].Update(base.transform, this.speed, deltaTime);
			}
			for (int j = 0; j < this.interactionEffectors.Length; j++)
			{
				this.interactionEffectors[j].ResetToDefaults(this.resetToDefaultsSpeed * this.speed, deltaTime);
			}
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00037FEC File Offset: 0x000361EC
		private void OnPreFBBIK()
		{
			if (this.fullBody == null)
			{
				return;
			}
			this.lookAt.SolveSpine();
			this.UpdateEffectors();
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00038010 File Offset: 0x00036210
		private void OnPostFBBIK()
		{
			if (this.fullBody == null)
			{
				return;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				this.interactionEffectors[i].OnPostFBBIK();
			}
			this.lookAt.SolveHead();
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00038057 File Offset: 0x00036257
		private void OnFixTransforms()
		{
			this.lookAt.OnFixTransforms();
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00038064 File Offset: 0x00036264
		private void OnDestroy()
		{
			if (this.fullBody == null)
			{
				return;
			}
			IKSolverFullBodyBiped solver = this.fullBody.solver;
			solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnPreFBBIK));
			IKSolverFullBodyBiped solver2 = this.fullBody.solver;
			solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostFBBIK));
			IKSolverFullBodyBiped solver3 = this.fullBody.solver;
			solver3.OnFixTransforms = (IKSolver.UpdateDelegate)Delegate.Remove(solver3.OnFixTransforms, new IKSolver.UpdateDelegate(this.OnFixTransforms));
			this.OnInteractionStart = (InteractionSystem.InteractionDelegate)Delegate.Remove(this.OnInteractionStart, new InteractionSystem.InteractionDelegate(this.LookAtInteraction));
			this.OnInteractionPause = (InteractionSystem.InteractionDelegate)Delegate.Remove(this.OnInteractionPause, new InteractionSystem.InteractionDelegate(this.InteractionPause));
			this.OnInteractionResume = (InteractionSystem.InteractionDelegate)Delegate.Remove(this.OnInteractionResume, new InteractionSystem.InteractionDelegate(this.InteractionResume));
			this.OnInteractionStop = (InteractionSystem.InteractionDelegate)Delegate.Remove(this.OnInteractionStop, new InteractionSystem.InteractionDelegate(this.InteractionStop));
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0003818C File Offset: 0x0003638C
		private bool IsValid(bool log)
		{
			if (this.fullBody == null)
			{
				if (log)
				{
					Warning.Log("FBBIK is null. Will not update the InteractionSystem", base.transform, false);
				}
				return false;
			}
			if (!this.initiated)
			{
				if (log)
				{
					Warning.Log("The InteractionSystem has not been initiated yet.", base.transform, false);
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x000381DC File Offset: 0x000363DC
		private bool TriggerIndexIsValid(int index)
		{
			if (index < 0 || index >= this.triggersInRange.Count)
			{
				Warning.Log("Index out of range.", base.transform, false);
				return false;
			}
			if (this.triggersInRange[index] == null)
			{
				Warning.Log("The InteractionTrigger in the list 'inContact' has been destroyed", base.transform, false);
				return false;
			}
			return true;
		}

		// Token: 0x040007CF RID: 1999
		[Tooltip("If not empty, only the targets with the specified tag will be used by this Interaction System.")]
		public string targetTag = "";

		// Token: 0x040007D0 RID: 2000
		[Tooltip("The fade in time of the interaction.")]
		public float fadeInTime = 0.3f;

		// Token: 0x040007D1 RID: 2001
		[Tooltip("The master speed for all interactions.")]
		public float speed = 1f;

		// Token: 0x040007D2 RID: 2002
		[Tooltip("If > 0, lerps all the FBBIK channels used by the Interaction System back to their default or initial values when not in interaction.")]
		public float resetToDefaultsSpeed = 1f;

		// Token: 0x040007D3 RID: 2003
		[Header("Triggering")]
		[Tooltip("The collider that registers OnTriggerEnter and OnTriggerExit events with InteractionTriggers.")]
		[FormerlySerializedAs("collider")]
		public Collider characterCollider;

		// Token: 0x040007D4 RID: 2004
		[Tooltip("Will be used by Interaction Triggers that need the camera's position. Assign the first person view character camera.")]
		[FormerlySerializedAs("camera")]
		public Transform FPSCamera;

		// Token: 0x040007D5 RID: 2005
		[Tooltip("The layers that will be raycasted from the camera (along camera.forward). All InteractionTrigger look at target colliders should be included.")]
		public LayerMask camRaycastLayers;

		// Token: 0x040007D6 RID: 2006
		[Tooltip("Max distance of raycasting from the camera.")]
		public float camRaycastDistance = 1f;

		// Token: 0x040007D8 RID: 2008
		private List<InteractionTrigger> inContact = new List<InteractionTrigger>();

		// Token: 0x040007D9 RID: 2009
		private List<int> bestRangeIndexes = new List<int>();

		// Token: 0x040007DA RID: 2010
		public InteractionSystem.InteractionDelegate OnInteractionStart;

		// Token: 0x040007DB RID: 2011
		public InteractionSystem.InteractionDelegate OnInteractionPause;

		// Token: 0x040007DC RID: 2012
		public InteractionSystem.InteractionDelegate OnInteractionPickUp;

		// Token: 0x040007DD RID: 2013
		public InteractionSystem.InteractionDelegate OnInteractionResume;

		// Token: 0x040007DE RID: 2014
		public InteractionSystem.InteractionDelegate OnInteractionStop;

		// Token: 0x040007DF RID: 2015
		public InteractionSystem.InteractionEventDelegate OnInteractionEvent;

		// Token: 0x040007E0 RID: 2016
		public RaycastHit raycastHit;

		// Token: 0x040007E1 RID: 2017
		[Space(10f)]
		[Tooltip("Reference to the FBBIK component.")]
		[SerializeField]
		private FullBodyBipedIK fullBody;

		// Token: 0x040007E2 RID: 2018
		[Tooltip("Handles looking at the interactions.")]
		public InteractionLookAt lookAt = new InteractionLookAt();

		// Token: 0x040007E3 RID: 2019
		private InteractionEffector[] interactionEffectors = new InteractionEffector[]
		{
			new InteractionEffector(FullBodyBipedEffector.Body),
			new InteractionEffector(FullBodyBipedEffector.LeftFoot),
			new InteractionEffector(FullBodyBipedEffector.LeftHand),
			new InteractionEffector(FullBodyBipedEffector.LeftShoulder),
			new InteractionEffector(FullBodyBipedEffector.LeftThigh),
			new InteractionEffector(FullBodyBipedEffector.RightFoot),
			new InteractionEffector(FullBodyBipedEffector.RightHand),
			new InteractionEffector(FullBodyBipedEffector.RightShoulder),
			new InteractionEffector(FullBodyBipedEffector.RightThigh)
		};

		// Token: 0x040007E5 RID: 2021
		private Collider lastCollider;

		// Token: 0x040007E6 RID: 2022
		private Collider c;

		// Token: 0x040007E7 RID: 2023
		private float lastTime;

		// Token: 0x020000F9 RID: 249
		// (Invoke) Token: 0x06000899 RID: 2201
		public delegate void InteractionDelegate(FullBodyBipedEffector effectorType, InteractionObject interactionObject);

		// Token: 0x020000FA RID: 250
		// (Invoke) Token: 0x0600089D RID: 2205
		public delegate void InteractionEventDelegate(FullBodyBipedEffector effectorType, InteractionObject interactionObject, InteractionObject.InteractionEvent interactionEvent);
	}
}
