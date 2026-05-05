using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000351 RID: 849
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public class vHideInInspectorAttribute : PropertyAttribute
	{
		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06001156 RID: 4438 RVA: 0x0005DCA8 File Offset: 0x0005BEA8
		// (set) Token: 0x06001157 RID: 4439 RVA: 0x0005DCB0 File Offset: 0x0005BEB0
		public bool hideProperty { get; set; }

		// Token: 0x06001158 RID: 4440 RVA: 0x0005DCB9 File Offset: 0x0005BEB9
		public vHideInInspectorAttribute(string refbooleanProperty, bool invertValue = false)
		{
			this.refbooleanProperty = refbooleanProperty;
			this.invertValue = invertValue;
		}

		// Token: 0x04001752 RID: 5970
		public string refbooleanProperty;

		// Token: 0x04001753 RID: 5971
		public bool invertValue;
	}
}
