using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;

namespace Rewired.InputManagers
{
	// Token: 0x020001D5 RID: 469
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class CustomInputManager : PlatformInputManager
	{
		// Token: 0x060017F1 RID: 6129 RVA: 0x0006F2F8 File Offset: 0x0006D4F8
		public CustomInputManager(CustomInputSource A_1, UpdateLoopSetting A_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_3, Func<int> A_4)
		{
			this.aaWaDLqJGvIJtduksTATDfCszLvX = A_1;
			this.GaXdLuImqNXAZEIaiOsqAbYBiAZJ = A_3;
			this.QhiihYZzyuPXIwuHcRwnorBZQEOq = A_4;
			this.qySrWuvZUCHWJMlKlmVNCJIcOkNT = this;
			try
			{
				this.KHKdhvIurWjginfjMkJJsCkXYOsc = new Action<int, ControllerDataUpdater>(this.UpdateControllerData);
				A_1.OCIJgUKOfUZUGllNZnYTtQcWnVjP += this.SystemDeviceConnected;
				A_1.esBuenIcaDNTBCTlulCudoizNLJg += this.SystemDeviceDisconnected;
			}
			catch (Exception)
			{
				this.OnDestroy();
				throw;
			}
		}

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x060017F2 RID: 6130 RVA: 0x0001479D File Offset: 0x0001299D
		[CustomObfuscation(rename = false)]
		public override int deviceCount
		{
			get
			{
				return this.hARWXmHAbnKDUKOJiYdMepeNbOffA;
			}
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x060017F3 RID: 6131 RVA: 0x000147A5 File Offset: 0x000129A5
		[CustomObfuscation(rename = false)]
		public override PlatformInputManager primaryInputManager
		{
			get
			{
				return this.qySrWuvZUCHWJMlKlmVNCJIcOkNT;
			}
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x060017F4 RID: 6132 RVA: 0x000067FE File Offset: 0x000049FE
		[CustomObfuscation(rename = false)]
		public override IInputSource inputSource
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x060017F5 RID: 6133 RVA: 0x000147AD File Offset: 0x000129AD
		[CustomObfuscation(rename = false)]
		public override InputSource inputSourceType
		{
			get
			{
				return this.aaWaDLqJGvIJtduksTATDfCszLvX.gqmHoFRhzjEYMIkPKkmRVUsgxjpg;
			}
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x000147BA File Offset: 0x000129BA
		[CustomObfuscation(rename = false)]
		public override void Initialize()
		{
			this.KZKagwFLMhHYxYcsTdxtMfmbRgvwA = new CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd();
			this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA = new List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB>();
			this.eoLSIYNVQCoiFBeqHAjlLIWGhblk = true;
			this.aaWaDLqJGvIJtduksTATDfCszLvX.JLAerzKwkOEHiFXjkpSPmTPwZEIv();
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x0006F37C File Offset: 0x0006D57C
		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			this.gkBhrcfKuKYQwiCPNyZhEqowmlZk = updateLoop;
			if (!this.aaWaDLqJGvIJtduksTATDfCszLvX.isReady)
			{
				return;
			}
			this.aaWaDLqJGvIJtduksTATDfCszLvX.Update();
			this.aaWaDLqJGvIJtduksTATDfCszLvX.pkUAzDKcsykDawzPXDyONdNaTfuU();
			if (this.eoLSIYNVQCoiFBeqHAjlLIWGhblk)
			{
				this.tAufZypNoxdUXkSpBjILIdRiEvVW();
			}
			this.CWdOWZPoVnoldqsqEEiyamkGkxRL();
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x000147E4 File Offset: 0x000129E4
		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (this.aaWaDLqJGvIJtduksTATDfCszLvX != null)
			{
				this.aaWaDLqJGvIJtduksTATDfCszLvX.Dispose();
			}
		}

		// Token: 0x060017F9 RID: 6137 RVA: 0x000147F9 File Offset: 0x000129F9
		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return this.KHKdhvIurWjginfjMkJJsCkXYOsc;
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x0006F3C8 File Offset: 0x0006D5C8
		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < this.hARWXmHAbnKDUKOJiYdMepeNbOffA; i++)
			{
				if (this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA[i].inputManagerId == inputManagerId)
				{
					this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId.ToString() + "!");
		}

		// Token: 0x060017FB RID: 6139 RVA: 0x00014801 File Offset: 0x00012A01
		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			this.eoLSIYNVQCoiFBeqHAjlLIWGhblk = true;
			if (this._SystemDeviceConnectedEvent != null)
			{
				this._SystemDeviceConnectedEvent();
			}
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x0001481D File Offset: 0x00012A1D
		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			this.eoLSIYNVQCoiFBeqHAjlLIWGhblk = true;
			if (this._SystemDeviceDisconnectedEvent != null)
			{
				this._SystemDeviceDisconnectedEvent();
			}
		}

		// Token: 0x060017FD RID: 6141 RVA: 0x00002FF9 File Offset: 0x000011F9
		[CustomObfuscation(rename = false)]
		public override void SetUnityJoystickId(int joystickId, int unityJoystickIndex)
		{
		}

		// Token: 0x060017FE RID: 6142 RVA: 0x00014839 File Offset: 0x00012A39
		[CustomObfuscation(rename = false)]
		public override IUnifiedMouseSource GetUnifiedMouseSource()
		{
			return this.aaWaDLqJGvIJtduksTATDfCszLvX.RoGrwwlaTTFqZxlGvVsoZGCktzSI();
		}

		// Token: 0x060017FF RID: 6143 RVA: 0x00014846 File Offset: 0x00012A46
		[CustomObfuscation(rename = false)]
		public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
		{
			return this.aaWaDLqJGvIJtduksTATDfCszLvX.OYKCcFUDuoxxbZeLGHhfyyQhGsRf();
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x0006F428 File Offset: 0x0006D628
		private void HKWWxAtILWTFQoSOpvujLAJkNbgJ(CustomInputSource.Joystick[] A_1)
		{
			int num = 0;
			List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> list = this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA;
			int num2 = this.hARWXmHAbnKDUKOJiYdMepeNbOffA;
			this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA = new List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB>();
			for (int i = 0; i < A_1.Length; i++)
			{
				if (A_1[i] != null)
				{
					CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB item = new CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB(this.aaWaDLqJGvIJtduksTATDfCszLvX, A_1[i].systemId, A_1[i].unityId, A_1[i], this.aaWaDLqJGvIJtduksTATDfCszLvX.gqmHoFRhzjEYMIkPKkmRVUsgxjpg, A_1[i].extension, this.GaXdLuImqNXAZEIaiOsqAbYBiAZJ);
					this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA.Add(item);
					num++;
				}
			}
			this.hARWXmHAbnKDUKOJiYdMepeNbOffA = num;
			this.phRLNHCsBSUHtErhAkYCtPlFeMHX(num2, num, list, this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA);
			for (int j = 0; j < num; j++)
			{
				if (this._UpdateControllerInfoEvent != null)
				{
					this._UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA[j]));
				}
			}
			this.UXxmAbJdOgkhgPrRQEjheAAlILCg(list, this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA, false);
			this.UXxmAbJdOgkhgPrRQEjheAAlILCg(this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA, list, true);
		}

		// Token: 0x06001801 RID: 6145 RVA: 0x0006F514 File Offset: 0x0006D714
		private void CWdOWZPoVnoldqsqEEiyamkGkxRL()
		{
			for (int i = 0; i < this.hARWXmHAbnKDUKOJiYdMepeNbOffA; i++)
			{
				this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA[i].Update();
			}
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x0006F544 File Offset: 0x0006D744
		private void phRLNHCsBSUHtErhAkYCtPlFeMHX(int A_1, int A_2, List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_3, List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_4)
		{
			if (A_2 > 0)
			{
				A_4.Sort(new Comparison<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB>(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB.zseesaEVMjIDysuyVukduvlSOJbu));
			}
			if (A_1 > 0 && A_2 > 0)
			{
				this.BuQsACfcBcNUnkMOuwNJdCrVngLf(A_2, A_4, A_1, A_3, CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct.Exact);
				if (this.aaWaDLqJGvIJtduksTATDfCszLvX.useApproximateMatching)
				{
					this.BuQsACfcBcNUnkMOuwNJdCrVngLf(A_2, A_4, A_1, A_3, CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct.Approximate);
				}
			}
			this.mwPkCPycBxrRDdtidJSNRtVqgFSN(A_2, A_4, CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct.Exact);
			if (this.aaWaDLqJGvIJtduksTATDfCszLvX.useApproximateMatching)
			{
				this.mwPkCPycBxrRDdtidJSNRtVqgFSN(A_2, A_4, CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct.Approximate);
			}
			for (int i = 0; i < A_2; i++)
			{
				CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB uinrhINWandtHykTyTDZfnkOuyxB = A_4[i];
				if (uinrhINWandtHykTyTDZfnkOuyxB != null && uinrhINWandtHykTyTDZfnkOuyxB.inputManagerId < 0)
				{
					uinrhINWandtHykTyTDZfnkOuyxB.inputManagerId = this.lhMhiYyczyNGQWMMjcMctndSaWic(A_4);
					uinrhINWandtHykTyTDZfnkOuyxB.rewiredId = ReInput.GetNewJoystickId();
					this.KZKagwFLMhHYxYcsTdxtMfmbRgvwA.FJvBWgLxevvFUwIEXDIMJZPFuxpL(uinrhINWandtHykTyTDZfnkOuyxB);
				}
			}
			A_4.Sort(new Comparison<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB>(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB.FPSBjAGMKboikceJpUJPDYbOpRWM));
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x0006F614 File Offset: 0x0006D814
		private void uhUeHMemraiyqGyldeBrLtCGHivRA(List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_1, int A_2, int A_3)
		{
			int count = A_1.Count;
			for (int i = 0; i < count; i++)
			{
				if (i != A_2 && A_1[i] != null && A_1[i].inputManagerId == A_3)
				{
					A_1[i].inputManagerId = -1;
				}
			}
		}

		// Token: 0x06001804 RID: 6148 RVA: 0x0006F660 File Offset: 0x0006D860
		private bool aWOAyfCqIxuZGsTYmrBxnAKCrNsz(List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_1, int A_2)
		{
			int count = A_1.Count;
			for (int i = 0; i < count; i++)
			{
				if (A_1[i] != null && A_1[i].inputManagerId == A_2)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001805 RID: 6149 RVA: 0x0006F69C File Offset: 0x0006D89C
		private int lhMhiYyczyNGQWMMjcMctndSaWic(List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_1)
		{
			int num = 0;
			for (;;)
			{
				bool flag = false;
				int count = A_1.Count;
				for (int i = 0; i < count; i++)
				{
					if (A_1[i] != null && A_1[i].inputManagerId == num)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				num++;
			}
			return num;
		}

		// Token: 0x06001806 RID: 6150 RVA: 0x0006F6E8 File Offset: 0x0006D8E8
		private bool qzyjhOYkPzGKNndWnccDKOjpdEPEb(List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_1, int A_2)
		{
			if (A_1 == null)
			{
				return false;
			}
			for (int i = 0; i < A_1.Count; i++)
			{
				if (A_1[i].rewiredId == A_2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001807 RID: 6151 RVA: 0x0006F720 File Offset: 0x0006D920
		private void BuQsACfcBcNUnkMOuwNJdCrVngLf(int A_1, List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_2, int A_3, List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_4, CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct A_5)
		{
			int num = (A_5 == CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct.Exact) ? 2 : 1;
			for (int i = 0; i < A_1; i++)
			{
				CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB uinrhINWandtHykTyTDZfnkOuyxB = A_2[i];
				if (uinrhINWandtHykTyTDZfnkOuyxB != null && uinrhINWandtHykTyTDZfnkOuyxB.inputManagerId < 0)
				{
					for (int j = 0; j < A_3; j++)
					{
						CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB uinrhINWandtHykTyTDZfnkOuyxB2 = A_4[j];
						if (uinrhINWandtHykTyTDZfnkOuyxB2 != null && !this.qzyjhOYkPzGKNndWnccDKOjpdEPEb(A_2, uinrhINWandtHykTyTDZfnkOuyxB2.rewiredId) && uinrhINWandtHykTyTDZfnkOuyxB.hieidPDnrYZVWCKEypZNvaZzqVKl(uinrhINWandtHykTyTDZfnkOuyxB2) >= num)
						{
							uinrhINWandtHykTyTDZfnkOuyxB.inputManagerId = uinrhINWandtHykTyTDZfnkOuyxB2.inputManagerId;
							uinrhINWandtHykTyTDZfnkOuyxB.rewiredId = uinrhINWandtHykTyTDZfnkOuyxB2.rewiredId;
							this.KZKagwFLMhHYxYcsTdxtMfmbRgvwA.FJvBWgLxevvFUwIEXDIMJZPFuxpL(uinrhINWandtHykTyTDZfnkOuyxB);
						}
					}
				}
			}
		}

		// Token: 0x06001808 RID: 6152 RVA: 0x0006F7B4 File Offset: 0x0006D9B4
		private void mwPkCPycBxrRDdtidJSNRtVqgFSN(int A_1, List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_2, CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct A_3)
		{
			for (int i = 0; i < A_1; i++)
			{
				CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB uinrhINWandtHykTyTDZfnkOuyxB = A_2[i];
				if (uinrhINWandtHykTyTDZfnkOuyxB != null && uinrhINWandtHykTyTDZfnkOuyxB.inputManagerId < 0)
				{
					CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.olwTSczyDuwReEaHoFRnfoqCaovx olwTSczyDuwReEaHoFRnfoqCaovx = null;
					foreach (CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.olwTSczyDuwReEaHoFRnfoqCaovx olwTSczyDuwReEaHoFRnfoqCaovx2 in this.KZKagwFLMhHYxYcsTdxtMfmbRgvwA.tPrbWhtFmmjoyLWAceVXsocmbZqw(uinrhINWandtHykTyTDZfnkOuyxB, A_3))
					{
						if (!this.qzyjhOYkPzGKNndWnccDKOjpdEPEb(A_2, olwTSczyDuwReEaHoFRnfoqCaovx2.CPCJtzHakMYhrXUNdIODDebRYHYp) && olwTSczyDuwReEaHoFRnfoqCaovx2.rdLaHxalSwXLcDMpKjzuHdLSeIkaA >= 0)
						{
							olwTSczyDuwReEaHoFRnfoqCaovx = olwTSczyDuwReEaHoFRnfoqCaovx2;
							break;
						}
					}
					if (olwTSczyDuwReEaHoFRnfoqCaovx != null)
					{
						int num = olwTSczyDuwReEaHoFRnfoqCaovx.rdLaHxalSwXLcDMpKjzuHdLSeIkaA;
						if (!this.aWOAyfCqIxuZGsTYmrBxnAKCrNsz(A_2, num))
						{
							num = this.lhMhiYyczyNGQWMMjcMctndSaWic(A_2);
							olwTSczyDuwReEaHoFRnfoqCaovx.rdLaHxalSwXLcDMpKjzuHdLSeIkaA = num;
						}
						uinrhINWandtHykTyTDZfnkOuyxB.inputManagerId = num;
						uinrhINWandtHykTyTDZfnkOuyxB.rewiredId = olwTSczyDuwReEaHoFRnfoqCaovx.CPCJtzHakMYhrXUNdIODDebRYHYp;
						this.KZKagwFLMhHYxYcsTdxtMfmbRgvwA.FJvBWgLxevvFUwIEXDIMJZPFuxpL(uinrhINWandtHykTyTDZfnkOuyxB);
					}
				}
			}
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x0006F898 File Offset: 0x0006DA98
		private void tAufZypNoxdUXkSpBjILIdRiEvVW()
		{
			CustomInputSource.Joystick[] array = this.aaWaDLqJGvIJtduksTATDfCszLvX.WDGbOlKfyvSlsCRXyhZoaKzfxZYqB();
			if (this.QCzHuzgCOHlQBpkOKBLNGQfhIneu(array))
			{
				this.HKWWxAtILWTFQoSOpvujLAJkNbgJ(array);
			}
			this.eoLSIYNVQCoiFBeqHAjlLIWGhblk = false;
		}

		// Token: 0x0600180A RID: 6154 RVA: 0x0006F8C8 File Offset: 0x0006DAC8
		private bool QCzHuzgCOHlQBpkOKBLNGQfhIneu(CustomInputSource.Joystick[] A_1)
		{
			int num = A_1.Length;
			int count = this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA.Count;
			if (num != count)
			{
				return true;
			}
			for (int i = 0; i < num; i++)
			{
				if (A_1[i] != null)
				{
					long? systemId = A_1[i].systemId;
					bool flag = false;
					for (int j = 0; j < count; j++)
					{
						if (this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA[j] != null)
						{
							long? num2 = systemId;
							long? num3 = this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA[j].systemId;
							if (num2.GetValueOrDefault() == num3.GetValueOrDefault() & num2 != null == (num3 != null))
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						return true;
					}
				}
			}
			for (int k = 0; k < count; k++)
			{
				if (this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA[k] != null)
				{
					long? systemId2 = this.aWlvtFKiJGihZBFfnJdVAVeRpsQAA[k].systemId;
					bool flag2 = false;
					for (int l = 0; l < num; l++)
					{
						if (A_1[l] != null)
						{
							long? num3 = systemId2;
							long? num2 = A_1[l].systemId;
							if (num3.GetValueOrDefault() == num2.GetValueOrDefault() & num3 != null == (num2 != null))
							{
								flag2 = true;
								break;
							}
						}
					}
					if (!flag2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0006F9FC File Offset: 0x0006DBFC
		private void UXxmAbJdOgkhgPrRQEjheAAlILCg(List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_1, List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> A_2, bool A_3)
		{
			if (A_1 == null)
			{
				return;
			}
			int num = (A_1 != null) ? A_1.Count : 0;
			int num2 = (A_2 != null) ? A_2.Count : 0;
			for (int i = 0; i < num; i++)
			{
				CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB uinrhINWandtHykTyTDZfnkOuyxB = A_1[i];
				if (uinrhINWandtHykTyTDZfnkOuyxB != null)
				{
					bool flag = false;
					if (A_2 != null)
					{
						for (int j = 0; j < num2; j++)
						{
							CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB uinrhINWandtHykTyTDZfnkOuyxB2 = A_2[j];
							if (uinrhINWandtHykTyTDZfnkOuyxB2 != null && uinrhINWandtHykTyTDZfnkOuyxB.rewiredId == uinrhINWandtHykTyTDZfnkOuyxB2.rewiredId)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						this.bvRTlcTdwQGRGRAVrVZUqgdHMJGT(A_1[i], A_3);
					}
				}
			}
		}

		// Token: 0x0600180C RID: 6156 RVA: 0x00014853 File Offset: 0x00012A53
		private void bvRTlcTdwQGRGRAVrVZUqgdHMJGT(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_1, bool A_2)
		{
			if (A_2)
			{
				A_1.quGTeAUMrbiCrWBcaYqZNbZZglbv();
			}
			this.PNRBYkflwVDOeQKGJEsLbcuDXejAB(A_1, A_2);
		}

		// Token: 0x0600180D RID: 6157 RVA: 0x00014866 File Offset: 0x00012A66
		private void PNRBYkflwVDOeQKGJEsLbcuDXejAB(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_1, bool A_2)
		{
			if (A_2)
			{
				if (this._DeviceConnectedEvent != null)
				{
					this._DeviceConnectedEvent(A_1.ToBridgedController());
					return;
				}
			}
			else if (this._DeviceDisconnectedEvent != null)
			{
				this._DeviceDisconnectedEvent(A_1.ToControllerDisconnectedEventArgs());
			}
		}

		// Token: 0x04000D1C RID: 3356
		private List<CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB> aWlvtFKiJGihZBFfnJdVAVeRpsQAA;

		// Token: 0x04000D1D RID: 3357
		private int hARWXmHAbnKDUKOJiYdMepeNbOffA;

		// Token: 0x04000D1E RID: 3358
		private CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd KZKagwFLMhHYxYcsTdxtMfmbRgvwA;

		// Token: 0x04000D1F RID: 3359
		private UpdateLoopType gkBhrcfKuKYQwiCPNyZhEqowmlZk;

		// Token: 0x04000D20 RID: 3360
		private Action<int, ControllerDataUpdater> KHKdhvIurWjginfjMkJJsCkXYOsc;

		// Token: 0x04000D21 RID: 3361
		private PlatformInputManager qySrWuvZUCHWJMlKlmVNCJIcOkNT;

		// Token: 0x04000D22 RID: 3362
		private CustomInputSource aaWaDLqJGvIJtduksTATDfCszLvX;

		// Token: 0x04000D23 RID: 3363
		private bool eoLSIYNVQCoiFBeqHAjlLIWGhblk;

		// Token: 0x04000D24 RID: 3364
		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> GaXdLuImqNXAZEIaiOsqAbYBiAZJ;

		// Token: 0x04000D25 RID: 3365
		private Func<int> QhiihYZzyuPXIwuHcRwnorBZQEOq;

		// Token: 0x020001D6 RID: 470
		private class uinrhINWandtHykTyTDZfnkOuyxB : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
		{
			// Token: 0x170005B0 RID: 1456
			// (get) Token: 0x0600180E RID: 6158 RVA: 0x0001489E File Offset: 0x00012A9E
			public int HayMMJGvTcfZbicoVJYRKBLLYhhy
			{
				get
				{
					if (this.KlrZtPQDqHFhstzuAekGstofGmAl == null)
					{
						return 0;
					}
					return this.KlrZtPQDqHFhstzuAekGstofGmAl.buttonCount;
				}
			}

			// Token: 0x170005B1 RID: 1457
			// (get) Token: 0x0600180F RID: 6159 RVA: 0x000148B5 File Offset: 0x00012AB5
			public int XzWQvtyceLfyKOUBYXLXqAwjcNHO
			{
				get
				{
					if (this.KlrZtPQDqHFhstzuAekGstofGmAl == null)
					{
						return 0;
					}
					return this.KlrZtPQDqHFhstzuAekGstofGmAl.axisCount;
				}
			}

			// Token: 0x170005B2 RID: 1458
			// (get) Token: 0x06001810 RID: 6160 RVA: 0x000148CC File Offset: 0x00012ACC
			// (set) Token: 0x06001811 RID: 6161 RVA: 0x000148D4 File Offset: 0x00012AD4
			[CustomObfuscation(rename = false)]
			public int rewiredId
			{
				get
				{
					return this.FJhZWTMaJHfDmkycyEZvMxGQNyBbA;
				}
				set
				{
					this.FJhZWTMaJHfDmkycyEZvMxGQNyBbA = value;
				}
			}

			// Token: 0x170005B3 RID: 1459
			// (get) Token: 0x06001812 RID: 6162 RVA: 0x000148DD File Offset: 0x00012ADD
			// (set) Token: 0x06001813 RID: 6163 RVA: 0x000148E5 File Offset: 0x00012AE5
			[CustomObfuscation(rename = false)]
			public int inputManagerId
			{
				get
				{
					return this.zvuTDbWBrptkdNXJwAjFQBmdHYVz;
				}
				set
				{
					this.zvuTDbWBrptkdNXJwAjFQBmdHYVz = value;
				}
			}

			// Token: 0x170005B4 RID: 1460
			// (get) Token: 0x06001814 RID: 6164 RVA: 0x0006FA88 File Offset: 0x0006DC88
			[CustomObfuscation(rename = false)]
			public string name
			{
				get
				{
					string text = (!string.IsNullOrEmpty(this.KlrZtPQDqHFhstzuAekGstofGmAl.customName)) ? this.KlrZtPQDqHFhstzuAekGstofGmAl.customName : this.KEjayFdfKeaySHUheWGXCtotOwdUA;
					if (text == "Unknown Controller")
					{
						text = this.NOFxtygDcwxfSiYTFLmYeiDsVVdv;
					}
					return text;
				}
			}

			// Token: 0x170005B5 RID: 1461
			// (get) Token: 0x06001815 RID: 6165 RVA: 0x000148EE File Offset: 0x00012AEE
			[CustomObfuscation(rename = false)]
			public long? systemId
			{
				get
				{
					return this.hCpCvZbrvFAhXbJQSVRPzZfGrJNTA;
				}
			}

			// Token: 0x170005B6 RID: 1462
			// (get) Token: 0x06001816 RID: 6166 RVA: 0x000148F6 File Offset: 0x00012AF6
			[CustomObfuscation(rename = false)]
			public int unityId
			{
				get
				{
					return this.VTXBPbkTCXtVRwPOMaSIWCFvCVjQ;
				}
			}

			// Token: 0x170005B7 RID: 1463
			// (get) Token: 0x06001817 RID: 6167 RVA: 0x000148FE File Offset: 0x00012AFE
			[CustomObfuscation(rename = false)]
			public Guid instanceGuid
			{
				get
				{
					if (this.hCpCvZbrvFAhXbJQSVRPzZfGrJNTA == null)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(this.name + "_" + this.hCpCvZbrvFAhXbJQSVRPzZfGrJNTA.ToString());
				}
			}

			// Token: 0x170005B8 RID: 1464
			// (get) Token: 0x06001818 RID: 6168 RVA: 0x00014939 File Offset: 0x00012B39
			[CustomObfuscation(rename = false)]
			public Guid persistentGuid
			{
				get
				{
					if (!(this.KlrZtPQDqHFhstzuAekGstofGmAl.deviceInstanceGuid != Guid.Empty))
					{
						return this.instanceGuid;
					}
					return this.KlrZtPQDqHFhstzuAekGstofGmAl.deviceInstanceGuid;
				}
			}

			// Token: 0x170005B9 RID: 1465
			// (get) Token: 0x06001819 RID: 6169 RVA: 0x00014964 File Offset: 0x00012B64
			[CustomObfuscation(rename = false)]
			public Controller.Extension extension
			{
				get
				{
					return this.xRLSKURcDbCbElTFtjBukZJkeAyFb;
				}
			}

			// Token: 0x0600181A RID: 6170 RVA: 0x00002FF9 File Offset: 0x000011F9
			[CustomObfuscation(rename = false)]
			public void SetVibration(float amount, int motorIndex)
			{
			}

			// Token: 0x0600181B RID: 6171 RVA: 0x00002FF9 File Offset: 0x000011F9
			[CustomObfuscation(rename = false)]
			public void StopVibration()
			{
			}

			// Token: 0x0600181C RID: 6172 RVA: 0x0006FAD0 File Offset: 0x0006DCD0
			public uinrhINWandtHykTyTDZfnkOuyxB(CustomInputSource A_1, long? A_2, int A_3, CustomInputSource.Joystick A_4, InputSource A_5, Controller.Extension A_6, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_7)
			{
				this.HrHbXpceDuiHoNHWXmbEBNzfnPxXB = (A_1.gqmHoFRhzjEYMIkPKkmRVUsgxjpg == InputSource.PS4 || A_1.gqmHoFRhzjEYMIkPKkmRVUsgxjpg == InputSource.PS5);
				this.hJjUQQrBZRtnYSFRVCmWBxIDHIco = new LocalizedString();
				this.GSJVneaWhtSTfWwxBTRDfWgDaHwr = A_1;
				this.KjkTpZnuoOVNaQdKtiOBFemSeEyhA = A_5;
				this.hCpCvZbrvFAhXbJQSVRPzZfGrJNTA = A_2;
				this.KlrZtPQDqHFhstzuAekGstofGmAl = A_4;
				this.VTXBPbkTCXtVRwPOMaSIWCFvCVjQ = A_3;
				this.xRLSKURcDbCbElTFtjBukZJkeAyFb = A_6;
				this.foqKtCgYBKfTdVqXkkpQaQfBAXPh = A_7;
				this.zvuTDbWBrptkdNXJwAjFQBmdHYVz = -1;
				this.FJhZWTMaJHfDmkycyEZvMxGQNyBbA = -1;
				this.quGTeAUMrbiCrWBcaYqZNbZZglbv();
				this.TmuJjeuyznTBhQUwMphwGvyoTAbA();
				this.bEDjgPGoXdDSFJCzMbrGxnnOCfCh = this.ySDRhxQpcBQFaxjIyUYsXQofhxlD.hardwareMapIdentifier.guid;
				this.KEjayFdfKeaySHUheWGXCtotOwdUA = this.ySDRhxQpcBQFaxjIyUYsXQofhxlD.controllerName;
				this.mkNNzyCGCcsSdTPKuzRqTSEAsgrL = new float[this.wqhkIMkzWLQPWdiprQWGrXDQwarC];
				this.nmnHFPutVdlqXQzYBzNEBIEZeiff = new bool[this.GbnxiuYGRaFIPgudKpmMXwiceWAx];
				this.hzQmsdZIGOWnTblbDPrwqIIIfaajA = new float[this.GbnxiuYGRaFIPgudKpmMXwiceWAx];
				this.dtaALDJbLNtrNgqskoLMlqmCYhKcA = new bool[this.GbnxiuYGRaFIPgudKpmMXwiceWAx];
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)this.ySDRhxQpcBQFaxjIyUYsXQofhxlD.map).Buttons;
				if (buttons != null)
				{
					int num = MathTools.Min(buttons.Length, this.GbnxiuYGRaFIPgudKpmMXwiceWAx);
					for (int i = 0; i < num; i++)
					{
						if (buttons[i] != null && buttons[i].buttonInfo != null)
						{
							this.dtaALDJbLNtrNgqskoLMlqmCYhKcA[i] = buttons[i].buttonInfo.isPressureSensitive;
						}
					}
				}
				this.Update();
			}

			// Token: 0x0600181D RID: 6173 RVA: 0x0001496C File Offset: 0x00012B6C
			public void quGTeAUMrbiCrWBcaYqZNbZZglbv()
			{
				this.NOFxtygDcwxfSiYTFLmYeiDsVVdv = this.KlrZtPQDqHFhstzuAekGstofGmAl.deviceName;
			}

			// Token: 0x0600181E RID: 6174 RVA: 0x0001497F File Offset: 0x00012B7F
			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (!this.KlrZtPQDqHFhstzuAekGstofGmAl.isConnected)
				{
					return;
				}
				this.fNgncQqrzkDQZTQCptlEJpbQBXFo();
				this.kAoTCFwGvVRpYjTqFMmIGdvPureW();
			}

			// Token: 0x0600181F RID: 6175 RVA: 0x0006FC24 File Offset: 0x0006DE24
			public int hieidPDnrYZVWCKEypZNvaZzqVKl(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_1)
			{
				if (A_1.NOFxtygDcwxfSiYTFLmYeiDsVVdv == this.NOFxtygDcwxfSiYTFLmYeiDsVVdv)
				{
					long? num = A_1.hCpCvZbrvFAhXbJQSVRPzZfGrJNTA;
					long? num2 = this.hCpCvZbrvFAhXbJQSVRPzZfGrJNTA;
					if (num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null))
					{
						return 2;
					}
				}
				if (A_1.NOFxtygDcwxfSiYTFLmYeiDsVVdv == this.NOFxtygDcwxfSiYTFLmYeiDsVVdv)
				{
					return 1;
				}
				return 0;
			}

			// Token: 0x06001820 RID: 6176 RVA: 0x0006FC90 File Offset: 0x0006DE90
			private void QudMjOGONmAJcuykFjCWHQpuVoQC(BridgedControllerHWInfo A_1)
			{
				A_1.inputManagerSource = this.KjkTpZnuoOVNaQdKtiOBFemSeEyhA;
				A_1.inputSource = this.KjkTpZnuoOVNaQdKtiOBFemSeEyhA;
				A_1.hardwareIdentifier = this.yIUXHXHLSuPGEYZYJEEyuOwxJcih();
				A_1.hardwareAxisCount = this.wqhkIMkzWLQPWdiprQWGrXDQwarC;
				A_1.hardwareButtonCount = this.GbnxiuYGRaFIPgudKpmMXwiceWAx;
				A_1.hardwareHatCount = 0;
				A_1.hw_productName = this.NOFxtygDcwxfSiYTFLmYeiDsVVdv;
				A_1.hw_supportsVibration = this.KlrZtPQDqHFhstzuAekGstofGmAl.supportsVibration;
				A_1.userCustomIdentifier = this.KlrZtPQDqHFhstzuAekGstofGmAl.customIdentifier;
			}

			// Token: 0x06001821 RID: 6177 RVA: 0x0006FD10 File Offset: 0x0006DF10
			private void HHszUAChqmbraNNjvfWggeJgRTBjA(BridgedController A_1)
			{
				this.QudMjOGONmAJcuykFjCWHQpuVoQC(A_1);
				A_1.sourceJoystick = this;
				A_1.gameHardwareMap = this.ySDRhxQpcBQFaxjIyUYsXQofhxlD.ToGameHardwareControllerMap();
				A_1.instanceName = this.NOFxtygDcwxfSiYTFLmYeiDsVVdv;
				A_1.productName = this.NOFxtygDcwxfSiYTFLmYeiDsVVdv;
				A_1.isXInputDevice = false;
				A_1.axisCount = this.wqhkIMkzWLQPWdiprQWGrXDQwarC;
				A_1.buttonCount = this.GbnxiuYGRaFIPgudKpmMXwiceWAx;
				A_1.controllerTypeGuid = this.bEDjgPGoXdDSFJCzMbrGxnnOCfCh;
				A_1.customInputSource = this.GSJVneaWhtSTfWwxBTRDfWgDaHwr;
				A_1.controllerExtension = this.xRLSKURcDbCbElTFtjBukZJkeAyFb;
				A_1.isButtonPressureSensitive = new bool[this.dtaALDJbLNtrNgqskoLMlqmCYhKcA.Length];
				for (int i = 0; i < this.dtaALDJbLNtrNgqskoLMlqmCYhKcA.Length; i++)
				{
					A_1.isButtonPressureSensitive[i] = this.dtaALDJbLNtrNgqskoLMlqmCYhKcA[i];
				}
			}

			// Token: 0x06001822 RID: 6178 RVA: 0x0006FDD0 File Offset: 0x0006DFD0
			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (this.wqhkIMkzWLQPWdiprQWGrXDQwarC != dataUpdater.axisCount || this.GbnxiuYGRaFIPgudKpmMXwiceWAx != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < this.wqhkIMkzWLQPWdiprQWGrXDQwarC; i++)
				{
					dataUpdater.axisValues[i] = this.mkNNzyCGCcsSdTPKuzRqTSEAsgrL[i];
				}
				for (int j = 0; j < this.GbnxiuYGRaFIPgudKpmMXwiceWAx; j++)
				{
					if (this.dtaALDJbLNtrNgqskoLMlqmCYhKcA[j])
					{
						dataUpdater.buttonPressureValues[j] = this.hzQmsdZIGOWnTblbDPrwqIIIfaajA[j];
					}
					dataUpdater.buttonValues[j] = this.nmnHFPutVdlqXQzYBzNEBIEZeiff[j];
				}
				if (this.PtxBRJMlzqBQnMGTOHEMUlfSwDtT && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			// Token: 0x06001823 RID: 6179 RVA: 0x0006FE78 File Offset: 0x0006E078
			public BridgedControllerHWInfo DnufofoDwDXHwrFNsepMIIgWKiRUA()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				this.QudMjOGONmAJcuykFjCWHQpuVoQC(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			// Token: 0x06001824 RID: 6180 RVA: 0x0006FE94 File Offset: 0x0006E094
			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				this.HHszUAChqmbraNNjvfWggeJgRTBjA(bridgedController);
				return bridgedController;
			}

			// Token: 0x06001825 RID: 6181 RVA: 0x0001499B File Offset: 0x00012B9B
			[CustomObfuscation(rename = false)]
			public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return new ControllerDisconnectedEventArgs(this.FJhZWTMaJHfDmkycyEZvMxGQNyBbA);
			}

			// Token: 0x06001826 RID: 6182 RVA: 0x0006FEB0 File Offset: 0x0006E0B0
			private void fNgncQqrzkDQZTQCptlEJpbQBXFo()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)this.ySDRhxQpcBQFaxjIyUYsXQofhxlD.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= this.wqhkIMkzWLQPWdiprQWGrXDQwarC)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						this.mkNNzyCGCcsSdTPKuzRqTSEAsgrL[i] = this.twooGbuxceUCGbRFpcSHYIBPoVQA(axes[i]);
						if (!this.PtxBRJMlzqBQnMGTOHEMUlfSwDtT && this.mkNNzyCGCcsSdTPKuzRqTSEAsgrL[i] != 0f)
						{
							this.PtxBRJMlzqBQnMGTOHEMUlfSwDtT = true;
						}
					}
				}
			}

			// Token: 0x06001827 RID: 6183 RVA: 0x0006FF30 File Offset: 0x0006E130
			private void kAoTCFwGvVRpYjTqFMmIGdvPureW()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)this.ySDRhxQpcBQFaxjIyUYsXQofhxlD.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= this.GbnxiuYGRaFIPgudKpmMXwiceWAx)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					this.nmnHFPutVdlqXQzYBzNEBIEZeiff[i] = this.UKvckhFNuNgQBxMhxhUJGciLjSTHA(buttons[i], out this.hzQmsdZIGOWnTblbDPrwqIIIfaajA[i]);
					if (!this.PtxBRJMlzqBQnMGTOHEMUlfSwDtT && (this.nmnHFPutVdlqXQzYBzNEBIEZeiff[i] || (this.dtaALDJbLNtrNgqskoLMlqmCYhKcA[i] && this.hzQmsdZIGOWnTblbDPrwqIIIfaajA[i] != 0f)))
					{
						this.PtxBRJMlzqBQnMGTOHEMUlfSwDtT = true;
					}
				}
			}

			// Token: 0x06001828 RID: 6184 RVA: 0x0006FFC8 File Offset: 0x0006E1C8
			private bool UKvckhFNuNgQBxMhxhUJGciLjSTHA(HardwareJoystickMap.Platform_Custom.Button A_1, out float A_2)
			{
				if (A_1.sourceType == 0)
				{
					bool result = this.jWhochrrXIoIbqVfibnkCdMjEJqq(A_1.sourceButton, out A_2);
					if (MathTools.Abs(A_2) <= A_1.axisDeadZone)
					{
						A_2 = 0f;
					}
					return result;
				}
				if (A_1.sourceType != 1)
				{
					A_2 = 0f;
					return false;
				}
				A_2 = 0f;
				float num = this.LufTfhzWFnFewYZzcKdMXqxZaBVo(A_1.sourceAxis);
				if (MathTools.Abs(num) <= A_1.axisDeadZone)
				{
					return false;
				}
				if (A_1.sourceAxisPole == Pole.Positive && num < 0f)
				{
					return false;
				}
				if (A_1.sourceAxisPole == Pole.Negative && num > 0f)
				{
					return false;
				}
				if (num < 0f)
				{
					num *= -1f;
				}
				if (num > 1f)
				{
					num = 1f;
				}
				A_2 = num;
				return true;
			}

			// Token: 0x06001829 RID: 6185 RVA: 0x00009CBF File Offset: 0x00007EBF
			private bool QJwcBbtkqBerubmvyPXBJyJAHgnP(float A_1, float A_2)
			{
				return MathTools.IsNear(A_2, A_1, 0.1f);
			}

			// Token: 0x0600182A RID: 6186 RVA: 0x00070080 File Offset: 0x0006E280
			private float twooGbuxceUCGbRFpcSHYIBPoVQA(HardwareJoystickMap.Platform_Custom.Axis A_1)
			{
				if (A_1.sourceType == 1)
				{
					return this.LufTfhzWFnFewYZzcKdMXqxZaBVo(A_1.sourceAxis);
				}
				if (A_1.sourceType != 0)
				{
					throw new NotImplementedException();
				}
				float result;
				if (!this.jWhochrrXIoIbqVfibnkCdMjEJqq(A_1.sourceButton, out result))
				{
					return 0f;
				}
				if (A_1.buttonAxisContribution == Pole.Positive)
				{
					result = 1f;
				}
				else
				{
					result = -1f;
				}
				return result;
			}

			// Token: 0x0600182B RID: 6187 RVA: 0x000149A8 File Offset: 0x00012BA8
			private float LufTfhzWFnFewYZzcKdMXqxZaBVo(int A_1)
			{
				return this.KlrZtPQDqHFhstzuAekGstofGmAl.GetAxisValue(A_1);
			}

			// Token: 0x0600182C RID: 6188 RVA: 0x000700E0 File Offset: 0x0006E2E0
			private bool jWhochrrXIoIbqVfibnkCdMjEJqq(int A_1, out float A_2)
			{
				bool result;
				this.KlrZtPQDqHFhstzuAekGstofGmAl.rnUAqEHMzdnSQgQvgOybSnKdmHyr(A_1, out result, out A_2);
				return result;
			}

			// Token: 0x0600182D RID: 6189 RVA: 0x00070100 File Offset: 0x0006E300
			private void TmuJjeuyznTBhQUwMphwGvyoTAbA()
			{
				this.ySDRhxQpcBQFaxjIyUYsXQofhxlD = this.foqKtCgYBKfTdVqXkkpQaQfBAXPh(this.DnufofoDwDXHwrFNsepMIIgWKiRUA());
				if (this.ySDRhxQpcBQFaxjIyUYsXQofhxlD == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				if (this.KlrZtPQDqHFhstzuAekGstofGmAl is IInputManagerHardwareJoystickMapHandler)
				{
					try
					{
						((IInputManagerHardwareJoystickMapHandler)this.KlrZtPQDqHFhstzuAekGstofGmAl).InitializeHardwareJoystickMap(this.ySDRhxQpcBQFaxjIyUYsXQofhxlD);
					}
					catch
					{
					}
				}
				this.wqhkIMkzWLQPWdiprQWGrXDQwarC = this.ySDRhxQpcBQFaxjIyUYsXQofhxlD.axisCount;
				this.GbnxiuYGRaFIPgudKpmMXwiceWAx = this.ySDRhxQpcBQFaxjIyUYsXQofhxlD.buttonCount;
			}

			// Token: 0x0600182E RID: 6190 RVA: 0x000149B6 File Offset: 0x00012BB6
			private void xMaaLMqzFZuTsvoLLqiUIFpCMXiK()
			{
				Array.Clear(this.nmnHFPutVdlqXQzYBzNEBIEZeiff, 0, this.nmnHFPutVdlqXQzYBzNEBIEZeiff.Length);
				Array.Clear(this.hzQmsdZIGOWnTblbDPrwqIIIfaajA, 0, this.hzQmsdZIGOWnTblbDPrwqIIIfaajA.Length);
				Array.Clear(this.mkNNzyCGCcsSdTPKuzRqTSEAsgrL, 0, this.mkNNzyCGCcsSdTPKuzRqTSEAsgrL.Length);
			}

			// Token: 0x0600182F RID: 6191 RVA: 0x00070194 File Offset: 0x0006E394
			private string yIUXHXHLSuPGEYZYJEEyuOwxJcih()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}", new object[]
					{
						ReInput.currentPlatform.ToString(),
						ReInput.webplayerPlatform.ToString(),
						this.KjkTpZnuoOVNaQdKtiOBFemSeEyhA.ToString(),
						this.NOFxtygDcwxfSiYTFLmYeiDsVVdv
					}));
				}
				if (xApfUAgfQcPgXcXdmaKvwTZGIoxYA.GXntXWfLzMLrGpDuLwjFcqKwikHHA)
				{
					return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}", ReInput.currentPlatform.ToString(), xApfUAgfQcPgXcXdmaKvwTZGIoxYA.TPxDaPfqMCkhyAkpodGjZISyJCpuA(), this.NOFxtygDcwxfSiYTFLmYeiDsVVdv));
				}
				return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}", ReInput.currentPlatform.ToString(), this.KjkTpZnuoOVNaQdKtiOBFemSeEyhA.ToString(), this.NOFxtygDcwxfSiYTFLmYeiDsVVdv));
			}

			// Token: 0x06001830 RID: 6192 RVA: 0x00070280 File Offset: 0x0006E480
			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				if (this.KlrZtPQDqHFhstzuAekGstofGmAl is ITryGetLocalizedName)
				{
					return ((ITryGetLocalizedName)this.KlrZtPQDqHFhstzuAekGstofGmAl).TryGetLocalizedName(out value);
				}
				if (this.HrHbXpceDuiHoNHWXmbEBNzfnPxXB)
				{
					if ((LocalizationManager.GetAndUpdateLocalizedString(this.hJjUQQrBZRtnYSFRVCmWBxIDHIco, this.ySDRhxQpcBQFaxjIyUYsXQofhxlD.deviceLocalizationInfo.parentKeys, "controller", this.name, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
					{
						string text = this.name;
						string text2 = null;
						MatchCollection matchCollection = Regex.Matches(text, "^(.*) ([0-9]+)$");
						if (matchCollection.Count > 0 && matchCollection[0].Groups != null && matchCollection[0].Groups.Count > 2)
						{
							text = matchCollection[0].Groups[1].Value;
							text2 = matchCollection[0].Groups[2].Value;
						}
						if (!string.IsNullOrEmpty(text2))
						{
							value = string.Format("{0} {1}", text, text2);
						}
						this.hJjUQQrBZRtnYSFRVCmWBxIDHIco.cachedValue = value;
					}
					return true;
				}
				value = null;
				return false;
			}

			// Token: 0x06001831 RID: 6193 RVA: 0x000149F4 File Offset: 0x00012BF4
			public static int FPSBjAGMKboikceJpUJPDYbOpRWM(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_0, CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_1)
			{
				if (A_0.zvuTDbWBrptkdNXJwAjFQBmdHYVz < A_1.zvuTDbWBrptkdNXJwAjFQBmdHYVz)
				{
					return -1;
				}
				if (A_0.zvuTDbWBrptkdNXJwAjFQBmdHYVz > A_1.zvuTDbWBrptkdNXJwAjFQBmdHYVz)
				{
					return 1;
				}
				return 0;
			}

			// Token: 0x06001832 RID: 6194 RVA: 0x00070384 File Offset: 0x0006E584
			public static int zseesaEVMjIDysuyVukduvlSOJbu(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_0, CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_1)
			{
				long? num = A_0.hCpCvZbrvFAhXbJQSVRPzZfGrJNTA;
				long? num2 = A_1.hCpCvZbrvFAhXbJQSVRPzZfGrJNTA;
				if (num.GetValueOrDefault() < num2.GetValueOrDefault() & (num != null & num2 != null))
				{
					return -1;
				}
				num2 = A_0.hCpCvZbrvFAhXbJQSVRPzZfGrJNTA;
				num = A_1.hCpCvZbrvFAhXbJQSVRPzZfGrJNTA;
				if (num2.GetValueOrDefault() > num.GetValueOrDefault() & (num2 != null & num != null))
				{
					return 1;
				}
				return 0;
			}

			// Token: 0x04000D26 RID: 3366
			private readonly InputSource KjkTpZnuoOVNaQdKtiOBFemSeEyhA;

			// Token: 0x04000D27 RID: 3367
			private readonly CustomInputSource GSJVneaWhtSTfWwxBTRDfWgDaHwr;

			// Token: 0x04000D28 RID: 3368
			private readonly Controller.Extension xRLSKURcDbCbElTFtjBukZJkeAyFb;

			// Token: 0x04000D29 RID: 3369
			private int FJhZWTMaJHfDmkycyEZvMxGQNyBbA;

			// Token: 0x04000D2A RID: 3370
			private int zvuTDbWBrptkdNXJwAjFQBmdHYVz;

			// Token: 0x04000D2B RID: 3371
			private long? hCpCvZbrvFAhXbJQSVRPzZfGrJNTA;

			// Token: 0x04000D2C RID: 3372
			private int VTXBPbkTCXtVRwPOMaSIWCFvCVjQ;

			// Token: 0x04000D2D RID: 3373
			public Guid bEDjgPGoXdDSFJCzMbrGxnnOCfCh;

			// Token: 0x04000D2E RID: 3374
			public string KEjayFdfKeaySHUheWGXCtotOwdUA;

			// Token: 0x04000D2F RID: 3375
			public string NOFxtygDcwxfSiYTFLmYeiDsVVdv;

			// Token: 0x04000D30 RID: 3376
			private int wqhkIMkzWLQPWdiprQWGrXDQwarC;

			// Token: 0x04000D31 RID: 3377
			private int GbnxiuYGRaFIPgudKpmMXwiceWAx;

			// Token: 0x04000D32 RID: 3378
			private float[] mkNNzyCGCcsSdTPKuzRqTSEAsgrL;

			// Token: 0x04000D33 RID: 3379
			private bool[] nmnHFPutVdlqXQzYBzNEBIEZeiff;

			// Token: 0x04000D34 RID: 3380
			private float[] hzQmsdZIGOWnTblbDPrwqIIIfaajA;

			// Token: 0x04000D35 RID: 3381
			private bool[] dtaALDJbLNtrNgqskoLMlqmCYhKcA;

			// Token: 0x04000D36 RID: 3382
			private HardwareJoystickMap_InputManager ySDRhxQpcBQFaxjIyUYsXQofhxlD;

			// Token: 0x04000D37 RID: 3383
			public CustomInputSource.Joystick KlrZtPQDqHFhstzuAekGstofGmAl;

			// Token: 0x04000D38 RID: 3384
			private bool PtxBRJMlzqBQnMGTOHEMUlfSwDtT;

			// Token: 0x04000D39 RID: 3385
			private readonly bool HrHbXpceDuiHoNHWXmbEBNzfnPxXB;

			// Token: 0x04000D3A RID: 3386
			private readonly LocalizedString hJjUQQrBZRtnYSFRVCmWBxIDHIco;

			// Token: 0x04000D3B RID: 3387
			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> foqKtCgYBKfTdVqXkkpQaQfBAXPh;
		}

		// Token: 0x020001D7 RID: 471
		private class QrgQfFHnQfEBWNHrPbhRpetjotcd
		{
			// Token: 0x06001833 RID: 6195 RVA: 0x00014A17 File Offset: 0x00012C17
			public QrgQfFHnQfEBWNHrPbhRpetjotcd()
			{
				this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA = new List<CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.olwTSczyDuwReEaHoFRnfoqCaovx>();
			}

			// Token: 0x170005BA RID: 1466
			// (get) Token: 0x06001834 RID: 6196 RVA: 0x00014A2A File Offset: 0x00012C2A
			public int BgbPrKEwkloPVHmVJLkzUysADRxM
			{
				get
				{
					return this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA.Count;
				}
			}

			// Token: 0x06001835 RID: 6197 RVA: 0x000703F8 File Offset: 0x0006E5F8
			public void FJvBWgLxevvFUwIEXDIMJZPFuxpL(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_1)
			{
				if (A_1 == null)
				{
					return;
				}
				int count = this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i].KgnKunxIrKQZsFwBmhVAWAtTGqvJ(A_1, CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct.Exact))
					{
						this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i].CPCJtzHakMYhrXUNdIODDebRYHYp = A_1.rewiredId;
						this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i].IuHSuJpXSbcEDdLQKVPXPmBDEVBj = A_1.systemId;
						this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i].SeRGAMgfMYybasEaXbdgfRzjQcrAb = A_1.NOFxtygDcwxfSiYTFLmYeiDsVVdv;
						this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i].rdLaHxalSwXLcDMpKjzuHdLSeIkaA = A_1.inputManagerId;
						this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i].qUfaFdIWTSpRMjcxHKsEBLsjRYXgb = A_1.HayMMJGvTcfZbicoVJYRKBLLYhhy;
						this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i].bsiUROQZmmTgTOEYRYmXliIfuzJR = A_1.XzWQvtyceLfyKOUBYXLXqAwjcNHO;
						this.TlKqGIFhnaqiFdWmlhjVqMDdQtq(A_1.rewiredId, i);
						return;
					}
				}
				this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA.Add(new CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.olwTSczyDuwReEaHoFRnfoqCaovx(A_1.rewiredId, A_1.systemId, A_1.NOFxtygDcwxfSiYTFLmYeiDsVVdv, A_1.inputManagerId, A_1.HayMMJGvTcfZbicoVJYRKBLLYhhy, A_1.XzWQvtyceLfyKOUBYXLXqAwjcNHO));
				this.TlKqGIFhnaqiFdWmlhjVqMDdQtq(A_1.rewiredId, this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA.Count - 1);
			}

			// Token: 0x06001836 RID: 6198 RVA: 0x00070524 File Offset: 0x0006E724
			public bool yyMQWcAJArHOpCPLcLVnMMXbjexl(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_1, CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct A_2)
			{
				int count = this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i].KgnKunxIrKQZsFwBmhVAWAtTGqvJ(A_1, A_2))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x06001837 RID: 6199 RVA: 0x00014A37 File Offset: 0x00012C37
			public IEnumerable<CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.olwTSczyDuwReEaHoFRnfoqCaovx> tPrbWhtFmmjoyLWAceVXsocmbZqw(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_1, CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct A_2)
			{
				int count = this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA.Count;
				int num;
				for (int i = 0; i < count; i = num + 1)
				{
					if (this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i].KgnKunxIrKQZsFwBmhVAWAtTGqvJ(A_1, A_2))
					{
						yield return this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i];
					}
					num = i;
				}
				yield break;
			}

			// Token: 0x06001838 RID: 6200 RVA: 0x00070564 File Offset: 0x0006E764
			public int QsFkUFUJLFuPhDtFcaEsgzXDJXPg(CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.olwTSczyDuwReEaHoFRnfoqCaovx A_1)
			{
				int count = this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i] == A_1)
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x06001839 RID: 6201 RVA: 0x0007059C File Offset: 0x0006E79C
			private void TlKqGIFhnaqiFdWmlhjVqMDdQtq(int A_1, int A_2)
			{
				for (int i = this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA.Count - 1; i >= 0; i--)
				{
					if (i != A_2 && this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA[i].CPCJtzHakMYhrXUNdIODDebRYHYp == A_1)
					{
						this.GKAeyxFXTGRsuhIHhVfTRhRYeqihA.RemoveAt(i);
					}
				}
			}

			// Token: 0x04000D3C RID: 3388
			private List<CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.olwTSczyDuwReEaHoFRnfoqCaovx> GKAeyxFXTGRsuhIHhVfTRhRYeqihA;

			// Token: 0x020001D8 RID: 472
			public enum boLVfhCYgowTOVPSOaYqChoWJIct
			{
				// Token: 0x04000D3E RID: 3390
				Exact,
				// Token: 0x04000D3F RID: 3391
				Approximate
			}

			// Token: 0x020001D9 RID: 473
			public class olwTSczyDuwReEaHoFRnfoqCaovx
			{
				// Token: 0x0600183A RID: 6202 RVA: 0x00014A55 File Offset: 0x00012C55
				public olwTSczyDuwReEaHoFRnfoqCaovx(int A_1, long? A_2, string A_3, int A_4, int A_5, int A_6)
				{
					this.CPCJtzHakMYhrXUNdIODDebRYHYp = A_1;
					this.IuHSuJpXSbcEDdLQKVPXPmBDEVBj = A_2;
					this.SeRGAMgfMYybasEaXbdgfRzjQcrAb = A_3;
					this.rdLaHxalSwXLcDMpKjzuHdLSeIkaA = A_4;
					this.qUfaFdIWTSpRMjcxHKsEBLsjRYXgb = A_5;
					this.bsiUROQZmmTgTOEYRYmXliIfuzJR = A_6;
				}

				// Token: 0x0600183B RID: 6203 RVA: 0x000705E8 File Offset: 0x0006E7E8
				public bool KgnKunxIrKQZsFwBmhVAWAtTGqvJ(CustomInputManager.uinrhINWandtHykTyTDZfnkOuyxB A_1, CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct A_2)
				{
					if (A_1.rewiredId == this.CPCJtzHakMYhrXUNdIODDebRYHYp)
					{
						return true;
					}
					if (A_1.HayMMJGvTcfZbicoVJYRKBLLYhhy != this.qUfaFdIWTSpRMjcxHKsEBLsjRYXgb)
					{
						return false;
					}
					if (A_1.XzWQvtyceLfyKOUBYXLXqAwjcNHO != this.bsiUROQZmmTgTOEYRYmXliIfuzJR)
					{
						return false;
					}
					if (A_2 == CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct.Exact)
					{
						long? iuHSuJpXSbcEDdLQKVPXPmBDEVBj = this.IuHSuJpXSbcEDdLQKVPXPmBDEVBj;
						long? systemId = A_1.systemId;
						return (iuHSuJpXSbcEDdLQKVPXPmBDEVBj.GetValueOrDefault() == systemId.GetValueOrDefault() & iuHSuJpXSbcEDdLQKVPXPmBDEVBj != null == (systemId != null)) && this.SeRGAMgfMYybasEaXbdgfRzjQcrAb == A_1.NOFxtygDcwxfSiYTFLmYeiDsVVdv;
					}
					if (A_2 == CustomInputManager.QrgQfFHnQfEBWNHrPbhRpetjotcd.boLVfhCYgowTOVPSOaYqChoWJIct.Approximate)
					{
						return this.SeRGAMgfMYybasEaXbdgfRzjQcrAb == A_1.NOFxtygDcwxfSiYTFLmYeiDsVVdv;
					}
					throw new NotImplementedException();
				}

				// Token: 0x04000D40 RID: 3392
				public int CPCJtzHakMYhrXUNdIODDebRYHYp;

				// Token: 0x04000D41 RID: 3393
				public long? IuHSuJpXSbcEDdLQKVPXPmBDEVBj;

				// Token: 0x04000D42 RID: 3394
				public string SeRGAMgfMYybasEaXbdgfRzjQcrAb;

				// Token: 0x04000D43 RID: 3395
				public int rdLaHxalSwXLcDMpKjzuHdLSeIkaA;

				// Token: 0x04000D44 RID: 3396
				public int qUfaFdIWTSpRMjcxHKsEBLsjRYXgb;

				// Token: 0x04000D45 RID: 3397
				public int bsiUROQZmmTgTOEYRYmXliIfuzJR;
			}
		}
	}
}
