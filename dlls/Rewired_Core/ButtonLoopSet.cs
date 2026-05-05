using System;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	// Token: 0x02000034 RID: 52
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class ButtonLoopSet : UpdateLoopDataSet<ButtonLoopSet.ButtonData>
	{
		// Token: 0x060001F2 RID: 498 RVA: 0x0002E024 File Offset: 0x0002C224
		public ButtonLoopSet(UpdateLoopSetting A_1, int A_2) : base(A_1)
		{
			this.buttonCount = A_2;
			for (int i = 0; i < base.Count; i++)
			{
				base[i] = new ButtonLoopSet.ButtonData(A_2, base.GetUpdateLoopType(i));
			}
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0002E064 File Offset: 0x0002C264
		public void SetValue(int index, bool value, double timestamp)
		{
			int count = base.Count;
			for (int i = 0; i < count; i++)
			{
				base[i].SetValue(index, value);
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0002E094 File Offset: 0x0002C294
		public void Clear()
		{
			int count = base.Count;
			for (int i = 0; i < count; i++)
			{
				base[i].Clear();
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0002E0C0 File Offset: 0x0002C2C0
		public void Import(ButtonLoopSet set)
		{
			if (set == null)
			{
				throw new ArgumentNullException("set");
			}
			if (set.buttonCount != this.buttonCount)
			{
				throw new Exception("Cannot import from a set with a different button count.");
			}
			for (int i = 0; i < base.Count; i++)
			{
				base[i].Import(set[i]);
			}
		}

		// Token: 0x040000E2 RID: 226
		public readonly int buttonCount;

		// Token: 0x02000035 RID: 53
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public class ButtonData
		{
			// Token: 0x17000078 RID: 120
			// (get) Token: 0x060001F6 RID: 502 RVA: 0x00003B7C File Offset: 0x00001D7C
			public bool[] effectiveValue
			{
				get
				{
					if (this.updateLoop == UpdateLoopType.FixedUpdate)
					{
						this.xrfWEvtZPNgIAxrgZzbpCtcWVRbp();
					}
					return this.KYNBEvgPdCEgRqhpWcbXCwCcnaGs;
				}
			}

			// Token: 0x060001F7 RID: 503 RVA: 0x0002E118 File Offset: 0x0002C318
			public ButtonData(int A_1, UpdateLoopType A_2)
			{
				this.updateLoop = A_2;
				this.values = new bool[A_1];
				this.xQinaUqEuGGWTGPxokmKRcejvPnE = new bool[A_1];
				this.wasTrueThisFrame = new bool[A_1];
				this.vjilwaLyqkmIKtfqYcEJilSKqEMl = new bool[A_1];
				this.KYNBEvgPdCEgRqhpWcbXCwCcnaGs = new bool[A_1];
				this.IcarUhMkqqYGYNoDSYRylIkaGEvy = ReInput.timeScalePauseChangedCount;
			}

			// Token: 0x060001F8 RID: 504 RVA: 0x0002E17C File Offset: 0x0002C37C
			public void SetValue(int index, bool value)
			{
				if (this.updateLoop == UpdateLoopType.FixedUpdate)
				{
					this.xrfWEvtZPNgIAxrgZzbpCtcWVRbp();
				}
				this.values[index] = value;
				if (value)
				{
					this.wasTrueThisFrame[index] = true;
					if (!this.xQinaUqEuGGWTGPxokmKRcejvPnE[index])
					{
						this.vjilwaLyqkmIKtfqYcEJilSKqEMl[index] = true;
					}
				}
				this.KYNBEvgPdCEgRqhpWcbXCwCcnaGs[index] = (value | this.vjilwaLyqkmIKtfqYcEJilSKqEMl[index]);
				this.xQinaUqEuGGWTGPxokmKRcejvPnE[index] = value;
			}

			// Token: 0x060001F9 RID: 505 RVA: 0x0002E1DC File Offset: 0x0002C3DC
			public void ClearWasTrueThisFrame()
			{
				for (int i = 0; i < this.values.Length; i++)
				{
					this.wasTrueThisFrame[i] = false;
					this.vjilwaLyqkmIKtfqYcEJilSKqEMl[i] = false;
					this.KYNBEvgPdCEgRqhpWcbXCwCcnaGs[i] = this.values[i];
				}
			}

			// Token: 0x060001FA RID: 506 RVA: 0x0002E220 File Offset: 0x0002C420
			public void Clear()
			{
				Array.Clear(this.values, 0, this.values.Length);
				Array.Clear(this.xQinaUqEuGGWTGPxokmKRcejvPnE, 0, this.values.Length);
				Array.Clear(this.wasTrueThisFrame, 0, this.wasTrueThisFrame.Length);
				Array.Clear(this.vjilwaLyqkmIKtfqYcEJilSKqEMl, 0, this.vjilwaLyqkmIKtfqYcEJilSKqEMl.Length);
				Array.Clear(this.KYNBEvgPdCEgRqhpWcbXCwCcnaGs, 0, this.KYNBEvgPdCEgRqhpWcbXCwCcnaGs.Length);
				this.IcarUhMkqqYGYNoDSYRylIkaGEvy = ReInput.timeScalePauseChangedCount;
			}

			// Token: 0x060001FB RID: 507 RVA: 0x0002E29C File Offset: 0x0002C49C
			public void Import(ButtonLoopSet.ButtonData source)
			{
				if (source == null)
				{
					return;
				}
				int num = MathTools.Min(this.values.Length, source.values.Length);
				for (int i = 0; i < num; i++)
				{
					this.values[i] = source.values[i];
					this.xQinaUqEuGGWTGPxokmKRcejvPnE[i] = source.xQinaUqEuGGWTGPxokmKRcejvPnE[i];
					this.wasTrueThisFrame[i] = source.wasTrueThisFrame[i];
					this.vjilwaLyqkmIKtfqYcEJilSKqEMl[i] = source.vjilwaLyqkmIKtfqYcEJilSKqEMl[i];
					this.KYNBEvgPdCEgRqhpWcbXCwCcnaGs[i] = source.KYNBEvgPdCEgRqhpWcbXCwCcnaGs[i];
					this.IcarUhMkqqYGYNoDSYRylIkaGEvy = source.IcarUhMkqqYGYNoDSYRylIkaGEvy;
				}
			}

			// Token: 0x060001FC RID: 508 RVA: 0x00003B93 File Offset: 0x00001D93
			private void xrfWEvtZPNgIAxrgZzbpCtcWVRbp()
			{
				if (ReInput.timeScalePauseChangedCount != this.IcarUhMkqqYGYNoDSYRylIkaGEvy)
				{
					this.ClearWasTrueThisFrame();
					this.IcarUhMkqqYGYNoDSYRylIkaGEvy = ReInput.timeScalePauseChangedCount;
				}
			}

			// Token: 0x040000E3 RID: 227
			public readonly UpdateLoopType updateLoop;

			// Token: 0x040000E4 RID: 228
			public readonly bool[] values;

			// Token: 0x040000E5 RID: 229
			public readonly bool[] wasTrueThisFrame;

			// Token: 0x040000E6 RID: 230
			private bool[] KYNBEvgPdCEgRqhpWcbXCwCcnaGs;

			// Token: 0x040000E7 RID: 231
			private int IcarUhMkqqYGYNoDSYRylIkaGEvy;

			// Token: 0x040000E8 RID: 232
			private readonly bool[] vjilwaLyqkmIKtfqYcEJilSKqEMl;

			// Token: 0x040000E9 RID: 233
			private readonly bool[] xQinaUqEuGGWTGPxokmKRcejvPnE;
		}
	}
}
