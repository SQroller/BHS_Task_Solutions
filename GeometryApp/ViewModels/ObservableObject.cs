using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GeometryApp.ViewModels;

/// <summary>
/// Базовый класс для ViewModel, реализующий <see cref="INotifyPropertyChanged"/>.
/// Позволяет удобно и безопасно уведомлять UI об изменениях свойств.
/// </summary>
public abstract class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Универсальный helper для установки значения и генерации уведомления.
    /// </summary>
    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(storage, value))
        {
            return false;
        }

        storage = value!;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


