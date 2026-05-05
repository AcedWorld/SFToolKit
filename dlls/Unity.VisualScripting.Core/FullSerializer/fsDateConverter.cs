using System;
using System.Globalization;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200017A RID: 378
	public class fsDateConverter : fsConverter
	{
		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000A15 RID: 2581 RVA: 0x00029CD1 File Offset: 0x00027ED1
		private string DateTimeFormatString
		{
			get
			{
				return this.Serializer.Config.CustomDateTimeFormatString ?? "o";
			}
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00029CEC File Offset: 0x00027EEC
		public override bool CanProcess(Type type)
		{
			return type == typeof(DateTime) || type == typeof(DateTimeOffset) || type == typeof(TimeSpan);
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00029D24 File Offset: 0x00027F24
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			if (instance is DateTime)
			{
				serialized = new fsData(((DateTime)instance).ToString(this.DateTimeFormatString));
				return fsResult.Success;
			}
			if (instance is DateTimeOffset)
			{
				serialized = new fsData(((DateTimeOffset)instance).ToString("o"));
				return fsResult.Success;
			}
			if (instance is TimeSpan)
			{
				serialized = new fsData(((TimeSpan)instance).ToString());
				return fsResult.Success;
			}
			throw new InvalidOperationException("FullSerializer Internal Error -- Unexpected serialization type");
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00029DB8 File Offset: 0x00027FB8
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (!data.IsString)
			{
				return fsResult.Fail("Date deserialization requires a string, not " + data.Type.ToString());
			}
			if (storageType == typeof(DateTime))
			{
				DateTime dateTime;
				if (DateTime.TryParse(data.AsString, null, DateTimeStyles.RoundtripKind, out dateTime))
				{
					instance = dateTime;
					return fsResult.Success;
				}
				if (fsGlobalConfig.AllowInternalExceptions)
				{
					try
					{
						instance = Convert.ToDateTime(data.AsString);
						return fsResult.Success;
					}
					catch (Exception ex)
					{
						string str = "Unable to parse ";
						string asString = data.AsString;
						string str2 = " into a DateTime; got exception ";
						Exception ex2 = ex;
						return fsResult.Fail(str + asString + str2 + ((ex2 != null) ? ex2.ToString() : null));
					}
				}
				return fsResult.Fail("Unable to parse " + data.AsString + " into a DateTime");
			}
			else if (storageType == typeof(DateTimeOffset))
			{
				DateTimeOffset dateTimeOffset;
				if (DateTimeOffset.TryParse(data.AsString, null, DateTimeStyles.RoundtripKind, out dateTimeOffset))
				{
					instance = dateTimeOffset;
					return fsResult.Success;
				}
				return fsResult.Fail("Unable to parse " + data.AsString + " into a DateTimeOffset");
			}
			else
			{
				if (!(storageType == typeof(TimeSpan)))
				{
					throw new InvalidOperationException("FullSerializer Internal Error -- Unexpected deserialization type");
				}
				TimeSpan timeSpan;
				if (TimeSpan.TryParse(data.AsString, out timeSpan))
				{
					instance = timeSpan;
					return fsResult.Success;
				}
				return fsResult.Fail("Unable to parse " + data.AsString + " into a TimeSpan");
			}
		}

		// Token: 0x0400025C RID: 604
		private const string DefaultDateTimeFormatString = "o";

		// Token: 0x0400025D RID: 605
		private const string DateTimeOffsetFormatString = "o";
	}
}
