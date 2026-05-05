using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200009B RID: 155
	public class PlayerController : IPlayerController
	{
		// Token: 0x06000651 RID: 1617 RVA: 0x0003A940 File Offset: 0x00038B40
		internal PlayerController(PlayerController.Definition A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("definition");
			}
			if (A_1.elements == null)
			{
				throw new ArgumentNullException("definition.elements");
			}
			this.GfryEZjMuOXKBkSbOztmLJzZPwtB = ReInput._id;
			this.DdZRVCMlDzZMkFJtXfdVAjrZClwhb = A_1.playerId;
			this.vujbiqJNyzDjVhshyemyYCJjiVMZA = A_1.enabled;
			List<PlayerController.Element> list = new List<PlayerController.Element>();
			List<PlayerController.Element> list2 = new List<PlayerController.Element>();
			List<PlayerController.Button> list3 = new List<PlayerController.Button>();
			List<PlayerController.Axis> list4 = new List<PlayerController.Axis>();
			foreach (PlayerController.Element.Definition definition in A_1.elements)
			{
				this.SqPqGgOqPLTqvYbuAwvJHENlHqPkA(definition.skekXiekWbwhBokIgqZdpnSxXPXK(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			this.eXaaLryDfwQzMNyDYTcLUjMGKeKg = new AList<PlayerController.Element>(list);
			this.ekqbPmNMJknaZrGyzESlPEKwhwzW = new AList<PlayerController.Button>(list3);
			this.NgQutzsVafahSCsULmKPgxhgbnzd = new AList<PlayerController.Axis>(list4);
			this.wWbGwllmDNjWEHNuqkRptPpkZHpY = new ReadOnlyCollection<PlayerController.Element>(this.eXaaLryDfwQzMNyDYTcLUjMGKeKg);
			this.yVbLzHJQAWNibPOGrnqiABtSdofHA = new ReadOnlyCollection<PlayerController.Button>(this.ekqbPmNMJknaZrGyzESlPEKwhwzW);
			this.UUFZZEqFJyoUjvDDpVmqdGciuUqL = new ReadOnlyCollection<PlayerController.Axis>(this.NgQutzsVafahSCsULmKPgxhgbnzd);
			this.dmKxLKkipOBItaMGTwXITIQxoTpo = new List<PlayerController.Element.ZKxEnrqufIGdhyxUPaRcGZCDCfjaA>();
			ReInput.UpdateEndedEvent += this.uMdpNjRCAcQHApzPzhIebuHslxBV;
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0003AA7C File Offset: 0x00038C7C
		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= this.uMdpNjRCAcQHApzPzhIebuHslxBV;
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x00007381 File Offset: 0x00005581
		// (set) Token: 0x06000654 RID: 1620 RVA: 0x0003AAB4 File Offset: 0x00038CB4
		public bool enabled
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return false;
				}
				return this.vujbiqJNyzDjVhshyemyYCJjiVMZA;
			}
			set
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return;
				}
				if (this.vujbiqJNyzDjVhshyemyYCJjiVMZA == value)
				{
					return;
				}
				if (!value)
				{
					this.ClearVars();
				}
				this.vujbiqJNyzDjVhshyemyYCJjiVMZA = value;
				for (int i = 0; i < this.eXaaLryDfwQzMNyDYTcLUjMGKeKg._count; i++)
				{
					this.eXaaLryDfwQzMNyDYTcLUjMGKeKg[i].enabled = value;
				}
				if (this.sEnePqAieMbZVyGwxgubdyFSbSuu != null)
				{
					try
					{
						this.sEnePqAieMbZVyGwxgubdyFSbSuu(value);
					}
					catch (Exception ex)
					{
						string str = "An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n";
						Exception ex2 = ex;
						Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
					}
				}
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x000073A4 File Offset: 0x000055A4
		// (set) Token: 0x06000656 RID: 1622 RVA: 0x000073C7 File Offset: 0x000055C7
		public int playerId
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return -1;
				}
				return this.DdZRVCMlDzZMkFJtXfdVAjrZClwhb;
			}
			set
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return;
				}
				if (this.DdZRVCMlDzZMkFJtXfdVAjrZClwhb == value)
				{
					return;
				}
				this.DdZRVCMlDzZMkFJtXfdVAjrZClwhb = value;
				this.ClearVars();
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x000073FA File Offset: 0x000055FA
		public IList<PlayerController.Button> buttons
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return null;
				}
				return this.yVbLzHJQAWNibPOGrnqiABtSdofHA;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000658 RID: 1624 RVA: 0x0000741D File Offset: 0x0000561D
		public IList<PlayerController.Axis> axes
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return null;
				}
				return this.UUFZZEqFJyoUjvDDpVmqdGciuUqL;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x00007440 File Offset: 0x00005640
		public IList<PlayerController.Element> elements
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return null;
				}
				return this.wWbGwllmDNjWEHNuqkRptPpkZHpY;
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x0600065A RID: 1626 RVA: 0x00007463 File Offset: 0x00005663
		public int buttonCount
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return 0;
				}
				if (this.ekqbPmNMJknaZrGyzESlPEKwhwzW == null)
				{
					return 0;
				}
				return this.ekqbPmNMJknaZrGyzESlPEKwhwzW._count;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x00007495 File Offset: 0x00005695
		public int axisCount
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return 0;
				}
				if (this.NgQutzsVafahSCsULmKPgxhgbnzd == null)
				{
					return 0;
				}
				return this.NgQutzsVafahSCsULmKPgxhgbnzd._count;
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x0600065C RID: 1628 RVA: 0x000074C7 File Offset: 0x000056C7
		public int elementCount
		{
			get
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return 0;
				}
				if (this.eXaaLryDfwQzMNyDYTcLUjMGKeKg == null)
				{
					return 0;
				}
				return this.eXaaLryDfwQzMNyDYTcLUjMGKeKg._count;
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600065D RID: 1629 RVA: 0x000074F9 File Offset: 0x000056F9
		// (remove) Token: 0x0600065E RID: 1630 RVA: 0x0000752C File Offset: 0x0000572C
		public event Action<int, bool> ButtonStateChangedEvent
		{
			add
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return;
				}
				this.UsZTQXlBpZaFlosdtwmRqylFkHlp = (Action<int, bool>)Delegate.Combine(this.UsZTQXlBpZaFlosdtwmRqylFkHlp, value);
			}
			remove
			{
				this.UsZTQXlBpZaFlosdtwmRqylFkHlp = (Action<int, bool>)Delegate.Remove(this.UsZTQXlBpZaFlosdtwmRqylFkHlp, value);
			}
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600065F RID: 1631 RVA: 0x00007545 File Offset: 0x00005745
		// (remove) Token: 0x06000660 RID: 1632 RVA: 0x00007578 File Offset: 0x00005778
		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return;
				}
				this.vwwHjwfEcLdyMBEoDyFAEyCROMIv = (Action<int, float>)Delegate.Combine(this.vwwHjwfEcLdyMBEoDyFAEyCROMIv, value);
			}
			remove
			{
				this.vwwHjwfEcLdyMBEoDyFAEyCROMIv = (Action<int, float>)Delegate.Remove(this.vwwHjwfEcLdyMBEoDyFAEyCROMIv, value);
			}
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000661 RID: 1633 RVA: 0x00007591 File Offset: 0x00005791
		// (remove) Token: 0x06000662 RID: 1634 RVA: 0x000075C4 File Offset: 0x000057C4
		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
				{
					ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
					return;
				}
				this.sEnePqAieMbZVyGwxgubdyFSbSuu = (Action<bool>)Delegate.Combine(this.sEnePqAieMbZVyGwxgubdyFSbSuu, value);
			}
			remove
			{
				this.sEnePqAieMbZVyGwxgubdyFSbSuu = (Action<bool>)Delegate.Remove(this.sEnePqAieMbZVyGwxgubdyFSbSuu, value);
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x000075DD File Offset: 0x000057DD
		public bool GetButton(int index)
		{
			if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
			{
				ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
				return false;
			}
			return index < this.ekqbPmNMJknaZrGyzESlPEKwhwzW._count && this.ekqbPmNMJknaZrGyzESlPEKwhwzW[index].value;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0000761B File Offset: 0x0000581B
		public bool GetButtonDown(int index)
		{
			if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
			{
				ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
				return false;
			}
			return index < this.ekqbPmNMJknaZrGyzESlPEKwhwzW._count && this.ekqbPmNMJknaZrGyzESlPEKwhwzW[index].justPressed;
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x00007659 File Offset: 0x00005859
		public bool GetButtonUp(int index)
		{
			if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
			{
				ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
				return false;
			}
			return index < this.ekqbPmNMJknaZrGyzESlPEKwhwzW._count && this.ekqbPmNMJknaZrGyzESlPEKwhwzW[index].justReleased;
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0003AB64 File Offset: 0x00038D64
		public float GetAxis(int index)
		{
			if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
			{
				ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
				return 0f;
			}
			if (index >= this.NgQutzsVafahSCsULmKPgxhgbnzd._count)
			{
				return 0f;
			}
			return this.NgQutzsVafahSCsULmKPgxhgbnzd[index].value;
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0003ABB8 File Offset: 0x00038DB8
		public float GetAxisRaw(int index)
		{
			if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
			{
				ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
				return 0f;
			}
			if (index >= this.NgQutzsVafahSCsULmKPgxhgbnzd._count)
			{
				return 0f;
			}
			return this.NgQutzsVafahSCsULmKPgxhgbnzd[index].valueRaw;
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x00007697 File Offset: 0x00005897
		public PlayerController.Element GetElement(int index)
		{
			if (ReInput._id != this.GfryEZjMuOXKBkSbOztmLJzZPwtB)
			{
				ReInput.CheckInitialized(this.GfryEZjMuOXKBkSbOztmLJzZPwtB);
				return null;
			}
			if (index >= this.eXaaLryDfwQzMNyDYTcLUjMGKeKg._count)
			{
				return null;
			}
			return this.eXaaLryDfwQzMNyDYTcLUjMGKeKg[index];
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x000076D0 File Offset: 0x000058D0
		public T GetElement<T>(int index) where T : PlayerController.Element
		{
			return this.GetElement(index) as T;
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x000076E3 File Offset: 0x000058E3
		internal Player ICjRvXNkWpCmQBbfkSSJGRsiKTFSA
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(this.playerId);
			}
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x000076FE File Offset: 0x000058FE
		private void uMdpNjRCAcQHApzPzhIebuHslxBV(UpdateLoopType A_1)
		{
			this.Update(A_1);
			this.UpdateFinished();
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0003AC0C File Offset: 0x00038E0C
		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!this.vujbiqJNyzDjVhshyemyYCJjiVMZA)
			{
				return false;
			}
			bool flag = this.vwwHjwfEcLdyMBEoDyFAEyCROMIv != null;
			bool flag2 = this.UsZTQXlBpZaFlosdtwmRqylFkHlp != null;
			for (int i = 0; i < this.eXaaLryDfwQzMNyDYTcLUjMGKeKg._count; i++)
			{
				float num = 0f;
				if (flag && this.eXaaLryDfwQzMNyDYTcLUjMGKeKg[i] is PlayerController.Axis)
				{
					PlayerController.Axis axis = this.eXaaLryDfwQzMNyDYTcLUjMGKeKg[i] as PlayerController.Axis;
					if (axis.coordinateMode == AxisCoordinateMode.Absolute)
					{
						num = axis.value;
					}
					else
					{
						num = 0f;
					}
				}
				this.eXaaLryDfwQzMNyDYTcLUjMGKeKg[i].GVwXmOtlACFwYFPpkFViNLfvwVlT();
				if (flag2 && this.eXaaLryDfwQzMNyDYTcLUjMGKeKg[i] is PlayerController.Button)
				{
					PlayerController.Button button = this.eXaaLryDfwQzMNyDYTcLUjMGKeKg[i] as PlayerController.Button;
					if (button.justPressed && button.value)
					{
						this.dmKxLKkipOBItaMGTwXITIQxoTpo.Add(new PlayerController.Element.ZKxEnrqufIGdhyxUPaRcGZCDCfjaA(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						this.dmKxLKkipOBItaMGTwXITIQxoTpo.Add(new PlayerController.Element.ZKxEnrqufIGdhyxUPaRcGZCDCfjaA(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && this.eXaaLryDfwQzMNyDYTcLUjMGKeKg[i] is PlayerController.Axis)
				{
					this.dmKxLKkipOBItaMGTwXITIQxoTpo.Add(new PlayerController.Element.ZKxEnrqufIGdhyxUPaRcGZCDCfjaA(ControllerElementType.Axis, i, (this.eXaaLryDfwQzMNyDYTcLUjMGKeKg[i] as PlayerController.Axis).value - num));
				}
			}
			return true;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0003AD6C File Offset: 0x00038F6C
		protected virtual void UpdateFinished()
		{
			int count = this.dmKxLKkipOBItaMGTwXITIQxoTpo.Count;
			if (count > 0)
			{
				int i = 0;
				while (i < count)
				{
					PlayerController.Element.ZKxEnrqufIGdhyxUPaRcGZCDCfjaA zkxEnrqufIGdhyxUPaRcGZCDCfjaA = this.dmKxLKkipOBItaMGTwXITIQxoTpo[i];
					if (zkxEnrqufIGdhyxUPaRcGZCDCfjaA.RBIseNlpeNiYwaCZJfYgbGAkoRdec == ControllerElementType.Button)
					{
						try
						{
							this.UsZTQXlBpZaFlosdtwmRqylFkHlp(zkxEnrqufIGdhyxUPaRcGZCDCfjaA.cZZXVrPiTaDITEyNPShgvnkEuBPD, zkxEnrqufIGdhyxUPaRcGZCDCfjaA.gapMyJQIwynRENVQIxzWExFmiboB > 0f);
							goto IL_B5;
						}
						catch (Exception ex)
						{
							string str = "An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n";
							Exception ex2 = ex;
							Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
							goto IL_B5;
						}
						goto IL_73;
					}
					goto IL_73;
					IL_B5:
					i++;
					continue;
					IL_73:
					if (zkxEnrqufIGdhyxUPaRcGZCDCfjaA.RBIseNlpeNiYwaCZJfYgbGAkoRdec == ControllerElementType.Axis)
					{
						try
						{
							this.vwwHjwfEcLdyMBEoDyFAEyCROMIv(zkxEnrqufIGdhyxUPaRcGZCDCfjaA.cZZXVrPiTaDITEyNPShgvnkEuBPD, zkxEnrqufIGdhyxUPaRcGZCDCfjaA.gapMyJQIwynRENVQIxzWExFmiboB);
						}
						catch (Exception ex3)
						{
							string str2 = "An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n";
							Exception ex4 = ex3;
							Logger.LogError(str2 + ((ex4 != null) ? ex4.ToString() : null));
						}
						goto IL_B5;
					}
					goto IL_B5;
				}
				this.dmKxLKkipOBItaMGTwXITIQxoTpo.Clear();
			}
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0000770E File Offset: 0x0000590E
		protected virtual void ClearVars()
		{
			this.dmKxLKkipOBItaMGTwXITIQxoTpo.Clear();
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0003AE60 File Offset: 0x00039060
		internal void aqjSFouuNqqVRvhhKgCNhKPQZxelA(PlayerController.Element A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			if (A_1 is PlayerController.Axis)
			{
				this.NgQutzsVafahSCsULmKPgxhgbnzd.Add(A_1 as PlayerController.Axis);
			}
			else if (A_1 is PlayerController.Button)
			{
				this.ekqbPmNMJknaZrGyzESlPEKwhwzW.Add(A_1 as PlayerController.Button);
			}
			this.eXaaLryDfwQzMNyDYTcLUjMGKeKg.Add(A_1);
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0003AEB4 File Offset: 0x000390B4
		private void SqPqGgOqPLTqvYbuAwvJHENlHqPkA(PlayerController.Element A_1, List<PlayerController.Element> A_2, List<PlayerController.Element> A_3, List<PlayerController.Button> A_4, List<PlayerController.Axis> A_5)
		{
			if (A_1 == null)
			{
				return;
			}
			A_1.GetType();
			if (A_1 is PlayerController.ElementWithSource)
			{
				if (A_1 is PlayerController.Button)
				{
					A_4.Add((PlayerController.Button)A_1);
				}
				else
				{
					if (!(A_1 is PlayerController.Axis))
					{
						string str = "Unknown Element type encountered: ";
						Type type = A_1.GetType();
						Logger.LogWarning(str + ((type != null) ? type.ToString() : null));
						return;
					}
					A_5.Add((PlayerController.Axis)A_1);
				}
				A_2.Add(A_1);
				return;
			}
			if (A_1 is PlayerController.CompoundElement)
			{
				using (TempListPool.TList<PlayerController.Element> tlist = TempListPool.GetTList<PlayerController.Element>())
				{
					List<PlayerController.Element> list = tlist.list;
					(A_1 as PlayerController.CompoundElement).ZKLEpEpPTHzwrJLVyRjUIEIiwlPw(list);
					for (int i = 0; i < list.Count; i++)
					{
						this.SqPqGgOqPLTqvYbuAwvJHENlHqPkA(list[i], A_2, A_3, A_4, A_5);
					}
				}
				A_3.Add(A_1);
				return;
			}
			string str2 = "Unknown Element type encountered: ";
			Type type2 = A_1.GetType();
			Logger.LogWarning(str2 + ((type2 != null) ? type2.ToString() : null));
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0003AFB8 File Offset: 0x000391B8
		internal static int gQxeTPTUCHIEowxfONJxFITtfpwR<\u0001>(IList<\u0001> A_0, Predicate<\u0001> A_1, int A_2) where \u0001 : PlayerController.Element
		{
			int num = 0;
			for (int i = 0; i < A_0.Count; i++)
			{
				if (A_1(A_0[i]))
				{
					num++;
				}
				if (num == A_2)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x040003C8 RID: 968
		internal readonly int GfryEZjMuOXKBkSbOztmLJzZPwtB;

		// Token: 0x040003C9 RID: 969
		private bool vujbiqJNyzDjVhshyemyYCJjiVMZA;

		// Token: 0x040003CA RID: 970
		private int DdZRVCMlDzZMkFJtXfdVAjrZClwhb;

		// Token: 0x040003CB RID: 971
		private readonly AList<PlayerController.Element> eXaaLryDfwQzMNyDYTcLUjMGKeKg;

		// Token: 0x040003CC RID: 972
		private readonly AList<PlayerController.Button> ekqbPmNMJknaZrGyzESlPEKwhwzW;

		// Token: 0x040003CD RID: 973
		private readonly AList<PlayerController.Axis> NgQutzsVafahSCsULmKPgxhgbnzd;

		// Token: 0x040003CE RID: 974
		private readonly ReadOnlyCollection<PlayerController.Element> wWbGwllmDNjWEHNuqkRptPpkZHpY;

		// Token: 0x040003CF RID: 975
		private readonly ReadOnlyCollection<PlayerController.Button> yVbLzHJQAWNibPOGrnqiABtSdofHA;

		// Token: 0x040003D0 RID: 976
		private readonly ReadOnlyCollection<PlayerController.Axis> UUFZZEqFJyoUjvDDpVmqdGciuUqL;

		// Token: 0x040003D1 RID: 977
		private readonly List<PlayerController.Element.ZKxEnrqufIGdhyxUPaRcGZCDCfjaA> dmKxLKkipOBItaMGTwXITIQxoTpo;

		// Token: 0x040003D2 RID: 978
		private Action<int, bool> UsZTQXlBpZaFlosdtwmRqylFkHlp;

		// Token: 0x040003D3 RID: 979
		private Action<int, float> vwwHjwfEcLdyMBEoDyFAEyCROMIv;

		// Token: 0x040003D4 RID: 980
		private Action<bool> sEnePqAieMbZVyGwxgubdyFSbSuu;

		// Token: 0x0200009C RID: 156
		public class Definition
		{
			// Token: 0x040003D5 RID: 981
			public bool enabled = true;

			// Token: 0x040003D6 RID: 982
			public int playerId = -1;

			// Token: 0x040003D7 RID: 983
			public ICollection<PlayerController.Element.Definition> elements;
		}

		// Token: 0x0200009D RID: 157
		public static class Factory
		{
			// Token: 0x06000673 RID: 1651 RVA: 0x00007731 File Offset: 0x00005931
			public static PlayerController Create(PlayerController.Definition definition)
			{
				return new PlayerController(definition);
			}
		}

		// Token: 0x0200009E RID: 158
		public class Axis : PlayerController.ElementWithSource
		{
			// Token: 0x06000674 RID: 1652 RVA: 0x00007739 File Offset: 0x00005939
			internal Axis(PlayerController A_1, PlayerController.Axis.Definition A_2) : base(A_1, A_2)
			{
				this.WQknEvCTlstvQamxyElWbpYAaULuA = A_2.absoluteToRelativeSensitivity;
				this.ztASCOmeAgziuEQaAIxSfKbGwFTJA = A_2.coordinateMode;
			}

			// Token: 0x17000235 RID: 565
			// (get) Token: 0x06000675 RID: 1653 RVA: 0x00007766 File Offset: 0x00005966
			// (set) Token: 0x06000676 RID: 1654 RVA: 0x0000776E File Offset: 0x0000596E
			public float absoluteToRelativeSensitivity
			{
				get
				{
					return this.WQknEvCTlstvQamxyElWbpYAaULuA;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					this.WQknEvCTlstvQamxyElWbpYAaULuA = value;
				}
			}

			// Token: 0x17000236 RID: 566
			// (get) Token: 0x06000677 RID: 1655 RVA: 0x00007786 File Offset: 0x00005986
			public AxisCoordinateMode coordinateMode
			{
				get
				{
					return this.ztASCOmeAgziuEQaAIxSfKbGwFTJA;
				}
			}

			// Token: 0x17000237 RID: 567
			// (get) Token: 0x06000678 RID: 1656 RVA: 0x0003AFF4 File Offset: 0x000391F4
			public virtual float value
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return 0f;
					}
					float num = base.player.GetAxis(base.actionId);
					AxisCoordinateMode axisCoordinateMode = base.player.GetAxisCoordinateMode(base.actionId);
					if (axisCoordinateMode != AxisCoordinateMode.Absolute)
					{
						if (axisCoordinateMode == AxisCoordinateMode.Relative && this.ztASCOmeAgziuEQaAIxSfKbGwFTJA == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
					}
					else if (this.ztASCOmeAgziuEQaAIxSfKbGwFTJA == AxisCoordinateMode.Relative)
					{
						num *= (float)ReInput.unscaledDeltaTime * this.WQknEvCTlstvQamxyElWbpYAaULuA;
					}
					return num;
				}
			}

			// Token: 0x17000238 RID: 568
			// (get) Token: 0x06000679 RID: 1657 RVA: 0x0000778E File Offset: 0x0000598E
			public virtual float valueRaw
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return 0f;
					}
					return base.player.GetAxisRaw(base.actionId);
				}
			}

			// Token: 0x040003D8 RID: 984
			internal const float enoojApzzCRFwLDreAEellaFJHtc = 1f;

			// Token: 0x040003D9 RID: 985
			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			// Token: 0x040003DA RID: 986
			private float WQknEvCTlstvQamxyElWbpYAaULuA = 1f;

			// Token: 0x040003DB RID: 987
			private AxisCoordinateMode ztASCOmeAgziuEQaAIxSfKbGwFTJA;

			// Token: 0x0200009F RID: 159
			public new class Definition : PlayerController.ElementWithSource.Definition
			{
				// Token: 0x0600067A RID: 1658 RVA: 0x000077B7 File Offset: 0x000059B7
				public Definition()
				{
					this.coordinateMode = AxisCoordinateMode.Absolute;
					this.absoluteToRelativeSensitivity = 1f;
				}

				// Token: 0x0600067B RID: 1659 RVA: 0x000077D1 File Offset: 0x000059D1
				internal virtual PlayerController.Element cDZDKaFYdLjzeoZfkIEvOyNxAdddA(PlayerController A_1)
				{
					return new PlayerController.Axis(A_1, this);
				}

				// Token: 0x040003DC RID: 988
				public AxisCoordinateMode coordinateMode;

				// Token: 0x040003DD RID: 989
				public float absoluteToRelativeSensitivity;
			}
		}

		// Token: 0x020000A0 RID: 160
		public class MouseAxis : PlayerController.Axis
		{
			// Token: 0x0600067C RID: 1660 RVA: 0x000077DA File Offset: 0x000059DA
			internal MouseAxis(PlayerController A_1, PlayerController.MouseAxis.Definition A_2) : base(A_1, A_2)
			{
			}

			// Token: 0x17000239 RID: 569
			// (get) Token: 0x0600067D RID: 1661 RVA: 0x0003B06C File Offset: 0x0003926C
			public override float value
			{
				get
				{
					float num = base.value;
					if (num == 0f)
					{
						return 0f;
					}
					if (base.coordinateMode == AxisCoordinateMode.Relative && base.player.GetAxisCoordinateMode(base.actionId) == AxisCoordinateMode.Absolute)
					{
						num *= (float)Screen.currentResolution.width / 1920f;
					}
					return num;
				}
			}

			// Token: 0x040003DE RID: 990
			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			// Token: 0x040003DF RID: 991
			[CustomObfuscation(rename = false)]
			internal const float defaultAbsoluteToRelativeSensitivity = 600f;

			// Token: 0x020000A1 RID: 161
			public new class Definition : PlayerController.Axis.Definition
			{
				// Token: 0x0600067E RID: 1662 RVA: 0x000077E4 File Offset: 0x000059E4
				public Definition()
				{
					this.coordinateMode = AxisCoordinateMode.Relative;
					this.absoluteToRelativeSensitivity = 600f;
				}

				// Token: 0x0600067F RID: 1663 RVA: 0x000077FE File Offset: 0x000059FE
				internal virtual PlayerController.Element gKmAnyUNxTzTghFjszCPboCwAQEk(PlayerController A_1)
				{
					return new PlayerController.MouseAxis(A_1, this);
				}
			}
		}

		// Token: 0x020000A2 RID: 162
		public class Axis2D : PlayerController.CompoundElement
		{
			// Token: 0x06000680 RID: 1664 RVA: 0x00007807 File Offset: 0x00005A07
			internal Axis2D(PlayerController A_1, PlayerController.Axis2D.Definition A_2, PlayerController.Element.Definition[] A_3) : base(A_1, A_2, A_3)
			{
			}

			// Token: 0x06000681 RID: 1665 RVA: 0x0003B0C4 File Offset: 0x000392C4
			internal Axis2D(PlayerController A_1, PlayerController.Axis2D.Definition A_2)
			{
				PlayerController.Element.Definition[] array;
				if (A_2 == null)
				{
					array = null;
				}
				else
				{
					PlayerController.Element.Definition[] array2 = new PlayerController.Element.Definition[2];
					array2[0] = ((A_2.xAxis != null) ? A_2.xAxis : new PlayerController.Axis.Definition());
					array = array2;
					array2[1] = ((A_2.yAxis != null) ? A_2.yAxis : new PlayerController.Axis.Definition());
				}
				base..ctor(A_1, A_2, array);
			}

			// Token: 0x1700023A RID: 570
			// (get) Token: 0x06000682 RID: 1666 RVA: 0x00007812 File Offset: 0x00005A12
			public PlayerController.Axis xAxis
			{
				get
				{
					return base.ClWUlewvkfNoRjqREkoOCVAwsOdl<PlayerController.Axis>(0);
				}
			}

			// Token: 0x1700023B RID: 571
			// (get) Token: 0x06000683 RID: 1667 RVA: 0x0000781B File Offset: 0x00005A1B
			public PlayerController.Axis yAxis
			{
				get
				{
					return base.ClWUlewvkfNoRjqREkoOCVAwsOdl<PlayerController.Axis>(1);
				}
			}

			// Token: 0x1700023C RID: 572
			// (get) Token: 0x06000684 RID: 1668 RVA: 0x00007824 File Offset: 0x00005A24
			public virtual Vector2 value
			{
				get
				{
					return new Vector2(base.ClWUlewvkfNoRjqREkoOCVAwsOdl<PlayerController.Axis>(0).value, base.ClWUlewvkfNoRjqREkoOCVAwsOdl<PlayerController.Axis>(1).value);
				}
			}

			// Token: 0x1700023D RID: 573
			// (get) Token: 0x06000685 RID: 1669 RVA: 0x00007843 File Offset: 0x00005A43
			public virtual Vector2 valueRaw
			{
				get
				{
					return new Vector2(base.ClWUlewvkfNoRjqREkoOCVAwsOdl<PlayerController.Axis>(0).valueRaw, base.ClWUlewvkfNoRjqREkoOCVAwsOdl<PlayerController.Axis>(1).valueRaw);
				}
			}

			// Token: 0x040003E0 RID: 992
			internal const int fXdkOwgzaUBqonrdvlaqfyfYAXzB = 0;

			// Token: 0x040003E1 RID: 993
			internal const int kQdAMtbzbcOLAEDeSFjhPGssWkHVA = 1;

			// Token: 0x040003E2 RID: 994
			internal const int xRUAHjgkrIUGgtlRSmiqFSKBcMiqB = 2;

			// Token: 0x020000A3 RID: 163
			public new class Definition : PlayerController.CompoundElement.Definition
			{
				// Token: 0x1700023E RID: 574
				// (get) Token: 0x06000687 RID: 1671 RVA: 0x0000786A File Offset: 0x00005A6A
				// (set) Token: 0x06000688 RID: 1672 RVA: 0x00007872 File Offset: 0x00005A72
				public PlayerController.Axis.Definition xAxis
				{
					get
					{
						return this.OAVIuTrWPwrpMZOUtFHNPuQmDjGb;
					}
					set
					{
						this.OAVIuTrWPwrpMZOUtFHNPuQmDjGb = value;
					}
				}

				// Token: 0x1700023F RID: 575
				// (get) Token: 0x06000689 RID: 1673 RVA: 0x0000787B File Offset: 0x00005A7B
				// (set) Token: 0x0600068A RID: 1674 RVA: 0x00007883 File Offset: 0x00005A83
				public PlayerController.Axis.Definition yAxis
				{
					get
					{
						return this.hSFMSCVlDmoEadzXBRJsZNuMmNMy;
					}
					set
					{
						this.hSFMSCVlDmoEadzXBRJsZNuMmNMy = value;
					}
				}

				// Token: 0x0600068B RID: 1675 RVA: 0x0000788C File Offset: 0x00005A8C
				internal virtual PlayerController.Element sRACRCfJxOAkNmsMNytJHQSwuvFEA(PlayerController A_1)
				{
					return new PlayerController.Axis2D(A_1, this);
				}

				// Token: 0x040003E3 RID: 995
				private PlayerController.Axis.Definition OAVIuTrWPwrpMZOUtFHNPuQmDjGb;

				// Token: 0x040003E4 RID: 996
				private PlayerController.Axis.Definition hSFMSCVlDmoEadzXBRJsZNuMmNMy;
			}
		}

		// Token: 0x020000A4 RID: 164
		public sealed class MouseAxis2D : PlayerController.Axis2D
		{
			// Token: 0x0600068C RID: 1676 RVA: 0x0003B118 File Offset: 0x00039318
			internal MouseAxis2D(PlayerController A_1, PlayerController.MouseAxis2D.Definition A_2)
			{
				PlayerController.Element.Definition[] array;
				if (A_2 == null)
				{
					array = null;
				}
				else
				{
					PlayerController.Element.Definition[] array2 = new PlayerController.Element.Definition[2];
					array2[0] = ((A_2.xAxis != null) ? A_2.xAxis : new PlayerController.MouseAxis.Definition());
					array = array2;
					array2[1] = ((A_2.yAxis != null) ? A_2.yAxis : new PlayerController.MouseAxis.Definition());
				}
				base..ctor(A_1, A_2, array);
			}

			// Token: 0x17000240 RID: 576
			// (get) Token: 0x0600068D RID: 1677 RVA: 0x00007895 File Offset: 0x00005A95
			public new PlayerController.MouseAxis xAxis
			{
				get
				{
					return base.ClWUlewvkfNoRjqREkoOCVAwsOdl<PlayerController.MouseAxis>(0);
				}
			}

			// Token: 0x17000241 RID: 577
			// (get) Token: 0x0600068E RID: 1678 RVA: 0x0000789E File Offset: 0x00005A9E
			public new PlayerController.MouseAxis yAxis
			{
				get
				{
					return base.ClWUlewvkfNoRjqREkoOCVAwsOdl<PlayerController.MouseAxis>(1);
				}
			}

			// Token: 0x020000A5 RID: 165
			public new class Definition : PlayerController.Axis2D.Definition
			{
				// Token: 0x17000242 RID: 578
				// (get) Token: 0x06000690 RID: 1680 RVA: 0x000078AF File Offset: 0x00005AAF
				// (set) Token: 0x06000691 RID: 1681 RVA: 0x000078BC File Offset: 0x00005ABC
				public new PlayerController.MouseAxis.Definition xAxis
				{
					get
					{
						return base.xAxis as PlayerController.MouseAxis.Definition;
					}
					set
					{
						base.xAxis = value;
					}
				}

				// Token: 0x17000243 RID: 579
				// (get) Token: 0x06000692 RID: 1682 RVA: 0x000078C5 File Offset: 0x00005AC5
				// (set) Token: 0x06000693 RID: 1683 RVA: 0x000078D2 File Offset: 0x00005AD2
				public new PlayerController.MouseAxis.Definition yAxis
				{
					get
					{
						return base.yAxis as PlayerController.MouseAxis.Definition;
					}
					set
					{
						base.yAxis = value;
					}
				}

				// Token: 0x06000694 RID: 1684 RVA: 0x000078DB File Offset: 0x00005ADB
				internal virtual PlayerController.Element wlCNzRchcOsdFHDqhKUaKpPbcVYh(PlayerController A_1)
				{
					return new PlayerController.MouseAxis2D(A_1, this);
				}
			}
		}

		// Token: 0x020000A6 RID: 166
		public sealed class Button : PlayerController.ElementWithSource
		{
			// Token: 0x06000695 RID: 1685 RVA: 0x000078E4 File Offset: 0x00005AE4
			internal Button(PlayerController A_1, PlayerController.Button.Definition A_2) : base(A_1, A_2)
			{
			}

			// Token: 0x17000244 RID: 580
			// (get) Token: 0x06000696 RID: 1686 RVA: 0x000078EE File Offset: 0x00005AEE
			public bool value
			{
				get
				{
					return base.selfAndParentEnabled && base.player != null && base.player.GetButton(base.actionId);
				}
			}

			// Token: 0x17000245 RID: 581
			// (get) Token: 0x06000697 RID: 1687 RVA: 0x00007913 File Offset: 0x00005B13
			public bool valuePrev
			{
				get
				{
					return base.selfAndParentEnabled && base.player != null && base.player.GetButtonPrev(base.actionId);
				}
			}

			// Token: 0x17000246 RID: 582
			// (get) Token: 0x06000698 RID: 1688 RVA: 0x00007938 File Offset: 0x00005B38
			public bool justPressed
			{
				get
				{
					return base.selfAndParentEnabled && base.player != null && base.player.GetButtonDown(base.actionId);
				}
			}

			// Token: 0x17000247 RID: 583
			// (get) Token: 0x06000699 RID: 1689 RVA: 0x0000795D File Offset: 0x00005B5D
			public bool justReleased
			{
				get
				{
					return base.selfAndParentEnabled && base.player != null && base.player.GetButtonUp(base.actionId);
				}
			}

			// Token: 0x020000A7 RID: 167
			public new class Definition : PlayerController.ElementWithSource.Definition
			{
				// Token: 0x0600069B RID: 1691 RVA: 0x0000798A File Offset: 0x00005B8A
				internal virtual PlayerController.Element LhHxiMapvSbFfVxMqpNTPVLHAevq(PlayerController A_1)
				{
					return new PlayerController.Button(A_1, this);
				}
			}
		}

		// Token: 0x020000A8 RID: 168
		public abstract class CompoundElement : PlayerController.Element
		{
			// Token: 0x0600069C RID: 1692 RVA: 0x0003B16C File Offset: 0x0003936C
			internal CompoundElement(PlayerController A_1, PlayerController.CompoundElement.Definition A_2, PlayerController.Element.Definition[] A_3) : base(A_1, A_2)
			{
				this.SrGYYNuHsHroWmgEQrNNBiwKtETV = new List<PlayerController.Element>();
				if (A_3 != null)
				{
					for (int i = 0; i < A_3.Length; i++)
					{
						if (A_3[i] != null)
						{
							this.wsditSWqGDffLuMozFbraGVLElzF(A_3[i].skekXiekWbwhBokIgqZdpnSxXPXK(A_1));
						}
					}
				}
			}

			// Token: 0x17000248 RID: 584
			// (get) Token: 0x0600069D RID: 1693 RVA: 0x00007993 File Offset: 0x00005B93
			internal int IziBFgtyAppWGAiFfjYmqEtTLqpB
			{
				get
				{
					return this.SrGYYNuHsHroWmgEQrNNBiwKtETV.Count;
				}
			}

			// Token: 0x0600069E RID: 1694 RVA: 0x0003B1B4 File Offset: 0x000393B4
			internal \u0001 ClWUlewvkfNoRjqREkoOCVAwsOdl<\u0001>(int A_1) where \u0001 : PlayerController.Element
			{
				if (A_1 >= this.SrGYYNuHsHroWmgEQrNNBiwKtETV.Count)
				{
					return default(\u0001);
				}
				return this.SrGYYNuHsHroWmgEQrNNBiwKtETV[A_1] as \u0001;
			}

			// Token: 0x0600069F RID: 1695 RVA: 0x0003B1F0 File Offset: 0x000393F0
			internal void ZKLEpEpPTHzwrJLVyRjUIEIiwlPw(List<PlayerController.Element> A_1)
			{
				for (int i = 0; i < this.SrGYYNuHsHroWmgEQrNNBiwKtETV.Count; i++)
				{
					if (this.SrGYYNuHsHroWmgEQrNNBiwKtETV[i] is PlayerController.CompoundElement)
					{
						(this.SrGYYNuHsHroWmgEQrNNBiwKtETV[i] as PlayerController.CompoundElement).ZKLEpEpPTHzwrJLVyRjUIEIiwlPw(A_1);
					}
					else
					{
						A_1.Add(this.SrGYYNuHsHroWmgEQrNNBiwKtETV[i]);
					}
				}
			}

			// Token: 0x060006A0 RID: 1696 RVA: 0x000079A0 File Offset: 0x00005BA0
			internal void wsditSWqGDffLuMozFbraGVLElzF(PlayerController.Element A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("element");
				}
				this.SrGYYNuHsHroWmgEQrNNBiwKtETV.Add(A_1);
				A_1.WUYPXmcWTQbrWXBAXEGcsxvdVjTB = true;
			}

			// Token: 0x040003E5 RID: 997
			private readonly List<PlayerController.Element> SrGYYNuHsHroWmgEQrNNBiwKtETV;

			// Token: 0x020000A9 RID: 169
			public new abstract class Definition : PlayerController.Element.Definition
			{
				// Token: 0x060006A1 RID: 1697 RVA: 0x000079C3 File Offset: 0x00005BC3
				public Definition()
				{
				}
			}
		}

		// Token: 0x020000AA RID: 170
		public abstract class Element
		{
			// Token: 0x060006A2 RID: 1698 RVA: 0x0003B254 File Offset: 0x00039454
			internal Element(PlayerController A_1, PlayerController.Element.Definition A_2)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (A_2 == null)
				{
					throw new ArgumentNullException("definition");
				}
				this.cwshTRoHHtBEBLqhYvrzJhaDVMbr = A_1;
				this.CLywUvLfwwiOrMJQSJEwkFYVdMCt = A_2.enabled;
				this.DRfaDeDSSTAUTqtpJVFjOFiDXufJ = A_2.name;
			}

			// Token: 0x17000249 RID: 585
			// (get) Token: 0x060006A3 RID: 1699 RVA: 0x000079CB File Offset: 0x00005BCB
			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(this.cwshTRoHHtBEBLqhYvrzJhaDVMbr.DdZRVCMlDzZMkFJtXfdVAjrZClwhb);
				}
			}

			// Token: 0x1700024A RID: 586
			// (get) Token: 0x060006A4 RID: 1700 RVA: 0x000079EB File Offset: 0x00005BEB
			protected bool selfAndParentEnabled
			{
				get
				{
					return this.CLywUvLfwwiOrMJQSJEwkFYVdMCt && this.cwshTRoHHtBEBLqhYvrzJhaDVMbr.vujbiqJNyzDjVhshyemyYCJjiVMZA;
				}
			}

			// Token: 0x1700024B RID: 587
			// (get) Token: 0x060006A5 RID: 1701 RVA: 0x00007A02 File Offset: 0x00005C02
			// (set) Token: 0x060006A6 RID: 1702 RVA: 0x00007A0A File Offset: 0x00005C0A
			internal bool WUYPXmcWTQbrWXBAXEGcsxvdVjTB
			{
				get
				{
					return this.LLAwaTcKRsHdfPoRWWxAXISsneSp;
				}
				set
				{
					this.LLAwaTcKRsHdfPoRWWxAXISsneSp = true;
				}
			}

			// Token: 0x1700024C RID: 588
			// (get) Token: 0x060006A7 RID: 1703 RVA: 0x00007A13 File Offset: 0x00005C13
			// (set) Token: 0x060006A8 RID: 1704 RVA: 0x00007A1B File Offset: 0x00005C1B
			public bool enabled
			{
				get
				{
					return this.CLywUvLfwwiOrMJQSJEwkFYVdMCt;
				}
				set
				{
					if (this.CLywUvLfwwiOrMJQSJEwkFYVdMCt == value)
					{
						return;
					}
					this.CLywUvLfwwiOrMJQSJEwkFYVdMCt = value;
					this.EnabledStateChanged(value);
				}
			}

			// Token: 0x1700024D RID: 589
			// (get) Token: 0x060006A9 RID: 1705 RVA: 0x00007A35 File Offset: 0x00005C35
			// (set) Token: 0x060006AA RID: 1706 RVA: 0x00007A3D File Offset: 0x00005C3D
			public string name
			{
				get
				{
					return this.DRfaDeDSSTAUTqtpJVFjOFiDXufJ;
				}
				set
				{
					this.DRfaDeDSSTAUTqtpJVFjOFiDXufJ = value;
				}
			}

			// Token: 0x060006AB RID: 1707 RVA: 0x00002FF9 File Offset: 0x000011F9
			internal virtual void GVwXmOtlACFwYFPpkFViNLfvwVlT()
			{
			}

			// Token: 0x060006AC RID: 1708 RVA: 0x00002FF9 File Offset: 0x000011F9
			protected virtual void EnabledStateChanged(bool state)
			{
			}

			// Token: 0x060006AD RID: 1709 RVA: 0x00007A46 File Offset: 0x00005C46
			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(PlayerController.Element.Type type)
			{
				if (PlayerController.Element.GeaARGzPQhutcCzrBVImNTGEPDEM == null)
				{
					PlayerController.Element.GeaARGzPQhutcCzrBVImNTGEPDEM = (int[])Enum.GetValues(typeof(PlayerController.Element.TypeWithSource));
				}
				return ArrayTools.Contains<int>(PlayerController.Element.GeaARGzPQhutcCzrBVImNTGEPDEM, (int)type);
			}

			// Token: 0x060006AE RID: 1710 RVA: 0x00007A73 File Offset: 0x00005C73
			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(PlayerController.Element.Type type)
			{
				if (PlayerController.Element.CzvpWFIeMKlEJbAKAdBeqQHgSqEd == null)
				{
					PlayerController.Element.CzvpWFIeMKlEJbAKAdBeqQHgSqEd = (int[])Enum.GetValues(typeof(PlayerController.Element.CompoundTypes));
				}
				return ArrayTools.Contains<int>(PlayerController.Element.CzvpWFIeMKlEJbAKAdBeqQHgSqEd, (int)type);
			}

			// Token: 0x060006AF RID: 1711 RVA: 0x00007AA0 File Offset: 0x00005CA0
			[CustomObfuscation(rename = false)]
			internal static int GetMaxElementCount(PlayerController.Element.Type type)
			{
				if (PlayerController.Element.IsTypeWithSource(type))
				{
					return 1;
				}
				if (!PlayerController.Element.IsCompoundType(type))
				{
					throw new NotImplementedException();
				}
				switch (type)
				{
				case PlayerController.Element.Type.Axis2D:
					return 2;
				case PlayerController.Element.Type.MouseAxis2D:
					return 2;
				case PlayerController.Element.Type.MouseWheel:
					return 2;
				default:
					throw new NotImplementedException();
				}
			}

			// Token: 0x060006B0 RID: 1712 RVA: 0x0003B2AC File Offset: 0x000394AC
			[CustomObfuscation(rename = false)]
			internal static string GetElementTitle(PlayerController.Element.Type type, int index)
			{
				if (index < 0 || index > PlayerController.Element.GetMaxElementCount(type))
				{
					return null;
				}
				if (PlayerController.Element.IsTypeWithSource(type))
				{
					return null;
				}
				if (!PlayerController.Element.IsCompoundType(type))
				{
					throw new NotImplementedException();
				}
				if (type - PlayerController.Element.Type.Axis2D > 2)
				{
					throw new NotImplementedException();
				}
				if (index != 0)
				{
					return "Y Axis";
				}
				return "X Axis";
			}

			// Token: 0x060006B1 RID: 1713 RVA: 0x0003B2FC File Offset: 0x000394FC
			[CustomObfuscation(rename = false)]
			internal static PlayerController.Element.Definition CreateDefinition(PlayerController.Element.Type type)
			{
				switch (type)
				{
				case PlayerController.Element.Type.Button:
					return new PlayerController.Button.Definition();
				case PlayerController.Element.Type.Axis:
					return new PlayerController.Axis.Definition();
				case PlayerController.Element.Type.MouseAxis:
					return new PlayerController.MouseAxis.Definition();
				case PlayerController.Element.Type.MouseWheelAxis:
					return new PlayerController.MouseWheelAxis.Definition();
				default:
					switch (type)
					{
					case PlayerController.Element.Type.Axis2D:
						return new PlayerController.Axis2D.Definition();
					case PlayerController.Element.Type.MouseAxis2D:
						return new PlayerController.MouseAxis2D.Definition();
					case PlayerController.Element.Type.MouseWheel:
						return new PlayerController.MouseWheel.Definition();
					default:
						throw new NotImplementedException();
					}
					break;
				}
			}

			// Token: 0x040003E6 RID: 998
			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			// Token: 0x040003E7 RID: 999
			private readonly PlayerController cwshTRoHHtBEBLqhYvrzJhaDVMbr;

			// Token: 0x040003E8 RID: 1000
			private bool LLAwaTcKRsHdfPoRWWxAXISsneSp;

			// Token: 0x040003E9 RID: 1001
			private bool CLywUvLfwwiOrMJQSJEwkFYVdMCt = true;

			// Token: 0x040003EA RID: 1002
			private string DRfaDeDSSTAUTqtpJVFjOFiDXufJ;

			// Token: 0x040003EB RID: 1003
			private static int[] GeaARGzPQhutcCzrBVImNTGEPDEM;

			// Token: 0x040003EC RID: 1004
			private static int[] CzvpWFIeMKlEJbAKAdBeqQHgSqEd;

			// Token: 0x020000AB RID: 171
			[CustomObfuscation(rename = false)]
			internal enum Type
			{
				// Token: 0x040003EE RID: 1006
				[CustomObfuscation(rename = false)]
				Button,
				// Token: 0x040003EF RID: 1007
				[CustomObfuscation(rename = false)]
				Axis,
				// Token: 0x040003F0 RID: 1008
				[CustomObfuscation(rename = false)]
				MouseAxis,
				// Token: 0x040003F1 RID: 1009
				[CustomObfuscation(rename = false)]
				MouseWheelAxis,
				// Token: 0x040003F2 RID: 1010
				[CustomObfuscation(rename = false)]
				Axis2D = 100,
				// Token: 0x040003F3 RID: 1011
				[CustomObfuscation(rename = false)]
				MouseAxis2D,
				// Token: 0x040003F4 RID: 1012
				[CustomObfuscation(rename = false)]
				MouseWheel
			}

			// Token: 0x020000AC RID: 172
			[CustomObfuscation(rename = false)]
			internal enum TypeWithSource
			{
				// Token: 0x040003F6 RID: 1014
				[CustomObfuscation(rename = false)]
				Button,
				// Token: 0x040003F7 RID: 1015
				[CustomObfuscation(rename = false)]
				Axis,
				// Token: 0x040003F8 RID: 1016
				[CustomObfuscation(rename = false)]
				MouseAxis,
				// Token: 0x040003F9 RID: 1017
				[CustomObfuscation(rename = false)]
				MouseWheelAxis
			}

			// Token: 0x020000AD RID: 173
			[CustomObfuscation(rename = false)]
			internal enum CompoundTypes
			{
				// Token: 0x040003FB RID: 1019
				[CustomObfuscation(rename = false)]
				Axis2D = 100,
				// Token: 0x040003FC RID: 1020
				[CustomObfuscation(rename = false)]
				MouseAxis2D,
				// Token: 0x040003FD RID: 1021
				[CustomObfuscation(rename = false)]
				MouseWheel
			}

			// Token: 0x020000AE RID: 174
			public abstract class Definition
			{
				// Token: 0x060006B2 RID: 1714 RVA: 0x00007ADC File Offset: 0x00005CDC
				public Definition()
				{
					this.enabled = true;
					this.name = null;
				}

				// Token: 0x060006B3 RID: 1715
				internal abstract PlayerController.Element skekXiekWbwhBokIgqZdpnSxXPXK(PlayerController);

				// Token: 0x040003FE RID: 1022
				public bool enabled;

				// Token: 0x040003FF RID: 1023
				public string name;
			}

			// Token: 0x020000AF RID: 175
			internal struct ZKxEnrqufIGdhyxUPaRcGZCDCfjaA
			{
				// Token: 0x060006B4 RID: 1716 RVA: 0x00007AF2 File Offset: 0x00005CF2
				public ZKxEnrqufIGdhyxUPaRcGZCDCfjaA(ControllerElementType A_1, int A_2, float A_3)
				{
					this.RBIseNlpeNiYwaCZJfYgbGAkoRdec = A_1;
					this.cZZXVrPiTaDITEyNPShgvnkEuBPD = A_2;
					this.gapMyJQIwynRENVQIxzWExFmiboB = A_3;
				}

				// Token: 0x04000400 RID: 1024
				public ControllerElementType RBIseNlpeNiYwaCZJfYgbGAkoRdec;

				// Token: 0x04000401 RID: 1025
				public int cZZXVrPiTaDITEyNPShgvnkEuBPD;

				// Token: 0x04000402 RID: 1026
				public float gapMyJQIwynRENVQIxzWExFmiboB;
			}
		}

		// Token: 0x020000B0 RID: 176
		public abstract class ElementWithSource : PlayerController.Element
		{
			// Token: 0x060006B5 RID: 1717 RVA: 0x00007B09 File Offset: 0x00005D09
			internal ElementWithSource(PlayerController A_1, PlayerController.ElementWithSource.Definition A_2) : base(A_1, A_2)
			{
				this.AepWGZPIITszUmoASLpmQcURzlAI = A_2.actionId;
			}

			// Token: 0x1700024E RID: 590
			// (get) Token: 0x060006B6 RID: 1718 RVA: 0x00007B26 File Offset: 0x00005D26
			// (set) Token: 0x060006B7 RID: 1719 RVA: 0x00007B2E File Offset: 0x00005D2E
			public int actionId
			{
				get
				{
					return this.AepWGZPIITszUmoASLpmQcURzlAI;
				}
				set
				{
					this.AepWGZPIITszUmoASLpmQcURzlAI = value;
				}
			}

			// Token: 0x1700024F RID: 591
			// (get) Token: 0x060006B8 RID: 1720 RVA: 0x0003B368 File Offset: 0x00039568
			// (set) Token: 0x060006B9 RID: 1721 RVA: 0x0003B3A4 File Offset: 0x000395A4
			public string actionName
			{
				get
				{
					if (!ReInput.isReady || this.AepWGZPIITszUmoASLpmQcURzlAI < 0)
					{
						return null;
					}
					InputAction action = ReInput.mapping.GetAction(this.AepWGZPIITszUmoASLpmQcURzlAI);
					if (action == null)
					{
						return null;
					}
					return action.name;
				}
				set
				{
					if (!ReInput.isReady)
					{
						return;
					}
					InputAction action = ReInput.mapping.GetAction(value);
					if (action == null)
					{
						this.AepWGZPIITszUmoASLpmQcURzlAI = -1;
						return;
					}
					this.AepWGZPIITszUmoASLpmQcURzlAI = action.id;
				}
			}

			// Token: 0x04000403 RID: 1027
			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			// Token: 0x04000404 RID: 1028
			private int AepWGZPIITszUmoASLpmQcURzlAI = -1;

			// Token: 0x020000B1 RID: 177
			public new abstract class Definition : PlayerController.Element.Definition
			{
				// Token: 0x060006BA RID: 1722 RVA: 0x00007B37 File Offset: 0x00005D37
				public Definition()
				{
					this.jaqIxoMPoTbrtGSPdqRRbfsAYRuP = -1;
				}

				// Token: 0x17000250 RID: 592
				// (get) Token: 0x060006BB RID: 1723 RVA: 0x00007B46 File Offset: 0x00005D46
				// (set) Token: 0x060006BC RID: 1724 RVA: 0x00007B4E File Offset: 0x00005D4E
				public int actionId
				{
					get
					{
						return this.jaqIxoMPoTbrtGSPdqRRbfsAYRuP;
					}
					set
					{
						this.jaqIxoMPoTbrtGSPdqRRbfsAYRuP = value;
					}
				}

				// Token: 0x17000251 RID: 593
				// (get) Token: 0x060006BD RID: 1725 RVA: 0x0003B3DC File Offset: 0x000395DC
				// (set) Token: 0x060006BE RID: 1726 RVA: 0x0003B418 File Offset: 0x00039618
				public string actionName
				{
					get
					{
						if (!ReInput.isReady || this.jaqIxoMPoTbrtGSPdqRRbfsAYRuP < 0)
						{
							return null;
						}
						InputAction action = ReInput.mapping.GetAction(this.jaqIxoMPoTbrtGSPdqRRbfsAYRuP);
						if (action == null)
						{
							return null;
						}
						return action.name;
					}
					set
					{
						if (!ReInput.isReady)
						{
							Logger.LogError("You cannot set an Action Name because Rewired has not been intialized.");
							return;
						}
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							this.jaqIxoMPoTbrtGSPdqRRbfsAYRuP = -1;
							return;
						}
						this.jaqIxoMPoTbrtGSPdqRRbfsAYRuP = action.id;
					}
				}

				// Token: 0x04000405 RID: 1029
				private int jaqIxoMPoTbrtGSPdqRRbfsAYRuP;
			}
		}

		// Token: 0x020000B2 RID: 178
		public sealed class MouseWheel : PlayerController.Axis2D
		{
			// Token: 0x060006BF RID: 1727 RVA: 0x0003B45C File Offset: 0x0003965C
			internal MouseWheel(PlayerController A_1, PlayerController.MouseWheel.Definition A_2)
			{
				PlayerController.Element.Definition[] array;
				if (A_2 == null)
				{
					array = null;
				}
				else
				{
					PlayerController.Element.Definition[] array2 = new PlayerController.Element.Definition[2];
					array2[0] = ((A_2.xAxis != null) ? A_2.xAxis : new PlayerController.MouseWheelAxis.Definition());
					array = array2;
					array2[1] = ((A_2.yAxis != null) ? A_2.yAxis : new PlayerController.MouseWheelAxis.Definition());
				}
				base..ctor(A_1, A_2, array);
			}

			// Token: 0x17000252 RID: 594
			// (get) Token: 0x060006C0 RID: 1728 RVA: 0x00007B57 File Offset: 0x00005D57
			public new PlayerController.MouseWheelAxis xAxis
			{
				get
				{
					return base.ClWUlewvkfNoRjqREkoOCVAwsOdl<PlayerController.MouseWheelAxis>(0);
				}
			}

			// Token: 0x17000253 RID: 595
			// (get) Token: 0x060006C1 RID: 1729 RVA: 0x00007B60 File Offset: 0x00005D60
			public new PlayerController.MouseWheelAxis yAxis
			{
				get
				{
					return base.ClWUlewvkfNoRjqREkoOCVAwsOdl<PlayerController.MouseWheelAxis>(1);
				}
			}

			// Token: 0x020000B3 RID: 179
			public new class Definition : PlayerController.Axis2D.Definition
			{
				// Token: 0x17000254 RID: 596
				// (get) Token: 0x060006C3 RID: 1731 RVA: 0x00007B69 File Offset: 0x00005D69
				// (set) Token: 0x060006C4 RID: 1732 RVA: 0x000078BC File Offset: 0x00005ABC
				public new PlayerController.MouseWheelAxis.Definition xAxis
				{
					get
					{
						return base.xAxis as PlayerController.MouseWheelAxis.Definition;
					}
					set
					{
						base.xAxis = value;
					}
				}

				// Token: 0x17000255 RID: 597
				// (get) Token: 0x060006C5 RID: 1733 RVA: 0x00007B76 File Offset: 0x00005D76
				// (set) Token: 0x060006C6 RID: 1734 RVA: 0x000078D2 File Offset: 0x00005AD2
				public new PlayerController.MouseWheelAxis.Definition yAxis
				{
					get
					{
						return base.yAxis as PlayerController.MouseWheelAxis.Definition;
					}
					set
					{
						base.yAxis = value;
					}
				}

				// Token: 0x060006C7 RID: 1735 RVA: 0x00007B83 File Offset: 0x00005D83
				internal virtual PlayerController.Element eRMzmrTImPaLYrfuObXctburOeim(PlayerController A_1)
				{
					return new PlayerController.MouseWheel(A_1, this);
				}
			}
		}

		// Token: 0x020000B4 RID: 180
		public sealed class MouseWheelAxis : PlayerController.Axis
		{
			// Token: 0x060006C8 RID: 1736 RVA: 0x00007B8C File Offset: 0x00005D8C
			internal MouseWheelAxis(PlayerController A_1, PlayerController.MouseWheelAxis.Definition A_2) : base(A_1, A_2)
			{
				this.repeatRate = A_2.repeatRate;
			}

			// Token: 0x17000256 RID: 598
			// (get) Token: 0x060006C9 RID: 1737 RVA: 0x00007BAD File Offset: 0x00005DAD
			// (set) Token: 0x060006CA RID: 1738 RVA: 0x00007BCE File Offset: 0x00005DCE
			public float repeatRate
			{
				get
				{
					if (this.mLIZRiBDMNKmlTvpqGdxJKHDGRcf == 0f)
					{
						return 0f;
					}
					return 1f / this.mLIZRiBDMNKmlTvpqGdxJKHDGRcf;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						this.mLIZRiBDMNKmlTvpqGdxJKHDGRcf = 0f;
						return;
					}
					this.mLIZRiBDMNKmlTvpqGdxJKHDGRcf = 1f / value;
				}
			}

			// Token: 0x17000257 RID: 599
			// (get) Token: 0x060006CB RID: 1739 RVA: 0x00007C00 File Offset: 0x00005E00
			public override float value
			{
				get
				{
					if (!base.selfAndParentEnabled)
					{
						return 0f;
					}
					return this.UXyFBsimcLCREpXNvwZBoeNoUkPhA;
				}
			}

			// Token: 0x060006CC RID: 1740 RVA: 0x00007C16 File Offset: 0x00005E16
			internal void GREsosXPEvQUXzvLskINWeiCEnOS()
			{
				base.GVwXmOtlACFwYFPpkFViNLfvwVlT();
				if (!base.selfAndParentEnabled)
				{
					return;
				}
				this.UXyFBsimcLCREpXNvwZBoeNoUkPhA = this.UTLAWkJawUXysHhBGKHyYFgqHZLhA();
			}

			// Token: 0x060006CD RID: 1741 RVA: 0x00007C33 File Offset: 0x00005E33
			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					this.pahWLbvgcCJJWYyPRoaBWLWkQjpy();
				}
			}

			// Token: 0x060006CE RID: 1742 RVA: 0x0003B4B0 File Offset: 0x000396B0
			private float UTLAWkJawUXysHhBGKHyYFgqHZLhA()
			{
				if (base.player == null)
				{
					return 0f;
				}
				float num = base.player.GetAxis(base.actionId);
				AxisCoordinateMode axisCoordinateMode = base.player.GetAxisCoordinateMode(base.actionId);
				if (axisCoordinateMode != AxisCoordinateMode.Absolute)
				{
					if (axisCoordinateMode != AxisCoordinateMode.Relative)
					{
					}
				}
				else
				{
					bool flag = false;
					if (base.player.GetButtonDown(base.actionId))
					{
						flag = true;
						num = 1f;
					}
					else if (base.player.GetNegativeButtonDown(base.actionId))
					{
						flag = true;
						num = -1f;
					}
					if (!flag && ReInput.unscaledTime < this.DEIfaJSTbUwubXjBxIcAmcmXYiEe + (double)this.mLIZRiBDMNKmlTvpqGdxJKHDGRcf)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					this.DEIfaJSTbUwubXjBxIcAmcmXYiEe = ReInput.unscaledTime;
				}
				return num;
			}

			// Token: 0x060006CF RID: 1743 RVA: 0x00007C45 File Offset: 0x00005E45
			private void pahWLbvgcCJJWYyPRoaBWLWkQjpy()
			{
				this.UXyFBsimcLCREpXNvwZBoeNoUkPhA = 0f;
				this.DEIfaJSTbUwubXjBxIcAmcmXYiEe = 0.0;
			}

			// Token: 0x04000406 RID: 1030
			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			// Token: 0x04000407 RID: 1031
			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			// Token: 0x04000408 RID: 1032
			private const float jqltKAEumLlIHXHMgxblkBBOplWh = 0.01f;

			// Token: 0x04000409 RID: 1033
			private float mLIZRiBDMNKmlTvpqGdxJKHDGRcf = 0.25f;

			// Token: 0x0400040A RID: 1034
			private double DEIfaJSTbUwubXjBxIcAmcmXYiEe;

			// Token: 0x0400040B RID: 1035
			private float UXyFBsimcLCREpXNvwZBoeNoUkPhA;

			// Token: 0x020000B5 RID: 181
			public new class Definition : PlayerController.Axis.Definition
			{
				// Token: 0x060006D0 RID: 1744 RVA: 0x00007C61 File Offset: 0x00005E61
				public Definition()
				{
					this.coordinateMode = AxisCoordinateMode.Relative;
					this.repeatRate = 4f;
				}

				// Token: 0x060006D1 RID: 1745 RVA: 0x00007C7B File Offset: 0x00005E7B
				internal virtual PlayerController.Element EODFLdiyLrEkeWUhPZiIbxstzrC(PlayerController A_1)
				{
					return new PlayerController.MouseWheelAxis(A_1, this);
				}

				// Token: 0x0400040C RID: 1036
				public float repeatRate;
			}
		}
	}
}
