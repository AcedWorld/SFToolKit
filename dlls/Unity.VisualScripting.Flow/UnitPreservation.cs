using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x02000182 RID: 386
	public sealed class UnitPreservation : IPoolable
	{
		// Token: 0x06000A5A RID: 2650 RVA: 0x000128B9 File Offset: 0x00010AB9
		void IPoolable.New()
		{
			this.disposed = false;
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x000128C4 File Offset: 0x00010AC4
		void IPoolable.Free()
		{
			this.disposed = true;
			foreach (KeyValuePair<string, List<UnitPreservation.UnitPortPreservation>> keyValuePair in this.inputConnections)
			{
				ListPool<UnitPreservation.UnitPortPreservation>.Free(keyValuePair.Value);
			}
			foreach (KeyValuePair<string, List<UnitPreservation.UnitPortPreservation>> keyValuePair2 in this.outputConnections)
			{
				ListPool<UnitPreservation.UnitPortPreservation>.Free(keyValuePair2.Value);
			}
			this.defaultValues.Clear();
			this.inputConnections.Clear();
			this.outputConnections.Clear();
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0001298C File Offset: 0x00010B8C
		private UnitPreservation()
		{
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x000129B8 File Offset: 0x00010BB8
		public static UnitPreservation Preserve(IUnit unit)
		{
			UnitPreservation unitPreservation = GenericPool<UnitPreservation>.New(() => new UnitPreservation());
			foreach (KeyValuePair<string, object> keyValuePair in unit.defaultValues)
			{
				unitPreservation.defaultValues.Add(keyValuePair.Key, keyValuePair.Value);
			}
			foreach (IUnitInputPort unitInputPort in unit.inputs)
			{
				if (unitInputPort.hasAnyConnection)
				{
					unitPreservation.inputConnections.Add(unitInputPort.key, ListPool<UnitPreservation.UnitPortPreservation>.New());
					foreach (IUnitPort port in unitInputPort.connectedPorts)
					{
						unitPreservation.inputConnections[unitInputPort.key].Add(new UnitPreservation.UnitPortPreservation(port));
					}
				}
			}
			foreach (IUnitOutputPort unitOutputPort in unit.outputs)
			{
				if (unitOutputPort.hasAnyConnection)
				{
					unitPreservation.outputConnections.Add(unitOutputPort.key, ListPool<UnitPreservation.UnitPortPreservation>.New());
					foreach (IUnitPort port2 in unitOutputPort.connectedPorts)
					{
						unitPreservation.outputConnections[unitOutputPort.key].Add(new UnitPreservation.UnitPortPreservation(port2));
					}
				}
			}
			return unitPreservation;
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00012BA8 File Offset: 0x00010DA8
		public void RestoreTo(IUnit unit)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(this.ToString());
			}
			foreach (KeyValuePair<string, object> keyValuePair in this.defaultValues)
			{
				if (unit.defaultValues.ContainsKey(keyValuePair.Key) && unit.valueInputs.Contains(keyValuePair.Key) && unit.valueInputs[keyValuePair.Key].type.IsAssignableFrom(keyValuePair.Value))
				{
					unit.defaultValues[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			foreach (KeyValuePair<string, List<UnitPreservation.UnitPortPreservation>> keyValuePair2 in this.inputConnections)
			{
				UnitPreservation.UnitPortPreservation destinationPreservation = new UnitPreservation.UnitPortPreservation(unit, keyValuePair2.Key);
				foreach (UnitPreservation.UnitPortPreservation sourcePreservation in keyValuePair2.Value)
				{
					this.RestoreConnection(sourcePreservation, destinationPreservation);
				}
			}
			foreach (KeyValuePair<string, List<UnitPreservation.UnitPortPreservation>> keyValuePair3 in this.outputConnections)
			{
				UnitPreservation.UnitPortPreservation sourcePreservation2 = new UnitPreservation.UnitPortPreservation(unit, keyValuePair3.Key);
				foreach (UnitPreservation.UnitPortPreservation destinationPreservation2 in keyValuePair3.Value)
				{
					this.RestoreConnection(sourcePreservation2, destinationPreservation2);
				}
			}
			GenericPool<UnitPreservation>.Free(this);
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x00012D9C File Offset: 0x00010F9C
		private void RestoreConnection(UnitPreservation.UnitPortPreservation sourcePreservation, UnitPreservation.UnitPortPreservation destinationPreservation)
		{
			InvalidOutput invalidOutput;
			IUnitPort orCreateOutput = sourcePreservation.GetOrCreateOutput(out invalidOutput);
			InvalidInput invalidInput;
			IUnitPort orCreateInput = destinationPreservation.GetOrCreateInput(out invalidInput);
			if (orCreateOutput.CanValidlyConnectTo(orCreateInput))
			{
				orCreateOutput.ValidlyConnectTo(orCreateInput);
				return;
			}
			if (orCreateOutput.CanInvalidlyConnectTo(orCreateInput))
			{
				orCreateOutput.InvalidlyConnectTo(orCreateInput);
				return;
			}
			if (invalidOutput != null)
			{
				sourcePreservation.unit.invalidOutputs.Remove(invalidOutput);
			}
			if (invalidInput != null)
			{
				destinationPreservation.unit.invalidInputs.Remove(invalidInput);
			}
		}

		// Token: 0x04000224 RID: 548
		private readonly Dictionary<string, object> defaultValues = new Dictionary<string, object>();

		// Token: 0x04000225 RID: 549
		private readonly Dictionary<string, List<UnitPreservation.UnitPortPreservation>> inputConnections = new Dictionary<string, List<UnitPreservation.UnitPortPreservation>>();

		// Token: 0x04000226 RID: 550
		private readonly Dictionary<string, List<UnitPreservation.UnitPortPreservation>> outputConnections = new Dictionary<string, List<UnitPreservation.UnitPortPreservation>>();

		// Token: 0x04000227 RID: 551
		private bool disposed;

		// Token: 0x020001E3 RID: 483
		private struct UnitPortPreservation
		{
			// Token: 0x06000C72 RID: 3186 RVA: 0x0001C17F File Offset: 0x0001A37F
			public UnitPortPreservation(IUnitPort port)
			{
				this.unit = port.unit;
				this.key = port.key;
			}

			// Token: 0x06000C73 RID: 3187 RVA: 0x0001C199 File Offset: 0x0001A399
			public UnitPortPreservation(IUnit unit, string key)
			{
				this.unit = unit;
				this.key = key;
			}

			// Token: 0x06000C74 RID: 3188 RVA: 0x0001C1AC File Offset: 0x0001A3AC
			public IUnitPort GetOrCreateInput(out InvalidInput newInvalidInput)
			{
				string key = this.key;
				if (!this.unit.inputs.Any((IUnitInputPort p) => p.key == key))
				{
					newInvalidInput = new InvalidInput(key);
					this.unit.invalidInputs.Add(newInvalidInput);
				}
				else
				{
					newInvalidInput = null;
				}
				return this.unit.inputs.Single((IUnitInputPort p) => p.key == key);
			}

			// Token: 0x06000C75 RID: 3189 RVA: 0x0001C22C File Offset: 0x0001A42C
			public IUnitPort GetOrCreateOutput(out InvalidOutput newInvalidOutput)
			{
				string key = this.key;
				if (!this.unit.outputs.Any((IUnitOutputPort p) => p.key == key))
				{
					newInvalidOutput = new InvalidOutput(key);
					this.unit.invalidOutputs.Add(newInvalidOutput);
				}
				else
				{
					newInvalidOutput = null;
				}
				return this.unit.outputs.Single((IUnitOutputPort p) => p.key == key);
			}

			// Token: 0x04000423 RID: 1059
			public readonly IUnit unit;

			// Token: 0x04000424 RID: 1060
			public readonly string key;
		}
	}
}
