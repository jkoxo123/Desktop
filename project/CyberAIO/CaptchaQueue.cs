using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using EO.Base;
using EO.WebBrowser;
using EO.WebEngine;
using Newtonsoft.Json.Linq;

// Token: 0x020000E6 RID: 230
internal sealed partial class CaptchaQueue : Form
{
	// Token: 0x06000546 RID: 1350 RVA: 0x0002D67C File Offset: 0x0002B87C
	public CaptchaQueue(bool bool_0 = true)
	{
		this.InitializeComponent();
		Dictionary<int, GClass1> dictionary = new Dictionary<int, GClass1>();
		dictionary[1] = new GClass1
		{
			bunifuThinButton2_0 = this.solverButton1,
			bunifuCustomLabel_0 = this.solverLine1,
			bunifuThinButton2_1 = this.closeButton1
		};
		dictionary[2] = new GClass1
		{
			bunifuThinButton2_0 = this.solverButton2,
			bunifuCustomLabel_0 = this.solverLine2,
			bunifuThinButton2_1 = this.closeButton2
		};
		dictionary[3] = new GClass1
		{
			bunifuThinButton2_0 = this.solverButton3,
			bunifuCustomLabel_0 = this.solverLine3,
			bunifuThinButton2_1 = this.closeButton3
		};
		dictionary[4] = new GClass1
		{
			bunifuThinButton2_0 = this.solverButton4,
			bunifuCustomLabel_0 = this.solverLine4,
			bunifuThinButton2_1 = this.closeButton4
		};
		this.dictionary_0 = dictionary;
		this.method_1();
		this.method_9(1);
		this.method_6(this.dictionary_0[1]);
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x0002D780 File Offset: 0x0002B980
	public void method_0(string string_0, string string_1)
	{
		if (string_1 == null)
		{
			string_1 = string.Empty;
		}
		if (string_0 == null)
		{
			string_0 = Guid.NewGuid().ToString();
		}
		int key = CaptchaQueue.dictionary_1.Any<KeyValuePair<int, GClass0>>() ? (CaptchaQueue.dictionary_1.Keys.Max() + 1) : 1;
		Panel panel = new Panel
		{
			Dock = DockStyle.Fill
		};
		BrowserOptions options = new BrowserOptions
		{
			EnableXSSAuditor = new bool?(false),
			EnableWebSecurity = new bool?(false)
		};
		WebView webView = new WebView();
		Engine engine = Engine.Create(string_0);
		try
		{
			string[] array = string_1.Split(new char[]
			{
				':'
			});
			if (array.Length == 4)
			{
				engine.Options.Proxy = new ProxyInfo(ProxyType.HTTP, array[0], Convert.ToInt32(array[1]), array[2], array[3]);
			}
			else if (array.Length == 2)
			{
				engine.Options.Proxy = new ProxyInfo(ProxyType.HTTP, array[0], Convert.ToInt32(array[1]));
			}
			else
			{
				engine.Options.Proxy = null;
			}
		}
		catch
		{
			engine.Options.Proxy = null;
		}
		webView.SetOptions(options);
		webView.Engine = engine;
		webView.Engine.AllowRestart = true;
		webView.Create(panel.Handle);
		webView.RegisterJSExtensionFunction("submit", new JSExtInvokeHandler(this.method_3));
		webView.CertificateError += this.method_11;
		webView.BeforeContextMenu += this.method_10;
		CaptchaQueue.dictionary_1[key] = new GClass0
		{
			int_0 = key,
			string_0 = string_0,
			webView_0 = webView,
			panel_0 = panel,
			string_1 = string_1
		};
		webView.LoadHtml(CaptchaQueue.smethod_4());
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x0002D93C File Offset: 0x0002BB3C
	public void method_1()
	{
		foreach (KeyValuePair<string, JToken> keyValuePair in Class130.jobject_5)
		{
			this.method_0((string)keyValuePair.Value["engine"], (string)keyValuePair.Value["proxy"]);
		}
		if (Class130.jobject_5.Count == 0)
		{
			this.method_0(null, null);
		}
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x0002D9C8 File Offset: 0x0002BBC8
	public void method_2()
	{
		JObject jobject = new JObject();
		foreach (GClass0 gclass in CaptchaQueue.dictionary_1.Values)
		{
			jobject[gclass.method_0()] = new JObject();
			jobject[gclass.method_0()]["proxy"] = gclass.string_1;
			jobject[gclass.method_0()]["engine"] = gclass.string_0;
		}
		Class130.jobject_5 = jobject;
		Class130.smethod_1();
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x0002DA80 File Offset: 0x0002BC80
	private void setProxyButton_Click(object sender, EventArgs e)
	{
		try
		{
			string[] array = this.proxyInput.Text.Split(new char[]
			{
				':'
			});
			GClass0 gclass = CaptchaQueue.dictionary_1[CaptchaQueue.int_0];
			WebView webView = gclass.webView_0;
			Engine engine = webView.Engine;
			try
			{
				if (array.Length == 4)
				{
					engine.Options.Proxy = new ProxyInfo(ProxyType.HTTP, array[0], Convert.ToInt32(array[1]), array[2], array[3]);
				}
				else if (array.Length == 2)
				{
					engine.Options.Proxy = new ProxyInfo(ProxyType.HTTP, array[0], Convert.ToInt32(array[1]));
				}
				else
				{
					engine.Options.Proxy = null;
				}
			}
			catch
			{
				engine.Options.Proxy = null;
			}
			webView.Engine.Stop(false);
			webView.Dispose();
			BrowserOptions options = new BrowserOptions
			{
				EnableXSSAuditor = new bool?(false),
				EnableWebSecurity = new bool?(false)
			};
			webView = new WebView();
			webView.SetOptions(options);
			webView.Engine = engine;
			webView.Engine.AllowRestart = true;
			webView.Create(gclass.panel_0.Handle);
			webView.RegisterJSExtensionFunction("submit", new JSExtInvokeHandler(this.method_3));
			webView.CertificateError += this.method_11;
			webView.BeforeContextMenu += this.method_10;
			CaptchaQueue.dictionary_1[CaptchaQueue.int_0].webView_0 = webView;
			CaptchaQueue.dictionary_1[CaptchaQueue.int_0].string_1 = this.proxyInput.Text;
			this.reloadCaptcha_Click(null, null);
		}
		catch
		{
		}
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x000051B1 File Offset: 0x000033B1
	private void method_3(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		CaptchaQueue.concurrentDictionary_0[jsextInvokeArgs_0.Arguments[1].ToString()].taskCompletionSource_0.TrySetResult(jsextInvokeArgs_0.Arguments.First<object>().ToString());
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x0002DC48 File Offset: 0x0002BE48
	public static async Task<string> smethod_0(string string_0, string string_1, string string_2, CancellationToken cancellationToken_0)
	{
		MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue.Class126.class126_0.method_0));
		Class131 @class = new Class131
		{
			int_0 = (int)Convert.ToInt16(string_2),
			string_1 = string_0,
			uri_0 = new Uri(string_1)
		};
		CaptchaQueue.concurrentDictionary_0[@class.string_0] = @class;
		CaptchaQueue.smethod_1(null, null);
		Task<string> task = @class.taskCompletionSource_0.Task;
		Task task2 = await Task.WhenAny(new Task[]
		{
			task,
			cancellationToken_0.smethod_23()
		});
		Class131 class2;
		CaptchaQueue.concurrentDictionary_0.TryRemove(@class.string_0, out class2);
		CaptchaQueue.smethod_5(@class.int_1);
		CaptchaQueue.smethod_1(null, null);
		return (task == task2) ? task.Result : null;
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x0002DCA8 File Offset: 0x0002BEA8
	public static bool smethod_1(object object_0, EventArgs eventArgs_0)
	{
		Class131 value = CaptchaQueue.concurrentDictionary_0.FirstOrDefault(new Func<KeyValuePair<string, Class131>, bool>(CaptchaQueue.Class126.class126_0.method_1)).Value;
		GClass0 value2 = CaptchaQueue.dictionary_1.FirstOrDefault(new Func<KeyValuePair<int, GClass0>, bool>(CaptchaQueue.Class126.class126_0.method_2)).Value;
		if (value != null && value2 != null)
		{
			value.bool_0 = true;
			value.int_1 = value2.int_0;
			MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue.Class126.class126_0.method_4));
			value2.bool_0 = false;
			value2.webView_0.LoadHtml(value.uri_0.ToString().Contains("supreme") ? CaptchaQueue.smethod_3(value.string_1, value.string_0) : CaptchaQueue.smethod_2(value.string_1, value.int_0, value.string_0, value.uri_0), value.uri_0.ToString());
			return true;
		}
		MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue.Class126.class126_0.method_3));
		return false;
	}

	// Token: 0x0600054F RID: 1359 RVA: 0x000051E5 File Offset: 0x000033E5
	public static string smethod_2(string string_0, int int_2, string string_1, Uri uri_0)
	{
		return string.Format("<!DOCTYPE html>\r\n                        <html lang='en' dir='ltr'>\r\n                           <style>\r\n                              body\r\n                              {{\r\n                              background-color: #19171A\r\n                              }}\r\n                           </style>\r\n                           <body>\r\n                              <script>\r\n                                 var recaptchaCallback = function() {{\r\n                                   grecaptcha.render('g-recaptcha', {{\r\n                                     sitekey: '{0}',\r\n                                     size: 'normal',\r\n                                     theme: 'dark',\r\n                                     callback: 'onCaptchaSuccess',\r\n                                   }});\r\n                                 }};\r\n\r\n                                 var onCaptchaSuccess = function() {{\r\n                                   var event;\r\n\r\n                                   try {{\r\n                                     event = new Event('captchaSuccess', {{bubbles: true, cancelable: true}});\r\n                                   }} catch (e) {{\r\n                                     event = document.createEvent('Event');\r\n                                     event.initEvent('captchaSuccess', true, true);\r\n                                   }}\r\n\r\n                                   window.dispatchEvent(event);\r\n                                 }}\r\n                              </script>\r\n                              <script>\r\n                                 var checker = setInterval(check, 300);\r\n\r\n                                 function check(){{\r\n                                   var response = grecaptcha.getResponse();\r\n                                   if(response != ''){{\r\n                                     submit(response, '{1}');\r\n                                     clearInterval(checker);\r\n                                   }}\r\n                                 }}\r\n\r\n                                 var clicker = setInterval(click, 300);\r\n                                 function click(){{\r\n\t                                 if(window.frames.length > 0){{\r\n\t\t                                 window.frames[0].document.getElementsByClassName('recaptcha-checkbox-checkmark')[0].click();\r\n\t\t                                 clearInterval(clicker);\r\n                                     }}\r\n                                 }}\r\n                              </script>\r\n                              <script src='https://www.google.com/recaptcha/api.js?onload=recaptchaCallback&amp;render=explicit&amp;hl=en' async='async'></script>\r\n                              <div align='center' id='g-recaptcha' class='g-recaptcha'></div>\r\n                              <center style='color:white; font-family:Verdana;margin:20px'>\r\n                                 <hr width='40px'>\r\n                              </center>\r\n                              <center style='color:white; font-family:Verdana;margin:10px'><b>Task ID: </b>{2}</center>\r\n                              <center style='color:white; font-family:Verdana'><b>Retailer: </b>{3}</center>\r\n                           </body>\r\n                        </html>", new object[]
		{
			string_0,
			string_1,
			int_2,
			uri_0.Host
		});
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x00005211 File Offset: 0x00003411
	public static string smethod_3(string string_0, string string_1)
	{
		return string.Format("<html>\r\n\t                        <style>\r\n\t                        body\r\n\t                        {{\r\n\t                            background-color: #19171A\r\n\t                        }}\r\n\t                        </style>\r\n                            <script>function _submit(captcha){{ submit(captcha, '{0}'); }};</script>\r\n\t                        <body onclick='grecaptcha.execute();' onload='grecaptcha.execute();'>\r\n                            <div class='g-recaptcha'\r\n                                  data-sitekey='{1}'\r\n                                  data-callback='_submit'\r\n                                  data-size='invisible'\r\n\t\t                          data-theme='dark'>\r\n                            </div>\r\n\r\n                            <script src='https://www.google.com/recaptcha/api.js' async defer></script>\r\n                        </html>", string_1, string_0);
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x0000521F File Offset: 0x0000341F
	public static string smethod_4()
	{
		return "<!DOCTYPE html>\r\n                            <html lang='en' >\r\n\r\n                            <head>\r\n                                <meta charset='UTF-8'>\r\n                                <title>Loading circle</title>\r\n\r\n                            </head>\r\n                            <style>\r\n\r\n                            body{\r\n                                background-color: #19171A;\r\n                            }\r\n                            #loader-page {\r\n                                position: fixed;\r\n                                top: 0;\r\n                                left: 0;\r\n                                height: 100%;\r\n                                width: 100%;\r\n                                background-color: transparent;\r\n                            }\r\n\r\n                            .loader-name {\r\n                                position: absolute;\r\n                                top: 50%;\r\n                                left: 50%;\r\n                                margin-top: -10px;\r\n                                margin-left: -52px;\r\n                                font-size: 125%;\r\n                                font-family: 'Montserrat', sans-serif;\r\n                                text-transform: uppercase;\r\n                                letter-spacing: 0.1em;\r\n                                color: #fefefe;\r\n                            }\r\n\r\n                            .loader-circle {\r\n                                width: 180px;\r\n                                height: 180px;\r\n                                -webkit-box-sizing: border-box;\r\n                                        box-sizing: border-box;\r\n                                position: fixed;\r\n                                top: 50%;\r\n                                left: 50%;\r\n                                border-top: 5px solid #fefefe;\r\n                                border-bottom: 2px solid transparent;\r\n                                border-left: 2px solid transparent;\r\n                                border-right: 2px solid transparent;\r\n                                border-radius: 50%;\r\n                                margin-top: -90px;\r\n                                margin-left: -90px;\r\n                                -webkit-animation: loader 1s infinite linear;\r\n                                        animation: loader 1s infinite linear;\r\n                            }\r\n\r\n                            @-webkit-keyframes loader {\r\n                                from {\r\n                                -webkit-transform: rotate(0deg);\r\n                                        transform: rotate(0deg);\r\n                                }\r\n                                to {\r\n                                -webkit-transform: rotate(360deg);\r\n                                        transform: rotate(360deg);\r\n                                }\r\n                            }\r\n\r\n                            @keyframes loader {\r\n                                from {\r\n                                -webkit-transform: rotate(0deg);\r\n                                        transform: rotate(0deg);\r\n                                }\r\n                                to {\r\n                                -webkit-transform: rotate(360deg);\r\n                                        transform: rotate(360deg);\r\n                                }\r\n                            }\r\n\r\n                            </style>\r\n                            <body>\r\n\r\n\t                            <div class='loader-name'>Waiting</div>\r\n\t                            <div class='loader-circle'></div>\r\n                            </div>\r\n\r\n                            </body>\r\n\r\n                            </html>\r\n                            ";
	}

	// Token: 0x06000552 RID: 1362 RVA: 0x00005226 File Offset: 0x00003426
	public static void smethod_5(int int_2)
	{
		if (!CaptchaQueue.dictionary_1.ContainsKey(int_2))
		{
			return;
		}
		CaptchaQueue.dictionary_1[int_2].bool_0 = true;
		CaptchaQueue.dictionary_1[int_2].webView_0.LoadHtml(CaptchaQueue.smethod_4());
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x00005262 File Offset: 0x00003462
	private void googlelogin_button_Click(object sender, EventArgs e)
	{
		if (!CaptchaQueue.dictionary_1.ContainsKey(CaptchaQueue.int_0))
		{
			return;
		}
		CaptchaQueue.dictionary_1[CaptchaQueue.int_0].webView_0.LoadUrl("https://accounts.google.com/signin/v2/identifier?continue=https%3A%2F%2Fwww.youtube.com&service=youtube&hl=en&uilel=3&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x0002DDF4 File Offset: 0x0002BFF4
	private void clearsession_button_Click(object sender, EventArgs e)
	{
		GClass0 gclass = CaptchaQueue.dictionary_1[CaptchaQueue.int_0];
		WebView webView = gclass.webView_0;
		webView.Engine.Stop(true);
		webView.Dispose();
		Engine engine = gclass.webView_0.Engine;
		BrowserOptions options = new BrowserOptions
		{
			EnableXSSAuditor = new bool?(false),
			EnableWebSecurity = new bool?(false)
		};
		webView = new WebView();
		webView.SetOptions(options);
		webView.Engine = engine;
		webView.Engine.AllowRestart = true;
		webView.Create(gclass.panel_0.Handle);
		webView.RegisterJSExtensionFunction("submit", new JSExtInvokeHandler(this.method_3));
		webView.CertificateError += this.method_11;
		webView.BeforeContextMenu += this.method_10;
		CaptchaQueue.dictionary_1[CaptchaQueue.int_0].webView_0 = webView;
		this.reloadCaptcha_Click(null, null);
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x0002DEE0 File Offset: 0x0002C0E0
	private void method_4()
	{
		foreach (KeyValuePair<int, GClass1> keyValuePair in this.dictionary_0)
		{
			keyValuePair.Value.bunifuCustomLabel_0.Visible = false;
		}
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x0002DF40 File Offset: 0x0002C140
	private void method_5()
	{
		foreach (GClass1 gclass in this.dictionary_0.Values)
		{
			gclass.method_1();
		}
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x0002DF98 File Offset: 0x0002C198
	private void solverButton1_Click(object sender, EventArgs e)
	{
		this.method_6(this.dictionary_0[Convert.ToInt32(((BunifuThinButton2)sender).Name.Last<char>().ToString())]);
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x0002DFD4 File Offset: 0x0002C1D4
	private void method_6(GClass1 gclass1_0)
	{
		short key = Convert.ToInt16(gclass1_0.bunifuThinButton2_0.ButtonText.Split(new char[]
		{
			' '
		}).Last<string>());
		if (!CaptchaQueue.dictionary_1.ContainsKey((int)key))
		{
			return;
		}
		this.method_4();
		gclass1_0.bunifuCustomLabel_0.Visible = true;
		this.browserPanel.Controls.Clear();
		this.browserPanel.Controls.Add(CaptchaQueue.dictionary_1[(int)key].panel_0);
		this.proxyInput.Text = ((CaptchaQueue.dictionary_1[(int)key].string_1.ToString() != string.Empty) ? CaptchaQueue.dictionary_1[(int)key].string_1 : "localhost");
		CaptchaQueue.int_0 = (int)key;
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x0002E0A0 File Offset: 0x0002C2A0
	private void closeButton1_Click(object sender, EventArgs e)
	{
		this.method_7(this.dictionary_0[Convert.ToInt32(((BunifuThinButton2)sender).Name.Last<char>().ToString())]);
	}

	// Token: 0x0600055A RID: 1370 RVA: 0x0002E0DC File Offset: 0x0002C2DC
	private void method_7(GClass1 gclass1_0)
	{
		CaptchaQueue.Class127 @class = new CaptchaQueue.Class127();
		if (CaptchaQueue.dictionary_1.Count == 1)
		{
			return;
		}
		@class.short_0 = Convert.ToInt16(gclass1_0.bunifuThinButton2_0.ButtonText.Split(new char[]
		{
			' '
		}).Last<string>());
		gclass1_0.method_1();
		CaptchaQueue.dictionary_1[(int)@class.short_0].webView_0.Engine.Stop(true);
		CaptchaQueue.dictionary_1[(int)@class.short_0].webView_0.Dispose();
		CaptchaQueue.dictionary_1.Remove((int)@class.short_0);
		Class131 class2 = CaptchaQueue.concurrentDictionary_0.Values.FirstOrDefault(new Func<Class131, bool>(@class.method_0));
		if (class2 != null)
		{
			class2.int_1 = 0;
			class2.bool_0 = false;
			CaptchaQueue.smethod_1(null, null);
		}
		this.method_9(this.int_1);
		if (CaptchaQueue.int_0 == (int)@class.short_0 && !this.method_8())
		{
			int num = this.dictionary_0.Values.ToList<GClass1>().IndexOf(gclass1_0);
			this.method_6(this.dictionary_0[(num > 0) ? num : 4]);
		}
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x0002E200 File Offset: 0x0002C400
	private void nextTabButton_Click(object sender, EventArgs e)
	{
		this.method_4();
		int num = (CaptchaQueue.dictionary_1.Count<KeyValuePair<int, GClass0>>() + 3) / 4;
		if (this.int_1 >= num)
		{
			this.int_1 = 0;
		}
		this.method_9(this.int_1 + 1);
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x0002E240 File Offset: 0x0002C440
	private bool method_8()
	{
		if (CaptchaQueue.dictionary_1.ContainsKey(CaptchaQueue.int_0) && !CaptchaQueue.dictionary_1[CaptchaQueue.int_0].bool_0)
		{
			return false;
		}
		Class131 @class = CaptchaQueue.concurrentDictionary_0.Values.Where(new Func<Class131, bool>(CaptchaQueue.Class126.class126_0.method_5)).FirstOrDefault<Class131>();
		if (@class == null)
		{
			return false;
		}
		int num = CaptchaQueue.dictionary_1.Values.OrderBy(new Func<GClass0, int>(CaptchaQueue.Class126.class126_0.method_6)).ToList<GClass0>().IndexOf(CaptchaQueue.dictionary_1[@class.int_1]);
		int key = num % 4 + 1;
		int num2 = num / 4;
		this.method_9(this.int_1);
		this.method_6(this.dictionary_0[key]);
		return true;
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x0002E320 File Offset: 0x0002C520
	private void method_9(int int_2)
	{
		this.int_1 = int_2;
		List<int> list = CaptchaQueue.dictionary_1.OrderBy(new Func<KeyValuePair<int, GClass0>, int>(CaptchaQueue.Class126.class126_0.method_7)).ToList<KeyValuePair<int, GClass0>>().Skip(int_2 * 4 - 4).Take(4).Select(new Func<KeyValuePair<int, GClass0>, int>(CaptchaQueue.Class126.class126_0.method_8)).ToList<int>();
		if (list.Count == 0)
		{
			this.method_9(this.int_1 - 1);
			return;
		}
		this.method_5();
		int num = 1;
		foreach (int num2 in list)
		{
			this.dictionary_0[num].method_0(string.Format("Solver {0}", num2), CaptchaQueue.int_0 == num2);
			num++;
		}
	}

	// Token: 0x0600055E RID: 1374 RVA: 0x0002E424 File Offset: 0x0002C624
	private void addSolverButton_Click(object sender, EventArgs e)
	{
		this.method_0(null, null);
		int int_ = (CaptchaQueue.dictionary_1.Count<KeyValuePair<int, GClass0>>() + 3) / 4;
		this.method_9(int_);
		CaptchaQueue.smethod_1(null, null);
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x0002E458 File Offset: 0x0002C658
	private void reloadCaptcha_Click(object sender, EventArgs e)
	{
		Class131 value = CaptchaQueue.concurrentDictionary_0.Where(new Func<KeyValuePair<string, Class131>, bool>(CaptchaQueue.Class126.class126_0.method_9)).FirstOrDefault<KeyValuePair<string, Class131>>().Value;
		if (value != null)
		{
			CaptchaQueue.dictionary_1[value.int_1].webView_0.LoadHtml(value.uri_0.ToString().Contains("supreme") ? CaptchaQueue.smethod_3(value.string_1, value.string_0) : CaptchaQueue.smethod_2(value.string_1, value.int_0, value.string_0, value.uri_0), value.uri_0.ToString());
			return;
		}
		CaptchaQueue.smethod_5(CaptchaQueue.int_0);
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x000036D3 File Offset: 0x000018D3
	private void method_10(object sender, BeforeContextMenuEventArgs e)
	{
		e.Menu.Items.Clear();
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x00005295 File Offset: 0x00003495
	public void method_11(object sender, CertificateErrorEventArgs e)
	{
		e.Continue();
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x0000382F File Offset: 0x00001A2F
	private void close_btn_Click(object sender, EventArgs e)
	{
		base.Hide();
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x000036FD File Offset: 0x000018FD
	private void minimise_btn_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x0000529D File Offset: 0x0000349D
	private void testBtn_Click(object sender, EventArgs e)
	{
		CaptchaQueue.dictionary_1[CaptchaQueue.int_0].webView_0.LoadUrl("https://patrickhlauke.github.io/recaptcha/");
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x000308EC File Offset: 0x0002EAEC
	protected override void WndProc(ref Message m)
	{
		if (m.Msg != 132)
		{
			base.WndProc(ref m);
			return;
		}
		int x = (int)(m.LParam.ToInt64() & 65535L);
		int y = (int)((m.LParam.ToInt64() & 4294901760L) >> 16);
		Point point = base.PointToClient(new Point(x, y));
		Size clientSize = base.ClientSize;
		if (point.X >= clientSize.Width - 16 && point.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)(base.IsMirrored ? 16 : 17);
			return;
		}
		if (point.X <= 16 && point.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)(base.IsMirrored ? 17 : 16);
			return;
		}
		if (point.X <= 16 && point.Y <= 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)(base.IsMirrored ? 14 : 13);
			return;
		}
		if (point.X >= clientSize.Width - 16 && point.Y <= 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)(base.IsMirrored ? 13 : 14);
			return;
		}
		if (point.Y <= 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)12;
			return;
		}
		if (point.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)15;
			return;
		}
		if (point.X <= 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)10;
			return;
		}
		if (point.X >= clientSize.Width - 16 && clientSize.Height >= 16)
		{
			m.Result = (IntPtr)11;
		}
	}

	// Token: 0x06000568 RID: 1384
	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr intptr_0, int int_2, int int_3, int int_4);

	// Token: 0x06000569 RID: 1385
	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x0600056A RID: 1386 RVA: 0x000052DD File Offset: 0x000034DD
	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.ClassStyle |= 131072;
			return createParams;
		}
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x000052F7 File Offset: 0x000034F7
	private void top_panel_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			CaptchaQueue.ReleaseCapture();
			CaptchaQueue.SendMessage(base.Handle, 161, 2, 0);
		}
	}

	// Token: 0x040003DA RID: 986
	public Dictionary<int, GClass1> dictionary_0;

	// Token: 0x040003DB RID: 987
	public static ConcurrentDictionary<string, Class131> concurrentDictionary_0 = new ConcurrentDictionary<string, Class131>();

	// Token: 0x040003DC RID: 988
	private static Dictionary<int, GClass0> dictionary_1 = new Dictionary<int, GClass0>();

	// Token: 0x040003DD RID: 989
	public static SoundPlayer soundPlayer_0 = new SoundPlayer(Class158.smethod_4());

	// Token: 0x040003DE RID: 990
	private static int int_0;

	// Token: 0x040003DF RID: 991
	private int int_1;

	// Token: 0x020000E7 RID: 231
	[Serializable]
	private sealed class Class126
	{
		// Token: 0x0600056E RID: 1390 RVA: 0x0000532B File Offset: 0x0000352B
		internal void method_0()
		{
			MainWindow.smethod_1(null, null);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x00005334 File Offset: 0x00003534
		internal bool method_1(KeyValuePair<string, Class131> keyValuePair_0)
		{
			return !keyValuePair_0.Value.bool_0;
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x00005345 File Offset: 0x00003545
		internal bool method_2(KeyValuePair<int, GClass0> keyValuePair_0)
		{
			return keyValuePair_0.Value.bool_0;
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00005353 File Offset: 0x00003553
		internal void method_3()
		{
			MainWindow.captchaQueue_0.method_8();
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00005353 File Offset: 0x00003553
		internal void method_4()
		{
			MainWindow.captchaQueue_0.method_8();
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00005360 File Offset: 0x00003560
		internal bool method_5(Class131 class131_0)
		{
			return class131_0.bool_0;
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00005368 File Offset: 0x00003568
		internal int method_6(GClass0 gclass0_0)
		{
			return gclass0_0.int_0;
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00005370 File Offset: 0x00003570
		internal int method_7(KeyValuePair<int, GClass0> keyValuePair_0)
		{
			return keyValuePair_0.Value.int_0;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00005370 File Offset: 0x00003570
		internal int method_8(KeyValuePair<int, GClass0> keyValuePair_0)
		{
			return keyValuePair_0.Value.int_0;
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0000537E File Offset: 0x0000357E
		internal bool method_9(KeyValuePair<string, Class131> keyValuePair_0)
		{
			return keyValuePair_0.Value.int_1 == CaptchaQueue.int_0 && keyValuePair_0.Value.bool_0;
		}

		// Token: 0x040003FF RID: 1023
		public static readonly CaptchaQueue.Class126 class126_0 = new CaptchaQueue.Class126();

		// Token: 0x04000400 RID: 1024
		public static MethodInvoker methodInvoker_0;

		// Token: 0x04000401 RID: 1025
		public static Func<KeyValuePair<string, Class131>, bool> func_0;

		// Token: 0x04000402 RID: 1026
		public static Func<KeyValuePair<int, GClass0>, bool> func_1;

		// Token: 0x04000403 RID: 1027
		public static MethodInvoker methodInvoker_1;

		// Token: 0x04000404 RID: 1028
		public static MethodInvoker methodInvoker_2;

		// Token: 0x04000405 RID: 1029
		public static Func<Class131, bool> func_2;

		// Token: 0x04000406 RID: 1030
		public static Func<GClass0, int> func_3;

		// Token: 0x04000407 RID: 1031
		public static Func<KeyValuePair<int, GClass0>, int> func_4;

		// Token: 0x04000408 RID: 1032
		public static Func<KeyValuePair<int, GClass0>, int> func_5;

		// Token: 0x04000409 RID: 1033
		public static Func<KeyValuePair<string, Class131>, bool> func_6;
	}

	// Token: 0x020000E8 RID: 232
	private sealed class Class127
	{
		// Token: 0x06000579 RID: 1401 RVA: 0x000053A1 File Offset: 0x000035A1
		internal bool method_0(Class131 class131_0)
		{
			return class131_0.int_1 == (int)this.short_0;
		}

		// Token: 0x0400040A RID: 1034
		public short short_0;
	}

	// Token: 0x020000E9 RID: 233
	[StructLayout(LayoutKind.Auto)]
	private struct Struct81 : IAsyncStateMachine
	{
		// Token: 0x0600057A RID: 1402 RVA: 0x00030B0C File Offset: 0x0002ED0C
		void IAsyncStateMachine.MoveNext()
		{
			int num2;
			int num = num2;
			string result2;
			try
			{
				TaskAwaiter<Task> taskAwaiter;
				if (num != 0)
				{
					MainWindow.mainWindow_0.Invoke(new MethodInvoker(CaptchaQueue.Class126.class126_0.method_0));
					@class = new Class131
					{
						int_0 = (int)Convert.ToInt16(string_2),
						string_1 = string_0,
						uri_0 = new Uri(string_1)
					};
					CaptchaQueue.concurrentDictionary_0[@class.string_0] = @class;
					CaptchaQueue.smethod_1(null, null);
					task = @class.taskCompletionSource_0.Task;
					taskAwaiter = Task.WhenAny(new Task[]
					{
						task,
						cancellationToken_0.smethod_23()
					}).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num2 = 0;
						TaskAwaiter<Task> taskAwaiter2 = taskAwaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<Task>, CaptchaQueue.Struct81>(ref taskAwaiter, ref this);
						return;
					}
				}
				else
				{
					TaskAwaiter<Task> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<Task>);
					num2 = -1;
				}
				Task result = taskAwaiter.GetResult();
				Class131 class2;
				CaptchaQueue.concurrentDictionary_0.TryRemove(@class.string_0, out class2);
				CaptchaQueue.smethod_5(@class.int_1);
				CaptchaQueue.smethod_1(null, null);
				result2 = ((task == result) ? task.Result : null);
			}
			catch (Exception exception)
			{
				num2 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			num2 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result2);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x000053B1 File Offset: 0x000035B1
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400040B RID: 1035
		public int int_0;

		// Token: 0x0400040C RID: 1036
		public AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder_0;

		// Token: 0x0400040D RID: 1037
		public string string_0;

		// Token: 0x0400040E RID: 1038
		public string string_1;

		// Token: 0x0400040F RID: 1039
		public string string_2;

		// Token: 0x04000410 RID: 1040
		public CancellationToken cancellationToken_0;

		// Token: 0x04000411 RID: 1041
		private Class131 class131_0;

		// Token: 0x04000412 RID: 1042
		private Task<string> task_0;

		// Token: 0x04000413 RID: 1043
		private TaskAwaiter<Task> taskAwaiter_0;
	}
}
