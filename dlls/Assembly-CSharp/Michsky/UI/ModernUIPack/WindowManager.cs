using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x0200032E RID: 814
	public class WindowManager : MonoBehaviour
	{
		// Token: 0x060010D6 RID: 4310 RVA: 0x0005AD10 File Offset: 0x00058F10
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
			try
			{
				this.currentButton = this.windows[this.currentWindowIndex].buttonObject;
				this.currentButtonAnimator = this.currentButton.GetComponent<Animator>();
				this.currentButtonAnimator.Play(this.buttonFadeIn);
			}
			catch
			{
			}
			this.currentWindow = this.windows[this.currentWindowIndex].windowObject;
			this.currentWindowAnimator = this.currentWindow.GetComponent<Animator>();
			this.currentWindowAnimator.Play(this.windowFadeIn);
			this.isFirstTime = false;
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x0005ADCC File Offset: 0x00058FCC
		private void OnEnable()
		{
			if (!this.isFirstTime && this.nextWindowAnimator == null)
			{
				this.currentWindowAnimator.Play(this.windowFadeIn);
				this.currentButtonAnimator.Play(this.buttonFadeIn);
				return;
			}
			if (!this.isFirstTime && this.nextWindowAnimator != null)
			{
				this.nextWindowAnimator.Play(this.windowFadeIn);
				this.nextButtonAnimator.Play(this.buttonFadeIn);
			}
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x0005AE4C File Offset: 0x0005904C
		public void OpenFirstTab()
		{
			if (this.currentWindowIndex != 0)
			{
				this.currentWindow = this.windows[this.currentWindowIndex].windowObject;
				this.currentWindowAnimator = this.currentWindow.GetComponent<Animator>();
				this.currentWindowAnimator.Play(this.windowFadeOut);
				try
				{
					this.currentButton = this.windows[this.currentWindowIndex].buttonObject;
					this.currentButtonAnimator = this.currentButton.GetComponent<Animator>();
					this.currentButtonAnimator.Play(this.buttonFadeOut);
				}
				catch
				{
				}
				this.currentWindowIndex = 0;
				this.currentButtonIndex = 0;
				this.currentWindow = this.windows[this.currentWindowIndex].windowObject;
				this.currentWindowAnimator = this.currentWindow.GetComponent<Animator>();
				this.currentWindowAnimator.Play(this.windowFadeIn);
				try
				{
					this.currentButton = this.windows[this.currentButtonIndex].buttonObject;
					this.currentButtonAnimator = this.currentButton.GetComponent<Animator>();
					this.currentButtonAnimator.Play(this.buttonFadeIn);
					return;
				}
				catch
				{
					return;
				}
			}
			if (this.currentWindowIndex == 0)
			{
				this.currentWindow = this.windows[this.currentWindowIndex].windowObject;
				this.currentWindowAnimator = this.currentWindow.GetComponent<Animator>();
				this.currentWindowAnimator.Play(this.windowFadeIn);
				try
				{
					this.currentButton = this.windows[this.currentButtonIndex].buttonObject;
					this.currentButtonAnimator = this.currentButton.GetComponent<Animator>();
					this.currentButtonAnimator.Play(this.buttonFadeIn);
				}
				catch
				{
				}
			}
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x0005B030 File Offset: 0x00059230
		public void OpenPanel(string newPanel)
		{
			for (int i = 0; i < this.windows.Count; i++)
			{
				if (this.windows[i].windowName == newPanel)
				{
					this.newWindowIndex = i;
				}
			}
			if (this.newWindowIndex != this.currentWindowIndex)
			{
				this.currentWindow = this.windows[this.currentWindowIndex].windowObject;
				try
				{
					this.currentButton = this.windows[this.currentWindowIndex].buttonObject;
				}
				catch
				{
				}
				this.currentWindowIndex = this.newWindowIndex;
				this.nextWindow = this.windows[this.currentWindowIndex].windowObject;
				this.currentWindowAnimator = this.currentWindow.GetComponent<Animator>();
				this.nextWindowAnimator = this.nextWindow.GetComponent<Animator>();
				this.currentWindowAnimator.Play(this.windowFadeOut);
				this.nextWindowAnimator.Play(this.windowFadeIn);
				try
				{
					this.currentButtonIndex = this.newWindowIndex;
					this.nextButton = this.windows[this.currentButtonIndex].buttonObject;
					this.currentButtonAnimator = this.currentButton.GetComponent<Animator>();
					this.nextButtonAnimator = this.nextButton.GetComponent<Animator>();
					this.currentButtonAnimator.Play(this.buttonFadeOut);
					this.nextButtonAnimator.Play(this.buttonFadeIn);
				}
				catch
				{
				}
			}
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x0005B1BC File Offset: 0x000593BC
		public void NextPage()
		{
			if (this.currentWindowIndex <= this.windows.Count - 2)
			{
				this.currentWindow = this.windows[this.currentWindowIndex].windowObject;
				try
				{
					this.currentButton = this.windows[this.currentButtonIndex].buttonObject;
					this.nextButton = this.windows[this.currentButtonIndex + 1].buttonObject;
					this.currentButtonAnimator = this.currentButton.GetComponent<Animator>();
					this.currentButtonAnimator.Play(this.buttonFadeOut);
				}
				catch
				{
				}
				this.currentWindowAnimator = this.currentWindow.GetComponent<Animator>();
				this.currentWindowAnimator.Play(this.windowFadeOut);
				this.currentWindowIndex++;
				this.currentButtonIndex++;
				this.nextWindow = this.windows[this.currentWindowIndex].windowObject;
				this.nextWindowAnimator = this.nextWindow.GetComponent<Animator>();
				this.nextWindowAnimator.Play(this.windowFadeIn);
				try
				{
					this.nextButtonAnimator = this.nextButton.GetComponent<Animator>();
					this.nextButtonAnimator.Play(this.buttonFadeIn);
				}
				catch
				{
				}
			}
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x0005B320 File Offset: 0x00059520
		public void PrevPage()
		{
			if (this.currentWindowIndex >= 1)
			{
				this.currentWindow = this.windows[this.currentWindowIndex].windowObject;
				try
				{
					this.currentButton = this.windows[this.currentButtonIndex].buttonObject;
					this.nextButton = this.windows[this.currentButtonIndex - 1].buttonObject;
					this.currentButtonAnimator = this.currentButton.GetComponent<Animator>();
					this.currentButtonAnimator.Play(this.buttonFadeOut);
				}
				catch
				{
				}
				this.currentWindowAnimator = this.currentWindow.GetComponent<Animator>();
				this.currentWindowAnimator.Play(this.windowFadeOut);
				this.currentWindowIndex--;
				this.currentButtonIndex--;
				this.nextWindow = this.windows[this.currentWindowIndex].windowObject;
				this.nextWindowAnimator = this.nextWindow.GetComponent<Animator>();
				this.nextWindowAnimator.Play(this.windowFadeIn);
				try
				{
					this.nextButtonAnimator = this.nextButton.GetComponent<Animator>();
					this.nextButtonAnimator.Play(this.buttonFadeIn);
				}
				catch
				{
				}
			}
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x0005B478 File Offset: 0x00059678
		public void AddNewItem()
		{
			WindowManager.WindowItem item = new WindowManager.WindowItem();
			this.windows.Add(item);
		}

		// Token: 0x04001694 RID: 5780
		public List<WindowManager.WindowItem> windows = new List<WindowManager.WindowItem>();

		// Token: 0x04001695 RID: 5781
		public int currentWindowIndex;

		// Token: 0x04001696 RID: 5782
		private int currentButtonIndex;

		// Token: 0x04001697 RID: 5783
		private int newWindowIndex;

		// Token: 0x04001698 RID: 5784
		public string windowFadeIn = "Panel In";

		// Token: 0x04001699 RID: 5785
		public string windowFadeOut = "Panel Out";

		// Token: 0x0400169A RID: 5786
		public string buttonFadeIn = "Normal to Pressed";

		// Token: 0x0400169B RID: 5787
		public string buttonFadeOut = "Pressed to Dissolve";

		// Token: 0x0400169C RID: 5788
		[HideInInspector]
		public bool editMode;

		// Token: 0x0400169D RID: 5789
		private bool isFirstTime = true;

		// Token: 0x0400169E RID: 5790
		private GameObject currentWindow;

		// Token: 0x0400169F RID: 5791
		private GameObject nextWindow;

		// Token: 0x040016A0 RID: 5792
		private GameObject currentButton;

		// Token: 0x040016A1 RID: 5793
		private GameObject nextButton;

		// Token: 0x040016A2 RID: 5794
		private Animator currentWindowAnimator;

		// Token: 0x040016A3 RID: 5795
		private Animator nextWindowAnimator;

		// Token: 0x040016A4 RID: 5796
		private Animator currentButtonAnimator;

		// Token: 0x040016A5 RID: 5797
		private Animator nextButtonAnimator;

		// Token: 0x040016A6 RID: 5798
		public int playerId;

		// Token: 0x040016A7 RID: 5799
		private Player player;

		// Token: 0x0200032F RID: 815
		[Serializable]
		public class WindowItem
		{
			// Token: 0x040016A8 RID: 5800
			public string windowName = "My Window";

			// Token: 0x040016A9 RID: 5801
			public GameObject windowObject;

			// Token: 0x040016AA RID: 5802
			public GameObject buttonObject;
		}
	}
}
