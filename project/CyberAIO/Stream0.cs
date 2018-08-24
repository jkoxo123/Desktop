using System;
using System.IO;

// Token: 0x020000F4 RID: 244
internal sealed class Stream0 : Stream
{
	// Token: 0x060005B1 RID: 1457 RVA: 0x000055D5 File Offset: 0x000037D5
	public Stream0(Stream stream_1, int int_1)
	{
		this.method_1(stream_1);
		this.int_0 = int_1;
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x000055EB File Offset: 0x000037EB
	public Stream method_0()
	{
		return this.stream_0;
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x000055F3 File Offset: 0x000037F3
	private void method_1(Stream stream_1)
	{
		this.stream_0 = stream_1;
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x060005B4 RID: 1460 RVA: 0x000055FC File Offset: 0x000037FC
	public override bool CanRead
	{
		get
		{
			return this.method_0().CanRead;
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x060005B5 RID: 1461 RVA: 0x00005609 File Offset: 0x00003809
	public override bool CanSeek
	{
		get
		{
			return this.method_0().CanSeek;
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x060005B6 RID: 1462 RVA: 0x00005616 File Offset: 0x00003816
	public override bool CanWrite
	{
		get
		{
			return this.method_0().CanWrite;
		}
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x00005623 File Offset: 0x00003823
	public override void Flush()
	{
		this.method_0().Flush();
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x060005B8 RID: 1464 RVA: 0x00005630 File Offset: 0x00003830
	public override long Length
	{
		get
		{
			return this.method_0().Length;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x060005B9 RID: 1465 RVA: 0x0000563D File Offset: 0x0000383D
	// (set) Token: 0x060005BA RID: 1466 RVA: 0x0000564A File Offset: 0x0000384A
	public override long Position
	{
		get
		{
			return this.method_0().Position;
		}
		set
		{
			this.method_0().Position = value;
		}
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x000313AC File Offset: 0x0002F5AC
	private byte method_2(byte byte_0, long long_0)
	{
		byte b = (byte)((ulong)this.int_0 | (ulong)long_0);
		return byte_0 ^ b;
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x000313C8 File Offset: 0x0002F5C8
	public override void Write(byte[] buffer, int offset, int count)
	{
		byte[] array = new byte[count];
		Buffer.BlockCopy(buffer, offset, array, 0, count);
		long position = this.Position;
		for (int i = 0; i < count; i++)
		{
			array[i] = this.method_2(array[i], position + (long)i);
		}
		this.method_0().Write(array, 0, count);
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x00031418 File Offset: 0x0002F618
	public override int Read(byte[] buffer, int offset, int count)
	{
		long position = this.Position;
		byte[] array = new byte[count];
		int num = this.method_0().Read(array, 0, count);
		for (int i = 0; i < num; i++)
		{
			buffer[i + offset] = this.method_2(array[i], position + (long)i);
		}
		return num;
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x00005658 File Offset: 0x00003858
	public override long Seek(long offset, SeekOrigin origin)
	{
		return this.method_0().Seek(offset, origin);
	}

	// Token: 0x060005BF RID: 1471 RVA: 0x00005667 File Offset: 0x00003867
	public override void SetLength(long value)
	{
		this.method_0().SetLength(value);
	}

	// Token: 0x04000437 RID: 1079
	private readonly int int_0;

	// Token: 0x04000438 RID: 1080
	private Stream stream_0;
}
