using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport.Relay;
using Unity.Networking.Transport.TLS;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x0200006C RID: 108
	public struct NetworkSettings : IDisposable
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x0000A61C File Offset: 0x0000881C
		public bool IsCreated
		{
			get
			{
				return this.m_Initialized == 0 || this.m_Parameters.IsCreated;
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000A634 File Offset: 0x00008834
		private bool EnsureInitializedOrError()
		{
			if (this.m_Initialized == 0)
			{
				this.m_Initialized = 1;
				this.m_Parameters = new NativeList<byte>(Allocator.Temp);
				this.m_ParameterOffsets = new NativeHashMap<long, NetworkSettings.ParameterSlice>(8, Allocator.Temp);
			}
			if (!this.m_Parameters.IsCreated)
			{
				Debug.LogError("The NetworkSettings has been deallocated, it is not allowed to access it.");
				return false;
			}
			return true;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000A68D File Offset: 0x0000888D
		public NetworkSettings(Allocator allocator)
		{
			this.m_Initialized = 1;
			this.m_Parameters = new NativeList<byte>(allocator);
			this.m_ParameterOffsets = new NativeHashMap<long, NetworkSettings.ParameterSlice>(8, allocator);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000A6B9 File Offset: 0x000088B9
		public void Dispose()
		{
			this.m_Initialized = 1;
			if (this.m_Parameters.IsCreated)
			{
				this.m_Parameters.Dispose();
				this.m_ParameterOffsets.Dispose();
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0000A6E8 File Offset: 0x000088E8
		public unsafe void AddRawParameterStruct<[IsUnmanaged] T>(ref T parameter) where T : struct, ValueType, INetworkParameter
		{
			if (!this.EnsureInitializedOrError())
			{
				return;
			}
			NetworkSettings.ValidateParameterOrError<T>(ref parameter);
			long hashCode = BurstRuntime.GetHashCode64<T>();
			NetworkSettings.ParameterSlice parameterSlice = new NetworkSettings.ParameterSlice
			{
				Offset = this.m_Parameters.Length,
				Size = UnsafeUtility.SizeOf<T>()
			};
			if (this.m_ParameterOffsets.TryAdd(hashCode, parameterSlice))
			{
				this.m_Parameters.Resize(this.m_Parameters.Length + parameterSlice.Size, NativeArrayOptions.UninitializedMemory);
			}
			else
			{
				parameterSlice = this.m_ParameterOffsets[hashCode];
			}
			T* ptr = (T*)((byte*)this.m_Parameters.GetUnsafePtr<byte>() + parameterSlice.Offset);
			*ptr = parameter;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000A790 File Offset: 0x00008990
		public unsafe bool TryGet<[IsUnmanaged] T>(out T parameter) where T : struct, ValueType, INetworkParameter
		{
			parameter = default(T);
			if (!this.EnsureInitializedOrError())
			{
				return false;
			}
			long hashCode = BurstRuntime.GetHashCode64<T>();
			NetworkSettings.ParameterSlice parameterSlice;
			if (this.m_ParameterOffsets.TryGetValue(hashCode, out parameterSlice))
			{
				parameter = *(T*)((byte*)this.m_Parameters.GetUnsafeReadOnlyPtr<byte>() + parameterSlice.Offset);
				return true;
			}
			return false;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0000A7E4 File Offset: 0x000089E4
		internal static void ValidateParameterOrError<T>(ref T parameter) where T : INetworkParameter
		{
			if (!parameter.Validate())
			{
				Debug.LogError("The provided network parameter (" + parameter.GetType().Name + ") is not valid");
			}
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000A81C File Offset: 0x00008A1C
		internal static NetworkSettings FromArray(params INetworkParameter[] parameters)
		{
			NetworkSettings networkSettings = new NetworkSettings(Allocator.Temp);
			foreach (INetworkParameter networkParameter in parameters)
			{
				Type type = networkParameter.GetType();
				if (type == typeof(BaselibNetworkParameter))
				{
					BaselibNetworkParameter baselibNetworkParameter = (BaselibNetworkParameter)networkParameter;
					if (baselibNetworkParameter.receiveQueueCapacity == 0)
					{
						baselibNetworkParameter.receiveQueueCapacity = 64;
					}
					if (baselibNetworkParameter.sendQueueCapacity == 0)
					{
						baselibNetworkParameter.sendQueueCapacity = 64;
					}
					if (baselibNetworkParameter.maximumPayloadSize == 0U)
					{
						baselibNetworkParameter.maximumPayloadSize = 2000U;
					}
					networkParameter = baselibNetworkParameter;
				}
				if (type == typeof(RelayNetworkParameter))
				{
					RelayNetworkParameter relayNetworkParameter = (RelayNetworkParameter)networkParameter;
					if (relayNetworkParameter.RelayConnectionTimeMS == 0)
					{
						relayNetworkParameter.RelayConnectionTimeMS = 3000;
					}
					networkParameter = relayNetworkParameter;
				}
				else if (type == typeof(SecureNetworkProtocolParameter))
				{
					SecureNetworkProtocolParameter secureNetworkProtocolParameter = (SecureNetworkProtocolParameter)networkParameter;
					if (secureNetworkProtocolParameter.SSLHandshakeTimeoutMin == 0U)
					{
						secureNetworkProtocolParameter.SSLHandshakeTimeoutMin = SecureNetworkProtocol.DefaultParameters.SSLHandshakeTimeoutMin;
					}
					if (secureNetworkProtocolParameter.SSLHandshakeTimeoutMax == 0U)
					{
						secureNetworkProtocolParameter.SSLHandshakeTimeoutMax = SecureNetworkProtocol.DefaultParameters.SSLHandshakeTimeoutMax;
					}
					networkParameter = secureNetworkProtocolParameter;
				}
				MethodInfo methodInfo = typeof(NetworkSettings).GetMethod("AddRawParameterStruct").MakeGenericMethod(new Type[]
				{
					type
				});
				try
				{
					methodInfo.Invoke(networkSettings, new object[]
					{
						networkParameter
					});
				}
				catch (TargetInvocationException ex)
				{
					throw ex.InnerException;
				}
			}
			return networkSettings;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000A990 File Offset: 0x00008B90
		internal bool TryGet(Type parameterType, out INetworkParameter parameter)
		{
			parameter = null;
			if (!this.m_Parameters.IsCreated)
			{
				return false;
			}
			MethodInfo methodInfo = typeof(NetworkSettings).GetMethod("TryGet").MakeGenericMethod(new Type[]
			{
				parameterType
			});
			object[] array = new object[1];
			object obj = methodInfo.Invoke(this, array);
			parameter = (INetworkParameter)array[0];
			return (bool)obj;
		}

		// Token: 0x0400016A RID: 362
		private const int k_MapInitialCapacity = 8;

		// Token: 0x0400016B RID: 363
		private NativeHashMap<long, NetworkSettings.ParameterSlice> m_ParameterOffsets;

		// Token: 0x0400016C RID: 364
		private NativeList<byte> m_Parameters;

		// Token: 0x0400016D RID: 365
		private byte m_Initialized;

		// Token: 0x0200006D RID: 109
		private struct ParameterSlice
		{
			// Token: 0x0400016E RID: 366
			public int Offset;

			// Token: 0x0400016F RID: 367
			public int Size;
		}
	}
}
