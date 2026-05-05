using System;
using UnityEngine;

// Token: 0x020001B0 RID: 432
public class CompleteScooter : MonoBehaviour
{
	// Token: 0x060006C2 RID: 1730 RVA: 0x00032664 File Offset: 0x00030864
	private void Start()
	{
		this.scooterDeck = GameObject.Find("Deck_Mesh");
		this.scooterBrake = GameObject.Find("Brake_Mesh");
		this.scooterBars = GameObject.Find("Bars_Mesh");
		this.scooterForks = GameObject.Find("Forks_Mesh");
		this.scooterClamp = GameObject.Find("Clamp_Mesh");
		this.scooterFrontHub = GameObject.Find("FrontWheel_Mesh");
		this.scooterFrontTyre = GameObject.Find("FrontTyre_Mesh");
		this.scooterRearHub = GameObject.Find("RearWheel_Mesh");
		this.scooterRearTyre = GameObject.Find("RearTyre_Mesh");
		this.scooterLeftGrip = GameObject.Find("LeftGrip_Mesh");
		this.scooterRightGrip = GameObject.Find("RightGrip_Mesh");
		this.scooterLeftBarEnd = GameObject.Find("LeftBarEnd_Mesh");
		this.scooterRightBarEnd = GameObject.Find("RightBarEnd_Mesh");
		this.scooterHeadset = GameObject.Find("Headset_Mesh");
		this.scooterGripTape = GameObject.Find("GripTape_Mesh");
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x00032761 File Offset: 0x00030961
	private void Update()
	{
		if (Input.GetKeyDown(this.keycode))
		{
			this.ApplyCompleteScooter();
		}
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x00032778 File Offset: 0x00030978
	public void ApplyCompleteScooter()
	{
		this.scooterBuilderBrain.scooterPegs.pegOption = this.completeScooterParts.pegOption;
		this.scooterBuilderBrain.ApplyPegOption();
		if (this.completeScooterParts.addOnParent.transform.childCount > 0)
		{
			foreach (object obj in this.completeScooterParts.addOnParent.transform)
			{
				Object.Destroy(((Transform)obj).gameObject);
			}
		}
		if (this.completeScooterParts.hasAddOns && this.completeScooterParts.hasAddOns)
		{
			Object.Instantiate<GameObject>(this.completeScooterParts.addOns[0], this.completeScooterParts.addOnParent.transform);
		}
		this.scooterDeck.GetComponent<MeshFilter>().mesh = this.completeScooterParts.deckMesh;
		this.scooterDeck.GetComponent<MeshRenderer>().material = this.completeScooterParts.deckMaterial;
		this.scooterBrake.GetComponent<MeshFilter>().mesh = this.completeScooterParts.brakeMesh;
		this.scooterBrake.GetComponent<MeshRenderer>().material = this.completeScooterParts.deckMaterial;
		this.scooterBars.GetComponent<MeshFilter>().mesh = this.completeScooterParts.barsMesh;
		this.scooterBars.GetComponent<MeshRenderer>().material = this.completeScooterParts.barsMaterial;
		this.scooterForks.GetComponent<MeshFilter>().mesh = this.completeScooterParts.forksMesh;
		this.scooterForks.GetComponent<MeshRenderer>().material = this.completeScooterParts.forksMaterial;
		this.scooterClamp.GetComponent<MeshFilter>().mesh = this.completeScooterParts.clampMesh;
		this.scooterClamp.GetComponent<MeshRenderer>().material = this.completeScooterParts.clampMaterial;
		this.scooterFrontHub.GetComponent<MeshFilter>().mesh = this.completeScooterParts.frontWheelMesh;
		this.scooterFrontHub.GetComponent<MeshRenderer>().material = this.completeScooterParts.frontWheelMaterial;
		this.scooterFrontTyre.GetComponent<MeshRenderer>().material = this.completeScooterParts.frontTyreMaterial;
		this.scooterRearHub.GetComponent<MeshFilter>().mesh = this.completeScooterParts.rearWheelMesh;
		this.scooterRearHub.GetComponent<MeshRenderer>().material = this.completeScooterParts.rearWheelMaterial;
		this.scooterRearTyre.GetComponent<MeshRenderer>().material = this.completeScooterParts.rearTyreMaterial;
		this.scooterLeftGrip.GetComponent<MeshFilter>().mesh = this.completeScooterParts.leftGripMesh;
		this.scooterLeftGrip.GetComponent<MeshRenderer>().material = this.completeScooterParts.gripsMaterial;
		this.scooterRightGrip.GetComponent<MeshFilter>().mesh = this.completeScooterParts.rightGripMesh;
		this.scooterRightGrip.GetComponent<MeshRenderer>().material = this.completeScooterParts.gripsMaterial;
		this.scooterLeftBarEnd.GetComponent<MeshFilter>().mesh = this.completeScooterParts.leftBarEndMesh;
		this.scooterLeftBarEnd.GetComponent<MeshRenderer>().material = this.completeScooterParts.barEndsMaterial;
		this.scooterRightBarEnd.GetComponent<MeshFilter>().mesh = this.completeScooterParts.rightBarEndMesh;
		this.scooterRightBarEnd.GetComponent<MeshRenderer>().material = this.completeScooterParts.barEndsMaterial;
		this.scooterHeadset.GetComponent<MeshFilter>().mesh = this.completeScooterParts.headsetMesh;
		this.scooterHeadset.GetComponent<MeshRenderer>().material = this.completeScooterParts.headsetMaterial;
		this.scooterGripTape.GetComponent<MeshFilter>().mesh = this.completeScooterParts.gripTapeMesh;
		this.scooterGripTape.GetComponent<MeshRenderer>().material.mainTexture = this.completeScooterParts.gripTapeTexture;
		this.SetCompleteNames();
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x00032B58 File Offset: 0x00030D58
	public void SetCompleteNames()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.DeckName = this.completeScooterParts.deckName;
			this.scooterBuilderBrain.customScooter1.BarsName = this.completeScooterParts.barsName;
			this.scooterBuilderBrain.customScooter1.ForksName = this.completeScooterParts.forksName;
			this.scooterBuilderBrain.customScooter1.ClampName = this.completeScooterParts.clampName;
			this.scooterBuilderBrain.customScooter1.FrontWheelName = this.completeScooterParts.frontWheelName;
			this.scooterBuilderBrain.customScooter1.RearWheelName = this.completeScooterParts.rearWheelName;
			this.scooterBuilderBrain.customScooter1.GripsName = this.completeScooterParts.gripsName;
			this.scooterBuilderBrain.customScooter1.BarEndsName = this.completeScooterParts.barEndsName;
			this.scooterBuilderBrain.customScooter1.HeadsetName = this.completeScooterParts.headsetName;
			this.scooterBuilderBrain.customScooter1.GripTapeName = this.completeScooterParts.gripTapeName + this.completeScooterParts.gripTapeID.ToString();
			this.scooterBuilderBrain.customScooter1.pegOption = this.completeScooterParts.pegOption;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.DeckName = this.completeScooterParts.deckName;
			this.scooterBuilderBrain.customScooter2.BarsName = this.completeScooterParts.barsName;
			this.scooterBuilderBrain.customScooter2.ForksName = this.completeScooterParts.forksName;
			this.scooterBuilderBrain.customScooter2.ClampName = this.completeScooterParts.clampName;
			this.scooterBuilderBrain.customScooter2.FrontWheelName = this.completeScooterParts.frontWheelName;
			this.scooterBuilderBrain.customScooter2.RearWheelName = this.completeScooterParts.rearWheelName;
			this.scooterBuilderBrain.customScooter2.GripsName = this.completeScooterParts.gripsName;
			this.scooterBuilderBrain.customScooter2.BarEndsName = this.completeScooterParts.barEndsName;
			this.scooterBuilderBrain.customScooter2.HeadsetName = this.completeScooterParts.headsetName;
			this.scooterBuilderBrain.customScooter2.GripTapeName = this.completeScooterParts.gripTapeName + this.completeScooterParts.gripTapeID.ToString();
			this.scooterBuilderBrain.customScooter2.pegOption = this.completeScooterParts.pegOption;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.DeckName = this.completeScooterParts.deckName;
			this.scooterBuilderBrain.customScooter3.BarsName = this.completeScooterParts.barsName;
			this.scooterBuilderBrain.customScooter3.ForksName = this.completeScooterParts.forksName;
			this.scooterBuilderBrain.customScooter3.ClampName = this.completeScooterParts.clampName;
			this.scooterBuilderBrain.customScooter3.FrontWheelName = this.completeScooterParts.frontWheelName;
			this.scooterBuilderBrain.customScooter3.RearWheelName = this.completeScooterParts.rearWheelName;
			this.scooterBuilderBrain.customScooter3.GripsName = this.completeScooterParts.gripsName;
			this.scooterBuilderBrain.customScooter3.BarEndsName = this.completeScooterParts.barEndsName;
			this.scooterBuilderBrain.customScooter3.HeadsetName = this.completeScooterParts.headsetName;
			this.scooterBuilderBrain.customScooter3.GripTapeName = this.completeScooterParts.gripTapeName + this.completeScooterParts.gripTapeID.ToString();
			this.scooterBuilderBrain.customScooter3.pegOption = this.completeScooterParts.pegOption;
		}
	}

	// Token: 0x04000BD4 RID: 3028
	public string CompleteName;

	// Token: 0x04000BD5 RID: 3029
	public KeyCode keycode;

	// Token: 0x04000BD6 RID: 3030
	public ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x04000BD7 RID: 3031
	public CompleteScooterParts completeScooterParts;

	// Token: 0x04000BD8 RID: 3032
	private GameObject scooterDeck;

	// Token: 0x04000BD9 RID: 3033
	private GameObject scooterBrake;

	// Token: 0x04000BDA RID: 3034
	private GameObject scooterBars;

	// Token: 0x04000BDB RID: 3035
	private GameObject scooterForks;

	// Token: 0x04000BDC RID: 3036
	private GameObject scooterClamp;

	// Token: 0x04000BDD RID: 3037
	private GameObject scooterFrontHub;

	// Token: 0x04000BDE RID: 3038
	private GameObject scooterFrontTyre;

	// Token: 0x04000BDF RID: 3039
	private GameObject scooterRearHub;

	// Token: 0x04000BE0 RID: 3040
	private GameObject scooterRearTyre;

	// Token: 0x04000BE1 RID: 3041
	private GameObject scooterLeftGrip;

	// Token: 0x04000BE2 RID: 3042
	private GameObject scooterRightGrip;

	// Token: 0x04000BE3 RID: 3043
	private GameObject scooterLeftBarEnd;

	// Token: 0x04000BE4 RID: 3044
	private GameObject scooterRightBarEnd;

	// Token: 0x04000BE5 RID: 3045
	private GameObject scooterHeadset;

	// Token: 0x04000BE6 RID: 3046
	private GameObject scooterGripTape;
}
