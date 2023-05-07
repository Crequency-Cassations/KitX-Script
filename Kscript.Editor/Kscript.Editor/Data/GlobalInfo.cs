using Common.BasicHelper.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kscript.Editor.Data;

public static class GlobalInfo
{
    public static readonly Dictionary<string, Queue<Action>> InfoReactors = new();

    public static void RegisterInfoReactor(this string name, Action action)
    {
        if (InfoReactors.TryGetValue(name, out var value))
            value.Push(action);
        else InfoReactors.Add(name, new Queue<Action>().Push(action));
    }

    public static void InvokeReactor(this string name)
    {
        if (InfoReactors.TryGetValue(name, out var value))
            value.ForEach(x => x.Invoke(), true);
    }

    private static void OnInfoChanged(string info) => InvokeReactor(info);

    public static readonly Dictionary<string, nint?> WindowHandles = new()
    {
        { "MainWindow", null }
    };

    public static void RegisterWindowHandle(this string name, nint? value)
    {
        if (WindowHandles.ContainsKey(name))
            WindowHandles[name] = value;
        else WindowHandles.Add(name, value);

        OnInfoChanged(nameof(WindowHandles));
    }

    public static nint RequestWindowHandle(this string name)
    {
        if (WindowHandles.TryGetValue(name, out var value))
            if (value is not null)
                return (nint)value;
        throw new IndexOutOfRangeException();
    }

    private static EditorState editorState = EditorState.Normal;

    public static EditorState EditorState
    {
        get => editorState;
        set
        {
            editorState = value;
            OnInfoChanged(nameof(EditorState));
        }
    }
}

public enum EditorState
{
    Normal = 0,
    Running = 1,
    Debugging = 2,
    RunInError = 3,
    EventInvoking = 4,
    TestsRunning = 5,
    TestsPassed = 6,
    TestsFailed = 7,
}
