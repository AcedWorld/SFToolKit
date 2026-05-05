using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200009C RID: 156
	public class FingerRig : SolverManager
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0001CB5A File Offset: 0x0001AD5A
		// (set) Token: 0x060004AF RID: 1199 RVA: 0x0001CB62 File Offset: 0x0001AD62
		public bool initiated { get; private set; }

		// Token: 0x060004B0 RID: 1200 RVA: 0x0001CB6C File Offset: 0x0001AD6C
		public bool IsValid(ref string errorMessage)
		{
			Finger[] array = this.fingers;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].IsValid(ref errorMessage))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0001CB9C File Offset: 0x0001AD9C
		[ContextMenu("Auto-detect")]
		public void AutoDetect()
		{
			this.fingers = new Finger[0];
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform[] array = new Transform[0];
				this.AddChildrenRecursive(base.transform.GetChild(i), ref array);
				if (array.Length == 3 || array.Length == 4)
				{
					Finger finger = new Finger();
					finger.bone1 = array[0];
					finger.bone2 = array[1];
					if (array.Length == 3)
					{
						finger.tip = array[2];
					}
					else
					{
						finger.bone3 = array[2];
						finger.tip = array[3];
					}
					finger.weight = 1f;
					Array.Resize<Finger>(ref this.fingers, this.fingers.Length + 1);
					this.fingers[this.fingers.Length - 1] = finger;
				}
			}
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0001CC68 File Offset: 0x0001AE68
		public void AddFinger(Transform bone1, Transform bone2, Transform bone3, Transform tip, Transform target = null)
		{
			Finger finger = new Finger();
			finger.bone1 = bone1;
			finger.bone2 = bone2;
			finger.bone3 = bone3;
			finger.tip = tip;
			finger.target = target;
			Array.Resize<Finger>(ref this.fingers, this.fingers.Length + 1);
			this.fingers[this.fingers.Length - 1] = finger;
			this.initiated = false;
			finger.Initiate(base.transform, this.fingers.Length - 1);
			if (this.fingers[this.fingers.Length - 1].initiated)
			{
				this.initiated = true;
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0001CD04 File Offset: 0x0001AF04
		public void RemoveFinger(int index)
		{
			if ((float)index < 0f || index >= this.fingers.Length)
			{
				Warning.Log("RemoveFinger index out of bounds.", base.transform, false);
				return;
			}
			if (this.fingers.Length == 1)
			{
				this.fingers = new Finger[0];
				return;
			}
			Finger[] array = new Finger[this.fingers.Length - 1];
			int num = 0;
			for (int i = 0; i < this.fingers.Length; i++)
			{
				if (i != index)
				{
					array[num] = this.fingers[i];
					num++;
				}
			}
			this.fingers = array;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0001CD8E File Offset: 0x0001AF8E
		private void AddChildrenRecursive(Transform parent, ref Transform[] array)
		{
			Array.Resize<Transform>(ref array, array.Length + 1);
			array[array.Length - 1] = parent;
			if (parent.childCount != 1)
			{
				return;
			}
			this.AddChildrenRecursive(parent.GetChild(0), ref array);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0001CDC0 File Offset: 0x0001AFC0
		protected override void InitiateSolver()
		{
			this.initiated = true;
			for (int i = 0; i < this.fingers.Length; i++)
			{
				this.fingers[i].Initiate(base.transform, i);
				if (!this.fingers[i].initiated)
				{
					this.initiated = false;
				}
			}
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0001CE14 File Offset: 0x0001B014
		public void UpdateFingerSolvers()
		{
			Finger[] array = this.fingers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Update(this.weight);
			}
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0001CE44 File Offset: 0x0001B044
		public void FixFingerTransforms()
		{
			if (this.weight <= 0f)
			{
				return;
			}
			Finger[] array = this.fingers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FixTransforms();
			}
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0001CE7C File Offset: 0x0001B07C
		public void StoreDefaultLocalState()
		{
			Finger[] array = this.fingers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].StoreDefaultLocalState();
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0001CEA6 File Offset: 0x0001B0A6
		protected override void UpdateSolver()
		{
			this.UpdateFingerSolvers();
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0001CEAE File Offset: 0x0001B0AE
		protected override void FixTransforms()
		{
			if (this.weight <= 0f)
			{
				return;
			}
			this.FixFingerTransforms();
		}

		// Token: 0x04000437 RID: 1079
		[Tooltip("The master weight for all fingers.")]
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x04000438 RID: 1080
		public Finger[] fingers = new Finger[0];
	}
}
