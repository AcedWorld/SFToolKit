using System;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x0200015A RID: 346
	public static class XUnit
	{
		// Token: 0x06000901 RID: 2305 RVA: 0x000104DC File Offset: 0x0000E6DC
		public static ValueInput CompatibleValueInput(this IUnit unit, Type outputType)
		{
			Ensure.That("outputType").IsNotNull<Type>(outputType);
			return (from valueInput in unit.valueInputs
			where ConversionUtility.CanConvert(outputType, valueInput.type, false)
			select valueInput).OrderBy(delegate(ValueInput valueInput)
			{
				bool flag = outputType == valueInput.type;
				bool flag2 = !valueInput.hasValidConnection;
				if (flag2 && flag)
				{
					return 1;
				}
				if (flag2)
				{
					return 2;
				}
				if (flag)
				{
					return 3;
				}
				return 4;
			}).FirstOrDefault<ValueInput>();
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00010538 File Offset: 0x0000E738
		public static ValueOutput CompatibleValueOutput(this IUnit unit, Type inputType)
		{
			Ensure.That("inputType").IsNotNull<Type>(inputType);
			return (from valueOutput in unit.valueOutputs
			where ConversionUtility.CanConvert(valueOutput.type, inputType, false)
			select valueOutput).OrderBy(delegate(ValueOutput valueOutput)
			{
				bool flag = inputType == valueOutput.type;
				bool flag2 = !valueOutput.hasValidConnection;
				if (flag2 && flag)
				{
					return 1;
				}
				if (flag2)
				{
					return 2;
				}
				if (flag)
				{
					return 3;
				}
				return 4;
			}).FirstOrDefault<ValueOutput>();
		}
	}
}
