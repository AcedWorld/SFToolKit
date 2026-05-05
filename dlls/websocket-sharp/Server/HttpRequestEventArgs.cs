using System;
using System.IO;
using System.Security.Principal;
using System.Text;
using WebSocketSharp.Net;

namespace WebSocketSharp.Server
{
	// Token: 0x02000048 RID: 72
	public class HttpRequestEventArgs : EventArgs
	{
		// Token: 0x060004D6 RID: 1238 RVA: 0x0001BA43 File Offset: 0x00019C43
		internal HttpRequestEventArgs(HttpListenerContext context, string documentRootPath)
		{
			this._context = context;
			this._docRootPath = documentRootPath;
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0001BA5C File Offset: 0x00019C5C
		public HttpListenerRequest Request
		{
			get
			{
				return this._context.Request;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0001BA7C File Offset: 0x00019C7C
		public HttpListenerResponse Response
		{
			get
			{
				return this._context.Response;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0001BA9C File Offset: 0x00019C9C
		public IPrincipal User
		{
			get
			{
				return this._context.User;
			}
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0001BABC File Offset: 0x00019CBC
		private string createFilePath(string childPath)
		{
			childPath = childPath.TrimStart(new char[]
			{
				'/',
				'\\'
			});
			return new StringBuilder(this._docRootPath, 32).AppendFormat("/{0}", childPath).ToString().Replace('\\', '/');
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0001BB0C File Offset: 0x00019D0C
		private static bool tryReadFile(string path, out byte[] contents)
		{
			contents = null;
			bool flag = !File.Exists(path);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				try
				{
					contents = File.ReadAllBytes(path);
				}
				catch
				{
					return false;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0001BB58 File Offset: 0x00019D58
		public byte[] ReadFile(string path)
		{
			bool flag = path == null;
			if (flag)
			{
				throw new ArgumentNullException("path");
			}
			bool flag2 = path.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			bool flag3 = path.IndexOf("..") > -1;
			if (flag3)
			{
				throw new ArgumentException("It contains '..'.", "path");
			}
			path = this.createFilePath(path);
			byte[] result;
			HttpRequestEventArgs.tryReadFile(path, out result);
			return result;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0001BBD4 File Offset: 0x00019DD4
		public bool TryReadFile(string path, out byte[] contents)
		{
			bool flag = path == null;
			if (flag)
			{
				throw new ArgumentNullException("path");
			}
			bool flag2 = path.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			bool flag3 = path.IndexOf("..") > -1;
			if (flag3)
			{
				throw new ArgumentException("It contains '..'.", "path");
			}
			path = this.createFilePath(path);
			return HttpRequestEventArgs.tryReadFile(path, out contents);
		}

		// Token: 0x0400023B RID: 571
		private HttpListenerContext _context;

		// Token: 0x0400023C RID: 572
		private string _docRootPath;
	}
}
