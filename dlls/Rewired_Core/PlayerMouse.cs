using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.UI;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	// Token: 0x020000B7 RID: 183
	public sealed class PlayerMouse : PlayerController, IPlayerMouse, IPlayerController, IMouseInputSource
	{
		// Token: 0x060006E4 RID: 1764 RVA: 0x0003B588 File Offset: 0x00039788
		private PlayerMouse(PlayerMouse.Definition A_1) : base(A_1)
		{
			this.rcPpnRDAkjQRrOmMpZvvrtMirstV = A_1.defaultToCenter;
			this.hUeFUtDXFoQJcEUdPLIaiVTMmHAIb = A_1.clampToMovementArea;
			this.OvagKcevmYEmKpHMjPMIKEUiwxkP = A_1.movementArea;
			this.dFEdAdDyvgkqNaYlKHhZOAuSyzro = A_1.movementAreaUnit;
			this.fbHaxSMoNQcrbgDyngKxrTNcxaHY = A_1.pointerSpeed;
			this.RwnrJdeJhEvgPlpEwxpsmlFfVPjs = A_1.useHardwarePointerPosition;
			int elementCount = base.elementCount;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < elementCount; i++)
			{
				if (num < 2 && base.elements[i].GetType() == typeof(PlayerController.MouseAxis))
				{
					if (num == 0)
					{
						this.YvqIRLVuMKyQXzlQPnffpLlVRlaI = base.axes.IndexOf((PlayerController.MouseAxis)base.elements[i]);
					}
					else
					{
						this.JZZVfRWLrtEFogiCuFTMvREADaRV = base.axes.IndexOf((PlayerController.MouseAxis)base.elements[i]);
					}
					num++;
				}
				else if (this.xOvgiPDNgJYQgGqvtUIGcODBNyFr < 0 && base.elements[i] is PlayerController.MouseWheel)
				{
					this.xOvgiPDNgJYQgGqvtUIGcODBNyFr = i;
				}
				else if (num2 < 3 && base.elements[i].GetType() == typeof(PlayerController.Button))
				{
					if (num2 == 0)
					{
						this.xIfDGumIyIhrvBKxKpawBRpCRVcA = base.buttons.IndexOf((PlayerController.Button)base.elements[i]);
					}
					else if (num2 == 1)
					{
						this.ppeUmeubYQIszEVxyxOrvABzNOOH = base.buttons.IndexOf((PlayerController.Button)base.elements[i]);
					}
					else if (num2 == 2)
					{
						this.ZORCgOuMfniNDhOZjwwwDObkndgo = base.buttons.IndexOf((PlayerController.Button)base.elements[i]);
					}
					num2++;
				}
			}
			if (this.xOvgiPDNgJYQgGqvtUIGcODBNyFr < 0)
			{
				int num3 = PlayerController.gQxeTPTUCHIEowxfONJxFITtfpwR<PlayerController.Axis>(base.axes, new Predicate<PlayerController.Axis>(PlayerMouse.uEnuNDtwtBJoFYAiLgbmsLBhsceQ.<>9.wYBmaOVhZBAYihZevopBEljdpVcoA), 1);
				int num4 = PlayerController.gQxeTPTUCHIEowxfONJxFITtfpwR<PlayerController.Axis>(base.axes, new Predicate<PlayerController.Axis>(PlayerMouse.uEnuNDtwtBJoFYAiLgbmsLBhsceQ.<>9.PJgEEWACdEzFctBREvImchZbQRTy), 2);
				if (num3 >= 0 || num4 >= 0)
				{
					PlayerController.MouseWheel mouseWheel = new PlayerController.MouseWheel(this, new PlayerController.MouseWheel.Definition
					{
						name = "Wheel"
					});
					base.aqjSFouuNqqVRvhhKgCNhKPQZxelA(mouseWheel);
					this.xOvgiPDNgJYQgGqvtUIGcODBNyFr = base.elements.Count - 1;
					if (num3 < 0 || num4 < 0)
					{
						PlayerController.Element element = new PlayerController.MouseWheelAxis(this, new PlayerController.MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						base.aqjSFouuNqqVRvhhKgCNhKPQZxelA(element);
						mouseWheel.wsditSWqGDffLuMozFbraGVLElzF(element);
						mouseWheel.wsditSWqGDffLuMozFbraGVLElzF((num3 < 0) ? base.axes[num4] : base.axes[num3]);
					}
					else
					{
						mouseWheel.wsditSWqGDffLuMozFbraGVLElzF(base.axes[num3]);
						mouseWheel.wsditSWqGDffLuMozFbraGVLElzF(base.axes[num4]);
					}
				}
			}
			if (this.rcPpnRDAkjQRrOmMpZvvrtMirstV)
			{
				ScreenRect screenRect = this.QKCDyjdxdWYOBRGpRlhreblEPZevb();
				this.tgWitOGEYzGYjFQWAhpNRtWOIxkh = new Vector2(screenRect.center.x, screenRect.center.y);
				return;
			}
			this.tgWitOGEYzGYjFQWAhpNRtWOIxkh = Vector2.zero;
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x060006E5 RID: 1765 RVA: 0x00007C84 File Offset: 0x00005E84
		// (set) Token: 0x060006E6 RID: 1766 RVA: 0x00007CA7 File Offset: 0x00005EA7
		public bool defaultToCenter
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return false;
				}
				return this.rcPpnRDAkjQRrOmMpZvvrtMirstV;
			}
			set
			{
				this.rcPpnRDAkjQRrOmMpZvvrtMirstV = value;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x060006E7 RID: 1767 RVA: 0x00007CB0 File Offset: 0x00005EB0
		// (set) Token: 0x060006E8 RID: 1768 RVA: 0x00007CB8 File Offset: 0x00005EB8
		public bool clampToMovementArea
		{
			get
			{
				return this.hUeFUtDXFoQJcEUdPLIaiVTMmHAIb;
			}
			set
			{
				this.hUeFUtDXFoQJcEUdPLIaiVTMmHAIb = value;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x060006E9 RID: 1769 RVA: 0x0003B8D4 File Offset: 0x00039AD4
		// (set) Token: 0x060006EA RID: 1770 RVA: 0x00007CC1 File Offset: 0x00005EC1
		public ScreenRect movementArea
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return default(ScreenRect);
				}
				return this.OvagKcevmYEmKpHMjPMIKEUiwxkP;
			}
			set
			{
				this.OvagKcevmYEmKpHMjPMIKEUiwxkP = value;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x00007CCA File Offset: 0x00005ECA
		// (set) Token: 0x060006EC RID: 1772 RVA: 0x00007CED File Offset: 0x00005EED
		public PlayerMouse.MovementAreaUnit movementAreaUnit
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return PlayerMouse.MovementAreaUnit.Screen;
				}
				return this.dFEdAdDyvgkqNaYlKHhZOAuSyzro;
			}
			set
			{
				this.dFEdAdDyvgkqNaYlKHhZOAuSyzro = value;
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x00007CF6 File Offset: 0x00005EF6
		// (set) Token: 0x060006EE RID: 1774 RVA: 0x00007D2B File Offset: 0x00005F2B
		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return this.tgWitOGEYzGYjFQWAhpNRtWOIxkh;
			}
			set
			{
				this.pxDDsEyDBGTLoaFpvjlJEjaLWaWeA(value);
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x00007D34 File Offset: 0x00005F34
		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return this.JYsHTuWBPwGsRPjRRPYIwSweAJko;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x060006F0 RID: 1776 RVA: 0x00007D69 File Offset: 0x00005F69
		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return Vector2.zero;
				}
				if (!base.enabled)
				{
					return Vector2.zero;
				}
				return this.DQSqEjfjAzsDfpoAkfuQVjsoMxTB;
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x00007D9E File Offset: 0x00005F9E
		public PlayerController.MouseAxis xAxis
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return null;
				}
				if (this.YvqIRLVuMKyQXzlQPnffpLlVRlaI < 0)
				{
					return null;
				}
				return (PlayerController.MouseAxis)base.axes[this.YvqIRLVuMKyQXzlQPnffpLlVRlaI];
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x060006F2 RID: 1778 RVA: 0x00007DDC File Offset: 0x00005FDC
		public PlayerController.MouseAxis yAxis
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return null;
				}
				if (this.JZZVfRWLrtEFogiCuFTMvREADaRV < 0)
				{
					return null;
				}
				return (PlayerController.MouseAxis)base.axes[this.JZZVfRWLrtEFogiCuFTMvREADaRV];
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x00007E1A File Offset: 0x0000601A
		public PlayerController.MouseWheel wheel
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return null;
				}
				if (this.xOvgiPDNgJYQgGqvtUIGcODBNyFr < 0)
				{
					return null;
				}
				return (PlayerController.MouseWheel)base.elements[this.xOvgiPDNgJYQgGqvtUIGcODBNyFr];
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x060006F4 RID: 1780 RVA: 0x00007E58 File Offset: 0x00006058
		public PlayerController.Button leftButton
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return null;
				}
				if (this.xIfDGumIyIhrvBKxKpawBRpCRVcA < 0)
				{
					return null;
				}
				return base.buttons[this.xIfDGumIyIhrvBKxKpawBRpCRVcA];
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x00007E91 File Offset: 0x00006091
		public PlayerController.Button rightButton
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return null;
				}
				if (this.ppeUmeubYQIszEVxyxOrvABzNOOH < 0)
				{
					return null;
				}
				return base.buttons[this.ppeUmeubYQIszEVxyxOrvABzNOOH];
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x060006F6 RID: 1782 RVA: 0x00007ECA File Offset: 0x000060CA
		public PlayerController.Button middleButton
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return null;
				}
				if (this.ZORCgOuMfniNDhOZjwwwDObkndgo < 0)
				{
					return null;
				}
				return base.buttons[this.ZORCgOuMfniNDhOZjwwwDObkndgo];
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x00007F03 File Offset: 0x00006103
		// (set) Token: 0x060006F8 RID: 1784 RVA: 0x00007F2A File Offset: 0x0000612A
		public float pointerSpeed
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return 0f;
				}
				return this.fbHaxSMoNQcrbgDyngKxrTNcxaHY;
			}
			set
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				this.fbHaxSMoNQcrbgDyngKxrTNcxaHY = value;
			}
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x00007F5C File Offset: 0x0000615C
		// (set) Token: 0x060006FA RID: 1786 RVA: 0x00007F7F File Offset: 0x0000617F
		public bool useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return false;
				}
				return this.RwnrJdeJhEvgPlpEwxpsmlFfVPjs;
			}
			set
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return;
				}
				this.RwnrJdeJhEvgPlpEwxpsmlFfVPjs = value;
				if (!value)
				{
					this.xPhDowYwmIjZsxwhqBnDfZaOaGQX();
				}
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060006FB RID: 1787 RVA: 0x00007FAB File Offset: 0x000061AB
		// (remove) Token: 0x060006FC RID: 1788 RVA: 0x00007FDE File Offset: 0x000061DE
		public event Action<Vector2> ScreenPositionChangedEvent
		{
			add
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return;
				}
				this.VQIoNevwGVmXVsMWdBMkhEeKrBpr = (Action<Vector2>)Delegate.Combine(this.VQIoNevwGVmXVsMWdBMkhEeKrBpr, value);
			}
			remove
			{
				this.VQIoNevwGVmXVsMWdBMkhEeKrBpr = (Action<Vector2>)Delegate.Remove(this.VQIoNevwGVmXVsMWdBMkhEeKrBpr, value);
			}
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0003B90C File Offset: 0x00039B0C
		protected override bool Update(UpdateLoopType updateLoop)
		{
			if (!base.Update(updateLoop))
			{
				return false;
			}
			if (updateLoop != UpdateLoopType.Update)
			{
				return false;
			}
			Player player;
			if (this.RwnrJdeJhEvgPlpEwxpsmlFfVPjs && (player = base.ICjRvXNkWpCmQBbfkSSJGRsiKTFSA) != null)
			{
				if (!player.controllers.hasMouse)
				{
					this.xPhDowYwmIjZsxwhqBnDfZaOaGQX();
				}
				else
				{
					this.XcZsUGEBWuMXifBjfiuWalMMvKvb = ReInput.controllers.Mouse.screenPosition;
					if (this.XcZsUGEBWuMXifBjfiuWalMMvKvb.x != this.WFkrisWFiNIoRaSkMkKIZfSrLirWA.x || this.XcZsUGEBWuMXifBjfiuWalMMvKvb.y != this.WFkrisWFiNIoRaSkMkKIZfSrLirWA.y)
					{
						this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.x = this.XcZsUGEBWuMXifBjfiuWalMMvKvb.x;
						this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.y = this.XcZsUGEBWuMXifBjfiuWalMMvKvb.y;
					}
					this.WFkrisWFiNIoRaSkMkKIZfSrLirWA.x = this.XcZsUGEBWuMXifBjfiuWalMMvKvb.x;
					this.WFkrisWFiNIoRaSkMkKIZfSrLirWA.y = this.XcZsUGEBWuMXifBjfiuWalMMvKvb.y;
				}
			}
			if (this.YvqIRLVuMKyQXzlQPnffpLlVRlaI >= 0)
			{
				this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.x = PlayerMouse.ewdkhyelJhcyLftpYAxIqorJEhlK(base.axes[this.YvqIRLVuMKyQXzlQPnffpLlVRlaI], this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.x, this.fbHaxSMoNQcrbgDyngKxrTNcxaHY);
			}
			if (this.JZZVfRWLrtEFogiCuFTMvREADaRV >= 0)
			{
				this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.y = PlayerMouse.ewdkhyelJhcyLftpYAxIqorJEhlK(base.axes[this.JZZVfRWLrtEFogiCuFTMvREADaRV], this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.y, this.fbHaxSMoNQcrbgDyngKxrTNcxaHY);
			}
			this.pxDDsEyDBGTLoaFpvjlJEjaLWaWeA(this.tgWitOGEYzGYjFQWAhpNRtWOIxkh);
			this.DQSqEjfjAzsDfpoAkfuQVjsoMxTB.x = this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.x - this.JYsHTuWBPwGsRPjRRPYIwSweAJko.x;
			this.DQSqEjfjAzsDfpoAkfuQVjsoMxTB.y = this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.y - this.JYsHTuWBPwGsRPjRRPYIwSweAJko.y;
			this.oreVlvqHMcExFzvbYacYklCyLfVgA = (this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.x != this.JYsHTuWBPwGsRPjRRPYIwSweAJko.x || this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.y != this.JYsHTuWBPwGsRPjRRPYIwSweAJko.y);
			this.JYsHTuWBPwGsRPjRRPYIwSweAJko.x = this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.x;
			this.JYsHTuWBPwGsRPjRRPYIwSweAJko.y = this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.y;
			return true;
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0003BB28 File Offset: 0x00039D28
		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (this.oreVlvqHMcExFzvbYacYklCyLfVgA && this.VQIoNevwGVmXVsMWdBMkhEeKrBpr != null)
			{
				try
				{
					this.VQIoNevwGVmXVsMWdBMkhEeKrBpr(this.tgWitOGEYzGYjFQWAhpNRtWOIxkh);
				}
				catch (Exception ex)
				{
					string str = "An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n";
					Exception ex2 = ex;
					Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
				}
				this.oreVlvqHMcExFzvbYacYklCyLfVgA = false;
			}
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00007FF7 File Offset: 0x000061F7
		protected override void ClearVars()
		{
			base.ClearVars();
			this.JYsHTuWBPwGsRPjRRPYIwSweAJko = this.tgWitOGEYzGYjFQWAhpNRtWOIxkh;
			this.DQSqEjfjAzsDfpoAkfuQVjsoMxTB = Vector2.zero;
			this.xPhDowYwmIjZsxwhqBnDfZaOaGQX();
			this.oreVlvqHMcExFzvbYacYklCyLfVgA = false;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0003BB94 File Offset: 0x00039D94
		private void pxDDsEyDBGTLoaFpvjlJEjaLWaWeA(Vector2 A_1)
		{
			if (!this.hUeFUtDXFoQJcEUdPLIaiVTMmHAIb)
			{
				this.tgWitOGEYzGYjFQWAhpNRtWOIxkh = A_1;
				return;
			}
			if (this.dFEdAdDyvgkqNaYlKHhZOAuSyzro == PlayerMouse.MovementAreaUnit.Screen)
			{
				float num = (float)Screen.width;
				float num2 = (float)Screen.height;
				this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.x = Mathf.Clamp(A_1.x, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.xMin * num, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.xMax * num);
				this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.y = Mathf.Clamp(A_1.y, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.yMin * num2, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.yMax * num2);
				return;
			}
			if (this.dFEdAdDyvgkqNaYlKHhZOAuSyzro == PlayerMouse.MovementAreaUnit.Pixel)
			{
				this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.x = Mathf.Clamp(A_1.x, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.xMin, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.xMax);
				this.tgWitOGEYzGYjFQWAhpNRtWOIxkh.y = Mathf.Clamp(A_1.y, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.yMin, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0003BC90 File Offset: 0x00039E90
		private ScreenRect QKCDyjdxdWYOBRGpRlhreblEPZevb()
		{
			if (this.dFEdAdDyvgkqNaYlKHhZOAuSyzro == PlayerMouse.MovementAreaUnit.Screen)
			{
				return new ScreenRect(this.OvagKcevmYEmKpHMjPMIKEUiwxkP.xMin * (float)Screen.width, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.yMin * (float)Screen.height, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.width * (float)Screen.width, this.OvagKcevmYEmKpHMjPMIKEUiwxkP.height * (float)Screen.height);
			}
			if (this.dFEdAdDyvgkqNaYlKHhZOAuSyzro == PlayerMouse.MovementAreaUnit.Pixel)
			{
				return this.OvagKcevmYEmKpHMjPMIKEUiwxkP;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00008023 File Offset: 0x00006223
		private void xPhDowYwmIjZsxwhqBnDfZaOaGQX()
		{
			this.XcZsUGEBWuMXifBjfiuWalMMvKvb = Vector2.zero;
			this.WFkrisWFiNIoRaSkMkKIZfSrLirWA = Vector2.zero;
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0003BD08 File Offset: 0x00039F08
		private static float ewdkhyelJhcyLftpYAxIqorJEhlK(PlayerController.Axis A_0, float A_1, float A_2)
		{
			if (A_0 == null)
			{
				return A_1;
			}
			AxisCoordinateMode coordinateMode = A_0.coordinateMode;
			if (coordinateMode == AxisCoordinateMode.Absolute)
			{
				return A_0.value;
			}
			if (coordinateMode != AxisCoordinateMode.Relative)
			{
				throw new NotImplementedException();
			}
			return A_1 + A_0.value * A_2;
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000704 RID: 1796 RVA: 0x0000803B File Offset: 0x0000623B
		bool IMouseInputSource.enabled
		{
			get
			{
				return base.enabled;
			}
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00008043 File Offset: 0x00006243
		bool IMouseInputSource.GetButtonDown(int button)
		{
			return base.GetButtonDown(button);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0000804C File Offset: 0x0000624C
		bool IMouseInputSource.GetButtonUp(int button)
		{
			return base.GetButtonUp(button);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00008055 File Offset: 0x00006255
		bool IMouseInputSource.GetButton(int button)
		{
			return base.GetButton(button);
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x0000805E File Offset: 0x0000625E
		Vector2 IMouseInputSource.screenPosition
		{
			get
			{
				return this.tgWitOGEYzGYjFQWAhpNRtWOIxkh;
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x00008066 File Offset: 0x00006266
		Vector2 IMouseInputSource.screenPositionDelta
		{
			get
			{
				return this.DQSqEjfjAzsDfpoAkfuQVjsoMxTB;
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x0600070A RID: 1802 RVA: 0x0000806E File Offset: 0x0000626E
		Vector2 IMouseInputSource.wheelDelta
		{
			get
			{
				if (this.wheel == null)
				{
					return Vector2.zero;
				}
				return this.wheel.value;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00003E2B File Offset: 0x0000202B
		bool IMouseInputSource.locked
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0400040D RID: 1037
		internal const bool bOtaCSEXFvFfRPuASrdwgOEBKRZab = true;

		// Token: 0x0400040E RID: 1038
		internal const float OgqLfQsUAUJgnouXIePVsVMzdgzS = 1f;

		// Token: 0x0400040F RID: 1039
		internal const bool WWuaSTUlYxVRhBsXTvVPSIzNADVJ = true;

		// Token: 0x04000410 RID: 1040
		internal const bool iotsMJGgPXYcdiWRPjiavwctscKW = true;

		// Token: 0x04000411 RID: 1041
		internal const PlayerMouse.MovementAreaUnit UAoDMqjxUyFWOupwfYTGmDLKzLnU = PlayerMouse.MovementAreaUnit.Screen;

		// Token: 0x04000412 RID: 1042
		internal static readonly ScreenRect CgaJYLCZvsOfYleOaAxwWgAjJSVbb = new ScreenRect(0f, 0f, 1f, 1f);

		// Token: 0x04000413 RID: 1043
		private const int RagALJBQmTiCNjAoSrCllSxoeNHtA = 3;

		// Token: 0x04000414 RID: 1044
		private const int ibcIzdetQjgARrLzbOonUybJsxxOA = 3;

		// Token: 0x04000415 RID: 1045
		internal const string QnschfdlhxptejKesfPRpYuucatDA = "Movement";

		// Token: 0x04000416 RID: 1046
		internal const string tfPrxUzPiypqnSFVImpXJqgnDLOJA = "Horizontal";

		// Token: 0x04000417 RID: 1047
		internal const string HbmnNDvRHODdQjBFAnkyFsSgTVmQb = "Vertical";

		// Token: 0x04000418 RID: 1048
		internal const string rqfoXEAUxgacTgQvzmuGLpuVRxrD = "Wheel";

		// Token: 0x04000419 RID: 1049
		internal const string SnnbthzslEmLEIKelWaBCmpGErHD = "Wheel Horizontal";

		// Token: 0x0400041A RID: 1050
		internal const string OGXbThhxqOPJerrRvSYCykrUAFyz = "Wheel Vertical";

		// Token: 0x0400041B RID: 1051
		internal const string MdxHLOSRtDddBBraOfYyAZXbNRLPb = "Left Button";

		// Token: 0x0400041C RID: 1052
		internal const string xWSbLCpMAMcBdEiKczNRTVuaXZmc = "Right Button";

		// Token: 0x0400041D RID: 1053
		internal const string gfJToKTILaoLpaehBeNakEoozEub = "Middle Button";

		// Token: 0x0400041E RID: 1054
		private readonly int xOvgiPDNgJYQgGqvtUIGcODBNyFr = -1;

		// Token: 0x0400041F RID: 1055
		private readonly int YvqIRLVuMKyQXzlQPnffpLlVRlaI = -1;

		// Token: 0x04000420 RID: 1056
		private readonly int JZZVfRWLrtEFogiCuFTMvREADaRV = -1;

		// Token: 0x04000421 RID: 1057
		private readonly int xIfDGumIyIhrvBKxKpawBRpCRVcA = -1;

		// Token: 0x04000422 RID: 1058
		private readonly int ppeUmeubYQIszEVxyxOrvABzNOOH = -1;

		// Token: 0x04000423 RID: 1059
		private readonly int ZORCgOuMfniNDhOZjwwwDObkndgo = -1;

		// Token: 0x04000424 RID: 1060
		private bool oreVlvqHMcExFzvbYacYklCyLfVgA;

		// Token: 0x04000425 RID: 1061
		private Vector2 XcZsUGEBWuMXifBjfiuWalMMvKvb;

		// Token: 0x04000426 RID: 1062
		private Vector2 WFkrisWFiNIoRaSkMkKIZfSrLirWA;

		// Token: 0x04000427 RID: 1063
		private Vector2 tgWitOGEYzGYjFQWAhpNRtWOIxkh;

		// Token: 0x04000428 RID: 1064
		private Vector2 JYsHTuWBPwGsRPjRRPYIwSweAJko;

		// Token: 0x04000429 RID: 1065
		private Vector2 DQSqEjfjAzsDfpoAkfuQVjsoMxTB;

		// Token: 0x0400042A RID: 1066
		private float fbHaxSMoNQcrbgDyngKxrTNcxaHY;

		// Token: 0x0400042B RID: 1067
		private bool RwnrJdeJhEvgPlpEwxpsmlFfVPjs;

		// Token: 0x0400042C RID: 1068
		private Action<Vector2> VQIoNevwGVmXVsMWdBMkhEeKrBpr;

		// Token: 0x0400042D RID: 1069
		private bool rcPpnRDAkjQRrOmMpZvvrtMirstV;

		// Token: 0x0400042E RID: 1070
		private ScreenRect OvagKcevmYEmKpHMjPMIKEUiwxkP;

		// Token: 0x0400042F RID: 1071
		private bool hUeFUtDXFoQJcEUdPLIaiVTMmHAIb;

		// Token: 0x04000430 RID: 1072
		private PlayerMouse.MovementAreaUnit dFEdAdDyvgkqNaYlKHhZOAuSyzro;

		// Token: 0x020000B8 RID: 184
		public new sealed class Definition : PlayerController.Definition
		{
			// Token: 0x0600070D RID: 1805 RVA: 0x000080A9 File Offset: 0x000062A9
			internal Definition()
			{
			}

			// Token: 0x04000431 RID: 1073
			public bool defaultToCenter = true;

			// Token: 0x04000432 RID: 1074
			public bool clampToMovementArea = true;

			// Token: 0x04000433 RID: 1075
			public ScreenRect movementArea = PlayerMouse.CgaJYLCZvsOfYleOaAxwWgAjJSVbb;

			// Token: 0x04000434 RID: 1076
			public PlayerMouse.MovementAreaUnit movementAreaUnit;

			// Token: 0x04000435 RID: 1077
			public float pointerSpeed = 1f;

			// Token: 0x04000436 RID: 1078
			public bool useHardwarePointerPosition = true;
		}

		// Token: 0x020000B9 RID: 185
		public new static class Factory
		{
			// Token: 0x0600070E RID: 1806 RVA: 0x000080DC File Offset: 0x000062DC
			public static PlayerMouse Create()
			{
				return PlayerMouse.Factory.RLVPFGgUrpeVhOfXQvfqnrNpqYUT(3, 3);
			}

			// Token: 0x0600070F RID: 1807 RVA: 0x0003BD44 File Offset: 0x00039F44
			private static PlayerMouse RLVPFGgUrpeVhOfXQvfqnrNpqYUT(int A_0, int A_1)
			{
				if (A_0 < 0)
				{
					A_0 = 0;
				}
				if (A_1 < 0)
				{
					A_1 = 0;
				}
				List<PlayerController.Element.Definition> list = new List<PlayerController.Element.Definition>(A_0 + A_1);
				if (A_1 >= 1)
				{
					list.Add(new PlayerController.MouseAxis2D.Definition
					{
						name = "Movement",
						xAxis = new PlayerController.MouseAxis.Definition
						{
							name = "Horizontal"
						},
						yAxis = new PlayerController.MouseAxis.Definition
						{
							name = "Vertical"
						}
					});
				}
				if (A_1 >= 3)
				{
					list.Add(new PlayerController.MouseWheel.Definition
					{
						name = "Wheel",
						xAxis = new PlayerController.MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal"
						},
						yAxis = new PlayerController.MouseWheelAxis.Definition
						{
							name = "Wheel Vertical"
						}
					});
				}
				for (int i = 4; i < A_1; i++)
				{
					list.Add(new PlayerController.Axis.Definition
					{
						coordinateMode = AxisCoordinateMode.Relative
					});
				}
				if (A_0 >= 1)
				{
					list.Add(new PlayerController.Button.Definition
					{
						name = "Left Button"
					});
				}
				if (A_0 >= 2)
				{
					list.Add(new PlayerController.Button.Definition
					{
						name = "Right Button"
					});
				}
				if (A_0 >= 3)
				{
					list.Add(new PlayerController.Button.Definition
					{
						name = "Middle Button"
					});
				}
				for (int j = 3; j < A_0; j++)
				{
					list.Add(new PlayerController.Button.Definition());
				}
				return new PlayerMouse(new PlayerMouse.Definition
				{
					elements = list
				});
			}

			// Token: 0x06000710 RID: 1808 RVA: 0x000080E5 File Offset: 0x000062E5
			public static PlayerMouse Create(PlayerMouse.Definition definition)
			{
				return new PlayerMouse(definition);
			}
		}

		// Token: 0x020000BA RID: 186
		public enum MovementAreaUnit
		{
			// Token: 0x04000438 RID: 1080
			Screen,
			// Token: 0x04000439 RID: 1081
			Pixel
		}

		// Token: 0x020000BB RID: 187
		[CompilerGenerated]
		[Serializable]
		private sealed class uEnuNDtwtBJoFYAiLgbmsLBhsceQ
		{
			// Token: 0x06000713 RID: 1811 RVA: 0x000080F9 File Offset: 0x000062F9
			internal bool wYBmaOVhZBAYihZevopBEljdpVcoA(PlayerController.Axis A_1)
			{
				return A_1.GetType() == typeof(PlayerController.MouseWheelAxis) && !A_1.WUYPXmcWTQbrWXBAXEGcsxvdVjTB;
			}

			// Token: 0x06000714 RID: 1812 RVA: 0x000080F9 File Offset: 0x000062F9
			internal bool PJgEEWACdEzFctBREvImchZbQRTy(PlayerController.Axis A_1)
			{
				return A_1.GetType() == typeof(PlayerController.MouseWheelAxis) && !A_1.WUYPXmcWTQbrWXBAXEGcsxvdVjTB;
			}

			// Token: 0x0400043A RID: 1082
			public static readonly PlayerMouse.uEnuNDtwtBJoFYAiLgbmsLBhsceQ <>9 = new PlayerMouse.uEnuNDtwtBJoFYAiLgbmsLBhsceQ();

			// Token: 0x0400043B RID: 1083
			public static Predicate<PlayerController.Axis> <>9__18_0;

			// Token: 0x0400043C RID: 1084
			public static Predicate<PlayerController.Axis> <>9__18_1;
		}
	}
}
