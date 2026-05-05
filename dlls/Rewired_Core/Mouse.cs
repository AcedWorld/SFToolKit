using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000066 RID: 102
	public sealed class Mouse : ControllerWithAxes
	{
		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x00006317 File Offset: 0x00004517
		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return Vector2.zero;
				}
				return this.mTKFlkApnEScruNszAeOznaKdjrr;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0000633E File Offset: 0x0000453E
		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return Vector2.zero;
				}
				return this.gdmVHbzpjegpUyHngePyVZgCqVwW;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x00006365 File Offset: 0x00004565
		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return Vector2.zero;
				}
				return this.mTKFlkApnEScruNszAeOznaKdjrr - this.gdmVHbzpjegpUyHngePyVZgCqVwW;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x00006397 File Offset: 0x00004597
		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return Guid.Empty;
				}
				return Mouse.knYmyYvjifHusMWBLISWtnkuzMmA;
			}
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0003743C File Offset: 0x0003563C
		internal Mouse(string A_1, IUnifiedMouseSource A_2) : this(0, A_2.inputSource, A_1, InputTools.FormatHardwareIdentifierString(A_1), A_2.axisCount, A_2.buttonCount, A_2.hardwareMap, (A_2 != null) ? A_2.controllerExtension : null, new ControllerDataUpdater(A_2.inputSource, A_2.axisCount, A_2.buttonCount, null))
		{
			this.FSDEbggmKZTJHjHFJDrrIGLfCNIwA = A_2;
			Mouse.knYmyYvjifHusMWBLISWtnkuzMmA = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			this.qEnvtUAzINATYqQGwxMxBBiSsAkj();
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x000374B0 File Offset: 0x000356B0
		private Mouse(int A_1, InputSource A_2, string A_3, string A_4, int A_5, int A_6, HardwareControllerMap_Game A_7, Controller.Extension A_8, ControllerDataUpdater A_9) : base(A_1, A_2, A_3, A_3, A_4, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, A_5, A_6, null, A_7, A_8, A_9)
		{
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x000063BD File Offset: 0x000045BD
		internal void asNsaBVEPtLTnHGJVGBthClppdziA(UpdateLoopType A_1)
		{
			this.FSDEbggmKZTJHjHFJDrrIGLfCNIwA.UpdateInputData(this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
			base.HNyKctIlBYbvsLaQmuRrJcfvYARm(A_1);
			this.tucadDBjoplJkIqDzkEaliikfLLhb();
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x000374DC File Offset: 0x000356DC
		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (this.mvwGLLjlqKanCYMGlapsIAAcfvO == null)
			{
				this.mvwGLLjlqKanCYMGlapsIAAcfvO = new float[this._axisCount];
			}
			if (this.RZnWplKdvGWSQImxJbsTqgbieclB == null)
			{
				this.RZnWplKdvGWSQImxJbsTqgbieclB = new TimerAbs(1.0);
			}
			if (this.RZnWplKdvGWSQImxJbsTqgbieclB.Update() || !this.RZnWplKdvGWSQImxJbsTqgbieclB.running)
			{
				this.RZnWplKdvGWSQImxJbsTqgbieclB.Start();
				Array.Clear(this.mvwGLLjlqKanCYMGlapsIAAcfvO, 0, this.mvwGLLjlqKanCYMGlapsIAAcfvO.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				this.mvwGLLjlqKanCYMGlapsIAAcfvO[index] += this.axes[index].valueRaw * 0.5f;
			}
			else
			{
				this.mvwGLLjlqKanCYMGlapsIAAcfvO[index] += this.axes[index].valueRaw;
			}
			float num = this.mvwGLLjlqKanCYMGlapsIAAcfvO[index];
			if (MathTools.Abs(num) <= this.axes[index].ZQoOPuaFhStRTYOlYriHWUJshfEj)
			{
				return false;
			}
			pole = ((num >= 0f) ? Pole.Positive : Pole.Negative);
			elementIdentifierId = this.WGnseNgKihPuTwMSEeDkNInQXGEb.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			this.RZnWplKdvGWSQImxJbsTqgbieclB.running = false;
			return true;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x000063DD File Offset: 0x000045DD
		internal void DmfgfHdSYzgYDjALJLguiETEEjvi()
		{
			base.xSsMiNKHGFcrTjlxQnjHqjKlHSWZ();
			if (this.RZnWplKdvGWSQImxJbsTqgbieclB != null)
			{
				this.RZnWplKdvGWSQImxJbsTqgbieclB.Clear();
			}
			this.mTKFlkApnEScruNszAeOznaKdjrr = Vector2.zero;
			this.gdmVHbzpjegpUyHngePyVZgCqVwW = Vector2.zero;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00037604 File Offset: 0x00035804
		internal bool jJUJeURxBGNBbXvrcAijdfHWieDh(bool A_1)
		{
			if (!base.YiinlzRStddWAaeiqMWoRMYdMJYK(A_1))
			{
				return false;
			}
			if (this.FSDEbggmKZTJHjHFJDrrIGLfCNIwA is IGetSetEnabled)
			{
				(this.FSDEbggmKZTJHjHFJDrrIGLfCNIwA as IGetSetEnabled).enabled = A_1;
			}
			if (A_1)
			{
				this.tucadDBjoplJkIqDzkEaliikfLLhb();
				this.gdmVHbzpjegpUyHngePyVZgCqVwW = this.screenPosition;
			}
			return true;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00037650 File Offset: 0x00035850
		private void tucadDBjoplJkIqDzkEaliikfLLhb()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != this.SSvNBXSUdnLHdgQuBtHEFoGKtXdt)
			{
				this.gdmVHbzpjegpUyHngePyVZgCqVwW = this.mTKFlkApnEScruNszAeOznaKdjrr;
				this.mTKFlkApnEScruNszAeOznaKdjrr = this.FSDEbggmKZTJHjHFJDrrIGLfCNIwA.mousePosition;
				this.SSvNBXSUdnLHdgQuBtHEFoGKtXdt = currentUnityFrame;
			}
		}

		// Token: 0x0400034B RID: 843
		private TimerAbs RZnWplKdvGWSQImxJbsTqgbieclB;

		// Token: 0x0400034C RID: 844
		private float[] mvwGLLjlqKanCYMGlapsIAAcfvO;

		// Token: 0x0400034D RID: 845
		private Vector2 mTKFlkApnEScruNszAeOznaKdjrr;

		// Token: 0x0400034E RID: 846
		private Vector2 gdmVHbzpjegpUyHngePyVZgCqVwW;

		// Token: 0x0400034F RID: 847
		private int SSvNBXSUdnLHdgQuBtHEFoGKtXdt;

		// Token: 0x04000350 RID: 848
		private readonly IUnifiedMouseSource FSDEbggmKZTJHjHFJDrrIGLfCNIwA;

		// Token: 0x04000351 RID: 849
		private static Guid knYmyYvjifHusMWBLISWtnkuzMmA;
	}
}
