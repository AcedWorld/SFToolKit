using System;
using System.Collections.Generic;

namespace Rewired.Platforms.Custom
{
	// Token: 0x02000226 RID: 550
	public abstract class CustomPlatformInputSource : CustomInputSource
	{
		// Token: 0x060019AF RID: 6575 RVA: 0x000719D4 File Offset: 0x0006FBD4
		protected CustomPlatformInputSource(CustomPlatformConfigVars A_1, CustomPlatformInputSource.InitOptions A_2) : base(100, (A_2 != null && A_2.unifiedKeyboardSource != null && A_1.useNativeKeyboard) ? new qcqtQJTyjFvWoJBrvcomQkgJUFng(A_2.unifiedKeyboardSource) : null, (A_2 != null && A_2.unifiedMouseSource != null && A_1.useNativeMouse) ? new XqDtbONtWiIoOhSjOMLTvVheXgEl(A_2.unifiedMouseSource) : null)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("configVars");
			}
			this.FYUlRckOtZEvJWsgbEtGSBYmyNgg = A_1;
			if (A_2 == null || A_2.unifiedKeyboardSource == null)
			{
				A_1.useNativeKeyboard = false;
			}
			if (A_2 == null || A_2.unifiedMouseSource == null)
			{
				A_1.useNativeMouse = false;
			}
			this.oNpdAWicvHJxDgENjELyqHJJkTPR = A_1.useNativeKeyboard;
			this.WHPosLIuxvTWjbffasLQvUNOSfXO = A_1.useNativeMouse;
		}

		// Token: 0x060019B0 RID: 6576 RVA: 0x00071A7C File Offset: 0x0006FC7C
		internal virtual void EfkbXJGXcaBaxqCswblgctQLiyOCA()
		{
			base.JLAerzKwkOEHiFXjkpSPmTPwZEIv();
			if (this.oNpdAWicvHJxDgENjELyqHJJkTPR && base.OYKCcFUDuoxxbZeLGHhfyyQhGsRf() is BhlfjTlGObGwOdBRJeLDpeideLfDb)
			{
				(base.OYKCcFUDuoxxbZeLGHhfyyQhGsRf() as BhlfjTlGObGwOdBRJeLDpeideLfDb).jzakiAASggtqZIjGFuGTPlrIDHnkA();
			}
			if (this.WHPosLIuxvTWjbffasLQvUNOSfXO && base.RoGrwwlaTTFqZxlGvVsoZGCktzSI() is BhlfjTlGObGwOdBRJeLDpeideLfDb)
			{
				(base.RoGrwwlaTTFqZxlGvVsoZGCktzSI() as BhlfjTlGObGwOdBRJeLDpeideLfDb).jzakiAASggtqZIjGFuGTPlrIDHnkA();
			}
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x00071ADC File Offset: 0x0006FCDC
		internal virtual void grhzciHqEydKIhxoAdsfUNvSKtWKA()
		{
			base.pkUAzDKcsykDawzPXDyONdNaTfuU();
			IList<CustomInputSource.Joystick> joysticks = base.GetJoysticks();
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				joysticks[i].eEaDExzqnDgLWQgylYwrAzNWKbBK();
				joysticks[i].Update();
			}
		}

		// Token: 0x060019B2 RID: 6578 RVA: 0x000150D3 File Offset: 0x000132D3
		protected override void Dispose(bool disposing)
		{
			if (this.rAlyOoghKfPesxoHvVMfeKJBNEHl)
			{
				return;
			}
			this.rAlyOoghKfPesxoHvVMfeKJBNEHl = true;
			base.Dispose(disposing);
		}

		// Token: 0x04000EAE RID: 3758
		private readonly CustomPlatformConfigVars FYUlRckOtZEvJWsgbEtGSBYmyNgg;

		// Token: 0x04000EAF RID: 3759
		private readonly bool oNpdAWicvHJxDgENjELyqHJJkTPR;

		// Token: 0x04000EB0 RID: 3760
		private readonly bool WHPosLIuxvTWjbffasLQvUNOSfXO;

		// Token: 0x04000EB1 RID: 3761
		private bool rAlyOoghKfPesxoHvVMfeKJBNEHl;

		// Token: 0x02000227 RID: 551
		public new abstract class Joystick : CustomInputSource.Joystick
		{
			// Token: 0x060019B3 RID: 6579 RVA: 0x000150EE File Offset: 0x000132EE
			protected Joystick(string A_1, long A_2, int A_3, int A_4) : base(A_1, A_2, A_3, A_4)
			{
				this._isConnected = true;
			}
		}

		// Token: 0x02000228 RID: 552
		public sealed class InitOptions
		{
			// Token: 0x04000EB2 RID: 3762
			public CustomPlatformUnifiedKeyboardSource unifiedKeyboardSource;

			// Token: 0x04000EB3 RID: 3763
			public CustomPlatformUnifiedMouseSource unifiedMouseSource;
		}
	}
}
