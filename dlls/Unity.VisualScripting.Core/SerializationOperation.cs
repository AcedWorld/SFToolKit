using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200013C RID: 316
	public class SerializationOperation
	{
		// Token: 0x0600089F RID: 2207 RVA: 0x0002633C File Offset: 0x0002453C
		public SerializationOperation()
		{
			this.objectReferences = new List<Object>();
			this.serializer = new fsSerializer();
			this.serializer.AddConverter(new UnityObjectConverter());
			this.serializer.AddConverter(new RayConverter());
			this.serializer.AddConverter(new Ray2DConverter());
			this.serializer.AddConverter(new NamespaceConverter());
			this.serializer.AddConverter(new LooseAssemblyNameConverter());
			this.serializer.Context.Set<List<Object>>(this.objectReferences);
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060008A0 RID: 2208 RVA: 0x000263CB File Offset: 0x000245CB
		// (set) Token: 0x060008A1 RID: 2209 RVA: 0x000263D3 File Offset: 0x000245D3
		public fsSerializer serializer { get; private set; }

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060008A2 RID: 2210 RVA: 0x000263DC File Offset: 0x000245DC
		// (set) Token: 0x060008A3 RID: 2211 RVA: 0x000263E4 File Offset: 0x000245E4
		public List<Object> objectReferences { get; private set; }

		// Token: 0x060008A4 RID: 2212 RVA: 0x000263ED File Offset: 0x000245ED
		public void Reset()
		{
			this.objectReferences.Clear();
		}
	}
}
