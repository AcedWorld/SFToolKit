using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200003E RID: 62
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class ThreadSafeUnityInput
	{
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000248 RID: 584 RVA: 0x00003E42 File Offset: 0x00002042
		public static ThreadSafeUnityInput.Mouse mouse
		{
			get
			{
				ThreadSafeUnityInput.Mouse result;
				if ((result = ThreadSafeUnityInput.qHqjZDxRvRjUENchOGGtXNPpJocR) == null)
				{
					result = (ThreadSafeUnityInput.qHqjZDxRvRjUENchOGGtXNPpJocR = new ThreadSafeUnityInput.Mouse());
				}
				return result;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000249 RID: 585 RVA: 0x00003E58 File Offset: 0x00002058
		public static ThreadSafeUnityInput.Keyboard keyboard
		{
			get
			{
				ThreadSafeUnityInput.Keyboard result;
				if ((result = ThreadSafeUnityInput.CuloXkjHHkxynUpGTBeWLhOFhrJS) == null)
				{
					result = (ThreadSafeUnityInput.CuloXkjHHkxynUpGTBeWLhOFhrJS = new ThreadSafeUnityInput.Keyboard());
				}
				return result;
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00002FF9 File Offset: 0x000011F9
		public static void Initialize()
		{
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00003E6E File Offset: 0x0000206E
		public static void PostInitialize()
		{
			if (ThreadSafeUnityInput.CuloXkjHHkxynUpGTBeWLhOFhrJS != null)
			{
				ThreadSafeUnityInput.CuloXkjHHkxynUpGTBeWLhOFhrJS.PostInitialize();
			}
			if (ThreadSafeUnityInput.qHqjZDxRvRjUENchOGGtXNPpJocR != null)
			{
				ThreadSafeUnityInput.qHqjZDxRvRjUENchOGGtXNPpJocR.PostInitialize();
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00002FF9 File Offset: 0x000011F9
		public static void PostInitialize2()
		{
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00003E92 File Offset: 0x00002092
		public static void Deinitialize()
		{
			if (ThreadSafeUnityInput.CuloXkjHHkxynUpGTBeWLhOFhrJS != null)
			{
				ThreadSafeUnityInput.CuloXkjHHkxynUpGTBeWLhOFhrJS = null;
			}
			if (ThreadSafeUnityInput.qHqjZDxRvRjUENchOGGtXNPpJocR != null)
			{
				ThreadSafeUnityInput.qHqjZDxRvRjUENchOGGtXNPpJocR = null;
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00003EAE File Offset: 0x000020AE
		public static void Update()
		{
			if (ThreadSafeUnityInput.CuloXkjHHkxynUpGTBeWLhOFhrJS != null)
			{
				ThreadSafeUnityInput.CuloXkjHHkxynUpGTBeWLhOFhrJS.enabled = ReInput.controllers.Keyboard.enabled;
				ThreadSafeUnityInput.CuloXkjHHkxynUpGTBeWLhOFhrJS.Update();
			}
			if (ThreadSafeUnityInput.qHqjZDxRvRjUENchOGGtXNPpJocR != null)
			{
				ThreadSafeUnityInput.qHqjZDxRvRjUENchOGGtXNPpJocR.Update();
			}
		}

		// Token: 0x04000104 RID: 260
		private static ThreadSafeUnityInput.Mouse qHqjZDxRvRjUENchOGGtXNPpJocR;

		// Token: 0x04000105 RID: 261
		private static ThreadSafeUnityInput.Keyboard CuloXkjHHkxynUpGTBeWLhOFhrJS;

		// Token: 0x0200003F RID: 63
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Keyboard
		{
			// Token: 0x1700008B RID: 139
			// (get) Token: 0x0600024F RID: 591 RVA: 0x00003EEB File Offset: 0x000020EB
			// (set) Token: 0x06000250 RID: 592 RVA: 0x00003EF3 File Offset: 0x000020F3
			public bool enabled
			{
				get
				{
					return this.VEvKmsmwuTGWnmfJbdsGxYELFIhO;
				}
				set
				{
					if (value == this.VEvKmsmwuTGWnmfJbdsGxYELFIhO)
					{
						return;
					}
					this.VEvKmsmwuTGWnmfJbdsGxYELFIhO = value;
					if (!this.VEvKmsmwuTGWnmfJbdsGxYELFIhO)
					{
						this.Clear();
					}
				}
			}

			// Token: 0x1700008C RID: 140
			// (get) Token: 0x06000251 RID: 593 RVA: 0x00003F14 File Offset: 0x00002114
			public bool monitoring
			{
				get
				{
					return this.aeMhdhJDhyFjViKJRotcHuGmHZln > 0;
				}
			}

			// Token: 0x1700008D RID: 141
			// (get) Token: 0x06000252 RID: 594 RVA: 0x00003F1F File Offset: 0x0000211F
			public int keyCount
			{
				get
				{
					return 132;
				}
			}

			// Token: 0x06000253 RID: 595 RVA: 0x0002E904 File Offset: 0x0002CB04
			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					ThreadSafeUnityInput.Keyboard.adcjRIxwPJFSqlOTUjCxlIxaRIZq = new int[]
					{
						ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape = ArrayTools.IndexOf(keyboardKeyValues, 27),
						ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu = ArrayTools.IndexOf(keyboardKeyValues, 319),
						ThreadSafeUnityInput.Keyboard.keyValueIndex_F2 = ArrayTools.IndexOf(keyboardKeyValues, 283),
						ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow = ArrayTools.IndexOf(keyboardKeyValues, 273),
						ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow = ArrayTools.IndexOf(keyboardKeyValues, 275),
						ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow = ArrayTools.IndexOf(keyboardKeyValues, 274),
						ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow = ArrayTools.IndexOf(keyboardKeyValues, 276)
					};
				}
			}

			// Token: 0x06000254 RID: 596 RVA: 0x0002E9B8 File Offset: 0x0002CBB8
			public Keyboard()
			{
				this.LznRBWPichHgLaBZMMWqteiZSIuH = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > this.XnzfoTijWiEKraGrWNugefinkJVk)
					{
						this.XnzfoTijWiEKraGrWNugefinkJVk = keyboardKeyValues[i];
					}
				}
				this.aorAkCrjgsYsugHxCmqovPcKDcEn = new int[this.XnzfoTijWiEKraGrWNugefinkJVk + 1];
				ArrayTools.Fill<int>(this.aorAkCrjgsYsugHxCmqovPcKDcEn, -1);
				for (int j = 0; j < num; j++)
				{
					this.aorAkCrjgsYsugHxCmqovPcKDcEn[keyboardKeyValues[j]] = j;
				}
			}

			// Token: 0x06000255 RID: 597 RVA: 0x00003F26 File Offset: 0x00002126
			public void Initialize()
			{
				if (this.aeMhdhJDhyFjViKJRotcHuGmHZln != 0)
				{
					this.yCbRBTKYAmjzqSEzmKBbQkttiZfv();
				}
				this.RkmGqBbyeQvsUJYywzZVrdMdFwnl();
			}

			// Token: 0x06000256 RID: 598 RVA: 0x00003F3C File Offset: 0x0000213C
			public void PostInitialize()
			{
				this.Update();
			}

			// Token: 0x06000257 RID: 599 RVA: 0x0002EA3C File Offset: 0x0002CC3C
			public void Update()
			{
				if (this.aeMhdhJDhyFjViKJRotcHuGmHZln == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					this.sqEdMcahnKFPNvyoZzAwjnCdYXnnA = true;
					if (this.VEvKmsmwuTGWnmfJbdsGxYELFIhO)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							this.LznRBWPichHgLaBZMMWqteiZSIuH[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
						return;
					}
					if (this.CLbTWEhKrlBKetZBkGRWumUJHhaP)
					{
						this.LznRBWPichHgLaBZMMWqteiZSIuH[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape] = this.GetKey(KeyCode.Escape);
						this.LznRBWPichHgLaBZMMWqteiZSIuH[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu] = this.GetKey(KeyCode.Menu);
						this.LznRBWPichHgLaBZMMWqteiZSIuH[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2] = this.GetKey(KeyCode.F2);
						this.LznRBWPichHgLaBZMMWqteiZSIuH[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow] = this.GetKey(KeyCode.UpArrow);
						this.LznRBWPichHgLaBZMMWqteiZSIuH[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow] = this.GetKey(KeyCode.RightArrow);
						this.LznRBWPichHgLaBZMMWqteiZSIuH[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow] = this.GetKey(KeyCode.DownArrow);
						this.LznRBWPichHgLaBZMMWqteiZSIuH[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow] = this.GetKey(KeyCode.LeftArrow);
						return;
					}
				}
				else if (this.sqEdMcahnKFPNvyoZzAwjnCdYXnnA)
				{
					Array.Clear(this.LznRBWPichHgLaBZMMWqteiZSIuH, 0, this.LznRBWPichHgLaBZMMWqteiZSIuH.Length);
				}
			}

			// Token: 0x06000258 RID: 600 RVA: 0x0002EB58 File Offset: 0x0002CD58
			public void Monitor(bool state)
			{
				if (state)
				{
					this.aeMhdhJDhyFjViKJRotcHuGmHZln++;
					if (this.aeMhdhJDhyFjViKJRotcHuGmHZln == 1)
					{
						this.ZArQDozydgkoxwUvWBdOviDXnIbf();
						return;
					}
				}
				else
				{
					this.aeMhdhJDhyFjViKJRotcHuGmHZln--;
					if (this.aeMhdhJDhyFjViKJRotcHuGmHZln < 0)
					{
						this.aeMhdhJDhyFjViKJRotcHuGmHZln = 0;
						this.lifyINXsPofPTAXWexnQIHfrgfEK();
					}
					if (this.aeMhdhJDhyFjViKJRotcHuGmHZln == 0)
					{
						this.hSTuGmDibxAEHQpKOcAlVLWDwvXU();
					}
				}
			}

			// Token: 0x06000259 RID: 601 RVA: 0x00003F44 File Offset: 0x00002144
			public bool GetKey(KeyCode keyCode)
			{
				if (this.aeMhdhJDhyFjViKJRotcHuGmHZln == 0)
				{
					this.cVxXJGGkoAXHDpjAVnTdlufhQjNu();
					return false;
				}
				return keyCode <= (KeyCode)this.XnzfoTijWiEKraGrWNugefinkJVk && this.LznRBWPichHgLaBZMMWqteiZSIuH[this.aorAkCrjgsYsugHxCmqovPcKDcEn[(int)keyCode]];
			}

			// Token: 0x0600025A RID: 602 RVA: 0x00003F70 File Offset: 0x00002170
			public void GetKeyValues(bool[] values)
			{
				if (this.aeMhdhJDhyFjViKJRotcHuGmHZln == 0)
				{
					this.cVxXJGGkoAXHDpjAVnTdlufhQjNu();
					return;
				}
				if (values == null || values.Length < 132)
				{
					return;
				}
				Array.Copy(this.LznRBWPichHgLaBZMMWqteiZSIuH, values, 132);
			}

			// Token: 0x0600025B RID: 603 RVA: 0x0002EBB8 File Offset: 0x0002CDB8
			public void Clear()
			{
				if (this.CLbTWEhKrlBKetZBkGRWumUJHhaP)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf<int>(ThreadSafeUnityInput.Keyboard.adcjRIxwPJFSqlOTUjCxlIxaRIZq, i) < 0)
						{
							this.LznRBWPichHgLaBZMMWqteiZSIuH[i] = false;
						}
					}
					return;
				}
				Array.Clear(this.LznRBWPichHgLaBZMMWqteiZSIuH, 0, 132);
			}

			// Token: 0x0600025C RID: 604 RVA: 0x00003FA0 File Offset: 0x000021A0
			private void yCbRBTKYAmjzqSEzmKBbQkttiZfv()
			{
				Array.Clear(this.LznRBWPichHgLaBZMMWqteiZSIuH, 0, 132);
			}

			// Token: 0x0600025D RID: 605 RVA: 0x00003FB3 File Offset: 0x000021B3
			private void RkmGqBbyeQvsUJYywzZVrdMdFwnl()
			{
				this.aeMhdhJDhyFjViKJRotcHuGmHZln = 0;
				this.VEvKmsmwuTGWnmfJbdsGxYELFIhO = true;
			}

			// Token: 0x0600025E RID: 606 RVA: 0x00002FF9 File Offset: 0x000011F9
			private void ZArQDozydgkoxwUvWBdOviDXnIbf()
			{
			}

			// Token: 0x0600025F RID: 607 RVA: 0x00003FC3 File Offset: 0x000021C3
			private void hSTuGmDibxAEHQpKOcAlVLWDwvXU()
			{
				this.yCbRBTKYAmjzqSEzmKBbQkttiZfv();
			}

			// Token: 0x06000260 RID: 608 RVA: 0x00003FCB File Offset: 0x000021CB
			private void cVxXJGGkoAXHDpjAVnTdlufhQjNu()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", true);
			}

			// Token: 0x06000261 RID: 609 RVA: 0x00003FD8 File Offset: 0x000021D8
			private void lifyINXsPofPTAXWexnQIHfrgfEK()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", true);
			}

			// Token: 0x04000106 RID: 262
			private const int kJKfEtbMuARnyQiwQDIhiAnEiIrYA = 132;

			// Token: 0x04000107 RID: 263
			public static readonly int keyValueIndex_Escape;

			// Token: 0x04000108 RID: 264
			public static readonly int keyValueIndex_Menu;

			// Token: 0x04000109 RID: 265
			public static readonly int keyValueIndex_F2;

			// Token: 0x0400010A RID: 266
			public static readonly int keyValueIndex_UpArrow;

			// Token: 0x0400010B RID: 267
			public static readonly int keyValueIndex_RightArrow;

			// Token: 0x0400010C RID: 268
			public static readonly int keyValueIndex_DownArrow;

			// Token: 0x0400010D RID: 269
			public static readonly int keyValueIndex_LeftArrow;

			// Token: 0x0400010E RID: 270
			private static readonly int[] adcjRIxwPJFSqlOTUjCxlIxaRIZq;

			// Token: 0x0400010F RID: 271
			private readonly int XnzfoTijWiEKraGrWNugefinkJVk;

			// Token: 0x04000110 RID: 272
			private readonly int[] aorAkCrjgsYsugHxCmqovPcKDcEn;

			// Token: 0x04000111 RID: 273
			private readonly bool[] LznRBWPichHgLaBZMMWqteiZSIuH;

			// Token: 0x04000112 RID: 274
			private bool VEvKmsmwuTGWnmfJbdsGxYELFIhO;

			// Token: 0x04000113 RID: 275
			private int aeMhdhJDhyFjViKJRotcHuGmHZln;

			// Token: 0x04000114 RID: 276
			private readonly bool CLbTWEhKrlBKetZBkGRWumUJHhaP;

			// Token: 0x04000115 RID: 277
			private bool sqEdMcahnKFPNvyoZzAwjnCdYXnnA;
		}

		// Token: 0x02000040 RID: 64
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			// Token: 0x1700008E RID: 142
			// (get) Token: 0x06000262 RID: 610 RVA: 0x00003FE5 File Offset: 0x000021E5
			public bool monitoring
			{
				get
				{
					return this.CSbVeEUPzJWFAmMKOvyKYYnLCktK > 0;
				}
			}

			// Token: 0x1700008F RID: 143
			// (get) Token: 0x06000263 RID: 611 RVA: 0x00003FF0 File Offset: 0x000021F0
			public Vector3 mousePosition
			{
				get
				{
					return this.LzSYEhkTtedbKyheeGRmjZlrELZ;
				}
			}

			// Token: 0x17000090 RID: 144
			// (get) Token: 0x06000264 RID: 612 RVA: 0x00003FF8 File Offset: 0x000021F8
			public bool mousePresent
			{
				get
				{
					return this.AyxKwxXPiJxXDndWFxIIUASIbjkeA;
				}
			}

			// Token: 0x06000265 RID: 613 RVA: 0x00004000 File Offset: 0x00002200
			public Mouse()
			{
				this.rJOGbRMUeYnKBoMTPhGXdhLAVoak = new bool[7];
				this.OXCDtBigMeXENlERinjOOduJrMbl = new float[4];
				this.ghzBFgrfnoDkQlEriHApJLYndFjl();
			}

			// Token: 0x06000266 RID: 614 RVA: 0x00004026 File Offset: 0x00002226
			public void PostInitialize()
			{
				this.Update();
			}

			// Token: 0x06000267 RID: 615 RVA: 0x0002EC08 File Offset: 0x0002CE08
			public void Update()
			{
				if (this.CSbVeEUPzJWFAmMKOvyKYYnLCktK == 0)
				{
					return;
				}
				if (!this.FbbcPsKmipjwQfdyNGApkNaNxwrn)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							this.rJOGbRMUeYnKBoMTPhGXdhLAVoak[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							this.OXCDtBigMeXENlERinjOOduJrMbl[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						this.FbbcPsKmipjwQfdyNGApkNaNxwrn = true;
					}
				}
				this.OXCDtBigMeXENlERinjOOduJrMbl[3] = Input.mouseScrollDelta.x;
				this.LzSYEhkTtedbKyheeGRmjZlrELZ = Input.mousePosition;
				this.AyxKwxXPiJxXDndWFxIIUASIbjkeA = Input.mousePresent;
			}

			// Token: 0x06000268 RID: 616 RVA: 0x0002ECBC File Offset: 0x0002CEBC
			public void Monitor(bool state)
			{
				if (state)
				{
					this.CSbVeEUPzJWFAmMKOvyKYYnLCktK++;
					if (this.CSbVeEUPzJWFAmMKOvyKYYnLCktK == 1)
					{
						this.koDrLZnLsfuKWsaLDbMgwSmCRHmg();
						return;
					}
				}
				else
				{
					this.CSbVeEUPzJWFAmMKOvyKYYnLCktK--;
					if (this.CSbVeEUPzJWFAmMKOvyKYYnLCktK < 0)
					{
						this.CSbVeEUPzJWFAmMKOvyKYYnLCktK = 0;
						this.GTVsYbxTRyQUDHOdvkICKFRpRiFR();
					}
					if (this.CSbVeEUPzJWFAmMKOvyKYYnLCktK == 0)
					{
						this.IjxDBsscexuzACsaISalwXeApXiC();
					}
				}
			}

			// Token: 0x06000269 RID: 617 RVA: 0x0000402E File Offset: 0x0000222E
			public bool GetButton(int index)
			{
				if (this.CSbVeEUPzJWFAmMKOvyKYYnLCktK == 0)
				{
					this.ToBYzTBdbPinMPUxLibBQJJxDOjR();
					return false;
				}
				return index < 7 && this.rJOGbRMUeYnKBoMTPhGXdhLAVoak[index];
			}

			// Token: 0x0600026A RID: 618 RVA: 0x0000404E File Offset: 0x0000224E
			public float GetAxisRaw(int index)
			{
				if (this.CSbVeEUPzJWFAmMKOvyKYYnLCktK == 0)
				{
					this.ToBYzTBdbPinMPUxLibBQJJxDOjR();
					return 0f;
				}
				if (index >= 4)
				{
					return 0f;
				}
				return this.OXCDtBigMeXENlERinjOOduJrMbl[index];
			}

			// Token: 0x0600026B RID: 619 RVA: 0x00004076 File Offset: 0x00002276
			public void GetButtonValues(bool[] buttons)
			{
				if (this.CSbVeEUPzJWFAmMKOvyKYYnLCktK == 0)
				{
					this.ToBYzTBdbPinMPUxLibBQJJxDOjR();
					return;
				}
				if (buttons == null || buttons.Length < 7)
				{
					return;
				}
				Array.Copy(this.rJOGbRMUeYnKBoMTPhGXdhLAVoak, buttons, 7);
			}

			// Token: 0x0600026C RID: 620 RVA: 0x0000409E File Offset: 0x0000229E
			public void GetAxisRawValues(float[] axes)
			{
				if (this.CSbVeEUPzJWFAmMKOvyKYYnLCktK == 0)
				{
					this.ToBYzTBdbPinMPUxLibBQJJxDOjR();
					return;
				}
				if (axes == null || axes.Length < 4)
				{
					return;
				}
				Array.Copy(this.OXCDtBigMeXENlERinjOOduJrMbl, axes, 4);
			}

			// Token: 0x0600026D RID: 621 RVA: 0x000040C6 File Offset: 0x000022C6
			private void GBVXWArpNkxzouMxacvobGYdyFqR()
			{
				Array.Clear(this.rJOGbRMUeYnKBoMTPhGXdhLAVoak, 0, 7);
				Array.Clear(this.OXCDtBigMeXENlERinjOOduJrMbl, 0, 4);
			}

			// Token: 0x0600026E RID: 622 RVA: 0x000040E2 File Offset: 0x000022E2
			private void ghzBFgrfnoDkQlEriHApJLYndFjl()
			{
				this.CSbVeEUPzJWFAmMKOvyKYYnLCktK = 0;
				this.LzSYEhkTtedbKyheeGRmjZlrELZ = Vector3.zero;
				this.AyxKwxXPiJxXDndWFxIIUASIbjkeA = false;
			}

			// Token: 0x0600026F RID: 623 RVA: 0x00002FF9 File Offset: 0x000011F9
			private void koDrLZnLsfuKWsaLDbMgwSmCRHmg()
			{
			}

			// Token: 0x06000270 RID: 624 RVA: 0x000040FD File Offset: 0x000022FD
			private void IjxDBsscexuzACsaISalwXeApXiC()
			{
				this.GBVXWArpNkxzouMxacvobGYdyFqR();
			}

			// Token: 0x06000271 RID: 625 RVA: 0x00004105 File Offset: 0x00002305
			private void ToBYzTBdbPinMPUxLibBQJJxDOjR()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", true);
			}

			// Token: 0x06000272 RID: 626 RVA: 0x00004112 File Offset: 0x00002312
			private void GTVsYbxTRyQUDHOdvkICKFRpRiFR()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", true);
			}

			// Token: 0x04000116 RID: 278
			private const int EWRsLwWNGDqDOzDXyclXAxePVdLMA = 7;

			// Token: 0x04000117 RID: 279
			private const int CPqkCltqpwTrwxfAJeHlLZJpnPDu = 4;

			// Token: 0x04000118 RID: 280
			private readonly bool[] rJOGbRMUeYnKBoMTPhGXdhLAVoak;

			// Token: 0x04000119 RID: 281
			private readonly float[] OXCDtBigMeXENlERinjOOduJrMbl;

			// Token: 0x0400011A RID: 282
			private int CSbVeEUPzJWFAmMKOvyKYYnLCktK;

			// Token: 0x0400011B RID: 283
			private Vector3 LzSYEhkTtedbKyheeGRmjZlrELZ;

			// Token: 0x0400011C RID: 284
			private bool AyxKwxXPiJxXDndWFxIIUASIbjkeA;

			// Token: 0x0400011D RID: 285
			private bool FbbcPsKmipjwQfdyNGApkNaNxwrn;
		}
	}
}
