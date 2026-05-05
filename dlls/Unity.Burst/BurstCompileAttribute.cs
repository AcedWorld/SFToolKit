using System;

namespace Unity.Burst
{
	// Token: 0x02000008 RID: 8
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
	public class BurstCompileAttribute : Attribute
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020D0 File Offset: 0x000002D0
		// (set) Token: 0x06000006 RID: 6 RVA: 0x000020D8 File Offset: 0x000002D8
		public FloatMode FloatMode { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020E1 File Offset: 0x000002E1
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020E9 File Offset: 0x000002E9
		public FloatPrecision FloatPrecision { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020F2 File Offset: 0x000002F2
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000210E File Offset: 0x0000030E
		public bool CompileSynchronously
		{
			get
			{
				return this._compileSynchronously != null && this._compileSynchronously.Value;
			}
			set
			{
				this._compileSynchronously = new bool?(value);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000211C File Offset: 0x0000031C
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00002138 File Offset: 0x00000338
		public bool Debug
		{
			get
			{
				return this._debug != null && this._debug.Value;
			}
			set
			{
				this._debug = new bool?(value);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002146 File Offset: 0x00000346
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002162 File Offset: 0x00000362
		public bool DisableSafetyChecks
		{
			get
			{
				return this._disableSafetyChecks != null && this._disableSafetyChecks.Value;
			}
			set
			{
				this._disableSafetyChecks = new bool?(value);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002170 File Offset: 0x00000370
		// (set) Token: 0x06000010 RID: 16 RVA: 0x0000218C File Offset: 0x0000038C
		public bool DisableDirectCall
		{
			get
			{
				return this._disableDirectCall != null && this._disableDirectCall.Value;
			}
			set
			{
				this._disableDirectCall = new bool?(value);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000219A File Offset: 0x0000039A
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000021A2 File Offset: 0x000003A2
		public OptimizeFor OptimizeFor { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000021AB File Offset: 0x000003AB
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000021B3 File Offset: 0x000003B3
		internal string[] Options { get; set; }

		// Token: 0x06000015 RID: 21 RVA: 0x000021BC File Offset: 0x000003BC
		public BurstCompileAttribute()
		{
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000021C4 File Offset: 0x000003C4
		public BurstCompileAttribute(FloatPrecision floatPrecision, FloatMode floatMode)
		{
			this.FloatMode = floatMode;
			this.FloatPrecision = floatPrecision;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000021DA File Offset: 0x000003DA
		internal BurstCompileAttribute(string[] options)
		{
			this.Options = options;
		}

		// Token: 0x04000013 RID: 19
		internal bool? _compileSynchronously;

		// Token: 0x04000014 RID: 20
		internal bool? _debug;

		// Token: 0x04000015 RID: 21
		internal bool? _disableSafetyChecks;

		// Token: 0x04000016 RID: 22
		internal bool? _disableDirectCall;
	}
}
