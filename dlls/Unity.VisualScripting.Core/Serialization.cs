using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200013A RID: 314
	public static class Serialization
	{
		// Token: 0x0600087F RID: 2175 RVA: 0x00025A84 File Offset: 0x00023C84
		static Serialization()
		{
			Serialization.freeOperations = new HashSet<SerializationOperation>();
			Serialization.busyOperations = new HashSet<SerializationOperation>();
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x00025AAE File Offset: 0x00023CAE
		// (set) Token: 0x06000881 RID: 2177 RVA: 0x00025AB5 File Offset: 0x00023CB5
		public static bool isUnitySerializing { get; set; }

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x00025ABD File Offset: 0x00023CBD
		public static bool isCustomSerializing
		{
			get
			{
				return Serialization.busyOperations.Count > 0;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000883 RID: 2179 RVA: 0x00025ACC File Offset: 0x00023CCC
		public static bool isSerializing
		{
			get
			{
				return Serialization.isUnitySerializing || Serialization.isCustomSerializing;
			}
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00025ADC File Offset: 0x00023CDC
		private static SerializationOperation StartOperation()
		{
			object obj = Serialization.@lock;
			SerializationOperation result;
			lock (obj)
			{
				if (Serialization.freeOperations.Count == 0)
				{
					Serialization.freeOperations.Add(new SerializationOperation());
				}
				SerializationOperation serializationOperation = Serialization.freeOperations.First<SerializationOperation>();
				Serialization.freeOperations.Remove(serializationOperation);
				Serialization.busyOperations.Add(serializationOperation);
				result = serializationOperation;
			}
			return result;
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00025B58 File Offset: 0x00023D58
		private static void EndOperation(SerializationOperation operation)
		{
			object obj = Serialization.@lock;
			lock (obj)
			{
				if (!Serialization.busyOperations.Contains(operation))
				{
					throw new InvalidOperationException("Trying to finish an operation that isn't started.");
				}
				operation.Reset();
				Serialization.busyOperations.Remove(operation);
				Serialization.freeOperations.Add(operation);
			}
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x00025BC8 File Offset: 0x00023DC8
		public static T CloneViaSerialization<T>(this T value, bool forceReflected = false)
		{
			return (T)((object)value.Serialize(forceReflected).Deserialize(forceReflected));
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00025BE4 File Offset: 0x00023DE4
		public static void CloneViaSerializationInto<TSource, TDestination>(this TSource value, ref TDestination instance, bool forceReflected = false) where TDestination : TSource
		{
			object obj = instance;
			value.Serialize(forceReflected).DeserializeInto(ref obj, forceReflected);
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00025C14 File Offset: 0x00023E14
		public static SerializationData Serialize(this object value, bool forceReflected = false)
		{
			SerializationOperation serializationOperation = Serialization.StartOperation();
			SerializationData result;
			try
			{
				string json = Serialization.SerializeJson(serializationOperation.serializer, value, forceReflected);
				Object[] objectReferences = serializationOperation.objectReferences.ToArray();
				result = new SerializationData(json, objectReferences);
			}
			catch (Exception innerException)
			{
				throw new SerializationException("Serialization of '" + (((value != null) ? value.GetType().ToString() : null) ?? "null") + "' failed.", innerException);
			}
			finally
			{
				Serialization.EndOperation(serializationOperation);
			}
			return result;
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00025CA4 File Offset: 0x00023EA4
		public static void DeserializeInto(this SerializationData data, ref object instance, bool forceReflected = false)
		{
			try
			{
				if (string.IsNullOrEmpty(data.json))
				{
					instance = null;
				}
				else
				{
					SerializationOperation serializationOperation = Serialization.StartOperation();
					try
					{
						serializationOperation.objectReferences.AddRange(data.objectReferences);
						Serialization.DeserializeJson(serializationOperation.serializer, data.json, ref instance, forceReflected);
					}
					finally
					{
						Serialization.EndOperation(serializationOperation);
					}
				}
			}
			catch (Exception innerException)
			{
				try
				{
					Debug.LogWarning(data.ToString("Deserialization Failure Data"), instance as Object);
				}
				catch (Exception ex)
				{
					string str = "Failed to log deserialization failure data:\n";
					Exception ex2 = ex;
					Debug.LogWarning(str + ((ex2 != null) ? ex2.ToString() : null), instance as Object);
				}
				string str2 = "Deserialization into '";
				object obj = instance;
				throw new SerializationException(str2 + (((obj != null) ? obj.GetType().ToString() : null) ?? "null") + "' failed.", innerException);
			}
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00025D9C File Offset: 0x00023F9C
		public static object Deserialize(this SerializationData data, bool forceReflected = false)
		{
			object result = null;
			data.DeserializeInto(ref result, forceReflected);
			return result;
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00025DB8 File Offset: 0x00023FB8
		private static string SerializeJson(fsSerializer serializer, object instance, bool forceReflected)
		{
			string result2;
			using (ProfilingUtility.SampleBlock("SerializeJson"))
			{
				fsData data;
				fsResult result;
				if (forceReflected)
				{
					result = serializer.TrySerialize(instance.GetType(), typeof(fsReflectedConverter), instance, out data);
				}
				else
				{
					result = serializer.TrySerialize<object>(instance, out data);
				}
				Serialization.HandleResult("Serialization", result, instance as Object);
				result2 = fsJsonPrinter.CompressedJson(data);
			}
			return result2;
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00025E34 File Offset: 0x00024034
		private static fsResult DeserializeJsonUtil(fsSerializer serializer, string json, ref object instance, bool forceReflected)
		{
			fsData data = fsJsonParser.Parse(json);
			fsResult result;
			if (forceReflected)
			{
				result = serializer.TryDeserialize(data, instance.GetType(), typeof(fsReflectedConverter), ref instance);
			}
			else
			{
				result = serializer.TryDeserialize<object>(data, ref instance);
			}
			return result;
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00025E74 File Offset: 0x00024074
		private static void DeserializeJson(fsSerializer serializer, string json, ref object instance, bool forceReflected)
		{
			using (ProfilingUtility.SampleBlock("DeserializeJson"))
			{
				fsResult result = Serialization.DeserializeJsonUtil(serializer, json, ref instance, forceReflected);
				Serialization.HandleResult("Deserialization", result, instance as Object);
			}
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00025EC8 File Offset: 0x000240C8
		private static void HandleResult(string label, fsResult result, Object context = null)
		{
			result.AssertSuccess();
			if (result.HasWarnings)
			{
				foreach (string text in result.RawMessages)
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"[",
						label,
						"] ",
						text,
						"\n"
					}), context);
				}
			}
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00025F54 File Offset: 0x00024154
		public static string PrettyPrint(string json)
		{
			return fsJsonPrinter.PrettyJson(fsJsonParser.Parse(json));
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00025F61 File Offset: 0x00024161
		public static void AwaitDependencies(ISerializationDepender depender)
		{
			Serialization.awaitingDependers.Add(depender);
			Serialization.CheckIfDependenciesMet(depender);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00025F75 File Offset: 0x00024175
		public static void NotifyDependencyDeserializing(ISerializationDependency dependency)
		{
			Serialization.NotifyDependencyUnavailable(dependency);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00025F7D File Offset: 0x0002417D
		public static void NotifyDependencyDeserialized(ISerializationDependency dependency)
		{
			Serialization.NotifyDependencyAvailable(dependency);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00025F85 File Offset: 0x00024185
		public static void NotifyDependencyUnavailable(ISerializationDependency dependency)
		{
			dependency.IsDeserialized = false;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00025F90 File Offset: 0x00024190
		public static void NotifyDependencyAvailable(ISerializationDependency dependency)
		{
			dependency.IsDeserialized = true;
			foreach (ISerializationDepender serializationDepender in Serialization.awaitingDependers.ToArray<ISerializationDepender>())
			{
				if (Serialization.awaitingDependers.Contains(serializationDepender))
				{
					Serialization.CheckIfDependenciesMet(serializationDepender);
				}
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00025FD4 File Offset: 0x000241D4
		private static void CheckIfDependenciesMet(ISerializationDepender depender)
		{
			bool flag = true;
			using (IEnumerator<ISerializationDependency> enumerator = depender.deserializationDependencies.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsDeserialized)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				Serialization.awaitingDependers.Remove(depender);
				depender.OnAfterDependenciesDeserialized();
			}
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0002603C File Offset: 0x0002423C
		public static void LogStuckDependers()
		{
			if (Serialization.awaitingDependers.Any<ISerializationDepender>())
			{
				string text = Serialization.awaitingDependers.Count.ToString() + " awaiting dependers: \n";
				foreach (ISerializationDepender serializationDepender in Serialization.awaitingDependers)
				{
					HashSet<object> hashSet = new HashSet<object>();
					foreach (ISerializationDependency serializationDependency in serializationDepender.deserializationDependencies)
					{
						if (!serializationDependency.IsDeserialized)
						{
							hashSet.Add(serializationDependency);
							break;
						}
					}
					text += string.Format("{0} is missing {1}\n", serializationDepender, hashSet.ToCommaSeparatedString());
				}
				Debug.LogWarning(text);
				return;
			}
			Debug.Log("No stuck awaiting depender.");
		}

		// Token: 0x04000207 RID: 519
		public const string ConstructorWarning = "This parameterless constructor is only made public for serialization. Use another constructor instead.";

		// Token: 0x04000208 RID: 520
		private static readonly HashSet<SerializationOperation> freeOperations;

		// Token: 0x04000209 RID: 521
		private static readonly HashSet<SerializationOperation> busyOperations;

		// Token: 0x0400020A RID: 522
		private static readonly object @lock = new object();

		// Token: 0x0400020C RID: 524
		private static readonly HashSet<ISerializationDepender> awaitingDependers = new HashSet<ISerializationDepender>();
	}
}
