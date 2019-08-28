﻿using Newtonsoft.Json;
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
            string _prefixo = this.prefixo.Text; // "VBC_";
            string _imagem = this.imagem.Text; // "CaminhoDaImagemDocker";
            string semEspacos = jsonEnv.Text.Replace(" ", "");

            //filtrando os parametros

            JsonTextReader reader = new JsonTextReader(new StringReader(semEspacos));
            string novoValor = "";
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    if (reader.TokenType.ToString() != "PropertyName")
                        novoValor += $"{_prefixo}{reader.Path.ToString().Replace(".", "__")}={reader.Value}";
                    else
                    {
                        novoValor += "\n";
                    }
                }
            }

            RetornoJson retornoJson = new RetornoJson(novoValor);
            this.NavigationService.Navigate(retornoJson);
        }
    }
}