using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace GeradorJson
{
    /// <summary>
    /// Interaction logic for InsereJson.xaml
    /// </summary>
    public partial class InsereJson : Page
    {
        public InsereJson()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
            
            string _prefixo = this.prefixo.Text; // "VBC_";
            string _imagem = this.imagem.Text; // "viajarbarato.ch.dataapi:latest";
            string semEspacos = jsonEnv.Text.Replace(" ", "");
            string itemSelecionado = combo.SelectionBoxItem.ToString();

            //filtrando os parametros

            JsonTextReader reader = new JsonTextReader(new StringReader(semEspacos));
            string novoValor = "";
            string inicio = "";
            string fim = "";

            if (itemSelecionado == "Daemon")
            {
                novoValor = "docker run -d \\  \n";
                inicio = "--env ";
                fim = "\\";
            }
            else if (itemSelecionado == "Interactive")
            {
                novoValor = "docker run --it \\  \n";
                inicio = "--env ";
                fim = "\\";
            }
            

            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    if (reader.TokenType.ToString() != "PropertyName")
                        novoValor += $"{inicio}{_prefixo}{reader.Path.ToString().Replace(".", "__")}={reader.Value} {fim}";
                    else
                    {
                        novoValor += "\n";
                    }
                }
            }

            RetornoJson retornoJson = new RetornoJson(novoValor + " " +_imagem);
            this.NavigationService.Navigate(retornoJson);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Coloque um formato de json válido - Erro: " + ex.Message, "Atenção!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}