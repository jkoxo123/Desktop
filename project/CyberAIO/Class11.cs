using System;

// Token: 0x0200001C RID: 28
internal abstract class Class11 : IDisposable
{
	// Token: 0x06000086 RID: 134
	public abstract bool vmethod_0();

	// Token: 0x06000087 RID: 135
	public abstract bool vmethod_1();

	// Token: 0x06000088 RID: 136
	public abstract bool vmethod_2();

	// Token: 0x06000089 RID: 137
	public abstract long vmethod_3();

	// Token: 0x0600008A RID: 138
	public abstract long vmethod_4();

	// Token: 0x0600008B RID: 139
	public abstract void vmethod_5(long long_0);

	// Token: 0x0600008C RID: 140 RVA: 0x00003039 File Offset: 0x00001239
	public virtual void vmethod_6()
	{
		this.vmethod_7(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00003048 File Offset: 0x00001248
	public void Dispose()
	{
		this.vmethod_6();
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00002D6B File Offset: 0x00000F6B
	protected virtual void vmethod_7(bool bool_0)
	{
	}

	// Token: 0x0600008F RID: 143
	public abstract void vmethod_8();

	// Token: 0x06000090 RID: 144
	public abstract long vmethod_9(long long_0, int int_0);

	// Token: 0x06000091 RID: 145
	public abstract void vmethod_10(long long_0);

	// Token: 0x06000092 RID: 146
	public abstract int vmethod_11(byte[] byte_0, int int_0, int int_1);

	// Token: 0x06000093 RID: 147 RVA: 0x000098FC File Offset: 0x00007AFC
	public virtual int vmethod_12()
	{
		byte[] array = new byte[1];
		if (this.vmethod_11(array, 0, 1) == 0)
		{
			return -1;
		}
		return (int)array[0];
	}

	// Token: 0x06000094 RID: 148
	public abstract void vmethod_13(byte[] byte_0, int int_0, int int_1);

	// Token: 0x06000095 RID: 149 RVA: 0x00009920 File Offset: 0x00007B20
	public virtual void vmethod_14(byte byte_0)
	{
		this.vmethod_13(new byte[]
		{
			byte_0
		}, 0, 1);
	}
}
