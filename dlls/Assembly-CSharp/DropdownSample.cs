using System;
using TMPro;
using UnityEngine;

// Token: 0x02000218 RID: 536
public class DropdownSample : MonoBehaviour
{
	// Token: 0x06000877 RID: 2167 RVA: 0x0003B658 File Offset: 0x00039858
	public void OnButtonClick()
	{
		this.text.text = ((this.dropdownWithPlaceholder.value > -1) ? ("Selected values:\n" + this.dropdownWithoutPlaceholder.value.ToString() + " - " + this.dropdownWithPlaceholder.value.ToString()) : "Error: Please make a selection");
	}

	// Token: 0x04000EAB RID: 3755
	[SerializeField]
	private TextMeshProUGUI text;

	// Token: 0x04000EAC RID: 3756
	[SerializeField]
	private TMP_Dropdown dropdownWithoutPlaceholder;

	// Token: 0x04000EAD RID: 3757
	[SerializeField]
	private TMP_Dropdown dropdownWithPlaceholder;
}
