using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x02000004 RID: 4
	public abstract class BufferedLinearInterpolator<T> where T : struct
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		private bool InvalidState
		{
			get
			{
				return this.m_Buffer.Count == 0 && this.m_LifetimeConsumedCount == 0;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020DA File Offset: 0x000002DA
		public void Clear()
		{
			this.m_Buffer.Clear();
			this.m_EndTimeConsumed = 0.0;
			this.m_StartTimeConsumed = 0.0;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002108 File Offset: 0x00000308
		public void ResetTo(T targetValue, double serverTime)
		{
			this.m_LifetimeConsumedCount = 1;
			this.m_InterpStartValue = targetValue;
			this.m_InterpEndValue = targetValue;
			this.m_CurrentInterpValue = targetValue;
			this.m_Buffer.Clear();
			this.m_EndTimeConsumed = 0.0;
			this.m_StartTimeConsumed = 0.0;
			this.Update(0f, serverTime, serverTime);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002168 File Offset: 0x00000368
		private void TryConsumeFromBuffer(double renderTime, double serverTime)
		{
			int num = 0;
			if (renderTime >= this.m_EndTimeConsumed)
			{
				BufferedLinearInterpolator<T>.BufferedItem? bufferedItem = null;
				for (int i = this.m_Buffer.Count - 1; i >= 0; i--)
				{
					BufferedLinearInterpolator<T>.BufferedItem bufferedItem2 = this.m_Buffer[i];
					if (bufferedItem2.TimeSent <= serverTime)
					{
						if (bufferedItem == null || bufferedItem2.TimeSent > bufferedItem.Value.TimeSent)
						{
							if (this.m_LifetimeConsumedCount == 0)
							{
								this.m_StartTimeConsumed = bufferedItem2.TimeSent;
								this.m_InterpStartValue = bufferedItem2.Item;
							}
							else if (num == 0)
							{
								this.m_StartTimeConsumed = this.m_EndTimeConsumed;
								this.m_InterpStartValue = this.m_InterpEndValue;
							}
							if (bufferedItem2.TimeSent > this.m_EndTimeConsumed)
							{
								bufferedItem = new BufferedLinearInterpolator<T>.BufferedItem?(bufferedItem2);
								this.m_EndTimeConsumed = bufferedItem2.TimeSent;
								this.m_InterpEndValue = bufferedItem2.Item;
							}
						}
						this.m_Buffer.RemoveAt(i);
						num++;
						this.m_LifetimeConsumedCount++;
					}
				}
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002268 File Offset: 0x00000468
		public T Update(float deltaTime, NetworkTime serverTime)
		{
			return this.Update(deltaTime, serverTime.TimeTicksAgo(1).Time, serverTime.Time);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002294 File Offset: 0x00000494
		public T Update(float deltaTime, double renderTime, double serverTime)
		{
			this.TryConsumeFromBuffer(renderTime, serverTime);
			if (this.InvalidState)
			{
				throw new InvalidOperationException("trying to update interpolator when no data has been added to it yet");
			}
			if (this.m_LifetimeConsumedCount >= 1)
			{
				float num = 1f;
				double num2 = this.m_EndTimeConsumed - this.m_StartTimeConsumed;
				if (num2 > 9.999999439624929E-11)
				{
					num = (float)((renderTime - this.m_StartTimeConsumed) / num2);
					if (num < 0f)
					{
						if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
						{
							NetworkLog.LogError(string.Format("renderTime was before m_StartTimeConsumed. This should never happen. {0} is {1}, {2} is {3}", new object[]
							{
								"renderTime",
								renderTime,
								"m_StartTimeConsumed",
								this.m_StartTimeConsumed
							}));
						}
						num = 0f;
					}
					if (num > this.MaxInterpolationBound)
					{
						num = 1f;
					}
				}
				T end = this.InterpolateUnclamped(this.m_InterpStartValue, this.m_InterpEndValue, num);
				this.m_CurrentInterpValue = this.Interpolate(this.m_CurrentInterpValue, end, deltaTime / this.MaximumInterpolationTime);
			}
			this.m_NbItemsReceivedThisFrame = 0;
			return this.m_CurrentInterpValue;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002394 File Offset: 0x00000594
		public void AddMeasurement(T newMeasurement, double sentTime)
		{
			this.m_NbItemsReceivedThisFrame++;
			if (this.m_NbItemsReceivedThisFrame > 100)
			{
				if (this.m_LastBufferedItemReceived.TimeSent < sentTime)
				{
					this.m_LastBufferedItemReceived = new BufferedLinearInterpolator<T>.BufferedItem(newMeasurement, sentTime);
					this.ResetTo(newMeasurement, sentTime);
					this.m_Buffer.Add(this.m_LastBufferedItemReceived);
				}
				return;
			}
			if (sentTime > this.m_EndTimeConsumed || this.m_LifetimeConsumedCount == 0)
			{
				this.m_LastBufferedItemReceived = new BufferedLinearInterpolator<T>.BufferedItem(newMeasurement, sentTime);
				this.m_Buffer.Add(this.m_LastBufferedItemReceived);
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000241D File Offset: 0x0000061D
		public T GetInterpolatedValue()
		{
			return this.m_CurrentInterpValue;
		}

		// Token: 0x0600000B RID: 11
		protected abstract T Interpolate(T start, T end, float time);

		// Token: 0x0600000C RID: 12
		protected abstract T InterpolateUnclamped(T start, T end, float time);

		// Token: 0x04000006 RID: 6
		internal float MaxInterpolationBound = 3f;

		// Token: 0x04000007 RID: 7
		public float MaximumInterpolationTime = 0.1f;

		// Token: 0x04000008 RID: 8
		private const double k_SmallValue = 9.999999439624929E-11;

		// Token: 0x04000009 RID: 9
		private T m_InterpStartValue;

		// Token: 0x0400000A RID: 10
		private T m_CurrentInterpValue;

		// Token: 0x0400000B RID: 11
		private T m_InterpEndValue;

		// Token: 0x0400000C RID: 12
		private double m_EndTimeConsumed;

		// Token: 0x0400000D RID: 13
		private double m_StartTimeConsumed;

		// Token: 0x0400000E RID: 14
		private readonly List<BufferedLinearInterpolator<T>.BufferedItem> m_Buffer = new List<BufferedLinearInterpolator<T>.BufferedItem>(100);

		// Token: 0x0400000F RID: 15
		private const int k_BufferCountLimit = 100;

		// Token: 0x04000010 RID: 16
		private BufferedLinearInterpolator<T>.BufferedItem m_LastBufferedItemReceived;

		// Token: 0x04000011 RID: 17
		private int m_NbItemsReceivedThisFrame;

		// Token: 0x04000012 RID: 18
		private int m_LifetimeConsumedCount;

		// Token: 0x02000005 RID: 5
		private struct BufferedItem
		{
			// Token: 0x0600000E RID: 14 RVA: 0x00002450 File Offset: 0x00000650
			public BufferedItem(T item, double timeSent)
			{
				this.Item = item;
				this.TimeSent = timeSent;
			}

			// Token: 0x04000013 RID: 19
			public T Item;

			// Token: 0x04000014 RID: 20
			public double TimeSent;
		}
	}
}
