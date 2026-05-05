using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x02000176 RID: 374
	[AddComponentMenu("Visual Scripting/Variables")]
	[DisableAnnotation]
	[IncludeInSettings(false)]
	public class Variables : LudiqBehaviour, IAotStubbable
	{
		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060009EE RID: 2542 RVA: 0x000299AB File Offset: 0x00027BAB
		// (set) Token: 0x060009EF RID: 2543 RVA: 0x000299B3 File Offset: 0x00027BB3
		[Serialize]
		[Inspectable]
		public VariableDeclarations declarations { get; internal set; } = new VariableDeclarations
		{
			Kind = VariableKind.Object
		};

		// Token: 0x060009F0 RID: 2544 RVA: 0x000299BC File Offset: 0x00027BBC
		public static VariableDeclarations Graph(GraphPointer pointer)
		{
			Ensure.That("pointer").IsNotNull<GraphPointer>(pointer);
			if (pointer.hasData)
			{
				return Variables.GraphInstance(pointer);
			}
			return Variables.GraphDefinition(pointer);
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x000299E3 File Offset: 0x00027BE3
		public static VariableDeclarations GraphInstance(GraphPointer pointer)
		{
			return pointer.GetGraphData<IGraphDataWithVariables>().variables;
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x000299F0 File Offset: 0x00027BF0
		public static VariableDeclarations GraphDefinition(GraphPointer pointer)
		{
			return Variables.GraphDefinition((IGraphWithVariables)pointer.graph);
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x00029A02 File Offset: 0x00027C02
		public static VariableDeclarations GraphDefinition(IGraphWithVariables graph)
		{
			return graph.variables;
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x00029A0A File Offset: 0x00027C0A
		public static VariableDeclarations Object(GameObject go)
		{
			return go.GetOrAddComponent<Variables>().declarations;
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00029A17 File Offset: 0x00027C17
		public static VariableDeclarations Object(Component component)
		{
			return Variables.Object(component.gameObject);
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00029A24 File Offset: 0x00027C24
		public static VariableDeclarations Scene(Scene? scene)
		{
			return SceneVariables.For(scene);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00029A2C File Offset: 0x00027C2C
		public static VariableDeclarations Scene(GameObject go)
		{
			return Variables.Scene(new Scene?(go.scene));
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00029A3E File Offset: 0x00027C3E
		public static VariableDeclarations Scene(Component component)
		{
			return Variables.Scene(component.gameObject);
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060009F9 RID: 2553 RVA: 0x00029A4B File Offset: 0x00027C4B
		public static VariableDeclarations ActiveScene
		{
			get
			{
				return Variables.Scene(new Scene?(SceneManager.GetActiveScene()));
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x00029A5C File Offset: 0x00027C5C
		public static VariableDeclarations Application
		{
			get
			{
				return ApplicationVariables.current;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x00029A63 File Offset: 0x00027C63
		public static VariableDeclarations Saved
		{
			get
			{
				return SavedVariables.current;
			}
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00029A6A File Offset: 0x00027C6A
		public static bool ExistOnObject(GameObject go)
		{
			return go.GetComponent<Variables>() != null;
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00029A78 File Offset: 0x00027C78
		public static bool ExistOnObject(Component component)
		{
			return Variables.ExistOnObject(component.gameObject);
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x00029A85 File Offset: 0x00027C85
		public static bool ExistInScene(Scene? scene)
		{
			return scene != null && SceneVariables.InstantiatedIn(scene.Value);
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x00029A9E File Offset: 0x00027C9E
		public static bool ExistInActiveScene
		{
			get
			{
				return Variables.ExistInScene(new Scene?(SceneManager.GetActiveScene()));
			}
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00029AAF File Offset: 0x00027CAF
		[ContextMenu("Show Data...")]
		protected override void ShowData()
		{
			base.ShowData();
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x00029AB7 File Offset: 0x00027CB7
		public IEnumerable<object> GetAotStubs(HashSet<object> visited)
		{
			foreach (VariableDeclaration variableDeclaration in this.declarations)
			{
				object value = variableDeclaration.value;
				ConstructorInfo constructorInfo = (value != null) ? value.GetType().GetPublicDefaultConstructor() : null;
				if (constructorInfo != null)
				{
					yield return constructorInfo;
				}
			}
			IEnumerator<VariableDeclaration> enumerator = null;
			yield break;
			yield break;
		}
	}
}
