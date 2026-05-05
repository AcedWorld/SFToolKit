using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SFToolKit
{
    /// <summary>
    /// Reflection helpers for interacting with the game's PlayerNameTag component and Steamworks data.
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
        private static readonly FieldInfo PlayerNamesField =
            PlayerNameTagType?.GetField("playerNames", BindingFlags.Static | BindingFlags.NonPublic);
        private static readonly Type NetworkObjectType = ResolveType("Unity.Netcode.NetworkObject");
        private static readonly PropertyInfo NetworkObjectIdProperty =
            NetworkObjectType?.GetProperty("NetworkObjectId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        private static readonly PropertyInfo OwnerClientIdProperty =
            NetworkObjectType?.GetProperty("OwnerClientId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        // Steamworks reflections (optional, guarded at runtime)
        private static readonly Type SteamManagerType = ResolveType("SteamManager");
        private static readonly PropertyInfo SteamManagerInitializedProperty =
            SteamManagerType?.GetProperty("Initialized", BindingFlags.Static | BindingFlags.Public);
        private static readonly Type SteamUserType = ResolveType("Steamworks.SteamUser");
        private static readonly MethodInfo SteamUserGetSteamId =
            SteamUserType?.GetMethod("GetSteamID", BindingFlags.Static | BindingFlags.Public, null, Type.EmptyTypes, null);
        private static readonly Type SteamIdType = SteamUserType?.Assembly?.GetType("Steamworks.CSteamID");
        private static readonly FieldInfo SteamIdValueField =
            SteamIdType?.GetField("m_SteamID", BindingFlags.Instance | BindingFlags.NonPublic);
        private static readonly ConstructorInfo SteamIdConstructor =
            SteamIdType?.GetConstructor(new[] { typeof(ulong) });
        private static readonly Type SteamFriendsType = ResolveType("Steamworks.SteamFriends");
        private static readonly MethodInfo SteamFriendsGetPersonaName =
            SteamFriendsType?.GetMethod("GetFriendPersonaName", BindingFlags.Static | BindingFlags.Public, null, SteamIdType != null ? new[] { SteamIdType } : Type.EmptyTypes, null);

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

        public static IReadOnlyList<Component> FindAllPlayerTags()
        {
            if (PlayerNameTagType == null)
                return Array.Empty<Component>();

            var list = new List<Component>();
            foreach (var obj in UnityEngine.Object.FindObjectsOfType(PlayerNameTagType))
            {
                if (obj is Component component)
                    list.Add(component);
            }
            return list;
        }

        public static IReadOnlyDictionary<ulong, string> GetKnownPlayerNames()
        {
            var names = new Dictionary<ulong, string>();
            if (PlayerNamesField == null)
                return names;

            object raw = null;
            try { raw = PlayerNamesField.GetValue(null); }
            catch { }

            if (raw is IDictionary dictionary)
            {
                foreach (DictionaryEntry entry in dictionary)
                {
                    try
                    {
                        ulong key = 0UL;
                        if (entry.Key is ulong directKey)
                            key = directKey;
                        else if (entry.Key is IConvertible convertibleKey)
                            key = convertibleKey.ToUInt64(null);
                        else
                            continue;

                        string value = entry.Value as string ?? string.Empty;
                        names[key] = value;
                    }
                    catch { }
                }
            }

            return names;
        }

        public static IReadOnlyList<PlayerSnapshot> CapturePlayerSnapshots()
        {
            var snapshots = new List<PlayerSnapshot>();
            var tags = FindAllPlayerTags();
            var nameCache = GetKnownPlayerNames();

            foreach (var tag in tags)
            {
                if (tag == null) continue;

                ulong netId = GetNetworkObjectId(tag);
                ulong ownerId = GetOwnerClientId(tag);
                string currentName = GetCurrentName(tag);
                if (string.IsNullOrWhiteSpace(currentName) && netId != 0UL && nameCache.TryGetValue(netId, out var cachedName))
                    currentName = cachedName;

                snapshots.Add(new PlayerSnapshot
                {
                    Tag = tag,
                    NetworkObjectId = netId,
                    OwnerClientId = ownerId,
                    DisplayName = currentName ?? string.Empty,
                    IsLocalOwner = IsOwner(tag)
                });
            }

            // include entries from the server dictionary that may not have spawned tags yet
            foreach (var kv in nameCache)
            {
                bool exists = false;
                for (int i = 0; i < snapshots.Count; i++)
                {
                    if (snapshots[i].NetworkObjectId == kv.Key)
                    {
                        exists = true;
                        if (string.IsNullOrWhiteSpace(snapshots[i].DisplayName))
                        {
                            var snapshot = snapshots[i];
                            snapshot.DisplayName = kv.Value ?? string.Empty;
                            snapshots[i] = snapshot;
                        }
                        break;
                    }
                }

                if (!exists)
                {
                    snapshots.Add(new PlayerSnapshot
                    {
                        Tag = null,
                        NetworkObjectId = kv.Key,
                        OwnerClientId = 0UL,
                        DisplayName = kv.Value ?? string.Empty,
                        IsLocalOwner = false
                    });
                }
            }

            return snapshots;
        }

        public static string GetCurrentName(Component tag)
        {
            if (tag == null || PlayerNameField == null)
                return string.Empty;

            try
            {
                return PlayerNameField.GetValue(tag) as string ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
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

        public static bool IsOwner(Component component)
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

        public static ulong GetNetworkObjectId(Component component)
        {
            var netObj = GetNetworkObject(component);
            if (netObj == null || NetworkObjectIdProperty == null)
                return 0UL;

            try
            {
                object idValue = NetworkObjectIdProperty.GetValue(netObj, null);
                if (idValue is ulong id)
                    return id;
                if (idValue is IConvertible convertible)
                    return convertible.ToUInt64(null);
            }
            catch
            {
            }

            return 0UL;
        }

        public static ulong GetOwnerClientId(Component component)
        {
            var netObj = GetNetworkObject(component);
            if (netObj == null || OwnerClientIdProperty == null)
                return 0UL;

            try
            {
                object idValue = OwnerClientIdProperty.GetValue(netObj, null);
                if (idValue is ulong id)
                    return id;
                if (idValue is IConvertible convertible)
                    return convertible.ToUInt64(null);
            }
            catch
            {
            }

            return 0UL;
        }

        public static bool TryGetLocalSteamId(out ulong steamId)
        {
            steamId = 0UL;

            if (SteamUserGetSteamId == null)
                return false;

            if (SteamManagerInitializedProperty != null)
            {
                try
                {
                    object initialized = SteamManagerInitializedProperty.GetValue(null, null);
                    if (initialized is bool isInitialized && !isInitialized)
                        return false;
                }
                catch
                {
                    // ignored
                }
            }

            try
            {
                object steamIdStruct = SteamUserGetSteamId.Invoke(null, null);
                return TryExtractSteamIdValue(steamIdStruct, out steamId);
            }
            catch
            {
                return false;
            }
        }

        public static bool TryGetPersonaName(ulong steamId, out string personaName)
        {
            personaName = null;

            if (SteamFriendsGetPersonaName == null || SteamIdConstructor == null)
                return false;

            if (!TryCreateSteamIdStruct(steamId, out var steamIdStruct))
                return false;

            try
            {
                object result = SteamFriendsGetPersonaName.Invoke(null, new[] { steamIdStruct });
                if (result is string name && !string.IsNullOrWhiteSpace(name))
                {
                    personaName = name;
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }

        private static object GetNetworkObject(Component component)
        {
            if (component == null || NetworkObjectProperty == null)
                return null;

            try
            {
                return NetworkObjectProperty.GetValue(component, null);
            }
            catch
            {
                return null;
            }
        }

        private static bool TryCreateSteamIdStruct(ulong value, out object steamIdStruct)
        {
            steamIdStruct = null;
            if (SteamIdConstructor == null)
                return false;

            try
            {
                steamIdStruct = SteamIdConstructor.Invoke(new object[] { value });
                return steamIdStruct != null;
            }
            catch
            {
                return false;
            }
        }

        private static bool TryExtractSteamIdValue(object steamIdStruct, out ulong value)
        {
            value = 0UL;
            if (steamIdStruct == null)
                return false;

            if (SteamIdValueField != null)
            {
                try
                {
                    object raw = SteamIdValueField.GetValue(steamIdStruct);
                    if (raw is ulong direct)
                    {
                        value = direct;
                        return true;
                    }
                    if (raw is long signed && signed > 0)
                    {
                        value = unchecked((ulong)signed);
                        return true;
                    }
                }
                catch
                {
                }
            }

            if (ulong.TryParse(steamIdStruct.ToString(), out var parsed))
            {
                value = parsed;
                return true;
            }

            return false;
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
            if (string.IsNullOrEmpty(typeName))
                return null;

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = null;
                try { type = assembly.GetType(typeName, false); }
                catch { }

                if (type != null)
                    return type;
            }
            return null;
        }

        public class PlayerSnapshot
        {
            public Component Tag { get; set; }
            public ulong NetworkObjectId { get; set; }
            public ulong OwnerClientId { get; set; }
            public string DisplayName { get; set; }
            public bool IsLocalOwner { get; set; }
        }
    }
}
