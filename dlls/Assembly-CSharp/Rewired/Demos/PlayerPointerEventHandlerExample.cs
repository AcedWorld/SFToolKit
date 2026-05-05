using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Integration.UnityUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rewired.Demos
{
	// Token: 0x020002B9 RID: 697
	[AddComponentMenu("")]
	public sealed class PlayerPointerEventHandlerExample : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler, IScrollHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		// Token: 0x06000EBA RID: 3770 RVA: 0x0004F272 File Offset: 0x0004D472
		private void Log(string o)
		{
			this.log.Add(o);
			if (this.log.Count > 10)
			{
				this.log.RemoveAt(0);
			}
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x0004F29C File Offset: 0x0004D49C
		private void Update()
		{
			if (this.text != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string value in this.log)
				{
					stringBuilder.AppendLine(value);
				}
				this.text.text = stringBuilder.ToString();
			}
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x0004F318 File Offset: 0x0004D518
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (eventData is PlayerPointerEventData)
			{
				PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)eventData;
				this.Log(string.Concat(new string[]
				{
					"OnPointerEnter:  Player = ",
					playerPointerEventData.playerId.ToString(),
					", Pointer Index = ",
					playerPointerEventData.inputSourceIndex.ToString(),
					", Source = ",
					PlayerPointerEventHandlerExample.GetSourceName(playerPointerEventData)
				}));
			}
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x0004F388 File Offset: 0x0004D588
		public void OnPointerExit(PointerEventData eventData)
		{
			if (eventData is PlayerPointerEventData)
			{
				PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)eventData;
				this.Log(string.Concat(new string[]
				{
					"OnPointerExit:  Player = ",
					playerPointerEventData.playerId.ToString(),
					", Pointer Index = ",
					playerPointerEventData.inputSourceIndex.ToString(),
					", Source = ",
					PlayerPointerEventHandlerExample.GetSourceName(playerPointerEventData)
				}));
			}
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x0004F3F8 File Offset: 0x0004D5F8
		public void OnPointerUp(PointerEventData eventData)
		{
			if (eventData is PlayerPointerEventData)
			{
				PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)eventData;
				this.Log(string.Concat(new string[]
				{
					"OnPointerUp:  Player = ",
					playerPointerEventData.playerId.ToString(),
					", Pointer Index = ",
					playerPointerEventData.inputSourceIndex.ToString(),
					", Source = ",
					PlayerPointerEventHandlerExample.GetSourceName(playerPointerEventData),
					", Button Index = ",
					playerPointerEventData.buttonIndex.ToString()
				}));
			}
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x0004F484 File Offset: 0x0004D684
		public void OnPointerDown(PointerEventData eventData)
		{
			if (eventData is PlayerPointerEventData)
			{
				PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)eventData;
				this.Log(string.Concat(new string[]
				{
					"OnPointerDown:  Player = ",
					playerPointerEventData.playerId.ToString(),
					", Pointer Index = ",
					playerPointerEventData.inputSourceIndex.ToString(),
					", Source = ",
					PlayerPointerEventHandlerExample.GetSourceName(playerPointerEventData),
					", Button Index = ",
					playerPointerEventData.buttonIndex.ToString()
				}));
			}
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x0004F510 File Offset: 0x0004D710
		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData is PlayerPointerEventData)
			{
				PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)eventData;
				this.Log(string.Concat(new string[]
				{
					"OnPointerClick:  Player = ",
					playerPointerEventData.playerId.ToString(),
					", Pointer Index = ",
					playerPointerEventData.inputSourceIndex.ToString(),
					", Source = ",
					PlayerPointerEventHandlerExample.GetSourceName(playerPointerEventData),
					", Button Index = ",
					playerPointerEventData.buttonIndex.ToString()
				}));
			}
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x0004F59C File Offset: 0x0004D79C
		public void OnScroll(PointerEventData eventData)
		{
			if (eventData is PlayerPointerEventData)
			{
				PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)eventData;
				this.Log(string.Concat(new string[]
				{
					"OnScroll:  Player = ",
					playerPointerEventData.playerId.ToString(),
					", Pointer Index = ",
					playerPointerEventData.inputSourceIndex.ToString(),
					", Source = ",
					PlayerPointerEventHandlerExample.GetSourceName(playerPointerEventData)
				}));
			}
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x0004F60C File Offset: 0x0004D80C
		public void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData is PlayerPointerEventData)
			{
				PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)eventData;
				this.Log(string.Concat(new string[]
				{
					"OnBeginDrag:  Player = ",
					playerPointerEventData.playerId.ToString(),
					", Pointer Index = ",
					playerPointerEventData.inputSourceIndex.ToString(),
					", Source = ",
					PlayerPointerEventHandlerExample.GetSourceName(playerPointerEventData),
					", Button Index = ",
					playerPointerEventData.buttonIndex.ToString()
				}));
			}
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x0004F698 File Offset: 0x0004D898
		public void OnDrag(PointerEventData eventData)
		{
			if (eventData is PlayerPointerEventData)
			{
				PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)eventData;
				this.Log(string.Concat(new string[]
				{
					"OnDrag:  Player = ",
					playerPointerEventData.playerId.ToString(),
					", Pointer Index = ",
					playerPointerEventData.inputSourceIndex.ToString(),
					", Source = ",
					PlayerPointerEventHandlerExample.GetSourceName(playerPointerEventData),
					", Button Index = ",
					playerPointerEventData.buttonIndex.ToString()
				}));
			}
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x0004F724 File Offset: 0x0004D924
		public void OnEndDrag(PointerEventData eventData)
		{
			if (eventData is PlayerPointerEventData)
			{
				PlayerPointerEventData playerPointerEventData = (PlayerPointerEventData)eventData;
				this.Log(string.Concat(new string[]
				{
					"OnEndDrag:  Player = ",
					playerPointerEventData.playerId.ToString(),
					", Pointer Index = ",
					playerPointerEventData.inputSourceIndex.ToString(),
					", Source = ",
					PlayerPointerEventHandlerExample.GetSourceName(playerPointerEventData),
					", Button Index = ",
					playerPointerEventData.buttonIndex.ToString()
				}));
			}
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x0004F7B0 File Offset: 0x0004D9B0
		private static string GetSourceName(PlayerPointerEventData playerEventData)
		{
			if (playerEventData.sourceType == PointerEventType.Mouse)
			{
				if (playerEventData.mouseSource is Behaviour)
				{
					return (playerEventData.mouseSource as Behaviour).name;
				}
			}
			else if (playerEventData.sourceType == PointerEventType.Touch && playerEventData.touchSource is Behaviour)
			{
				return (playerEventData.touchSource as Behaviour).name;
			}
			return null;
		}

		// Token: 0x04001364 RID: 4964
		public Text text;

		// Token: 0x04001365 RID: 4965
		private const int logLength = 10;

		// Token: 0x04001366 RID: 4966
		private List<string> log = new List<string>();
	}
}
