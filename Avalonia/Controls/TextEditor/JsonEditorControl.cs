using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml.MarkupExtensions;
using AvaloniaEdit;
using AvaloniaEdit.Editing;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace Controls.JsonEditor;

public class JsonEditorControl : UserControl
{
    public static readonly StyledProperty<bool> IsModifiedProperty = AvaloniaProperty.Register<JsonEditorControl, bool>(
        nameof(IsModified),
        defaultValue: false
    );

    public static readonly StyledProperty<bool> IsReadOnlyProperty = AvaloniaProperty.Register<JsonEditorControl, bool>(
        nameof(IsReadOnly),
        defaultValue: false
    );

    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<JsonEditorControl, string>(
        nameof(Text),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay
    );

    private readonly TextEditor _editor;

    private bool _updating;

    public JsonEditorControl()
    {
        RegistryOptions registryOptions = new RegistryOptions(ThemeName.LightPlus);

        _editor = new TextEditor
        {
            Background = Avalonia.Media.Brushes.Transparent,
            FontFamily = new Avalonia.Media.FontFamily("Consolas,Courier New,monospace"),
            FontSize = 15,
            ShowLineNumbers = true,
            WordWrap = false,
        };

        _editor.Options.AllowScrollBelowDocument = false;
        _editor.TextArea.Bind(TextArea.SelectionBrushProperty, new DynamicResourceExtension("TertiaryBrush"));
        _editor.TextArea.Bind(TextArea.SelectionForegroundProperty, new DynamicResourceExtension("TextWhiteBrush"));

        _editor.InstallTextMate(registryOptions).SetGrammar(registryOptions.GetScopeByLanguageId("json"));
        _editor.Document.TextChanged += OnEditorTextChanged;

        Content = _editor;
    }

    public bool IsModified
    {
        get => GetValue(IsModifiedProperty);
        private set => SetValue(IsModifiedProperty, value);
    }

    public bool IsReadOnly
    {
        get => GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsReadOnlyProperty)
        {
            _editor.IsReadOnly = change.GetNewValue<bool>();
        }
        else if (change.Property == TextProperty && !_updating)
        {
            string newText = change.GetNewValue<string>();
            if (newText == _editor.Document.Text)
            {
                return;
            }

            _updating = true;
            _editor.Document.Text = newText;
            _editor.Document.UndoStack.MarkAsOriginalFile();
            SetValue(IsModifiedProperty, false);
            _updating = false;
        }
    }

    private void OnEditorTextChanged(object? sender, System.EventArgs e)
    {
        if (!_updating)
        {
            _updating = true;
            SetValue(TextProperty, _editor.Document.Text);
            SetValue(IsModifiedProperty, _editor.IsModified);
            _updating = false;
        }
    }
}
