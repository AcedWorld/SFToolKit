using System;
using System.Reflection;
using UnityEngine;

namespace SFToolKit
{
    /// <summary>
    /// Utilities for interacting with the game's PlayerNameTag component without compile-time coupling.
    /// </summary>
    public static class NameTagHelper
    {
        private static readonly Type PlayerNameTagType = ResolveType("PlayerNameTag");
        private static readonly FieldInfo PlayerNameField =
            PlayerNameTagType?.GetField("playerName", BindingFlags.Instance | BindingFlags.NonPublic);
        private static readonly MethodInfo RegisterNameRpc =
            PlayerNameTagType?.GetMethod("RegisterPlayerNameServerRpc", BindingFlags.Instance | BindingFlags.NonPublic);
        private static readonly PropertyInfo IsOwnerProperty =
            PlayerNameTagType?.GetProperty("IsOwner", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        private static readonly PropertyInfo NetworkObjectProperty =
            PlayerNameTagType?.GetProperty("NetworkObject", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        private static readonly PropertyInfo NetworkObjectIdProperty =
            ResolveType("Unity.Netcode.NetworkObject")?.GetProperty("NetworkObjectId", BindingFlags.Instance | BindingFlags.Public);

        private static Component cachedLocalTag;
        private static float lastLookupTime;
        private const float LookupCooldown = 0.5f;

        public static Component FindLocalPlayerTag()
        {
            if (PlayerNameTagType == null)
                return null;

            if (IsComponentActive(cachedLocalTag))
                return cachedLocalTag;

            if (Time.time - lastLookupTime < LookupCooldown)
                return cachedLocalTag;

            lastLookupTime = Time.time;

            foreach (var obj in UnityEngine.Object.FindObjectsOfType(PlayerNameTagType))
            {
                if (obj is Component component && IsOwner(component))
                {
                    cachedLocalTag = component;
                    break;
                }
            }

            return cachedLocalTag;
        }

        public static string GetCurrentName(Component tag)
        {
            if (tag == null || PlayerNameField == null)
                return string.Empty;

            return PlayerNameField.GetValue(tag) as string ?? string.Empty;
        }

        public static bool TryApplyName(string rawName, out string errorMessage)
        {
            if (PlayerNameTagType == null || PlayerNameField == null || RegisterNameRpc == null)
            {
                errorMessage = "Name tag metadata unavailable.";
                return false;
            }

            var tag = FindLocalPlayerTag();
            if (tag == null)
            {
                errorMessage = "Local player name tag not found yet.";
                return false;
            }

            string nameToSend = string.IsNullOrWhiteSpace(rawName)
                ? $"Player {GetNetworkObjectId(tag)}"
                : rawName;

            try
            {
                var parameters = RegisterNameRpc.GetParameters();
                if (parameters.Length > 1)
                {
                    var paramType = parameters[1].ParameterType;
                    object defaultValue = paramType.IsValueType ? Activator.CreateInstance(paramType) : null;
                    RegisterNameRpc.Invoke(tag, new object[] { nameToSend, defaultValue });
                }
                else
                {
                    RegisterNameRpc.Invoke(tag, new object[] { nameToSend });
                }

                PlayerNameField.SetValue(tag, nameToSend);
                errorMessage = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Failed to send name: {ex.Message}";
                return false;
            }
        }

        private static bool IsOwner(Component component)
        {
            if (component == null || IsOwnerProperty == null)
                return false;

            try
            {
                object value = IsOwnerProperty.GetValue(component, null);
                return value is bool result && result;
            }
            catch
            {
                return false;
            }
        }

        private static ulong GetNetworkObjectId(Component component)
        {
            if (component == null || NetworkObjectProperty == null || NetworkObjectIdProperty == null)
                return 0UL;

            try
            {
                var netObj = NetworkObjectProperty.GetValue(component, null);
                if (netObj == null)
                    return 0UL;
                object idValue = NetworkObjectIdProperty.GetValue(netObj, null);
                return idValue is ulong id ? id : 0UL;
            }
            catch
            {
                return 0UL;
            }
        }

        private static bool IsComponentActive(Component component)
        {
            if (component == null)
                return false;

            if (component is Behaviour behaviour)
                return behaviour.isActiveAndEnabled;

            return component.gameObject != null && component.gameObject.activeInHierarchy;
        }

        private static Type ResolveType(string typeName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType(typeName, false);
                if (type != null)
                    return type;
            }
            return null;
        }
    }
}
