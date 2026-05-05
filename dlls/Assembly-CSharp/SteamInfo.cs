using System;
using Steamworks;
using UnityEngine;

// Token: 0x020001CD RID: 461
public class SteamInfo : MonoBehaviour
{
	// Token: 0x06000731 RID: 1841 RVA: 0x000365BC File Offset: 0x000347BC
	private void Start()
	{
		if (SteamManager.Initialized)
		{
			this.steamName = SteamFriends.GetPersonaName();
			this.steamID = SteamUser.GetSteamID();
			Debug.Log("Steam Name: " + this.steamName);
			Debug.Log(string.Format("Steam ID: {0}", this.steamID));
			this.steamAvatar = this.GetSteamImageAsTexture2D(SteamFriends.GetLargeFriendAvatar(this.steamID));
			return;
		}
		Debug.LogError("Steam is not initialized!");
	}

	// Token: 0x06000732 RID: 1842 RVA: 0x00036638 File Offset: 0x00034838
	private Texture2D GetSteamImageAsTexture2D(int iImage)
	{
		if (iImage == -1)
		{
			Debug.LogWarning("Could not get avatar.");
			return null;
		}
		uint num;
		uint num2;
		if (!SteamUtils.GetImageSize(iImage, out num, out num2) || num == 0U || num2 == 0U)
		{
			Debug.LogWarning("Invalid image size.");
			return null;
		}
		byte[] array = new byte[4U * num * num2];
		if (!SteamUtils.GetImageRGBA(iImage, array, (int)(4U * num * num2)))
		{
			Debug.LogWarning("Could not get image bytes.");
			return null;
		}
		Texture2D texture2D = new Texture2D((int)num, (int)num2, TextureFormat.RGBA32, false);
		texture2D.LoadRawTextureData(array);
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x04000CCF RID: 3279
	public string steamName;

	// Token: 0x04000CD0 RID: 3280
	public CSteamID steamID;

	// Token: 0x04000CD1 RID: 3281
	public Texture2D steamAvatar;
}
