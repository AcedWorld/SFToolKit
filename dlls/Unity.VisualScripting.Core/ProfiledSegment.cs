using System;
using System.Diagnostics;

namespace Unity.VisualScripting
{
	// Token: 0x020000C9 RID: 201
	public class ProfiledSegment
	{
		// Token: 0x060004D4 RID: 1236 RVA: 0x0000ADE8 File Offset: 0x00008FE8
		public ProfiledSegment(ProfiledSegment parent, string name)
		{
			this.parent = parent;
			this.name = name;
			this.stopwatch = new Stopwatch();
			this.children = new ProfiledSegmentCollection();
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x0000AE14 File Offset: 0x00009014
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x0000AE1C File Offset: 0x0000901C
		public string name { get; private set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0000AE25 File Offset: 0x00009025
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x0000AE2D File Offset: 0x0000902D
		public Stopwatch stopwatch { get; private set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0000AE36 File Offset: 0x00009036
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x0000AE3E File Offset: 0x0000903E
		public long calls { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x0000AE47 File Offset: 0x00009047
		// (set) Token: 0x060004DC RID: 1244 RVA: 0x0000AE4F File Offset: 0x0000904F
		public ProfiledSegment parent { get; private set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060004DD RID: 1245 RVA: 0x0000AE58 File Offset: 0x00009058
		// (set) Token: 0x060004DE RID: 1246 RVA: 0x0000AE60 File Offset: 0x00009060
		public ProfiledSegmentCollection children { get; private set; }
	}
}
