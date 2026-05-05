using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000193 RID: 403
	public class AOVRequestBuilder : IDisposable
	{
		// Token: 0x06000C89 RID: 3209 RVA: 0x00068850 File Offset: 0x00066A50
		public AOVRequestBuilder Add(AOVRequest settings, AOVRequestBufferAllocator bufferAllocator, List<GameObject> includedLightList, AOVBuffers[] aovBuffers, FramePassCallback callback)
		{
			List<AOVRequestData> list;
			if ((list = this.m_AOVRequestDataData) == null)
			{
				list = (this.m_AOVRequestDataData = ListPool<AOVRequestData>.Get());
			}
			list.Add(new AOVRequestData(settings, bufferAllocator, includedLightList, aovBuffers, callback));
			return this;
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x00068888 File Offset: 0x00066A88
		public AOVRequestBuilder Add(AOVRequest settings, AOVRequestBufferAllocator bufferAllocator, List<GameObject> includedLightList, AOVBuffers[] aovBuffers, CustomPassAOVBuffers[] customPassAovBuffers, AOVRequestCustomPassBufferAllocator customPassbufferAllocator, FramePassCallbackEx callback)
		{
			List<AOVRequestData> list;
			if ((list = this.m_AOVRequestDataData) == null)
			{
				list = (this.m_AOVRequestDataData = ListPool<AOVRequestData>.Get());
			}
			list.Add(new AOVRequestData(settings, bufferAllocator, includedLightList, aovBuffers, customPassAovBuffers, customPassbufferAllocator, callback));
			return this;
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x000688C3 File Offset: 0x00066AC3
		public AOVRequestDataCollection Build()
		{
			AOVRequestDataCollection result = new AOVRequestDataCollection(this.m_AOVRequestDataData);
			this.m_AOVRequestDataData = null;
			return result;
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x000688D7 File Offset: 0x00066AD7
		public void Dispose()
		{
			if (this.m_AOVRequestDataData == null)
			{
				return;
			}
			ListPool<AOVRequestData>.Release(this.m_AOVRequestDataData);
			this.m_AOVRequestDataData = null;
		}

		// Token: 0x040013B8 RID: 5048
		private List<AOVRequestData> m_AOVRequestDataData;
	}
}
