namespace GeometryApp.ViewModels;

/// <summary>
/// ViewModel, описывающая круг (отрисовывается как эллипс).
/// Содержит коэффициенты масштабирования по осям X и Y.
/// </summary>
public sealed class CircleViewModel : ShapeViewModelBase
{
    private double _scaleX = 1.0;
    private double _scaleY = 1.0;

    public override string DisplayName => "Круг";

    /// <summary>
    /// Масштаб по оси X (горизонтальное сжатие / растяжение).
    /// </summary>
    public double ScaleX
    {
        get => _scaleX;
        set => SetProperty(ref _scaleX, value);
    }

    /// <summary>
    /// Масштаб по оси Y (вертикальное сжатие / растяжение).
    /// </summary>
    public double ScaleY
    {
        get => _scaleY;
        set => SetProperty(ref _scaleY, value);
    }
}


