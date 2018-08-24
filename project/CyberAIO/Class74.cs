using System;
using System.Diagnostics;
using System.Threading;

// Token: 0x020000A3 RID: 163
internal static class Class74
{
	// Token: 0x020000A4 RID: 164
	private sealed class Class75
	{
		// Token: 0x0600040A RID: 1034 RVA: 0x000047D8 File Offset: 0x000029D8
		internal void method_0(int int_1)
		{
			this.int_0 += int_1;
		}

		// Token: 0x040001D1 RID: 465
		public int int_0;
	}

	// Token: 0x020000A5 RID: 165
	internal sealed class Class76 : Interface3<int>, Interface0<int>, Interface4, Interface7, Interface9
	{
		// Token: 0x0600040B RID: 1035 RVA: 0x000047E8 File Offset: 0x000029E8
		[DebuggerHidden]
		public Class76(int int_8)
		{
			this.int_0 = int_8;
			this.int_2 = Thread.CurrentThread.ManagedThreadId;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0002081C File Offset: 0x0001EA1C
		[DebuggerHidden]
		void Interface9.imethod_0()
		{
			int num = this.int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					this.method_0();
				}
			}
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00020854 File Offset: 0x0001EA54
		bool Interface7.imethod_0()
		{
			bool result;
			try
			{
				int num = this.int_0;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					this.int_0 = -3;
					int num2 = this.class75_0.int_0;
					this.class75_0.int_0 = num2 - 1;
					if (this.class75_0.int_0 == 0)
					{
						result = false;
						this.method_0();
						return result;
					}
					int num3 = this.int_6;
					this.int_6 = (num3 + this.int_5 + this.class75_0.int_0 ^ -407143042 + this.int_7);
					this.int_5 = num3;
				}
				else
				{
					this.int_0 = -1;
					this.class75_0 = new Class74.Class75();
					this.class75_0.int_0 = this.int_3;
					this.int_5 = 0;
					this.int_6 = 1;
					Class74.Delegate22<int> @delegate = new Class74.Delegate22<int>(this.class75_0.method_0);
					int num4 = this.int_6;
					Class74.Delegate22<int> delegate22_ = @delegate;
					int num5 = num4;
					this.interface0_0 = ((Interface3<int>)new Class74.Class77(-2)
					{
						int_4 = num5,
						delegate22_1 = delegate22_
					}).GetEnumerator();
					this.int_0 = -3;
				}
				if (!this.interface0_0.imethod_0())
				{
					this.method_0();
					this.interface0_0 = null;
					result = false;
				}
				else
				{
					this.int_7 = this.interface0_0.imethod_3();
					this.int_1 = this.int_6;
					this.int_0 = 1;
					result = true;
				}
			}
			catch
			{
				this.Interface9.imethod_0();
				throw;
			}
			return result;
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00004807 File Offset: 0x00002A07
		private void method_0()
		{
			this.int_0 = -1;
			if (this.interface0_0 != null)
			{
				this.interface0_0.imethod_0();
			}
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00004823 File Offset: 0x00002A23
		[DebuggerHidden]
		int Interface0<int>.imethod_3()
		{
			return this.int_1;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0000482B File Offset: 0x00002A2B
		[DebuggerHidden]
		void Interface7.imethod_2()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00004832 File Offset: 0x00002A32
		[DebuggerHidden]
		object Interface7.imethod_1()
		{
			return this.int_1;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x000209D0 File Offset: 0x0001EBD0
		[DebuggerHidden]
		Interface0<int> Interface3<int>.GetEnumerator()
		{
			Class74.Class76 @class;
			if (this.int_0 == -2 && this.int_2 == Thread.CurrentThread.ManagedThreadId)
			{
				this.int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class74.Class76(0);
			}
			@class.int_3 = this.int_4;
			return @class;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0000483F File Offset: 0x00002A3F
		[DebuggerHidden]
		Interface7 Interface4.imethod_0()
		{
			return this.Interface3<System.Int32>.GetEnumerator();
		}

		// Token: 0x040001D2 RID: 466
		private int int_0;

		// Token: 0x040001D3 RID: 467
		private int int_1;

		// Token: 0x040001D4 RID: 468
		private int int_2;

		// Token: 0x040001D5 RID: 469
		private int int_3;

		// Token: 0x040001D6 RID: 470
		public int int_4;

		// Token: 0x040001D7 RID: 471
		private Class74.Class75 class75_0;

		// Token: 0x040001D8 RID: 472
		private int int_5;

		// Token: 0x040001D9 RID: 473
		private int int_6;

		// Token: 0x040001DA RID: 474
		private Interface0<int> interface0_0;

		// Token: 0x040001DB RID: 475
		private int int_7;
	}

	// Token: 0x020000A6 RID: 166
	internal sealed class Class77 : Interface3<int>, Interface0<int>, Interface4, Interface7, Interface9
	{
		// Token: 0x06000414 RID: 1044 RVA: 0x00004847 File Offset: 0x00002A47
		[DebuggerHidden]
		public Class77(int int_6)
		{
			this.int_0 = int_6;
			this.int_2 = Thread.CurrentThread.ManagedThreadId;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00002D6B File Offset: 0x00000F6B
		[DebuggerHidden]
		void Interface9.imethod_0()
		{
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00020A18 File Offset: 0x0001EC18
		bool Interface7.imethod_0()
		{
			int num = this.int_0;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				this.int_0 = -1;
				this.int_5 += this.int_5;
				if (this.int_5 == 64)
				{
					this.delegate22_0(this.int_5 - 7);
					this.int_5 = 5;
				}
			}
			else
			{
				this.int_0 = -1;
				this.int_5 = 1;
				this.delegate22_0(this.int_3 - 29495656);
			}
			this.int_1 = this.int_5;
			this.int_0 = 1;
			return true;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00004866 File Offset: 0x00002A66
		[DebuggerHidden]
		int Interface0<int>.imethod_3()
		{
			return this.int_1;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0000482B File Offset: 0x00002A2B
		[DebuggerHidden]
		void Interface7.imethod_2()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0000486E File Offset: 0x00002A6E
		[DebuggerHidden]
		object Interface7.imethod_1()
		{
			return this.int_1;
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00020AB0 File Offset: 0x0001ECB0
		[DebuggerHidden]
		Interface0<int> Interface3<int>.GetEnumerator()
		{
			Class74.Class77 @class;
			if (this.int_0 == -2 && this.int_2 == Thread.CurrentThread.ManagedThreadId)
			{
				this.int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class74.Class77(0);
			}
			@class.int_3 = this.int_4;
			@class.delegate22_0 = this.delegate22_1;
			return @class;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0000487B File Offset: 0x00002A7B
		[DebuggerHidden]
		Interface7 Interface4.imethod_0()
		{
			return this.Interface3<System.Int32>.GetEnumerator();
		}

		// Token: 0x040001DC RID: 476
		private int int_0;

		// Token: 0x040001DD RID: 477
		private int int_1;

		// Token: 0x040001DE RID: 478
		private int int_2;

		// Token: 0x040001DF RID: 479
		private Class74.Delegate22<int> delegate22_0;

		// Token: 0x040001E0 RID: 480
		public Class74.Delegate22<int> delegate22_1;

		// Token: 0x040001E1 RID: 481
		private int int_3;

		// Token: 0x040001E2 RID: 482
		public int int_4;

		// Token: 0x040001E3 RID: 483
		private int int_5;
	}

	// Token: 0x020000A7 RID: 167
	// (Invoke) Token: 0x0600041D RID: 1053
	private delegate void Delegate22<T>(T gparam_0);

	// Token: 0x020000A8 RID: 168
	internal sealed class Class78 : Interface3<int>, Interface0<int>, Interface4, Interface7, Interface9
	{
		// Token: 0x06000420 RID: 1056 RVA: 0x00004883 File Offset: 0x00002A83
		[DebuggerHidden]
		public Class78(int int_6)
		{
			this.int_0 = int_6;
			this.int_2 = Thread.CurrentThread.ManagedThreadId;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00020B04 File Offset: 0x0001ED04
		[DebuggerHidden]
		void Interface9.imethod_0()
		{
			int num = this.int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					this.method_0();
				}
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00020B3C File Offset: 0x0001ED3C
		bool Interface7.imethod_0()
		{
			bool result;
			try
			{
				int num = this.int_0;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					this.int_0 = -3;
					if (this.int_5 == 0)
					{
						result = false;
						this.method_0();
						return result;
					}
				}
				else
				{
					this.int_0 = -1;
					this.int_5 = 7;
					int num2 = this.int_3;
					this.interface0_0 = ((Interface3<int>)new Class74.Class76(-2)
					{
						int_4 = num2
					}).GetEnumerator();
					this.int_0 = -3;
				}
				if (!this.interface0_0.imethod_0())
				{
					this.method_0();
					this.interface0_0 = null;
					result = false;
				}
				else
				{
					int num3 = this.interface0_0.imethod_3() ^ this.int_3;
					if ((num3 & 3) == 0)
					{
						num3 ^= 250240083;
					}
					int num4 = this.int_5 - 1;
					this.int_5 = num4;
					if ((num3 & 15) == 0)
					{
						num3 ^= (-362740949 ^ this.int_5);
					}
					this.int_1 = num3;
					this.int_0 = 1;
					result = true;
				}
			}
			catch
			{
				this.Interface9.imethod_0();
				throw;
			}
			return result;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x000048A2 File Offset: 0x00002AA2
		private void method_0()
		{
			this.int_0 = -1;
			if (this.interface0_0 != null)
			{
				this.interface0_0.imethod_0();
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x000048BE File Offset: 0x00002ABE
		[DebuggerHidden]
		int Interface0<int>.imethod_3()
		{
			return this.int_1;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000482B File Offset: 0x00002A2B
		[DebuggerHidden]
		void Interface7.imethod_2()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x000048C6 File Offset: 0x00002AC6
		[DebuggerHidden]
		object Interface7.imethod_1()
		{
			return this.int_1;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00020C40 File Offset: 0x0001EE40
		[DebuggerHidden]
		Interface0<int> Interface3<int>.GetEnumerator()
		{
			Class74.Class78 @class;
			if (this.int_0 == -2 && this.int_2 == Thread.CurrentThread.ManagedThreadId)
			{
				this.int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class74.Class78(0);
			}
			@class.int_3 = this.int_4;
			return @class;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x000048D3 File Offset: 0x00002AD3
		[DebuggerHidden]
		Interface7 Interface4.imethod_0()
		{
			return this.Interface3<System.Int32>.GetEnumerator();
		}

		// Token: 0x040001E4 RID: 484
		private int int_0;

		// Token: 0x040001E5 RID: 485
		private int int_1;

		// Token: 0x040001E6 RID: 486
		private int int_2;

		// Token: 0x040001E7 RID: 487
		private int int_3;

		// Token: 0x040001E8 RID: 488
		public int int_4;

		// Token: 0x040001E9 RID: 489
		private int int_5;

		// Token: 0x040001EA RID: 490
		private Interface0<int> interface0_0;
	}
}
