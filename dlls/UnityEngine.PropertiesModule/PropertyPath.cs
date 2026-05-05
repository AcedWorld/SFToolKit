using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine.Pool;

namespace Unity.Properties
{
	// Token: 0x0200002B RID: 43
	public readonly struct PropertyPath : IEquatable<PropertyPath>
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00003875 File Offset: 0x00001A75
		public int Length { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x0000387D File Offset: 0x00001A7D
		public bool IsEmpty
		{
			get
			{
				return this.Length == 0;
			}
		}

		// Token: 0x17000020 RID: 32
		public PropertyPathPart this[int index]
		{
			get
			{
				PropertyPathPart result;
				switch (index)
				{
				case 0:
				{
					bool flag = this.Length < 1;
					if (flag)
					{
						throw new IndexOutOfRangeException();
					}
					result = this.m_Part0;
					break;
				}
				case 1:
				{
					bool flag2 = this.Length < 2;
					if (flag2)
					{
						throw new IndexOutOfRangeException();
					}
					result = this.m_Part1;
					break;
				}
				case 2:
				{
					bool flag3 = this.Length < 3;
					if (flag3)
					{
						throw new IndexOutOfRangeException();
					}
					result = this.m_Part2;
					break;
				}
				case 3:
				{
					bool flag4 = this.Length < 4;
					if (flag4)
					{
						throw new IndexOutOfRangeException();
					}
					result = this.m_Part3;
					break;
				}
				default:
					result = this.m_AdditionalParts[index - 4];
					break;
				}
				return result;
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003940 File Offset: 0x00001B40
		public PropertyPath(string path)
		{
			PropertyPath propertyPath = PropertyPath.ConstructFromPath(path);
			this.m_Part0 = propertyPath.m_Part0;
			this.m_Part1 = propertyPath.m_Part1;
			this.m_Part2 = propertyPath.m_Part2;
			this.m_Part3 = propertyPath.m_Part3;
			this.m_AdditionalParts = propertyPath.m_AdditionalParts;
			this.m_InlinePartsCount = propertyPath.m_InlinePartsCount;
			int inlinePartsCount = this.m_InlinePartsCount;
			PropertyPathPart[] additionalParts = this.m_AdditionalParts;
			this.Length = inlinePartsCount + ((additionalParts != null) ? additionalParts.Length : 0);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000039BC File Offset: 0x00001BBC
		private PropertyPath(in PropertyPathPart part)
		{
			this.m_Part0 = part;
			this.m_Part1 = default(PropertyPathPart);
			this.m_Part2 = default(PropertyPathPart);
			this.m_Part3 = default(PropertyPathPart);
			this.m_AdditionalParts = null;
			this.m_InlinePartsCount = 1;
			this.Length = 1;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003A10 File Offset: 0x00001C10
		private PropertyPath(in PropertyPathPart part0, in PropertyPathPart part1)
		{
			this.m_Part0 = part0;
			this.m_Part1 = part1;
			this.m_Part2 = default(PropertyPathPart);
			this.m_Part3 = default(PropertyPathPart);
			this.m_AdditionalParts = null;
			this.m_InlinePartsCount = 2;
			this.Length = 2;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003A64 File Offset: 0x00001C64
		private PropertyPath(in PropertyPathPart part0, in PropertyPathPart part1, in PropertyPathPart part2)
		{
			this.m_Part0 = part0;
			this.m_Part1 = part1;
			this.m_Part2 = part2;
			this.m_Part3 = default(PropertyPathPart);
			this.m_AdditionalParts = null;
			this.m_InlinePartsCount = 3;
			this.Length = 3;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003AB8 File Offset: 0x00001CB8
		private PropertyPath(in PropertyPathPart part0, in PropertyPathPart part1, in PropertyPathPart part2, in PropertyPathPart part3)
		{
			this.m_Part0 = part0;
			this.m_Part1 = part1;
			this.m_Part2 = part2;
			this.m_Part3 = part3;
			this.m_AdditionalParts = null;
			this.m_InlinePartsCount = 4;
			this.Length = 4;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003B0C File Offset: 0x00001D0C
		internal PropertyPath(List<PropertyPathPart> parts)
		{
			this.m_Part0 = default(PropertyPathPart);
			this.m_Part1 = default(PropertyPathPart);
			this.m_Part2 = default(PropertyPathPart);
			this.m_Part3 = default(PropertyPathPart);
			this.m_InlinePartsCount = 0;
			this.m_AdditionalParts = ((parts.Count > 4) ? new PropertyPathPart[parts.Count - 4] : null);
			for (int i = 0; i < parts.Count; i++)
			{
				switch (i)
				{
				case 0:
					this.m_Part0 = parts[i];
					this.m_InlinePartsCount++;
					break;
				case 1:
					this.m_Part1 = parts[i];
					this.m_InlinePartsCount++;
					break;
				case 2:
					this.m_Part2 = parts[i];
					this.m_InlinePartsCount++;
					break;
				case 3:
					this.m_Part3 = parts[i];
					this.m_InlinePartsCount++;
					break;
				default:
					this.m_AdditionalParts[i - 4] = parts[i];
					break;
				}
			}
			this.Length = parts.Count;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003C40 File Offset: 0x00001E40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertyPath FromPart(in PropertyPathPart part)
		{
			return new PropertyPath(ref part);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00003C48 File Offset: 0x00001E48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertyPath FromName(string name)
		{
			PropertyPathPart propertyPathPart = new PropertyPathPart(name);
			return new PropertyPath(ref propertyPathPart);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003C64 File Offset: 0x00001E64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertyPath FromIndex(int index)
		{
			PropertyPathPart propertyPathPart = new PropertyPathPart(index);
			return new PropertyPath(ref propertyPathPart);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003C80 File Offset: 0x00001E80
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertyPath FromKey(object key)
		{
			PropertyPathPart propertyPathPart = new PropertyPathPart(key);
			return new PropertyPath(ref propertyPathPart);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003C9C File Offset: 0x00001E9C
		public static PropertyPath Combine(in PropertyPath path, in PropertyPath pathToAppend)
		{
			bool isEmpty = path.IsEmpty;
			PropertyPath result;
			if (isEmpty)
			{
				result = pathToAppend;
			}
			else
			{
				bool isEmpty2 = pathToAppend.IsEmpty;
				if (isEmpty2)
				{
					result = path;
				}
				else
				{
					int length = path.Length;
					int length2 = pathToAppend.Length;
					int num = length + length2;
					bool flag = num <= 4;
					if (flag)
					{
						int index = 0;
						PropertyPathPart propertyPathPart = path[0];
						PropertyPathPart propertyPathPart2 = (length > 1) ? path[1] : pathToAppend[index++];
						PropertyPathPart propertyPathPart3 = (num > 2) ? ((length > 2) ? path[2] : pathToAppend[index++]) : default(PropertyPathPart);
						PropertyPathPart propertyPathPart4 = (num > 3) ? ((length > 3) ? path[3] : pathToAppend[index]) : default(PropertyPathPart);
						switch (num)
						{
						case 2:
							return new PropertyPath(ref propertyPathPart, ref propertyPathPart2);
						case 3:
							return new PropertyPath(ref propertyPathPart, ref propertyPathPart2, ref propertyPathPart3);
						case 4:
							return new PropertyPath(ref propertyPathPart, ref propertyPathPart2, ref propertyPathPart3, ref propertyPathPart4);
						}
					}
					List<PropertyPathPart> list = CollectionPool<List<PropertyPathPart>, PropertyPathPart>.Get();
					try
					{
						PropertyPath.GetParts(path, list);
						PropertyPath.GetParts(pathToAppend, list);
						result = new PropertyPath(list);
					}
					finally
					{
						CollectionPool<List<PropertyPathPart>, PropertyPathPart>.Release(list);
					}
				}
			}
			return result;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003E04 File Offset: 0x00002004
		public static PropertyPath Combine(in PropertyPath path, string pathToAppend)
		{
			bool flag = string.IsNullOrEmpty(pathToAppend);
			PropertyPath result;
			if (flag)
			{
				result = path;
			}
			else
			{
				PropertyPath propertyPath = new PropertyPath(pathToAppend);
				result = PropertyPath.Combine(path, propertyPath);
			}
			return result;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003E3C File Offset: 0x0000203C
		public static PropertyPath AppendPart(in PropertyPath path, in PropertyPathPart part)
		{
			bool isEmpty = path.IsEmpty;
			PropertyPath result;
			if (isEmpty)
			{
				result = new PropertyPath(ref part);
			}
			else
			{
				switch (path.Length + 1)
				{
				case 2:
				{
					PropertyPathPart propertyPathPart = path[0];
					result = new PropertyPath(ref propertyPathPart, ref part);
					break;
				}
				case 3:
				{
					PropertyPathPart propertyPathPart = path[0];
					PropertyPathPart propertyPathPart2 = path[1];
					result = new PropertyPath(ref propertyPathPart, ref propertyPathPart2, ref part);
					break;
				}
				case 4:
				{
					PropertyPathPart propertyPathPart = path[0];
					PropertyPathPart propertyPathPart2 = path[1];
					PropertyPathPart propertyPathPart3 = path[2];
					result = new PropertyPath(ref propertyPathPart, ref propertyPathPart2, ref propertyPathPart3, ref part);
					break;
				}
				default:
				{
					List<PropertyPathPart> list = CollectionPool<List<PropertyPathPart>, PropertyPathPart>.Get();
					try
					{
						PropertyPath.GetParts(path, list);
						list.Add(part);
						result = new PropertyPath(list);
					}
					finally
					{
						CollectionPool<List<PropertyPathPart>, PropertyPathPart>.Release(list);
					}
					break;
				}
				}
			}
			return result;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003F20 File Offset: 0x00002120
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertyPath AppendName(in PropertyPath path, string name)
		{
			PropertyPathPart propertyPathPart = new PropertyPathPart(name);
			return PropertyPath.AppendPart(path, propertyPathPart);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003F3C File Offset: 0x0000213C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertyPath AppendIndex(in PropertyPath path, int index)
		{
			PropertyPathPart propertyPathPart = new PropertyPathPart(index);
			return PropertyPath.AppendPart(path, propertyPathPart);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003F58 File Offset: 0x00002158
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertyPath AppendKey(in PropertyPath path, object key)
		{
			PropertyPathPart propertyPathPart = new PropertyPathPart(key);
			return PropertyPath.AppendPart(path, propertyPathPart);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003F74 File Offset: 0x00002174
		public static PropertyPath AppendProperty(in PropertyPath path, IProperty property)
		{
			if (!true)
			{
			}
			IListElementProperty listElementProperty = property as IListElementProperty;
			PropertyPath result;
			if (listElementProperty == null)
			{
				ISetElementProperty setElementProperty = property as ISetElementProperty;
				if (setElementProperty == null)
				{
					IDictionaryElementProperty dictionaryElementProperty = property as IDictionaryElementProperty;
					if (dictionaryElementProperty == null)
					{
						PropertyPathPart propertyPathPart = new PropertyPathPart(property.Name);
						result = PropertyPath.AppendPart(path, propertyPathPart);
					}
					else
					{
						PropertyPathPart propertyPathPart = new PropertyPathPart(dictionaryElementProperty.ObjectKey);
						result = PropertyPath.AppendPart(path, propertyPathPart);
					}
				}
				else
				{
					PropertyPathPart propertyPathPart = new PropertyPathPart(setElementProperty.ObjectKey);
					result = PropertyPath.AppendPart(path, propertyPathPart);
				}
			}
			else
			{
				PropertyPathPart propertyPathPart = new PropertyPathPart(listElementProperty.Index);
				result = PropertyPath.AppendPart(path, propertyPathPart);
			}
			if (!true)
			{
			}
			return result;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004017 File Offset: 0x00002217
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertyPath Pop(in PropertyPath path)
		{
			return PropertyPath.SubPath(path, 0, path.Length - 1);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004028 File Offset: 0x00002228
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertyPath SubPath(in PropertyPath path, int startIndex)
		{
			return PropertyPath.SubPath(path, startIndex, path.Length - startIndex);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000403C File Offset: 0x0000223C
		public static PropertyPath SubPath(in PropertyPath path, int startIndex, int length)
		{
			int length2 = path.Length;
			bool flag = startIndex < 0;
			if (flag)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			bool flag2 = startIndex > length2;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			bool flag3 = length < 0;
			if (flag3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			bool flag4 = startIndex > length2 - length;
			if (flag4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			bool flag5 = length == 0;
			PropertyPath result;
			if (flag5)
			{
				result = default(PropertyPath);
			}
			else
			{
				bool flag6 = startIndex == 0 && length == length2;
				if (flag6)
				{
					result = path;
				}
				else
				{
					switch (length)
					{
					case 1:
					{
						PropertyPathPart propertyPathPart = path[startIndex];
						result = new PropertyPath(ref propertyPathPart);
						break;
					}
					case 2:
					{
						PropertyPathPart propertyPathPart = path[startIndex];
						PropertyPathPart propertyPathPart2 = path[startIndex + 1];
						result = new PropertyPath(ref propertyPathPart, ref propertyPathPart2);
						break;
					}
					case 3:
					{
						PropertyPathPart propertyPathPart = path[startIndex];
						PropertyPathPart propertyPathPart2 = path[startIndex + 1];
						PropertyPathPart propertyPathPart3 = path[startIndex + 2];
						result = new PropertyPath(ref propertyPathPart, ref propertyPathPart2, ref propertyPathPart3);
						break;
					}
					case 4:
					{
						PropertyPathPart propertyPathPart = path[startIndex];
						PropertyPathPart propertyPathPart2 = path[startIndex + 1];
						PropertyPathPart propertyPathPart3 = path[startIndex + 2];
						PropertyPathPart propertyPathPart4 = path[startIndex + 3];
						result = new PropertyPath(ref propertyPathPart, ref propertyPathPart2, ref propertyPathPart3, ref propertyPathPart4);
						break;
					}
					default:
					{
						List<PropertyPathPart> list = CollectionPool<List<PropertyPathPart>, PropertyPathPart>.Get();
						try
						{
							for (int i = startIndex; i < startIndex + length; i++)
							{
								list.Add(path[i]);
							}
							result = new PropertyPath(list);
						}
						finally
						{
							CollectionPool<List<PropertyPathPart>, PropertyPathPart>.Release(list);
						}
						break;
					}
					}
				}
			}
			return result;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000041F8 File Offset: 0x000023F8
		public override string ToString()
		{
			bool flag = this.Length == 0;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				bool flag2 = this.Length == 1 && this.m_Part0.IsName;
				if (flag2)
				{
					result = this.m_Part0.Name;
				}
				else
				{
					StringBuilder stringBuilder = new StringBuilder(32);
					bool flag3 = this.Length > 0;
					if (flag3)
					{
						PropertyPath.AppendToBuilder(this.m_Part0, stringBuilder);
					}
					bool flag4 = this.Length > 1;
					if (flag4)
					{
						PropertyPath.AppendToBuilder(this.m_Part1, stringBuilder);
					}
					bool flag5 = this.Length > 2;
					if (flag5)
					{
						PropertyPath.AppendToBuilder(this.m_Part2, stringBuilder);
					}
					bool flag6 = this.Length > 3;
					if (flag6)
					{
						PropertyPath.AppendToBuilder(this.m_Part3, stringBuilder);
					}
					bool flag7 = this.Length > 4;
					if (flag7)
					{
						foreach (PropertyPathPart propertyPathPart in this.m_AdditionalParts)
						{
							PropertyPath.AppendToBuilder(propertyPathPart, stringBuilder);
						}
					}
					result = stringBuilder.ToString();
				}
			}
			return result;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004310 File Offset: 0x00002510
		private static void AppendToBuilder(in PropertyPathPart part, StringBuilder builder)
		{
			PropertyPathPartKind kind = part.Kind;
			PropertyPathPartKind propertyPathPartKind = kind;
			if (propertyPathPartKind != PropertyPathPartKind.Name)
			{
				if (propertyPathPartKind - PropertyPathPartKind.Index > 1)
				{
					throw new ArgumentOutOfRangeException();
				}
				builder.Append(part.ToString());
			}
			else
			{
				bool flag = builder.Length > 0;
				if (flag)
				{
					builder.Append('.');
				}
				builder.Append(part.ToString());
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000437C File Offset: 0x0000257C
		private static void GetParts(in PropertyPath path, List<PropertyPathPart> parts)
		{
			int length = path.Length;
			for (int i = 0; i < length; i++)
			{
				parts.Add(path[i]);
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000043B0 File Offset: 0x000025B0
		private static PropertyPath ConstructFromPath(string path)
		{
			PropertyPath.<>c__DisplayClass37_0 CS$<>8__locals1;
			CS$<>8__locals1.path = path;
			bool flag = string.IsNullOrEmpty(CS$<>8__locals1.path);
			PropertyPath result;
			if (flag)
			{
				result = default(PropertyPath);
			}
			else
			{
				CS$<>8__locals1.index = 0;
				CS$<>8__locals1.length = CS$<>8__locals1.path.Length;
				CS$<>8__locals1.state = 0;
				List<PropertyPathPart> list = CollectionPool<List<PropertyPathPart>, PropertyPathPart>.Get();
				try
				{
					list.Clear();
					while (CS$<>8__locals1.index < CS$<>8__locals1.length)
					{
						switch (CS$<>8__locals1.state)
						{
						case 0:
						{
							PropertyPath.<ConstructFromPath>g__TrimStart|37_0(ref CS$<>8__locals1);
							bool flag2 = CS$<>8__locals1.index == CS$<>8__locals1.length;
							if (!flag2)
							{
								bool flag3 = CS$<>8__locals1.path[CS$<>8__locals1.index] == '.';
								if (flag3)
								{
									throw new ArgumentException(string.Format("{0}: Invalid '{1}' character encountered at index '{2}'.", "PropertyPath", CS$<>8__locals1.path[CS$<>8__locals1.index], CS$<>8__locals1.index));
								}
								bool flag4 = CS$<>8__locals1.path[CS$<>8__locals1.index] == '[';
								if (flag4)
								{
									CS$<>8__locals1.state = 2;
								}
								else
								{
									bool flag5 = CS$<>8__locals1.path[CS$<>8__locals1.index] == '"';
									if (flag5)
									{
										throw new ArgumentException(string.Format("{0}: Invalid '{1}' character encountered at index '{2}'.", "PropertyPath", CS$<>8__locals1.path[CS$<>8__locals1.index], CS$<>8__locals1.index));
									}
									CS$<>8__locals1.state = 1;
								}
							}
							break;
						}
						case 1:
						{
							int index = CS$<>8__locals1.index;
							while (CS$<>8__locals1.index < CS$<>8__locals1.length)
							{
								bool flag6 = CS$<>8__locals1.path[CS$<>8__locals1.index] == '.' || CS$<>8__locals1.path[CS$<>8__locals1.index] == '[';
								if (flag6)
								{
									break;
								}
								int index2 = CS$<>8__locals1.index + 1;
								CS$<>8__locals1.index = index2;
							}
							bool flag7 = index == CS$<>8__locals1.index;
							if (flag7)
							{
								throw new ArgumentException("Invalid PropertyPath: Name is empty.");
							}
							bool flag8 = CS$<>8__locals1.index == CS$<>8__locals1.length;
							if (flag8)
							{
								list.Add(new PropertyPathPart(CS$<>8__locals1.path.Substring(index)));
								CS$<>8__locals1.state = 0;
							}
							else
							{
								list.Add(new PropertyPathPart(CS$<>8__locals1.path.Substring(index, CS$<>8__locals1.index - index)));
								PropertyPath.<ConstructFromPath>g__ReadNext|37_1(ref CS$<>8__locals1);
							}
							break;
						}
						case 2:
						{
							bool flag9 = CS$<>8__locals1.path[CS$<>8__locals1.index] != '[';
							if (flag9)
							{
								throw new ArgumentException(string.Format("{0}: Invalid '{1}' character encountered at index '{2}'.", "PropertyPath", CS$<>8__locals1.path[CS$<>8__locals1.index], CS$<>8__locals1.index));
							}
							bool flag10 = CS$<>8__locals1.index + 1 < CS$<>8__locals1.length && CS$<>8__locals1.path[CS$<>8__locals1.index + 1] == '"';
							if (flag10)
							{
								CS$<>8__locals1.state = 4;
							}
							else
							{
								CS$<>8__locals1.state = 3;
							}
							break;
						}
						case 3:
						{
							bool flag11 = CS$<>8__locals1.path[CS$<>8__locals1.index] != '[';
							if (flag11)
							{
								throw new ArgumentException(string.Format("{0}: Invalid '{1}' character encountered at index '{2}'.", "PropertyPath", CS$<>8__locals1.path[CS$<>8__locals1.index], CS$<>8__locals1.index));
							}
							int index2 = CS$<>8__locals1.index + 1;
							CS$<>8__locals1.index = index2;
							int index3 = CS$<>8__locals1.index;
							while (CS$<>8__locals1.index < CS$<>8__locals1.length)
							{
								char c = CS$<>8__locals1.path[CS$<>8__locals1.index];
								bool flag12 = c == ']';
								if (flag12)
								{
									break;
								}
								index2 = CS$<>8__locals1.index + 1;
								CS$<>8__locals1.index = index2;
							}
							bool flag13 = CS$<>8__locals1.path[CS$<>8__locals1.index] != ']';
							if (flag13)
							{
								throw new ArgumentException(string.Format("{0}: Invalid '{1}' character encountered at index '{2}'.", "PropertyPath", CS$<>8__locals1.path[CS$<>8__locals1.index], CS$<>8__locals1.index));
							}
							string s = CS$<>8__locals1.path.Substring(index3, CS$<>8__locals1.index - index3);
							int num;
							bool flag14 = !int.TryParse(s, out num);
							if (flag14)
							{
								throw new ArgumentException("Indices in PropertyPath must be a numeric value.");
							}
							bool flag15 = num < 0;
							if (flag15)
							{
								throw new ArgumentException("Invalid PropertyPath: Negative indices are not supported.");
							}
							list.Add(new PropertyPathPart(num));
							index2 = CS$<>8__locals1.index + 1;
							CS$<>8__locals1.index = index2;
							bool flag16 = CS$<>8__locals1.index == CS$<>8__locals1.length;
							if (!flag16)
							{
								PropertyPath.<ConstructFromPath>g__ReadNext|37_1(ref CS$<>8__locals1);
							}
							break;
						}
						case 4:
						{
							bool flag17 = CS$<>8__locals1.path[CS$<>8__locals1.index] != '[';
							if (flag17)
							{
								throw new ArgumentException(string.Format("{0}: Invalid '{1}' character encountered at index '{2}'.", "PropertyPath", CS$<>8__locals1.path[CS$<>8__locals1.index], CS$<>8__locals1.index));
							}
							int index2 = CS$<>8__locals1.index + 1;
							CS$<>8__locals1.index = index2;
							bool flag18 = CS$<>8__locals1.path[CS$<>8__locals1.index] != '"';
							if (flag18)
							{
								throw new ArgumentException(string.Format("{0}: Invalid '{1}' character encountered at index '{2}'.", "PropertyPath", CS$<>8__locals1.path[CS$<>8__locals1.index], CS$<>8__locals1.index));
							}
							index2 = CS$<>8__locals1.index + 1;
							CS$<>8__locals1.index = index2;
							int index4 = CS$<>8__locals1.index;
							while (CS$<>8__locals1.index < CS$<>8__locals1.length)
							{
								char c2 = CS$<>8__locals1.path[CS$<>8__locals1.index];
								bool flag19 = c2 == '"';
								if (flag19)
								{
									break;
								}
								index2 = CS$<>8__locals1.index + 1;
								CS$<>8__locals1.index = index2;
							}
							bool flag20 = CS$<>8__locals1.path[CS$<>8__locals1.index] != '"';
							if (flag20)
							{
								throw new ArgumentException(string.Format("{0}: Invalid '{1}' character encountered at index '{2}'.", "PropertyPath", CS$<>8__locals1.path[CS$<>8__locals1.index], CS$<>8__locals1.index));
							}
							bool flag21 = CS$<>8__locals1.index + 1 < CS$<>8__locals1.length && CS$<>8__locals1.path[CS$<>8__locals1.index + 1] == ']';
							if (!flag21)
							{
								throw new ArgumentException("Invalid PropertyPath: No matching end quote for key.");
							}
							string key = CS$<>8__locals1.path.Substring(index4, CS$<>8__locals1.index - index4);
							list.Add(new PropertyPathPart(key));
							CS$<>8__locals1.index += 2;
							PropertyPath.<ConstructFromPath>g__ReadNext|37_1(ref CS$<>8__locals1);
							break;
						}
						}
					}
					result = new PropertyPath(list);
				}
				finally
				{
					CollectionPool<List<PropertyPathPart>, PropertyPathPart>.Release(list);
				}
			}
			return result;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004AB0 File Offset: 0x00002CB0
		public bool Equals(PropertyPath other)
		{
			bool flag = this.Length != other.Length;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < this.Length; i++)
				{
					bool flag2 = !this[i].Equals(other[i]);
					if (flag2)
					{
						return false;
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004B1C File Offset: 0x00002D1C
		public override bool Equals(object obj)
		{
			PropertyPath other;
			bool flag;
			if (obj is PropertyPath)
			{
				other = (PropertyPath)obj;
				flag = true;
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			return flag2 && this.Equals(other);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004B50 File Offset: 0x00002D50
		public override int GetHashCode()
		{
			int num = 19;
			int length = this.Length;
			bool flag = length == 0;
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				bool flag2 = length > 0;
				if (flag2)
				{
					num = num * 31 + this.m_Part0.GetHashCode();
				}
				bool flag3 = length > 1;
				if (flag3)
				{
					num = num * 31 + this.m_Part1.GetHashCode();
				}
				bool flag4 = length > 2;
				if (flag4)
				{
					num = num * 31 + this.m_Part2.GetHashCode();
				}
				bool flag5 = length > 3;
				if (flag5)
				{
					num = num * 31 + this.m_Part3.GetHashCode();
				}
				bool flag6 = length <= 4;
				if (flag6)
				{
					result = num;
				}
				else
				{
					foreach (PropertyPathPart propertyPathPart in this.m_AdditionalParts)
					{
						num = num * 31 + propertyPathPart.GetHashCode();
					}
					result = num;
				}
			}
			return result;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004C50 File Offset: 0x00002E50
		[CompilerGenerated]
		internal static void <ConstructFromPath>g__TrimStart|37_0(ref PropertyPath.<>c__DisplayClass37_0 A_0)
		{
			while (A_0.index < A_0.length && A_0.path[A_0.index] == ' ')
			{
				int index = A_0.index + 1;
				A_0.index = index;
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004C9C File Offset: 0x00002E9C
		[CompilerGenerated]
		internal static void <ConstructFromPath>g__ReadNext|37_1(ref PropertyPath.<>c__DisplayClass37_0 A_0)
		{
			bool flag = A_0.index == A_0.length;
			if (flag)
			{
				A_0.state = 0;
			}
			else
			{
				char c = A_0.path[A_0.index];
				char c2 = c;
				if (c2 != '.')
				{
					if (c2 != '[')
					{
						throw new ArgumentException(string.Format("{0}: Invalid '{1}' character encountered at index '{2}'.", "PropertyPath", A_0.path[A_0.index], A_0.index));
					}
					A_0.state = 2;
				}
				else
				{
					int index = A_0.index + 1;
					A_0.index = index;
					A_0.state = 0;
				}
			}
		}

		// Token: 0x04000041 RID: 65
		internal const int k_InlineCount = 4;

		// Token: 0x04000042 RID: 66
		private readonly PropertyPathPart m_Part0;

		// Token: 0x04000043 RID: 67
		private readonly PropertyPathPart m_Part1;

		// Token: 0x04000044 RID: 68
		private readonly PropertyPathPart m_Part2;

		// Token: 0x04000045 RID: 69
		private readonly PropertyPathPart m_Part3;

		// Token: 0x04000046 RID: 70
		private readonly int m_InlinePartsCount;

		// Token: 0x04000047 RID: 71
		private readonly PropertyPathPart[] m_AdditionalParts;
	}
}
