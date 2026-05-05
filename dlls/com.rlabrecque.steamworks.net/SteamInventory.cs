using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000014 RID: 20
	public static class SteamInventory
	{
		// Token: 0x06000272 RID: 626 RVA: 0x0000759B File Offset: 0x0000579B
		public static EResult GetResultStatus(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetResultStatus(CSteamAPIContext.GetSteamInventory(), resultHandle);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x000075AD File Offset: 0x000057AD
		public static bool GetResultItems(SteamInventoryResult_t resultHandle, SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize)
		{
			InteropHelp.TestIfAvailableClient();
			if (pOutItemsArray != null && (long)pOutItemsArray.Length != (long)((ulong)punOutItemsArraySize))
			{
				throw new ArgumentException("pOutItemsArray must be the same size as punOutItemsArraySize!");
			}
			return NativeMethods.ISteamInventory_GetResultItems(CSteamAPIContext.GetSteamInventory(), resultHandle, pOutItemsArray, ref punOutItemsArraySize);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000075D8 File Offset: 0x000057D8
		public static bool GetResultItemProperty(SteamInventoryResult_t resultHandle, uint unItemIndex, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)punValueBufferSizeOut);
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchPropertyName))
			{
				bool flag = NativeMethods.ISteamInventory_GetResultItemProperty(CSteamAPIContext.GetSteamInventory(), resultHandle, unItemIndex, utf8StringHandle, intPtr, ref punValueBufferSizeOut);
				pchValueBuffer = (flag ? InteropHelp.PtrToStringUTF8(intPtr) : null);
				Marshal.FreeHGlobal(intPtr);
				result = flag;
			}
			return result;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00007640 File Offset: 0x00005840
		public static uint GetResultTimestamp(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetResultTimestamp(CSteamAPIContext.GetSteamInventory(), resultHandle);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00007652 File Offset: 0x00005852
		public static bool CheckResultSteamID(SteamInventoryResult_t resultHandle, CSteamID steamIDExpected)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_CheckResultSteamID(CSteamAPIContext.GetSteamInventory(), resultHandle, steamIDExpected);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00007665 File Offset: 0x00005865
		public static void DestroyResult(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamInventory_DestroyResult(CSteamAPIContext.GetSteamInventory(), resultHandle);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00007677 File Offset: 0x00005877
		public static bool GetAllItems(out SteamInventoryResult_t pResultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetAllItems(CSteamAPIContext.GetSteamInventory(), out pResultHandle);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00007689 File Offset: 0x00005889
		public static bool GetItemsByID(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t[] pInstanceIDs, uint unCountInstanceIDs)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetItemsByID(CSteamAPIContext.GetSteamInventory(), out pResultHandle, pInstanceIDs, unCountInstanceIDs);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000769D File Offset: 0x0000589D
		public static bool SerializeResult(SteamInventoryResult_t resultHandle, byte[] pOutBuffer, out uint punOutBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_SerializeResult(CSteamAPIContext.GetSteamInventory(), resultHandle, pOutBuffer, out punOutBufferSize);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000076B1 File Offset: 0x000058B1
		public static bool DeserializeResult(out SteamInventoryResult_t pOutResultHandle, byte[] pBuffer, uint unBufferSize, bool bRESERVED_MUST_BE_FALSE = false)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_DeserializeResult(CSteamAPIContext.GetSteamInventory(), out pOutResultHandle, pBuffer, unBufferSize, bRESERVED_MUST_BE_FALSE);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000076C6 File Offset: 0x000058C6
		public static bool GenerateItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint[] punArrayQuantity, uint unArrayLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GenerateItems(CSteamAPIContext.GetSteamInventory(), out pResultHandle, pArrayItemDefs, punArrayQuantity, unArrayLength);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000076DB File Offset: 0x000058DB
		public static bool GrantPromoItems(out SteamInventoryResult_t pResultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GrantPromoItems(CSteamAPIContext.GetSteamInventory(), out pResultHandle);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000076ED File Offset: 0x000058ED
		public static bool AddPromoItem(out SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_AddPromoItem(CSteamAPIContext.GetSteamInventory(), out pResultHandle, itemDef);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00007700 File Offset: 0x00005900
		public static bool AddPromoItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint unArrayLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_AddPromoItems(CSteamAPIContext.GetSteamInventory(), out pResultHandle, pArrayItemDefs, unArrayLength);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00007714 File Offset: 0x00005914
		public static bool ConsumeItem(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_ConsumeItem(CSteamAPIContext.GetSteamInventory(), out pResultHandle, itemConsume, unQuantity);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00007728 File Offset: 0x00005928
		public static bool ExchangeItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayGenerate, uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, SteamItemInstanceID_t[] pArrayDestroy, uint[] punArrayDestroyQuantity, uint unArrayDestroyLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_ExchangeItems(CSteamAPIContext.GetSteamInventory(), out pResultHandle, pArrayGenerate, punArrayGenerateQuantity, unArrayGenerateLength, pArrayDestroy, punArrayDestroyQuantity, unArrayDestroyLength);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00007743 File Offset: 0x00005943
		public static bool TransferItemQuantity(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_TransferItemQuantity(CSteamAPIContext.GetSteamInventory(), out pResultHandle, itemIdSource, unQuantity, itemIdDest);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00007758 File Offset: 0x00005958
		public static void SendItemDropHeartbeat()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamInventory_SendItemDropHeartbeat(CSteamAPIContext.GetSteamInventory());
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00007769 File Offset: 0x00005969
		public static bool TriggerItemDrop(out SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_TriggerItemDrop(CSteamAPIContext.GetSteamInventory(), out pResultHandle, dropListDefinition);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000777C File Offset: 0x0000597C
		public static bool TradeItems(out SteamInventoryResult_t pResultHandle, CSteamID steamIDTradePartner, SteamItemInstanceID_t[] pArrayGive, uint[] pArrayGiveQuantity, uint nArrayGiveLength, SteamItemInstanceID_t[] pArrayGet, uint[] pArrayGetQuantity, uint nArrayGetLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_TradeItems(CSteamAPIContext.GetSteamInventory(), out pResultHandle, steamIDTradePartner, pArrayGive, pArrayGiveQuantity, nArrayGiveLength, pArrayGet, pArrayGetQuantity, nArrayGetLength);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x000077A4 File Offset: 0x000059A4
		public static bool LoadItemDefinitions()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_LoadItemDefinitions(CSteamAPIContext.GetSteamInventory());
		}

		// Token: 0x06000287 RID: 647 RVA: 0x000077B5 File Offset: 0x000059B5
		public static bool GetItemDefinitionIDs(SteamItemDef_t[] pItemDefIDs, ref uint punItemDefIDsArraySize)
		{
			InteropHelp.TestIfAvailableClient();
			if (pItemDefIDs != null && (long)pItemDefIDs.Length != (long)((ulong)punItemDefIDsArraySize))
			{
				throw new ArgumentException("pItemDefIDs must be the same size as punItemDefIDsArraySize!");
			}
			return NativeMethods.ISteamInventory_GetItemDefinitionIDs(CSteamAPIContext.GetSteamInventory(), pItemDefIDs, ref punItemDefIDsArraySize);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000077E0 File Offset: 0x000059E0
		public static bool GetItemDefinitionProperty(SteamItemDef_t iDefinition, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)punValueBufferSizeOut);
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchPropertyName))
			{
				bool flag = NativeMethods.ISteamInventory_GetItemDefinitionProperty(CSteamAPIContext.GetSteamInventory(), iDefinition, utf8StringHandle, intPtr, ref punValueBufferSizeOut);
				pchValueBuffer = (flag ? InteropHelp.PtrToStringUTF8(intPtr) : null);
				Marshal.FreeHGlobal(intPtr);
				result = flag;
			}
			return result;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00007844 File Offset: 0x00005A44
		public static SteamAPICall_t RequestEligiblePromoItemDefinitionsIDs(CSteamID steamID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamInventory_RequestEligiblePromoItemDefinitionsIDs(CSteamAPIContext.GetSteamInventory(), steamID);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000785B File Offset: 0x00005A5B
		public static bool GetEligiblePromoItemDefinitionIDs(CSteamID steamID, SteamItemDef_t[] pItemDefIDs, ref uint punItemDefIDsArraySize)
		{
			InteropHelp.TestIfAvailableClient();
			if (pItemDefIDs != null && (long)pItemDefIDs.Length != (long)((ulong)punItemDefIDsArraySize))
			{
				throw new ArgumentException("pItemDefIDs must be the same size as punItemDefIDsArraySize!");
			}
			return NativeMethods.ISteamInventory_GetEligiblePromoItemDefinitionIDs(CSteamAPIContext.GetSteamInventory(), steamID, pItemDefIDs, ref punItemDefIDsArraySize);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00007886 File Offset: 0x00005A86
		public static SteamAPICall_t StartPurchase(SteamItemDef_t[] pArrayItemDefs, uint[] punArrayQuantity, uint unArrayLength)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamInventory_StartPurchase(CSteamAPIContext.GetSteamInventory(), pArrayItemDefs, punArrayQuantity, unArrayLength);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000789F File Offset: 0x00005A9F
		public static SteamAPICall_t RequestPrices()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamInventory_RequestPrices(CSteamAPIContext.GetSteamInventory());
		}

		// Token: 0x0600028D RID: 653 RVA: 0x000078B5 File Offset: 0x00005AB5
		public static uint GetNumItemsWithPrices()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetNumItemsWithPrices(CSteamAPIContext.GetSteamInventory());
		}

		// Token: 0x0600028E RID: 654 RVA: 0x000078C8 File Offset: 0x00005AC8
		public static bool GetItemsWithPrices(SteamItemDef_t[] pArrayItemDefs, ulong[] pCurrentPrices, ulong[] pBasePrices, uint unArrayLength)
		{
			InteropHelp.TestIfAvailableClient();
			if (pArrayItemDefs != null && (long)pArrayItemDefs.Length != (long)((ulong)unArrayLength))
			{
				throw new ArgumentException("pArrayItemDefs must be the same size as unArrayLength!");
			}
			if (pCurrentPrices != null && (long)pCurrentPrices.Length != (long)((ulong)unArrayLength))
			{
				throw new ArgumentException("pCurrentPrices must be the same size as unArrayLength!");
			}
			if (pBasePrices != null && (long)pBasePrices.Length != (long)((ulong)unArrayLength))
			{
				throw new ArgumentException("pBasePrices must be the same size as unArrayLength!");
			}
			return NativeMethods.ISteamInventory_GetItemsWithPrices(CSteamAPIContext.GetSteamInventory(), pArrayItemDefs, pCurrentPrices, pBasePrices, unArrayLength);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000792A File Offset: 0x00005B2A
		public static bool GetItemPrice(SteamItemDef_t iDefinition, out ulong pCurrentPrice, out ulong pBasePrice)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetItemPrice(CSteamAPIContext.GetSteamInventory(), iDefinition, out pCurrentPrice, out pBasePrice);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000793E File Offset: 0x00005B3E
		public static SteamInventoryUpdateHandle_t StartUpdateProperties()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamInventoryUpdateHandle_t)NativeMethods.ISteamInventory_StartUpdateProperties(CSteamAPIContext.GetSteamInventory());
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00007954 File Offset: 0x00005B54
		public static bool RemoveProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchPropertyName))
			{
				result = NativeMethods.ISteamInventory_RemoveProperty(CSteamAPIContext.GetSteamInventory(), handle, nItemID, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00007998 File Offset: 0x00005B98
		public static bool SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, string pchPropertyValue)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchPropertyName))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchPropertyValue))
				{
					result = NativeMethods.ISteamInventory_SetPropertyString(CSteamAPIContext.GetSteamInventory(), handle, nItemID, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x000079FC File Offset: 0x00005BFC
		public static bool SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchPropertyName))
			{
				result = NativeMethods.ISteamInventory_SetPropertyBool(CSteamAPIContext.GetSteamInventory(), handle, nItemID, utf8StringHandle, bValue);
			}
			return result;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00007A44 File Offset: 0x00005C44
		public static bool SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, long nValue)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchPropertyName))
			{
				result = NativeMethods.ISteamInventory_SetPropertyInt64(CSteamAPIContext.GetSteamInventory(), handle, nItemID, utf8StringHandle, nValue);
			}
			return result;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00007A8C File Offset: 0x00005C8C
		public static bool SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t nItemID, string pchPropertyName, float flValue)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchPropertyName))
			{
				result = NativeMethods.ISteamInventory_SetPropertyFloat(CSteamAPIContext.GetSteamInventory(), handle, nItemID, utf8StringHandle, flValue);
			}
			return result;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00007AD4 File Offset: 0x00005CD4
		public static bool SubmitUpdateProperties(SteamInventoryUpdateHandle_t handle, out SteamInventoryResult_t pResultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_SubmitUpdateProperties(CSteamAPIContext.GetSteamInventory(), handle, out pResultHandle);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00007AE8 File Offset: 0x00005CE8
		public static bool InspectItem(out SteamInventoryResult_t pResultHandle, string pchItemToken)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchItemToken))
			{
				result = NativeMethods.ISteamInventory_InspectItem(CSteamAPIContext.GetSteamInventory(), out pResultHandle, utf8StringHandle);
			}
			return result;
		}
	}
}
