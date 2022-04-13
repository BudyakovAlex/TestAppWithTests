using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestApplication.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private readonly ConcurrentDictionary<string, object?> _properties = new();

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool CallPropertyChangeEvent { get; set; } = true;

        protected T Get<T>(Func<T>? func = null, [CallerMemberName] string name = null)
        {
            func ??= () => default(T);
            if (string.IsNullOrEmpty(name))
            {
                return func.Invoke();
            }

            if (_properties.TryGetValue(name, out var value))
            {
                return (T)value;
            }

            var defaultValue = func.Invoke();
            _properties.AddOrUpdate(name, defaultValue, (_, _) => defaultValue);
            return defaultValue;
        }

        protected bool Set(object value, [CallerMemberName] string name = null, params string[] otherPropertyNames)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            var isExists = _properties.TryGetValue(name, out var getValue);
            if (isExists && Equals(value, getValue))
            {
                return false;
            }

            _properties.AddOrUpdate(name, value, (s, o) => value);
            if (CallPropertyChangeEvent)
            {
                OnPropertyChanged(name);
                foreach (var propertyName in otherPropertyNames)
                {
                    OnPropertyChanged(propertyName);
                }
            }

            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}