using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using AvaloniaEdit;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace Controls.JsonEditor;

/// <inheritdoc />
public class JsonEditorControl : UserControl
{
    /// <summary>StyledProperty for <see cref="IsModified"/>.</summary>
    public static readonly StyledProperty<bool> IsModifiedProperty = AvaloniaProperty.Register<JsonEditorControl, bool>(
        nameof(IsModified),
        defaultValue: false
    );

    /// <summary>StyledProperty for <see cref="IsReadOnly"/>.</summary>
    public static readonly StyledProperty<bool> IsReadOnlyProperty = AvaloniaProperty.Register<JsonEditorControl, bool>(
        nameof(IsReadOnly),
        defaultValue: false
    );

    /// <summary>StyledProperty for <see cref="Text"/>.</summary>
    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<JsonEditorControl, string>(
        nameof(Text),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay
    );

    private readonly TextEditor _editor;

    private bool _updating;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonEditorControl"/> class.
    /// </summary>
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

        _editor.InstallTextMate(registryOptions).SetGrammar(registryOptions.GetScopeByLanguageId("json"));
        _editor.Document.TextChanged += OnEditorTextChanged;

        Content = _editor;
    }

    /// <summary>Gets a value indicating whether the content has been modified since last load.</summary>
    public bool IsModified
    {
        get => GetValue(IsModifiedProperty);
        private set => SetValue(IsModifiedProperty, value);
    }

    /// <summary>Gets or sets a value indicating whether the editor is read-only.</summary>
    public bool IsReadOnly
    {
        get => GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    /// <summary>Gets or sets the JSON content displayed in the editor.</summary>
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <inheritdoc />
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
