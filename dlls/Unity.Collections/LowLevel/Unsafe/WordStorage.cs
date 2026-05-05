using System;
using System.Diagnostics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000E6 RID: 230
	[Obsolete("This storage will no longer be used. (RemovedAfter 2021-06-01)")]
	[DebuggerTypeProxy(typeof(WordStorageDebugView))]
	public struct WordStorage
	{
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000924 RID: 2340 RVA: 0x0001CC00 File Offset: 0x0001AE00
		[NotBurstCompatible]
		public static ref WordStorage Instance
		{
			get
			{
				WordStorage.Initialize();
				return ref WordStorageStatic.Ref.Data;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x0001CC11 File Offset: 0x0001AE11
		public int Entries
		{
			get
			{
				return this.entries;
			}
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0001CC1C File Offset: 0x0001AE1C
		[NotBurstCompatible]
		public static void Initialize()
		{
			if (WordStorageStatic.Ref.Data.buffer.IsCreated)
			{
				return;
			}
			WordStorageStatic.Ref.Data.buffer = new NativeArray<byte>(2097152, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			WordStorageStatic.Ref.Data.entry = new NativeArray<WordStorage.Entry>(16384, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			WordStorageStatic.Ref.Data.hash = new NativeMultiHashMap<int, int>(16384, Allocator.Persistent);
			WordStorage.Clear();
			AppDomain.CurrentDomain.DomainUnload += delegate(object _, EventArgs __)
			{
				WordStorage.Shutdown();
			};
			AppDomain.CurrentDomain.ProcessExit += delegate(object _, EventArgs __)
			{
				WordStorage.Shutdown();
			};
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0001CCEC File Offset: 0x0001AEEC
		[NotBurstCompatible]
		public static void Shutdown()
		{
			if (!WordStorageStatic.Ref.Data.buffer.IsCreated)
			{
				return;
			}
			WordStorageStatic.Ref.Data.buffer.Dispose();
			WordStorageStatic.Ref.Data.entry.Dispose();
			WordStorageStatic.Ref.Data.hash.Dispose();
			WordStorageStatic.Ref.Data = default(WordStorage);
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0001CD5C File Offset: 0x0001AF5C
		[NotBurstCompatible]
		public static void Clear()
		{
			WordStorage.Initialize();
			WordStorageStatic.Ref.Data.chars = 0;
			WordStorageStatic.Ref.Data.entries = 0;
			WordStorageStatic.Ref.Data.hash.Clear();
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			WordStorageStatic.Ref.Data.GetOrCreateIndex<FixedString32Bytes>(ref fixedString32Bytes);
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0001CDBC File Offset: 0x0001AFBC
		[NotBurstCompatible]
		public static void Setup()
		{
			WordStorage.Clear();
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0001CDC4 File Offset: 0x0001AFC4
		public unsafe void GetFixedString<T>(int index, ref T temp) where T : IUTF8Bytes, INativeList<byte>
		{
			WordStorage.Entry entry = this.entry[index];
			temp.Length = entry.length;
			UnsafeUtility.MemCpy((void*)temp.GetUnsafePtr(), (void*)((byte*)this.buffer.GetUnsafePtr<byte>() + entry.offset), (long)temp.Length);
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0001CE20 File Offset: 0x0001B020
		public int GetIndexFromHashAndFixedString<T>(int h, ref T temp) where T : IUTF8Bytes, INativeList<byte>
		{
			int num;
			NativeMultiHashMapIterator<int> nativeMultiHashMapIterator;
			if (this.hash.TryGetFirstValue(h, out num, out nativeMultiHashMapIterator))
			{
				for (;;)
				{
					WordStorage.Entry entry = this.entry[num];
					if (entry.length == temp.Length)
					{
						int num2 = 0;
						while (num2 < entry.length && temp[num2] == this.buffer[entry.offset + num2])
						{
							num2++;
						}
						if (num2 == temp.Length)
						{
							break;
						}
					}
					if (!this.hash.TryGetNextValue(out num, ref nativeMultiHashMapIterator))
					{
						return -1;
					}
				}
				return num;
			}
			return -1;
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0001CEB8 File Offset: 0x0001B0B8
		public bool Contains<T>(ref T value) where T : IUTF8Bytes, INativeList<byte>
		{
			int hashCode = value.GetHashCode();
			return this.GetIndexFromHashAndFixedString<T>(hashCode, ref value) != -1;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0001CEE0 File Offset: 0x0001B0E0
		[NotBurstCompatible]
		public bool Contains(string value)
		{
			FixedString512Bytes fixedString512Bytes = value;
			return this.Contains<FixedString512Bytes>(ref fixedString512Bytes);
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0001CEFC File Offset: 0x0001B0FC
		public int GetOrCreateIndex<T>(ref T value) where T : IUTF8Bytes, INativeList<byte>
		{
			int hashCode = value.GetHashCode();
			int indexFromHashAndFixedString = this.GetIndexFromHashAndFixedString<T>(hashCode, ref value);
			if (indexFromHashAndFixedString != -1)
			{
				return indexFromHashAndFixedString;
			}
			int offset = this.chars;
			ushort num = (ushort)value.Length;
			int num2;
			for (int i = 0; i < (int)num; i++)
			{
				num2 = this.chars;
				this.chars = num2 + 1;
				this.buffer[num2] = value[i];
			}
			this.entry[this.entries] = new WordStorage.Entry
			{
				offset = offset,
				length = (int)num
			};
			this.hash.Add(hashCode, this.entries);
			num2 = this.entries;
			this.entries = num2 + 1;
			return num2;
		}

		// Token: 0x04000328 RID: 808
		private NativeArray<byte> buffer;

		// Token: 0x04000329 RID: 809
		private NativeArray<WordStorage.Entry> entry;

		// Token: 0x0400032A RID: 810
		private NativeMultiHashMap<int, int> hash;

		// Token: 0x0400032B RID: 811
		private int chars;

		// Token: 0x0400032C RID: 812
		private int entries;

		// Token: 0x0400032D RID: 813
		private const int kMaxEntries = 16384;

		// Token: 0x0400032E RID: 814
		private const int kMaxChars = 2097152;

		// Token: 0x0400032F RID: 815
		public const int kMaxCharsPerEntry = 4096;

		// Token: 0x020000E7 RID: 231
		private struct Entry
		{
			// Token: 0x04000330 RID: 816
			public int offset;

			// Token: 0x04000331 RID: 817
			public int length;
		}
	}
}
