using System;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x02000402 RID: 1026
	public class vMousePositionHandler : MonoBehaviour
	{
		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x060014F3 RID: 5363 RVA: 0x0006D1E4 File Offset: 0x0006B3E4
		public static vMousePositionHandler Instance
		{
			get
			{
				if (vMousePositionHandler._instance == null)
				{
					vMousePositionHandler._instance = Object.FindObjectOfType<vMousePositionHandler>();
				}
				if (vMousePositionHandler._instance == null)
				{
					vMousePositionHandler._instance = new GameObject("MousePositionHandler").AddComponent<vMousePositionHandler>();
					vMousePositionHandler._instance.mainCamera = Camera.main;
				}
				return vMousePositionHandler._instance;
			}
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x0006D23D File Offset: 0x0006B43D
		public virtual void SetMousePosition(Vector2 pos)
		{
			this.joystickMousePos = pos;
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x060014F5 RID: 5365 RVA: 0x0006D248 File Offset: 0x0006B448
		public virtual Vector2 mousePosition
		{
			get
			{
				switch (vInput.instance.inputDevice)
				{
				case InputDevice.MouseKeyboard:
					return Input.mousePosition;
				case InputDevice.Joystick:
				{
					this.joystickMousePos.x = this.joystickMousePos.x + Input.GetAxis("RightAnalogHorizontal") * this.joystickSensitivity;
					this.joystickMousePos.x = Mathf.Clamp(this.joystickMousePos.x, -((float)Screen.width * 0.5f), (float)Screen.width * 0.5f);
					this.joystickMousePos.y = this.joystickMousePos.y + Input.GetAxis("RightAnalogVertical") * this.joystickSensitivity;
					this.joystickMousePos.y = Mathf.Clamp(this.joystickMousePos.y, -((float)Screen.height * 0.5f), (float)Screen.height * 0.5f);
					Vector2 b = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
					Vector2 vector = this.joystickMousePos + b;
					vector.x = Mathf.Clamp(vector.x, 0f, (float)Screen.width);
					vector.y = Mathf.Clamp(vector.y, 0f, (float)Screen.height);
					return vector;
				}
				case InputDevice.Mobile:
					if (this.clampScreen)
					{
						return Input.GetTouch(0).deltaPosition;
					}
					return this.joystickMousePos;
				default:
					return Input.mousePosition;
				}
			}
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x0006D3BC File Offset: 0x0006B5BC
		public virtual Vector3 WorldMousePosition(LayerMask castLayer, out Collider collider)
		{
			if (!this.mainCamera)
			{
				if (!Camera.main)
				{
					Debug.LogWarning("Trying to get the world mouse position but a MainCamera is missing from the scene");
					collider = null;
					return Vector3.zero;
				}
				this.mainCamera = Camera.main;
				collider = null;
				return Vector3.zero;
			}
			else
			{
				Ray ray = this.mainCamera.ScreenPointToRay(this.mousePosition);
				RaycastHit raycastHit;
				if (Physics.Raycast(ray, out raycastHit, this.mainCamera.farClipPlane, castLayer))
				{
					collider = raycastHit.collider;
					return raycastHit.point;
				}
				collider = null;
				return ray.GetPoint(this.mainCamera.farClipPlane);
			}
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x0006D464 File Offset: 0x0006B664
		public virtual bool CastWorldMousePosition(LayerMask castLayer, out RaycastHit hit, float distance = 0f)
		{
			if (!this.mainCamera)
			{
				if (!Camera.main)
				{
					Debug.LogWarning("Trying to get the world mouse position but a MainCamera is missing from the scene");
					hit = default(RaycastHit);
					return false;
				}
				this.mainCamera = Camera.main;
				hit = default(RaycastHit);
				return false;
			}
			else
			{
				if (Physics.Raycast(this.mainCamera.ScreenPointToRay(this.mousePosition), out hit, (distance == 0f) ? this.mainCamera.farClipPlane : distance, castLayer))
				{
					return true;
				}
				hit = default(RaycastHit);
				return false;
			}
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x0006D4F8 File Offset: 0x0006B6F8
		public virtual bool CastWorldMousePosition(LayerMask castLayer, out RaycastHit hit, float distance = 0f, float radius = 0f)
		{
			if (!this.mainCamera)
			{
				if (!Camera.main)
				{
					Debug.LogWarning("Trying to get the world mouse position but a MainCamera is missing from the scene");
					hit = default(RaycastHit);
					return false;
				}
				this.mainCamera = Camera.main;
				hit = default(RaycastHit);
				return false;
			}
			else
			{
				if (radius == 0f)
				{
					return this.CastWorldMousePosition(castLayer, out hit, distance);
				}
				if (Physics.SphereCast(this.mainCamera.ScreenPointToRay(this.mousePosition), radius, out hit, (distance == 0f) ? this.mainCamera.farClipPlane : distance, castLayer))
				{
					return true;
				}
				hit = default(RaycastHit);
				return false;
			}
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x0006D5A0 File Offset: 0x0006B7A0
		public virtual Vector3 WorldMousePosition(LayerMask castLayer)
		{
			if (!this.mainCamera)
			{
				if (!Camera.main)
				{
					Debug.LogWarning("Trying to get the world mouse position but a MainCamera is missing from the scene");
					return Vector3.zero;
				}
				this.mainCamera = Camera.main;
				return Vector3.zero;
			}
			else
			{
				Ray ray = this.mainCamera.ScreenPointToRay(this.mousePosition);
				RaycastHit raycastHit;
				if (Physics.Raycast(ray, out raycastHit, this.mainCamera.farClipPlane, castLayer))
				{
					return raycastHit.point;
				}
				return ray.GetPoint(this.mainCamera.farClipPlane);
			}
		}

		// Token: 0x04001AB5 RID: 6837
		public Camera mainCamera;

		// Token: 0x04001AB6 RID: 6838
		protected static vMousePositionHandler _instance;

		// Token: 0x04001AB7 RID: 6839
		public string joystickHorizontalAxis = "RightAnalogHorizontal";

		// Token: 0x04001AB8 RID: 6840
		public string joystickVerticalAxis = "RightAnalogVertical";

		// Token: 0x04001AB9 RID: 6841
		public float joystickSensitivity = 25f;

		// Token: 0x04001ABA RID: 6842
		public bool clampScreen = true;

		// Token: 0x04001ABB RID: 6843
		public Vector2 joystickMousePos;
	}
}
