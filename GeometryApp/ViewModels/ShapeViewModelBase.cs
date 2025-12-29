using Avalonia.Media;

namespace GeometryApp.ViewModels;

/// <summary>
/// Базовая ViewModel для геометрических фигур.
/// Содержит общие свойства: цвет заливки, цвет текста и сам текст.
/// </summary>
public abstract class ShapeViewModelBase : ObservableObject
{
    private Color _fillColor = Colors.SteelBlue;
    private Color _textColor = Colors.White;
    private string _text = "Фигура";

    /// <summary>
    /// Отображаемое название фигуры в UI (для ComboBox).
    /// </summary>
    public abstract string DisplayName { get; }

    /// <summary>
    /// Цвет заливки фигуры.
    /// </summary>
    public Color FillColor
    {
        get => _fillColor;
        set
        {
            if (SetProperty(ref _fillColor, value))
            {
                OnPropertyChanged(nameof(FillBrush));
            }
        }
    }

    /// <summary>
    /// Кисть для биндинга к свойству Fill в XAML.
    /// </summary>
    public IBrush FillBrush => new SolidColorBrush(FillColor);

    /// <summary>
    /// Цвет текста на фигуре.
    /// </summary>
    public Color TextColor
    {
        get => _textColor;
        set
        {
            if (SetProperty(ref _textColor, value))
            {
                OnPropertyChanged(nameof(TextBrush));
            }
        }
    }

    /// <summary>
    /// Кисть для текста (Foreground).
    /// </summary>
    public IBrush TextBrush => new SolidColorBrush(TextColor);

    /// <summary>
    /// Текст, отображаемый на фигуре.
    /// </summary>
    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }
}


