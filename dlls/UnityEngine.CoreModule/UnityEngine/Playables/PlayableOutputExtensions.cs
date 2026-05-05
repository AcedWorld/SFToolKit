using System;

namespace UnityEngine.Playables
{
	// Token: 0x020004A7 RID: 1191
	public static class PlayableOutputExtensions
	{
		// Token: 0x06002979 RID: 10617 RVA: 0x00046594 File Offset: 0x00044794
		public static bool IsOutputNull<U>(this U output) where U : struct, IPlayableOutput
		{
			return output.GetHandle().IsNull();
		}

		// Token: 0x0600297A RID: 10618 RVA: 0x000465BC File Offset: 0x000447BC
		public static bool IsOutputValid<U>(this U output) where U : struct, IPlayableOutput
		{
			return output.GetHandle().IsValid();
		}

		// Token: 0x0600297B RID: 10619 RVA: 0x000465E4 File Offset: 0x000447E4
		public static Object GetReferenceObject<U>(this U output) where U : struct, IPlayableOutput
		{
			return output.GetHandle().GetReferenceObject();
		}

		// Token: 0x0600297C RID: 10620 RVA: 0x0004660C File Offset: 0x0004480C
		public static void SetReferenceObject<U>(this U output, Object value) where U : struct, IPlayableOutput
		{
			output.GetHandle().SetReferenceObject(value);
		}

		// Token: 0x0600297D RID: 10621 RVA: 0x00046634 File Offset: 0x00044834
		public static Object GetUserData<U>(this U output) where U : struct, IPlayableOutput
		{
			return output.GetHandle().GetUserData();
		}

		// Token: 0x0600297E RID: 10622 RVA: 0x0004665C File Offset: 0x0004485C
		public static void SetUserData<U>(this U output, Object value) where U : struct, IPlayableOutput
		{
			output.GetHandle().SetUserData(value);
		}

		// Token: 0x0600297F RID: 10623 RVA: 0x00046684 File Offset: 0x00044884
		public static Playable GetSourcePlayable<U>(this U output) where U : struct, IPlayableOutput
		{
			return new Playable(output.GetHandle().GetSourcePlayable());
		}

		// Token: 0x06002980 RID: 10624 RVA: 0x000466B0 File Offset: 0x000448B0
		public static void SetSourcePlayable<U, V>(this U output, V value) where U : struct, IPlayableOutput where V : struct, IPlayable
		{
			output.GetHandle().SetSourcePlayable(value.GetHandle(), output.GetSourceOutputPort<U>());
		}

		// Token: 0x06002981 RID: 10625 RVA: 0x000466E8 File Offset: 0x000448E8
		public static void SetSourcePlayable<U, V>(this U output, V value, int port) where U : struct, IPlayableOutput where V : struct, IPlayable
		{
			output.GetHandle().SetSourcePlayable(value.GetHandle(), port);
		}

		// Token: 0x06002982 RID: 10626 RVA: 0x0004671C File Offset: 0x0004491C
		public static int GetSourceOutputPort<U>(this U output) where U : struct, IPlayableOutput
		{
			return output.GetHandle().GetSourceOutputPort();
		}

		// Token: 0x06002983 RID: 10627 RVA: 0x00046744 File Offset: 0x00044944
		public static float GetWeight<U>(this U output) where U : struct, IPlayableOutput
		{
			return output.GetHandle().GetWeight();
		}

		// Token: 0x06002984 RID: 10628 RVA: 0x0004676C File Offset: 0x0004496C
		public static void SetWeight<U>(this U output, float value) where U : struct, IPlayableOutput
		{
			output.GetHandle().SetWeight(value);
		}

		// Token: 0x06002985 RID: 10629 RVA: 0x00046794 File Offset: 0x00044994
		public static void PushNotification<U>(this U output, Playable origin, INotification notification, object context = null) where U : struct, IPlayableOutput
		{
			output.GetHandle().PushNotification(origin.GetHandle(), notification, context);
		}

		// Token: 0x06002986 RID: 10630 RVA: 0x000467C4 File Offset: 0x000449C4
		public static INotificationReceiver[] GetNotificationReceivers<U>(this U output) where U : struct, IPlayableOutput
		{
			return output.GetHandle().GetNotificationReceivers();
		}

		// Token: 0x06002987 RID: 10631 RVA: 0x000467EC File Offset: 0x000449EC
		public static void AddNotificationReceiver<U>(this U output, INotificationReceiver receiver) where U : struct, IPlayableOutput
		{
			output.GetHandle().AddNotificationReceiver(receiver);
		}

		// Token: 0x06002988 RID: 10632 RVA: 0x00046814 File Offset: 0x00044A14
		public static void RemoveNotificationReceiver<U>(this U output, INotificationReceiver receiver) where U : struct, IPlayableOutput
		{
			output.GetHandle().RemoveNotificationReceiver(receiver);
		}

		// Token: 0x06002989 RID: 10633 RVA: 0x0004683C File Offset: 0x00044A3C
		[Obsolete("Method GetSourceInputPort has been renamed to GetSourceOutputPort (UnityUpgradable) -> GetSourceOutputPort<U>(*)", false)]
		public static int GetSourceInputPort<U>(this U output) where U : struct, IPlayableOutput
		{
			return output.GetHandle().GetSourceOutputPort();
		}

		// Token: 0x0600298A RID: 10634 RVA: 0x00046863 File Offset: 0x00044A63
		[Obsolete("Method SetSourceInputPort has been deprecated. Use SetSourcePlayable(Playable, Port) instead.", false)]
		public static void SetSourceInputPort<U>(this U output, int value) where U : struct, IPlayableOutput
		{
			output.SetSourcePlayable(output.GetSourcePlayable<U>(), value);
		}

		// Token: 0x0600298B RID: 10635 RVA: 0x00046863 File Offset: 0x00044A63
		[Obsolete("Method SetSourceOutputPort has been deprecated. Use SetSourcePlayable(Playable, Port) instead.", false)]
		public static void SetSourceOutputPort<U>(this U output, int value) where U : struct, IPlayableOutput
		{
			output.SetSourcePlayable(output.GetSourcePlayable<U>(), value);
		}
	}
}
