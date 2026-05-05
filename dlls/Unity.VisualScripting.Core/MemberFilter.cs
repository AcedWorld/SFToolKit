using System;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000D5 RID: 213
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public sealed class MemberFilter : Attribute, ICloneable
	{
		// Token: 0x0600059B RID: 1435 RVA: 0x0000DFE4 File Offset: 0x0000C1E4
		public MemberFilter()
		{
			this.Fields = false;
			this.Properties = false;
			this.Methods = false;
			this.Constructors = false;
			this.Gettable = false;
			this.Settable = false;
			this.Inherited = true;
			this.Targeted = true;
			this.NonTargeted = true;
			this.Public = true;
			this.NonPublic = false;
			this.ReadOnly = true;
			this.WriteOnly = true;
			this.Extensions = true;
			this.Operators = true;
			this.Conversions = true;
			this.Parameters = true;
			this.Obsolete = false;
			this.OpenConstructedGeneric = false;
			this.TypeInitializers = true;
			this.ClsNonCompliant = true;
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0000E08A File Offset: 0x0000C28A
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0000E092 File Offset: 0x0000C292
		public bool Fields { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x0000E09B File Offset: 0x0000C29B
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x0000E0A3 File Offset: 0x0000C2A3
		public bool Properties { get; set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x0000E0AC File Offset: 0x0000C2AC
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x0000E0B4 File Offset: 0x0000C2B4
		public bool Methods { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x0000E0BD File Offset: 0x0000C2BD
		// (set) Token: 0x060005A3 RID: 1443 RVA: 0x0000E0C5 File Offset: 0x0000C2C5
		public bool Constructors { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0000E0CE File Offset: 0x0000C2CE
		// (set) Token: 0x060005A5 RID: 1445 RVA: 0x0000E0D6 File Offset: 0x0000C2D6
		public bool Gettable { get; set; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x0000E0DF File Offset: 0x0000C2DF
		// (set) Token: 0x060005A7 RID: 1447 RVA: 0x0000E0E7 File Offset: 0x0000C2E7
		public bool Settable { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x0000E0F0 File Offset: 0x0000C2F0
		// (set) Token: 0x060005A9 RID: 1449 RVA: 0x0000E0F8 File Offset: 0x0000C2F8
		public bool Inherited { get; set; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x0000E101 File Offset: 0x0000C301
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x0000E109 File Offset: 0x0000C309
		public bool Targeted { get; set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x0000E112 File Offset: 0x0000C312
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x0000E11A File Offset: 0x0000C31A
		public bool NonTargeted { get; set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x0000E123 File Offset: 0x0000C323
		// (set) Token: 0x060005AF RID: 1455 RVA: 0x0000E12B File Offset: 0x0000C32B
		public bool Public { get; set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0000E134 File Offset: 0x0000C334
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0000E13C File Offset: 0x0000C33C
		public bool NonPublic { get; set; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x0000E145 File Offset: 0x0000C345
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x0000E14D File Offset: 0x0000C34D
		public bool ReadOnly { get; set; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x0000E156 File Offset: 0x0000C356
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x0000E15E File Offset: 0x0000C35E
		public bool WriteOnly { get; set; }

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x0000E167 File Offset: 0x0000C367
		// (set) Token: 0x060005B7 RID: 1463 RVA: 0x0000E16F File Offset: 0x0000C36F
		public bool Extensions { get; set; }

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0000E178 File Offset: 0x0000C378
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x0000E180 File Offset: 0x0000C380
		public bool Operators { get; set; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x0000E189 File Offset: 0x0000C389
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x0000E191 File Offset: 0x0000C391
		public bool Conversions { get; set; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x0000E19A File Offset: 0x0000C39A
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x0000E1A2 File Offset: 0x0000C3A2
		public bool Setters { get; set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x0000E1AB File Offset: 0x0000C3AB
		// (set) Token: 0x060005BF RID: 1471 RVA: 0x0000E1B3 File Offset: 0x0000C3B3
		public bool Parameters { get; set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x0000E1BC File Offset: 0x0000C3BC
		// (set) Token: 0x060005C1 RID: 1473 RVA: 0x0000E1C4 File Offset: 0x0000C3C4
		public bool Obsolete { get; set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x0000E1CD File Offset: 0x0000C3CD
		// (set) Token: 0x060005C3 RID: 1475 RVA: 0x0000E1D5 File Offset: 0x0000C3D5
		public bool OpenConstructedGeneric { get; set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x0000E1DE File Offset: 0x0000C3DE
		// (set) Token: 0x060005C5 RID: 1477 RVA: 0x0000E1E6 File Offset: 0x0000C3E6
		public bool TypeInitializers { get; set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x0000E1EF File Offset: 0x0000C3EF
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x0000E1F7 File Offset: 0x0000C3F7
		public bool ClsNonCompliant { get; set; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x0000E200 File Offset: 0x0000C400
		public BindingFlags validBindingFlags
		{
			get
			{
				BindingFlags bindingFlags = BindingFlags.Default;
				if (this.Public)
				{
					bindingFlags |= BindingFlags.Public;
				}
				if (this.NonPublic)
				{
					bindingFlags |= BindingFlags.NonPublic;
				}
				if (this.Targeted || this.Constructors)
				{
					bindingFlags |= BindingFlags.Instance;
				}
				if (this.NonTargeted)
				{
					bindingFlags |= BindingFlags.Static;
				}
				if (!this.Inherited)
				{
					bindingFlags |= BindingFlags.DeclaredOnly;
				}
				if (this.NonTargeted && this.Inherited)
				{
					bindingFlags |= BindingFlags.FlattenHierarchy;
				}
				return bindingFlags;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0000E26C File Offset: 0x0000C46C
		public MemberTypes validMemberTypes
		{
			get
			{
				MemberTypes memberTypes = (MemberTypes)0;
				if (this.Fields || this.Gettable || this.Settable)
				{
					memberTypes |= MemberTypes.Field;
				}
				if (this.Properties || this.Gettable || this.Settable)
				{
					memberTypes |= MemberTypes.Property;
				}
				if (this.Methods || this.Gettable)
				{
					memberTypes |= MemberTypes.Method;
				}
				if (this.Constructors || this.Gettable)
				{
					memberTypes |= MemberTypes.Constructor;
				}
				return memberTypes;
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0000E2DD File Offset: 0x0000C4DD
		object ICloneable.Clone()
		{
			return this.Clone();
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0000E2E8 File Offset: 0x0000C4E8
		public MemberFilter Clone()
		{
			return new MemberFilter
			{
				Fields = this.Fields,
				Properties = this.Properties,
				Methods = this.Methods,
				Constructors = this.Constructors,
				Gettable = this.Gettable,
				Settable = this.Settable,
				Inherited = this.Inherited,
				Targeted = this.Targeted,
				NonTargeted = this.NonTargeted,
				Public = this.Public,
				NonPublic = this.NonPublic,
				ReadOnly = this.ReadOnly,
				WriteOnly = this.WriteOnly,
				Extensions = this.Extensions,
				Operators = this.Operators,
				Conversions = this.Conversions,
				Parameters = this.Parameters,
				Obsolete = this.Obsolete,
				OpenConstructedGeneric = this.OpenConstructedGeneric,
				TypeInitializers = this.TypeInitializers,
				ClsNonCompliant = this.ClsNonCompliant
			};
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0000E3F8 File Offset: 0x0000C5F8
		public override bool Equals(object obj)
		{
			MemberFilter memberFilter = obj as MemberFilter;
			return memberFilter != null && (this.Fields == memberFilter.Fields && this.Properties == memberFilter.Properties && this.Methods == memberFilter.Methods && this.Constructors == memberFilter.Constructors && this.Gettable == memberFilter.Gettable && this.Settable == memberFilter.Settable && this.Inherited == memberFilter.Inherited && this.Targeted == memberFilter.Targeted && this.NonTargeted == memberFilter.NonTargeted && this.Public == memberFilter.Public && this.NonPublic == memberFilter.NonPublic && this.ReadOnly == memberFilter.ReadOnly && this.WriteOnly == memberFilter.WriteOnly && this.Extensions == memberFilter.Extensions && this.Operators == memberFilter.Operators && this.Conversions == memberFilter.Conversions && this.Parameters == memberFilter.Parameters && this.Obsolete == memberFilter.Obsolete && this.OpenConstructedGeneric == memberFilter.OpenConstructedGeneric && this.TypeInitializers == memberFilter.TypeInitializers) && this.ClsNonCompliant == memberFilter.ClsNonCompliant;
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0000E55C File Offset: 0x0000C75C
		public override int GetHashCode()
		{
			return ((((((((((((((((((((17 * 23 + this.Fields.GetHashCode()) * 23 + this.Properties.GetHashCode()) * 23 + this.Methods.GetHashCode()) * 23 + this.Constructors.GetHashCode()) * 23 + this.Gettable.GetHashCode()) * 23 + this.Settable.GetHashCode()) * 23 + this.Inherited.GetHashCode()) * 23 + this.Targeted.GetHashCode()) * 23 + this.NonTargeted.GetHashCode()) * 23 + this.Public.GetHashCode()) * 23 + this.NonPublic.GetHashCode()) * 23 + this.ReadOnly.GetHashCode()) * 23 + this.WriteOnly.GetHashCode()) * 23 + this.Extensions.GetHashCode()) * 23 + this.Operators.GetHashCode()) * 23 + this.Conversions.GetHashCode()) * 23 + this.Parameters.GetHashCode()) * 23 + this.Obsolete.GetHashCode()) * 23 + this.OpenConstructedGeneric.GetHashCode()) * 23 + this.TypeInitializers.GetHashCode()) * 23 + this.ClsNonCompliant.GetHashCode();
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0000E6E8 File Offset: 0x0000C8E8
		public bool ValidateMember(MemberInfo member, TypeFilter typeFilter = null)
		{
			if (member is FieldInfo)
			{
				FieldInfo fieldInfo = (FieldInfo)member;
				bool flag = true;
				bool flag2 = !fieldInfo.IsLiteral && !fieldInfo.IsInitOnly;
				if (!this.Fields && (!this.Gettable || !flag) && (!this.Settable || !flag2))
				{
					return false;
				}
				bool flag3 = !fieldInfo.IsStatic;
				if (!this.Targeted && flag3)
				{
					return false;
				}
				if (!this.NonTargeted && !flag3)
				{
					return false;
				}
				if (!this.WriteOnly && !flag)
				{
					return false;
				}
				if (!this.ReadOnly && !flag2)
				{
					return false;
				}
				if (!this.Public && fieldInfo.IsPublic)
				{
					return false;
				}
				if (!this.NonPublic && !fieldInfo.IsPublic)
				{
					return false;
				}
				if (typeFilter != null && !typeFilter.ValidateType(fieldInfo.FieldType))
				{
					return false;
				}
				if (fieldInfo.IsSpecialName)
				{
					return false;
				}
			}
			else if (member is PropertyInfo)
			{
				PropertyInfo propertyInfo = (PropertyInfo)member;
				MethodInfo getMethod = propertyInfo.GetGetMethod(true);
				MethodInfo setMethod = propertyInfo.GetSetMethod(true);
				bool canRead = propertyInfo.CanRead;
				bool canWrite = propertyInfo.CanWrite;
				if (!this.Properties && (!this.Gettable || !canRead) && (!this.Settable || !canWrite))
				{
					return false;
				}
				bool flag4 = !this.WriteOnly || (!this.Properties && this.Gettable);
				bool flag5 = !this.ReadOnly || (!this.Properties && this.Settable);
				bool flag6 = propertyInfo.CanRead && (this.NonPublic || getMethod.IsPublic);
				bool flag7 = propertyInfo.CanWrite && (this.NonPublic || setMethod.IsPublic);
				if (flag4 && !flag6)
				{
					return false;
				}
				if (flag5 && !flag7)
				{
					return false;
				}
				bool flag8 = !(getMethod ?? setMethod).IsStatic;
				if (!this.Targeted && flag8)
				{
					return false;
				}
				if (!this.NonTargeted && !flag8)
				{
					return false;
				}
				if (typeFilter != null && !typeFilter.ValidateType(propertyInfo.PropertyType))
				{
					return false;
				}
				if (propertyInfo.IsSpecialName)
				{
					return false;
				}
				if (propertyInfo.GetIndexParameters().Any<ParameterInfo>())
				{
					return false;
				}
			}
			else if (member is MethodBase)
			{
				MethodBase methodBase = (MethodBase)member;
				bool flag9 = methodBase.IsExtensionMethod();
				bool flag10 = !methodBase.IsStatic || flag9;
				if (!this.Public && methodBase.IsPublic)
				{
					return false;
				}
				if (!this.NonPublic && !methodBase.IsPublic)
				{
					return false;
				}
				if (!this.Parameters && methodBase.GetParameters().Length > (flag9 ? 1 : 0))
				{
					return false;
				}
				if (!this.OpenConstructedGeneric && methodBase.ContainsGenericParameters)
				{
					return false;
				}
				if (member is MethodInfo)
				{
					MethodInfo methodInfo = (MethodInfo)member;
					bool flag11 = methodInfo.IsOperator();
					bool flag12 = methodInfo.IsUserDefinedConversion();
					bool flag13 = methodInfo.ReturnType != typeof(void);
					bool flag14 = false;
					if (!this.Methods && (!this.Gettable || !flag13) && (!this.Settable || !flag14))
					{
						return false;
					}
					if (!this.Targeted && flag10)
					{
						return false;
					}
					if (!this.NonTargeted && !flag10)
					{
						return false;
					}
					if (!this.Operators && flag11)
					{
						return false;
					}
					if (!this.Extensions && flag9)
					{
						return false;
					}
					if (typeFilter != null && !typeFilter.ValidateType(methodInfo.ReturnType))
					{
						return false;
					}
					if (methodInfo.IsSpecialName && (!flag11 && !flag12))
					{
						return false;
					}
					if (flag13 && methodInfo.ReturnType.IsByRefLike)
					{
						return false;
					}
				}
				else if (member is ConstructorInfo)
				{
					ConstructorInfo constructorInfo = (ConstructorInfo)member;
					bool flag15 = true;
					bool flag16 = false;
					if (!this.Constructors && (!this.Gettable || !flag15) && (!this.Settable || !flag16))
					{
						return false;
					}
					if (typeFilter != null && !typeFilter.ValidateType(constructorInfo.DeclaringType))
					{
						return false;
					}
					if (constructorInfo.IsStatic && !this.TypeInitializers)
					{
						return false;
					}
					if (typeof(Component).IsAssignableFrom(member.DeclaringType) || typeof(ScriptableObject).IsAssignableFrom(member.DeclaringType))
					{
						return false;
					}
				}
			}
			if (!this.Obsolete && member.HasAttribute(false))
			{
				return false;
			}
			if (!this.ClsNonCompliant)
			{
				CLSCompliantAttribute attribute = member.GetAttribute(true);
				if (attribute != null && !attribute.IsCompliant)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0000EB38 File Offset: 0x0000CD38
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(string.Format("Fields: {0}", this.Fields));
			stringBuilder.AppendLine(string.Format("Properties: {0}", this.Properties));
			stringBuilder.AppendLine(string.Format("Methods: {0}", this.Methods));
			stringBuilder.AppendLine(string.Format("Constructors: {0}", this.Constructors));
			stringBuilder.AppendLine(string.Format("Gettable: {0}", this.Gettable));
			stringBuilder.AppendLine(string.Format("Settable: {0}", this.Settable));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(string.Format("Inherited: {0}", this.Inherited));
			stringBuilder.AppendLine(string.Format("Instance: {0}", this.Targeted));
			stringBuilder.AppendLine(string.Format("Static: {0}", this.NonTargeted));
			stringBuilder.AppendLine(string.Format("Public: {0}", this.Public));
			stringBuilder.AppendLine(string.Format("NonPublic: {0}", this.NonPublic));
			stringBuilder.AppendLine(string.Format("ReadOnly: {0}", this.ReadOnly));
			stringBuilder.AppendLine(string.Format("WriteOnly: {0}", this.WriteOnly));
			stringBuilder.AppendLine(string.Format("Extensions: {0}", this.Extensions));
			stringBuilder.AppendLine(string.Format("Operators: {0}", this.Operators));
			stringBuilder.AppendLine(string.Format("Conversions: {0}", this.Conversions));
			stringBuilder.AppendLine(string.Format("Parameters: {0}", this.Parameters));
			stringBuilder.AppendLine(string.Format("Obsolete: {0}", this.Obsolete));
			stringBuilder.AppendLine(string.Format("OpenConstructedGeneric: {0}", this.OpenConstructedGeneric));
			stringBuilder.AppendLine(string.Format("TypeInitializers: {0}", this.TypeInitializers));
			stringBuilder.AppendLine(string.Format("ClsNonCompliant: {0}", this.ClsNonCompliant));
			return stringBuilder.ToString();
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x0000EDA2 File Offset: 0x0000CFA2
		public static MemberFilter Any
		{
			get
			{
				return new MemberFilter
				{
					Fields = true,
					Properties = true,
					Methods = true,
					Constructors = true
				};
			}
		}
	}
}
