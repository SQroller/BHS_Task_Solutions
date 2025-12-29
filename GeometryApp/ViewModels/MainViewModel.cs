using System.Collections.ObjectModel;

namespace GeometryApp.ViewModels;

/// <summary>
/// Главная ViewModel окна.
/// Хранит коллекцию доступных фигур и текущий выбранный элемент.
/// Состояние каждой фигуры сохраняется, так как ViewModel'и не пересоздаются.
/// </summary>
public sealed class MainViewModel : ObservableObject
{
    private ShapeViewModelBase? _selectedShape;

    /// <summary>
    /// Коллекция всех фигур, доступных пользователю.
    /// </summary>
    public ObservableCollection<ShapeViewModelBase> Shapes { get; } = new();

    /// <summary>
    /// Текущая выбранная фигура, к которой привязан UI.
    /// </summary>
    public ShapeViewModelBase? SelectedShape
    {
        get => _selectedShape;
        set => SetProperty(ref _selectedShape, value);
    }

    public MainViewModel()
    {
        // Инициализируем две фигуры и сохраняем их в коллекции.
        var rectangle = new RectangleViewModel
        {
            Text = "Прямоугольник",
        };

        var circle = new CircleViewModel
        {
            Text = "Круг",
        };

        Shapes.Add(rectangle);
        Shapes.Add(circle);

        // По умолчанию выбрана первая фигура (прямоугольник).
        SelectedShape = rectangle;
    }
}


