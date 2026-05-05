using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x020000AC RID: 172
public class ChallengeList : MonoBehaviour
{
	// Token: 0x060002D8 RID: 728 RVA: 0x000167CF File Offset: 0x000149CF
	private void Start()
	{
		this.UpdateChallengeList();
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x000167D7 File Offset: 0x000149D7
	public void CompleteChallenge(int index)
	{
		if (index >= 0 && index < this.challenges.Count)
		{
			this.completedChallenges.Add(index);
			this.UpdateChallengeList();
		}
	}

	// Token: 0x060002DA RID: 730 RVA: 0x00016800 File Offset: 0x00014A00
	private void UpdateChallengeList()
	{
		this.challengeText.text = "";
		for (int i = 0; i < this.challenges.Count; i++)
		{
			if (this.completedChallenges.Contains(i))
			{
				TextMeshProUGUI textMeshProUGUI = this.challengeText;
				textMeshProUGUI.text = textMeshProUGUI.text + "<s>" + this.challenges[i] + "</s>\n";
			}
			else
			{
				TextMeshProUGUI textMeshProUGUI2 = this.challengeText;
				textMeshProUGUI2.text = textMeshProUGUI2.text + this.challenges[i] + "\n";
			}
		}
	}

	// Token: 0x04000394 RID: 916
	[SerializeField]
	private TextMeshProUGUI challengeText;

	// Token: 0x04000395 RID: 917
	private List<string> challenges = new List<string>
	{
		"Pushing & Moveing",
		"Steering",
		"Jumping/Hop",
		"Manuals",
		"NoseManuals",
		"FootJams",
		"TailWhip",
		"HeelWhip",
		"Flyout Tricks",
		"Assisted Transfer",
		"Asssited Airing"
	};

	// Token: 0x04000396 RID: 918
	private HashSet<int> completedChallenges = new HashSet<int>();
}
