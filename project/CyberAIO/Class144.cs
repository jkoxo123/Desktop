using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

// Token: 0x02000112 RID: 274
internal static class Class144
{
	// Token: 0x06000620 RID: 1568 RVA: 0x000058AD File Offset: 0x00003AAD
	private static bool smethod_0()
	{
		return Class144.smethod_1();
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x00036764 File Offset: 0x00034964
	private static bool smethod_1()
	{
		StackTrace stackTrace = new StackTrace();
		StackFrame frame = stackTrace.GetFrame(3);
		MethodBase methodBase = (frame == null) ? null : frame.GetMethod();
		Type type = (methodBase == null) ? null : methodBase.DeclaringType;
		return type != typeof(RuntimeMethodHandle) && type != null && type.Assembly == typeof(Class144).Assembly;
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x000058B9 File Offset: 0x00003AB9
	internal static void smethod_2()
	{
		AppDomain.CurrentDomain.AssemblyResolve += Class144.smethod_4;
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x000367C8 File Offset: 0x000349C8
	internal static Assembly smethod_3(string string_0)
	{
		return Class144.smethod_5(string_0);
	}

	// Token: 0x06000624 RID: 1572 RVA: 0x000367E0 File Offset: 0x000349E0
	private static Assembly smethod_4(object object_0, ResolveEventArgs resolveEventArgs_0)
	{
		return Class144.smethod_5(resolveEventArgs_0.Name);
	}

	// Token: 0x06000625 RID: 1573 RVA: 0x000367FC File Offset: 0x000349FC
	private static Assembly smethod_5(string string_0)
	{
		Class144.Struct103 @struct = new Class144.Struct103(string_0.ToUpperInvariant());
		Class144.Class147.Class148 @class = null;
		string s = @struct.method_0(false);
		string string_ = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
		using (IEnumerator<Class144.Class147.Class148> enumerator = Class144.Class147.smethod_0(string_).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				Class144.Class147.Class148 class2 = enumerator.Current;
				@class = class2;
			}
		}
		if (@class == null)
		{
			return null;
		}
		Dictionary<string, Assembly> dictionary_ = Class144.Class145.dictionary_0;
		Dictionary<string, Assembly> obj = dictionary_;
		Assembly assembly;
		lock (obj)
		{
			if (!dictionary_.TryGetValue(@class.string_2, out assembly))
			{
				byte[] array = Class144.Class147.smethod_1(@class);
				if (array == null)
				{
					return null;
				}
				bool flag;
				if (!(flag = @class.bool_2))
				{
					try
					{
						assembly = Assembly.Load(array);
					}
					catch (FileLoadException)
					{
						flag = true;
					}
					catch (BadImageFormatException)
					{
						flag = true;
					}
				}
				if (flag)
				{
					try
					{
						string assemblyFile = Class144.Class147.smethod_2(@class, true, array);
						assembly = Assembly.LoadFrom(assemblyFile);
					}
					catch
					{
					}
				}
				dictionary_.Add(@class.string_2, assembly);
			}
		}
		return assembly;
	}

	// Token: 0x06000626 RID: 1574 RVA: 0x000058D1 File Offset: 0x00003AD1
	private static int smethod_6(byte[] byte_0, int int_0)
	{
		return (int)byte_0[int_0] | (int)byte_0[int_0 + 1] << 24 | (int)byte_0[int_0 + 2] << 8 | (int)byte_0[int_0 + 3] << 16;
	}

	// Token: 0x06000627 RID: 1575 RVA: 0x000058D1 File Offset: 0x00003AD1
	private static int smethod_7(byte[] byte_0, int int_0)
	{
		return (int)byte_0[int_0] | (int)byte_0[int_0 + 1] << 24 | (int)byte_0[int_0 + 2] << 8 | (int)byte_0[int_0 + 3] << 16;
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x00036934 File Offset: 0x00034B34
	private static byte[] smethod_8(byte[] byte_0)
	{
		int num = Class144.smethod_6(byte_0, 0);
		if (num != -1686991929)
		{
			throw new Exception();
		}
		int num2 = Class144.smethod_7(byte_0, 4);
		Stream stream = new DeflateStream(new MemoryStream(byte_0, false)
		{
			Position = 8L
		}, CompressionMode.Decompress);
		byte_0 = new byte[num2];
		int num3 = stream.Read(byte_0, 0, num2);
		if (num3 != num2)
		{
			throw new Exception();
		}
		return byte_0;
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x000369A0 File Offset: 0x00034BA0
	private static byte[] smethod_9(byte[] byte_0)
	{
		string s = "wij18KVsARkE6h4Nvxgf+q+4Yq4Qr8u9A47G6G5ZKt7bf9CyysPXucMo8MtMiCv2iKuf9a+eXgwEUTBETmHfO+/0mNbUI0o=";
		byte[] array = Convert.FromBase64String(s);
		Class179.smethod_1(array);
		Class144.Class146 @class = new Class144.Class146(array);
		int num = byte_0.Length;
		byte b = 0;
		byte b2 = 121;
		byte[] array2 = new byte[]
		{
			148,
			68,
			208,
			52,
			241,
			93,
			195,
			220
		};
		for (int num2 = 0; num2 != num; num2++)
		{
			if (b == 0)
			{
				b2 = @class.method_1();
			}
			b += 1;
			if (b == 32)
			{
				b = 0;
			}
			int num3 = num2;
			byte_0[num3] ^= (b2 ^ array2[num2 >> 2 & 3] ^ array2[(int)(b & 3)]);
		}
		return byte_0;
	}

	// Token: 0x0600062A RID: 1578
	[DllImport("kernel32.dll")]
	private static extern bool MoveFileEx(string string_0, string string_1, int int_0);

	// Token: 0x02000113 RID: 275
	private struct Struct103
	{
		// Token: 0x0600062B RID: 1579 RVA: 0x00036A58 File Offset: 0x00034C58
		public Struct103(string string_3)
		{
			this = default(Class144.Struct103);
			this.version_0 = new Version();
			this.string_0 = string.Empty;
			foreach (string text in string_3.Split(new char[]
			{
				','
			}))
			{
				string text2 = text.Trim();
				if (text2.StartsWith("Version=", StringComparison.OrdinalIgnoreCase))
				{
					this.version_0 = new Version(text2.Substring("Version=".Length));
					this.bool_0 = true;
				}
				else if (text2.StartsWith("Culture=", StringComparison.OrdinalIgnoreCase))
				{
					this.string_1 = text2.Substring("Culture=".Length);
					if (this.string_1.Equals("neutral", StringComparison.OrdinalIgnoreCase))
					{
						this.string_1 = null;
					}
					this.bool_1 = true;
				}
				else if (text2.StartsWith("PublicKeyToken=", StringComparison.OrdinalIgnoreCase))
				{
					this.string_2 = text2.Substring("PublicKeyToken=".Length);
					if (this.string_2.Equals("null", StringComparison.OrdinalIgnoreCase))
					{
						this.string_2 = null;
					}
					this.bool_2 = true;
				}
				else
				{
					this.string_0 = text2;
				}
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00036B80 File Offset: 0x00034D80
		public string method_0(bool bool_3)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.string_0);
			if (bool_3)
			{
				stringBuilder.Append(", VERSION=").Append(this.version_0);
			}
			stringBuilder.Append(", CULTURE=").Append(this.string_1 ?? "NEUTRAL").Append(", PUBLICKEYTOKEN=").Append(this.string_2 ?? "NULL");
			return stringBuilder.ToString();
		}

		// Token: 0x040004DD RID: 1245
		public Version version_0;

		// Token: 0x040004DE RID: 1246
		public bool bool_0;

		// Token: 0x040004DF RID: 1247
		public string string_0;

		// Token: 0x040004E0 RID: 1248
		public string string_1;

		// Token: 0x040004E1 RID: 1249
		public bool bool_1;

		// Token: 0x040004E2 RID: 1250
		public string string_2;

		// Token: 0x040004E3 RID: 1251
		public bool bool_2;
	}

	// Token: 0x02000114 RID: 276
	private static class Class145
	{
		// Token: 0x040004E4 RID: 1252
		internal static readonly Dictionary<string, Assembly> dictionary_0 = new Dictionary<string, Assembly>(StringComparer.Ordinal);
	}

	// Token: 0x02000115 RID: 277
	private sealed class Class146
	{
		// Token: 0x0600062E RID: 1582 RVA: 0x00036C00 File Offset: 0x00034E00
		public Class146(byte[] byte_1)
		{
			int num = byte_1.Length;
			this.int_0 = 0;
			while (this.int_0 < 256)
			{
				this.byte_0[this.int_0] = (byte)this.int_0;
				this.int_0++;
			}
			this.int_1 = 0;
			this.int_0 = 0;
			while (this.int_0 < 256)
			{
				this.int_1 = (this.int_1 + (int)byte_1[this.int_0 % num] + (int)this.byte_0[this.int_0] & 255);
				this.method_0(this.int_0, this.int_1);
				this.int_0++;
			}
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00036CC8 File Offset: 0x00034EC8
		private void method_0(int int_2, int int_3)
		{
			byte b = this.byte_0[int_2];
			this.byte_0[int_2] = this.byte_0[int_3];
			this.byte_0[int_3] = b;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x00036CF8 File Offset: 0x00034EF8
		public byte method_1()
		{
			this.int_0 = (this.int_0 + 1 & 255);
			this.int_1 = (this.int_1 + (int)this.byte_0[this.int_0] & 255);
			this.method_0(this.int_0, this.int_1);
			return this.byte_0[(int)(this.byte_0[this.int_0] + this.byte_0[this.int_1])];
		}

		// Token: 0x040004E5 RID: 1253
		private byte[] byte_0 = new byte[256];

		// Token: 0x040004E6 RID: 1254
		private int int_0;

		// Token: 0x040004E7 RID: 1255
		private int int_1;
	}

	// Token: 0x02000116 RID: 278
	private static class Class147
	{
		// Token: 0x06000631 RID: 1585 RVA: 0x00005901 File Offset: 0x00003B01
		internal static IEnumerable<Class144.Class147.Class148> smethod_0(string string_0)
		{
			return new Class144.Class147.Class149(-2)
			{
				string_1 = string_0
			};
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00036D70 File Offset: 0x00034F70
		internal static byte[] smethod_1(Class144.Class147.Class148 class148_0)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(class148_0.string_2);
			if (manifestResourceStream == null)
			{
				return null;
			}
			int num = (int)manifestResourceStream.Length;
			byte[] array = new byte[num];
			manifestResourceStream.Read(array, 0, num);
			manifestResourceStream.Dispose();
			if (class148_0.bool_0)
			{
				array = Class144.smethod_9(array);
			}
			if (class148_0.bool_1)
			{
				array = Class144.smethod_8(array);
			}
			return array;
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00036DD4 File Offset: 0x00034FD4
		internal static string smethod_2(Class144.Class147.Class148 class148_0, bool bool_0, byte[] byte_0)
		{
			string text = Path.Combine(Path.GetTempPath(), class148_0.string_2);
			try
			{
				Directory.CreateDirectory(text);
			}
			catch
			{
				text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				text = Path.Combine(text, "clrldr");
				text = Path.Combine(text, class148_0.string_2);
				Directory.CreateDirectory(text);
				if (text == null)
				{
					throw;
				}
			}
			string text2 = Path.Combine(text, class148_0.method_1());
			if (!File.Exists(text2))
			{
				if (byte_0 == null)
				{
					byte_0 = Class144.Class147.smethod_1(class148_0);
				}
				File.WriteAllBytes(text2, byte_0);
				if (bool_0)
				{
					try
					{
						Class144.MoveFileEx(text2, null, 4);
						Class144.MoveFileEx(text, null, 4);
					}
					catch
					{
					}
				}
			}
			return text2;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00036E8C File Offset: 0x0003508C
		internal static void smethod_3(string string_0, bool bool_0)
		{
			bool flag = false;
			try
			{
				File.Delete(string_0);
				flag = true;
			}
			catch
			{
			}
			string directoryName = Path.GetDirectoryName(string_0);
			bool flag2 = false;
			try
			{
				Directory.Delete(directoryName);
				flag = true;
			}
			catch
			{
			}
			if (bool_0)
			{
				if (!flag)
				{
					try
					{
						Class144.MoveFileEx(string_0, null, 4);
					}
					catch
					{
					}
				}
				if (!flag2)
				{
					try
					{
						Class144.MoveFileEx(directoryName, null, 4);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x02000117 RID: 279
		internal sealed class Class148
		{
			// Token: 0x06000636 RID: 1590 RVA: 0x00036F18 File Offset: 0x00035118
			public string method_0()
			{
				if (this.string_1 == null)
				{
					byte[] array = Convert.FromBase64String(this.string_0);
					this.string_1 = Encoding.UTF8.GetString(array, 0, array.Length);
				}
				return this.string_1;
			}

			// Token: 0x06000637 RID: 1591 RVA: 0x00036F54 File Offset: 0x00035154
			public string method_1()
			{
				if (this.string_4 == null)
				{
					byte[] array = Convert.FromBase64String(this.string_3);
					this.string_4 = Encoding.UTF8.GetString(array, 0, array.Length);
				}
				return this.string_4;
			}

			// Token: 0x040004E8 RID: 1256
			public string string_0;

			// Token: 0x040004E9 RID: 1257
			private string string_1;

			// Token: 0x040004EA RID: 1258
			public string string_2;

			// Token: 0x040004EB RID: 1259
			public bool bool_0;

			// Token: 0x040004EC RID: 1260
			public bool bool_1;

			// Token: 0x040004ED RID: 1261
			public bool bool_2;

			// Token: 0x040004EE RID: 1262
			public bool bool_3;

			// Token: 0x040004EF RID: 1263
			public bool bool_4;

			// Token: 0x040004F0 RID: 1264
			public string string_3;

			// Token: 0x040004F1 RID: 1265
			private string string_4;
		}

		// Token: 0x02000118 RID: 280
		private sealed class Class149 : IDisposable, IEnumerable<Class144.Class147.Class148>, IEnumerator<Class144.Class147.Class148>, IEnumerable, IEnumerator
		{
			// Token: 0x06000638 RID: 1592 RVA: 0x00005911 File Offset: 0x00003B11
			[DebuggerHidden]
			public Class149(int int_3)
			{
				this.int_0 = int_3;
				this.int_1 = Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000639 RID: 1593 RVA: 0x00002D6B File Offset: 0x00000F6B
			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			// Token: 0x0600063A RID: 1594 RVA: 0x00036F90 File Offset: 0x00035190
			bool IEnumerator.MoveNext()
			{
				int num = this.int_0;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					this.int_0 = -1;
				}
				else
				{
					this.int_0 = -1;
					string text = "WlhfNEFCQUUwMjczM0RDNDgyM0I4NDJFM0Y5MzUzODBEREUsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|54fced5d63fd496eacb1c440c98de4fc,enhfNGFiYWUwMjczM2RjNDgyM2I4NDJlM2Y5MzUzODBkZGUuZGxs,,WlhfNTY5MTU1NzcyM0EyNDNFNzlCNUIzQzNCMkMzMzE1NTUsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|9d15cde587224d03b8417f6f2c74712e,enhfNTY5MTU1NzcyM2EyNDNlNzliNWIzYzNiMmMzMzE1NTUuZGxs,,WlhfQTdEN0ZBQjkwNjg5NDRBQTg1MzA5RENBRDM1RjFFQzEsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|37dbffb9a4bc47afb33c84111e1b3689,enhfYTdkN2ZhYjkwNjg5NDRhYTg1MzA5ZGNhZDM1ZjFlYzEuZGxs,,WlhfRjFEMDRGQTcwNzRGNEJFMTlBNkI1NzZGMUFEODFFRUMsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|ed38925f674b45819a599080aef3e798,enhfZjFkMDRmYTcwNzRmNGJlMTlhNmI1NzZmMWFkODFlZWMuZGxs,,WlhfQkU3QUREQTdDNDQwNDc1ODlEMzA1MERFODcxMTVFRjcsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|b83ccc64b7bf408aaf87236e7ef0e2e8,enhfYmU3YWRkYTdjNDQwNDc1ODlkMzA1MGRlODcxMTVlZjcuZGxs,,WlhfNkY2MEU2MEEyQjQ5NDdGQzlGQTA4RDczODk0MTlDN0IsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|58ff340d9b3040ec8bc007da16af85b3,enhfNmY2MGU2MGEyYjQ5NDdmYzlmYTA4ZDczODk0MTljN2IuZGxs,,WlhfMjAzOTc5MjQ2RjJCNDA4Q0I4Q0ZDNTkwMjZFREQ5ODIsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|72f097238dd3482fa3c56a74c33917c9,enhfMjAzOTc5MjQ2ZjJiNDA4Y2I4Y2ZjNTkwMjZlZGQ5ODIuZGxs,,WlhfMkVDMkQxNjI0MkM2NEY4QjlFQTI0RjNDNzcyNkM3NDYsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|a8debadfde2c4005b37b50f6744b29f7,enhfMmVjMmQxNjI0MmM2NGY4YjllYTI0ZjNjNzcyNmM3NDYuZGxs,,WlhfRTcwQzlDNDlEMzM1NDhGQkI4OTNFNjlBRjQ4Rjg1MUYsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|f0dc2f5492254cdcb16b1bd8e631cc70,enhfZTcwYzljNDlkMzM1NDhmYmI4OTNlNjlhZjQ4Zjg1MWYuZGxs,,WlhfODM2MUM4RUIyRjg3NDA4M0IwNjk2QUUwRTY5NEIzRjcsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|48915b54dece4d53a9c2e407dd7944aa,enhfODM2MWM4ZWIyZjg3NDA4M2IwNjk2YWUwZTY5NGIzZjcuZGxs,,WlhfMkNGOUQwMjlCRTY3NDg5OUIxMDM0MkNDMDZCNjE3OTQsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|a09dc88ede4640298e2b56757cf4b227,enhfMmNmOWQwMjliZTY3NDg5OWIxMDM0MmNjMDZiNjE3OTQuZGxs,,WlhfNzgxNDEyRTI3MTU3NDE2OTg3NkFCMDZERDUxMTdGMzEsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|f04aa0aa624743aa82e4fb389237f12e,enhfNzgxNDEyZTI3MTU3NDE2OTg3NmFiMDZkZDUxMTdmMzEuZGxs,,WlhfNzc3NzhBQURDREFFNEY2MkExNzVBOTU5RDlGNzZGQTEsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|30cf6568d51d45aaaaea63e4c3ab0123,enhfNzc3NzhhYWRjZGFlNGY2MmExNzVhOTU5ZDlmNzZmYTEuZGxs,,WlhfQUQ4MDA5OTU1NzBCNEVBREE5MTMzMTVBMTlFMTE3MEEsIENVTFRVUkU9TkVVVFJBTCwgUFVCTElDS0VZVE9LRU49TlVMTA==,ab|8dd62c3943824952a23cd896a6ad50a4,enhfYWQ4MDA5OTU1NzBiNGVhZGE5MTMzMTVhMTllMTE3MGEuZGxs,";
					this.string_2 = text.Split(new char[]
					{
						','
					});
					if (this.string_0 == null && !Class144.smethod_0())
					{
						return false;
					}
					this.int_2 = 0;
					goto IL_91;
				}
				IL_83:
				this.int_2 += 4;
				IL_91:
				if (this.int_2 >= this.string_2.Length)
				{
					return false;
				}
				string text2 = this.string_2[this.int_2];
				if (this.string_0 != null && !text2.Equals(this.string_0, StringComparison.Ordinal))
				{
					goto IL_83;
				}
				Class144.Class147.Class148 @class = new Class144.Class147.Class148();
				@class.string_0 = text2;
				string text3 = this.string_2[this.int_2 + 1];
				int num2 = text3.IndexOf('|');
				if (num2 >= 0)
				{
					string text4 = text3.Substring(0, num2);
					text3 = text3.Substring(num2 + 1);
					@class.bool_0 = (text4.IndexOf('a') != -1);
					@class.bool_1 = (text4.IndexOf('b') != -1);
					@class.bool_2 = (text4.IndexOf('c') != -1);
				}
				@class.string_2 = text3;
				@class.string_3 = this.string_2[this.int_2 + 2];
				this.class148_0 = @class;
				this.int_0 = 1;
				return true;
			}

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600063B RID: 1595 RVA: 0x00005930 File Offset: 0x00003B30
			Class144.Class147.Class148 IEnumerator<Class144.Class147.Class148>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.class148_0;
				}
			}

			// Token: 0x0600063C RID: 1596 RVA: 0x0000482B File Offset: 0x00002A2B
			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600063D RID: 1597 RVA: 0x00005930 File Offset: 0x00003B30
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.class148_0;
				}
			}

			// Token: 0x0600063E RID: 1598 RVA: 0x000370E8 File Offset: 0x000352E8
			[DebuggerHidden]
			IEnumerator<Class144.Class147.Class148> IEnumerable<Class144.Class147.Class148>.GetEnumerator()
			{
				Class144.Class147.Class149 @class;
				if (this.int_0 == -2 && this.int_1 == Thread.CurrentThread.ManagedThreadId)
				{
					this.int_0 = 0;
					@class = this;
				}
				else
				{
					@class = new Class144.Class147.Class149(0);
				}
				@class.string_0 = this.string_1;
				return @class;
			}

			// Token: 0x0600063F RID: 1599 RVA: 0x00005938 File Offset: 0x00003B38
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<Class144.Class147.Class148>.GetEnumerator();
			}

			// Token: 0x040004F2 RID: 1266
			private int int_0;

			// Token: 0x040004F3 RID: 1267
			private Class144.Class147.Class148 class148_0;

			// Token: 0x040004F4 RID: 1268
			private int int_1;

			// Token: 0x040004F5 RID: 1269
			private string string_0;

			// Token: 0x040004F6 RID: 1270
			public string string_1;

			// Token: 0x040004F7 RID: 1271
			private string[] string_2;

			// Token: 0x040004F8 RID: 1272
			private int int_2;
		}
	}
}
