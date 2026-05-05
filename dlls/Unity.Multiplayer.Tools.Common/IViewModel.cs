using System;
using System.ComponentModel;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000020 RID: 32
	internal interface IViewModel<TViewModel>
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600008E RID: 142
		// (remove) Token: 0x0600008F RID: 143
		event IViewModel<TViewModel>.ViewModelChangedEventHandler ViewModelChanged;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000090 RID: 144
		// (remove) Token: 0x06000091 RID: 145
		event IViewModel<TViewModel>.ViewModelChangedPropertyEventHandler PropertyChanged;

		// Token: 0x0200002A RID: 42
		// (Invoke) Token: 0x060000AC RID: 172
		public delegate void ViewModelChangedEventHandler(TViewModel viewModel);

		// Token: 0x0200002B RID: 43
		// (Invoke) Token: 0x060000B0 RID: 176
		public delegate void ViewModelChangedPropertyEventHandler(TViewModel viewModel, PropertyChangedEventArgs eventArgs);
	}
}
