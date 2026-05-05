using System;
using Rewired;
using Rewired.Utils.Classes.Data;

// Token: 0x0200051E RID: 1310
internal sealed class RvmIJGbAvRTGQGQgDEFpplYzZpWu<\u0001> where \u0001 : class
{
	// Token: 0x06003603 RID: 13827 RVA: 0x0002A495 File Offset: 0x00028695
	public RvmIJGbAvRTGQGQgDEFpplYzZpWu()
	{
		this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE = new IndexedDictionary<uint, WeakReference>();
		this.AknyEaBIZQFXJFyVOKTiaRHpCaXCb = 1U;
	}

	// Token: 0x06003604 RID: 13828 RVA: 0x0002A4B4 File Offset: 0x000286B4
	public RvmIJGbAvRTGQGQgDEFpplYzZpWu(float A_1) : this()
	{
		this.KuqBQrmPsQCVYMfBQTIgokSgzeCk = A_1;
	}

	// Token: 0x06003605 RID: 13829 RVA: 0x000B623C File Offset: 0x000B443C
	public bool LQUfTFJcfMkEiTtKGHpsBWtdOAXBb(uint A_1, out \u0001 A_2)
	{
		WeakReference weakReference;
		if (!this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE.TryGetValue(A_1, out weakReference))
		{
			A_2 = default(\u0001);
			return false;
		}
		\u0001 u;
		if ((u = (weakReference.Target as \u0001)) == null)
		{
			this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE.Remove(A_1);
			A_2 = default(\u0001);
			return false;
		}
		A_2 = u;
		return true;
	}

	// Token: 0x06003606 RID: 13830 RVA: 0x000B629C File Offset: 0x000B449C
	public uint aMahfZqbBrbegzXkZEXwZfqhtBZj(\u0001 A_1)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException();
		}
		this.CeGMVVoIDiGIvcEetdCFZflALaiKA();
		this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE.SetValue(this.AknyEaBIZQFXJFyVOKTiaRHpCaXCb.id, new WeakReference(A_1, false));
		this.AknyEaBIZQFXJFyVOKTiaRHpCaXCb.Increment();
		return this.AknyEaBIZQFXJFyVOKTiaRHpCaXCb.id;
	}

	// Token: 0x06003607 RID: 13831 RVA: 0x0002A4C3 File Offset: 0x000286C3
	public bool rzTgCniDYAFMijOABRyLzSxcXWZjB(uint A_1)
	{
		this.CeGMVVoIDiGIvcEetdCFZflALaiKA();
		return this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE.Remove(A_1);
	}

	// Token: 0x06003608 RID: 13832 RVA: 0x000B62F8 File Offset: 0x000B44F8
	public void JzGoTFqpGdYkTUxcryLnTUHbIotE()
	{
		for (int i = this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE.Count - 1; i >= 0; i--)
		{
			if (!this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE[i].IsAlive)
			{
				this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE.RemoveAt(i);
			}
		}
		this.VBTadPtLkUMFYLjcpLkVEkubKPpb = ReInput.unscaledTime + (double)this.KuqBQrmPsQCVYMfBQTIgokSgzeCk;
	}

	// Token: 0x06003609 RID: 13833 RVA: 0x000B6350 File Offset: 0x000B4550
	public void zAXkItAZChRgPbCJeFkkCtqIPkzMA(Action<\u0001> A_1)
	{
		for (int i = this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE.Count - 1; i >= 0; i--)
		{
			\u0001 obj;
			if ((obj = (this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE[i].Target as \u0001)) == null)
			{
				this.BBVDJCUhKZHfIqsrNqHFvrVOmSLE.RemoveAt(i);
			}
			else
			{
				A_1(obj);
			}
		}
		this.VBTadPtLkUMFYLjcpLkVEkubKPpb = ReInput.unscaledTime + (double)this.KuqBQrmPsQCVYMfBQTIgokSgzeCk;
	}

	// Token: 0x0600360A RID: 13834 RVA: 0x0002A4D7 File Offset: 0x000286D7
	private void CeGMVVoIDiGIvcEetdCFZflALaiKA()
	{
		if (this.KuqBQrmPsQCVYMfBQTIgokSgzeCk <= 0f)
		{
			return;
		}
		if (ReInput.unscaledTime > this.VBTadPtLkUMFYLjcpLkVEkubKPpb)
		{
			this.JzGoTFqpGdYkTUxcryLnTUHbIotE();
		}
	}

	// Token: 0x04001C76 RID: 7286
	private readonly IndexedDictionary<uint, WeakReference> BBVDJCUhKZHfIqsrNqHFvrVOmSLE;

	// Token: 0x04001C77 RID: 7287
	private Id AknyEaBIZQFXJFyVOKTiaRHpCaXCb;

	// Token: 0x04001C78 RID: 7288
	private double VBTadPtLkUMFYLjcpLkVEkubKPpb;

	// Token: 0x04001C79 RID: 7289
	private float KuqBQrmPsQCVYMfBQTIgokSgzeCk;
}
