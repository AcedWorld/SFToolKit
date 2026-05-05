using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using Rewired.Data;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	// Token: 0x020003DD RID: 989
	[DisallowMultipleComponent]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[AddComponentMenu("Rewired/Component Controls/Custom Controller")]
	[Serializable]
	public class CustomController : ComponentController
	{
		// Token: 0x1400003C RID: 60
		// (add) Token: 0x06002796 RID: 10134 RVA: 0x0001D995 File Offset: 0x0001BB95
		// (remove) Token: 0x06002797 RID: 10135 RVA: 0x0001D9AE File Offset: 0x0001BBAE
		internal event Action InputSourceUpdateEvent
		{
			add
			{
				this.oEypczzqSIOXJyQKjWSioujNiEAc = (Action)Delegate.Combine(this.oEypczzqSIOXJyQKjWSioujNiEAc, value);
			}
			remove
			{
				this.oEypczzqSIOXJyQKjWSioujNiEAc = (Action)Delegate.Remove(this.oEypczzqSIOXJyQKjWSioujNiEAc, value);
			}
		}

		// Token: 0x17000950 RID: 2384
		// (get) Token: 0x06002798 RID: 10136 RVA: 0x0001D9C7 File Offset: 0x0001BBC7
		// (set) Token: 0x06002799 RID: 10137 RVA: 0x0001D9CF File Offset: 0x0001BBCF
		public InputManager_Base rewiredInputManager
		{
			get
			{
				return this._rewiredInputManager;
			}
			set
			{
				if (this._rewiredInputManager == value)
				{
					return;
				}
				this._rewiredInputManager = value;
				this.XQEydRPildbIefQcHuEFeHvvJeSX();
			}
		}

		// Token: 0x17000951 RID: 2385
		// (get) Token: 0x0600279A RID: 10138 RVA: 0x0001D9ED File Offset: 0x0001BBED
		public CustomControllerSelector customControllerSelector
		{
			get
			{
				return this._customControllerSelector;
			}
		}

		// Token: 0x17000952 RID: 2386
		// (get) Token: 0x0600279B RID: 10139 RVA: 0x0001D9F5 File Offset: 0x0001BBF5
		public CustomController.CreateCustomControllerSettings createCustomControllerSettings
		{
			get
			{
				return this._createCustomControllerSettings;
			}
		}

		// Token: 0x0600279C RID: 10140 RVA: 0x0001D9FD File Offset: 0x0001BBFD
		[CustomObfuscation(rename = false)]
		internal CustomController()
		{
		}

		// Token: 0x0600279D RID: 10141 RVA: 0x0001DA2F File Offset: 0x0001BC2F
		public CustomController GetCustomController()
		{
			return this.DpsKgbvhQKKbuhmVhRHIfoZnbSuz(false);
		}

		// Token: 0x0600279E RID: 10142 RVA: 0x0001DA38 File Offset: 0x0001BC38
		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB;
		}

		// Token: 0x0600279F RID: 10143 RVA: 0x0001DA47 File Offset: 0x0001BC47
		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (!base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB)
			{
				return;
			}
			this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Clear();
		}

		// Token: 0x060027A0 RID: 10144 RVA: 0x0001DA63 File Offset: 0x0001BC63
		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB)
			{
				return;
			}
			this.XQEydRPildbIefQcHuEFeHvvJeSX();
		}

		// Token: 0x060027A1 RID: 10145 RVA: 0x0001DA7A File Offset: 0x0001BC7A
		[CustomObfuscation(rename = false)]
		internal override void OnDestroy()
		{
			base.OnDestroy();
			this.iQANiVvZQGaLdTlDmaCBkmNPDYluA();
		}

		// Token: 0x060027A2 RID: 10146 RVA: 0x0001DA88 File Offset: 0x0001BC88
		internal virtual bool OnInitialize()
		{
			if (!base.bvofkoAxqimixQrzNzQSTfAbWDiq())
			{
				return false;
			}
			if (this.GetUseCustomController())
			{
				if (!this.nqsNrAWbuvCSCKBwHWfwNcgikFOZ())
				{
					return false;
				}
				if (this.DpsKgbvhQKKbuhmVhRHIfoZnbSuz(true) == null)
				{
					this.SetUseCustomController(false);
				}
			}
			return true;
		}

		// Token: 0x060027A3 RID: 10147 RVA: 0x0001DAB7 File Offset: 0x0001BCB7
		internal virtual void OnSubscribeEvents()
		{
			base.AprEPOioEjENQKgHEEHgJwJcoeAz();
			this.WKKxkVMPEQalCfsKsCnuFfGKMTklA();
			if (!ReInput.isReady)
			{
				return;
			}
			ReInput.InputSourceUpdateEvent += this.uUPfySgOQvMnkyeXONUsBpLbEEyqA;
		}

		// Token: 0x060027A4 RID: 10148 RVA: 0x0001DADE File Offset: 0x0001BCDE
		internal virtual void OnUnsubscribeEvents()
		{
			base.WKKxkVMPEQalCfsKsCnuFfGKMTklA();
			ReInput.InputSourceUpdateEvent -= this.uUPfySgOQvMnkyeXONUsBpLbEEyqA;
		}

		// Token: 0x060027A5 RID: 10149 RVA: 0x0001DAF7 File Offset: 0x0001BCF7
		public override void ClearControlValues()
		{
			base.ClearControlValues();
			if (!base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB)
			{
				return;
			}
			this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Clear();
		}

		// Token: 0x060027A6 RID: 10150 RVA: 0x000042E2 File Offset: 0x000024E2
		[CustomObfuscation(rename = false)]
		internal virtual bool GetUseCustomController()
		{
			return true;
		}

		// Token: 0x060027A7 RID: 10151 RVA: 0x00002FF9 File Offset: 0x000011F9
		[CustomObfuscation(rename = false)]
		internal virtual void SetUseCustomController(bool value)
		{
		}

		// Token: 0x060027A8 RID: 10152 RVA: 0x00095A50 File Offset: 0x00093C50
		internal void SetAxisValue(CustomControllerElementSelector element, float value)
		{
			if (!base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB)
			{
				return;
			}
			if (element == null)
			{
				return;
			}
			if (!this.GetUseCustomController())
			{
				return;
			}
			CustomController customController = this.DpsKgbvhQKKbuhmVhRHIfoZnbSuz(false);
			if (customController == null)
			{
				return;
			}
			int elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			int count = this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Count;
			for (int i = 0; i < this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Count; i++)
			{
				CustomController.AQnsoGBmDyJHVcNRehRFGvsdcaXm value2 = this.jfqHACdWACCXIdJLfFioPcyHSfEZC[i];
				if (value2.qNpXkrmjHCRojKByNsCobVCtuiJI(element.elementType, elementIndex))
				{
					value2.PUEZNOjhtbamsMeGNCMLSovLYHO(value);
					this.jfqHACdWACCXIdJLfFioPcyHSfEZC[i] = value2;
					return;
				}
			}
			this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Add(new CustomController.AQnsoGBmDyJHVcNRehRFGvsdcaXm(element.elementType, elementIndex, value));
		}

		// Token: 0x060027A9 RID: 10153 RVA: 0x00095AFC File Offset: 0x00093CFC
		internal void SetButtonValue(CustomControllerElementSelector element, bool value)
		{
			if (!base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB)
			{
				return;
			}
			if (element == null)
			{
				return;
			}
			if (!this.GetUseCustomController())
			{
				return;
			}
			CustomController customController = this.DpsKgbvhQKKbuhmVhRHIfoZnbSuz(false);
			if (customController == null)
			{
				return;
			}
			int elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			int count = this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Count;
			for (int i = 0; i < this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Count; i++)
			{
				CustomController.AQnsoGBmDyJHVcNRehRFGvsdcaXm value2 = this.jfqHACdWACCXIdJLfFioPcyHSfEZC[i];
				if (value2.qNpXkrmjHCRojKByNsCobVCtuiJI(element.elementType, elementIndex))
				{
					value2.gXbBqslurBNEYhLTMdyzapdDqhqZA(value);
					this.jfqHACdWACCXIdJLfFioPcyHSfEZC[i] = value2;
					return;
				}
			}
			this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Add(new CustomController.AQnsoGBmDyJHVcNRehRFGvsdcaXm(element.elementType, elementIndex, value));
		}

		// Token: 0x060027AA RID: 10154 RVA: 0x00095BA8 File Offset: 0x00093DA8
		internal void ClearElementValue(CustomControllerElementTargetSet targetSet)
		{
			if (targetSet == null)
			{
				return;
			}
			int targetCount = targetSet.targetCount;
			for (int i = 0; i < targetCount; i++)
			{
				this.ClearElementValue(targetSet[i]);
			}
		}

		// Token: 0x060027AB RID: 10155 RVA: 0x0001DB13 File Offset: 0x0001BD13
		internal void ClearElementValue(CustomControllerElementTarget target)
		{
			if (target == null)
			{
				return;
			}
			this.ClearElementValue(target.element);
		}

		// Token: 0x060027AC RID: 10156 RVA: 0x00095BDC File Offset: 0x00093DDC
		internal void ClearElementValue(CustomControllerElementSelector element)
		{
			if (!base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB)
			{
				return;
			}
			if (element == null)
			{
				return;
			}
			if (!this.GetUseCustomController())
			{
				return;
			}
			CustomController customController = this.DpsKgbvhQKKbuhmVhRHIfoZnbSuz(false);
			if (customController == null)
			{
				return;
			}
			int elementIndex = element.GetElementIndex(customController);
			if (elementIndex < 0)
			{
				return;
			}
			CustomControllerElementSelector.ElementType elementType = element.elementType;
			if (elementType != CustomControllerElementSelector.ElementType.Axis)
			{
				if (elementType != CustomControllerElementSelector.ElementType.Button)
				{
					throw new NotImplementedException();
				}
				customController.ClearButtonValue(elementIndex);
			}
			else
			{
				customController.ClearAxisValue(elementIndex);
			}
			int count = this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Count;
			for (int i = this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Count - 1; i >= 0; i--)
			{
				if (this.jfqHACdWACCXIdJLfFioPcyHSfEZC[i].qNpXkrmjHCRojKByNsCobVCtuiJI(element.elementType, elementIndex))
				{
					this.jfqHACdWACCXIdJLfFioPcyHSfEZC.RemoveAt(i);
				}
			}
		}

		// Token: 0x060027AD RID: 10157 RVA: 0x00095C90 File Offset: 0x00093E90
		internal int ElementExists_Editor(CustomControllerElementSelector element)
		{
			if (element == null)
			{
				return -1;
			}
			if (!element.isAssigned)
			{
				return -1;
			}
			if (this._rewiredInputManager == null)
			{
				return -1;
			}
			if (!this._customControllerSelector.findUsingSourceId)
			{
				return -1;
			}
			CustomController_Editor customControllerById = this._rewiredInputManager.userData.GetCustomControllerById(this._customControllerSelector.sourceId);
			if (customControllerById == null)
			{
				return -1;
			}
			switch (element.selectorType)
			{
			case CustomControllerElementSelector.SelectorType.Name:
				if (!ArrayTools.Contains<string>(customControllerById.GetElementIdentifierNames(), element.elementName))
				{
					return 0;
				}
				return 1;
			case CustomControllerElementSelector.SelectorType.Index:
			{
				CustomControllerElementSelector.ElementType elementType = element.elementType;
				if (elementType != CustomControllerElementSelector.ElementType.Axis)
				{
					if (elementType != CustomControllerElementSelector.ElementType.Button)
					{
						throw new NotImplementedException();
					}
					if (element.elementIndex < 0 || element.elementIndex >= customControllerById.buttonCount)
					{
						return 0;
					}
					return 1;
				}
				else
				{
					if (element.elementIndex < 0 || element.elementIndex >= customControllerById.axisCount)
					{
						return 0;
					}
					return 1;
				}
				break;
			}
			case CustomControllerElementSelector.SelectorType.Id:
				if (!customControllerById.ContainsElementIdentifier(element.elementId))
				{
					return 0;
				}
				return 1;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x060027AE RID: 10158 RVA: 0x00095D84 File Offset: 0x00093F84
		internal bool ElementExists(CustomControllerElementSelector element)
		{
			if (!base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB)
			{
				return false;
			}
			if (element == null)
			{
				return false;
			}
			CustomController customController = this.DpsKgbvhQKKbuhmVhRHIfoZnbSuz(false);
			return customController != null && element.GetElementIndex(customController) >= 0;
		}

		// Token: 0x060027AF RID: 10159 RVA: 0x00095DBC File Offset: 0x00093FBC
		internal bool ValidateElements(CustomControllerElementTargetSet targetSet)
		{
			if (targetSet == null)
			{
				return false;
			}
			bool flag = true;
			int targetCount = targetSet.targetCount;
			for (int i = 0; i < targetCount; i++)
			{
				flag &= this.ValidateElement(targetSet[i]);
			}
			return flag;
		}

		// Token: 0x060027B0 RID: 10160 RVA: 0x0001DB25 File Offset: 0x0001BD25
		internal bool ValidateElement(CustomControllerElementTarget target)
		{
			return target != null && this.ValidateElement(target.element);
		}

		// Token: 0x060027B1 RID: 10161 RVA: 0x00095DF4 File Offset: 0x00093FF4
		internal bool ValidateElement(CustomControllerElementSelector element)
		{
			if (!base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB)
			{
				return false;
			}
			if (!this.GetUseCustomController())
			{
				return false;
			}
			if (element == null)
			{
				return false;
			}
			if (!element.isAssigned)
			{
				return false;
			}
			CustomController customController = this.DpsKgbvhQKKbuhmVhRHIfoZnbSuz(false);
			if (customController == null)
			{
				return false;
			}
			if (!this.ElementExists(element))
			{
				Logger.LogWarning(string.Concat(new string[]
				{
					"No element found for ",
					element.GetSelectorFormattedString(),
					" in Custom Controller \"",
					customController.name,
					"\""
				}));
				return false;
			}
			return true;
		}

		// Token: 0x060027B2 RID: 10162 RVA: 0x0001DB38 File Offset: 0x0001BD38
		private void XQEydRPildbIefQcHuEFeHvvJeSX()
		{
			if (!base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB)
			{
				return;
			}
			this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Clear();
		}

		// Token: 0x060027B3 RID: 10163 RVA: 0x0001DB4E File Offset: 0x0001BD4E
		private bool nqsNrAWbuvCSCKBwHWfwNcgikFOZ()
		{
			if (ReInput.isReady)
			{
				return true;
			}
			Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Custom Controller. Custom Controller support will be disabled on this Custom Controller.");
			this.SetUseCustomController(false);
			return false;
		}

		// Token: 0x060027B4 RID: 10164 RVA: 0x00095E78 File Offset: 0x00094078
		private void aIScSytmjepfdKunHDRTzjiEIWrq()
		{
			if (this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Count == 0)
			{
				return;
			}
			CustomController customController = this.DpsKgbvhQKKbuhmVhRHIfoZnbSuz(false);
			if (customController == null)
			{
				this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Clear();
				return;
			}
			for (int i = 0; i < this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Count; i++)
			{
				CustomController.AQnsoGBmDyJHVcNRehRFGvsdcaXm aqnsoGBmDyJHVcNRehRFGvsdcaXm = this.jfqHACdWACCXIdJLfFioPcyHSfEZC[i];
				CustomControllerElementSelector.ElementType eynhcpjWiHGVQPzrimrjIlHKywII = aqnsoGBmDyJHVcNRehRFGvsdcaXm.EynhcpjWiHGVQPzrimrjIlHKywII;
				if (eynhcpjWiHGVQPzrimrjIlHKywII != CustomControllerElementSelector.ElementType.Axis)
				{
					if (eynhcpjWiHGVQPzrimrjIlHKywII != CustomControllerElementSelector.ElementType.Button)
					{
						throw new NotImplementedException();
					}
					customController.SetButtonValue(aqnsoGBmDyJHVcNRehRFGvsdcaXm.MTeRkuefGlcdCHlsugnzUewepXSH, aqnsoGBmDyJHVcNRehRFGvsdcaXm.cPygWquBEUGBWzCiOnilhtEVBZBp != 0f);
				}
				else
				{
					customController.SetAxisValue(aqnsoGBmDyJHVcNRehRFGvsdcaXm.MTeRkuefGlcdCHlsugnzUewepXSH, aqnsoGBmDyJHVcNRehRFGvsdcaXm.cPygWquBEUGBWzCiOnilhtEVBZBp);
				}
			}
			this.jfqHACdWACCXIdJLfFioPcyHSfEZC.Clear();
		}

		// Token: 0x060027B5 RID: 10165 RVA: 0x00095F20 File Offset: 0x00094120
		private CustomController DpsKgbvhQKKbuhmVhRHIfoZnbSuz(bool A_1)
		{
			if (!this.GetUseCustomController())
			{
				return null;
			}
			if (!ReInput.isReady)
			{
				return null;
			}
			CustomController customController;
			if (this.rGbfZWckRQbmwToDGSjYCeUkfzfKB >= 0)
			{
				customController = ReInput.controllers.GetCustomController(this.rGbfZWckRQbmwToDGSjYCeUkfzfKB);
				if (customController == null)
				{
					this.rGbfZWckRQbmwToDGSjYCeUkfzfKB = -1;
				}
			}
			else
			{
				customController = null;
			}
			if (customController == null)
			{
				if (this._createCustomControllerSettings.createCustomController)
				{
					customController = ReInput.controllers.CreateCustomController(this._createCustomControllerSettings.customControllerSourceId);
					if (customController != null)
					{
						this.rGbfZWckRQbmwToDGSjYCeUkfzfKB = customController.id;
						this.oOyawegViUUHQVFEkNGJmfeKuajjA(customController);
					}
				}
				else
				{
					customController = this._customControllerSelector.GetCustomController();
				}
			}
			if (A_1 && customController == null && this.GetUseCustomController())
			{
				Logger.LogWarning("No Custom Controller was found matching the search parameters.");
			}
			return customController;
		}

		// Token: 0x060027B6 RID: 10166 RVA: 0x00095FCC File Offset: 0x000941CC
		private void oOyawegViUUHQVFEkNGJmfeKuajjA(CustomController A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			if (this._createCustomControllerSettings.assignToPlayerId == -1)
			{
				if (Application.isEditor)
				{
					Logger.LogWarning("The Custom Controller has not been assigned to any Player and will not be used for input until it is assigned. You should set the Player to assign it to in the inspector.");
				}
				return;
			}
			Player player = ReInput.players.GetPlayer(this._createCustomControllerSettings.assignToPlayerId);
			if (player == null)
			{
				Logger.LogError("Invalid Player Id " + this._createCustomControllerSettings.assignToPlayerId.ToString() + ". Cannot assign Custom Controller to Player.");
				return;
			}
			player.controllers.AddController(A_1, true);
		}

		// Token: 0x060027B7 RID: 10167 RVA: 0x0009604C File Offset: 0x0009424C
		private void iQANiVvZQGaLdTlDmaCBkmNPDYluA()
		{
			if (this.rGbfZWckRQbmwToDGSjYCeUkfzfKB < 0)
			{
				return;
			}
			if (!this._createCustomControllerSettings.destroyCustomController)
			{
				return;
			}
			CustomController customController = this.DpsKgbvhQKKbuhmVhRHIfoZnbSuz(false);
			if (customController == null)
			{
				return;
			}
			if (!ReInput.isReady)
			{
				return;
			}
			ReInput.controllers.DestroyCustomController(customController);
			this.rGbfZWckRQbmwToDGSjYCeUkfzfKB = -1;
		}

		// Token: 0x060027B8 RID: 10168 RVA: 0x0001DB6B File Offset: 0x0001BD6B
		private void uUPfySgOQvMnkyeXONUsBpLbEEyqA()
		{
			if (this.oEypczzqSIOXJyQKjWSioujNiEAc != null)
			{
				this.oEypczzqSIOXJyQKjWSioujNiEAc();
			}
			this.aIScSytmjepfdKunHDRTzjiEIWrq();
		}

		// Token: 0x04001706 RID: 5894
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Custom Controller elements, etc.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private InputManager_Base _rewiredInputManager;

		// Token: 0x04001707 RID: 5895
		[Tooltip("Contains search parameters to find a particular Custom Controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerSelector _customControllerSelector = new CustomControllerSelector();

		// Token: 0x04001708 RID: 5896
		[Tooltip("Settings for creating a Custom Controller on start.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomController.CreateCustomControllerSettings _createCustomControllerSettings = new CustomController.CreateCustomControllerSettings();

		// Token: 0x04001709 RID: 5897
		private List<CustomController.AQnsoGBmDyJHVcNRehRFGvsdcaXm> jfqHACdWACCXIdJLfFioPcyHSfEZC = new List<CustomController.AQnsoGBmDyJHVcNRehRFGvsdcaXm>(10);

		// Token: 0x0400170A RID: 5898
		[NonSerialized]
		private int rGbfZWckRQbmwToDGSjYCeUkfzfKB = -1;

		// Token: 0x0400170B RID: 5899
		private Action oEypczzqSIOXJyQKjWSioujNiEAc;

		// Token: 0x020003DE RID: 990
		[Serializable]
		public class CreateCustomControllerSettings
		{
			// Token: 0x17000953 RID: 2387
			// (get) Token: 0x060027B9 RID: 10169 RVA: 0x0001DB86 File Offset: 0x0001BD86
			// (set) Token: 0x060027BA RID: 10170 RVA: 0x0001DB8E File Offset: 0x0001BD8E
			public bool createCustomController
			{
				get
				{
					return this._createCustomController;
				}
				set
				{
					if (this._createCustomController == value)
					{
						return;
					}
					this._createCustomController = value;
				}
			}

			// Token: 0x17000954 RID: 2388
			// (get) Token: 0x060027BB RID: 10171 RVA: 0x0001DBA1 File Offset: 0x0001BDA1
			// (set) Token: 0x060027BC RID: 10172 RVA: 0x0001DBA9 File Offset: 0x0001BDA9
			public int customControllerSourceId
			{
				get
				{
					return this._customControllerSourceId;
				}
				set
				{
					this._customControllerSourceId = value;
				}
			}

			// Token: 0x17000955 RID: 2389
			// (get) Token: 0x060027BD RID: 10173 RVA: 0x0001DBB2 File Offset: 0x0001BDB2
			// (set) Token: 0x060027BE RID: 10174 RVA: 0x0001DBBA File Offset: 0x0001BDBA
			public int assignToPlayerId
			{
				get
				{
					return this._assignToPlayerId;
				}
				set
				{
					this._assignToPlayerId = value;
				}
			}

			// Token: 0x17000956 RID: 2390
			// (get) Token: 0x060027BF RID: 10175 RVA: 0x0001DBC3 File Offset: 0x0001BDC3
			// (set) Token: 0x060027C0 RID: 10176 RVA: 0x0001DBCB File Offset: 0x0001BDCB
			public bool destroyCustomController
			{
				get
				{
					return this._destroyCustomController;
				}
				set
				{
					this._destroyCustomController = value;
				}
			}

			// Token: 0x0400170C RID: 5900
			[Tooltip("If true, a new Custom Controller will be created. Otherwise, an existing Custom Controller will be found using the selector properties.")]
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _createCustomController = true;

			// Token: 0x0400170D RID: 5901
			[Tooltip("The source id of the Custom Controller to create. Get this from the Rewired Input Manager.")]
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _customControllerSourceId = -1;

			// Token: 0x0400170E RID: 5902
			[Tooltip("The Player that will be assigned this Custom Controller when it is created.")]
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _assignToPlayerId;

			// Token: 0x0400170F RID: 5903
			[Tooltip("If true, the Custom Controller created by this component will be destroyed when this component is destroyed.")]
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _destroyCustomController = true;
		}

		// Token: 0x020003DF RID: 991
		private struct AQnsoGBmDyJHVcNRehRFGvsdcaXm
		{
			// Token: 0x060027C2 RID: 10178 RVA: 0x0001DBF1 File Offset: 0x0001BDF1
			public AQnsoGBmDyJHVcNRehRFGvsdcaXm(CustomControllerElementSelector.ElementType A_1, int A_2, float A_3)
			{
				this.EynhcpjWiHGVQPzrimrjIlHKywII = A_1;
				this.MTeRkuefGlcdCHlsugnzUewepXSH = A_2;
				this.cPygWquBEUGBWzCiOnilhtEVBZBp = A_3;
			}

			// Token: 0x060027C3 RID: 10179 RVA: 0x0001DC08 File Offset: 0x0001BE08
			public AQnsoGBmDyJHVcNRehRFGvsdcaXm(CustomControllerElementSelector.ElementType A_1, int A_2, bool A_3)
			{
				this.EynhcpjWiHGVQPzrimrjIlHKywII = A_1;
				this.MTeRkuefGlcdCHlsugnzUewepXSH = A_2;
				this.cPygWquBEUGBWzCiOnilhtEVBZBp = (A_3 ? 1f : 0f);
			}

			// Token: 0x060027C4 RID: 10180 RVA: 0x0001DC2D File Offset: 0x0001BE2D
			public bool qNpXkrmjHCRojKByNsCobVCtuiJI(CustomControllerElementSelector.ElementType A_1, int A_2)
			{
				return this.EynhcpjWiHGVQPzrimrjIlHKywII == A_1 && this.MTeRkuefGlcdCHlsugnzUewepXSH == A_2;
			}

			// Token: 0x060027C5 RID: 10181 RVA: 0x0001DC43 File Offset: 0x0001BE43
			public void PUEZNOjhtbamsMeGNCMLSovLYHO(float A_1)
			{
				this.cPygWquBEUGBWzCiOnilhtEVBZBp = MathTools.MaxMagnitude(this.cPygWquBEUGBWzCiOnilhtEVBZBp, A_1);
			}

			// Token: 0x060027C6 RID: 10182 RVA: 0x0001DC57 File Offset: 0x0001BE57
			public void gXbBqslurBNEYhLTMdyzapdDqhqZA(bool A_1)
			{
				if (A_1)
				{
					this.cPygWquBEUGBWzCiOnilhtEVBZBp = 1f;
				}
			}

			// Token: 0x04001710 RID: 5904
			public CustomControllerElementSelector.ElementType EynhcpjWiHGVQPzrimrjIlHKywII;

			// Token: 0x04001711 RID: 5905
			public int MTeRkuefGlcdCHlsugnzUewepXSH;

			// Token: 0x04001712 RID: 5906
			public float cPygWquBEUGBWzCiOnilhtEVBZBp;
		}
	}
}
