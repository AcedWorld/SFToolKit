using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001BF RID: 447
	public class ScalableSettingSchema
	{
		// Token: 0x06000DB2 RID: 3506 RVA: 0x0006EFAC File Offset: 0x0006D1AC
		internal static ScalableSettingSchema GetSchemaOrNull(ScalableSettingSchemaId id)
		{
			ScalableSettingSchema result;
			if (!ScalableSettingSchema.Schemas.TryGetValue(id, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x0006EFCC File Offset: 0x0006D1CC
		internal static ScalableSettingSchema GetSchemaOrNull(ScalableSettingSchemaId? id)
		{
			ScalableSettingSchema result;
			if (id == null || !ScalableSettingSchema.Schemas.TryGetValue(id.Value, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x0006EFFA File Offset: 0x0006D1FA
		public int levelCount
		{
			get
			{
				return this.levelNames.Length;
			}
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x0006F004 File Offset: 0x0006D204
		public ScalableSettingSchema(GUIContent[] levelNames)
		{
			this.levelNames = levelNames;
		}

		// Token: 0x04001592 RID: 5522
		internal static readonly Dictionary<ScalableSettingSchemaId, ScalableSettingSchema> Schemas = new Dictionary<ScalableSettingSchemaId, ScalableSettingSchema>
		{
			{
				ScalableSettingSchemaId.With3Levels,
				new ScalableSettingSchema(new GUIContent[]
				{
					new GUIContent("Low"),
					new GUIContent("Medium"),
					new GUIContent("High")
				})
			},
			{
				ScalableSettingSchemaId.With4Levels,
				new ScalableSettingSchema(new GUIContent[]
				{
					new GUIContent("Low"),
					new GUIContent("Medium"),
					new GUIContent("High"),
					new GUIContent("Ultra")
				})
			}
		};

		// Token: 0x04001593 RID: 5523
		public readonly GUIContent[] levelNames;
	}
}
