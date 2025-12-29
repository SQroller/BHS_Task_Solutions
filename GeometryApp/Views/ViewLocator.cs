using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using GeometryApp.ViewModels;

namespace GeometryApp.Views;

/// <summary>
/// ViewLocator позволяет Avalonia по типу ViewModel находить соответствующее View.
/// Это помогает соблюдать MVVM и не "зашивать" View в коде ViewModel.
/// </summary>
public sealed class ViewLocator : IDataTemplate
{
    public Control Build(object? data)
    {
        if (data is null)
        {
            return new TextBlock { Text = "Нет данных" };
        }

        var name = data.GetType().FullName!.Replace("ViewModels", "Views");
        name = name.Replace("ViewModel", "View");

        var type = Type.GetType(name);

        if (type is not null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = "Не удалось найти View для " + name };
    }

    public bool Match(object? data) => data is ObservableObject;
}


