using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;

[assembly: AssemblyVersion("0.0.0.0")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport.EditorTests")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport.PlayTests.Performance")]
[assembly: InternalsVisibleTo("Unity.InternalAPINetworkingBridge.001")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
