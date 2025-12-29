using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using GeometryApp.ViewModels;
using GeometryApp.Views;

namespace GeometryApp;

/// <summary>
/// Корневой класс приложения Avalonia.
/// Отвечает за инициализацию ресурсов и создание главного окна.
/// </summary>
public partial class App : Application
{
    public override void Initialize()
    {
        // Подключаем XAML-ресурсы приложения (темы, стили и пр.).
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Создаем главную VM и View.
            var mainViewModel = new MainViewModel();

            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}


