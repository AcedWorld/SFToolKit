using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Analytics
{
	// Token: 0x0200000C RID: 12
	[NativeHeader("Modules/UnityAnalytics/Public/Events/UserCustomEvent.h")]
	[StructLayout(LayoutKind.Sequential)]
	internal class CustomEventData : IDisposable
	{
		// Token: 0x0600008C RID: 140 RVA: 0x00002435 File Offset: 0x00000635
		private CustomEventData()
		{
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002E4F File Offset: 0x0000104F
		public CustomEventData(string name)
		{
			this.m_Ptr = CustomEventData.Internal_Create(this, name);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002E68 File Offset: 0x00001068
		~CustomEventData()
		{
			this.Destroy();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00002E98 File Offset: 0x00001098
		private void Destroy()
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				CustomEventData.Internal_Destroy(this.m_Ptr);
				this.m_Ptr = IntPtr.Zero;
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00002ED3 File Offset: 0x000010D3
		public void Dispose()
		{
			this.Destroy();
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000091 RID: 145
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr Internal_Create(CustomEventData ced, string name);

		// Token: 0x06000092 RID: 146
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Destroy(IntPtr ptr);

		// Token: 0x06000093 RID: 147
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool AddString(string key, string value);

		// Token: 0x06000094 RID: 148
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool AddInt32(string key, int value);

		// Token: 0x06000095 RID: 149
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool AddUInt32(string key, uint value);

		// Token: 0x06000096 RID: 150
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool AddInt64(string key, long value);

		// Token: 0x06000097 RID: 151
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool AddUInt64(string key, ulong value);

		// Token: 0x06000098 RID: 152
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool AddBool(string key, bool value);

		// Token: 0x06000099 RID: 153
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool AddDouble(string key, double value);

		// Token: 0x0600009A RID: 154 RVA: 0x00002EE4 File Offset: 0x000010E4
		public bool AddDictionary(IDictionary<string, object> eventData)
		{
			foreach (KeyValuePair<string, object> keyValuePair in eventData)
			{
				string key = keyValuePair.Key;
				object value = keyValuePair.Value;
				bool flag = value == null;
				if (flag)
				{
					this.AddString(key, "null");
				}
				else
				{
					Type type = value.GetType();
					bool flag2 = type == typeof(string);
					if (flag2)
					{
						this.AddString(key, (string)value);
					}
					else
					{
						bool flag3 = type == typeof(char);
						if (flag3)
						{
							this.AddString(key, char.ToString((char)value));
						}
						else
						{
							bool flag4 = type == typeof(sbyte);
							if (flag4)
							{
								this.AddInt32(key, (int)((sbyte)value));
							}
							else
							{
								bool flag5 = type == typeof(byte);
								if (flag5)
								{
									this.AddInt32(key, (int)((byte)value));
								}
								else
								{
									bool flag6 = type == typeof(short);
									if (flag6)
									{
										this.AddInt32(key, (int)((short)value));
									}
									else
									{
										bool flag7 = type == typeof(ushort);
										if (flag7)
										{
											this.AddUInt32(key, (uint)((ushort)value));
										}
										else
										{
											bool flag8 = type == typeof(int);
											if (flag8)
											{
												this.AddInt32(key, (int)value);
											}
											else
											{
												bool flag9 = type == typeof(uint);
												if (flag9)
												{
													this.AddUInt32(keyValuePair.Key, (uint)value);
												}
												else
												{
													bool flag10 = type == typeof(long);
													if (flag10)
													{
														this.AddInt64(key, (long)value);
													}
													else
													{
														bool flag11 = type == typeof(ulong);
														if (flag11)
														{
															this.AddUInt64(key, (ulong)value);
														}
														else
														{
															bool flag12 = type == typeof(bool);
															if (flag12)
															{
																this.AddBool(key, (bool)value);
															}
															else
															{
																bool flag13 = type == typeof(float);
																if (flag13)
																{
																	this.AddDouble(key, (double)Convert.ToDecimal((float)value));
																}
																else
																{
																	bool flag14 = type == typeof(double);
																	if (flag14)
																	{
																		this.AddDouble(key, (double)value);
																	}
																	else
																	{
																		bool flag15 = type == typeof(decimal);
																		if (flag15)
																		{
																			this.AddDouble(key, (double)Convert.ToDecimal((decimal)value));
																		}
																		else
																		{
																			bool isValueType = type.IsValueType;
																			if (!isValueType)
																			{
																				throw new ArgumentException(string.Format("Invalid type: {0} passed", type));
																			}
																			this.AddString(key, value.ToString());
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x04000019 RID: 25
		[NonSerialized]
		internal IntPtr m_Ptr;
	}
}
