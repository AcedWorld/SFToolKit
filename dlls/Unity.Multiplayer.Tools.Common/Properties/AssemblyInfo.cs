using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;

[assembly: AssemblyVersion("0.0.0.0")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.Adapters")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.Common.Tests")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.Editor")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.Initialization")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.MetricTestData")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.MetricTypes")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.NetStats")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.NetStatsMonitor.Component")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.NetStatsMonitor.Configuration")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.NetStatsMonitor.Editor")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.NetStatsMonitor.Implementation")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.NetStatsMonitor.Tests.Implementation")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.NetworkSimulator.Editor")]
[assembly: InternalsVisibleTo("Unity.Multiplayer.Tools.NetworkSimulator.Runtime")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
