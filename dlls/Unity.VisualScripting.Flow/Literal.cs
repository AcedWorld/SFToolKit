using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000B4 RID: 180
	[SpecialUnit]
	public sealed class Literal : Unit
	{
		// Token: 0x06000534 RID: 1332 RVA: 0x0000AF99 File Offset: 0x00009199
		[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
		public Literal()
		{
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0000AFA1 File Offset: 0x000091A1
		public Literal(Type type) : this(type, type.PseudoDefault())
		{
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0000AFB0 File Offset: 0x000091B0
		public Literal(Type type, object value)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			Ensure.That("value").IsOfType<object>(value, type);
			this.type = type;
			this.value = value;
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x0000AFE7 File Offset: 0x000091E7
		public override bool canDefine
		{
			get
			{
				return this.type != null;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x0000AFF5 File Offset: 0x000091F5
		// (set) Token: 0x06000539 RID: 1337 RVA: 0x0000AFFD File Offset: 0x000091FD
		[Serialize]
		public Type type { get; internal set; }

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0000B006 File Offset: 0x00009206
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x0000B00E File Offset: 0x0000920E
		[DoNotSerialize]
		public object value
		{
			get
			{
				return this._value;
			}
			set
			{
				Ensure.That("value").IsOfType<object>(value, this.type);
				this._value = value;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x0000B02D File Offset: 0x0000922D
		// (set) Token: 0x0600053D RID: 1341 RVA: 0x0000B035 File Offset: 0x00009235
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput output { get; private set; }

		// Token: 0x0600053E RID: 1342 RVA: 0x0000B03E File Offset: 0x0000923E
		protected override void Definition()
		{
			this.output = base.ValueOutput(this.type, "output", (Flow flow) => this.value).Predictable();
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0000B068 File Offset: 0x00009268
		public override AnalyticsIdentifier GetAnalyticsIdentifier()
		{
			AnalyticsIdentifier analyticsIdentifier = new AnalyticsIdentifier();
			analyticsIdentifier.Identifier = base.GetType().FullName + "(" + this.type.Name + ")";
			analyticsIdentifier.Namespace = this.type.Namespace;
			analyticsIdentifier.Hashcode = analyticsIdentifier.Identifier.GetHashCode();
			return analyticsIdentifier;
		}

		// Token: 0x04000151 RID: 337
		[SerializeAs("value")]
		private object _value;
	}
}
