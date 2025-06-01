using System;
using System.Reflection;
using Harmony12;
using UnityEngine;
using UnityModManagerNet;
using static UnityModManagerNet.UnityModManager;

namespace SFToolKit
{
    // Token: 0x02000003 RID: 3
    [EnableReloading]
    public static class Main
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002944 File Offset: 0x00000B44
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            modEntry.OnUnload = Unload;
            Main.modId = modEntry.Info.Id;
            HarmonyInstance.Create(modEntry.Info.Id).PatchAll(Assembly.GetExecutingAssembly());
            GameObject gameObject = new GameObject();
            gameObject.name = "SFMenu";
            gameObject.AddComponent<Menu>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            return true;
        }

        public static bool Unload(ModEntry modEntry)
        {
            return true;
        }

        // Token: 0x0400000E RID: 14
        public static string modId;
    }
}
