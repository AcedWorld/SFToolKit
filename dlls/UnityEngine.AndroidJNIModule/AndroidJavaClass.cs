using System;

namespace UnityEngine
{
	// Token: 0x02000008 RID: 8
	public class AndroidJavaClass : AndroidJavaObject
	{
		// Token: 0x0600005A RID: 90 RVA: 0x00004AD1 File Offset: 0x00002CD1
		public AndroidJavaClass(string className)
		{
			this._AndroidJavaClass(className);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004AE4 File Offset: 0x00002CE4
		private void _AndroidJavaClass(string className)
		{
			base.DebugPrint("Creating AndroidJavaClass from " + className);
			IntPtr intPtr = AndroidJNISafe.FindClass(className.Replace('.', '/'));
			this.m_jclass = new GlobalJavaObjectRef(intPtr);
			this.m_jobject = null;
			AndroidJNISafe.DeleteLocalRef(intPtr);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004B30 File Offset: 0x00002D30
		internal AndroidJavaClass(IntPtr jclass)
		{
			bool flag = jclass == IntPtr.Zero;
			if (flag)
			{
				throw new Exception("JNI: Init'd AndroidJavaClass with null ptr!");
			}
			this.m_jclass = new GlobalJavaObjectRef(jclass);
			this.m_jobject = null;
		}
	}
}
