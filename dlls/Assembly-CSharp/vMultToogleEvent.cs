using System;
using System.Collections.Generic;
using Invector;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000036 RID: 54
[vClassHeader("Mult-Toggle Event", true, "icon_v2", false, "", helpBoxText = "Use the method SetToggleOn/Off via Events", openClose = false)]
public class vMultToogleEvent : vMonoBehaviour
{
	// Token: 0x060000B8 RID: 184 RVA: 0x0000828D File Offset: 0x0000648D
	public void Start()
	{
		this.CheckValidation();
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00008295 File Offset: 0x00006495
	public void ToogleOn(int index)
	{
		if (this.toogles.Count > 0 && index < this.toogles.Count)
		{
			this.toogles[index].ToogleOn();
			this.CheckValidation();
		}
	}

	// Token: 0x060000BA RID: 186 RVA: 0x000082CA File Offset: 0x000064CA
	public void ToogleOff(int index)
	{
		if (this.toogles.Count > 0 && index < this.toogles.Count)
		{
			this.toogles[index].ToogleOff();
			this.CheckValidation();
		}
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00008300 File Offset: 0x00006500
	public void ToogleOn(string name)
	{
		vMultToogleEvent.Toogle toogle = this.toogles.Find((vMultToogleEvent.Toogle t) => t.name.Equals(name));
		if (toogle != null)
		{
			toogle.ToogleOn();
			this.CheckValidation();
		}
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00008344 File Offset: 0x00006544
	public void ToogleOff(string name)
	{
		vMultToogleEvent.Toogle toogle = this.toogles.Find((vMultToogleEvent.Toogle t) => t.name.Equals(name));
		if (toogle != null)
		{
			toogle.ToogleOff();
			this.CheckValidation();
		}
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00008388 File Offset: 0x00006588
	private void CheckValidation()
	{
		bool flag = this.isValid;
		flag = (this.toogles.FindAll((vMultToogleEvent.Toogle t) => t.isValid).Count == this.toogles.Count);
		if (flag != this.isValid)
		{
			this.isValid = flag;
			if (this.isValid)
			{
				this.onValidate.Invoke();
				return;
			}
			this.onInvalidate.Invoke();
		}
	}

	// Token: 0x04000108 RID: 264
	public List<vMultToogleEvent.Toogle> toogles;

	// Token: 0x04000109 RID: 265
	public bool isValid;

	// Token: 0x0400010A RID: 266
	public UnityEvent onValidate;

	// Token: 0x0400010B RID: 267
	public UnityEvent onInvalidate;

	// Token: 0x02000037 RID: 55
	[Serializable]
	public class Toogle
	{
		// Token: 0x060000BF RID: 191 RVA: 0x0000840D File Offset: 0x0000660D
		public void ToogleOn()
		{
			this.value = true;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00008416 File Offset: 0x00006616
		public void ToogleOff()
		{
			this.value = false;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000841F File Offset: 0x0000661F
		public bool isValid
		{
			get
			{
				return this.value.Equals(this.validation);
			}
		}

		// Token: 0x0400010C RID: 268
		public string name;

		// Token: 0x0400010D RID: 269
		[Header("Current Value of the toogle")]
		public bool value;

		// Token: 0x0400010E RID: 270
		[Header("Validation to compare with value")]
		public bool validation;
	}
}
