using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200001A RID: 26
	[SpecialUnit]
	public sealed class CreateStruct : Unit
	{
		// Token: 0x060000CF RID: 207 RVA: 0x00003A5B File Offset: 0x00001C5B
		[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
		public CreateStruct()
		{
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00003A63 File Offset: 0x00001C63
		public CreateStruct(Type type)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			if (!type.IsStruct())
			{
				throw new ArgumentException(string.Format("Type {0} must be a struct.", type), "type");
			}
			this.type = type;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00003AA0 File Offset: 0x00001CA0
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x00003AA8 File Offset: 0x00001CA8
		[Serialize]
		public Type type { get; internal set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00003AB1 File Offset: 0x00001CB1
		public override bool canDefine
		{
			get
			{
				return this.type != null;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00003ABF File Offset: 0x00001CBF
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x00003AC7 File Offset: 0x00001CC7
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00003AD0 File Offset: 0x00001CD0
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00003AD8 File Offset: 0x00001CD8
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00003AE1 File Offset: 0x00001CE1
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00003AE9 File Offset: 0x00001CE9
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput output { get; private set; }

		// Token: 0x060000DA RID: 218 RVA: 0x00003AF4 File Offset: 0x00001CF4
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Enter));
			this.exit = base.ControlOutput("exit");
			this.output = base.ValueOutput(this.type, "output", new Func<Flow, object>(this.Create));
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00003B64 File Offset: 0x00001D64
		private ControlOutput Enter(Flow flow)
		{
			flow.SetValue(this.output, Activator.CreateInstance(this.type));
			return this.exit;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00003B83 File Offset: 0x00001D83
		private object Create(Flow flow)
		{
			return Activator.CreateInstance(this.type);
		}
	}
}
