using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

// Token: 0x02000389 RID: 905
internal sealed class COootOIiwXGzUSdmLyqHaOKMeIvB : IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal
{
	// Token: 0x1700089F RID: 2207
	// (get) Token: 0x0600251C RID: 9500 RVA: 0x0001B40C File Offset: 0x0001960C
	public string name
	{
		get
		{
			return this.CkhWHwpQZVjPlGdcGuLmXIhLBDyB;
		}
	}

	// Token: 0x170008A0 RID: 2208
	// (get) Token: 0x0600251D RID: 9501 RVA: 0x0001B414 File Offset: 0x00019614
	public string yRRhNuBLHhhkeeyCuaJSeukbXFcTB
	{
		get
		{
			return this.BDWQwsBJAAnPvoTqsVCpLAkFITFu;
		}
	}

	// Token: 0x170008A1 RID: 2209
	// (get) Token: 0x0600251E RID: 9502 RVA: 0x0001B41C File Offset: 0x0001961C
	public string MkNRKbrrcjLDRsezPGSfGuOHBAGq
	{
		get
		{
			return this.SGHAQBBdwmWYhMxAeMccdicNFUaAA;
		}
	}

	// Token: 0x170008A2 RID: 2210
	// (get) Token: 0x0600251F RID: 9503 RVA: 0x0001B424 File Offset: 0x00019624
	public Guid QrQhTWxkdKIjWKrNNOMwChQrVSON
	{
		get
		{
			return this.kEKPoYaWOdHmJvnZMIMrUPvjGRVO;
		}
	}

	// Token: 0x06002520 RID: 9504 RVA: 0x00091CFC File Offset: 0x0008FEFC
	public COootOIiwXGzUSdmLyqHaOKMeIvB(HardwareJoystickTemplateMap A_1, List<HardwareJoystickTemplateMap.Entry> A_2, ControllerTemplateElementIdentifier[] A_3)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException();
		}
		if (A_2 == null)
		{
			throw new ArgumentNullException();
		}
		if (A_3 == null)
		{
			throw new ArgumentNullException();
		}
		this.swajajPqYFsSkojMuaqcAYzYjUdq = A_1;
		this.CkhWHwpQZVjPlGdcGuLmXIhLBDyB = A_1.name;
		this.BDWQwsBJAAnPvoTqsVCpLAkFITFu = A_1.ClassName;
		this.kEKPoYaWOdHmJvnZMIMrUPvjGRVO = A_1.Guid;
		this.SGHAQBBdwmWYhMxAeMccdicNFUaAA = A_1.Key;
		this.udnbAvjOpZaPpeZMFNRcMyVrwwObA = A_2;
		this.BXBxyQaltXDVXXOkJpQFWkcltlyG = A_3;
		this.NNzJpyGPwDmzhXdXOWYcwmxCfpDk = new DeviceLocalizationInfo(ControllerType.Joystick, true, this.QrQhTWxkdKIjWKrNNOMwChQrVSON, new AList<string>
		{
			this.SGHAQBBdwmWYhMxAeMccdicNFUaAA
		}, null);
		this.NNzJpyGPwDmzhXdXOWYcwmxCfpDk.FinishRuntimeSetup();
		bool flag = this.NNzJpyGPwDmzhXdXOWYcwmxCfpDk.controllerType != ControllerType.Keyboard && this.NNzJpyGPwDmzhXdXOWYcwmxCfpDk.controllerType != ControllerType.Mouse;
		for (int i = 0; i < this.BXBxyQaltXDVXXOkJpQFWkcltlyG.Length; i++)
		{
			if (this.BXBxyQaltXDVXXOkJpQFWkcltlyG[i] != null)
			{
				if (flag)
				{
					ControllerTemplateElementIdentifier controllerTemplateElementIdentifier;
					if (ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.jJSuKKsHyDrXgAXltdKcPNIDXwpG(this.NNzJpyGPwDmzhXdXOWYcwmxCfpDk, this.BXBxyQaltXDVXXOkJpQFWkcltlyG[i], out controllerTemplateElementIdentifier))
					{
						this.BXBxyQaltXDVXXOkJpQFWkcltlyG[i] = controllerTemplateElementIdentifier;
						goto IL_118;
					}
					ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.kiumPGWNpmulBHwmcQlavzxLOgmv(this.NNzJpyGPwDmzhXdXOWYcwmxCfpDk, this.BXBxyQaltXDVXXOkJpQFWkcltlyG[i]);
				}
				this.BXBxyQaltXDVXXOkJpQFWkcltlyG[i].FinishRuntimeSetup(this.NNzJpyGPwDmzhXdXOWYcwmxCfpDk);
			}
			IL_118:;
		}
	}

	// Token: 0x06002521 RID: 9505 RVA: 0x00091E30 File Offset: 0x00090030
	public ControllerTemplateElementIdentifier grPlAFggxlMRFZfwGkMaZjUnSfNB(Guid A_1, int A_2)
	{
		if (A_1 == Guid.Empty || A_2 < 0)
		{
			return null;
		}
		if (this.udnbAvjOpZaPpeZMFNRcMyVrwwObA == null)
		{
			return null;
		}
		int num = -1;
		int count = this.udnbAvjOpZaPpeZMFNRcMyVrwwObA.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.udnbAvjOpZaPpeZMFNRcMyVrwwObA[i] != null && this.udnbAvjOpZaPpeZMFNRcMyVrwwObA[i].JoystickGuid == A_1)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return null;
		}
		HardwareJoystickTemplateMap.Entry entry = this.udnbAvjOpZaPpeZMFNRcMyVrwwObA[num];
		if (entry == null)
		{
			return null;
		}
		int templateElementId = entry.GetTemplateElementId(A_2);
		if (templateElementId < 0)
		{
			return null;
		}
		return HardwareJoystickTemplateMap.oCWzblfMOSbkQbShRbMmwWQpBuJgA(this.BXBxyQaltXDVXXOkJpQFWkcltlyG, templateElementId);
	}

	// Token: 0x06002522 RID: 9506 RVA: 0x00091ED8 File Offset: 0x000900D8
	public int QTJiclENSsFlSCogpqemVyqvZqbHA(Guid A_1, int A_2, List<HardwareControllerTemplateMap.vNUinRqnjfTkAskqXltQLMfPUMUv> A_3)
	{
		if (A_3 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (A_1 == Guid.Empty || A_2 < 0)
		{
			return 0;
		}
		if (this.udnbAvjOpZaPpeZMFNRcMyVrwwObA == null)
		{
			return 0;
		}
		int num = -1;
		int count = this.udnbAvjOpZaPpeZMFNRcMyVrwwObA.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.udnbAvjOpZaPpeZMFNRcMyVrwwObA[i] != null && this.udnbAvjOpZaPpeZMFNRcMyVrwwObA[i].JoystickGuid == A_1)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return 0;
		}
		HardwareJoystickTemplateMap.Entry entry = this.udnbAvjOpZaPpeZMFNRcMyVrwwObA[num];
		if (entry == null)
		{
			return 0;
		}
		int count2 = A_3.Count;
		int num2 = (entry.elementIdentifierMappings != null) ? entry.elementIdentifierMappings.Count : 0;
		for (int j = 0; j < num2; j++)
		{
			if (entry.elementIdentifierMappings != null)
			{
				HardwareJoystickTemplateMap.ElementIdentifierMap elementIdentifierMap = entry.elementIdentifierMappings[j];
				if (elementIdentifierMap != null)
				{
					ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = COootOIiwXGzUSdmLyqHaOKMeIvB.ACOgUgdczfxKvEQLXAheFTBhqzmAA(this.BXBxyQaltXDVXXOkJpQFWkcltlyG, elementIdentifierMap.templateId);
					if (controllerTemplateElementIdentifier != null)
					{
						if (controllerTemplateElementIdentifier.elementType == ControllerTemplateElementType.Axis)
						{
							if (elementIdentifierMap.splitAxis)
							{
								if (elementIdentifierMap.joystickId != A_2 && elementIdentifierMap.joystickId2 != A_2)
								{
									goto IL_184;
								}
							}
							else if (elementIdentifierMap.joystickId != A_2)
							{
								goto IL_184;
							}
						}
						else if (elementIdentifierMap.joystickId != A_2)
						{
							goto IL_184;
						}
						A_3.Add(new HardwareControllerTemplateMap.vNUinRqnjfTkAskqXltQLMfPUMUv
						{
							UIHXARWEFIUQvHamiuIUzSVIaBFb = elementIdentifierMap.templateId,
							gxqDjvURKgAphrnHLBgXhhAevmWo = elementIdentifierMap.joystickId,
							zeCfOGzHrAArWDHkKnYIkfgqsJXSA = elementIdentifierMap.joystickId2,
							tgGVJPmoMdsLlKFiRFfKEnLphuSt = (controllerTemplateElementIdentifier.elementType == ControllerTemplateElementType.Axis && elementIdentifierMap.splitAxis)
						});
					}
				}
			}
			IL_184:;
		}
		return A_3.Count - count2;
	}

	// Token: 0x06002523 RID: 9507 RVA: 0x00092080 File Offset: 0x00090280
	private HardwareJoystickTemplateMap.Entry VXQptveaPJtzcGovavSWqvlLJmBh(Guid A_1)
	{
		if (this.udnbAvjOpZaPpeZMFNRcMyVrwwObA == null)
		{
			return null;
		}
		for (int i = 0; i < this.udnbAvjOpZaPpeZMFNRcMyVrwwObA.Count; i++)
		{
			if (this.udnbAvjOpZaPpeZMFNRcMyVrwwObA[i].JoystickGuid == A_1)
			{
				return this.udnbAvjOpZaPpeZMFNRcMyVrwwObA[i];
			}
		}
		return null;
	}

	// Token: 0x06002524 RID: 9508 RVA: 0x000920D4 File Offset: 0x000902D4
	private static ControllerTemplateElementIdentifier ACOgUgdczfxKvEQLXAheFTBhqzmAA(ControllerTemplateElementIdentifier[] A_0, int A_1)
	{
		if (A_0 == null)
		{
			return null;
		}
		for (int i = 0; i < A_0.Length; i++)
		{
			if (A_0[i] != null && A_0[i].id == A_1)
			{
				return A_0[i];
			}
		}
		return null;
	}

	// Token: 0x170008A3 RID: 2211
	// (get) Token: 0x06002525 RID: 9509 RVA: 0x0001B40C File Offset: 0x0001960C
	string IHardwareControllerTemplateMap_Internal.name
	{
		get
		{
			return this.CkhWHwpQZVjPlGdcGuLmXIhLBDyB;
		}
	}

	// Token: 0x170008A4 RID: 2212
	// (get) Token: 0x06002526 RID: 9510 RVA: 0x0001B424 File Offset: 0x00019624
	Guid IHardwareControllerTemplateMap_Internal.typeGuid
	{
		get
		{
			return this.kEKPoYaWOdHmJvnZMIMrUPvjGRVO;
		}
	}

	// Token: 0x170008A5 RID: 2213
	// (get) Token: 0x06002527 RID: 9511 RVA: 0x0001B41C File Offset: 0x0001961C
	string IHardwareControllerTemplateMap_Internal.typeKey
	{
		get
		{
			return this.SGHAQBBdwmWYhMxAeMccdicNFUaAA;
		}
	}

	// Token: 0x06002528 RID: 9512 RVA: 0x0001B42C File Offset: 0x0001962C
	int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
	{
		if (this.BXBxyQaltXDVXXOkJpQFWkcltlyG == null)
		{
			return 0;
		}
		return this.BXBxyQaltXDVXXOkJpQFWkcltlyG.Length;
	}

	// Token: 0x06002529 RID: 9513 RVA: 0x0001B440 File Offset: 0x00019640
	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
	{
		if (this.BXBxyQaltXDVXXOkJpQFWkcltlyG == null)
		{
			return null;
		}
		return this.BXBxyQaltXDVXXOkJpQFWkcltlyG[index];
	}

	// Token: 0x0600252A RID: 9514 RVA: 0x0001B454 File Offset: 0x00019654
	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.oCWzblfMOSbkQbShRbMmwWQpBuJgA(this.BXBxyQaltXDVXXOkJpQFWkcltlyG, elementIdentifierId);
	}

	// Token: 0x0600252B RID: 9515 RVA: 0x0001B462 File Offset: 0x00019662
	IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
	{
		return new COootOIiwXGzUSdmLyqHaOKMeIvB.JYWdnqbIveEjOaWGIbtkbvaUNgg(((IHardwareControllerTemplateMap_Internal)this.swajajPqYFsSkojMuaqcAYzYjUdq).GetSpecialTemplateElementByElementIdentifierId(id));
	}

	// Token: 0x0600252C RID: 9516 RVA: 0x0001B47A File Offset: 0x0001967A
	zzIYMvAnMtpiMJyIjwvHCSyknhJk IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.TTcMpmkxaXCfVuNtxqoHbBddRNYS(this, controller, elementIdentifierId, this.GFhOmcHuOWwdwtfNSkMHAgtJgtjc);
	}

	// Token: 0x0600252D RID: 9517 RVA: 0x0001B48A File Offset: 0x0001968A
	zzIYMvAnMtpiMJyIjwvHCSyknhJk IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.oFdcjuhlnTvFnsPJrzRVSnTJgcMw(this, controller, elementIdentifierId, this.GFhOmcHuOWwdwtfNSkMHAgtJgtjc);
	}

	// Token: 0x170008A6 RID: 2214
	// (get) Token: 0x0600252E RID: 9518 RVA: 0x0009210C File Offset: 0x0009030C
	private Func<Guid, HardwareJoystickTemplateMap.Entry> GFhOmcHuOWwdwtfNSkMHAgtJgtjc
	{
		get
		{
			Func<Guid, HardwareJoystickTemplateMap.Entry> result;
			if ((result = this.lenBqHIgBUOvWzfhxfYNEylEQfzWb) == null)
			{
				result = (this.lenBqHIgBUOvWzfhxfYNEylEQfzWb = new Func<Guid, HardwareJoystickTemplateMap.Entry>(this.VXQptveaPJtzcGovavSWqvlLJmBh));
			}
			return result;
		}
	}

	// Token: 0x04001530 RID: 5424
	private HardwareJoystickTemplateMap swajajPqYFsSkojMuaqcAYzYjUdq;

	// Token: 0x04001531 RID: 5425
	private string CkhWHwpQZVjPlGdcGuLmXIhLBDyB;

	// Token: 0x04001532 RID: 5426
	private string BDWQwsBJAAnPvoTqsVCpLAkFITFu;

	// Token: 0x04001533 RID: 5427
	private string SGHAQBBdwmWYhMxAeMccdicNFUaAA;

	// Token: 0x04001534 RID: 5428
	private readonly Guid kEKPoYaWOdHmJvnZMIMrUPvjGRVO;

	// Token: 0x04001535 RID: 5429
	private readonly List<HardwareJoystickTemplateMap.Entry> udnbAvjOpZaPpeZMFNRcMyVrwwObA;

	// Token: 0x04001536 RID: 5430
	private readonly ControllerTemplateElementIdentifier[] BXBxyQaltXDVXXOkJpQFWkcltlyG;

	// Token: 0x04001537 RID: 5431
	private readonly DeviceLocalizationInfo NNzJpyGPwDmzhXdXOWYcwmxCfpDk;

	// Token: 0x04001538 RID: 5432
	[NonSerialized]
	private Func<Guid, HardwareJoystickTemplateMap.Entry> lenBqHIgBUOvWzfhxfYNEylEQfzWb;

	// Token: 0x0200038A RID: 906
	private struct JYWdnqbIveEjOaWGIbtkbvaUNgg : IControllerTemplateMapSpecialElement_Internal
	{
		// Token: 0x0600252F RID: 9519 RVA: 0x0001B49A File Offset: 0x0001969A
		public JYWdnqbIveEjOaWGIbtkbvaUNgg(IControllerTemplateMapSpecialElement_Internal A_1)
		{
			this.WyUzZSIxmPkPfWGlzHtpWMxsLvuq = A_1;
		}

		// Token: 0x06002530 RID: 9520 RVA: 0x0001B4A3 File Offset: 0x000196A3
		public T GetMapping<T>() where T : ControllerTemplateSpecialElementMapping
		{
			return this.WyUzZSIxmPkPfWGlzHtpWMxsLvuq.GetMapping<T>();
		}

		// Token: 0x04001539 RID: 5433
		private IControllerTemplateMapSpecialElement_Internal WyUzZSIxmPkPfWGlzHtpWMxsLvuq;
	}
}
