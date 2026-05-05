using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200000B RID: 11
public class MobileControl : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
{
	// Token: 0x06000020 RID: 32 RVA: 0x00002AC4 File Offset: 0x00000CC4
	private void Awake()
	{
		Application.targetFrameRate = 60;
		this.analogLeft = base.transform.Find("AnalogLeft").gameObject;
		this.lookDirection = base.transform.Find("LookDirection").gameObject;
		this.camLook = this.player.transform.Find("Camera").gameObject;
		this.rectTransform = base.transform.GetComponent<RectTransform>();
		this.imgAnalog = this.analogLeft.GetComponent<Image>();
		this.joystickImgAnalog = this.analogLeft.transform.GetChild(0).GetComponent<Image>();
		this.imgLook = this.lookDirection.GetComponent<Image>();
		this.joystickImgLook = this.lookDirection.transform.GetChild(0).GetComponent<Image>();
		this.charController = this.player.GetComponent<CharacterController>();
		this.xyBase = new Vector2(this.camLook.transform.localRotation.eulerAngles.x, this.player.transform.localRotation.eulerAngles.y);
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00002BF0 File Offset: 0x00000DF0
	private void Update()
	{
		Vector2 vector = new Vector2(this.inputVectorLook.z, this.inputVectorLook.x);
		this.camLook.transform.localRotation = Quaternion.Euler(this.xyBase.x + vector.x * -60f, 0f, 0f);
		this.player.transform.rotation = Quaternion.Euler(0f, this.xyBase.y + vector.y * 180f, 0f);
		Vector2 vector2 = new Vector2(this.inputVectorAnalogic.z, this.inputVectorAnalogic.x);
		Vector3 a = this.player.transform.forward * vector2.x;
		Vector3 b = this.player.transform.right * vector2.y;
		this.charController.SimpleMove(Vector3.ClampMagnitude(a + b, 1f) * (Input.GetKey(KeyCode.LeftShift) ? (this.speed * 2f) : this.speed));
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002D20 File Offset: 0x00000F20
	public virtual void OnDrag(PointerEventData ped)
	{
		bool flag = ped.position.x > (float)(Screen.width / 2);
		Vector2 vector;
		if (!flag)
		{
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(this.imgAnalog.rectTransform, ped.position, ped.pressEventCamera, out vector))
			{
				vector.x = (vector.x - this.imgAnalog.rectTransform.rect.width / 2f) / this.imgAnalog.rectTransform.sizeDelta.x;
				vector.y = (vector.y + this.imgAnalog.rectTransform.rect.height / 2f) / this.imgAnalog.rectTransform.sizeDelta.y;
				this.inputVectorAnalogic = new Vector3(vector.x * 2f + 1f, 0f, vector.y * 2f - 1f);
				this.inputVectorAnalogic = ((this.inputVectorAnalogic.magnitude > 1f) ? this.inputVectorAnalogic.normalized : this.inputVectorAnalogic);
				this.joystickImgAnalog.rectTransform.anchoredPosition = new Vector3(this.inputVectorAnalogic.x * (this.imgAnalog.rectTransform.sizeDelta.x / 3f), this.inputVectorAnalogic.z * (this.imgAnalog.rectTransform.sizeDelta.y / 3f));
				return;
			}
		}
		else if (flag && RectTransformUtility.ScreenPointToLocalPointInRectangle(this.imgLook.rectTransform, ped.position, ped.pressEventCamera, out vector))
		{
			vector.x = (vector.x - this.imgLook.rectTransform.rect.width / 2f) / this.imgLook.rectTransform.sizeDelta.x;
			vector.y = (vector.y + this.imgLook.rectTransform.rect.height / 2f) / this.imgLook.rectTransform.sizeDelta.y;
			this.inputVectorLook = new Vector3(vector.x * 2f + 1f, 0f, vector.y * 2f - 1f);
			this.inputVectorLook = ((this.inputVectorLook.magnitude > 1f) ? this.inputVectorLook.normalized : this.inputVectorLook);
			this.joystickImgLook.rectTransform.anchoredPosition = new Vector3(this.inputVectorLook.x * (this.imgLook.rectTransform.sizeDelta.x / 3f), this.inputVectorLook.z * (this.imgLook.rectTransform.sizeDelta.y / 3f));
		}
	}

	// Token: 0x06000023 RID: 35 RVA: 0x0000302C File Offset: 0x0000122C
	public virtual void OnPointerDown(PointerEventData ped)
	{
		bool flag = ped.position.x > (float)(Screen.width / 2);
		if ((flag && this.toqueLook) || (!flag && this.toqueAnalogic))
		{
			return;
		}
		Vector2 vector;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(base.transform.GetComponent<Image>().rectTransform, ped.position, ped.pressEventCamera, out vector))
		{
			vector.x += this.rectTransform.sizeDelta.x / 2f;
			vector.y += this.rectTransform.sizeDelta.y / 2f;
			vector.x *= this.rectTransform.localScale.x;
			vector.y *= this.rectTransform.localScale.y;
			flag = (vector.x > (float)(Screen.width / 2));
			if (flag && !this.toqueLook)
			{
				this.toqueLook = true;
				this.xyBase = new Vector2(this.camLook.transform.localRotation.eulerAngles.x, this.player.transform.localRotation.eulerAngles.y);
				this.imgLook.transform.position = vector;
				this.OnDrag(ped);
				return;
			}
			if (!flag && !this.toqueAnalogic)
			{
				this.toqueAnalogic = true;
				this.imgAnalog.transform.position = vector;
				this.OnDrag(ped);
			}
		}
	}

	// Token: 0x06000024 RID: 36 RVA: 0x000031BC File Offset: 0x000013BC
	public virtual void OnPointerUp(PointerEventData ped)
	{
		if (ped.position.x <= (float)(Screen.width / 2))
		{
			this.inputVectorAnalogic = Vector3.zero;
			this.toqueAnalogic = false;
			this.joystickImgAnalog.rectTransform.anchoredPosition = Vector3.zero;
			return;
		}
		this.toqueLook = false;
	}

	// Token: 0x04000033 RID: 51
	private bool toqueAnalogic;

	// Token: 0x04000034 RID: 52
	private bool toqueLook;

	// Token: 0x04000035 RID: 53
	private GameObject analogLeft;

	// Token: 0x04000036 RID: 54
	private GameObject lookDirection;

	// Token: 0x04000037 RID: 55
	public GameObject player;

	// Token: 0x04000038 RID: 56
	private GameObject camLook;

	// Token: 0x04000039 RID: 57
	private Image imgAnalog;

	// Token: 0x0400003A RID: 58
	private Image imgLook;

	// Token: 0x0400003B RID: 59
	private Image joystickImgAnalog;

	// Token: 0x0400003C RID: 60
	private Image joystickImgLook;

	// Token: 0x0400003D RID: 61
	private Vector3 inputVectorAnalogic;

	// Token: 0x0400003E RID: 62
	private Vector3 inputVectorLook;

	// Token: 0x0400003F RID: 63
	public float speed = 10f;

	// Token: 0x04000040 RID: 64
	private float straffe;

	// Token: 0x04000041 RID: 65
	private float translation;

	// Token: 0x04000042 RID: 66
	private RectTransform rectTransform;

	// Token: 0x04000043 RID: 67
	private Vector2 xyBase;

	// Token: 0x04000044 RID: 68
	private CharacterController charController;
}
