using System;
using System.Diagnostics;
using Unity.Burst.LowLevel;
using Unity.Jobs.LowLevel.Unsafe;

namespace Unity.Burst
{
	// Token: 0x02000010 RID: 16
	public static class BurstRuntime
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00002EAB File Offset: 0x000010AB
		public static int GetHashCode32<T>()
		{
			return BurstRuntime.HashCode32<T>.Value;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002EB2 File Offset: 0x000010B2
		public static int GetHashCode32(Type type)
		{
			return BurstRuntime.HashStringWithFNV1A32(type.AssemblyQualifiedName);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002EBF File Offset: 0x000010BF
		public static long GetHashCode64<T>()
		{
			return BurstRuntime.HashCode64<T>.Value;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002EC6 File Offset: 0x000010C6
		public static long GetHashCode64(Type type)
		{
			return BurstRuntime.HashStringWithFNV1A64(type.AssemblyQualifiedName);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002ED4 File Offset: 0x000010D4
		internal static int HashStringWithFNV1A32(string text)
		{
			uint num = 2166136261U;
			foreach (char c in text)
			{
				num = 16777619U * (num ^ (uint)((byte)(c & 'ÿ')));
				num = 16777619U * (num ^ (uint)((byte)(c >> 8)));
			}
			return (int)num;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002F24 File Offset: 0x00001124
		internal static long HashStringWithFNV1A64(string text)
		{
			ulong num = 14695981039346656037UL;
			foreach (char c in text)
			{
				num = 1099511628211UL * (num ^ (ulong)((byte)(c & 'ÿ')));
				num = 1099511628211UL * (num ^ (ulong)((byte)(c >> 8)));
			}
			return (long)num;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002F7F File Offset: 0x0000117F
		public static bool LoadAdditionalLibrary(string pathToLibBurstGenerated)
		{
			return BurstCompiler.IsLoadAdditionalLibrarySupported() && BurstRuntime.LoadAdditionalLibraryInternal(pathToLibBurstGenerated);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002F90 File Offset: 0x00001190
		internal static bool LoadAdditionalLibraryInternal(string pathToLibBurstGenerated)
		{
			return (bool)typeof(BurstCompilerService).GetMethod("LoadBurstLibrary").Invoke(null, new object[]
			{
				pathToLibBurstGenerated
			});
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002FBB File Offset: 0x000011BB
		[BurstRuntime.PreserveAttribute]
		internal unsafe static void RuntimeLog(byte* message, int logType, byte* fileName, int lineNumber)
		{
			BurstCompilerService.RuntimeLog(null, (BurstCompilerService.BurstLogType)logType, message, fileName, lineNumber);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002FC8 File Offset: 0x000011C8
		internal static void Initialize()
		{
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002FCA File Offset: 0x000011CA
		[BurstRuntime.PreserveAttribute]
		internal static void PreventRequiredAttributeStrip()
		{
			new BurstDiscardAttribute();
			new ConditionalAttribute("HEJSA");
			new JobProducerTypeAttribute(typeof(BurstRuntime));
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002FED File Offset: 0x000011ED
		[BurstRuntime.PreserveAttribute]
		internal unsafe static void Log(byte* message, int logType, byte* fileName, int lineNumber)
		{
			BurstCompilerService.Log(null, (BurstCompilerService.BurstLogType)logType, message, null, lineNumber);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002FFB File Offset: 0x000011FB
		public unsafe static byte* GetUTF8LiteralPointer(string str, out int byteCount)
		{
			throw new NotImplementedException("This function only works from Burst");
		}

		// Token: 0x02000030 RID: 48
		private struct HashCode32<T>
		{
			// Token: 0x0400024B RID: 587
			public static readonly int Value = BurstRuntime.HashStringWithFNV1A32(typeof(T).AssemblyQualifiedName);
		}

		// Token: 0x02000031 RID: 49
		private struct HashCode64<T>
		{
			// Token: 0x0400024C RID: 588
			public static readonly long Value = BurstRuntime.HashStringWithFNV1A64(typeof(T).AssemblyQualifiedName);
		}

		// Token: 0x02000032 RID: 50
		internal class PreserveAttribute : Attribute
		{
		}
	}
}
