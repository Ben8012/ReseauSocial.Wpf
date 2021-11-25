using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Patterns.Mvvm.ViewModels
{
    public abstract class ViewModelCollectionBase<TViewModel> : ViewModelBase
        where TViewModel : ViewModelBase
    {
        private ObservableCollection<TViewModel> _items;

        public ObservableCollection<TViewModel> Items 
        { 
            get => _items ??= LoadItems(); 
        }

        protected abstract ObservableCollection<TViewModel> LoadItems();
    }
}
