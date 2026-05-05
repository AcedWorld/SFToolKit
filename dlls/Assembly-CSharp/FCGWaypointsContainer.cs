using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200001C RID: 28
public class FCGWaypointsContainer : MonoBehaviour
{
	// Token: 0x0600007B RID: 123 RVA: 0x00007554 File Offset: 0x00005754
	private void Awake()
	{
		this.inLeft = GameObject.Find("RoadMarkRev");
		this.tf01IDX = GameObject.Find("traffic-idx");
		if (!this.tf01IDX)
		{
			this.tf01IDX = new GameObject("traffic-idx");
			this.tf01IDX.AddComponent<Tf01>();
		}
		if (this.tf01IDX)
		{
			this.tf01 = this.tf01IDX.GetComponent<Tf01>().getTF01();
		}
		for (int i = 0; i < this.waypoints.Count; i++)
		{
			if (i < this.waypoints.Count - 1)
			{
				this.waypoints[i].LookAt(this.waypoints[i + 1]);
			}
			else
			{
				this.waypoints[i].rotation = Quaternion.LookRotation(this.waypoints[i].position - this.waypoints[i - 1].position);
				this.NextWays(this.waypoints[i]);
			}
		}
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00007670 File Offset: 0x00005870
	private void NextWays(Transform referencia)
	{
		int num = this.tf01.Length;
		if (num < 1)
		{
			return;
		}
		this.arr.Clear();
		for (int i = 0; i < num; i++)
		{
			float num2 = Vector3.Distance(referencia.position, this.tf01[i].position);
			if (num2 < 35f && num2 > 8f)
			{
				float angulo = this.GetAngulo(referencia, this.tf01[i]);
				if ((!this.inLeft && (angulo > 340f || angulo < 80f)) || (this.inLeft && (angulo > 280f || angulo < 20f)))
				{
					this.arr.Add(this.tf01[i]);
				}
			}
		}
		int count = this.arr.Count;
		this.nextWay = new GameObject[count];
		if (count < 1)
		{
			return;
		}
		for (int j = 0; j < count; j++)
		{
			Transform transform = (Transform)this.arr[j];
			this.nextWay[j] = transform.parent.gameObject;
		}
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00007784 File Offset: 0x00005984
	private void AddNewWays(ArrayList arr)
	{
		this.nextWay = new GameObject[arr.Count];
		for (int i = 0; i < arr.Count; i++)
		{
			Transform transform = (Transform)arr[i];
			this.nextWay[i] = transform.parent.gameObject;
		}
	}

	// Token: 0x0600007E RID: 126 RVA: 0x000077D4 File Offset: 0x000059D4
	private float GetAngulo(Transform origem, Transform target)
	{
		GameObject gameObject = new GameObject("Compass");
		gameObject.transform.parent = origem;
		gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
		gameObject.transform.LookAt(target);
		float y = gameObject.transform.localEulerAngles.y;
		Object.Destroy(gameObject);
		return y;
	}

	// Token: 0x0600007F RID: 127 RVA: 0x0000783C File Offset: 0x00005A3C
	public void InvertNodesDirection()
	{
		Vector3 position = new Vector3(0f, 0f, 0f);
		int num = Mathf.CeilToInt((float)(this.waypoints.Count / 2));
		for (int i = 0; i < num; i++)
		{
			position = this.waypoints[i].position;
			this.waypoints[i].position = this.waypoints[this.waypoints.Count - i - 1].position;
			this.waypoints[this.waypoints.Count - i - 1].position = position;
		}
	}

	// Token: 0x06000080 RID: 128 RVA: 0x000078E4 File Offset: 0x00005AE4
	private void OnDrawGizmos()
	{
		if (this.waypoints.Count < 1)
		{
			return;
		}
		for (int i = 0; i < this.waypoints.Count; i++)
		{
			Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
			if (this.waypoints.Count < 1)
			{
				return;
			}
			Gizmos.DrawSphere(this.waypoints[i].transform.position, 1f);
			Gizmos.DrawWireSphere(this.waypoints[i].transform.position, 2f);
			if (this.waypoints.Count < 2)
			{
				return;
			}
			if (i < this.waypoints.Count - 1)
			{
				if (this.waypoints[i] && this.waypoints[i + 1] && this.waypoints.Count > 0 && i < this.waypoints.Count - 1)
				{
					Gizmos.DrawLine(this.waypoints[i].position, this.waypoints[i + 1].position);
					this.waypoints[i].LookAt(this.waypoints[i + 1]);
				}
			}
			else if (i == this.waypoints.Count - 1)
			{
				this.waypoints[i].rotation = this.waypoints[i - 1].rotation;
			}
		}
	}

	// Token: 0x040000BD RID: 189
	public List<Transform> waypoints = new List<Transform>();

	// Token: 0x040000BE RID: 190
	public GameObject[] nextWay;

	// Token: 0x040000BF RID: 191
	private bool inLeft;

	// Token: 0x040000C0 RID: 192
	public Transform[] tf01;

	// Token: 0x040000C1 RID: 193
	private ArrayList arr = new ArrayList();

	// Token: 0x040000C2 RID: 194
	private GameObject tf01IDX;
}
