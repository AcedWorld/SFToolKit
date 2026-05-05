using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000B0 RID: 176
	[GenerateSerializationForGenericParameter(0)]
	public class NetworkList<[IsUnmanaged] T> : NetworkVariableBase where T : struct, ValueType, IEquatable<T>
	{
		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060003F8 RID: 1016 RVA: 0x000126E4 File Offset: 0x000108E4
		// (remove) Token: 0x060003F9 RID: 1017 RVA: 0x0001271C File Offset: 0x0001091C
		public event NetworkList<T>.OnListChangedDelegate OnListChanged;

		// Token: 0x060003FA RID: 1018 RVA: 0x00012751 File Offset: 0x00010951
		public NetworkList() : base(NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server)
		{
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00012784 File Offset: 0x00010984
		public NetworkList(IEnumerable<T> values = null, NetworkVariableReadPermission readPerm = NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission writePerm = NetworkVariableWritePermission.Server) : base(readPerm, writePerm)
		{
			if (values != null)
			{
				foreach (T t in values)
				{
					this.m_List.Add(t);
				}
			}
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00012804 File Offset: 0x00010A04
		~NetworkList()
		{
			this.Dispose();
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00012830 File Offset: 0x00010A30
		public override void ResetDirty()
		{
			base.ResetDirty();
			if (this.m_DirtyEvents.Length > 0)
			{
				this.m_DirtyEvents.Clear();
			}
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00012851 File Offset: 0x00010A51
		public override bool IsDirty()
		{
			return base.IsDirty() || this.m_DirtyEvents.Length > 0;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0001286B File Offset: 0x00010A6B
		internal void MarkNetworkObjectDirty()
		{
			base.MarkNetworkBehaviourDirty();
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00012874 File Offset: 0x00010A74
		public unsafe override void WriteDelta(FastBufferWriter writer)
		{
			ushort num;
			if (base.IsDirty())
			{
				num = 1;
				writer.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
				NetworkListEvent<T>.EventType eventType = NetworkListEvent<T>.EventType.Full;
				writer.WriteValueSafe<NetworkListEvent<T>.EventType>(eventType, default(FastBufferWriter.ForEnums));
				this.WriteField(writer);
				return;
			}
			num = (ushort)this.m_DirtyEvents.Length;
			writer.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < this.m_DirtyEvents.Length; i++)
			{
				NetworkListEvent<T> networkListEvent = *this.m_DirtyEvents.ElementAt(i);
				writer.WriteValueSafe<NetworkListEvent<T>.EventType>(networkListEvent.Type, default(FastBufferWriter.ForEnums));
				NetworkListEvent<T>.EventType eventType = networkListEvent.Type;
				switch (eventType)
				{
				case NetworkListEvent<T>.EventType.Add:
					NetworkVariableSerialization<T>.Write(writer, ref networkListEvent.Value);
					break;
				case NetworkListEvent<T>.EventType.Insert:
					writer.WriteValueSafe<int>(networkListEvent.Index, default(FastBufferWriter.ForPrimitives));
					NetworkVariableSerialization<T>.Write(writer, ref networkListEvent.Value);
					break;
				case NetworkListEvent<T>.EventType.Remove:
					NetworkVariableSerialization<T>.Write(writer, ref networkListEvent.Value);
					break;
				case NetworkListEvent<T>.EventType.RemoveAt:
					writer.WriteValueSafe<int>(networkListEvent.Index, default(FastBufferWriter.ForPrimitives));
					break;
				case NetworkListEvent<T>.EventType.Value:
					writer.WriteValueSafe<int>(networkListEvent.Index, default(FastBufferWriter.ForPrimitives));
					NetworkVariableSerialization<T>.Write(writer, ref networkListEvent.Value);
					break;
				}
			}
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x000129D0 File Offset: 0x00010BD0
		public override void WriteField(FastBufferWriter writer)
		{
			ushort num = (ushort)this.m_List.Length;
			writer.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < this.m_List.Length; i++)
			{
				NetworkVariableSerialization<T>.Write(writer, this.m_List.ElementAt(i));
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00012A24 File Offset: 0x00010C24
		public override void ReadField(FastBufferReader reader)
		{
			this.m_List.Clear();
			ushort num;
			reader.ReadValueSafe<ushort>(out num, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < (int)num; i++)
			{
				T t = Activator.CreateInstance<T>();
				NetworkVariableSerialization<T>.Read(reader, ref t);
				this.m_List.Add(t);
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00012A78 File Offset: 0x00010C78
		public override void ReadDelta(FastBufferReader reader, bool keepDirtyDelta)
		{
			bool isServer = base.m_NetworkManager.IsServer;
			ushort num;
			reader.ReadValueSafe<ushort>(out num, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < (int)num; i++)
			{
				NetworkListEvent<T>.EventType type;
				reader.ReadValueSafe<NetworkListEvent<T>.EventType>(out type, default(FastBufferWriter.ForEnums));
				switch (type)
				{
				case NetworkListEvent<T>.EventType.Add:
				{
					T t = Activator.CreateInstance<T>();
					NetworkVariableSerialization<T>.Read(reader, ref t);
					this.m_List.Add(t);
					if (this.OnListChanged != null)
					{
						NetworkList<T>.OnListChangedDelegate onListChanged = this.OnListChanged;
						NetworkListEvent<T> changeEvent = new NetworkListEvent<T>
						{
							Type = type,
							Index = this.m_List.Length - 1,
							Value = this.m_List[this.m_List.Length - 1]
						};
						onListChanged(changeEvent);
					}
					if (isServer)
					{
						NetworkListEvent<T> changeEvent = default(NetworkListEvent<T>);
						changeEvent.Type = type;
						changeEvent.Index = this.m_List.Length - 1;
						changeEvent.Value = this.m_List[this.m_List.Length - 1];
						this.m_DirtyEvents.Add(changeEvent);
						if (keepDirtyDelta)
						{
							this.MarkNetworkObjectDirty();
						}
					}
					break;
				}
				case NetworkListEvent<T>.EventType.Insert:
				{
					int num2;
					reader.ReadValueSafe<int>(out num2, default(FastBufferWriter.ForPrimitives));
					T value = Activator.CreateInstance<T>();
					NetworkVariableSerialization<T>.Read(reader, ref value);
					if (num2 < this.m_List.Length)
					{
						this.m_List.InsertRangeWithBeginEnd(num2, num2 + 1);
						this.m_List[num2] = value;
					}
					else
					{
						this.m_List.Add(value);
					}
					if (this.OnListChanged != null)
					{
						NetworkList<T>.OnListChangedDelegate onListChanged2 = this.OnListChanged;
						NetworkListEvent<T> changeEvent = new NetworkListEvent<T>
						{
							Type = type,
							Index = num2,
							Value = this.m_List[num2]
						};
						onListChanged2(changeEvent);
					}
					if (isServer)
					{
						NetworkListEvent<T> changeEvent = default(NetworkListEvent<T>);
						changeEvent.Type = type;
						changeEvent.Index = num2;
						changeEvent.Value = this.m_List[num2];
						this.m_DirtyEvents.Add(changeEvent);
						if (keepDirtyDelta)
						{
							this.MarkNetworkObjectDirty();
						}
					}
					break;
				}
				case NetworkListEvent<T>.EventType.Remove:
				{
					T value2 = Activator.CreateInstance<T>();
					NetworkVariableSerialization<T>.Read(reader, ref value2);
					int num3 = this.m_List.IndexOf(value2);
					if (num3 != -1)
					{
						this.m_List.RemoveAt(num3);
						if (this.OnListChanged != null)
						{
							NetworkList<T>.OnListChangedDelegate onListChanged3 = this.OnListChanged;
							NetworkListEvent<T> changeEvent = new NetworkListEvent<T>
							{
								Type = type,
								Index = num3,
								Value = value2
							};
							onListChanged3(changeEvent);
						}
						if (isServer)
						{
							NetworkListEvent<T> changeEvent = default(NetworkListEvent<T>);
							changeEvent.Type = type;
							changeEvent.Index = num3;
							changeEvent.Value = value2;
							this.m_DirtyEvents.Add(changeEvent);
							if (keepDirtyDelta)
							{
								this.MarkNetworkObjectDirty();
							}
						}
					}
					break;
				}
				case NetworkListEvent<T>.EventType.RemoveAt:
				{
					int index;
					reader.ReadValueSafe<int>(out index, default(FastBufferWriter.ForPrimitives));
					T value3 = this.m_List[index];
					this.m_List.RemoveAt(index);
					if (this.OnListChanged != null)
					{
						NetworkList<T>.OnListChangedDelegate onListChanged4 = this.OnListChanged;
						NetworkListEvent<T> changeEvent = new NetworkListEvent<T>
						{
							Type = type,
							Index = index,
							Value = value3
						};
						onListChanged4(changeEvent);
					}
					if (isServer)
					{
						NetworkListEvent<T> changeEvent = default(NetworkListEvent<T>);
						changeEvent.Type = type;
						changeEvent.Index = index;
						changeEvent.Value = value3;
						this.m_DirtyEvents.Add(changeEvent);
						if (keepDirtyDelta)
						{
							this.MarkNetworkObjectDirty();
						}
					}
					break;
				}
				case NetworkListEvent<T>.EventType.Value:
				{
					int num4;
					reader.ReadValueSafe<int>(out num4, default(FastBufferWriter.ForPrimitives));
					T value4 = Activator.CreateInstance<T>();
					NetworkVariableSerialization<T>.Read(reader, ref value4);
					if (num4 >= this.m_List.Length)
					{
						throw new Exception("Shouldn't be here, index is higher than list length");
					}
					T previousValue = this.m_List[num4];
					this.m_List[num4] = value4;
					if (this.OnListChanged != null)
					{
						NetworkList<T>.OnListChangedDelegate onListChanged5 = this.OnListChanged;
						NetworkListEvent<T> changeEvent = new NetworkListEvent<T>
						{
							Type = type,
							Index = num4,
							Value = value4,
							PreviousValue = previousValue
						};
						onListChanged5(changeEvent);
					}
					if (isServer)
					{
						NetworkListEvent<T> changeEvent = default(NetworkListEvent<T>);
						changeEvent.Type = type;
						changeEvent.Index = num4;
						changeEvent.Value = value4;
						changeEvent.PreviousValue = previousValue;
						this.m_DirtyEvents.Add(changeEvent);
						if (keepDirtyDelta)
						{
							this.MarkNetworkObjectDirty();
						}
					}
					break;
				}
				case NetworkListEvent<T>.EventType.Clear:
					this.m_List.Clear();
					if (this.OnListChanged != null)
					{
						NetworkList<T>.OnListChangedDelegate onListChanged6 = this.OnListChanged;
						NetworkListEvent<T> changeEvent = new NetworkListEvent<T>
						{
							Type = type
						};
						onListChanged6(changeEvent);
					}
					if (isServer)
					{
						NetworkListEvent<T> changeEvent = default(NetworkListEvent<T>);
						changeEvent.Type = type;
						this.m_DirtyEvents.Add(changeEvent);
						if (keepDirtyDelta)
						{
							this.MarkNetworkObjectDirty();
						}
					}
					break;
				case NetworkListEvent<T>.EventType.Full:
					this.ReadField(reader);
					this.ResetDirty();
					break;
				}
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00012F6E File Offset: 0x0001116E
		internal override void PostDeltaRead()
		{
			if (base.m_NetworkManager.IsServer)
			{
				this.ResetDirty();
			}
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00012F83 File Offset: 0x00011183
		public IEnumerator<T> GetEnumerator()
		{
			return this.m_List.GetEnumerator();
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00012F98 File Offset: 0x00011198
		public void Add(T item)
		{
			if (!base.CanClientWrite(this.m_NetworkBehaviour.NetworkManager.LocalClientId))
			{
				base.LogWritePermissionError();
				return;
			}
			this.m_List.Add(item);
			NetworkListEvent<T> listEvent = new NetworkListEvent<T>
			{
				Type = NetworkListEvent<T>.EventType.Add,
				Value = item,
				Index = this.m_List.Length - 1
			};
			this.HandleAddListEvent(listEvent);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00013008 File Offset: 0x00011208
		public void Clear()
		{
			if (!base.CanClientWrite(this.m_NetworkBehaviour.NetworkManager.LocalClientId))
			{
				base.LogWritePermissionError();
				return;
			}
			this.m_List.Clear();
			NetworkListEvent<T> listEvent = new NetworkListEvent<T>
			{
				Type = NetworkListEvent<T>.EventType.Clear
			};
			this.HandleAddListEvent(listEvent);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00013058 File Offset: 0x00011258
		public bool Contains(T item)
		{
			return this.m_List.IndexOf(item) != -1;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0001306C File Offset: 0x0001126C
		public bool Remove(T item)
		{
			if (!base.CanClientWrite(this.m_NetworkBehaviour.NetworkManager.LocalClientId))
			{
				base.LogWritePermissionError();
				return false;
			}
			int num = this.m_List.IndexOf(item);
			if (num == -1)
			{
				return false;
			}
			this.m_List.RemoveAt(num);
			NetworkListEvent<T> listEvent = new NetworkListEvent<T>
			{
				Type = NetworkListEvent<T>.EventType.Remove,
				Value = item
			};
			this.HandleAddListEvent(listEvent);
			return true;
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x000130DA File Offset: 0x000112DA
		public int Count
		{
			get
			{
				return this.m_List.Length;
			}
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x000130E7 File Offset: 0x000112E7
		public int IndexOf(T item)
		{
			return this.m_List.IndexOf(item);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x000130F8 File Offset: 0x000112F8
		public void Insert(int index, T item)
		{
			if (!base.CanClientWrite(this.m_NetworkBehaviour.NetworkManager.LocalClientId))
			{
				base.LogWritePermissionError();
				return;
			}
			if (index < this.m_List.Length)
			{
				this.m_List.InsertRangeWithBeginEnd(index, index + 1);
				this.m_List[index] = item;
			}
			else
			{
				this.m_List.Add(item);
			}
			NetworkListEvent<T> listEvent = new NetworkListEvent<T>
			{
				Type = NetworkListEvent<T>.EventType.Insert,
				Index = index,
				Value = item
			};
			this.HandleAddListEvent(listEvent);
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00013188 File Offset: 0x00011388
		public void RemoveAt(int index)
		{
			if (!base.CanClientWrite(this.m_NetworkBehaviour.NetworkManager.LocalClientId))
			{
				base.LogWritePermissionError();
				return;
			}
			T value = this.m_List[index];
			this.m_List.RemoveAt(index);
			NetworkListEvent<T> listEvent = new NetworkListEvent<T>
			{
				Type = NetworkListEvent<T>.EventType.RemoveAt,
				Index = index,
				Value = value
			};
			this.HandleAddListEvent(listEvent);
		}

		// Token: 0x17000088 RID: 136
		public T this[int index]
		{
			get
			{
				return this.m_List[index];
			}
			set
			{
				if (!base.CanClientWrite(this.m_NetworkBehaviour.NetworkManager.LocalClientId))
				{
					base.LogWritePermissionError();
					return;
				}
				T previousValue = this.m_List[index];
				this.m_List[index] = value;
				NetworkListEvent<T> listEvent = new NetworkListEvent<T>
				{
					Type = NetworkListEvent<T>.EventType.Value,
					Index = index,
					Value = value,
					PreviousValue = previousValue
				};
				this.HandleAddListEvent(listEvent);
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0001327B File Offset: 0x0001147B
		private void HandleAddListEvent(NetworkListEvent<T> listEvent)
		{
			this.m_DirtyEvents.Add(listEvent);
			this.MarkNetworkObjectDirty();
			NetworkList<T>.OnListChangedDelegate onListChanged = this.OnListChanged;
			if (onListChanged == null)
			{
				return;
			}
			onListChanged(listEvent);
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x000132A1 File Offset: 0x000114A1
		public int LastModifiedTick
		{
			get
			{
				return int.MinValue;
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x000132A8 File Offset: 0x000114A8
		public override void Dispose()
		{
			if (this.m_List.IsCreated)
			{
				this.m_List.Dispose();
			}
			if (this.m_DirtyEvents.IsCreated)
			{
				this.m_DirtyEvents.Dispose();
			}
			base.Dispose();
		}

		// Token: 0x04000238 RID: 568
		private NativeList<T> m_List = new NativeList<T>(64, Allocator.Persistent);

		// Token: 0x04000239 RID: 569
		private NativeList<NetworkListEvent<T>> m_DirtyEvents = new NativeList<NetworkListEvent<T>>(64, Allocator.Persistent);

		// Token: 0x020000B1 RID: 177
		// (Invoke) Token: 0x06000414 RID: 1044
		public delegate void OnListChangedDelegate(NetworkListEvent<T> changeEvent);
	}
}
