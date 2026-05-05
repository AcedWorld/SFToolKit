using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x020001A8 RID: 424
	public class fsSerializer
	{
		// Token: 0x06000B23 RID: 2851 RVA: 0x0002EAFC File Offset: 0x0002CCFC
		public fsSerializer()
		{
			this._cachedConverterTypeInstances = new Dictionary<Type, fsBaseConverter>();
			this._cachedConverters = new Dictionary<Type, fsBaseConverter>();
			this._cachedProcessors = new Dictionary<Type, List<fsObjectProcessor>>();
			this._references = new fsCyclicReferenceManager();
			this._lazyReferenceWriter = new fsSerializer.fsLazyCycleDefinitionWriter();
			this._availableConverters = new List<fsConverter>
			{
				new fsNullableConverter
				{
					Serializer = this
				},
				new fsGuidConverter
				{
					Serializer = this
				},
				new fsTypeConverter
				{
					Serializer = this
				},
				new fsDateConverter
				{
					Serializer = this
				},
				new fsEnumConverter
				{
					Serializer = this
				},
				new fsPrimitiveConverter
				{
					Serializer = this
				},
				new fsArrayConverter
				{
					Serializer = this
				},
				new fsDictionaryConverter
				{
					Serializer = this
				},
				new fsIEnumerableConverter
				{
					Serializer = this
				},
				new fsKeyValuePairConverter
				{
					Serializer = this
				},
				new fsWeakReferenceConverter
				{
					Serializer = this
				},
				new fsReflectedConverter
				{
					Serializer = this
				}
			};
			this._availableDirectConverters = new Dictionary<Type, fsDirectConverter>();
			this._processors = new List<fsObjectProcessor>
			{
				new fsSerializationCallbackProcessor()
			};
			this._processors.Add(new fsSerializationCallbackReceiverProcessor());
			this._abstractTypeRemap = new Dictionary<Type, Type>();
			this.SetDefaultStorageType(typeof(ICollection<>), typeof(List<>));
			this.SetDefaultStorageType(typeof(IList<>), typeof(List<>));
			this.SetDefaultStorageType(typeof(IDictionary<, >), typeof(Dictionary<, >));
			this.Context = new fsContext();
			this.Config = new fsConfig();
			foreach (Type type in fsConverterRegistrar.Converters)
			{
				this.AddConverter((fsBaseConverter)Activator.CreateInstance(type));
			}
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0002ED18 File Offset: 0x0002CF18
		private void RemapAbstractStorageTypeToDefaultType(ref Type storageType)
		{
			if (!storageType.Resolve().IsInterface && !storageType.Resolve().IsAbstract)
			{
				return;
			}
			Type type2;
			if (storageType.Resolve().IsGenericType)
			{
				Type type;
				if (this._abstractTypeRemap.TryGetValue(storageType.Resolve().GetGenericTypeDefinition(), out type))
				{
					Type[] genericArguments = storageType.GetGenericArguments();
					storageType = type.Resolve().MakeGenericType(genericArguments);
					return;
				}
			}
			else if (this._abstractTypeRemap.TryGetValue(storageType, out type2))
			{
				storageType = type2;
			}
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0002ED96 File Offset: 0x0002CF96
		public void AddProcessor(fsObjectProcessor processor)
		{
			this._processors.Add(processor);
			this._cachedProcessors = new Dictionary<Type, List<fsObjectProcessor>>();
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0002EDB0 File Offset: 0x0002CFB0
		public void RemoveProcessor<TProcessor>()
		{
			int i = 0;
			while (i < this._processors.Count)
			{
				if (this._processors[i] is TProcessor)
				{
					this._processors.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
			this._cachedProcessors = new Dictionary<Type, List<fsObjectProcessor>>();
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0002EDFF File Offset: 0x0002CFFF
		public void SetDefaultStorageType(Type abstractType, Type defaultStorageType)
		{
			if (!abstractType.Resolve().IsInterface && !abstractType.Resolve().IsAbstract)
			{
				throw new ArgumentException("|abstractType| must be an interface or abstract type");
			}
			this._abstractTypeRemap[abstractType] = defaultStorageType;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0002EE34 File Offset: 0x0002D034
		private List<fsObjectProcessor> GetProcessors(Type type)
		{
			fsObjectAttribute attribute = fsPortableReflection.GetAttribute<fsObjectAttribute>(type);
			List<fsObjectProcessor> list;
			if (attribute != null && attribute.Processor != null)
			{
				fsObjectProcessor item = (fsObjectProcessor)Activator.CreateInstance(attribute.Processor);
				list = new List<fsObjectProcessor>();
				list.Add(item);
				this._cachedProcessors[type] = list;
			}
			else if (!this._cachedProcessors.TryGetValue(type, out list))
			{
				list = new List<fsObjectProcessor>();
				for (int i = 0; i < this._processors.Count; i++)
				{
					fsObjectProcessor fsObjectProcessor = this._processors[i];
					if (fsObjectProcessor.CanProcess(type))
					{
						list.Add(fsObjectProcessor);
					}
				}
				this._cachedProcessors[type] = list;
			}
			return list;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0002EEE0 File Offset: 0x0002D0E0
		public void AddConverter(fsBaseConverter converter)
		{
			if (converter.Serializer != null)
			{
				throw new InvalidOperationException("Cannot add a single converter instance to multiple fsConverters -- please construct a new instance for " + ((converter != null) ? converter.ToString() : null));
			}
			if (converter is fsDirectConverter)
			{
				fsDirectConverter fsDirectConverter = (fsDirectConverter)converter;
				this._availableDirectConverters[fsDirectConverter.ModelType] = fsDirectConverter;
			}
			else
			{
				if (!(converter is fsConverter))
				{
					throw new InvalidOperationException("Unable to add converter " + ((converter != null) ? converter.ToString() : null) + "; the type association strategy is unknown. Please use either fsDirectConverter or fsConverter as your base type.");
				}
				this._availableConverters.Insert(0, (fsConverter)converter);
			}
			converter.Serializer = this;
			this._cachedConverters = new Dictionary<Type, fsBaseConverter>();
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0002EF88 File Offset: 0x0002D188
		private fsBaseConverter GetConverter(Type type, Type overrideConverterType)
		{
			if (overrideConverterType != null)
			{
				fsBaseConverter fsBaseConverter;
				if (!this._cachedConverterTypeInstances.TryGetValue(overrideConverterType, out fsBaseConverter))
				{
					fsBaseConverter = (fsBaseConverter)Activator.CreateInstance(overrideConverterType);
					fsBaseConverter.Serializer = this;
					this._cachedConverterTypeInstances[overrideConverterType] = fsBaseConverter;
				}
				return fsBaseConverter;
			}
			fsBaseConverter fsBaseConverter2;
			if (this._cachedConverters.TryGetValue(type, out fsBaseConverter2))
			{
				return fsBaseConverter2;
			}
			fsObjectAttribute attribute = fsPortableReflection.GetAttribute<fsObjectAttribute>(type);
			if (attribute != null && attribute.Converter != null)
			{
				fsBaseConverter2 = (fsBaseConverter)Activator.CreateInstance(attribute.Converter);
				fsBaseConverter2.Serializer = this;
				return this._cachedConverters[type] = fsBaseConverter2;
			}
			fsForwardAttribute attribute2 = fsPortableReflection.GetAttribute<fsForwardAttribute>(type);
			if (attribute2 != null)
			{
				fsBaseConverter2 = new fsForwardConverter(attribute2);
				fsBaseConverter2.Serializer = this;
				return this._cachedConverters[type] = fsBaseConverter2;
			}
			if (!this._cachedConverters.TryGetValue(type, out fsBaseConverter2))
			{
				if (this._availableDirectConverters.ContainsKey(type))
				{
					fsBaseConverter2 = this._availableDirectConverters[type];
					return this._cachedConverters[type] = fsBaseConverter2;
				}
				for (int i = 0; i < this._availableConverters.Count; i++)
				{
					if (this._availableConverters[i].CanProcess(type))
					{
						fsBaseConverter2 = this._availableConverters[i];
						return this._cachedConverters[type] = fsBaseConverter2;
					}
				}
			}
			throw new InvalidOperationException("Internal error -- could not find a converter for " + ((type != null) ? type.ToString() : null));
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0002F0F5 File Offset: 0x0002D2F5
		public fsResult TrySerialize<T>(T instance, out fsData data)
		{
			return this.TrySerialize(typeof(T), instance, out data);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0002F110 File Offset: 0x0002D310
		public fsResult TryDeserialize<T>(fsData data, ref T instance)
		{
			object obj = instance;
			fsResult result = this.TryDeserialize(data, typeof(T), ref obj);
			if (result.Succeeded)
			{
				instance = (T)((object)obj);
			}
			return result;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0002F153 File Offset: 0x0002D353
		public fsResult TrySerialize(Type storageType, object instance, out fsData data)
		{
			return this.TrySerialize(storageType, null, instance, out data);
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0002F160 File Offset: 0x0002D360
		public fsResult TrySerialize(Type storageType, Type overrideConverterType, object instance, out fsData data)
		{
			List<fsObjectProcessor> processors = this.GetProcessors((instance == null) ? storageType : instance.GetType());
			try
			{
				fsSerializer.Invoke_OnBeforeSerialize(processors, storageType, instance);
			}
			catch (Exception ex)
			{
				data = new fsData();
				return fsResult.Fail(ex.ToString());
			}
			if (instance == null)
			{
				data = new fsData();
				fsSerializer.Invoke_OnAfterSerialize(processors, storageType, instance, ref data);
				return fsResult.Success;
			}
			fsResult fsResult = this.InternalSerialize_1_ProcessCycles(storageType, overrideConverterType, instance, out data);
			try
			{
				fsSerializer.Invoke_OnAfterSerialize(processors, storageType, instance, ref data);
			}
			catch (Exception ex2)
			{
				fsResult += fsResult.Fail(ex2.ToString());
			}
			return fsResult;
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0002F208 File Offset: 0x0002D408
		private fsResult InternalSerialize_1_ProcessCycles(Type storageType, Type overrideConverterType, object instance, out fsData data)
		{
			fsResult result;
			try
			{
				this._references.Enter();
				if (!this.GetConverter(instance.GetType(), overrideConverterType).RequestCycleSupport(instance.GetType()))
				{
					result = this.InternalSerialize_2_Inheritance(storageType, overrideConverterType, instance, out data);
				}
				else if (this._references.IsReference(instance))
				{
					data = fsData.CreateDictionary();
					this._lazyReferenceWriter.WriteReference(this._references.GetReferenceId(instance), data.AsDictionary);
					result = fsResult.Success;
				}
				else
				{
					this._references.MarkSerialized(instance);
					fsResult fsResult = this.InternalSerialize_2_Inheritance(storageType, overrideConverterType, instance, out data);
					if (fsResult.Failed)
					{
						result = fsResult;
					}
					else
					{
						this._lazyReferenceWriter.WriteDefinition(this._references.GetReferenceId(instance), data);
						result = fsResult;
					}
				}
			}
			finally
			{
				if (this._references.Exit())
				{
					this._lazyReferenceWriter.Clear();
				}
			}
			return result;
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0002F2F8 File Offset: 0x0002D4F8
		private fsResult InternalSerialize_2_Inheritance(Type storageType, Type overrideConverterType, object instance, out fsData data)
		{
			fsResult result = this.InternalSerialize_3_ProcessVersioning(overrideConverterType, instance, out data);
			if (result.Failed)
			{
				return result;
			}
			if (storageType != instance.GetType() && this.GetConverter(storageType, overrideConverterType).RequestInheritanceSupport(storageType))
			{
				Type type = instance.GetType();
				if (instance is Object)
				{
					Type type2 = type;
					do
					{
						type = type2;
						type2 = type2.BaseType;
					}
					while (type2 != null && type != typeof(Object) && storageType.IsAssignableFrom(type2));
				}
				fsSerializer.EnsureDictionary(data);
				data.AsDictionary[fsSerializer.Key_InstanceType] = new fsData(RuntimeCodebase.SerializeType(type));
			}
			return result;
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0002F3A0 File Offset: 0x0002D5A0
		private fsResult InternalSerialize_3_ProcessVersioning(Type overrideConverterType, object instance, out fsData data)
		{
			fsOption<fsVersionedType> versionedType = fsVersionManager.GetVersionedType(instance.GetType());
			if (!versionedType.HasValue)
			{
				return this.InternalSerialize_4_Converter(overrideConverterType, instance, out data);
			}
			fsVersionedType value = versionedType.Value;
			fsResult result = this.InternalSerialize_4_Converter(overrideConverterType, instance, out data);
			if (result.Failed)
			{
				return result;
			}
			fsSerializer.EnsureDictionary(data);
			data.AsDictionary[fsSerializer.Key_Version] = new fsData(value.VersionString);
			return result;
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0002F410 File Offset: 0x0002D610
		private fsResult InternalSerialize_4_Converter(Type overrideConverterType, object instance, out fsData data)
		{
			Type type = instance.GetType();
			return this.GetConverter(type, overrideConverterType).TrySerialize(instance, out data, type);
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0002F434 File Offset: 0x0002D634
		public fsResult TryDeserialize(fsData data, Type storageType, ref object result)
		{
			return this.TryDeserialize(data, storageType, null, ref result);
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0002F440 File Offset: 0x0002D640
		public fsResult TryDeserialize(fsData data, Type storageType, Type overrideConverterType, ref object result)
		{
			if (data.IsNull)
			{
				result = null;
				List<fsObjectProcessor> processors = this.GetProcessors(storageType);
				fsSerializer.Invoke_OnBeforeDeserialize(processors, storageType, ref data);
				fsSerializer.Invoke_OnAfterDeserialize(processors, storageType, null);
				return fsResult.Success;
			}
			fsSerializer.ConvertLegacyData(ref data);
			fsResult result2;
			try
			{
				this._references.Enter();
				List<fsObjectProcessor> processors2;
				fsResult fsResult = this.InternalDeserialize_1_CycleReference(overrideConverterType, data, storageType, ref result, out processors2);
				if (fsResult.Succeeded)
				{
					try
					{
						fsSerializer.Invoke_OnAfterDeserialize(processors2, storageType, result);
					}
					catch (Exception ex)
					{
						fsResult += fsResult.Fail(ex.ToString());
					}
				}
				result2 = fsResult;
			}
			finally
			{
				this._references.Exit();
			}
			return result2;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0002F4F0 File Offset: 0x0002D6F0
		private fsResult InternalDeserialize_1_CycleReference(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor> processors)
		{
			if (fsSerializer.IsObjectReference(data))
			{
				int id = int.Parse(data.AsDictionary[fsSerializer.Key_ObjectReference].AsString);
				result = this._references.GetReferenceObject(id);
				processors = this.GetProcessors(result.GetType());
				return fsResult.Success;
			}
			return this.InternalDeserialize_2_Version(overrideConverterType, data, storageType, ref result, out processors);
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0002F554 File Offset: 0x0002D754
		private fsResult InternalDeserialize_2_Version(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor> processors)
		{
			if (fsSerializer.IsVersioned(data))
			{
				string asString = data.AsDictionary[fsSerializer.Key_Version].AsString;
				fsOption<fsVersionedType> versionedType = fsVersionManager.GetVersionedType(storageType);
				if (versionedType.HasValue && versionedType.Value.VersionString != asString)
				{
					fsResult fsResult = fsResult.Success;
					List<fsVersionedType> list;
					fsResult += fsVersionManager.GetVersionImportPath(asString, versionedType.Value, out list);
					if (fsResult.Failed)
					{
						processors = this.GetProcessors(storageType);
						return fsResult;
					}
					fsResult += this.InternalDeserialize_3_Inheritance(overrideConverterType, data, list[0].ModelType, ref result, out processors);
					if (fsResult.Failed)
					{
						return fsResult;
					}
					for (int i = 1; i < list.Count; i++)
					{
						result = list[i].Migrate(result);
					}
					if (fsSerializer.IsObjectDefinition(data))
					{
						int id = int.Parse(data.AsDictionary[fsSerializer.Key_ObjectDefinition].AsString);
						this._references.AddReferenceWithId(id, result);
					}
					processors = this.GetProcessors(fsResult.GetType());
					return fsResult;
				}
			}
			return this.InternalDeserialize_3_Inheritance(overrideConverterType, data, storageType, ref result, out processors);
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0002F68C File Offset: 0x0002D88C
		private fsResult InternalDeserialize_3_Inheritance(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor> processors)
		{
			fsResult fsResult = fsResult.Success;
			Type type = storageType;
			if (fsSerializer.IsTypeSpecified(data))
			{
				type = fsSerializer.GetDataType(ref data, storageType, ref fsResult);
			}
			this.RemapAbstractStorageTypeToDefaultType(ref type);
			processors = this.GetProcessors(type);
			if (fsResult.Failed)
			{
				return fsResult;
			}
			try
			{
				fsSerializer.Invoke_OnBeforeDeserialize(processors, storageType, ref data);
			}
			catch (Exception ex)
			{
				fsResult += fsResult.Fail(ex.ToString());
				return fsResult;
			}
			if (result == null || result.GetType() != type)
			{
				result = this.GetConverter(type, overrideConverterType).CreateInstance(data, type);
			}
			try
			{
				fsSerializer.Invoke_OnBeforeDeserializeAfterInstanceCreation(processors, storageType, result, ref data);
			}
			catch (Exception ex2)
			{
				fsResult += fsResult.Fail(ex2.ToString());
				return fsResult;
			}
			fsResult += this.InternalDeserialize_4_Cycles(overrideConverterType, data, type, ref result);
			return fsResult;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0002F778 File Offset: 0x0002D978
		private fsResult InternalDeserialize_4_Cycles(Type overrideConverterType, fsData data, Type resultType, ref object result)
		{
			if (fsSerializer.IsObjectDefinition(data))
			{
				int id = int.Parse(data.AsDictionary[fsSerializer.Key_ObjectDefinition].AsString);
				this._references.AddReferenceWithId(id, result);
			}
			return this.InternalDeserialize_5_Converter(overrideConverterType, data, resultType, ref result);
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0002F7C2 File Offset: 0x0002D9C2
		private fsResult InternalDeserialize_5_Converter(Type overrideConverterType, fsData data, Type resultType, ref object result)
		{
			if (fsSerializer.IsWrappedData(data))
			{
				data = data.AsDictionary[fsSerializer.Key_Content];
			}
			return this.GetConverter(resultType, overrideConverterType).TryDeserialize(data, ref result, resultType);
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0002F7F0 File Offset: 0x0002D9F0
		private static Type GetDataType(ref fsData data, Type defaultType, ref fsResult deserializeResult)
		{
			Dictionary<string, fsData> asDictionary = data.AsDictionary;
			fsData fsData = asDictionary[fsSerializer.Key_InstanceType];
			if (!fsData.IsString)
			{
				string key_InstanceType = fsSerializer.Key_InstanceType;
				string str = " value must be a string (in ";
				fsData fsData2 = data;
				deserializeResult.AddMessage(key_InstanceType + str + ((fsData2 != null) ? fsData2.ToString() : null) + ")");
				return defaultType;
			}
			string asString = fsData.AsString;
			Type type;
			if (!RuntimeCodebase.TryDeserializeType(asString, out type))
			{
				if (fsSerializer.IsVisualScriptingUnit(data))
				{
					asDictionary[fsSerializer.Key_UnitFormerValue] = new fsData(data.ToString());
					asDictionary[fsSerializer.Key_UnitFormerType] = fsData;
					asDictionary[fsSerializer.Key_InstanceType] = new fsData(fsSerializer.TypeName_MissingType);
					deserializeResult += fsResult.Warn(string.Concat(new string[]
					{
						"Type definition for '",
						asString,
						"' is missing.\nConverted '",
						asString,
						"' unit to '",
						fsSerializer.TypeName_MissingType,
						"'. Did you delete the type's script file?"
					}));
					return fsSerializer.Type_MissingType;
				}
				deserializeResult += fsResult.Warn("Unable to find type: \"" + asString + "\"");
				return defaultType;
			}
			else
			{
				if (asString == fsSerializer.TypeName_MissingType)
				{
					if (asDictionary.ContainsKey(fsSerializer.Key_UnitFormerType) && fsSerializer.IsVisualScriptingUnit(data))
					{
						string asString2 = asDictionary[fsSerializer.Key_UnitFormerType].AsString;
						Type type2;
						if (RuntimeCodebase.TryDeserializeType(asString2, out type2))
						{
							if (defaultType.IsAssignableFrom(type2))
							{
								if (asDictionary.ContainsKey(fsSerializer.Key_UnitFormerValue))
								{
									fsData value = asDictionary[fsSerializer.Key_UnitPosition];
									data = fsJsonParser.Parse(asDictionary[fsSerializer.Key_UnitFormerValue].AsString);
									asDictionary = data.AsDictionary;
									asDictionary[fsSerializer.Key_UnitPosition] = value;
									deserializeResult += fsResult.Warn(string.Concat(new string[]
									{
										"Missing unit type '",
										asString2,
										"' was found.\nConverted '",
										fsSerializer.TypeName_MissingType,
										"' unit back to '",
										asString2,
										"'"
									}));
								}
								else
								{
									asDictionary[fsSerializer.Key_InstanceType] = new fsData(asString2);
									fsResult a = deserializeResult;
									string[] array = new string[8];
									array[0] = "Missing unit type '";
									array[1] = asString2;
									array[2] = "' was found.\nConverted '";
									array[3] = fsSerializer.TypeName_MissingType;
									array[4] = "' unit back to '";
									array[5] = asString2;
									array[6] = "'\nNo former state can be found. Reverting node to defaults.\n";
									int num = 7;
									fsData fsData3 = data;
									array[num] = ((fsData3 != null) ? fsData3.ToString() : null);
									deserializeResult = a + fsResult.Warn(string.Concat(array));
								}
								return type2;
							}
							deserializeResult += fsResult.Warn(string.Concat(new string[]
							{
								"Missing unit type '",
								asString2,
								"' was found, but is not assignable to '",
								defaultType.FullName,
								"'. Did you forget to inherit from '",
								fsSerializer.TypeName_Unit,
								"'?"
							}));
						}
						else
						{
							deserializeResult += fsResult.Warn("Type definition for '" + asString2 + "' unit is missing. Did you remove its script file?");
						}
					}
					else
					{
						deserializeResult += fsResult.Warn("Serialized '" + fsSerializer.TypeName_MissingType + "' unit has an unrecognized format.");
					}
				}
				if (defaultType.IsAssignableFrom(type))
				{
					return type;
				}
				if (fsSerializer.IsVisualScriptingUnit(data))
				{
					asDictionary[fsSerializer.Key_UnitFormerType] = fsData;
					asDictionary[fsSerializer.Key_InstanceType] = new fsData(fsSerializer.TypeName_MissingType);
					deserializeResult += fsResult.Warn(string.Concat(new string[]
					{
						"Type '",
						asString,
						"' is no longer assignable to '",
						defaultType.FullName,
						"'. Did you remove inheritance from '",
						fsSerializer.TypeName_Unit,
						"'?\nConverted '",
						asString,
						"' unit to '",
						fsSerializer.TypeName_MissingType,
						"'."
					}));
					return fsSerializer.Type_MissingType;
				}
				string str2 = "Ignoring type specifier; a field/property of type ";
				string str3 = (defaultType != null) ? defaultType.ToString() : null;
				string str4 = " cannot hold an instance of ";
				Type type3 = type;
				deserializeResult.AddMessage(str2 + str3 + str4 + ((type3 != null) ? type3.ToString() : null));
				return defaultType;
			}
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0002FC28 File Offset: 0x0002DE28
		private static void EnsureDictionary(fsData data)
		{
			if (!data.IsDictionary)
			{
				fsData value = data.Clone();
				data.BecomeDictionary();
				data.AsDictionary[fsSerializer.Key_Content] = value;
			}
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0002FC5C File Offset: 0x0002DE5C
		static fsSerializer()
		{
			fsSerializer._reservedKeywords = new HashSet<string>
			{
				fsSerializer.Key_ObjectReference,
				fsSerializer.Key_ObjectDefinition,
				fsSerializer.Key_InstanceType,
				fsSerializer.Key_Version,
				fsSerializer.Key_Content
			};
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x0002FD77 File Offset: 0x0002DF77
		public static bool IsReservedKeyword(string key)
		{
			return fsSerializer._reservedKeywords.Contains(key);
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0002FD84 File Offset: 0x0002DF84
		private static bool IsObjectReference(fsData data)
		{
			return data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_ObjectReference);
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x0002FDA0 File Offset: 0x0002DFA0
		private static bool IsObjectDefinition(fsData data)
		{
			return data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_ObjectDefinition);
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0002FDBC File Offset: 0x0002DFBC
		private static bool IsVersioned(fsData data)
		{
			return data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_Version);
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0002FDD8 File Offset: 0x0002DFD8
		private static bool IsTypeSpecified(fsData data)
		{
			return data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_InstanceType);
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x0002FDF4 File Offset: 0x0002DFF4
		private static bool IsWrappedData(fsData data)
		{
			return data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_Content);
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0002FE10 File Offset: 0x0002E010
		private static bool IsVisualScriptingUnit(fsData data)
		{
			if (!data.IsDictionary)
			{
				return false;
			}
			Dictionary<string, fsData> asDictionary = data.AsDictionary;
			return asDictionary.ContainsKey(fsSerializer.Key_UnitDefault) && asDictionary.ContainsKey(fsSerializer.Key_UnitPosition) && asDictionary.ContainsKey(fsSerializer.Key_UnitGuid) && asDictionary[fsSerializer.Key_UnitPosition].AsDictionary.ContainsKey("x") && asDictionary[fsSerializer.Key_UnitPosition].AsDictionary.ContainsKey("y");
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0002FE90 File Offset: 0x0002E090
		public static void StripDeserializationMetadata(ref fsData data)
		{
			if (data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_Content))
			{
				data = data.AsDictionary[fsSerializer.Key_Content];
			}
			if (data.IsDictionary)
			{
				Dictionary<string, fsData> asDictionary = data.AsDictionary;
				asDictionary.Remove(fsSerializer.Key_ObjectReference);
				asDictionary.Remove(fsSerializer.Key_ObjectDefinition);
				asDictionary.Remove(fsSerializer.Key_InstanceType);
				asDictionary.Remove(fsSerializer.Key_Version);
			}
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x0002FF0C File Offset: 0x0002E10C
		private static void ConvertLegacyData(ref fsData data)
		{
			if (!data.IsDictionary)
			{
				return;
			}
			Dictionary<string, fsData> asDictionary = data.AsDictionary;
			if (asDictionary.Count > 2)
			{
				return;
			}
			string key = "ReferenceId";
			string key2 = "SourceId";
			string key3 = "Data";
			string key4 = "Type";
			string key5 = "Data";
			if (asDictionary.Count == 2 && asDictionary.ContainsKey(key4) && asDictionary.ContainsKey(key5))
			{
				data = asDictionary[key5];
				fsSerializer.EnsureDictionary(data);
				fsSerializer.ConvertLegacyData(ref data);
				data.AsDictionary[fsSerializer.Key_InstanceType] = asDictionary[key4];
				return;
			}
			if (asDictionary.Count == 2 && asDictionary.ContainsKey(key2) && asDictionary.ContainsKey(key3))
			{
				data = asDictionary[key3];
				fsSerializer.EnsureDictionary(data);
				fsSerializer.ConvertLegacyData(ref data);
				data.AsDictionary[fsSerializer.Key_ObjectDefinition] = asDictionary[key2];
				return;
			}
			if (asDictionary.Count == 1 && asDictionary.ContainsKey(key))
			{
				data = fsData.CreateDictionary();
				data.AsDictionary[fsSerializer.Key_ObjectReference] = asDictionary[key];
			}
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x00030020 File Offset: 0x0002E220
		private static void Invoke_OnBeforeSerialize(List<fsObjectProcessor> processors, Type storageType, object instance)
		{
			for (int i = 0; i < processors.Count; i++)
			{
				processors[i].OnBeforeSerialize(storageType, instance);
			}
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0003004C File Offset: 0x0002E24C
		private static void Invoke_OnAfterSerialize(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data)
		{
			for (int i = processors.Count - 1; i >= 0; i--)
			{
				processors[i].OnAfterSerialize(storageType, instance, ref data);
			}
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0003007C File Offset: 0x0002E27C
		private static void Invoke_OnBeforeDeserialize(List<fsObjectProcessor> processors, Type storageType, ref fsData data)
		{
			for (int i = 0; i < processors.Count; i++)
			{
				processors[i].OnBeforeDeserialize(storageType, ref data);
			}
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x000300A8 File Offset: 0x0002E2A8
		private static void Invoke_OnBeforeDeserializeAfterInstanceCreation(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data)
		{
			for (int i = 0; i < processors.Count; i++)
			{
				processors[i].OnBeforeDeserializeAfterInstanceCreation(storageType, instance, ref data);
			}
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x000300D8 File Offset: 0x0002E2D8
		private static void Invoke_OnAfterDeserialize(List<fsObjectProcessor> processors, Type storageType, object instance)
		{
			for (int i = processors.Count - 1; i >= 0; i--)
			{
				processors[i].OnAfterDeserialize(storageType, instance);
			}
		}

		// Token: 0x04000299 RID: 665
		private readonly List<fsConverter> _availableConverters;

		// Token: 0x0400029A RID: 666
		private readonly Dictionary<Type, fsDirectConverter> _availableDirectConverters;

		// Token: 0x0400029B RID: 667
		private readonly List<fsObjectProcessor> _processors;

		// Token: 0x0400029C RID: 668
		private readonly fsCyclicReferenceManager _references;

		// Token: 0x0400029D RID: 669
		private readonly fsSerializer.fsLazyCycleDefinitionWriter _lazyReferenceWriter;

		// Token: 0x0400029E RID: 670
		private readonly Dictionary<Type, Type> _abstractTypeRemap;

		// Token: 0x0400029F RID: 671
		private Dictionary<Type, fsBaseConverter> _cachedConverterTypeInstances;

		// Token: 0x040002A0 RID: 672
		private Dictionary<Type, fsBaseConverter> _cachedConverters;

		// Token: 0x040002A1 RID: 673
		private Dictionary<Type, List<fsObjectProcessor>> _cachedProcessors;

		// Token: 0x040002A2 RID: 674
		public fsContext Context;

		// Token: 0x040002A3 RID: 675
		public fsConfig Config;

		// Token: 0x040002A4 RID: 676
		private static HashSet<string> _reservedKeywords;

		// Token: 0x040002A5 RID: 677
		private static readonly string Key_ObjectReference = fsGlobalConfig.InternalFieldPrefix + "ref";

		// Token: 0x040002A6 RID: 678
		private static readonly string Key_ObjectDefinition = fsGlobalConfig.InternalFieldPrefix + "id";

		// Token: 0x040002A7 RID: 679
		private static readonly string Key_InstanceType = fsGlobalConfig.InternalFieldPrefix + "type";

		// Token: 0x040002A8 RID: 680
		private static readonly string Key_Version = fsGlobalConfig.InternalFieldPrefix + "version";

		// Token: 0x040002A9 RID: 681
		private static readonly string Key_Content = fsGlobalConfig.InternalFieldPrefix + "content";

		// Token: 0x040002AA RID: 682
		internal static readonly string Key_UnitDefault = "defaultValues";

		// Token: 0x040002AB RID: 683
		internal static readonly string Key_UnitPosition = "position";

		// Token: 0x040002AC RID: 684
		internal static readonly string Key_UnitGuid = "guid";

		// Token: 0x040002AD RID: 685
		internal static readonly string Key_UnitFormerType = "formerType";

		// Token: 0x040002AE RID: 686
		internal static readonly string Key_UnitFormerValue = "formerValue";

		// Token: 0x040002AF RID: 687
		internal static readonly string TypeName_Unit = "Unity.VisualScripting.Unit";

		// Token: 0x040002B0 RID: 688
		private static readonly Type Type_Unit = RuntimeCodebase.DeserializeType(fsSerializer.TypeName_Unit);

		// Token: 0x040002B1 RID: 689
		internal static readonly string TypeName_MissingType = "Unity.VisualScripting.MissingType";

		// Token: 0x040002B2 RID: 690
		private static readonly Type Type_MissingType = RuntimeCodebase.DeserializeType(fsSerializer.TypeName_MissingType);

		// Token: 0x02000220 RID: 544
		internal class fsLazyCycleDefinitionWriter
		{
			// Token: 0x0600131F RID: 4895 RVA: 0x00039137 File Offset: 0x00037337
			public void WriteDefinition(int id, fsData data)
			{
				if (this._references.Contains(id))
				{
					fsSerializer.EnsureDictionary(data);
					data.AsDictionary[fsSerializer.Key_ObjectDefinition] = new fsData(id.ToString());
					return;
				}
				this._pendingDefinitions[id] = data;
			}

			// Token: 0x06001320 RID: 4896 RVA: 0x00039178 File Offset: 0x00037378
			public void WriteReference(int id, Dictionary<string, fsData> dict)
			{
				if (this._pendingDefinitions.ContainsKey(id))
				{
					fsData fsData = this._pendingDefinitions[id];
					fsSerializer.EnsureDictionary(fsData);
					fsData.AsDictionary[fsSerializer.Key_ObjectDefinition] = new fsData(id.ToString());
					this._pendingDefinitions.Remove(id);
				}
				else
				{
					this._references.Add(id);
				}
				dict[fsSerializer.Key_ObjectReference] = new fsData(id.ToString());
			}

			// Token: 0x06001321 RID: 4897 RVA: 0x000391F3 File Offset: 0x000373F3
			public void Clear()
			{
				this._pendingDefinitions.Clear();
				this._references.Clear();
			}

			// Token: 0x040009E0 RID: 2528
			private Dictionary<int, fsData> _pendingDefinitions = new Dictionary<int, fsData>();

			// Token: 0x040009E1 RID: 2529
			private HashSet<int> _references = new HashSet<int>();
		}
	}
}
