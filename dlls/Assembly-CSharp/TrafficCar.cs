using System;
using System.Linq;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class TrafficCar : MonoBehaviour
{
	// Token: 0x06000057 RID: 87 RVA: 0x00006228 File Offset: 0x00004428
	private Transform GetTransformWheel(string wheelName)
	{
		GameObject[] array = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name.Equals(wheelName) && g.transform.parent.root == this.transform
		select g).ToArray<GameObject>();
		if (array.Length != 0)
		{
			return array[0].transform;
		}
		return null;
	}

	// Token: 0x06000058 RID: 88 RVA: 0x000062A4 File Offset: 0x000044A4
	public void Configure()
	{
		if (!this.wheelsTransforms.frontRight)
		{
			this.wheelsTransforms.frontRight = this.GetTransformWheel("FR");
		}
		if (!this.wheelsTransforms.frontLeft)
		{
			this.wheelsTransforms.frontLeft = this.GetTransformWheel("FL");
		}
		if (!this.wheelsTransforms.backRight)
		{
			this.wheelsTransforms.backRight = this.GetTransformWheel("BR");
		}
		if (!this.wheelsTransforms.backLeft)
		{
			this.wheelsTransforms.backLeft = this.GetTransformWheel("BL");
		}
		if (!this.wheelsTransforms.backRight2)
		{
			this.wheelsTransforms.backRight2 = base.transform.Find("BR2");
		}
		if (!this.wheelsTransforms.backLeft2)
		{
			this.wheelsTransforms.backLeft2 = base.transform.Find("BL2");
		}
		if (!base.transform.GetComponent<Rigidbody>())
		{
			base.transform.gameObject.AddComponent<Rigidbody>();
		}
		if (base.transform.gameObject.GetComponent<Rigidbody>().mass < 4000f)
		{
			base.transform.gameObject.GetComponent<Rigidbody>().mass = 4000f;
		}
		float z = this.wheelsTransforms.frontRight.localPosition.z + 0.6f;
		if (!base.transform.Find("RayC"))
		{
			this.mRayC = new GameObject("RayC").transform;
			this.mRayC.SetParent(base.transform);
			this.mRayC.localRotation = Quaternion.identity;
			this.mRayC.localPosition = new Vector3(0f, 0.5f, z);
		}
		else if (!this.mRayC)
		{
			this.mRayC = base.transform.Find("RayC");
		}
		this.carSetting.maxSteerAngle = (float)((int)Mathf.Clamp(Vector3.Distance(this.wheelsTransforms.frontRight.transform.position, this.wheelsTransforms.backRight.transform.position) * 12f, 35f, 72f));
		this.wheel = new Transform[4];
		this.wCollider = new WheelCollider[4];
		GameObject gameObject = new GameObject("Center");
		Vector3[] array = new Vector3[4];
		Vector3 a = new Vector3(0f, 0f, 0f);
		this.wheel[0] = this.wheelsTransforms.frontRight;
		this.wheel[1] = this.wheelsTransforms.frontLeft;
		this.wheel[2] = this.wheelsTransforms.backRight;
		this.wheel[3] = this.wheelsTransforms.backLeft;
		for (int i = 0; i < 4; i++)
		{
			this.wCollider[i] = this.SetWheelComponent(i);
			gameObject.transform.SetParent(this.wheel[i].transform);
			gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
			gameObject.transform.SetParent(base.transform);
			array[i] = (gameObject.transform.localPosition -= new Vector3(0f, this.wCollider[i].radius, 0f));
			a += array[i];
		}
		this.shiftCentre = a / 4f;
		Object.DestroyImmediate(gameObject);
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00006660 File Offset: 0x00004860
	private void Start()
	{
		if (this.path)
		{
			this.Init(this.path);
		}
	}

	// Token: 0x0600005A RID: 90 RVA: 0x0000667C File Offset: 0x0000487C
	public void Init(GameObject pth)
	{
		this.path = pth;
		this.myRigidbody = base.transform.GetComponent<Rigidbody>();
		this.myRigidbody.centerOfMass = this.shiftCentre;
		this.atualWay = this.path;
		this.atualWayScript = this.atualWay.GetComponent<FCGWaypointsContainer>();
		this.DefineNewPath();
		this.currentNode = 1;
		this.distance = Vector3.Distance(this.nodes[this.currentNode].position, base.transform.position);
		base.InvokeRepeating("MoveCar", 0.02f, 0.02f);
	}

	// Token: 0x0600005B RID: 91 RVA: 0x0000671C File Offset: 0x0000491C
	private WheelCollider SetWheelComponent(int w)
	{
		if (base.transform.Find(this.wheel[w].name + " - WheelCollider"))
		{
			Object.DestroyImmediate(base.transform.Find(this.wheel[w].name + " - WheelCollider").gameObject);
		}
		GameObject gameObject = new GameObject(this.wheel[w].name + " - WheelCollider");
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.position = this.wheel[w].position;
		gameObject.transform.eulerAngles = base.transform.eulerAngles;
		WheelCollider wheelCollider = (WheelCollider)gameObject.AddComponent(typeof(WheelCollider));
		WheelCollider component = gameObject.GetComponent<WheelCollider>();
		JointSpring suspensionSpring = wheelCollider.suspensionSpring;
		suspensionSpring.spring = this.carSetting.springs;
		suspensionSpring.damper = this.carSetting.dampers;
		wheelCollider.suspensionSpring = suspensionSpring;
		wheelCollider.suspensionDistance = 0.05f;
		wheelCollider.radius = this.wheel[w].GetComponent<MeshFilter>().sharedMesh.bounds.size.z * this.wheel[w].transform.localScale.z * 0.5f;
		wheelCollider.mass = 1500f;
		return component;
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00006884 File Offset: 0x00004A84
	private void DefineNewPath()
	{
		this.nodes = new Transform[this.atualWay.transform.childCount];
		int num = 0;
		foreach (object obj in this.atualWay.transform)
		{
			Transform transform = (Transform)obj;
			this.nodes[num++] = transform;
		}
		this.countWays = this.nodes.Length;
		this.currentNode = 0;
	}

	// Token: 0x0600005D RID: 93 RVA: 0x0000691C File Offset: 0x00004B1C
	private void MoveCar()
	{
		this.relativeVector = base.transform.InverseTransformPoint(this.nodes[this.currentNode].position);
		this.steer = this.relativeVector.x / this.relativeVector.magnitude * this.carSetting.maxSteerAngle;
		this.speed = this.myRigidbody.velocity.magnitude * 3.6f;
		this.mRayC.localRotation = Quaternion.Euler(new Vector3(0f, this.steer, 0f));
		this.VerificaPoints();
		this.iRC += 1f;
		if (this.iRC >= 6f)
		{
			this.brake = this.FixedRaycasts();
			this.iRC = 0f;
		}
		if (this.speed < 1f)
		{
			this.timeStoped += Time.deltaTime;
			if (this.timeStoped > 60f)
			{
				Object.Destroy(base.transform.gameObject);
			}
		}
		else
		{
			this.timeStoped = 0f;
		}
		float num = 0f;
		for (int i = 0; i < 4; i++)
		{
			if (this.speed > this.carSetting.limitSpeed)
			{
				num = Mathf.Lerp(100f, 1000f, (this.speed - this.carSetting.limitSpeed) / 10f);
			}
			if (num > this.brake)
			{
				this.brake = num;
			}
			if (this.brake == 0f)
			{
				this.wCollider[i].brakeTorque = 0f;
			}
			else
			{
				this.wCollider[i].motorTorque = 0f;
				this.wCollider[i].brakeTorque = this.carSetting.brakePower * this.brake;
			}
			if (i < 2)
			{
				this.motorTorque = Mathf.Lerp(this.carSetting.carPower * 30f, 0f, this.speed / this.carSetting.limitSpeed);
				this.wCollider[i].motorTorque = this.motorTorque;
				this.wCollider[i].steerAngle = this.steer;
			}
			Vector3 position;
			Quaternion rotation;
			this.wCollider[i].GetWorldPose(out position, out rotation);
			this.wheel[i].position = position;
			this.wheel[i].rotation = rotation;
		}
		if (this.wheelsTransforms.backRight2)
		{
			this.wheelsTransforms.backRight2.rotation = this.wheelsTransforms.backRight.rotation;
			this.wheelsTransforms.backLeft2.rotation = this.wheelsTransforms.backRight.rotation;
		}
		if (this.carSetting.carSteer)
		{
			this.carSetting.carSteer.localEulerAngles = new Vector3(this.steerCurAngle.x, this.steerCurAngle.y, this.steerCurAngle.z - this.steer);
		}
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00006C2C File Offset: 0x00004E2C
	private void VerificaPoints()
	{
		if (this.distance < 5f)
		{
			if (this.currentNode < this.countWays - 1)
			{
				this.currentNode++;
			}
			else
			{
				this.atualWay = this.atualWayScript.nextWay[Random.Range(0, this.atualWayScript.nextWay.Length)];
				this.atualWayScript = this.atualWay.GetComponent<FCGWaypointsContainer>();
				this.DefineNewPath();
			}
		}
		this.distance = Vector3.Distance(this.nodes[this.currentNode].position, base.transform.position);
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00006CCC File Offset: 0x00004ECC
	private float FixedRaycasts()
	{
		int num = 6;
		float result = 0f;
		this.mRayC.localRotation = Quaternion.Euler(new Vector3(0f, this.steer, 0f));
		Debug.DrawRay(this.mRayC.position, this.mRayC.forward * (float)num, Color.yellow);
		RaycastHit raycastHit;
		if (Physics.Raycast(this.mRayC.position, this.mRayC.forward, out raycastHit, (float)num))
		{
			Debug.DrawRay(this.mRayC.position, this.mRayC.forward * (float)num, Color.red);
			result = 6000f / raycastHit.distance;
		}
		return result;
	}

	// Token: 0x0400007F RID: 127
	private float timeStoped;

	// Token: 0x04000080 RID: 128
	public GameObject path;

	// Token: 0x04000081 RID: 129
	public GameObject atualWay;

	// Token: 0x04000082 RID: 130
	[HideInInspector]
	public Transform mRayC;

	// Token: 0x04000083 RID: 131
	[HideInInspector]
	public Transform[] wheel;

	// Token: 0x04000084 RID: 132
	public WheelCollider[] wCollider;

	// Token: 0x04000085 RID: 133
	private int countWays;

	// Token: 0x04000086 RID: 134
	private Transform[] nodes;

	// Token: 0x04000087 RID: 135
	public int currentNode;

	// Token: 0x04000088 RID: 136
	private float distance;

	// Token: 0x04000089 RID: 137
	private float steer;

	// Token: 0x0400008A RID: 138
	private float speed;

	// Token: 0x0400008B RID: 139
	private float brake;

	// Token: 0x0400008C RID: 140
	private float motorTorque;

	// Token: 0x0400008D RID: 141
	private Vector3 steerCurAngle = Vector3.zero;

	// Token: 0x0400008E RID: 142
	private Rigidbody myRigidbody;

	// Token: 0x0400008F RID: 143
	private FCGWaypointsContainer atualWayScript;

	// Token: 0x04000090 RID: 144
	private Vector3 relativeVector;

	// Token: 0x04000091 RID: 145
	public TrafficCar.CarWheelsTransform wheelsTransforms;

	// Token: 0x04000092 RID: 146
	private FCGWaypointsContainer fcgWaypointsContainer;

	// Token: 0x04000093 RID: 147
	public TrafficCar.CarSetting carSetting;

	// Token: 0x04000094 RID: 148
	private Vector3 shiftCentre = new Vector3(0f, -0.05f, 0f);

	// Token: 0x04000095 RID: 149
	private float iRC;

	// Token: 0x02000013 RID: 19
	[Serializable]
	public class CarWheelsTransform
	{
		// Token: 0x04000096 RID: 150
		public Transform frontRight;

		// Token: 0x04000097 RID: 151
		public Transform frontLeft;

		// Token: 0x04000098 RID: 152
		public Transform backRight;

		// Token: 0x04000099 RID: 153
		public Transform backLeft;

		// Token: 0x0400009A RID: 154
		public Transform backRight2;

		// Token: 0x0400009B RID: 155
		public Transform backLeft2;
	}

	// Token: 0x02000014 RID: 20
	[Serializable]
	public class CarSetting
	{
		// Token: 0x0400009C RID: 156
		public bool showNormalGizmos;

		// Token: 0x0400009D RID: 157
		public Transform carSteer;

		// Token: 0x0400009E RID: 158
		[Range(10000f, 60000f)]
		public float springs = 25000f;

		// Token: 0x0400009F RID: 159
		[Range(1000f, 6000f)]
		public float dampers = 1500f;

		// Token: 0x040000A0 RID: 160
		[Range(60f, 200f)]
		public float carPower = 120f;

		// Token: 0x040000A1 RID: 161
		[Range(5f, 10f)]
		public float brakePower = 8f;

		// Token: 0x040000A2 RID: 162
		[Range(20f, 30f)]
		public float limitSpeed = 30f;

		// Token: 0x040000A3 RID: 163
		[Range(30f, 72f)]
		public float maxSteerAngle = 40f;
	}
}
