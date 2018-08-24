using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200001F RID: 31
internal sealed class Class15<T> : IEnumerable<T>, IEnumerable, ICollection
{
	// Token: 0x060000A4 RID: 164 RVA: 0x0000306B File Offset: 0x0000126B
	public Class15()
	{
		this.gparam_0 = Class132<T>.gparam_0;
		this.int_0 = 0;
		this.int_1 = 0;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x0000308C File Offset: 0x0000128C
	public Class15(int int_2)
	{
		if (int_2 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		this.gparam_0 = new T[int_2];
		this.int_0 = 0;
		this.int_1 = 0;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00009FF0 File Offset: 0x000081F0
	public Class15(IEnumerable<T> ienumerable_0)
	{
		if (ienumerable_0 == null)
		{
			throw new ArgumentNullException();
		}
		ICollection<T> collection = ienumerable_0 as ICollection<T>;
		if (collection != null)
		{
			int count = collection.Count;
			this.gparam_0 = new T[count];
			collection.CopyTo(this.gparam_0, 0);
			this.int_0 = count;
			return;
		}
		this.int_0 = 0;
		this.gparam_0 = new T[4];
		foreach (T gparam_ in ienumerable_0)
		{
			this.method_7(gparam_);
		}
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x060000A7 RID: 167 RVA: 0x000030B8 File Offset: 0x000012B8
	public int Count
	{
		get
		{
			return this.int_0;
		}
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x060000A8 RID: 168 RVA: 0x000030C0 File Offset: 0x000012C0
	bool ICollection.IsSynchronized
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x060000A9 RID: 169 RVA: 0x000030C3 File Offset: 0x000012C3
	object ICollection.SyncRoot
	{
		get
		{
			if (this.object_0 == null)
			{
				Interlocked.CompareExchange(ref this.object_0, new object(), null);
			}
			return this.object_0;
		}
	}

	// Token: 0x060000AA RID: 170 RVA: 0x000030E5 File Offset: 0x000012E5
	public void method_0()
	{
		Array.Clear(this.gparam_0, 0, this.int_0);
		this.int_0 = 0;
		this.int_1++;
	}

	// Token: 0x060000AB RID: 171 RVA: 0x0000A08C File Offset: 0x0000828C
	public bool method_1(T gparam_1)
	{
		int num = this.int_0;
		EqualityComparer<T> @default = EqualityComparer<T>.Default;
		while (num-- > 0)
		{
			if (gparam_1 == null)
			{
				if (this.gparam_0[num] == null)
				{
					return true;
				}
			}
			else if (this.gparam_0[num] != null && @default.Equals(this.gparam_0[num], gparam_1))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060000AC RID: 172 RVA: 0x0000A0FC File Offset: 0x000082FC
	public void method_2(T[] gparam_1, int int_2)
	{
		if (gparam_1 == null)
		{
			throw new ArgumentNullException("\u0002");
		}
		if (int_2 < 0 || int_2 > gparam_1.Length)
		{
			throw new ArgumentOutOfRangeException("\u0003", "arrayIndex < 0 || arrayIndex > array.Length");
		}
		if (gparam_1.Length - int_2 < this.int_0)
		{
			throw new ArgumentException("Invalid Off Len");
		}
		Array.Copy(this.gparam_0, 0, gparam_1, int_2, this.int_0);
		Array.Reverse(gparam_1, int_2, this.int_0);
	}

	// Token: 0x060000AD RID: 173 RVA: 0x0000A16C File Offset: 0x0000836C
	void ICollection.CopyTo(Array array, int index)
	{
		if (array == null)
		{
			throw new ArgumentNullException();
		}
		if (array.Rank != 1)
		{
			throw new ArgumentException();
		}
		if (array.GetLowerBound(0) != 0)
		{
			throw new ArgumentException();
		}
		if (index >= 0 && index <= array.Length)
		{
			if (array.Length - index < this.int_0)
			{
				throw new ArgumentException();
			}
			try
			{
				Array.Copy(this.gparam_0, 0, array, index, this.int_0);
				Array.Reverse(array, index, this.int_0);
				return;
			}
			catch (ArrayTypeMismatchException)
			{
				throw new ArgumentException();
			}
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x060000AE RID: 174 RVA: 0x0000310E File Offset: 0x0000130E
	public Class15<T>.Struct12 method_3()
	{
		return new Class15<T>.Struct12(this);
	}

	// Token: 0x060000AF RID: 175 RVA: 0x00003116 File Offset: 0x00001316
	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return new Class15<T>.Struct12(this);
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00003116 File Offset: 0x00001316
	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Class15<T>.Struct12(this);
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x0000A204 File Offset: 0x00008404
	public void method_4()
	{
		int num = (int)((double)this.gparam_0.Length * 0.9);
		if (this.int_0 < num)
		{
			T[] destinationArray = new T[this.int_0];
			Array.Copy(this.gparam_0, 0, destinationArray, 0, this.int_0);
			this.gparam_0 = destinationArray;
			this.int_1++;
		}
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x00003123 File Offset: 0x00001323
	public T method_5()
	{
		if (this.int_0 == 0)
		{
			throw new InvalidOperationException();
		}
		return this.gparam_0[this.int_0 - 1];
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x0000A264 File Offset: 0x00008464
	public T method_6()
	{
		if (this.int_0 == 0)
		{
			throw new InvalidOperationException();
		}
		this.int_1++;
		T[] array = this.gparam_0;
		int num = this.int_0 - 1;
		this.int_0 = num;
		T result = array[num];
		this.gparam_0[this.int_0] = default(T);
		return result;
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x0000A2C4 File Offset: 0x000084C4
	public void method_7(T gparam_1)
	{
		if (this.int_0 == this.gparam_0.Length)
		{
			T[] destinationArray = new T[(this.gparam_0.Length == 0) ? 4 : (2 * this.gparam_0.Length)];
			Array.Copy(this.gparam_0, 0, destinationArray, 0, this.int_0);
			this.gparam_0 = destinationArray;
		}
		T[] array = this.gparam_0;
		int num = this.int_0;
		this.int_0 = num + 1;
		array[num] = gparam_1;
		this.int_1++;
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x0000A344 File Offset: 0x00008544
	public T[] method_8()
	{
		T[] array = new T[this.int_0];
		for (int i = 0; i < this.int_0; i++)
		{
			array[i] = this.gparam_0[this.int_0 - i - 1];
		}
		return array;
	}

	// Token: 0x0400005E RID: 94
	private T[] gparam_0;

	// Token: 0x0400005F RID: 95
	private int int_0;

	// Token: 0x04000060 RID: 96
	private int int_1;

	// Token: 0x04000061 RID: 97
	private object object_0;

	// Token: 0x02000020 RID: 32
	public struct Struct12 : IEnumerator<T>, IDisposable, IEnumerator
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x00003146 File Offset: 0x00001346
		internal Struct12(Class15<T> class15_1)
		{
			this.class15_0 = class15_1;
			this.int_1 = this.class15_0.int_1;
			this.int_0 = -2;
			this.gparam_0 = default(T);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003174 File Offset: 0x00001374
		public void Dispose()
		{
			this.int_0 = -1;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000A38C File Offset: 0x0000858C
		public bool MoveNext()
		{
			if (this.int_1 != this.class15_0.int_1)
			{
				throw new InvalidOperationException("EnumFailedVersion");
			}
			if (this.int_0 == -2)
			{
				this.int_0 = this.class15_0.int_0 - 1;
				bool flag = this.int_0 >= 0;
				if (flag)
				{
					this.gparam_0 = this.class15_0.gparam_0[this.int_0];
				}
				return flag;
			}
			if (this.int_0 == -1)
			{
				return false;
			}
			int num = this.int_0 - 1;
			this.int_0 = num;
			bool flag2 = num >= 0;
			if (flag2)
			{
				this.gparam_0 = this.class15_0.gparam_0[this.int_0];
				return flag2;
			}
			this.gparam_0 = default(T);
			return flag2;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x0000317D File Offset: 0x0000137D
		public T Current
		{
			get
			{
				if (this.int_0 == -2)
				{
					throw new InvalidOperationException();
				}
				if (this.int_0 == -1)
				{
					throw new InvalidOperationException();
				}
				return this.gparam_0;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000BA RID: 186 RVA: 0x000031A4 File Offset: 0x000013A4
		object IEnumerator.Current
		{
			get
			{
				if (this.int_0 == -2)
				{
					throw new InvalidOperationException();
				}
				if (this.int_0 == -1)
				{
					throw new InvalidOperationException();
				}
				return this.gparam_0;
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000031D0 File Offset: 0x000013D0
		void IEnumerator.Reset()
		{
			if (this.int_1 != this.class15_0.int_1)
			{
				throw new InvalidOperationException();
			}
			this.int_0 = -2;
			this.gparam_0 = default(T);
		}

		// Token: 0x04000062 RID: 98
		private Class15<T> class15_0;

		// Token: 0x04000063 RID: 99
		private int int_0;

		// Token: 0x04000064 RID: 100
		private int int_1;

		// Token: 0x04000065 RID: 101
		private T gparam_0;
	}
}
