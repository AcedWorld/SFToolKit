using System;
using Rewired;
using UnityEngine;

// Token: 0x020000A8 RID: 168
public class ObjectSpawner : MonoBehaviour
{
	// Token: 0x060002C5 RID: 709 RVA: 0x00016158 File Offset: 0x00014358
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		Vector3[] positions = new Vector3[]
		{
			Vector3.zero,
			Vector3.zero
		};
		this.laserLineRenderer.SetPositions(positions);
		this.laserLineRenderer.startWidth = this.laserWidth;
		this.laserLineRenderer.endWidth = this.laserWidth;
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x000161C8 File Offset: 0x000143C8
	private void Update()
	{
		if (this.player.GetButtonLongPress("R1"))
		{
			this.spawnMode = true;
		}
		if (this.player.GetButtonUp("R1"))
		{
			this.spawnMode = false;
		}
		if (this.player.GetButtonLongPress("L1"))
		{
			this.removeMode = true;
		}
		if (this.player.GetButtonUp("L1"))
		{
			this.removeMode = false;
		}
		if (this.spawnMode)
		{
			if (Physics.Raycast(base.transform.position, base.transform.TransformDirection(Vector3.down), out this.hit, float.PositiveInfinity, this.layerMask))
			{
				Debug.DrawRay(base.transform.position, base.transform.TransformDirection(Vector3.down) * this.hit.distance, Color.yellow);
				if (this.spawnedObject != null)
				{
					this.spawnedObject.transform.position = this.hit.point;
					Quaternion rhs = new Quaternion(0f, base.transform.rotation.y, 0f, base.transform.rotation.w);
					Quaternion rotation = Quaternion.FromToRotation(Vector3.up, this.hit.normal) * rhs;
					this.spawnedObject.transform.rotation = rotation;
				}
			}
			else
			{
				Debug.DrawRay(base.transform.position, base.transform.TransformDirection(Vector3.down) * 1000f, Color.white);
			}
		}
		if (this.trigger != this.spawnMode)
		{
			this.ToggleSpawn();
			this.trigger = this.spawnMode;
		}
		if (this.removeTrigger != this.removeMode)
		{
			this.ToggleRemove();
			this.removeTrigger = this.removeMode;
		}
		RaycastHit raycastHit;
		if (this.removeMode && Physics.Raycast(this.laserStartPos.position, this.laserStartPos.TransformDirection(Vector3.forward), out raycastHit, float.PositiveInfinity, this.layerMask))
		{
			this.laserLineRenderer.enabled = true;
			this.ShootLaserFromTargetPosition(this.laserStartPos.position, raycastHit.point, raycastHit.distance);
			if (this.spawnedRemoveTool != null)
			{
				this.spawnedRemoveTool.transform.position = raycastHit.point;
				Quaternion rhs2 = new Quaternion(0f, base.transform.rotation.y, 0f, base.transform.rotation.w);
				Quaternion rotation2 = Quaternion.FromToRotation(Vector3.up, raycastHit.normal) * rhs2;
				this.spawnedRemoveTool.transform.rotation = rotation2;
				this.ObjectInLaser = raycastHit.collider.gameObject;
			}
		}
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x000164B4 File Offset: 0x000146B4
	public void ToggleSpawn()
	{
		if (this.spawnMode)
		{
			this.clearToSpawn = true;
			this.spawnedObject = Object.Instantiate<GameObject>(this.transparentObject, this.hit.point, base.transform.rotation);
		}
		if (!this.spawnMode)
		{
			this.SpawnObject();
			Object.Destroy(this.spawnedObject);
			this.spawnedObject = null;
		}
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x00016518 File Offset: 0x00014718
	public void ToggleRemove()
	{
		if (this.removeMode)
		{
			this.spawnedRemoveTool = Object.Instantiate<GameObject>(this.removalTool, this.hit.point, base.transform.rotation);
		}
		if (!this.removeMode)
		{
			this.laserLineRenderer.enabled = false;
			this.RemoveGameObject();
			Object.Destroy(this.spawnedRemoveTool);
			this.spawnedRemoveTool = null;
		}
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x00016580 File Offset: 0x00014780
	public void RemoveGameObject()
	{
		if (this.ObjectInLaser.tag == "ObjectSpawner")
		{
			Object.Destroy(this.ObjectInLaser.transform.parent.gameObject);
		}
	}

	// Token: 0x060002CA RID: 714 RVA: 0x000165B3 File Offset: 0x000147B3
	public void SpawnObject()
	{
		if (this.clearToSpawn)
		{
			Object.Instantiate<GameObject>(this.objectToSpawn, this.spawnedObject.transform.position, this.spawnedObject.transform.rotation);
		}
	}

	// Token: 0x060002CB RID: 715 RVA: 0x000165E9 File Offset: 0x000147E9
	private void ShootLaserFromTargetPosition(Vector3 StartPostition, Vector3 EndPosition, float length)
	{
		this.laserLineRenderer.SetPosition(0, StartPostition);
		this.laserLineRenderer.SetPosition(1, EndPosition);
	}

	// Token: 0x04000377 RID: 887
	private int playerId;

	// Token: 0x04000378 RID: 888
	private Player player;

	// Token: 0x04000379 RID: 889
	public Transform camTarget;

	// Token: 0x0400037A RID: 890
	public bool spawnMode;

	// Token: 0x0400037B RID: 891
	public bool removeMode;

	// Token: 0x0400037C RID: 892
	public bool clearToSpawn;

	// Token: 0x0400037D RID: 893
	public LayerMask layerMask;

	// Token: 0x0400037E RID: 894
	private RaycastHit hit;

	// Token: 0x0400037F RID: 895
	public GameObject transparentObject;

	// Token: 0x04000380 RID: 896
	public GameObject objectToSpawn;

	// Token: 0x04000381 RID: 897
	public GameObject spawnedObject;

	// Token: 0x04000382 RID: 898
	public Transform laserStartPos;

	// Token: 0x04000383 RID: 899
	public LineRenderer laserLineRenderer;

	// Token: 0x04000384 RID: 900
	public float laserWidth;

	// Token: 0x04000385 RID: 901
	public GameObject removalTool;

	// Token: 0x04000386 RID: 902
	private GameObject spawnedRemoveTool;

	// Token: 0x04000387 RID: 903
	private bool trigger;

	// Token: 0x04000388 RID: 904
	private bool removeTrigger;

	// Token: 0x04000389 RID: 905
	public GameObject ObjectInLaser;
}
