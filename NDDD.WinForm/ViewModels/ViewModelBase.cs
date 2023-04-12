using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NDDD.WinForm.ViewModels
{
    /// <summary>
    /// ViewModelの基底クラス
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// SetProperty
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="field">field</param>
        /// <param name="value">value</param>
        /// <param name="propertyName">propertyName</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;

            var h = this.PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }

            return true;

        }

    }

}

