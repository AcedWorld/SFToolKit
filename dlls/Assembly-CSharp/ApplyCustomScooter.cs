using System;
using UnityEngine;

// Token: 0x0200011D RID: 285
public class ApplyCustomScooter : MonoBehaviour
{
	// Token: 0x0600049F RID: 1183 RVA: 0x0001FF06 File Offset: 0x0001E106
	private void Start()
	{
		this.LoadAndApplyScooter();
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x0001FF10 File Offset: 0x0001E110
	public void LoadAndApplyScooter()
	{
		this.customScooterSlot = this.customScootersAsset.activeSlot;
		Debug.Log(this.customScootersAsset.activeSlot.ToString() + "THIS IS THE ACTIVE SLOT");
		Debug.Log(this.customScooterSlot.ToString() + "THIS IS THE CUSTOM SLOT");
		if (this.partsLibrary == null || this.customScootersAsset == null)
		{
			Debug.LogWarning("[ApplyCustomScooter] Missing assets: assign partsLibrary and customScootersAsset.");
			return;
		}
		if (this.customScooterSlot < 1 || this.customScooterSlot > 3)
		{
			Debug.LogWarning("[ApplyCustomScooter] customScooterSlot must be 1..3. Using 1.");
			this.customScooterSlot = 1;
		}
		CustomScooterData data = null;
		switch (this.customScooterSlot)
		{
		case 1:
			data = this.customScootersAsset.scooter1;
			break;
		case 2:
			data = this.customScootersAsset.scooter2;
			break;
		case 3:
			data = this.customScootersAsset.scooter3;
			break;
		}
		if (data == null)
		{
			Debug.LogWarning(string.Format("[ApplyCustomScooter] Slot {0} is empty.", this.customScooterSlot));
			return;
		}
		DeckData deckData = string.IsNullOrEmpty(data.deck) ? null : this.partsLibrary.decks.Find((DeckData d) => d.deckName == data.deck);
		BarsData barsData = string.IsNullOrEmpty(data.bars) ? null : this.partsLibrary.bars.Find((BarsData d) => d.barsName == data.bars);
		ForksData forksData = string.IsNullOrEmpty(data.fork) ? null : this.partsLibrary.forks.Find((ForksData d) => d.forksName == data.fork);
		ClampData clampData = string.IsNullOrEmpty(data.clamp) ? null : this.partsLibrary.clamps.Find((ClampData d) => d.clampName == data.clamp);
		FrontWheelData frontWheelData = string.IsNullOrEmpty(data.frontWheel) ? null : this.partsLibrary.frontWheels.Find((FrontWheelData d) => d.wheelName == data.frontWheel);
		RearWheelData rearWheelData = string.IsNullOrEmpty(data.rearWheel) ? null : this.partsLibrary.rearWheels.Find((RearWheelData d) => d.wheelName == data.rearWheel);
		GripsData gripsData = string.IsNullOrEmpty(data.grips) ? null : this.partsLibrary.grips.Find((GripsData d) => d.gripsName == data.grips);
		BarEndsData barEndsData = string.IsNullOrEmpty(data.barEnds) ? null : this.partsLibrary.barEnds.Find((BarEndsData d) => d.barEndsName == data.barEnds);
		HeadsetData headsetData = string.IsNullOrEmpty(data.headset) ? null : this.partsLibrary.headsets.Find((HeadsetData d) => d.headsetName == data.headset);
		GripTapeData gripTapeData = string.IsNullOrEmpty(data.gripTape) ? null : this.partsLibrary.gripTapes.Find((GripTapeData d) => d.gripTapeName == data.gripTape);
		PegsData pegsData = string.IsNullOrEmpty(data.pegs) ? null : this.partsLibrary.pegs.Find((PegsData d) => d.pegsName == data.pegs);
		if (deckData != null)
		{
			if (this.myScooterParts.deck && deckData.deckMesh)
			{
				this.myScooterParts.deck.GetComponent<MeshFilter>().mesh = deckData.deckMesh;
			}
			if (this.myScooterParts.deck && deckData.deckMaterial)
			{
				this.myScooterParts.deck.GetComponent<MeshRenderer>().material = deckData.deckMaterial;
			}
			if (this.myScooterParts.brake && deckData.brakeMesh)
			{
				this.myScooterParts.brake.GetComponent<MeshFilter>().mesh = deckData.brakeMesh;
			}
			this.myScooterParts.brake.GetComponent<MeshRenderer>().material = deckData.deckMaterial;
			if (this.myScooterParts.gripTape && deckData.gripTapeMesh)
			{
				this.myScooterParts.gripTape.GetComponent<MeshFilter>().mesh = deckData.gripTapeMesh;
			}
		}
		if (this.myScooterParts.gripTape && gripTapeData != null && gripTapeData.gripTapeTexture != null)
		{
			MeshRenderer component = this.myScooterParts.gripTape.GetComponent<MeshRenderer>();
			if (component && component.material)
			{
				if (component.material.HasProperty("_BaseMap"))
				{
					component.material.SetTexture("_BaseMap", gripTapeData.gripTapeTexture);
				}
				else if (component.material.HasProperty("_MainTex"))
				{
					component.material.SetTexture("_MainTex", gripTapeData.gripTapeTexture);
				}
			}
		}
		if (barsData != null)
		{
			if (this.myScooterParts.bars && barsData.barsMesh)
			{
				this.myScooterParts.bars.GetComponent<MeshFilter>().mesh = barsData.barsMesh;
			}
			if (this.myScooterParts.bars && barsData.barsMaterial)
			{
				this.myScooterParts.bars.GetComponent<MeshRenderer>().material = barsData.barsMaterial;
			}
		}
		if (forksData != null)
		{
			if (this.myScooterParts.forks && forksData.forksMesh)
			{
				this.myScooterParts.forks.GetComponent<MeshFilter>().mesh = forksData.forksMesh;
			}
			if (this.myScooterParts.forks && forksData.forksMaterial)
			{
				this.myScooterParts.forks.GetComponent<MeshRenderer>().material = forksData.forksMaterial;
			}
		}
		if (clampData != null)
		{
			if (this.myScooterParts.clamp && clampData.clampMesh)
			{
				this.myScooterParts.clamp.GetComponent<MeshFilter>().mesh = clampData.clampMesh;
			}
			if (this.myScooterParts.clamp && clampData.clampMaterial)
			{
				this.myScooterParts.clamp.GetComponent<MeshRenderer>().material = clampData.clampMaterial;
			}
		}
		if (frontWheelData != null)
		{
			if (this.myScooterParts.frontWheel && frontWheelData.wheelMesh)
			{
				this.myScooterParts.frontWheel.GetComponent<MeshFilter>().mesh = frontWheelData.wheelMesh;
			}
			if (this.myScooterParts.frontWheel && frontWheelData.hubMaterial)
			{
				this.myScooterParts.frontWheel.GetComponent<MeshRenderer>().material = frontWheelData.hubMaterial;
			}
			if (this.myScooterParts.frontTyre && frontWheelData.tyreMaterial)
			{
				this.myScooterParts.frontTyre.GetComponent<MeshRenderer>().material = frontWheelData.tyreMaterial;
			}
		}
		if (rearWheelData != null)
		{
			if (this.myScooterParts.rearWheel && rearWheelData.wheelMesh)
			{
				this.myScooterParts.rearWheel.GetComponent<MeshFilter>().mesh = rearWheelData.wheelMesh;
			}
			if (this.myScooterParts.rearWheel && rearWheelData.hubMaterial)
			{
				this.myScooterParts.rearWheel.GetComponent<MeshRenderer>().material = rearWheelData.hubMaterial;
			}
			if (this.myScooterParts.rearTyre && rearWheelData.tyreMaterial)
			{
				this.myScooterParts.rearTyre.GetComponent<MeshRenderer>().material = rearWheelData.tyreMaterial;
			}
		}
		if (gripsData != null)
		{
			if (this.myScooterParts.leftGrip && gripsData.leftGripMesh)
			{
				this.myScooterParts.leftGrip.GetComponent<MeshFilter>().mesh = gripsData.leftGripMesh;
			}
			if (this.myScooterParts.rightGrip && gripsData.rightGripMesh)
			{
				this.myScooterParts.rightGrip.GetComponent<MeshFilter>().mesh = gripsData.rightGripMesh;
			}
			if (gripsData.gripsMaterial)
			{
				if (this.myScooterParts.leftGrip)
				{
					this.myScooterParts.leftGrip.GetComponent<MeshRenderer>().material = gripsData.gripsMaterial;
				}
				if (this.myScooterParts.rightGrip)
				{
					this.myScooterParts.rightGrip.GetComponent<MeshRenderer>().material = gripsData.gripsMaterial;
				}
			}
		}
		if (barEndsData != null)
		{
			if (this.myScooterParts.leftBarEnd && barEndsData.leftBarendMesh)
			{
				this.myScooterParts.leftBarEnd.GetComponent<MeshFilter>().mesh = barEndsData.leftBarendMesh;
			}
			if (this.myScooterParts.rightBarEnd && barEndsData.rightBarend)
			{
				this.myScooterParts.rightBarEnd.GetComponent<MeshFilter>().mesh = barEndsData.rightBarend;
			}
			if (barEndsData.barEndsMaterial)
			{
				if (this.myScooterParts.leftBarEnd)
				{
					this.myScooterParts.leftBarEnd.GetComponent<MeshRenderer>().material = barEndsData.barEndsMaterial;
				}
				if (this.myScooterParts.rightBarEnd)
				{
					this.myScooterParts.rightBarEnd.GetComponent<MeshRenderer>().material = barEndsData.barEndsMaterial;
				}
			}
		}
		if (headsetData != null)
		{
			if (this.myScooterParts.headset && headsetData.headsetMesh)
			{
				this.myScooterParts.headset.GetComponent<MeshFilter>().mesh = headsetData.headsetMesh;
			}
			if (this.myScooterParts.headset && headsetData.headsetMaterial)
			{
				this.myScooterParts.headset.GetComponent<MeshRenderer>().material = headsetData.headsetMaterial;
			}
		}
		if (this.myScooterParts.deckAddonParent)
		{
			for (int i = this.myScooterParts.deckAddonParent.childCount - 1; i >= 0; i--)
			{
				Object.Destroy(this.myScooterParts.deckAddonParent.GetChild(i).gameObject);
			}
		}
		if (deckData != null && deckData.hasAddOns && deckData.deckAddOns != null && this.myScooterParts.deckAddonParent)
		{
			foreach (GameObject gameObject in deckData.deckAddOns)
			{
				if (gameObject)
				{
					GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject, this.myScooterParts.deckAddonParent);
					gameObject2.transform.localPosition = Vector3.zero;
					gameObject2.transform.localRotation = Quaternion.identity;
					gameObject2.transform.localScale = Vector3.one;
				}
			}
		}
		if (pegsData != null)
		{
			if (this.myScooterParts.frontLeftPeg && pegsData.frontLeftPegMesh)
			{
				this.myScooterParts.frontLeftPeg.GetComponent<MeshFilter>().mesh = pegsData.frontLeftPegMesh;
			}
			if (this.myScooterParts.frontRightPeg && pegsData.frontRightPegMesh)
			{
				this.myScooterParts.frontRightPeg.GetComponent<MeshFilter>().mesh = pegsData.frontRightPegMesh;
			}
			if (this.myScooterParts.rearLeftPeg && pegsData.rearLeftPegMesh)
			{
				this.myScooterParts.rearLeftPeg.GetComponent<MeshFilter>().mesh = pegsData.rearLeftPegMesh;
			}
			if (this.myScooterParts.rearRightPeg && pegsData.rearRightPegMesh)
			{
				this.myScooterParts.rearRightPeg.GetComponent<MeshFilter>().mesh = pegsData.rearRightPegMesh;
			}
			if (pegsData.pegsMaterial)
			{
				if (this.myScooterParts.frontLeftPeg)
				{
					this.myScooterParts.frontLeftPeg.GetComponent<MeshRenderer>().material = pegsData.pegsMaterial;
				}
				if (this.myScooterParts.frontRightPeg)
				{
					this.myScooterParts.frontRightPeg.GetComponent<MeshRenderer>().material = pegsData.pegsMaterial;
				}
				if (this.myScooterParts.rearLeftPeg)
				{
					this.myScooterParts.rearLeftPeg.GetComponent<MeshRenderer>().material = pegsData.pegsMaterial;
				}
				if (this.myScooterParts.rearRightPeg)
				{
					this.myScooterParts.rearRightPeg.GetComponent<MeshRenderer>().material = pegsData.pegsMaterial;
				}
			}
		}
		bool active = false;
		bool active2 = false;
		bool active3 = false;
		bool active4 = false;
		switch (data.pegOption)
		{
		case 0:
			active2 = (active = (active3 = (active4 = true)));
			break;
		case 1:
			active3 = (active = true);
			break;
		case 2:
			active4 = (active2 = true);
			break;
		case 3:
			active2 = (active = true);
			break;
		case 4:
			active4 = (active3 = true);
			break;
		case 5:
			break;
		default:
			active2 = (active = (active3 = (active4 = true)));
			break;
		}
		if (deckData != null && deckData.hasAddOns)
		{
			active3 = false;
			active4 = false;
		}
		if (this.myScooterParts.frontLeftPeg)
		{
			this.myScooterParts.frontLeftPeg.SetActive(active);
		}
		if (this.myScooterParts.frontRightPeg)
		{
			this.myScooterParts.frontRightPeg.SetActive(active2);
		}
		if (this.myScooterParts.rearLeftPeg)
		{
			this.myScooterParts.rearLeftPeg.SetActive(active3);
		}
		if (this.myScooterParts.rearRightPeg)
		{
			this.myScooterParts.rearRightPeg.SetActive(active4);
		}
		if (this.scooterDetails == null)
		{
			this.scooterDetails = Object.FindObjectOfType<ScooterDetails>();
		}
		if (this.scooterDetails != null)
		{
			this.scooterDetails.hasDeckPegs = data.hasDeckPegs;
		}
		if (this.grindSystem != null)
		{
			this.grindSystem.hasDeckPegs = data.hasDeckPegs;
			this.grindSystem.SetPegs();
		}
		Debug.Log(string.Format("[ApplyCustomScooter] Loaded slot {0} from SO and applied via Library.", this.customScooterSlot));
	}

	// Token: 0x0400070B RID: 1803
	public MyScooterParts myScooterParts;

	// Token: 0x0400070C RID: 1804
	public GrindSystem grindSystem;

	// Token: 0x0400070D RID: 1805
	private ScooterDetails scooterDetails;

	// Token: 0x0400070E RID: 1806
	[Header("Load From Assets")]
	public ScooterPartsLibrary partsLibrary;

	// Token: 0x0400070F RID: 1807
	public CustomScooter customScootersAsset;

	// Token: 0x04000710 RID: 1808
	[Range(1f, 3f)]
	public int customScooterSlot = 1;
}
