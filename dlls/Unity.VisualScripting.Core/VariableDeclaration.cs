using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000170 RID: 368
	[SerializationVersion("A", new Type[]
	{

	})]
	public sealed class VariableDeclaration
	{
		// Token: 0x060009CB RID: 2507 RVA: 0x000296D3 File Offset: 0x000278D3
		[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
		public VariableDeclaration()
		{
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x000296DB File Offset: 0x000278DB
		public VariableDeclaration(string name, object value)
		{
			this.name = name;
			this.value = value;
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060009CD RID: 2509 RVA: 0x000296F1 File Offset: 0x000278F1
		// (set) Token: 0x060009CE RID: 2510 RVA: 0x000296F9 File Offset: 0x000278F9
		[Serialize]
		public string name { get; private set; }

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060009CF RID: 2511 RVA: 0x00029702 File Offset: 0x00027902
		// (set) Token: 0x060009D0 RID: 2512 RVA: 0x0002970A File Offset: 0x0002790A
		[Serialize]
		[Value]
		public object value { get; set; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060009D1 RID: 2513 RVA: 0x00029713 File Offset: 0x00027913
		// (set) Token: 0x060009D2 RID: 2514 RVA: 0x0002971B File Offset: 0x0002791B
		[Serialize]
		public SerializableType typeHandle { get; set; }
	}
}
