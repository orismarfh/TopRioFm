using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AudioForms.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		//Assinatura da Interface
		public event PropertyChangedEventHandler PropertyChanged;

		// Refactor - Deixar tudo dentro de um mesmo Método//Refactor - Diretiva CALLERMEMBERNAM
		protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(storage, value))
			{
				return false;
			}
			storage = value;
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}
