using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Unity.VisualScripting
{
	// Token: 0x02000129 RID: 297
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public sealed class TypeFilter : Attribute, ICloneable
	{
		// Token: 0x060007CE RID: 1998 RVA: 0x0002320C File Offset: 0x0002140C
		public TypeFilter(TypesMatching matching, IEnumerable<Type> types)
		{
			Ensure.That("types").IsNotNull<IEnumerable<Type>>(types);
			this.Matching = matching;
			this.types = new HashSet<Type>(types);
			this.Value = true;
			this.Reference = true;
			this.Classes = true;
			this.Interfaces = true;
			this.Structs = true;
			this.Enums = true;
			this.Public = true;
			this.NonPublic = false;
			this.Abstract = true;
			this.Generic = true;
			this.OpenConstructedGeneric = false;
			this.Static = true;
			this.Sealed = true;
			this.Nested = true;
			this.Primitives = true;
			this.Object = true;
			this.NonSerializable = true;
			this.Obsolete = false;
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x000232C0 File Offset: 0x000214C0
		public TypeFilter(TypesMatching matching, params Type[] types) : this(matching, types)
		{
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x000232CA File Offset: 0x000214CA
		public TypeFilter(IEnumerable<Type> types) : this(TypesMatching.ConvertibleToAny, types)
		{
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x000232D4 File Offset: 0x000214D4
		public TypeFilter(params Type[] types) : this(TypesMatching.ConvertibleToAny, types)
		{
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x000232DE File Offset: 0x000214DE
		// (set) Token: 0x060007D3 RID: 2003 RVA: 0x000232E6 File Offset: 0x000214E6
		public TypesMatching Matching { get; set; }

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060007D4 RID: 2004 RVA: 0x000232EF File Offset: 0x000214EF
		public HashSet<Type> Types
		{
			get
			{
				return this.types;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x000232F7 File Offset: 0x000214F7
		// (set) Token: 0x060007D6 RID: 2006 RVA: 0x000232FF File Offset: 0x000214FF
		public bool Value { get; set; }

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060007D7 RID: 2007 RVA: 0x00023308 File Offset: 0x00021508
		// (set) Token: 0x060007D8 RID: 2008 RVA: 0x00023310 File Offset: 0x00021510
		public bool Reference { get; set; }

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060007D9 RID: 2009 RVA: 0x00023319 File Offset: 0x00021519
		// (set) Token: 0x060007DA RID: 2010 RVA: 0x00023321 File Offset: 0x00021521
		public bool Classes { get; set; }

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x0002332A File Offset: 0x0002152A
		// (set) Token: 0x060007DC RID: 2012 RVA: 0x00023332 File Offset: 0x00021532
		public bool Interfaces { get; set; }

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060007DD RID: 2013 RVA: 0x0002333B File Offset: 0x0002153B
		// (set) Token: 0x060007DE RID: 2014 RVA: 0x00023343 File Offset: 0x00021543
		public bool Structs { get; set; }

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x0002334C File Offset: 0x0002154C
		// (set) Token: 0x060007E0 RID: 2016 RVA: 0x00023354 File Offset: 0x00021554
		public bool Enums { get; set; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x0002335D File Offset: 0x0002155D
		// (set) Token: 0x060007E2 RID: 2018 RVA: 0x00023365 File Offset: 0x00021565
		public bool Public { get; set; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x0002336E File Offset: 0x0002156E
		// (set) Token: 0x060007E4 RID: 2020 RVA: 0x00023376 File Offset: 0x00021576
		public bool NonPublic { get; set; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x0002337F File Offset: 0x0002157F
		// (set) Token: 0x060007E6 RID: 2022 RVA: 0x00023387 File Offset: 0x00021587
		public bool Abstract { get; set; }

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x00023390 File Offset: 0x00021590
		// (set) Token: 0x060007E8 RID: 2024 RVA: 0x00023398 File Offset: 0x00021598
		public bool Generic { get; set; }

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x000233A1 File Offset: 0x000215A1
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x000233A9 File Offset: 0x000215A9
		public bool OpenConstructedGeneric { get; set; }

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x000233B2 File Offset: 0x000215B2
		// (set) Token: 0x060007EC RID: 2028 RVA: 0x000233BA File Offset: 0x000215BA
		public bool Static { get; set; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x000233C3 File Offset: 0x000215C3
		// (set) Token: 0x060007EE RID: 2030 RVA: 0x000233CB File Offset: 0x000215CB
		public bool Sealed { get; set; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x000233D4 File Offset: 0x000215D4
		// (set) Token: 0x060007F0 RID: 2032 RVA: 0x000233DC File Offset: 0x000215DC
		public bool Nested { get; set; }

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x000233E5 File Offset: 0x000215E5
		// (set) Token: 0x060007F2 RID: 2034 RVA: 0x000233ED File Offset: 0x000215ED
		public bool Primitives { get; set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x000233F6 File Offset: 0x000215F6
		// (set) Token: 0x060007F4 RID: 2036 RVA: 0x000233FE File Offset: 0x000215FE
		public bool Object { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x00023407 File Offset: 0x00021607
		// (set) Token: 0x060007F6 RID: 2038 RVA: 0x0002340F File Offset: 0x0002160F
		public bool NonSerializable { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x00023418 File Offset: 0x00021618
		// (set) Token: 0x060007F8 RID: 2040 RVA: 0x00023420 File Offset: 0x00021620
		public bool Obsolete { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x00023429 File Offset: 0x00021629
		public bool ExpectsBoolean
		{
			get
			{
				return this.Types.Count == 1 && this.Types.Single<Type>() == typeof(bool);
			}
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x00023455 File Offset: 0x00021655
		object ICloneable.Clone()
		{
			return this.Clone();
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x00023460 File Offset: 0x00021660
		public TypeFilter Clone()
		{
			return new TypeFilter(this.Matching, this.Types.ToArray<Type>())
			{
				Value = this.Value,
				Reference = this.Reference,
				Classes = this.Classes,
				Interfaces = this.Interfaces,
				Structs = this.Structs,
				Enums = this.Enums,
				Public = this.Public,
				NonPublic = this.NonPublic,
				Abstract = this.Abstract,
				Generic = this.Generic,
				OpenConstructedGeneric = this.OpenConstructedGeneric,
				Static = this.Static,
				Sealed = this.Sealed,
				Nested = this.Nested,
				Primitives = this.Primitives,
				Object = this.Object,
				NonSerializable = this.NonSerializable,
				Obsolete = this.Obsolete
			};
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0002355C File Offset: 0x0002175C
		public override bool Equals(object obj)
		{
			TypeFilter typeFilter = obj as TypeFilter;
			return typeFilter != null && (this.Matching == typeFilter.Matching && this.types.SetEquals(typeFilter.types) && this.Value == typeFilter.Value && this.Reference == typeFilter.Reference && this.Classes == typeFilter.Classes && this.Interfaces == typeFilter.Interfaces && this.Structs == typeFilter.Structs && this.Enums == typeFilter.Enums && this.Public == typeFilter.Public && this.NonPublic == typeFilter.NonPublic && this.Abstract == typeFilter.Abstract && this.Generic == typeFilter.Generic && this.OpenConstructedGeneric == typeFilter.OpenConstructedGeneric && this.Static == typeFilter.Static && this.Sealed == typeFilter.Sealed && this.Nested == typeFilter.Nested && this.Primitives == typeFilter.Primitives && this.Object == typeFilter.Object && this.NonSerializable == typeFilter.NonSerializable) && this.Obsolete == typeFilter.Obsolete;
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x000236B4 File Offset: 0x000218B4
		public override int GetHashCode()
		{
			int num = 17;
			num = num * 23 + this.Matching.GetHashCode();
			foreach (Type type in this.types)
			{
				if (type != null)
				{
					num = num * 23 + type.GetHashCode();
				}
			}
			num = num * 23 + this.Value.GetHashCode();
			num = num * 23 + this.Reference.GetHashCode();
			num = num * 23 + this.Classes.GetHashCode();
			num = num * 23 + this.Interfaces.GetHashCode();
			num = num * 23 + this.Structs.GetHashCode();
			num = num * 23 + this.Enums.GetHashCode();
			num = num * 23 + this.Public.GetHashCode();
			num = num * 23 + this.NonPublic.GetHashCode();
			num = num * 23 + this.Abstract.GetHashCode();
			num = num * 23 + this.Generic.GetHashCode();
			num = num * 23 + this.OpenConstructedGeneric.GetHashCode();
			num = num * 23 + this.Static.GetHashCode();
			num = num * 23 + this.Sealed.GetHashCode();
			num = num * 23 + this.Nested.GetHashCode();
			num = num * 23 + this.Primitives.GetHashCode();
			num = num * 23 + this.Object.GetHashCode();
			num = num * 23 + this.NonSerializable.GetHashCode();
			num = num * 23 + this.Obsolete.GetHashCode();
			return num;
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x000238B0 File Offset: 0x00021AB0
		public bool ValidateType(Type type)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			if (!this.Generic && type.IsGenericType)
			{
				return false;
			}
			if (!this.OpenConstructedGeneric && type.ContainsGenericParameters)
			{
				return false;
			}
			if (!this.Value && type.IsValueType)
			{
				return false;
			}
			if (!this.Reference && !type.IsValueType)
			{
				return false;
			}
			if (!this.Classes && type.IsClass)
			{
				return false;
			}
			if (!this.Interfaces && type.IsInterface)
			{
				return false;
			}
			if (!this.Structs && type.IsValueType && !type.IsEnum && !type.IsPrimitive)
			{
				return false;
			}
			if (!this.Enums && type.IsEnum)
			{
				return false;
			}
			if (!this.Public && type.IsVisible)
			{
				return false;
			}
			if (!this.NonPublic && !type.IsVisible)
			{
				return false;
			}
			if (!this.Abstract && type.IsAbstract())
			{
				return false;
			}
			if (!this.Static && type.IsStatic())
			{
				return false;
			}
			if (!this.Sealed && type.IsSealed)
			{
				return false;
			}
			if (!this.Nested && type.IsNested)
			{
				return false;
			}
			if (!this.Primitives && type.IsPrimitive)
			{
				return false;
			}
			if (!this.Object && type == typeof(object))
			{
				return false;
			}
			if (!this.NonSerializable && !type.IsSerializable)
			{
				return false;
			}
			if (type.IsSpecialName || type.HasAttribute(true))
			{
				return false;
			}
			if (!this.Obsolete && type.HasAttribute(true))
			{
				return false;
			}
			bool flag = true;
			if (this.Types.Count > 0)
			{
				flag = (this.Matching == TypesMatching.AssignableToAll);
				foreach (Type type2 in this.Types)
				{
					if (this.Matching == TypesMatching.Any)
					{
						if (type == type2)
						{
							flag = true;
							break;
						}
					}
					else if (this.Matching == TypesMatching.ConvertibleToAny)
					{
						if (type.IsConvertibleTo(type2, true))
						{
							flag = true;
							break;
						}
					}
					else
					{
						if (this.Matching != TypesMatching.AssignableToAll)
						{
							throw new UnexpectedEnumValueException<TypesMatching>(this.Matching);
						}
						flag &= type.IsSubclassOf(type2);
						if (!flag)
						{
							break;
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00023AEC File Offset: 0x00021CEC
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(string.Format("Matching: {0}", this.Matching));
			stringBuilder.AppendLine("Types: " + this.types.ToCommaSeparatedString());
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(string.Format("Value: {0}", this.Value));
			stringBuilder.AppendLine(string.Format("Reference: {0}", this.Reference));
			stringBuilder.AppendLine(string.Format("Classes: {0}", this.Classes));
			stringBuilder.AppendLine(string.Format("Interfaces: {0}", this.Interfaces));
			stringBuilder.AppendLine(string.Format("Structs: {0}", this.Structs));
			stringBuilder.AppendLine(string.Format("Enums: {0}", this.Enums));
			stringBuilder.AppendLine(string.Format("Public: {0}", this.Public));
			stringBuilder.AppendLine(string.Format("NonPublic: {0}", this.NonPublic));
			stringBuilder.AppendLine(string.Format("Abstract: {0}", this.Abstract));
			stringBuilder.AppendLine(string.Format("Generic: {0}", this.Generic));
			stringBuilder.AppendLine(string.Format("OpenConstructedGeneric: {0}", this.OpenConstructedGeneric));
			stringBuilder.AppendLine(string.Format("Static: {0}", this.Static));
			stringBuilder.AppendLine(string.Format("Sealed: {0}", this.Sealed));
			stringBuilder.AppendLine(string.Format("Nested: {0}", this.Nested));
			stringBuilder.AppendLine(string.Format("Primitives: {0}", this.Primitives));
			stringBuilder.AppendLine(string.Format("Object: {0}", this.Object));
			stringBuilder.AppendLine(string.Format("NonSerializable: {0}", this.NonSerializable));
			stringBuilder.AppendLine(string.Format("Obsolete: {0}", this.Obsolete));
			return stringBuilder.ToString();
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x00023D3A File Offset: 0x00021F3A
		public static TypeFilter Any
		{
			get
			{
				return new TypeFilter(Array.Empty<Type>());
			}
		}

		// Token: 0x040001D7 RID: 471
		private readonly HashSet<Type> types;
	}
}
