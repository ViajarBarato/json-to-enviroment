using System.Windows.Controls;

namespace GeradorJson
{
    /// <summary>
    /// Interaction logic for RetornoJson.xaml
    /// </summary>
    public partial class RetornoJson : Page
    {
        public RetornoJson()
        {
            InitializeComponent();
        }

        public RetornoJson(object data) : this()
        {
            this.DataContext = data;

            Conversor.Text = data.ToString();
        }
    }
}