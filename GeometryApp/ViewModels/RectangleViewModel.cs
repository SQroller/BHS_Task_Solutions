namespace GeometryApp.ViewModels;

/// <summary>
/// ViewModel, описывающая прямоугольник.
/// Содержит специфические свойства: ширина, высота и угол поворота.
/// </summary>
public sealed class RectangleViewModel : ShapeViewModelBase
{
    private double _width = 200;
    private double _height = 120;
    private double _rotationAngle;

    public override string DisplayName => "Прямоугольник";

    /// <summary>
    /// Ширина прямоугольника в пикселях.
    /// </summary>
    public double Width
    {
        get => _width;
        set => SetProperty(ref _width, value);
    }

    /// <summary>
    /// Высота прямоугольника в пикселях.
    /// </summary>
    public double Height
    {
        get => _height;
        set => SetProperty(ref _height, value);
    }

    /// <summary>
    /// Угол поворота в градусах.
    /// </summary>
    public double RotationAngle
    {
        get => _rotationAngle;
        set => SetProperty(ref _rotationAngle, value);
    }
}


