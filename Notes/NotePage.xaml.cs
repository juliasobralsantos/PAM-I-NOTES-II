namespace Notes;
public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    //Método Construtor (método que acontece a todo momento)
    public NotePage()
    {
        InitializeComponent();
        if (File.Exists(_fileName))
        TextEditor.Text = File.ReadAllText(_fileName);
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, TextEditor.Text);
        await DisplayAlert("Salvo", "Arquivo criado com sucesso",
          "Ok");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
            File.Delete(_fileName);
        {
            await DisplayAlert("Deletar arquivo", "Parece que esse arquivo já existe", "Fechar");
        }
        TextEditor.Text = string.Empty;
    }
}