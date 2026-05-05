using System;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x02000506 RID: 1286
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		// Token: 0x17000BF1 RID: 3057
		// (get) Token: 0x06003477 RID: 13431 RVA: 0x00028564 File Offset: 0x00026764
		public int Capacity
		{
			get
			{
				return this.nCDNafsgkwQdHWiWSxzILMSkqRQO;
			}
		}

		// Token: 0x17000BF2 RID: 3058
		// (get) Token: 0x06003478 RID: 13432 RVA: 0x0002856C File Offset: 0x0002676C
		public int BytesInBuffer
		{
			get
			{
				return this.DdZFVzgwDxjpWvBTwnVLdPriTYBob;
			}
		}

		// Token: 0x17000BF3 RID: 3059
		// (get) Token: 0x06003479 RID: 13433 RVA: 0x00028574 File Offset: 0x00026774
		public bool BufferOverrun
		{
			get
			{
				return this.zUdnUrEUoufxBuRaWILpOnlmiKNP;
			}
		}

		// Token: 0x17000BF4 RID: 3060
		// (get) Token: 0x0600347A RID: 13434 RVA: 0x0002857C File Offset: 0x0002677C
		public int ReadPosition
		{
			get
			{
				return (int)this.tYTrOqTojGqbXJHfImVsVpbIxzTm;
			}
		}

		// Token: 0x17000BF5 RID: 3061
		// (get) Token: 0x0600347B RID: 13435 RVA: 0x00028585 File Offset: 0x00026785
		public long WritePosition
		{
			get
			{
				return this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA;
			}
		}

		// Token: 0x0600347C RID: 13436 RVA: 0x0002858D File Offset: 0x0002678D
		public NativeRingBuffer(int A_1)
		{
			this.nCDNafsgkwQdHWiWSxzILMSkqRQO = A_1;
			if (A_1 <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			this.KGmFSYPeibiYqwaYMuOqwHUrNwKN = new NativeBuffer(A_1);
		}

		// Token: 0x0600347D RID: 13437 RVA: 0x000B4B28 File Offset: 0x000B2D28
		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.GetPointer((int)this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA);
			passId = this.MJgvUsbwFNrTijHaiBLpxfmSsAVU;
			if (zeroFill)
			{
				int num = 0;
				this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryFill(0, bufferLength, (int)this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryFill(0, bufferLength - num, num);
				}
			}
			this.kdgbAYeDIyHEIDDkihtfnffjMiWfB(bufferLength);
			return pointer;
		}

		// Token: 0x0600347E RID: 13438 RVA: 0x000B4B94 File Offset: 0x000B2D94
		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA;
			passId = this.MJgvUsbwFNrTijHaiBLpxfmSsAVU;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA, 0);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			this.kdgbAYeDIyHEIDDkihtfnffjMiWfB(num);
			return num;
		}

		// Token: 0x0600347F RID: 13439 RVA: 0x000B4C10 File Offset: 0x000B2E10
		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA;
			passId = this.MJgvUsbwFNrTijHaiBLpxfmSsAVU;
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > num)
			{
				numBytesToWrite = num;
			}
			int num2 = this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryWriteBytes(buffer, numBytesToWrite, (int)this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA, 0);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			this.kdgbAYeDIyHEIDDkihtfnffjMiWfB(num2);
			return num2;
		}

		// Token: 0x06003480 RID: 13440 RVA: 0x000B4C84 File Offset: 0x000B2E84
		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			int num;
			uint num2;
			return this.Write(buffer, bufferLength, numBytesToWrite, out num, out num2);
		}

		// Token: 0x06003481 RID: 13441 RVA: 0x000B4CA0 File Offset: 0x000B2EA0
		public int Write(byte[] buffer, int numBytesToWrite)
		{
			int num;
			uint num2;
			return this.Write(buffer, numBytesToWrite, out num, out num2);
		}

		// Token: 0x06003482 RID: 13442 RVA: 0x000B4CBC File Offset: 0x000B2EBC
		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || this.DdZFVzgwDxjpWvBTwnVLdPriTYBob == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > this.DdZFVzgwDxjpWvBTwnVLdPriTYBob)
			{
				numBytesToRead = this.DdZFVzgwDxjpWvBTwnVLdPriTYBob;
			}
			int num = this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)this.tYTrOqTojGqbXJHfImVsVpbIxzTm, 0);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			this.GtDgiUGyCyszYiQwKmbOFwtyvhAWA(num);
			return num;
		}

		// Token: 0x06003483 RID: 13443 RVA: 0x000B4D40 File Offset: 0x000B2F40
		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || this.DdZFVzgwDxjpWvBTwnVLdPriTYBob == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > this.DdZFVzgwDxjpWvBTwnVLdPriTYBob)
			{
				numBytesToRead = this.DdZFVzgwDxjpWvBTwnVLdPriTYBob;
			}
			int num2 = this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryReadBytes(buffer, numBytesToRead, (int)this.tYTrOqTojGqbXJHfImVsVpbIxzTm, 0);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			this.GtDgiUGyCyszYiQwKmbOFwtyvhAWA(num2);
			return num2;
		}

		// Token: 0x06003484 RID: 13444 RVA: 0x000B4DBC File Offset: 0x000B2FBC
		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || this.DdZFVzgwDxjpWvBTwnVLdPriTYBob == 0 || readStartIndex < 0 || readStartIndex >= this.nCDNafsgkwQdHWiWSxzILMSkqRQO)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > this.DdZFVzgwDxjpWvBTwnVLdPriTYBob)
			{
				numBytesToRead = this.DdZFVzgwDxjpWvBTwnVLdPriTYBob;
			}
			int num = this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex, 0);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			return num;
		}

		// Token: 0x06003485 RID: 13445 RVA: 0x000B4E44 File Offset: 0x000B3044
		public int RandomRead(byte[] buffer, int numBytesToRead, int readStartIndex)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || this.DdZFVzgwDxjpWvBTwnVLdPriTYBob == 0 || readStartIndex < 0 || readStartIndex >= this.nCDNafsgkwQdHWiWSxzILMSkqRQO)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > this.DdZFVzgwDxjpWvBTwnVLdPriTYBob)
			{
				numBytesToRead = this.DdZFVzgwDxjpWvBTwnVLdPriTYBob;
			}
			int num2 = this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryReadBytes(buffer, numBytesToRead, readStartIndex, 0);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			return num2;
		}

		// Token: 0x06003486 RID: 13446 RVA: 0x000B4EC0 File Offset: 0x000B30C0
		public IntPtr GetPointerFromReadPosition(int offset)
		{
			int offsetFromReadPosition = this.GetOffsetFromReadPosition(offset);
			if (offsetFromReadPosition < 0)
			{
				return IntPtr.Zero;
			}
			return this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.GetPointer(offsetFromReadPosition);
		}

		// Token: 0x06003487 RID: 13447 RVA: 0x000B4EEC File Offset: 0x000B30EC
		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)this.tYTrOqTojGqbXJHfImVsVpbIxzTm + offset;
			if (num >= this.nCDNafsgkwQdHWiWSxzILMSkqRQO)
			{
				num -= this.nCDNafsgkwQdHWiWSxzILMSkqRQO;
			}
			else if (num < 0)
			{
				num += this.nCDNafsgkwQdHWiWSxzILMSkqRQO;
			}
			if (num < 0 || num >= this.nCDNafsgkwQdHWiWSxzILMSkqRQO)
			{
				return -1;
			}
			return num;
		}

		// Token: 0x06003488 RID: 13448 RVA: 0x000B4F34 File Offset: 0x000B3134
		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= this.nCDNafsgkwQdHWiWSxzILMSkqRQO)
			{
				return false;
			}
			if ((long)startIndex < this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA)
			{
				if (passId == this.MJgvUsbwFNrTijHaiBLpxfmSsAVU)
				{
					return true;
				}
			}
			else if ((long)startIndex >= this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA)
			{
				if (this.MJgvUsbwFNrTijHaiBLpxfmSsAVU == 0U)
				{
					return false;
				}
				if (this.MJgvUsbwFNrTijHaiBLpxfmSsAVU - 1U == passId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003489 RID: 13449 RVA: 0x000B4F88 File Offset: 0x000B3188
		public void CopyFrom(NativeRingBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (this.nCDNafsgkwQdHWiWSxzILMSkqRQO != other.nCDNafsgkwQdHWiWSxzILMSkqRQO)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA = other.lSjGvwDgLEgcQqrIwbSQUUysLRtKA;
			this.tYTrOqTojGqbXJHfImVsVpbIxzTm = other.tYTrOqTojGqbXJHfImVsVpbIxzTm;
			this.DdZFVzgwDxjpWvBTwnVLdPriTYBob = other.DdZFVzgwDxjpWvBTwnVLdPriTYBob;
			this.zUdnUrEUoufxBuRaWILpOnlmiKNP = other.zUdnUrEUoufxBuRaWILpOnlmiKNP;
			this.MJgvUsbwFNrTijHaiBLpxfmSsAVU = other.MJgvUsbwFNrTijHaiBLpxfmSsAVU;
			this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.CopyFrom(other.KGmFSYPeibiYqwaYMuOqwHUrNwKN);
		}

		// Token: 0x0600348A RID: 13450 RVA: 0x000285B7 File Offset: 0x000267B7
		public void Reset()
		{
			this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA = 0L;
			this.tYTrOqTojGqbXJHfImVsVpbIxzTm = 0L;
			this.DdZFVzgwDxjpWvBTwnVLdPriTYBob = 0;
			this.zUdnUrEUoufxBuRaWILpOnlmiKNP = false;
			this.MJgvUsbwFNrTijHaiBLpxfmSsAVU = 0U;
		}

		// Token: 0x0600348B RID: 13451 RVA: 0x000B500C File Offset: 0x000B320C
		private void kdgbAYeDIyHEIDDkihtfnffjMiWfB(int A_1)
		{
			if (A_1 <= 0)
			{
				return;
			}
			int num = (int)this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA;
			this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA += (long)A_1;
			bool flag = false;
			if ((long)num < this.tYTrOqTojGqbXJHfImVsVpbIxzTm)
			{
				if (this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA > this.tYTrOqTojGqbXJHfImVsVpbIxzTm)
				{
					flag = true;
				}
			}
			else if ((long)num > this.tYTrOqTojGqbXJHfImVsVpbIxzTm)
			{
				if (this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA - (long)this.nCDNafsgkwQdHWiWSxzILMSkqRQO > this.tYTrOqTojGqbXJHfImVsVpbIxzTm)
				{
					flag = true;
				}
			}
			else if (this.DdZFVzgwDxjpWvBTwnVLdPriTYBob > 0)
			{
				flag = true;
			}
			if (flag)
			{
				this.zUdnUrEUoufxBuRaWILpOnlmiKNP = true;
				this.tYTrOqTojGqbXJHfImVsVpbIxzTm = this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA;
				if (this.tYTrOqTojGqbXJHfImVsVpbIxzTm >= (long)this.nCDNafsgkwQdHWiWSxzILMSkqRQO)
				{
					this.tYTrOqTojGqbXJHfImVsVpbIxzTm -= (long)this.nCDNafsgkwQdHWiWSxzILMSkqRQO;
				}
			}
			if (this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA >= (long)this.nCDNafsgkwQdHWiWSxzILMSkqRQO)
			{
				this.lSjGvwDgLEgcQqrIwbSQUUysLRtKA -= (long)this.nCDNafsgkwQdHWiWSxzILMSkqRQO;
				this.zOnsAXHpwScYgHPeLDbolCpgLfKgA();
			}
			this.DdZFVzgwDxjpWvBTwnVLdPriTYBob = (int)MathTools.Clamp((long)this.DdZFVzgwDxjpWvBTwnVLdPriTYBob + (long)A_1, 0L, (long)this.nCDNafsgkwQdHWiWSxzILMSkqRQO);
		}

		// Token: 0x0600348C RID: 13452 RVA: 0x000B5104 File Offset: 0x000B3304
		private void GtDgiUGyCyszYiQwKmbOFwtyvhAWA(int A_1)
		{
			if (A_1 <= 0)
			{
				return;
			}
			if (this.zUdnUrEUoufxBuRaWILpOnlmiKNP)
			{
				this.zUdnUrEUoufxBuRaWILpOnlmiKNP = false;
			}
			this.tYTrOqTojGqbXJHfImVsVpbIxzTm += (long)A_1;
			if (this.tYTrOqTojGqbXJHfImVsVpbIxzTm >= (long)this.nCDNafsgkwQdHWiWSxzILMSkqRQO)
			{
				this.tYTrOqTojGqbXJHfImVsVpbIxzTm -= (long)this.nCDNafsgkwQdHWiWSxzILMSkqRQO;
			}
			long num = (long)this.DdZFVzgwDxjpWvBTwnVLdPriTYBob - (long)A_1;
			this.DdZFVzgwDxjpWvBTwnVLdPriTYBob = ((num < 0L) ? 0 : ((int)num));
		}

		// Token: 0x0600348D RID: 13453 RVA: 0x000285DE File Offset: 0x000267DE
		private void zOnsAXHpwScYgHPeLDbolCpgLfKgA()
		{
			if (this.MJgvUsbwFNrTijHaiBLpxfmSsAVU == 4294967295U)
			{
				this.MJgvUsbwFNrTijHaiBLpxfmSsAVU = 0U;
				return;
			}
			this.MJgvUsbwFNrTijHaiBLpxfmSsAVU += 1U;
		}

		// Token: 0x0600348E RID: 13454 RVA: 0x000285FF File Offset: 0x000267FF
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600348F RID: 13455 RVA: 0x000B5174 File Offset: 0x000B3374
		~NativeRingBuffer()
		{
			this.Dispose(false);
		}

		// Token: 0x06003490 RID: 13456 RVA: 0x0002860E File Offset: 0x0002680E
		protected void Dispose(bool disposing)
		{
			if (this.LtoQzsKAlUUAixLqYiTgtFYMsVwM)
			{
				return;
			}
			if (disposing && this.KGmFSYPeibiYqwaYMuOqwHUrNwKN != null)
			{
				this.KGmFSYPeibiYqwaYMuOqwHUrNwKN.Dispose();
			}
			this.LtoQzsKAlUUAixLqYiTgtFYMsVwM = true;
		}

		// Token: 0x04001BFD RID: 7165
		private readonly NativeBuffer KGmFSYPeibiYqwaYMuOqwHUrNwKN;

		// Token: 0x04001BFE RID: 7166
		private readonly int nCDNafsgkwQdHWiWSxzILMSkqRQO;

		// Token: 0x04001BFF RID: 7167
		private long lSjGvwDgLEgcQqrIwbSQUUysLRtKA;

		// Token: 0x04001C00 RID: 7168
		private long tYTrOqTojGqbXJHfImVsVpbIxzTm;

		// Token: 0x04001C01 RID: 7169
		private int DdZFVzgwDxjpWvBTwnVLdPriTYBob;

		// Token: 0x04001C02 RID: 7170
		private bool zUdnUrEUoufxBuRaWILpOnlmiKNP;

		// Token: 0x04001C03 RID: 7171
		private uint MJgvUsbwFNrTijHaiBLpxfmSsAVU;

		// Token: 0x04001C04 RID: 7172
		private bool LtoQzsKAlUUAixLqYiTgtFYMsVwM;
	}
}
