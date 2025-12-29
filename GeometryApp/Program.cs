using Avalonia;

namespace GeometryApp;

/// <summary>
/// Точка входа в приложение GeometryApp.
/// Класс Program содержит стандартный Bootstrap-код Avalonia.
/// </summary>
internal sealed class Program
{
    // Типичная точка входа для desktop‑приложения Avalonia.
    public static void Main(string[] args) =>
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

    /// <summary>
    /// Создаёт и настраивает объект <see cref="AppBuilder"/>.
    /// Вынесено в отдельный метод, чтобы поддерживать интеграцию
    /// с тестами и дизайнером.
    /// </summary>
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            //.WithInterFont() // аккуратный кросс‑платформенный шрифт
            .LogToTrace();
}


