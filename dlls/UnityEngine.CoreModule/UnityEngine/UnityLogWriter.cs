using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x020001E7 RID: 487
	[NativeHeader("Runtime/Export/Logging/UnityLogWriter.bindings.h")]
	internal class UnityLogWriter : TextWriter
	{
		// Token: 0x060014E2 RID: 5346 RVA: 0x0001E8D8 File Offset: 0x0001CAD8
		[ThreadAndSerializationSafe]
		public static void WriteStringToUnityLog(string s)
		{
			bool flag = s == null;
			if (!flag)
			{
				UnityLogWriter.WriteStringToUnityLogImpl(s);
			}
		}

		// Token: 0x060014E3 RID: 5347
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void WriteStringToUnityLogImpl(string s);

		// Token: 0x060014E4 RID: 5348 RVA: 0x0001E8F7 File Offset: 0x0001CAF7
		public static void Init()
		{
			Console.SetOut(new UnityLogWriter());
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x060014E5 RID: 5349 RVA: 0x0001E908 File Offset: 0x0001CB08
		public override Encoding Encoding
		{
			get
			{
				return Encoding.UTF8;
			}
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x0001E91F File Offset: 0x0001CB1F
		public override void Write(char value)
		{
			UnityLogWriter.WriteStringToUnityLog(value.ToString());
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x0001E92F File Offset: 0x0001CB2F
		public override void Write(string s)
		{
			UnityLogWriter.WriteStringToUnityLog(s);
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x0001E939 File Offset: 0x0001CB39
		public override void Write(char[] buffer, int index, int count)
		{
			UnityLogWriter.WriteStringToUnityLogImpl(new string(buffer, index, count));
		}
	}
}
