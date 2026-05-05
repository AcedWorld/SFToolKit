using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000208 RID: 520
	internal static class HDBakingUtilities
	{
		// Token: 0x06000F72 RID: 3954 RVA: 0x00078646 File Offset: 0x00076846
		public static string HDProbeAssetPattern(ProbeSettings.ProbeType type)
		{
			return string.Format("{0}-*.exr", type);
		}

		// Token: 0x06000F73 RID: 3955 RVA: 0x00078658 File Offset: 0x00076858
		public static string GetBakedTextureDirectory(Scene scene)
		{
			string path = scene.path;
			if (string.IsNullOrEmpty(path))
			{
				return string.Empty;
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
			return Path.Combine(Path.GetDirectoryName(path), fileNameWithoutExtension);
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x0007868E File Offset: 0x0007688E
		public static string GetBakedTextureFilePath(HDProbe probe)
		{
			return HDBakingUtilities.GetBakedTextureFilePath(probe.settings.type, SceneObjectIDMap.GetOrCreateSceneObjectID<HDBakingUtilities.SceneObjectCategory>(probe.gameObject, HDBakingUtilities.SceneObjectCategory.ReflectionProbe), probe.gameObject.scene);
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x000786B8 File Offset: 0x000768B8
		public static bool TryParseBakedProbeAssetFileName(string filename, out ProbeSettings.ProbeType type, out int index)
		{
			Match match = HDBakingUtilities.k_HDProbeAssetRegex.Match(filename);
			if (!match.Success)
			{
				type = ProbeSettings.ProbeType.ReflectionProbe;
				index = 0;
				return false;
			}
			type = (ProbeSettings.ProbeType)Enum.Parse(typeof(ProbeSettings.ProbeType), match.Groups["type"].Value);
			index = int.Parse(match.Groups["index"].Value);
			return true;
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x00078729 File Offset: 0x00076929
		public static string GetBakedTextureFilePath(ProbeSettings.ProbeType probeType, int index, Scene scene)
		{
			return Path.Combine(HDBakingUtilities.GetBakedTextureDirectory(scene), string.Format("{0}-{1}.exr", probeType, index));
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x0007874C File Offset: 0x0007694C
		public static void CreateParentDirectoryIfMissing(string path)
		{
			FileInfo fileInfo = new FileInfo(path);
			if (!fileInfo.Directory.Exists)
			{
				fileInfo.Directory.Create();
			}
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x00078778 File Offset: 0x00076978
		public static bool TrySerializeToDisk<T>(T renderData, string filePath)
		{
			HDBakingUtilities.CreateParentDirectoryIfMissing(filePath);
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(filePath, FileMode.Create);
				xmlSerializer.Serialize(fileStream, renderData);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Dispose();
				}
			}
			return true;
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x000787E8 File Offset: 0x000769E8
		public static bool TryDeserializeFromDisk<T>(string filePath, out T renderData)
		{
			if (!File.Exists(filePath))
			{
				renderData = default(T);
				return false;
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			bool result;
			try
			{
				FileStream stream = new FileStream(filePath, FileMode.Open);
				renderData = (T)((object)xmlSerializer.Deserialize(stream));
				result = true;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				renderData = default(T);
				result = false;
			}
			return result;
		}

		// Token: 0x04001806 RID: 6150
		private const string k_HDProbeAssetFormat = "{0}-{1}.exr";

		// Token: 0x04001807 RID: 6151
		private static readonly Regex k_HDProbeAssetRegex = new Regex("(?<type>ReflectionProbe|PlanarProbe)-(?<index>\\d+)\\.exr");

		// Token: 0x0200043F RID: 1087
		public enum SceneObjectCategory
		{
			// Token: 0x04002982 RID: 10626
			ReflectionProbe
		}
	}
}
