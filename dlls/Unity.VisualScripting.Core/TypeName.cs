using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Unity.VisualScripting
{
	// Token: 0x0200012A RID: 298
	public class TypeName
	{
		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x00023D46 File Offset: 0x00021F46
		// (set) Token: 0x06000802 RID: 2050 RVA: 0x00023D4E File Offset: 0x00021F4E
		public string AssemblyDescription { get; private set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x00023D57 File Offset: 0x00021F57
		// (set) Token: 0x06000804 RID: 2052 RVA: 0x00023D5F File Offset: 0x00021F5F
		public string AssemblyName { get; private set; }

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x00023D68 File Offset: 0x00021F68
		// (set) Token: 0x06000806 RID: 2054 RVA: 0x00023D70 File Offset: 0x00021F70
		public string AssemblyVersion { get; private set; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000807 RID: 2055 RVA: 0x00023D79 File Offset: 0x00021F79
		// (set) Token: 0x06000808 RID: 2056 RVA: 0x00023D81 File Offset: 0x00021F81
		public string AssemblyCulture { get; private set; }

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x00023D8A File Offset: 0x00021F8A
		// (set) Token: 0x0600080A RID: 2058 RVA: 0x00023D92 File Offset: 0x00021F92
		public string AssemblyPublicKeyToken { get; private set; }

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x00023D9B File Offset: 0x00021F9B
		public List<TypeName> GenericParameters { get; } = new List<TypeName>();

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x00023DA3 File Offset: 0x00021FA3
		// (set) Token: 0x0600080D RID: 2061 RVA: 0x00023DAB File Offset: 0x00021FAB
		public string Name { get; private set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x00023DB4 File Offset: 0x00021FB4
		public bool IsArray
		{
			get
			{
				return this.Name.EndsWith("[]");
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x00023DC6 File Offset: 0x00021FC6
		public string LastName
		{
			get
			{
				return this.names[this.names.Count - 1];
			}
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00023DE0 File Offset: 0x00021FE0
		public static TypeName Parse(string s)
		{
			int num = 0;
			return new TypeName(s, ref num);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00023DF8 File Offset: 0x00021FF8
		private TypeName(string s, ref int index)
		{
			try
			{
				int num = index;
				int num2 = num;
				int? num3 = null;
				int? num4 = null;
				int? num5 = null;
				bool flag = false;
				TypeName.ParseState parseState = TypeName.ParseState.Name;
				while (index < s.Length)
				{
					char c = s[index];
					char? c2 = (index + 1 < s.Length) ? new char?(s[index + 1]) : null;
					if (parseState == TypeName.ParseState.Name)
					{
						if (c == '[')
						{
							if (index == num)
							{
								flag = true;
								num2++;
							}
							else
							{
								char? c3 = c2;
								int? num6 = (c3 != null) ? new int?((int)c3.GetValueOrDefault()) : null;
								int i = 93;
								if (!(num6.GetValueOrDefault() == i & num6 != null))
								{
									c3 = c2;
									num6 = ((c3 != null) ? new int?((int)c3.GetValueOrDefault()) : null);
									i = 44;
									if (!(num6.GetValueOrDefault() == i & num6 != null))
									{
										num3 = new int?(index);
										parseState = TypeName.ParseState.Generics;
										goto IL_1D0;
									}
								}
								parseState = TypeName.ParseState.Array;
							}
						}
						else if (c == ']')
						{
							if (flag)
							{
								break;
							}
						}
						else if (c == ',')
						{
							parseState = TypeName.ParseState.Assembly;
							num4 = new int?(index + 1);
							if (num3 == null)
							{
								num3 = new int?(index);
							}
						}
					}
					else if (parseState == TypeName.ParseState.Array)
					{
						if (c == ']')
						{
							parseState = TypeName.ParseState.Name;
						}
					}
					else if (parseState == TypeName.ParseState.Generics)
					{
						if (c == ']')
						{
							parseState = TypeName.ParseState.Name;
						}
						else if (c != ',' && c != ' ')
						{
							this.GenericParameters.Add(new TypeName(s, ref index));
						}
					}
					else if (parseState == TypeName.ParseState.Assembly && c == ']' && flag)
					{
						num5 = new int?(index);
						break;
					}
					IL_1D0:
					index++;
				}
				if (num3 == null)
				{
					num3 = new int?(s.Length);
				}
				if (num5 == null)
				{
					num5 = new int?(s.Length);
				}
				this.Name = s.Substring(num2, num3.Value - num2);
				if (this.Name.Contains('+'))
				{
					string[] array = this.Name.Split('+', StringSplitOptions.None);
					for (int i = 0; i < array.Length; i++)
					{
						string item;
						string text;
						array[i].PartsAround('`', out item, out text);
						this.names.Add(item);
						if (text != null)
						{
							this.genericarities.Add(int.Parse(text));
						}
						else
						{
							this.genericarities.Add(0);
						}
					}
				}
				else
				{
					string item2;
					string text2;
					this.Name.PartsAround('`', out item2, out text2);
					this.names.Add(item2);
					if (text2 != null)
					{
						this.genericarities.Add(int.Parse(text2));
					}
					else
					{
						this.genericarities.Add(0);
					}
				}
				if (num4 != null)
				{
					this.AssemblyDescription = s.Substring(num4.Value, num5.Value - num4.Value);
					List<string> list = (from x in this.AssemblyDescription.Split(',', StringSplitOptions.None)
					select x.Trim()).ToList<string>();
					this.AssemblyVersion = TypeName.LookForPairThenRemove(list, "Version");
					this.AssemblyCulture = TypeName.LookForPairThenRemove(list, "Culture");
					this.AssemblyPublicKeyToken = TypeName.LookForPairThenRemove(list, "PublicKeyToken");
					if (list.Count > 0)
					{
						this.AssemblyName = list[0];
					}
				}
			}
			catch (Exception innerException)
			{
				throw new FormatException("Failed to parse type name: " + s, innerException);
			}
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x000241CC File Offset: 0x000223CC
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

		// Token: 0x06000813 RID: 2067 RVA: 0x0002421C File Offset: 0x0002241C
		public void ReplaceNamespace(string oldNamespace, string newNamespace)
		{
			if (this.names[0].StartsWith(oldNamespace + "."))
			{
				this.names[0] = newNamespace + "." + this.names[0].TrimStart(oldNamespace + ".");
			}
			foreach (TypeName typeName in this.GenericParameters)
			{
				typeName.ReplaceNamespace(oldNamespace, newNamespace);
			}
			this.UpdateName();
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x000242C8 File Offset: 0x000224C8
		public void ReplaceAssembly(string oldAssembly, string newAssembly)
		{
			if (this.AssemblyName != null && this.AssemblyName.StartsWith(oldAssembly))
			{
				this.AssemblyName = newAssembly + this.AssemblyName.TrimStart(oldAssembly);
			}
			foreach (TypeName typeName in this.GenericParameters)
			{
				typeName.ReplaceAssembly(oldAssembly, newAssembly);
			}
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00024348 File Offset: 0x00022548
		public void ReplaceName(string oldTypeName, Type newType)
		{
			string fullName = newType.FullName;
			Assembly assembly = newType.Assembly;
			this.ReplaceName(oldTypeName, fullName, (assembly != null) ? assembly.GetName() : null);
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0002436C File Offset: 0x0002256C
		public void ReplaceName(string oldTypeName, string newTypeName, AssemblyName newAssemblyName = null)
		{
			for (int i = 0; i < this.names.Count; i++)
			{
				if (TypeName.ToElementTypeName(this.names[i]) == oldTypeName)
				{
					this.names[i] = TypeName.ToArrayOrType(this.names[i], newTypeName);
					if (newAssemblyName != null)
					{
						this.SetAssemblyName(newAssemblyName);
					}
				}
			}
			foreach (TypeName typeName in this.GenericParameters)
			{
				typeName.ReplaceName(oldTypeName, newTypeName, newAssemblyName);
			}
			this.UpdateName();
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0002441C File Offset: 0x0002261C
		private static string ToElementTypeName(string s)
		{
			if (!s.EndsWith("[]"))
			{
				return s;
			}
			return s.Replace("[]", string.Empty);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0002443D File Offset: 0x0002263D
		private static string ToArrayOrType(string oldType, string newType)
		{
			if (oldType.EndsWith("[]"))
			{
				newType += "[]";
			}
			return newType;
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0002445C File Offset: 0x0002265C
		public void SetAssemblyName(AssemblyName newAssemblyName)
		{
			this.AssemblyDescription = newAssemblyName.ToString();
			this.AssemblyName = newAssemblyName.Name;
			this.AssemblyCulture = newAssemblyName.CultureName;
			this.AssemblyVersion = newAssemblyName.Version.ToString();
			byte[] publicKeyToken = newAssemblyName.GetPublicKeyToken();
			this.AssemblyPublicKeyToken = (((publicKeyToken != null) ? publicKeyToken.ToHexString() : null) ?? "null");
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x000244C0 File Offset: 0x000226C0
		private void UpdateName()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < this.names.Count; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append('+');
				}
				stringBuilder.Append(this.names[i]);
				if (this.genericarities[i] > 0)
				{
					stringBuilder.Append('`');
					stringBuilder.Append(this.genericarities[i]);
				}
			}
			this.Name = stringBuilder.ToString();
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x00024540 File Offset: 0x00022740
		public string ToString(TypeNameDetail specification, TypeNameDetail genericsSpecification)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.Name);
			if (this.GenericParameters.Count > 0)
			{
				stringBuilder.Append("[");
				bool flag = true;
				foreach (TypeName typeName in this.GenericParameters)
				{
					if (!flag)
					{
						stringBuilder.Append(",");
					}
					if (genericsSpecification != TypeNameDetail.Name)
					{
						stringBuilder.Append("[");
					}
					stringBuilder.Append(typeName.ToString(genericsSpecification, genericsSpecification));
					if (genericsSpecification != TypeNameDetail.Name)
					{
						stringBuilder.Append("]");
					}
					flag = false;
				}
				stringBuilder.Append("]");
			}
			if (specification == TypeNameDetail.Full)
			{
				if (!string.IsNullOrEmpty(this.AssemblyDescription))
				{
					stringBuilder.Append(", ");
					stringBuilder.Append(this.AssemblyDescription);
				}
			}
			else if (specification == TypeNameDetail.NameAndAssembly && !string.IsNullOrEmpty(this.AssemblyName))
			{
				stringBuilder.Append(", ");
				stringBuilder.Append(this.AssemblyName);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00024664 File Offset: 0x00022864
		public override string ToString()
		{
			return this.ToString(TypeNameDetail.Name, TypeNameDetail.Full);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x0002466E File Offset: 0x0002286E
		public string ToLooseString()
		{
			return this.ToString(TypeNameDetail.NameAndAssembly, TypeNameDetail.NameAndAssembly);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00024678 File Offset: 0x00022878
		public static string Simplify(string typeName)
		{
			return TypeName.Parse(typeName).ToLooseString();
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00024688 File Offset: 0x00022888
		public static string SimplifyFast(string typeName)
		{
			int num;
			for (;;)
			{
				num = typeName.IndexOf(", Version=", StringComparison.Ordinal);
				if (num < 0)
				{
					return typeName;
				}
				int num2 = typeName.IndexOf(']', num);
				if (num2 < 0)
				{
					break;
				}
				typeName = typeName.Remove(num, num2 - num);
			}
			typeName = typeName.Substring(0, num);
			return typeName;
		}

		// Token: 0x040001F1 RID: 497
		private readonly List<string> names = new List<string>();

		// Token: 0x040001F2 RID: 498
		private readonly List<int> genericarities = new List<int>();

		// Token: 0x020001FE RID: 510
		private enum ParseState
		{
			// Token: 0x04000962 RID: 2402
			Name,
			// Token: 0x04000963 RID: 2403
			Array,
			// Token: 0x04000964 RID: 2404
			Generics,
			// Token: 0x04000965 RID: 2405
			Assembly
		}
	}
}
