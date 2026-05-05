using System;
using System.Collections.Generic;
using System.Reflection;

namespace Unity.VisualScripting.FullSerializer.Internal
{
	// Token: 0x020001B3 RID: 435
	public static class fsVersionManager
	{
		// Token: 0x06000B9D RID: 2973 RVA: 0x000312F8 File Offset: 0x0002F4F8
		public static fsResult GetVersionImportPath(string currentVersion, fsVersionedType targetVersion, out List<fsVersionedType> path)
		{
			path = new List<fsVersionedType>();
			if (!fsVersionManager.GetVersionImportPathRecursive(path, currentVersion, targetVersion))
			{
				return fsResult.Fail(string.Concat(new string[]
				{
					"There is no migration path from \"",
					currentVersion,
					"\" to \"",
					targetVersion.VersionString,
					"\""
				}));
			}
			path.Add(targetVersion);
			return fsResult.Success;
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0003135C File Offset: 0x0002F55C
		private static bool GetVersionImportPathRecursive(List<fsVersionedType> path, string currentVersion, fsVersionedType current)
		{
			for (int i = 0; i < current.Ancestors.Length; i++)
			{
				fsVersionedType fsVersionedType = current.Ancestors[i];
				if (fsVersionedType.VersionString == currentVersion || fsVersionManager.GetVersionImportPathRecursive(path, currentVersion, fsVersionedType))
				{
					path.Add(fsVersionedType);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x000313AC File Offset: 0x0002F5AC
		public static fsOption<fsVersionedType> GetVersionedType(Type type)
		{
			fsOption<fsVersionedType> fsOption;
			if (!fsVersionManager._cache.TryGetValue(type, out fsOption))
			{
				fsObjectAttribute attribute = fsPortableReflection.GetAttribute<fsObjectAttribute>(type);
				if (attribute != null && (!string.IsNullOrEmpty(attribute.VersionString) || attribute.PreviousModels != null))
				{
					if (attribute.PreviousModels != null && string.IsNullOrEmpty(attribute.VersionString))
					{
						throw new Exception("fsObject attribute on " + ((type != null) ? type.ToString() : null) + " contains a PreviousModels specifier - it must also include a VersionString modifier");
					}
					fsVersionedType[] array = new fsVersionedType[(attribute.PreviousModels != null) ? attribute.PreviousModels.Length : 0];
					for (int i = 0; i < array.Length; i++)
					{
						fsOption<fsVersionedType> versionedType = fsVersionManager.GetVersionedType(attribute.PreviousModels[i]);
						if (versionedType.IsEmpty)
						{
							throw new Exception("Unable to create versioned type for ancestor " + versionedType.ToString() + "; please add an [fsObject(VersionString=\"...\")] attribute");
						}
						array[i] = versionedType.Value;
					}
					fsVersionedType fsVersionedType = new fsVersionedType
					{
						Ancestors = array,
						VersionString = attribute.VersionString,
						ModelType = type
					};
					fsVersionManager.VerifyUniqueVersionStrings(fsVersionedType);
					fsVersionManager.VerifyConstructors(fsVersionedType);
					fsOption = fsOption.Just<fsVersionedType>(fsVersionedType);
				}
				fsVersionManager._cache[type] = fsOption;
			}
			return fsOption;
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x000314DC File Offset: 0x0002F6DC
		private static void VerifyConstructors(fsVersionedType type)
		{
			ConstructorInfo[] declaredConstructors = type.ModelType.GetDeclaredConstructors();
			for (int i = 0; i < type.Ancestors.Length; i++)
			{
				Type modelType = type.Ancestors[i].ModelType;
				bool flag = false;
				for (int j = 0; j < declaredConstructors.Length; j++)
				{
					ParameterInfo[] parameters = declaredConstructors[j].GetParameters();
					if (parameters.Length == 1 && parameters[0].ParameterType == modelType)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					throw new fsMissingVersionConstructorException(type.ModelType, modelType);
				}
			}
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x00031568 File Offset: 0x0002F768
		private static void VerifyUniqueVersionStrings(fsVersionedType type)
		{
			Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
			Queue<fsVersionedType> queue = new Queue<fsVersionedType>();
			queue.Enqueue(type);
			while (queue.Count > 0)
			{
				fsVersionedType fsVersionedType = queue.Dequeue();
				if (dictionary.ContainsKey(fsVersionedType.VersionString) && dictionary[fsVersionedType.VersionString] != fsVersionedType.ModelType)
				{
					throw new fsDuplicateVersionNameException(dictionary[fsVersionedType.VersionString], fsVersionedType.ModelType, fsVersionedType.VersionString);
				}
				dictionary[fsVersionedType.VersionString] = fsVersionedType.ModelType;
				foreach (fsVersionedType item in fsVersionedType.Ancestors)
				{
					queue.Enqueue(item);
				}
			}
		}

		// Token: 0x040002CF RID: 719
		private static readonly Dictionary<Type, fsOption<fsVersionedType>> _cache = new Dictionary<Type, fsOption<fsVersionedType>>();
	}
}
