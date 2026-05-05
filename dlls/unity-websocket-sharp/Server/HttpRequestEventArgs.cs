using System;
using System.IO;
using System.Security.Principal;
using System.Text;
using UnityWebSocketSharp.Net;

namespace UnityWebSocketSharp.Server
{
	// Token: 0x02000019 RID: 25
	internal class HttpRequestEventArgs : EventArgs
	{
		// Token: 0x06000192 RID: 402 RVA: 0x00008CB9 File Offset: 0x00006EB9
		internal HttpRequestEventArgs(HttpListenerContext context, string documentRootPath)
		{
			this._context = context;
			this._docRootPath = documentRootPath;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00008CCF File Offset: 0x00006ECF
		public HttpListenerRequest Request
		{
			get
			{
				return this._context.Request;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00008CDC File Offset: 0x00006EDC
		public HttpListenerResponse Response
		{
			get
			{
				return this._context.Response;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00008CE9 File Offset: 0x00006EE9
		public IPrincipal User
		{
			get
			{
				return this._context.User;
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00008CF6 File Offset: 0x00006EF6
		private string createFilePath(string childPath)
		{
			childPath = childPath.TrimStart(new char[]
			{
				'/',
				'\\'
			});
			return new StringBuilder(this._docRootPath, 32).AppendFormat("/{0}", childPath).ToString().Replace('\\', '/');
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00008D38 File Offset: 0x00006F38
		private static bool tryReadFile(string path, out byte[] contents)
		{
			contents = null;
			if (!File.Exists(path))
			{
				return false;
			}
			try
			{
				contents = File.ReadAllBytes(path);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00008D78 File Offset: 0x00006F78
		public byte[] ReadFile(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path.IndexOf("..") > -1)
			{
				throw new ArgumentException("It contains '..'.", "path");
			}
			path = this.createFilePath(path);
			byte[] result;
			HttpRequestEventArgs.tryReadFile(path, out result);
			return result;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00008DDC File Offset: 0x00006FDC
		public bool TryReadFile(string path, out byte[] contents)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path.IndexOf("..") > -1)
			{
				throw new ArgumentException("It contains '..'.", "path");
			}
			path = this.createFilePath(path);
			return HttpRequestEventArgs.tryReadFile(path, out contents);
		}

		// Token: 0x0400009B RID: 155
		private HttpListenerContext _context;

		// Token: 0x0400009C RID: 156
		private string _docRootPath;
	}
}
