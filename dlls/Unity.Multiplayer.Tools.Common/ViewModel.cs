using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000021 RID: 33
	internal class ViewModel<TViewModel> : IViewModel<TViewModel> where TViewModel : ViewModel<TViewModel>
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000092 RID: 146 RVA: 0x00002FA0 File Offset: 0x000011A0
		// (remove) Token: 0x06000093 RID: 147 RVA: 0x00002FD8 File Offset: 0x000011D8
		public event IViewModel<TViewModel>.ViewModelChangedEventHandler ViewModelChanged;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000094 RID: 148 RVA: 0x00003010 File Offset: 0x00001210
		// (remove) Token: 0x06000095 RID: 149 RVA: 0x00003048 File Offset: 0x00001248
		public event IViewModel<TViewModel>.ViewModelChangedPropertyEventHandler PropertyChanged;

		// Token: 0x06000096 RID: 150 RVA: 0x0000307D File Offset: 0x0000127D
		protected bool SetField<TProperty>(ref TProperty field, TProperty value, [CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<TProperty>.Default.Equals(field, value))
			{
				return false;
			}
			field = value;
			this.OnPropertyChanged(propertyName);
			return true;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000030A3 File Offset: 0x000012A3
		protected virtual void OnViewModelChanged()
		{
			IViewModel<TViewModel>.ViewModelChangedEventHandler viewModelChanged = this.ViewModelChanged;
			if (viewModelChanged == null)
			{
				return;
			}
			viewModelChanged((TViewModel)((object)this));
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000030BB File Offset: 0x000012BB
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.OnViewModelChanged();
			IViewModel<TViewModel>.ViewModelChangedPropertyEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged == null)
			{
				return;
			}
			propertyChanged((TViewModel)((object)this), new PropertyChangedEventArgs(propertyName));
		}
	}
}
