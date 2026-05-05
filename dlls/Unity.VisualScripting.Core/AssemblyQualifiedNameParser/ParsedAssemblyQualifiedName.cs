using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unity.VisualScripting.AssemblyQualifiedNameParser
{
	// Token: 0x020001B5 RID: 437
	public class ParsedAssemblyQualifiedName
	{
		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x000316A4 File Offset: 0x0002F8A4
		public string AssemblyDescriptionString { get; }

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x000316AC File Offset: 0x0002F8AC
		// (set) Token: 0x06000BAA RID: 2986 RVA: 0x000316B4 File Offset: 0x0002F8B4
		public string TypeName { get; private set; }

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x000316BD File Offset: 0x0002F8BD
		public string ShortAssemblyName { get; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x000316C5 File Offset: 0x0002F8C5
		public string Version { get; }

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x000316CD File Offset: 0x0002F8CD
		public string Culture { get; }

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000BAE RID: 2990 RVA: 0x000316D5 File Offset: 0x0002F8D5
		public string PublicKeyToken { get; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x000316DD File Offset: 0x0002F8DD
		public List<ParsedAssemblyQualifiedName> GenericParameters { get; } = new List<ParsedAssemblyQualifiedName>();

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x000316E5 File Offset: 0x0002F8E5
		public int GenericParameterCount { get; }

		// Token: 0x06000BB1 RID: 2993 RVA: 0x000316F0 File Offset: 0x0002F8F0
		public ParsedAssemblyQualifiedName(string AssemblyQualifiedName)
		{
			int num = AssemblyQualifiedName.Length;
			bool flag = false;
			ParsedAssemblyQualifiedName.Block block = new ParsedAssemblyQualifiedName.Block();
			int num2 = 0;
			ParsedAssemblyQualifiedName.Block block2 = block;
			for (int i = 0; i < AssemblyQualifiedName.Length; i++)
			{
				char c = AssemblyQualifiedName[i];
				if (c == '[')
				{
					if (AssemblyQualifiedName[i + 1] == ']')
					{
						i++;
					}
					else
					{
						if (num2 == 0)
						{
							num = i;
						}
						num2++;
						ParsedAssemblyQualifiedName.Block block3 = new ParsedAssemblyQualifiedName.Block
						{
							startIndex = i + 1,
							level = num2,
							parentBlock = block2
						};
						block2.innerBlocks.Add(block3);
						block2 = block3;
					}
				}
				else if (c == ']')
				{
					block2.endIndex = i - 1;
					if (AssemblyQualifiedName[block2.startIndex] != '[')
					{
						block2.parsedAssemblyQualifiedName = new ParsedAssemblyQualifiedName(AssemblyQualifiedName.Substring(block2.startIndex, i - block2.startIndex));
						if (num2 == 2)
						{
							this.GenericParameters.Add(block2.parsedAssemblyQualifiedName);
						}
					}
					block2 = block2.parentBlock;
					num2--;
				}
				else if (num2 == 0 && c == ',')
				{
					num = i;
					flag = true;
					break;
				}
			}
			this.TypeName = AssemblyQualifiedName.Substring(0, num);
			int num3 = this.TypeName.IndexOf('`');
			if (num3 >= 0)
			{
				this.TypeName = this.TypeName.Substring(0, num3);
				this.GenericParameterCount = this.GenericParameters.Count;
			}
			if (flag)
			{
				this.AssemblyDescriptionString = AssemblyQualifiedName.Substring(num + 2);
				List<string> list = (from x in this.AssemblyDescriptionString.Split(',', StringSplitOptions.None)
				select x.Trim()).ToList<string>();
				this.Version = ParsedAssemblyQualifiedName.LookForPairThenRemove(list, "Version");
				this.Culture = ParsedAssemblyQualifiedName.LookForPairThenRemove(list, "Culture");
				this.PublicKeyToken = ParsedAssemblyQualifiedName.LookForPairThenRemove(list, "PublicKeyToken");
				if (list.Count > 0)
				{
					this.ShortAssemblyName = list[0];
				}
			}
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x000318FC File Offset: 0x0002FAFC
		private static string LookForPairThenRemove(List<string> strings, string Name)
		{
			for (int i = 0; i < strings.Count; i++)
			{
				string text = strings[i];
				if (text.IndexOf(Name) == 0)
				{
					int num = text.IndexOf('=');
					if (num > 0)
					{
						string result = text.Substring(num + 1);
						strings.RemoveAt(i);
						return result;
					}
				}
			}
			return null;
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0003194C File Offset: 0x0002FB4C
		public void Replace(string oldTypeName, string newTypeName)
		{
			if (this.TypeName == oldTypeName)
			{
				this.TypeName = newTypeName;
			}
			foreach (ParsedAssemblyQualifiedName parsedAssemblyQualifiedName in this.GenericParameters)
			{
				parsedAssemblyQualifiedName.Replace(oldTypeName, newTypeName);
			}
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x000319B4 File Offset: 0x0002FBB4
		private string ToString(bool includeAssemblyDescription)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.TypeName);
			if (this.GenericParameters.Count > 0)
			{
				stringBuilder.Append("`");
				stringBuilder.Append(this.GenericParameterCount);
				stringBuilder.Append("[[");
				foreach (ParsedAssemblyQualifiedName parsedAssemblyQualifiedName in this.GenericParameters)
				{
					stringBuilder.Append(parsedAssemblyQualifiedName.ToString(true));
				}
				stringBuilder.Append("]]");
			}
			if (includeAssemblyDescription)
			{
				stringBuilder.Append(", ");
				stringBuilder.Append(this.AssemblyDescriptionString);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x00031A84 File Offset: 0x0002FC84
		public override string ToString()
		{
			return this.ToString(false);
		}

		// Token: 0x02000229 RID: 553
		private class Block
		{
			// Token: 0x040009F2 RID: 2546
			internal int startIndex;

			// Token: 0x040009F3 RID: 2547
			internal int endIndex;

			// Token: 0x040009F4 RID: 2548
			internal int level;

			// Token: 0x040009F5 RID: 2549
			internal ParsedAssemblyQualifiedName.Block parentBlock;

			// Token: 0x040009F6 RID: 2550
			internal readonly List<ParsedAssemblyQualifiedName.Block> innerBlocks = new List<ParsedAssemblyQualifiedName.Block>();

			// Token: 0x040009F7 RID: 2551
			internal ParsedAssemblyQualifiedName parsedAssemblyQualifiedName;
		}
	}
}
