using Avalonia.Media;
using Kscript.Editor.Data;
using ReactiveUI;
using System.Reactive;

namespace Kscript.Editor.ViewModels;

public class MainViewModel : ViewModelBase
{

    public MainViewModel()
    {
        UpdateVMCommand = ReactiveCommand.Create(UpdateVM);

        nameof(GlobalInfo.EditorState).RegisterInfoReactor(
            () => BackgroundTintColor = EditorState2BackgroundColor);
    }

    public static Color EditorState2BackgroundColor
    {
        get
        {
            var state = GlobalInfo.EditorState;
            return state switch
            {
                EditorState.Normal => Colors.Transparent,
                EditorState.Running => Colors.Blue,
                EditorState.Debugging => Colors.Yellow,
                EditorState.RunInError => Colors.Red,
                EditorState.EventInvoking => Colors.RosyBrown,
                EditorState.TestsRunning => Colors.GreenYellow,
                EditorState.TestsPassed => Colors.Green,
                EditorState.TestsFailed => Colors.OrangeRed,
                _ => Colors.Transparent,
            };
        }
    }

    private Color backgroundTintColor = Colors.Transparent;

    public Color BackgroundTintColor
    {
        get => EditorState2BackgroundColor;
        set => this.RaiseAndSetIfChanged(ref backgroundTintColor, value);
    }

    private double backgroundTintOpacity = 0.2;

    public double BackgroundTintOpacity
    {
        get => backgroundTintOpacity;
        set => this.RaiseAndSetIfChanged(ref backgroundTintOpacity, value);
    }

    private double materialOpacity = 0;

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

    public void UpdateVM()
    {
        GlobalInfo.EditorState = GlobalInfo.EditorState switch
        {
            EditorState.Normal => EditorState.Running,
            EditorState.Running => EditorState.Debugging,
            EditorState.Debugging => EditorState.RunInError,
            EditorState.RunInError => EditorState.EventInvoking,
            EditorState.EventInvoking => EditorState.TestsRunning,
            EditorState.TestsRunning => EditorState.TestsPassed,
            EditorState.TestsPassed => EditorState.TestsFailed,
            EditorState.TestsFailed => GlobalInfo.EditorState = EditorState.Normal,
            _ => EditorState.Normal,
        };
        Content = GlobalInfo.EditorState.ToString();
    }

}
