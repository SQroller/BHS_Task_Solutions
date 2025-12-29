using Avalonia.Controls;

namespace GeometryApp.Views;

/// <summary>
/// Главное окно приложения.
/// Логика полностью вынесена во ViewModel (паттерн MVVM),
/// здесь оставляем только минимальный код инициализации.
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
}


