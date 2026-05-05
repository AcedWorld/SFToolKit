using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000017 RID: 23
	public sealed class Flow : IPoolable, IDisposable
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002955 File Offset: 0x00000B55
		// (set) Token: 0x06000072 RID: 114 RVA: 0x0000295D File Offset: 0x00000B5D
		public GraphStack stack { get; private set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002966 File Offset: 0x00000B66
		// (set) Token: 0x06000074 RID: 116 RVA: 0x0000296E File Offset: 0x00000B6E
		public MonoBehaviour coroutineRunner { get; private set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00002977 File Offset: 0x00000B77
		// (set) Token: 0x06000076 RID: 118 RVA: 0x0000297F File Offset: 0x00000B7F
		public bool isCoroutine { get; private set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002988 File Offset: 0x00000B88
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00002990 File Offset: 0x00000B90
		public bool isPrediction { get; private set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00002999 File Offset: 0x00000B99
		public bool enableDebug
		{
			get
			{
				return !this.isPrediction && this.stack.hasDebugData;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000029B5 File Offset: 0x00000BB5
		// (set) Token: 0x0600007B RID: 123 RVA: 0x000029BC File Offset: 0x00000BBC
		public static Func<GraphPointer, bool> isInspectedBinding { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600007C RID: 124 RVA: 0x000029C4 File Offset: 0x00000BC4
		public bool isInspected
		{
			get
			{
				Func<GraphPointer, bool> isInspectedBinding = Flow.isInspectedBinding;
				return isInspectedBinding != null && isInspectedBinding(this.stack);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000029DC File Offset: 0x00000BDC
		private Flow()
		{
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002A18 File Offset: 0x00000C18
		public static Flow New(GraphReference reference)
		{
			Ensure.That("reference").IsNotNull<GraphReference>(reference);
			Flow flow = GenericPool<Flow>.New(() => new Flow());
			flow.stack = reference.ToStackPooled();
			return flow;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00002A65 File Offset: 0x00000C65
		void IPoolable.New()
		{
			this.disposed = false;
			this.recursion = Recursion<Flow.RecursionNode>.New();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002A79 File Offset: 0x00000C79
		public void Dispose()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(this.ToString());
			}
			GenericPool<Flow>.Free(this);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002A98 File Offset: 0x00000C98
		void IPoolable.Free()
		{
			GraphStack stack = this.stack;
			if (stack != null)
			{
				stack.Dispose();
			}
			Recursion<Flow.RecursionNode> recursion = this.recursion;
			if (recursion != null)
			{
				recursion.Dispose();
			}
			this.locals.Clear();
			this.loops.Clear();
			this.variables.Clear();
			foreach (GraphStack graphStack in this.preservedStacks)
			{
				graphStack.Dispose();
			}
			this.preservedStacks.Clear();
			this.loopIdentifier = -1;
			this.stack = null;
			this.recursion = null;
			this.isCoroutine = false;
			this.coroutineEnumerator = null;
			this.coroutineRunner = null;
			ICollection<Flow> collection = this.activeCoroutinesRegistry;
			if (collection != null)
			{
				collection.Remove(this);
			}
			this.activeCoroutinesRegistry = null;
			this.coroutineStopRequested = false;
			this.isPrediction = false;
			this.disposed = true;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002B90 File Offset: 0x00000D90
		public GraphStack PreserveStack()
		{
			GraphStack graphStack = this.stack.Clone();
			this.preservedStacks.Add(graphStack);
			return graphStack;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002BB7 File Offset: 0x00000DB7
		public void RestoreStack(GraphStack stack)
		{
			this.stack.CopyFrom(stack);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00002BC5 File Offset: 0x00000DC5
		public void DisposePreservedStack(GraphStack stack)
		{
			stack.Dispose();
			this.preservedStacks.Remove(stack);
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00002BDA File Offset: 0x00000DDA
		public int currentLoop
		{
			get
			{
				if (this.loops.Count > 0)
				{
					return this.loops.Peek();
				}
				return -1;
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002BF7 File Offset: 0x00000DF7
		public bool LoopIsNotBroken(int loop)
		{
			return this.currentLoop == loop;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00002C04 File Offset: 0x00000E04
		public int EnterLoop()
		{
			int num = this.loopIdentifier + 1;
			this.loopIdentifier = num;
			int num2 = num;
			this.loops.Push(num2);
			return num2;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00002C30 File Offset: 0x00000E30
		public void BreakLoop()
		{
			if (this.currentLoop < 0)
			{
				throw new InvalidOperationException("No active loop to break.");
			}
			this.loops.Pop();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002C52 File Offset: 0x00000E52
		public void ExitLoop(int loop)
		{
			if (loop != this.currentLoop)
			{
				return;
			}
			this.loops.Pop();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00002C6A File Offset: 0x00000E6A
		public void Run(ControlOutput port)
		{
			this.Invoke(port);
			this.Dispose();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00002C7C File Offset: 0x00000E7C
		public void StartCoroutine(ControlOutput port, ICollection<Flow> registry = null)
		{
			this.isCoroutine = true;
			this.coroutineRunner = this.stack.component;
			if (this.coroutineRunner == null)
			{
				this.coroutineRunner = CoroutineRunner.instance;
			}
			this.activeCoroutinesRegistry = registry;
			ICollection<Flow> collection = this.activeCoroutinesRegistry;
			if (collection != null)
			{
				collection.Add(this);
			}
			this.coroutineEnumerator = this.Coroutine(port);
			this.coroutineRunner.StartCoroutine(this.coroutineEnumerator);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00002CF2 File Offset: 0x00000EF2
		public void StopCoroutine(bool disposeInstantly)
		{
			if (!this.isCoroutine)
			{
				throw new NotSupportedException("Stop may only be called on coroutines.");
			}
			if (disposeInstantly)
			{
				this.StopCoroutineImmediate();
				return;
			}
			this.coroutineStopRequested = true;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002D18 File Offset: 0x00000F18
		internal void StopCoroutineImmediate()
		{
			if (this.coroutineRunner && this.coroutineEnumerator != null)
			{
				this.coroutineRunner.StopCoroutine(this.coroutineEnumerator);
				((IDisposable)this.coroutineEnumerator).Dispose();
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002D50 File Offset: 0x00000F50
		private IEnumerator Coroutine(ControlOutput startPort)
		{
			try
			{
				foreach (object obj in this.InvokeCoroutine(startPort))
				{
					if (this.coroutineStopRequested)
					{
						yield break;
					}
					yield return obj;
					if (this.coroutineStopRequested)
					{
						yield break;
					}
				}
				IEnumerator enumerator = null;
			}
			finally
			{
				if (!this.disposed)
				{
					this.Dispose();
				}
			}
			yield break;
			yield break;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00002D68 File Offset: 0x00000F68
		public void Invoke(ControlOutput output)
		{
			Ensure.That("output").IsNotNull<ControlOutput>(output);
			ControlConnection connection = output.connection;
			if (connection == null)
			{
				return;
			}
			ControlInput destination = connection.destination;
			Flow.RecursionNode recursionNode = new Flow.RecursionNode(output, this.stack);
			this.BeforeInvoke(output, recursionNode);
			try
			{
				ControlOutput controlOutput = this.InvokeDelegate(destination);
				if (controlOutput != null)
				{
					this.Invoke(controlOutput);
				}
			}
			finally
			{
				this.AfterInvoke(output, recursionNode);
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00002DDC File Offset: 0x00000FDC
		private IEnumerable InvokeCoroutine(ControlOutput output)
		{
			ControlConnection connection = output.connection;
			if (connection == null)
			{
				yield break;
			}
			ControlInput destination = connection.destination;
			Flow.RecursionNode recursionNode = new Flow.RecursionNode(output, this.stack);
			this.BeforeInvoke(output, recursionNode);
			if (destination.supportsCoroutine)
			{
				foreach (object obj in this.InvokeCoroutineDelegate(destination))
				{
					if (obj is ControlOutput)
					{
						foreach (object obj2 in this.InvokeCoroutine((ControlOutput)obj))
						{
							yield return obj2;
						}
						IEnumerator enumerator2 = null;
					}
					else
					{
						yield return obj;
					}
				}
				IEnumerator enumerator = null;
			}
			else
			{
				ControlOutput controlOutput = this.InvokeDelegate(destination);
				if (controlOutput != null)
				{
					foreach (object obj3 in this.InvokeCoroutine(controlOutput))
					{
						yield return obj3;
					}
					IEnumerator enumerator = null;
				}
			}
			this.AfterInvoke(output, recursionNode);
			yield break;
			yield break;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00002DF4 File Offset: 0x00000FF4
		private Flow.RecursionNode BeforeInvoke(ControlOutput output, Flow.RecursionNode recursionNode)
		{
			try
			{
				Recursion<Flow.RecursionNode> recursion = this.recursion;
				if (recursion != null)
				{
					recursion.Enter(recursionNode);
				}
			}
			catch (StackOverflowException ex)
			{
				output.unit.HandleException(this.stack, ex);
				throw;
			}
			ControlConnection connection = output.connection;
			ControlInput destination = connection.destination;
			if (this.enableDebug)
			{
				IUnitConnectionDebugData elementDebugData = this.stack.GetElementDebugData<IUnitConnectionDebugData>(connection);
				IUnitDebugData elementDebugData2 = this.stack.GetElementDebugData<IUnitDebugData>(destination.unit);
				elementDebugData.lastInvokeFrame = EditorTimeBinding.frame;
				elementDebugData.lastInvokeTime = EditorTimeBinding.time;
				elementDebugData2.lastInvokeFrame = EditorTimeBinding.frame;
				elementDebugData2.lastInvokeTime = EditorTimeBinding.time;
			}
			return recursionNode;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00002E9C File Offset: 0x0000109C
		private void AfterInvoke(ControlOutput output, Flow.RecursionNode recursionNode)
		{
			Recursion<Flow.RecursionNode> recursion = this.recursion;
			if (recursion == null)
			{
				return;
			}
			recursion.Exit(recursionNode);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00002EB0 File Offset: 0x000010B0
		private ControlOutput InvokeDelegate(ControlInput input)
		{
			ControlOutput result;
			try
			{
				if (input.requiresCoroutine)
				{
					throw new InvalidOperationException(string.Format("Port '{0}' on '{1}' can only be triggered in a coroutine.", input.key, input.unit));
				}
				result = input.action(this);
			}
			catch (Exception ex)
			{
				input.unit.HandleException(this.stack, ex);
				throw;
			}
			return result;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002F18 File Offset: 0x00001118
		private IEnumerable InvokeCoroutineDelegate(ControlInput input)
		{
			IEnumerator instructions = input.coroutineAction(this);
			for (;;)
			{
				object obj;
				try
				{
					if (!instructions.MoveNext())
					{
						yield break;
					}
					obj = instructions.Current;
				}
				catch (Exception ex)
				{
					input.unit.HandleException(this.stack, ex);
					throw;
				}
				yield return obj;
			}
			yield break;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00002F2F File Offset: 0x0000112F
		public bool IsLocal(IUnitValuePort port)
		{
			Ensure.That("port").IsNotNull<IUnitValuePort>(port);
			return this.locals.ContainsKey(port);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00002F50 File Offset: 0x00001150
		public void SetValue(IUnitValuePort port, object value)
		{
			Ensure.That("port").IsNotNull<IUnitValuePort>(port);
			Ensure.That("value").IsOfType<object>(value, port.type);
			if (this.locals.ContainsKey(port))
			{
				this.locals[port] = value;
				return;
			}
			this.locals.Add(port, value);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00002FAC File Offset: 0x000011AC
		public object GetValue(ValueInput input)
		{
			object result;
			if (this.locals.TryGetValue(input, out result))
			{
				return result;
			}
			ValueConnection connection = input.connection;
			if (connection != null)
			{
				if (this.enableDebug)
				{
					IUnitConnectionDebugData elementDebugData = this.stack.GetElementDebugData<IUnitConnectionDebugData>(connection);
					elementDebugData.lastInvokeFrame = EditorTimeBinding.frame;
					elementDebugData.lastInvokeTime = EditorTimeBinding.time;
				}
				ValueOutput source = connection.source;
				object value = this.GetValue(source);
				if (this.enableDebug)
				{
					ValueConnection.DebugData elementDebugData2 = this.stack.GetElementDebugData<ValueConnection.DebugData>(connection);
					elementDebugData2.lastValue = value;
					elementDebugData2.assignedLastValue = true;
				}
				return value;
			}
			object result2;
			if (this.TryGetDefaultValue(input, out result2))
			{
				return result2;
			}
			throw new MissingValuePortInputException(input.key);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000304C File Offset: 0x0000124C
		private object GetValue(ValueOutput output)
		{
			object result;
			if (this.locals.TryGetValue(output, out result))
			{
				return result;
			}
			if (!output.supportsFetch)
			{
				throw new InvalidOperationException(string.Format("The value of '{0}' on '{1}' cannot be fetched dynamically, it must be assigned.", output.key, output.unit));
			}
			Flow.RecursionNode o = new Flow.RecursionNode(output, this.stack);
			try
			{
				Recursion<Flow.RecursionNode> recursion = this.recursion;
				if (recursion != null)
				{
					recursion.Enter(o);
				}
			}
			catch (StackOverflowException ex)
			{
				output.unit.HandleException(this.stack, ex);
				throw;
			}
			object valueDelegate;
			try
			{
				if (this.enableDebug)
				{
					IUnitDebugData elementDebugData = this.stack.GetElementDebugData<IUnitDebugData>(output.unit);
					elementDebugData.lastInvokeFrame = EditorTimeBinding.frame;
					elementDebugData.lastInvokeTime = EditorTimeBinding.time;
				}
				valueDelegate = this.GetValueDelegate(output);
			}
			finally
			{
				Recursion<Flow.RecursionNode> recursion2 = this.recursion;
				if (recursion2 != null)
				{
					recursion2.Exit(o);
				}
			}
			return valueDelegate;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003130 File Offset: 0x00001330
		public object GetValue(ValueInput input, Type type)
		{
			return ConversionUtility.Convert(this.GetValue(input), type);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000313F File Offset: 0x0000133F
		public T GetValue<T>(ValueInput input)
		{
			return (T)((object)this.GetValue(input, typeof(T)));
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003157 File Offset: 0x00001357
		public object GetConvertedValue(ValueInput input)
		{
			return this.GetValue(input, input.type);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003168 File Offset: 0x00001368
		private object GetDefaultValue(ValueInput input)
		{
			object result;
			if (!this.TryGetDefaultValue(input, out result))
			{
				throw new InvalidOperationException("Value input port does not have a default value.");
			}
			return result;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000318C File Offset: 0x0000138C
		public bool TryGetDefaultValue(ValueInput input, out object defaultValue)
		{
			if (!input.unit.defaultValues.TryGetValue(input.key, out defaultValue))
			{
				return false;
			}
			if (input.nullMeansSelf && defaultValue == null)
			{
				defaultValue = this.stack.self;
			}
			return true;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000031C4 File Offset: 0x000013C4
		private object GetValueDelegate(ValueOutput output)
		{
			object result;
			try
			{
				result = output.getValue(this);
			}
			catch (Exception ex)
			{
				output.unit.HandleException(this.stack, ex);
				throw;
			}
			return result;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003208 File Offset: 0x00001408
		public static object FetchValue(ValueInput input, GraphReference reference)
		{
			Flow flow = Flow.New(reference);
			object value = flow.GetValue(input);
			flow.Dispose();
			return value;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003229 File Offset: 0x00001429
		public static object FetchValue(ValueInput input, Type type, GraphReference reference)
		{
			return ConversionUtility.Convert(Flow.FetchValue(input, reference), type);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003238 File Offset: 0x00001438
		public static T FetchValue<T>(ValueInput input, GraphReference reference)
		{
			return (T)((object)Flow.FetchValue(input, typeof(T), reference));
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003250 File Offset: 0x00001450
		public static bool CanPredict(IUnitValuePort port, GraphReference reference)
		{
			Ensure.That("port").IsNotNull<IUnitValuePort>(port);
			Flow flow = Flow.New(reference);
			flow.isPrediction = true;
			bool result;
			if (port is ValueInput)
			{
				result = flow.CanPredict((ValueInput)port);
			}
			else
			{
				if (!(port is ValueOutput))
				{
					throw new NotSupportedException();
				}
				result = flow.CanPredict((ValueOutput)port);
			}
			flow.Dispose();
			return result;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000032B8 File Offset: 0x000014B8
		private bool CanPredict(ValueInput input)
		{
			if (!input.hasValidConnection)
			{
				object obj;
				if (!this.TryGetDefaultValue(input, out obj))
				{
					return false;
				}
				if (typeof(Component).IsAssignableFrom(input.type))
				{
					obj = ((obj != null) ? obj.ConvertTo(input.type) : null);
				}
				return input.allowsNull || obj != null;
			}
			else
			{
				ValueOutput output = input.validConnectedPorts.Single<ValueOutput>();
				if (!this.CanPredict(output))
				{
					return false;
				}
				object obj2 = this.GetValue(output);
				if (!ConversionUtility.CanConvert(obj2, input.type, false))
				{
					return false;
				}
				if (typeof(Component).IsAssignableFrom(input.type))
				{
					obj2 = ((obj2 != null) ? obj2.ConvertTo(input.type) : null);
				}
				return input.allowsNull || obj2 != null;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000337C File Offset: 0x0000157C
		private bool CanPredict(ValueOutput output)
		{
			if (!output.supportsPrediction)
			{
				return false;
			}
			Flow.RecursionNode o = new Flow.RecursionNode(output, this.stack);
			Recursion<Flow.RecursionNode> recursion = this.recursion;
			if (recursion != null && !recursion.TryEnter(o))
			{
				return false;
			}
			foreach (IUnitRelation unitRelation in output.unit.relations.WithDestination(output))
			{
				if (unitRelation.source is ValueInput)
				{
					ValueInput input = (ValueInput)unitRelation.source;
					if (!this.CanPredict(input))
					{
						Recursion<Flow.RecursionNode> recursion2 = this.recursion;
						if (recursion2 != null)
						{
							recursion2.Exit(o);
						}
						return false;
					}
				}
			}
			bool result = this.CanPredictDelegate(output);
			Recursion<Flow.RecursionNode> recursion3 = this.recursion;
			if (recursion3 == null)
			{
				return result;
			}
			recursion3.Exit(o);
			return result;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003454 File Offset: 0x00001654
		private bool CanPredictDelegate(ValueOutput output)
		{
			bool result;
			try
			{
				result = output.canPredictValue(this);
			}
			catch (Exception arg)
			{
				Debug.LogWarning(string.Format("Prediction check failed for '{0}' on '{1}':\n{2}", output.key, output.unit, arg));
				result = false;
			}
			return result;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000034A4 File Offset: 0x000016A4
		public static object Predict(IUnitValuePort port, GraphReference reference)
		{
			Ensure.That("port").IsNotNull<IUnitValuePort>(port);
			Flow flow = Flow.New(reference);
			flow.isPrediction = true;
			object value;
			if (port is ValueInput)
			{
				value = flow.GetValue((ValueInput)port);
			}
			else
			{
				if (!(port is ValueOutput))
				{
					throw new NotSupportedException();
				}
				value = flow.GetValue((ValueOutput)port);
			}
			flow.Dispose();
			return value;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000350A File Offset: 0x0000170A
		public static object Predict(IUnitValuePort port, GraphReference reference, Type type)
		{
			return ConversionUtility.Convert(Flow.Predict(port, reference), type);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003519 File Offset: 0x00001719
		public static T Predict<T>(IUnitValuePort port, GraphReference pointer)
		{
			return (T)((object)Flow.Predict(port, pointer, typeof(T)));
		}

		// Token: 0x04000018 RID: 24
		private Recursion<Flow.RecursionNode> recursion;

		// Token: 0x04000019 RID: 25
		private readonly Dictionary<IUnitValuePort, object> locals = new Dictionary<IUnitValuePort, object>();

		// Token: 0x0400001A RID: 26
		public readonly VariableDeclarations variables = new VariableDeclarations();

		// Token: 0x0400001B RID: 27
		private readonly Stack<int> loops = new Stack<int>();

		// Token: 0x0400001C RID: 28
		private readonly HashSet<GraphStack> preservedStacks = new HashSet<GraphStack>();

		// Token: 0x0400001E RID: 30
		private ICollection<Flow> activeCoroutinesRegistry;

		// Token: 0x0400001F RID: 31
		private bool coroutineStopRequested;

		// Token: 0x04000021 RID: 33
		private IEnumerator coroutineEnumerator;

		// Token: 0x04000023 RID: 35
		private bool disposed;

		// Token: 0x04000025 RID: 37
		public int loopIdentifier = -1;

		// Token: 0x0200019C RID: 412
		private struct RecursionNode : IEquatable<Flow.RecursionNode>
		{
			// Token: 0x170003B6 RID: 950
			// (get) Token: 0x06000B61 RID: 2913 RVA: 0x0001A1FE File Offset: 0x000183FE
			public readonly IUnitPort port { get; }

			// Token: 0x170003B7 RID: 951
			// (get) Token: 0x06000B62 RID: 2914 RVA: 0x0001A206 File Offset: 0x00018406
			public readonly IGraphParent context { get; }

			// Token: 0x06000B63 RID: 2915 RVA: 0x0001A20E File Offset: 0x0001840E
			public RecursionNode(IUnitPort port, GraphPointer pointer)
			{
				this.port = port;
				this.context = pointer.parent;
			}

			// Token: 0x06000B64 RID: 2916 RVA: 0x0001A223 File Offset: 0x00018423
			public bool Equals(Flow.RecursionNode other)
			{
				return other.port == this.port && other.context == this.context;
			}

			// Token: 0x06000B65 RID: 2917 RVA: 0x0001A248 File Offset: 0x00018448
			public override bool Equals(object obj)
			{
				if (obj is Flow.RecursionNode)
				{
					Flow.RecursionNode other = (Flow.RecursionNode)obj;
					return this.Equals(other);
				}
				return false;
			}

			// Token: 0x06000B66 RID: 2918 RVA: 0x0001A26D File Offset: 0x0001846D
			public override int GetHashCode()
			{
				return HashUtility.GetHashCode<IUnitPort, IGraphParent>(this.port, this.context);
			}
		}
	}
}
