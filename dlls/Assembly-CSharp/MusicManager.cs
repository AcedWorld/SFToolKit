using System;
using Michsky.UI.ModernUIPack;
using UnityEngine;

// Token: 0x0200008E RID: 142
public class MusicManager : MonoBehaviour
{
	// Token: 0x06000259 RID: 601 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x0600025A RID: 602 RVA: 0x00013B58 File Offset: 0x00011D58
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.currentTrack = 0;
			this.PlaySong();
		}
		if (this.isSongPlaying && !this.audioSource.isPlaying && this.audioSource.clip != null)
		{
			this.isSongPlaying = false;
			this.OnSongEnd();
		}
	}

	// Token: 0x0600025B RID: 603 RVA: 0x00013BB0 File Offset: 0x00011DB0
	public void PlaySong()
	{
		Debug.Log("Playing " + this.trackList[this.currentTrack].trackTitle);
		this.notificationManager.title = this.trackList[this.currentTrack].trackTitle;
		this.notificationManager.description = this.trackList[this.currentTrack].trackArtist;
		this.notificationManager.UpdateUI();
		this.notificationManager.OpenNotification();
		this.audioSource.clip = this.trackList[this.currentTrack].songFile;
		this.audioSource.Play();
		this.isSongPlaying = true;
	}

	// Token: 0x0600025C RID: 604 RVA: 0x00013C5D File Offset: 0x00011E5D
	public void OnSongEnd()
	{
		Debug.Log("Song Ended");
		if (this.currentTrack + 1 < this.trackList.Length)
		{
			this.currentTrack++;
		}
		else
		{
			this.currentTrack = 0;
		}
		this.PlaySong();
	}

	// Token: 0x040002F3 RID: 755
	private bool isSongPlaying;

	// Token: 0x040002F4 RID: 756
	public NotificationManager notificationManager;

	// Token: 0x040002F5 RID: 757
	public AudioSource audioSource;

	// Token: 0x040002F6 RID: 758
	public int currentTrack;

	// Token: 0x040002F7 RID: 759
	public TrackList[] trackList;
}
