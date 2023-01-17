using System.Windows.Input;

namespace Evira.App.Controls;

public partial class VerificationCodeKeyboard : ContentView
{
	public VerificationCodeKeyboard()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VerificationCodeKeyboard));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
        nameof(DeleteCommand),
        typeof(ICommand),
        typeof(VerificationCodeKeyboard));

    public ICommand DeleteCommand
    {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    void KeyboardButtonTapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Command?.Execute(((Label)sender).Text);
    }

    void DeleteButtonTapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        DeleteCommand?.Execute(null);
    }
}
