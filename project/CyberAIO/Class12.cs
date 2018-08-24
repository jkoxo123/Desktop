using System;
using System.IO;

// Token: 0x0200006F RID: 111
internal sealed class Class12 : Class11
{
	// Token: 0x060001FB RID: 507 RVA: 0x00003CF7 File Offset: 0x00001EF7
	public Class12(Stream stream_1, int int_1)
	{
		this.stream_0 = stream_1;
		this.int_0 = int_1;
	}

	// Token: 0x060001FC RID: 508 RVA: 0x00003D0D File Offset: 0x00001F0D
	public Stream method_0()
	{
		return this.stream_0;
	}

	// Token: 0x060001FD RID: 509 RVA: 0x00003D15 File Offset: 0x00001F15
	public override bool vmethod_0()
	{
		return this.method_0().CanRead;
	}

	// Token: 0x060001FE RID: 510 RVA: 0x00003D22 File Offset: 0x00001F22
	public override bool vmethod_2()
	{
		return this.method_0().CanSeek;
	}

	// Token: 0x060001FF RID: 511 RVA: 0x00003D2F File Offset: 0x00001F2F
	public override bool vmethod_1()
	{
		return this.method_0().CanWrite;
	}

	// Token: 0x06000200 RID: 512 RVA: 0x00003D3C File Offset: 0x00001F3C
	public override void vmethod_8()
	{
		this.method_0().Flush();
	}

	// Token: 0x06000201 RID: 513 RVA: 0x00003D49 File Offset: 0x00001F49
	public override long vmethod_3()
	{
		return this.method_0().Length;
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00003D56 File Offset: 0x00001F56
	public override long vmethod_4()
	{
		return this.method_0().Position;
	}

	// Token: 0x06000203 RID: 515 RVA: 0x00003D63 File Offset: 0x00001F63
	public override void vmethod_5(long long_0)
	{
		this.method_0().Position = long_0;
	}

	// Token: 0x06000204 RID: 516 RVA: 0x000128C0 File Offset: 0x00010AC0
	private byte method_1(byte byte_0, long long_0)
	{
		byte b = (byte)(this.int_0 ^ -559030707 ^ (int)((uint)long_0));
		return byte_0 ^ b;
	}

	// Token: 0x06000205 RID: 517 RVA: 0x000128E4 File Offset: 0x00010AE4
	public override void vmethod_13(byte[] byte_0, int int_1, int int_2)
	{
		long num = this.vmethod_4();
		byte[] array = new byte[int_2];
		for (int i = 0; i < int_2; i++)
		{
			array[i] = this.method_1(byte_0[i + int_1], num + (long)i);
		}
		this.method_0().Write(array, 0, int_2);
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0001292C File Offset: 0x00010B2C
	public override int vmethod_11(byte[] byte_0, int int_1, int int_2)
	{
		long num = this.vmethod_4();
		byte[] array = new byte[int_2];
		int num2 = this.method_0().Read(array, 0, int_2);
		for (int i = 0; i < num2; i++)
		{
			byte_0[i + int_1] = this.method_1(array[i], num + (long)i);
		}
		return num2;
	}

	// Token: 0x06000207 RID: 519 RVA: 0x00012978 File Offset: 0x00010B78
	public override long vmethod_9(long long_0, int int_1)
	{
		SeekOrigin origin;
		switch (int_1)
		{
		case 0:
			origin = SeekOrigin.Begin;
			break;
		case 1:
			origin = SeekOrigin.Current;
			break;
		case 2:
			origin = SeekOrigin.End;
			break;
		default:
			throw new ArgumentException();
		}
		return this.method_0().Seek(long_0, origin);
	}

	// Token: 0x06000208 RID: 520 RVA: 0x00003D71 File Offset: 0x00001F71
	public override void vmethod_10(long long_0)
	{
		this.method_0().SetLength(long_0);
	}

	// Token: 0x04000153 RID: 339
	private readonly int int_0;

	// Token: 0x04000154 RID: 340
	private readonly Stream stream_0;
}
