using Avalonia.Media;
using ReactiveUI;
using System.Reactive;

namespace Kscript.Editor.ViewModels;

public class MainViewModel : ViewModelBase
{

    public MainViewModel()
    {
        UpdateVMCommand = ReactiveCommand.Create(UpdateVM);
    }

    private Color backgroundTintColor = Colors.Transparent;

    public Color BackgroundTintColor
    {
        get => backgroundTintColor;
        set => this.RaiseAndSetIfChanged(ref backgroundTintColor, value);
    }

    private double backgroundTintOpacity = 0.1;

    public double BackgroundTintOpacity
    {
        get => backgroundTintOpacity;
        set => this.RaiseAndSetIfChanged(ref backgroundTintOpacity, value);
    }

    private double materialOpacity = 0.1;

    public double MaterialOpacity
    {
        get => materialOpacity;
        set => this.RaiseAndSetIfChanged(ref materialOpacity, value);
    }

    private string content = "Update";

    public string Content
    {
        get => content;
        set => this.RaiseAndSetIfChanged(ref content, value);
    }

    public ReactiveCommand<Unit, Unit> UpdateVMCommand { get; }

    bool isT = true;

    public void UpdateVM()
    {
        BackgroundTintColor = isT ? Colors.Red : Colors.Transparent;
        isT = !isT;
    }

}
