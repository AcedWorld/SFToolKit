using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Core.Components;
using Unity.Services.Core.Internal;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.Services.Authentication.Components
{
	// Token: 0x0200006F RID: 111
	[AddComponentMenu("Services/Player Authentication")]
	public class PlayerAuthentication : ServicesBehaviour
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600030E RID: 782 RVA: 0x00007A0C File Offset: 0x00005C0C
		// (set) Token: 0x0600030F RID: 783 RVA: 0x00007A14 File Offset: 0x00005C14
		public IAuthenticationService AuthenticationService { get; internal set; }

		// Token: 0x06000310 RID: 784 RVA: 0x00007A1D File Offset: 0x00005C1D
		internal PlayerAuthentication()
		{
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00007A30 File Offset: 0x00005C30
		protected override void OnServicesReady()
		{
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00007A34 File Offset: 0x00005C34
		protected override void OnServicesInitialized()
		{
			PlayerAuthentication.<OnServicesInitialized>d__16 <OnServicesInitialized>d__;
			<OnServicesInitialized>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnServicesInitialized>d__.<>4__this = this;
			<OnServicesInitialized>d__.<>1__state = -1;
			<OnServicesInitialized>d__.<>t__builder.Start<PlayerAuthentication.<OnServicesInitialized>d__16>(ref <OnServicesInitialized>d__);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00007A6C File Offset: 0x00005C6C
		protected override void Cleanup()
		{
			if (this.AuthenticationService != null)
			{
				this.AuthenticationService.SignInFailed -= new Action<RequestFailedException>(this.OnSignInFailed);
				this.AuthenticationService.SignedOut -= this.OnSignedOut;
				this.AuthenticationService.Expired -= this.OnExpired;
				this.AuthenticationService.SignInCodeReceived -= this.OnSignInCodeReceived;
				this.AuthenticationService.SignInCodeExpired -= this.OnSignInCodeExpired;
			}
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00007AF4 File Offset: 0x00005CF4
		internal virtual void SetAuthenticationService()
		{
			this.AuthenticationService = base.Services.GetAuthenticationService();
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00007B08 File Offset: 0x00005D08
		internal Task SetupAsync()
		{
			PlayerAuthentication.<SetupAsync>d__19 <SetupAsync>d__;
			<SetupAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SetupAsync>d__.<>4__this = this;
			<SetupAsync>d__.<>1__state = -1;
			<SetupAsync>d__.<>t__builder.Start<PlayerAuthentication.<SetupAsync>d__19>(ref <SetupAsync>d__);
			return <SetupAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00007B4C File Offset: 0x00005D4C
		private Task SignInAnonymouslyAsync()
		{
			PlayerAuthentication.<SignInAnonymouslyAsync>d__20 <SignInAnonymouslyAsync>d__;
			<SignInAnonymouslyAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SignInAnonymouslyAsync>d__.<>4__this = this;
			<SignInAnonymouslyAsync>d__.<>1__state = -1;
			<SignInAnonymouslyAsync>d__.<>t__builder.Start<PlayerAuthentication.<SignInAnonymouslyAsync>d__20>(ref <SignInAnonymouslyAsync>d__);
			return <SignInAnonymouslyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00007B90 File Offset: 0x00005D90
		private Task FetchPlayerInfoAsync()
		{
			PlayerAuthentication.<FetchPlayerInfoAsync>d__21 <FetchPlayerInfoAsync>d__;
			<FetchPlayerInfoAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<FetchPlayerInfoAsync>d__.<>4__this = this;
			<FetchPlayerInfoAsync>d__.<>1__state = -1;
			<FetchPlayerInfoAsync>d__.<>t__builder.Start<PlayerAuthentication.<FetchPlayerInfoAsync>d__21>(ref <FetchPlayerInfoAsync>d__);
			return <FetchPlayerInfoAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00007BD4 File Offset: 0x00005DD4
		private Task FetchPlayerNameAsync()
		{
			PlayerAuthentication.<FetchPlayerNameAsync>d__22 <FetchPlayerNameAsync>d__;
			<FetchPlayerNameAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<FetchPlayerNameAsync>d__.<>4__this = this;
			<FetchPlayerNameAsync>d__.<>1__state = -1;
			<FetchPlayerNameAsync>d__.<>t__builder.Start<PlayerAuthentication.<FetchPlayerNameAsync>d__22>(ref <FetchPlayerNameAsync>d__);
			return <FetchPlayerNameAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00007C18 File Offset: 0x00005E18
		private void OnSignedIn()
		{
			PlayerAuthentication.<OnSignedIn>d__23 <OnSignedIn>d__;
			<OnSignedIn>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnSignedIn>d__.<>4__this = this;
			<OnSignedIn>d__.<>1__state = -1;
			<OnSignedIn>d__.<>t__builder.Start<PlayerAuthentication.<OnSignedIn>d__23>(ref <OnSignedIn>d__);
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00007C4F File Offset: 0x00005E4F
		private void OnSignInFailed(Exception exception)
		{
			PlayerAuthenticationEvents events = this.Events;
			if (events == null)
			{
				return;
			}
			UnityEvent<Exception> signInFailed = events.SignInFailed;
			if (signInFailed == null)
			{
				return;
			}
			signInFailed.Invoke(exception);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00007C6C File Offset: 0x00005E6C
		private void OnSignedOut()
		{
			this.ResetAutomation();
			PlayerAuthenticationEvents events = this.Events;
			if (events == null)
			{
				return;
			}
			UnityEvent signedOut = events.SignedOut;
			if (signedOut == null)
			{
				return;
			}
			signedOut.Invoke();
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00007C8E File Offset: 0x00005E8E
		private void OnExpired()
		{
			PlayerAuthenticationEvents events = this.Events;
			if (events == null)
			{
				return;
			}
			UnityEvent expired = events.Expired;
			if (expired == null)
			{
				return;
			}
			expired.Invoke();
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00007CAA File Offset: 0x00005EAA
		private void OnSignInCodeReceived(SignInCodeInfo info)
		{
			PlayerAuthenticationEvents events = this.Events;
			if (events == null)
			{
				return;
			}
			UnityEvent<SignInCodeInfo> signInCodeReceived = events.SignInCodeReceived;
			if (signInCodeReceived == null)
			{
				return;
			}
			signInCodeReceived.Invoke(info);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00007CC7 File Offset: 0x00005EC7
		private void OnSignInCodeExpired()
		{
			PlayerAuthenticationEvents events = this.Events;
			if (events == null)
			{
				return;
			}
			UnityEvent signInCodeExpired = events.SignInCodeExpired;
			if (signInCodeExpired == null)
			{
				return;
			}
			signInCodeExpired.Invoke();
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00007CE3 File Offset: 0x00005EE3
		private void ResetAutomation()
		{
			this.IsInfoFetched = false;
			this.IsNameFetched = false;
		}

		// Token: 0x0400015A RID: 346
		[Header("On Initialization")]
		[SerializeField]
		[Tooltip("Option to set a custom profile to scope persisted credentials and get different players.")]
		public bool SetCustomProfile;

		// Token: 0x0400015B RID: 347
		[SerializeField]
		[Visibility("SetCustomProfile", true)]
		[Tooltip("The profile is a local scope for persisted player credentials that you can use to get different players.")]
		public string Profile;

		// Token: 0x0400015C RID: 348
		[SerializeField]
		[Tooltip("Option to sign in anonymously automatically after services initialization.")]
		public bool SignInAnonymously;

		// Token: 0x0400015D RID: 349
		[Header("On Sign In")]
		[SerializeField]
		[Tooltip("Fetches the player info upon sign in. This provides the player creation time, username, etc.")]
		public bool FetchPlayerInfo;

		// Token: 0x0400015E RID: 350
		[SerializeField]
		[Tooltip("Fetches the player name upon sign in.")]
		public bool FetchPlayerName;

		// Token: 0x0400015F RID: 351
		[SerializeField]
		[Visibility("FetchPlayerName", true)]
		[Tooltip("Pass in the option to autogenerate the name if none exist.")]
		public bool GenerateName;

		// Token: 0x04000160 RID: 352
		[Header("Events")]
		[SerializeField]
		public PlayerAuthenticationEvents Events = new PlayerAuthenticationEvents();

		// Token: 0x04000161 RID: 353
		internal bool IsSetupDone;

		// Token: 0x04000162 RID: 354
		internal bool IsInfoFetched;

		// Token: 0x04000163 RID: 355
		internal bool IsNameFetched;
	}
}
