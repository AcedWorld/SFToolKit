using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000172 RID: 370
	[SerializationVersion("A", new Type[]
	{

	})]
	public sealed class VariableDeclarations : IEnumerable<VariableDeclaration>, IEnumerable, ISpecifiesCloner
	{
		// Token: 0x060009DA RID: 2522 RVA: 0x00029775 File Offset: 0x00027975
		public VariableDeclarations()
		{
			this.collection = new VariableDeclarationCollection();
		}

		// Token: 0x170001C7 RID: 455
		public object this[[InspectorVariableName(ActionDirection.Any)] string variable]
		{
			get
			{
				return this.Get(variable);
			}
			set
			{
				this.Set(variable, value);
			}
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0002979C File Offset: 0x0002799C
		public void Set([InspectorVariableName(ActionDirection.Set)] string variable, object value)
		{
			if (string.IsNullOrEmpty(variable))
			{
				return;
			}
			VariableDeclaration variableDeclaration;
			if (this.collection.TryGetValue(variable, out variableDeclaration))
			{
				if (variableDeclaration.value != value)
				{
					variableDeclaration.value = value;
					Action onVariableChanged = this.OnVariableChanged;
					if (onVariableChanged == null)
					{
						return;
					}
					onVariableChanged();
					return;
				}
			}
			else
			{
				this.collection.Add(new VariableDeclaration(variable, value));
				Action onVariableChanged2 = this.OnVariableChanged;
				if (onVariableChanged2 == null)
				{
					return;
				}
				onVariableChanged2();
			}
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00029808 File Offset: 0x00027A08
		public object Get([InspectorVariableName(ActionDirection.Get)] string variable)
		{
			if (string.IsNullOrEmpty(variable))
			{
				throw new ArgumentException("No variable name specified.", "variable");
			}
			VariableDeclaration variableDeclaration;
			if (this.collection.TryGetValue(variable, out variableDeclaration))
			{
				return variableDeclaration.value;
			}
			throw new InvalidOperationException("Variable not found: '" + variable + "'.");
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x00029859 File Offset: 0x00027A59
		public T Get<T>([InspectorVariableName(ActionDirection.Get)] string variable)
		{
			return (T)((object)this.Get(variable, typeof(T)));
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00029871 File Offset: 0x00027A71
		public object Get([InspectorVariableName(ActionDirection.Get)] string variable, Type expectedType)
		{
			return ConversionUtility.Convert(this.Get(variable), expectedType);
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x00029880 File Offset: 0x00027A80
		public void Clear()
		{
			this.collection.Clear();
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x0002988D File Offset: 0x00027A8D
		public bool IsDefined([InspectorVariableName(ActionDirection.Any)] string variable)
		{
			if (string.IsNullOrEmpty(variable))
			{
				throw new ArgumentException("No variable name specified.", "variable");
			}
			return this.collection.Contains(variable);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x000298B4 File Offset: 0x00027AB4
		public VariableDeclaration GetDeclaration(string variable)
		{
			VariableDeclaration result;
			if (this.collection.TryGetValue(variable, out result))
			{
				return result;
			}
			throw new InvalidOperationException("Variable not found: '" + variable + "'.");
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x000298E8 File Offset: 0x00027AE8
		public IEnumerator<VariableDeclaration> GetEnumerator()
		{
			return this.collection.GetEnumerator();
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x000298F5 File Offset: 0x00027AF5
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.collection).GetEnumerator();
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x00029902 File Offset: 0x00027B02
		ICloner ISpecifiesCloner.cloner
		{
			get
			{
				return VariableDeclarationsCloner.instance;
			}
		}

		// Token: 0x0400024E RID: 590
		public VariableKind Kind;

		// Token: 0x0400024F RID: 591
		[Serialize]
		[InspectorWide(true)]
		private VariableDeclarationCollection collection;

		// Token: 0x04000250 RID: 592
		internal Action OnVariableChanged;
	}
}
