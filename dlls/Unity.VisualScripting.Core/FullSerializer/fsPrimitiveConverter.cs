using System;
using Unity.VisualScripting.FullSerializer.Internal;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000183 RID: 387
	public class fsPrimitiveConverter : fsConverter
	{
		// Token: 0x06000A4D RID: 2637 RVA: 0x0002AE9D File Offset: 0x0002909D
		public override bool CanProcess(Type type)
		{
			return type.Resolve().IsPrimitive || type == typeof(string) || type == typeof(decimal);
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0002AED0 File Offset: 0x000290D0
		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x0002AED3 File Offset: 0x000290D3
		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0002AED8 File Offset: 0x000290D8
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			Type type = instance.GetType();
			if (this.Serializer.Config.Serialize64BitIntegerAsString && (type == typeof(long) || type == typeof(ulong)))
			{
				serialized = new fsData((string)Convert.ChangeType(instance, typeof(string)));
				return fsResult.Success;
			}
			if (fsPrimitiveConverter.UseBool(type))
			{
				serialized = new fsData((bool)instance);
				return fsResult.Success;
			}
			if (fsPrimitiveConverter.UseInt64(type))
			{
				serialized = new fsData((long)Convert.ChangeType(instance, typeof(long)));
				return fsResult.Success;
			}
			if (fsPrimitiveConverter.UseDouble(type))
			{
				if (instance.GetType() == typeof(float) && (float)instance != -3.4028235E+38f && (float)instance != 3.4028235E+38f && !float.IsInfinity((float)instance) && !float.IsNaN((float)instance))
				{
					serialized = new fsData((double)((decimal)((float)instance)));
					return fsResult.Success;
				}
				serialized = new fsData((double)Convert.ChangeType(instance, typeof(double)));
				return fsResult.Success;
			}
			else
			{
				if (fsPrimitiveConverter.UseString(type))
				{
					serialized = new fsData((string)Convert.ChangeType(instance, typeof(string)));
					return fsResult.Success;
				}
				serialized = null;
				string str = "Unhandled primitive type ";
				Type type2 = instance.GetType();
				return fsResult.Fail(str + ((type2 != null) ? type2.ToString() : null));
			}
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x0002B070 File Offset: 0x00029270
		public override fsResult TryDeserialize(fsData storage, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			if (fsPrimitiveConverter.UseBool(storageType))
			{
				fsResult fsResult2;
				fsResult = (fsResult2 = fsResult + base.CheckType(storage, fsDataType.Boolean));
				if (fsResult2.Succeeded)
				{
					instance = storage.AsBool;
				}
				return fsResult;
			}
			if (fsPrimitiveConverter.UseDouble(storageType) || fsPrimitiveConverter.UseInt64(storageType))
			{
				if (storage.IsDouble)
				{
					instance = Convert.ChangeType(storage.AsDouble, storageType);
				}
				else if (storage.IsInt64)
				{
					instance = Convert.ChangeType(storage.AsInt64, storageType);
				}
				else
				{
					if (!this.Serializer.Config.Serialize64BitIntegerAsString || !storage.IsString || (!(storageType == typeof(long)) && !(storageType == typeof(ulong))))
					{
						return fsResult.Fail(string.Concat(new string[]
						{
							base.GetType().Name,
							" expected number but got ",
							storage.Type.ToString(),
							" in ",
							(storage != null) ? storage.ToString() : null
						}));
					}
					instance = Convert.ChangeType(storage.AsString, storageType);
				}
				return fsResult.Success;
			}
			if (fsPrimitiveConverter.UseString(storageType))
			{
				fsResult fsResult2;
				fsResult = (fsResult2 = fsResult + base.CheckType(storage, fsDataType.String));
				if (fsResult2.Succeeded)
				{
					string asString = storage.AsString;
					if (storageType == typeof(char))
					{
						if (storageType == typeof(char))
						{
							if (asString.Length == 1)
							{
								instance = asString[0];
							}
							else
							{
								instance = '\0';
							}
						}
					}
					else
					{
						instance = asString;
					}
				}
				return fsResult;
			}
			return fsResult.Fail(base.GetType().Name + ": Bad data; expected bool, number, string, but got " + ((storage != null) ? storage.ToString() : null));
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x0002B24D File Offset: 0x0002944D
		private static bool UseBool(Type type)
		{
			return type == typeof(bool);
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x0002B260 File Offset: 0x00029460
		private static bool UseInt64(Type type)
		{
			return type == typeof(sbyte) || type == typeof(byte) || type == typeof(short) || type == typeof(ushort) || type == typeof(int) || type == typeof(uint) || type == typeof(long) || type == typeof(ulong);
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x0002B2FD File Offset: 0x000294FD
		private static bool UseDouble(Type type)
		{
			return type == typeof(float) || type == typeof(double) || type == typeof(decimal);
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0002B335 File Offset: 0x00029535
		private static bool UseString(Type type)
		{
			return type == typeof(string) || type == typeof(char);
		}
	}
}
