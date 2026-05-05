using System;
using UnityEngine;

// Token: 0x020001AF RID: 431
[Serializable]
public class CompleteScooterParts
{
	// Token: 0x04000BAC RID: 2988
	[Header("Deck")]
	public string deckName;

	// Token: 0x04000BAD RID: 2989
	public Mesh deckMesh;

	// Token: 0x04000BAE RID: 2990
	public Mesh brakeMesh;

	// Token: 0x04000BAF RID: 2991
	public Material deckMaterial;

	// Token: 0x04000BB0 RID: 2992
	public Transform addOnParent;

	// Token: 0x04000BB1 RID: 2993
	public bool hasAddOns;

	// Token: 0x04000BB2 RID: 2994
	public GameObject[] addOns;

	// Token: 0x04000BB3 RID: 2995
	[Header("Bars")]
	public string barsName;

	// Token: 0x04000BB4 RID: 2996
	public Mesh barsMesh;

	// Token: 0x04000BB5 RID: 2997
	public Material barsMaterial;

	// Token: 0x04000BB6 RID: 2998
	[Header("Forks")]
	public string forksName;

	// Token: 0x04000BB7 RID: 2999
	public Mesh forksMesh;

	// Token: 0x04000BB8 RID: 3000
	public Material forksMaterial;

	// Token: 0x04000BB9 RID: 3001
	[Header("Clamp")]
	public string clampName;

	// Token: 0x04000BBA RID: 3002
	public Mesh clampMesh;

	// Token: 0x04000BBB RID: 3003
	public Material clampMaterial;

	// Token: 0x04000BBC RID: 3004
	[Header("Front Wheel")]
	public string frontWheelName;

	// Token: 0x04000BBD RID: 3005
	public Mesh frontWheelMesh;

	// Token: 0x04000BBE RID: 3006
	public Material frontWheelMaterial;

	// Token: 0x04000BBF RID: 3007
	public Material frontTyreMaterial;

	// Token: 0x04000BC0 RID: 3008
	[Header("Rear Wheel")]
	public string rearWheelName;

	// Token: 0x04000BC1 RID: 3009
	public Mesh rearWheelMesh;

	// Token: 0x04000BC2 RID: 3010
	public Material rearWheelMaterial;

	// Token: 0x04000BC3 RID: 3011
	public Material rearTyreMaterial;

	// Token: 0x04000BC4 RID: 3012
	[Header("Grips")]
	public string gripsName;

	// Token: 0x04000BC5 RID: 3013
	public Mesh leftGripMesh;

	// Token: 0x04000BC6 RID: 3014
	public Mesh rightGripMesh;

	// Token: 0x04000BC7 RID: 3015
	public Material gripsMaterial;

	// Token: 0x04000BC8 RID: 3016
	[Header("Bar Ends")]
	public string barEndsName;

	// Token: 0x04000BC9 RID: 3017
	public Mesh leftBarEndMesh;

	// Token: 0x04000BCA RID: 3018
	public Mesh rightBarEndMesh;

	// Token: 0x04000BCB RID: 3019
	public Material barEndsMaterial;

	// Token: 0x04000BCC RID: 3020
	[Header("Headset")]
	public string headsetName;

	// Token: 0x04000BCD RID: 3021
	public Mesh headsetMesh;

	// Token: 0x04000BCE RID: 3022
	public Material headsetMaterial;

	// Token: 0x04000BCF RID: 3023
	[Header("Grip Tape")]
	public string gripTapeName;

	// Token: 0x04000BD0 RID: 3024
	public int gripTapeID;

	// Token: 0x04000BD1 RID: 3025
	public Mesh gripTapeMesh;

	// Token: 0x04000BD2 RID: 3026
	public Texture gripTapeTexture;

	// Token: 0x04000BD3 RID: 3027
	[Header("Pegs")]
	public int pegOption;
}
