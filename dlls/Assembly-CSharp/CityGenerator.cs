using System;
using System.Linq;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class CityGenerator : MonoBehaviour
{
	// Token: 0x0600002A RID: 42 RVA: 0x000033AC File Offset: 0x000015AC
	public void GenerateStreetsVerySmall()
	{
		if (!this.cityMaker)
		{
			this.cityMaker = GameObject.Find("City-Maker");
		}
		if (this.cityMaker)
		{
			Object.DestroyImmediate(this.cityMaker);
		}
		this.cityMaker = new GameObject("City-Maker");
		this.distCenter = 150f;
		int maxExclusive = this.largeBlocks.Length;
		int num = Random.Range(0, maxExclusive);
		Object.Instantiate<GameObject>(this.largeBlocks[num], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f), this.cityMaker.transform);
		this.center = new Vector3(0f, 0f, 0f);
		Object.Instantiate<GameObject>(this.miniBorder, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f), this.cityMaker.transform).transform.SetParent(this.cityMaker.transform);
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000034CC File Offset: 0x000016CC
	public void GenerateStreetsSmall()
	{
		if (!this.cityMaker)
		{
			this.cityMaker = GameObject.Find("City-Maker");
		}
		if (this.cityMaker)
		{
			Object.DestroyImmediate(this.cityMaker);
		}
		this.cityMaker = new GameObject("City-Maker");
		this.distCenter = 200f;
		int num = 0;
		int maxExclusive = this.largeBlocks.Length;
		this._largeBlocks = new bool[this.largeBlocks.Length];
		Vector3[] array = new Vector3[3];
		int[] array2 = new int[3];
		if (Random.Range(0f, 6f) < 3f)
		{
			array[1] = new Vector3(0f, 0f, 0f);
			array2[1] = 0;
			array[2] = new Vector3(0f, 0f, 300f);
			array2[2] = 0;
		}
		else
		{
			array[1] = new Vector3(-150f, 0f, 150f);
			array2[1] = 90;
			array[2] = new Vector3(150f, 0f, 150f);
			array2[2] = 90;
		}
		for (int i = 1; i < 3; i++)
		{
			for (int j = 0; j < 100; j++)
			{
				num = Random.Range(0, maxExclusive);
				if (!this._largeBlocks[num])
				{
					break;
				}
			}
			this._largeBlocks[num] = true;
			Object.Instantiate<GameObject>(this.largeBlocks[num], array[i], Quaternion.Euler(0f, (float)array2[i], 0f), this.cityMaker.transform);
		}
		this.center = array[Random.Range(1, 2)];
		Object.Instantiate<GameObject>(this.smallBorder, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f), this.cityMaker.transform).transform.SetParent(this.cityMaker.transform);
	}

	// Token: 0x0600002C RID: 44 RVA: 0x000036C4 File Offset: 0x000018C4
	public void GenerateStreets()
	{
		if (!this.cityMaker)
		{
			this.cityMaker = GameObject.Find("City-Maker");
		}
		if (this.cityMaker)
		{
			Object.DestroyImmediate(this.cityMaker);
		}
		this.cityMaker = new GameObject("City-Maker");
		this.distCenter = 300f;
		int num = 0;
		int maxExclusive = this.largeBlocks.Length;
		this._largeBlocks = new bool[this.largeBlocks.Length];
		Vector3[] array = new Vector3[5];
		int[] array2 = new int[5];
		float num2 = Random.Range(0f, 6f);
		if (num2 < 2f)
		{
			array[1] = new Vector3(0f, 0f, 0f);
			array2[1] = 0;
			array[2] = new Vector3(0f, 0f, 300f);
			array2[2] = 0;
			array[3] = new Vector3(450f, 0f, 150f);
			array2[3] = 90;
			array[4] = new Vector3(-450f, 0f, 150f);
			array2[4] = 90;
		}
		else if (num2 < 3f)
		{
			array[1] = new Vector3(-450f, 0f, 150f);
			array2[1] = 90;
			array[2] = new Vector3(-150f, 0f, 150f);
			array2[2] = 90;
			array[3] = new Vector3(150f, 0f, 150f);
			array2[3] = 90;
			array[4] = new Vector3(450f, 0f, 150f);
			array2[4] = 90;
		}
		else if (num2 < 4f)
		{
			array[1] = new Vector3(-450f, 0f, 150f);
			array2[1] = 90;
			array[2] = new Vector3(-150f, 0f, 150f);
			array2[2] = 90;
			array[3] = new Vector3(300f, 0f, 0f);
			array2[3] = 0;
			array[4] = new Vector3(300f, 0f, 300f);
			array2[4] = 0;
		}
		else
		{
			array[1] = new Vector3(450f, 0f, 150f);
			array2[1] = 90;
			array[2] = new Vector3(150f, 0f, 150f);
			array2[2] = 90;
			array[3] = new Vector3(-300f, 0f, 0f);
			array2[3] = 0;
			array[4] = new Vector3(-300f, 0f, 300f);
			array2[4] = 0;
		}
		for (int i = 1; i < 5; i++)
		{
			for (int j = 0; j < 100; j++)
			{
				num = Random.Range(0, maxExclusive);
				if (!this._largeBlocks[num])
				{
					break;
				}
			}
			this._largeBlocks[num] = true;
			Object.Instantiate<GameObject>(this.largeBlocks[num], array[i], Quaternion.Euler(0f, (float)array2[i], 0f), this.cityMaker.transform);
		}
		this.center = array[Random.Range(1, 4)];
		Object.Instantiate<GameObject>(this.mediumBorder, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f), this.cityMaker.transform).transform.SetParent(this.cityMaker.transform);
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00003A60 File Offset: 0x00001C60
	public void GenerateStreetsBig()
	{
		if (!this.cityMaker)
		{
			this.cityMaker = GameObject.Find("City-Maker");
		}
		if (this.cityMaker)
		{
			Object.DestroyImmediate(this.cityMaker);
		}
		this.cityMaker = new GameObject("City-Maker");
		this.distCenter = 350f;
		int num = 0;
		int maxExclusive = this.largeBlocks.Length;
		this._largeBlocks = new bool[this.largeBlocks.Length];
		Vector3[] array = new Vector3[7];
		int[] array2 = new int[7];
		float num2 = Random.Range(0f, 6f);
		if (num2 < 3f)
		{
			array[1] = new Vector3(0f, 0f, 0f);
			array2[1] = 0;
			array[2] = new Vector3(0f, 0f, 300f);
			array2[2] = 0;
			array[3] = new Vector3(450f, 0f, 150f);
			array2[3] = 90;
			array[4] = new Vector3(-450f, 0f, 150f);
			array2[4] = 90;
			array[5] = new Vector3(-300f, 0f, 600f);
			array2[5] = 0;
			array[6] = new Vector3(300f, 0f, 600f);
			array2[6] = 0;
		}
		else if (num2 < 3f)
		{
			array[1] = new Vector3(-450f, 0f, 150f);
			array2[1] = 90;
			array[2] = new Vector3(-150f, 0f, 150f);
			array2[2] = 90;
			array[3] = new Vector3(150f, 0f, 150f);
			array2[3] = 90;
			array[4] = new Vector3(450f, 0f, 150f);
			array2[4] = 90;
			array[5] = new Vector3(-300f, 0f, 600f);
			array2[5] = 0;
			array[6] = new Vector3(300f, 0f, 600f);
			array2[6] = 0;
		}
		else if (num2 < 4f)
		{
			array[1] = new Vector3(-300f, 0f, 300f);
			array2[1] = 0;
			array[2] = new Vector3(-300f, 0f, 0f);
			array2[2] = 0;
			array[3] = new Vector3(150f, 0f, 150f);
			array2[3] = 90;
			array[4] = new Vector3(450f, 0f, 150f);
			array2[4] = 90;
			array[5] = new Vector3(-300f, 0f, 600f);
			array2[5] = 0;
			array[6] = new Vector3(300f, 0f, 600f);
			array2[6] = 0;
		}
		else
		{
			array[1] = new Vector3(-450f, 0f, 150f);
			array2[1] = 90;
			array[2] = new Vector3(300f, 0f, 0f);
			array2[2] = 0;
			array[3] = new Vector3(-150f, 0f, 150f);
			array2[3] = 90;
			array[4] = new Vector3(450f, 0f, 450f);
			array2[4] = 90;
			array[5] = new Vector3(-300f, 0f, 600f);
			array2[5] = 0;
			array[6] = new Vector3(150f, 0f, 450f);
			array2[6] = 90;
		}
		for (int i = 1; i < 7; i++)
		{
			for (int j = 0; j < 100; j++)
			{
				num = Random.Range(0, maxExclusive);
				if (!this._largeBlocks[num])
				{
					break;
				}
			}
			this._largeBlocks[num] = true;
			Object.Instantiate<GameObject>(this.largeBlocks[num], array[i], Quaternion.Euler(0f, (float)array2[i], 0f), this.cityMaker.transform);
		}
		this.center = array[Random.Range(1, 6)];
		Object.Instantiate<GameObject>(this.largeBorder, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f), this.cityMaker.transform).transform.SetParent(this.cityMaker.transform);
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00003EF8 File Offset: 0x000020F8
	public void GenerateAllBuildings()
	{
		this._BB = new int[this.BB.Length];
		this._BC = new int[this.BC.Length];
		this._BR = new int[this.BR.Length];
		this._EB = new int[this.EB.Length];
		this._EC = new int[this.EC.Length];
		this._MB = new int[this.MB.Length];
		this._BK = new int[this.BK.Length];
		this._SB = new int[this.SB.Length];
		this.residential = 0;
		this.DestroyBuildings();
		Object obj = new GameObject();
		this.nB = 0;
		this.CreateBuildingsInSuperBlocks();
		this.CreateBuildingsInBlocks();
		this.CreateBuildingsInLines();
		this.CreateBuildingsInDouble();
		Debug.ClearDeveloperConsole();
		Debug.Log(this.nB.ToString() + " buildings were created");
		Object.DestroyImmediate(obj);
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00003FF4 File Offset: 0x000021F4
	public void CreateBuildingsInLines()
	{
		this.tempArray = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name == "Marcador"
		select g).ToArray<GameObject>();
		foreach (GameObject gameObject in this.tempArray)
		{
			this._residential = (this.residential < 15 && Vector3.Distance(this.center, gameObject.transform.position) > 400f && Random.Range(0, 100) < 30);
			foreach (object obj in gameObject.transform)
			{
				Transform transform = (Transform)obj;
				if (transform.name == "E")
				{
					this.CreateBuildingsInCorners(transform.gameObject);
				}
				else
				{
					this.CreateBuildingsInLine(transform.gameObject, 90f);
				}
			}
			this._residential = false;
		}
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00004144 File Offset: 0x00002344
	public void CreateBuildingsInCorners(GameObject child)
	{
		this.pB = null;
		int i = 0;
		float num = 0f;
		float num2 = Vector3.Distance(this.center, child.transform.position);
		int num3 = 0;
		while (i < 100)
		{
			i++;
			if (num2 < this.distCenter)
			{
				int num4;
				do
				{
					num3++;
					num4 = Random.Range(0, this.EC.Length);
				}
				while (this._EC[num4] != 0 && (num3 <= 100 || this._EC[num4] > 1) && (num3 <= 150 || this._EC[num4] > 2) && (num3 <= 200 || this._EC[num4] > 3) && num3 <= 250 && num3 < 300);
				num = this.GetWith(this.EC[num4]);
				if (num <= 36.05f)
				{
					this._EC[num4]++;
					this.pB = this.EC[num4];
					break;
				}
			}
			else
			{
				int num4;
				do
				{
					num3++;
					num4 = Random.Range(0, this.EB.Length);
				}
				while (this._EB[num4] != 0 && (num3 <= 100 || this._EB[num4] > 1) && (num3 <= 150 || this._EB[num4] > 2) && (num3 <= 200 || this._EB[num4] > 2) && num3 <= 250 && num3 < 300);
				num = this.GetWith(this.EB[num4]);
				if (num <= 36.05f)
				{
					this._EB[num4]++;
					this.pB = this.EB[num4];
					break;
				}
			}
		}
		GameObject gameObject = Object.Instantiate<GameObject>(this.pB, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
		gameObject.name = gameObject.name;
		gameObject.transform.SetParent(child.transform);
		gameObject.transform.localPosition = new Vector3(-(num * 0.5f), 0f, 0f);
		gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		this.nB++;
		float height = this.GetHeight(this.pB);
		float num5;
		float num6;
		if (height < 29.9f)
		{
			GameObject gameObject2 = new GameObject("Marcador");
			gameObject2.transform.SetParent(child.transform);
			gameObject2.transform.localPosition = new Vector3(0f, 0f, -36f);
			gameObject2.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			gameObject2.name = (36f - height).ToString();
			this.CreateBuildingsInLine(gameObject2, 90f);
		}
		else
		{
			num5 = 36f - height;
			num6 = 1f + num5 / height;
			gameObject.transform.localScale = new Vector3(1f, 1f, num6);
		}
		if (num < 29.9f)
		{
			GameObject gameObject2 = new GameObject("Marcador");
			gameObject2.transform.SetParent(child.transform);
			gameObject2.transform.localPosition = new Vector3(-num, 0f, 0f);
			gameObject2.transform.localRotation = Quaternion.Euler(0f, 270f, 0f);
			gameObject2.name = (36f - num).ToString();
			this.CreateBuildingsInLine(gameObject2, 90f);
			return;
		}
		num5 = 36f - num;
		num6 = 1f + num5 / num;
		gameObject.transform.localScale = new Vector3(num6, 1f, 1f);
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00004514 File Offset: 0x00002714
	private int RandRotation()
	{
		int num = Random.Range(0, 4);
		int result;
		if (num == 3)
		{
			result = 180;
		}
		else if (num == 2)
		{
			result = 90;
		}
		else if (num == 1)
		{
			result = 270;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00004550 File Offset: 0x00002750
	public void CreateBuildingsInBlocks()
	{
		this.tempArray = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name == "Blocks"
		select g).ToArray<GameObject>();
		GameObject[] array = this.tempArray;
		for (int i = 0; i < array.Length; i++)
		{
			foreach (object obj in array[i].transform)
			{
				Transform transform = (Transform)obj;
				if (Random.Range(0, 20) > 5)
				{
					int num = 0;
					int num2;
					do
					{
						num++;
						num2 = Random.Range(0, this.BK.Length);
					}
					while (this._BK[num2] != 0 && (num <= 125 || this._BK[num2] > 1) && (num <= 150 || this._BK[num2] > 2) && (num <= 200 || this._BK[num2] > 3) && num <= 250 && num < 300);
					this._BK[num2]++;
					Object.Instantiate<GameObject>(this.BK[num2], transform.position, transform.rotation, transform);
					this.nB++;
				}
				else
				{
					for (int j = 1; j <= 4; j++)
					{
						GameObject gameObject = new GameObject("E");
						gameObject.transform.SetParent(transform);
						if (j == 1)
						{
							gameObject.transform.localPosition = new Vector3(-36f, 0f, -36f);
							gameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
						}
						if (j == 2)
						{
							gameObject.transform.localPosition = new Vector3(-36f, 0f, 36f);
							gameObject.transform.localRotation = Quaternion.Euler(0f, 270f, 0f);
						}
						if (j == 3)
						{
							gameObject.transform.localPosition = new Vector3(36f, 0f, 36f);
							gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
						}
						if (j == 4)
						{
							gameObject.transform.localPosition = new Vector3(36f, 0f, -36f);
							gameObject.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
						}
						this.CreateBuildingsInCorners(gameObject);
					}
				}
			}
		}
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00004844 File Offset: 0x00002A44
	public void CreateBuildingsInSuperBlocks()
	{
		this.tempArray = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name == "SuperBlocks"
		select g).ToArray<GameObject>();
		GameObject[] array = this.tempArray;
		for (int i = 0; i < array.Length; i++)
		{
			foreach (object obj in array[i].transform)
			{
				Transform transform = (Transform)obj;
				int num = 0;
				int num2;
				do
				{
					num++;
					num2 = Random.Range(0, this.SB.Length);
				}
				while (this._SB[num2] != 0 && (num <= 125 || this._SB[num2] > 1) && (num <= 150 || this._SB[num2] > 2) && (num <= 200 || this._SB[num2] > 3) && num <= 250 && num < 300);
				this._SB[num2]++;
				Object.Instantiate<GameObject>(this.SB[num2], transform.position, transform.rotation, transform);
				this.nB++;
			}
		}
	}

	// Token: 0x06000034 RID: 52 RVA: 0x000049CC File Offset: 0x00002BCC
	private void CreateBuildingsInLine(GameObject line, float angulo)
	{
		int num = -1;
		GameObject[] array = new GameObject[50];
		float num2;
		if (line.name.Contains("."))
		{
			num2 = float.Parse(line.name.Split('.', StringSplitOptions.None)[0]) + float.Parse(line.name.Split('.', StringSplitOptions.None)[1]) / float.Parse("1" + "0000000".Substring(0, line.name.Split('.', StringSplitOptions.None)[1].Length));
		}
		else
		{
			num2 = float.Parse(line.name);
		}
		float num3 = 0f;
		float num4 = 0f;
		int i = 0;
		float num5 = Vector3.Distance(this.center, line.transform.position);
		while (i < 100)
		{
			i++;
			int num6 = 0;
			int num7 = 0;
			while (num6 < 200 && num3 <= num2 - 4f)
			{
				num6++;
				if (num5 < this.distCenter)
				{
					do
					{
						num7++;
						this.numB = Random.Range(0, this.BC.Length);
					}
					while (this._BC[this.numB] != 0 && (num7 <= 125 || this._BC[this.numB] > 1) && (num7 <= 150 || this._BC[this.numB] > 2) && (num7 <= 200 || this._BC[this.numB] > 3) && num7 <= 250 && num7 < 300);
					num4 = this.GetWith(this.BC[this.numB]);
					if (num3 + num4 <= num2 + 4f)
					{
						this.pB = this.BC[this.numB];
						this._BC[this.numB]++;
						break;
					}
				}
				else if (this._residential)
				{
					do
					{
						num7++;
						this.numB = Random.Range(0, this.BR.Length);
					}
					while (this._BR[this.numB] != 0 && (num7 <= 100 || this._BR[this.numB] > 1) && (num7 <= 150 || this._BR[this.numB] > 2) && (num7 <= 200 || this._BR[this.numB] > 3) && num7 <= 250 && num7 < 300);
					num4 = this.GetWith(this.BR[this.numB]);
					if (num3 + num4 <= num2 + 4f)
					{
						this.pB = this.BR[this.numB];
						this._BR[this.numB]++;
						this.residential++;
						break;
					}
				}
				else
				{
					do
					{
						num7++;
						this.numB = Random.Range(0, this.BB.Length);
					}
					while (this._BB[this.numB] != 0 && (num7 <= 100 || this._BB[this.numB] > 1) && (num7 <= 150 || this._BB[this.numB] > 2) && (num7 <= 200 || this._BB[this.numB] > 3) && num7 <= 250 && num7 < 300);
					num4 = this.GetWith(this.BB[this.numB]);
					if (num3 + num4 <= num2 + 4f)
					{
						this.pB = this.BB[this.numB];
						this._BB[this.numB]++;
						break;
					}
				}
			}
			if (num6 >= 200 || num3 > num2 - 4f)
			{
				this.AdjustsWidth(array, num + 1, num2 - num3, 0f);
				return;
			}
			num++;
			array[num] = Object.Instantiate<GameObject>(this.pB, new Vector3(0f, 0f, num3 + num4 * 0.5f), Quaternion.Euler(0f, angulo, 0f));
			this.nB++;
			array[num].name = array[num].name;
			array[num].transform.SetParent(line.transform);
			array[num].transform.localPosition = new Vector3(0f, 0f, num3 + num4 * 0.5f);
			array[num].transform.localRotation = Quaternion.Euler(0f, angulo, 0f);
			num3 += num4;
			if (num3 > num2 - 6f)
			{
				this.AdjustsWidth(array, num + 1, num2 - num3, 0f);
			}
		}
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00004E64 File Offset: 0x00003064
	private void CreateBuildingsInDoubleLine(GameObject line)
	{
		int num = -1;
		GameObject[] array = new GameObject[20];
		float num2 = float.Parse(line.name);
		float num3 = 0f;
		float num4 = 0f;
		int i = 0;
		while (i < 100)
		{
			i++;
			int num5 = 0;
			int num6 = 0;
			while (num5 < 200 && num3 <= num2 - 4f)
			{
				num5++;
				do
				{
					num6++;
					this.numB = Random.Range(0, this.MB.Length);
				}
				while (this._MB[this.numB] != 0 && (num6 <= 100 || this._MB[this.numB] > 1) && (num6 <= 150 || this._MB[this.numB] > 2) && num6 <= 200 && num6 < 300);
				num4 = this.GetWith(this.MB[this.numB]);
				if (num3 + num4 <= num2 + 4f)
				{
					this._MB[this.numB]++;
					break;
				}
			}
			if (num5 >= 200 || num3 > num2 - 4f)
			{
				this.AdjustsWidth(array, num + 1, num2 - num3, 0f);
				return;
			}
			num++;
			array[num] = Object.Instantiate<GameObject>(this.MB[this.numB], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 90f, 0f), line.transform);
			this.nB++;
			array[num].name = "building";
			array[num].transform.SetParent(line.transform);
			array[num].transform.localPosition = new Vector3(0f, 0f, num3 + num4 * 0.5f);
			array[num].transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
			num3 += num4;
			if (num3 > num2 - 6f)
			{
				this.AdjustsWidth(array, num + 1, num2 - num3, 0f);
			}
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x0000507C File Offset: 0x0000327C
	private void CreateBuildingsInDouble()
	{
		this.tempArray = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name == "Double"
		select g).ToArray<GameObject>();
		GameObject[] array = this.tempArray;
		for (int i = 0; i < array.Length; i++)
		{
			foreach (object obj in array[i].transform)
			{
				Transform transform = (Transform)obj;
				float num = float.Parse(transform.name);
				if (Random.Range(0, 10) < 5)
				{
					float height;
					do
					{
						this.numB = Random.Range(0, this.DC.Length);
						height = this.GetHeight(this.DC[this.numB]);
					}
					while (height > num / 2f);
					Object.Instantiate<GameObject>(this.DC[this.numB], transform.transform.position, transform.transform.rotation, transform.transform);
					this.nB++;
					float height2;
					do
					{
						this.numB = Random.Range(0, this.DC.Length);
						height2 = this.GetHeight(this.DC[this.numB]);
					}
					while (height2 > num - (height + 26f));
					GameObject gameObject = Object.Instantiate<GameObject>(this.DC[this.numB], transform.transform.position, transform.rotation, transform.transform);
					gameObject.transform.SetParent(transform.transform);
					gameObject.transform.localPosition = new Vector3(0f, 0f, -num);
					gameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
					GameObject gameObject2 = new GameObject((num - height - height2).ToString() ?? "");
					gameObject2.transform.SetParent(transform.transform);
					gameObject2.transform.localPosition = new Vector3(0f, 0f, -(num - height2));
					gameObject2.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
					gameObject2.name = ((num - height - height2).ToString() ?? "");
					this.CreateBuildingsInDoubleLine(gameObject2);
				}
				else
				{
					GameObject gameObject3 = new GameObject("Marcador");
					gameObject3.transform.SetParent(transform);
					gameObject3.transform.localPosition = new Vector3(0f, 0f, 0f);
					gameObject3.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
					GameObject gameObject4;
					for (int j = 1; j <= 4; j++)
					{
						gameObject4 = new GameObject("E");
						gameObject4.transform.SetParent(gameObject3.transform);
						if (j == 1)
						{
							gameObject4.transform.localPosition = new Vector3(36f, 0f, -num);
							gameObject4.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
						}
						if (j == 2)
						{
							gameObject4.transform.localPosition = new Vector3(36f, 0f, 0f);
							gameObject4.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
						}
						if (j == 3)
						{
							gameObject4.transform.localPosition = new Vector3(-36f, 0f, 0f);
							gameObject4.transform.localRotation = Quaternion.Euler(0f, 270f, 0f);
						}
						if (j == 4)
						{
							gameObject4.transform.localPosition = new Vector3(-36f, 0f, -num);
							gameObject4.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
						}
						this.CreateBuildingsInCorners(gameObject4);
					}
					gameObject4 = new GameObject((num - 72f).ToString() ?? "");
					gameObject4.transform.SetParent(gameObject3.transform);
					gameObject4.transform.localPosition = new Vector3(-36f, 0.001f, -36f);
					gameObject4.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
					this.CreateBuildingsInLine(gameObject4, 90f);
					gameObject4 = new GameObject((num - 72f).ToString() ?? "");
					gameObject4.transform.SetParent(gameObject3.transform);
					gameObject4.transform.localPosition = new Vector3(36f, 0.001f, -(num - 36f));
					gameObject4.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
					this.CreateBuildingsInLine(gameObject4, 90f);
				}
			}
		}
	}

	// Token: 0x06000037 RID: 55 RVA: 0x000055D4 File Offset: 0x000037D4
	private void AdjustsWidth(GameObject[] tBuildings, int quantity, float remainingMeters, float init)
	{
		if (remainingMeters == 0f)
		{
			return;
		}
		float num = remainingMeters / (float)quantity;
		float num2 = init;
		for (int i = 0; i < quantity; i++)
		{
			float with = this.GetWith(tBuildings[i]);
			if (with > 0f)
			{
				float x = 1f + num / with;
				float num3 = with + num;
				tBuildings[i].transform.localPosition = new Vector3(tBuildings[i].transform.localPosition.x, tBuildings[i].transform.localPosition.y, num2 + num3 * 0.5f);
				tBuildings[i].transform.localScale = new Vector3(x, 1f, 1f);
				num2 += num3;
			}
		}
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00005694 File Offset: 0x00003894
	private float GetWith(GameObject building)
	{
		if (building.transform.GetComponent<MeshFilter>() != null)
		{
			return building.transform.GetComponent<MeshFilter>().sharedMesh.bounds.size.x;
		}
		Debug.LogError("Error:  " + building.name + " does not have a mesh renderer at the root. The prefab must be the floor/base mesh. I nside it you place the building. More info im https://youtu.be/kVrWir_WjNY");
		return 0f;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x000056F8 File Offset: 0x000038F8
	private float GetHeight(GameObject building)
	{
		if (building.GetComponent<MeshFilter>() != null)
		{
			return building.GetComponent<MeshFilter>().sharedMesh.bounds.size.z;
		}
		Debug.LogError("Error:  " + building.name + " does not have a mesh renderer at the root. The prefab must be the floor/base mesh. I nside it you place the building. More info im https://youtu.be/kVrWir_WjNY");
		return 0f;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00005750 File Offset: 0x00003950
	public void DestroyBuildings()
	{
		this.tempArray = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name == "Marcador"
		select g).ToArray<GameObject>();
		for (int i = 1; i < 8; i++)
		{
			GameObject[] array = this.tempArray;
			for (int j = 0; j < array.Length; j++)
			{
				foreach (object obj in array[j].transform)
				{
					Transform transform = (Transform)obj;
					this.DestryObjetcs2(transform.gameObject, "All");
				}
			}
		}
		this.tempArray = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name == "Blocks"
		select g).ToArray<GameObject>();
		for (int k = 1; k < 8; k++)
		{
			GameObject[] array = this.tempArray;
			for (int j = 0; j < array.Length; j++)
			{
				foreach (object obj2 in array[j].transform)
				{
					Transform transform2 = (Transform)obj2;
					this.DestryObjetcs2(transform2.gameObject, "All");
				}
			}
		}
		this.tempArray = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name == "SuperBlocks"
		select g).ToArray<GameObject>();
		for (int l = 1; l < 8; l++)
		{
			GameObject[] array = this.tempArray;
			for (int j = 0; j < array.Length; j++)
			{
				foreach (object obj3 in array[j].transform)
				{
					Transform transform3 = (Transform)obj3;
					this.DestryObjetcs2(transform3.gameObject, "All");
				}
			}
		}
		this.tempArray = (from g in Object.FindObjectsOfType(typeof(GameObject))
		select g as GameObject into g
		where g.name == "Double"
		select g).ToArray<GameObject>();
		for (int m = 1; m < 8; m++)
		{
			GameObject[] array = this.tempArray;
			for (int j = 0; j < array.Length; j++)
			{
				foreach (object obj4 in array[j].transform)
				{
					Transform transform4 = (Transform)obj4;
					this.DestryObjetcs2(transform4.gameObject, "All");
				}
			}
		}
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00005AE0 File Offset: 0x00003CE0
	private void DestryObjetcs2(GameObject line, string nameObj)
	{
		foreach (object obj in line.transform)
		{
			Transform transform = (Transform)obj;
			if (nameObj == "All")
			{
				Object.DestroyImmediate(transform.gameObject);
			}
			else if (transform.name == nameObj)
			{
				Object.DestroyImmediate(transform.gameObject);
			}
		}
	}

	// Token: 0x0400004A RID: 74
	private int nB;

	// Token: 0x0400004B RID: 75
	private Vector3 center;

	// Token: 0x0400004C RID: 76
	private int residential;

	// Token: 0x0400004D RID: 77
	private bool _residential;

	// Token: 0x0400004E RID: 78
	private GameObject cityMaker;

	// Token: 0x0400004F RID: 79
	[HideInInspector]
	public GameObject miniBorder;

	// Token: 0x04000050 RID: 80
	[HideInInspector]
	public GameObject smallBorder;

	// Token: 0x04000051 RID: 81
	[HideInInspector]
	public GameObject largeBorder;

	// Token: 0x04000052 RID: 82
	[HideInInspector]
	public GameObject mediumBorder;

	// Token: 0x04000053 RID: 83
	[HideInInspector]
	public GameObject[] largeBlocks;

	// Token: 0x04000054 RID: 84
	private bool[] _largeBlocks;

	// Token: 0x04000055 RID: 85
	[HideInInspector]
	public GameObject[] BB;

	// Token: 0x04000056 RID: 86
	[HideInInspector]
	public GameObject[] BC;

	// Token: 0x04000057 RID: 87
	[HideInInspector]
	public GameObject[] BR;

	// Token: 0x04000058 RID: 88
	[HideInInspector]
	public GameObject[] DC;

	// Token: 0x04000059 RID: 89
	[HideInInspector]
	public GameObject[] EB;

	// Token: 0x0400005A RID: 90
	[HideInInspector]
	public GameObject[] EC;

	// Token: 0x0400005B RID: 91
	[HideInInspector]
	public GameObject[] MB;

	// Token: 0x0400005C RID: 92
	[HideInInspector]
	public GameObject[] BK;

	// Token: 0x0400005D RID: 93
	[HideInInspector]
	public GameObject[] SB;

	// Token: 0x0400005E RID: 94
	private int[] _BB;

	// Token: 0x0400005F RID: 95
	private int[] _BC;

	// Token: 0x04000060 RID: 96
	private int[] _BR;

	// Token: 0x04000061 RID: 97
	private int[] _EB;

	// Token: 0x04000062 RID: 98
	private int[] _EC;

	// Token: 0x04000063 RID: 99
	private int[] _MB;

	// Token: 0x04000064 RID: 100
	private int[] _BK;

	// Token: 0x04000065 RID: 101
	private int[] _SB;

	// Token: 0x04000066 RID: 102
	private GameObject[] tempArray;

	// Token: 0x04000067 RID: 103
	private int numB;

	// Token: 0x04000068 RID: 104
	private float distCenter = 300f;

	// Token: 0x04000069 RID: 105
	private GameObject pB;
}
