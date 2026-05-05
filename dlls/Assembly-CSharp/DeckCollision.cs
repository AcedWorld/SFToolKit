using System;
using UnityEngine;

// Token: 0x02000175 RID: 373
public class DeckCollision : MonoBehaviour
{
	// Token: 0x06000603 RID: 1539 RVA: 0x0002BC45 File Offset: 0x00029E45
	public void OnTriggerEnter(Collider other)
	{
		this.deckCollision = true;
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x0002BC4E File Offset: 0x00029E4E
	public void OnTriggerExit(Collider other)
	{
		this.deckCollision = false;
	}

	// Token: 0x040009F2 RID: 2546
	public bool deckCollision;
}
