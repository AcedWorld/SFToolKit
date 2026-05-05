using System;
using System.Linq;
using UnityEngine;

// Token: 0x02000019 RID: 25
public class TrafficSystem : MonoBehaviour
{
	// Token: 0x0600006D RID: 109 RVA: 0x000070E3 File Offset: 0x000052E3
	private void Awake()
	{
		if (GameObject.Find("RoadMark") && GameObject.Find("RoadMarkRev"))
		{
			this.InverseCarDirection(true);
		}
		this.LoadCars(this.intenseTraffic);
	}

	// Token: 0x0600006E RID: 110 RVA: 0x0000711C File Offset: 0x0000531C
	private void InverseCarDirection(bool actualside)
	{
		GameObject[] array = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name.Equals("Road-Mark")
		select g).ToArray<GameObject>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].transform.Find("RoadMark").gameObject.SetActive(actualside);
		}
		array = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name.Equals("Road-Mark-Rev")
		select g).ToArray<GameObject>();
		for (int j = 0; j < array.Length; j++)
		{
			array[j].transform.Find("RoadMarkRev").gameObject.SetActive(!actualside);
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x0000723C File Offset: 0x0000543C
	public void LoadCars(bool intenseTraffic = false)
	{
		int num = 0;
		Object.DestroyImmediate(GameObject.Find("CarContainer"));
		Transform transform = new GameObject("CarContainer").transform;
		FCGWaypointsContainer[] array = (from g in Object.FindObjectsOfType(typeof(FCGWaypointsContainer))
		select g as FCGWaypointsContainer).ToArray<FCGWaypointsContainer>();
		int num2 = array.Length;
		for (int i = 0; i < num2; i++)
		{
			FCGWaypointsContainer component = array[i].GetComponent<FCGWaypointsContainer>();
			GameObject gameObject = Object.Instantiate<GameObject>(this.IaCars[Mathf.Clamp(Random.Range(0, this.IaCars.Length), 0, this.IaCars.Length - 1)], component.waypoints[0].transform.position, component.waypoints[0].transform.rotation);
			gameObject.transform.SetParent(transform);
			gameObject.GetComponent<TrafficCar>().path = array[i].gameObject;
			num++;
			if (intenseTraffic && Vector3.Distance(component.waypoints[0].transform.position, component.waypoints[1].transform.position) > 50f)
			{
				GameObject gameObject2 = Object.Instantiate<GameObject>(this.IaCars[Mathf.Clamp(Random.Range(0, this.IaCars.Length), 0, this.IaCars.Length - 1)], Vector3.Lerp(component.waypoints[0].transform.position, component.waypoints[1].transform.position, 0.4f), component.waypoints[0].transform.rotation);
				gameObject2.transform.SetParent(transform);
				gameObject2.GetComponent<TrafficCar>().path = array[i].gameObject;
				num++;
			}
		}
		Debug.Log(num.ToString() + " vehicles were instantiated");
	}

	// Token: 0x040000B3 RID: 179
	public GameObject[] IaCars;

	// Token: 0x040000B4 RID: 180
	public bool intenseTraffic;
}
