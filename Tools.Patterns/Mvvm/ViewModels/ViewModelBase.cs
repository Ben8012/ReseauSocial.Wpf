using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tools.Patterns.Mvvm.Commands;

namespace Tools.Patterns.Mvvm.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected ViewModelBase()
        {
            Type type = GetType();
            Type commandType = typeof(ICommand);
            IEnumerable<PropertyInfo> propertyInfos = type.GetProperties().Where(p => p.PropertyType == commandType || p.PropertyType.GetInterfaces().Contains(commandType));

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                ICommand command = (ICommand)propertyInfo.GetMethod?.Invoke(this, null);

                if(command is not null)
                {
                    PropertyChanged += (o, e) => command.RaiseCanExecuteChanged();
                }
            }
        }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if(!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class ViewModelBase<TEntity> : ViewModelBase
        where TEntity : class
    {
        private readonly TEntity _entity;

        protected TEntity Entity
        {
            get { return _entity; }
        }

        public ViewModelBase(TEntity entity)
        {
            _entity = entity;
        }
    }

}
