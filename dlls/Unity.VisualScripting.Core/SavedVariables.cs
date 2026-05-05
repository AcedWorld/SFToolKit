using System;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200016E RID: 366
	public static class SavedVariables
	{
		// Token: 0x170001BE RID: 446
		// (get) Token: 0x060009B3 RID: 2483 RVA: 0x00029295 File Offset: 0x00027495
		public static VariablesAsset asset
		{
			get
			{
				if (SavedVariables._asset == null)
				{
					SavedVariables.Load();
				}
				return SavedVariables._asset;
			}
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x000292AE File Offset: 0x000274AE
		public static void Load()
		{
			SavedVariables._asset = (Resources.Load<VariablesAsset>("SavedVariables") ?? ScriptableObject.CreateInstance<VariablesAsset>());
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x000292C8 File Offset: 0x000274C8
		public static void OnEnterEditMode()
		{
			SavedVariables.FetchSavedDeclarations();
			SavedVariables.DestroyMergedDeclarations();
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x000292D4 File Offset: 0x000274D4
		public static void OnExitEditMode()
		{
			SavedVariables.SaveDeclarations(SavedVariables.saved);
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x000292E0 File Offset: 0x000274E0
		internal static void OnEnterPlayMode()
		{
			SavedVariables.FetchSavedDeclarations();
			SavedVariables.MergeInitialAndSavedDeclarations();
			VariableDeclarations merged = SavedVariables.merged;
			merged.OnVariableChanged = (Action)Delegate.Combine(merged.OnVariableChanged, new Action(delegate()
			{
				if (VariablesSaver.instance == null)
				{
					VariablesSaver.Instantiate();
				}
			}));
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x00029330 File Offset: 0x00027530
		internal static void OnExitPlayMode()
		{
			SavedVariables.SaveDeclarations(SavedVariables.merged);
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0002933C File Offset: 0x0002753C
		public static VariableDeclarations initial
		{
			get
			{
				return SavedVariables.asset.declarations;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x00029348 File Offset: 0x00027548
		// (set) Token: 0x060009BB RID: 2491 RVA: 0x0002934F File Offset: 0x0002754F
		public static VariableDeclarations saved { get; private set; }

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060009BC RID: 2492 RVA: 0x00029357 File Offset: 0x00027557
		// (set) Token: 0x060009BD RID: 2493 RVA: 0x0002935E File Offset: 0x0002755E
		public static VariableDeclarations merged { get; private set; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x00029366 File Offset: 0x00027566
		public static VariableDeclarations current
		{
			get
			{
				if (!Application.isPlaying)
				{
					return SavedVariables.initial;
				}
				return SavedVariables.merged;
			}
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0002937C File Offset: 0x0002757C
		public static void SaveDeclarations(VariableDeclarations declarations)
		{
			SavedVariables.WarnAndNullifyUnityObjectReferences(declarations);
			try
			{
				SerializationData serializationData = declarations.Serialize(false);
				if (serializationData.objectReferences.Length != 0)
				{
					throw new InvalidOperationException("Cannot use Unity object variable references in saved variables.");
				}
				PlayerPrefs.SetString("LudiqSavedVariables", serializationData.json);
				PlayerPrefs.Save();
			}
			catch (Exception arg)
			{
				Debug.LogWarning(string.Format("Failed to save variables to player prefs: \n{0}", arg));
			}
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x000293E8 File Offset: 0x000275E8
		public static void FetchSavedDeclarations()
		{
			if (PlayerPrefs.HasKey("LudiqSavedVariables"))
			{
				try
				{
					SavedVariables.saved = (VariableDeclarations)new SerializationData(PlayerPrefs.GetString("LudiqSavedVariables"), Array.Empty<Object>()).Deserialize(false);
					return;
				}
				catch (Exception arg)
				{
					Debug.LogWarning(string.Format("Failed to fetch saved variables from player prefs: \n{0}", arg));
					SavedVariables.saved = new VariableDeclarations();
					return;
				}
			}
			SavedVariables.saved = new VariableDeclarations();
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x00029460 File Offset: 0x00027660
		private static void MergeInitialAndSavedDeclarations()
		{
			SavedVariables.merged = SavedVariables.initial.CloneViaFakeSerialization<VariableDeclarations>();
			SavedVariables.WarnAndNullifyUnityObjectReferences(SavedVariables.merged);
			foreach (string text in from vd in SavedVariables.saved
			select vd.name)
			{
				if (!SavedVariables.merged.IsDefined(text))
				{
					SavedVariables.merged[text] = SavedVariables.saved[text];
				}
				else if (SavedVariables.merged[text] == null)
				{
					if (SavedVariables.saved[text] == null || SavedVariables.saved[text].GetType().IsNullable())
					{
						SavedVariables.merged[text] = SavedVariables.saved[text];
					}
					else
					{
						Debug.LogWarning("Cannot convert saved player pref '" + text + "' to null.\n");
					}
				}
				else if (SavedVariables.saved[text].IsConvertibleTo(SavedVariables.merged[text].GetType(), true))
				{
					SavedVariables.merged[text] = SavedVariables.saved[text];
				}
				else
				{
					Debug.LogWarning(string.Format("Cannot convert saved player pref '{0}' to expected type ({1}).\nReverting to initial value.", text, SavedVariables.merged[text].GetType()));
				}
			}
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x000295CC File Offset: 0x000277CC
		private static void DestroyMergedDeclarations()
		{
			SavedVariables.merged = null;
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x000295D4 File Offset: 0x000277D4
		private static void WarnAndNullifyUnityObjectReferences(VariableDeclarations declarations)
		{
			Ensure.That("declarations").IsNotNull<VariableDeclarations>(declarations);
			foreach (VariableDeclaration variableDeclaration in declarations)
			{
				if (variableDeclaration.value is Object)
				{
					Debug.LogWarning("Saved variable '" + variableDeclaration.name + "' refers to a Unity object. This is not supported. Its value will be null.");
					declarations[variableDeclaration.name] = null;
				}
			}
		}

		// Token: 0x04000245 RID: 581
		public const string assetPath = "SavedVariables";

		// Token: 0x04000246 RID: 582
		public const string playerPrefsKey = "LudiqSavedVariables";

		// Token: 0x04000247 RID: 583
		private static VariablesAsset _asset;
	}
}
