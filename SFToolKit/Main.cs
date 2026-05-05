using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace SFToolKit
{
    [EnableReloading]
    public static class Main
    {
        private static GameObject _root;
        private static Harmony _harmony;
        private static string _modId;

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            _modId = modEntry.Info.Id;
            modEntry.OnUnload = Unload;

            _harmony = new Harmony(_modId);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());

            if (_root == null)
            {
                _root = new GameObject("SFToolKit");
                Object.DontDestroyOnLoad(_root);
                _root.AddComponent<SFMenu>();
            }

            return true;
        }

        public static bool Unload(UnityModManager.ModEntry modEntry)
        {
            if (_harmony != null)
            {
                _harmony.UnpatchAll(_modId);
                _harmony = null;
            }

            if (_root != null)
            {
                Object.Destroy(_root);
                _root = null;
            }

            return true;
        }
    }
}
