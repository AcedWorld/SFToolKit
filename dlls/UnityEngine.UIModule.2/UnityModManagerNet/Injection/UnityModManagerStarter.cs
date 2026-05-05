using System;
using System.IO;
using System.Reflection;

namespace UnityModManagerNet.Injection
{
	// Token: 0x0200000E RID: 14
	public class UnityModManagerStarter
	{
		// Token: 0x0600009D RID: 157 RVA: 0x00002B50 File Offset: 0x00000D50
		public static void Start()
		{
			try
			{
				string text = Path.Combine(Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath), "UnityModManager"), "UnityModManager.dll");
				Console.WriteLine("[Assembly] Loading UnityModManager by " + text);
				Assembly.LoadFrom(text).GetType("UnityModManagerNet.Injector").GetMethod("Run", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[]
				{
					false
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}
