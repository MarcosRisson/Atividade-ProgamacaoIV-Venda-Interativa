using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UMFG.Venda.Aprensetacao.Interfaces;
using UMFG.Venda.Aprensetacao.Models;
using UMFG.Venda.Aprensetacao.ViewModels;

namespace UMFG.Venda.Aprensetacao.UserControls
{
    /// <summary>
    /// Interação lógica para ucReceber.xam
    /// </summary>
    public partial class ucReceber : UserControl
    {
        private IObserver observer;

        private ucReceber(IObserver observer, PedidoModel pedido)
        {
            InitializeComponent();

            DataContext = new ReceberViewModel(this, observer, pedido);
        }

        internal static PedidoModel Exibir(IObserver observer,
            PedidoModel pedido)
        {
            var tela = new ucReceber(observer, pedido);
            var vm = tela.DataContext as ReceberViewModel;

            vm.Notify();
            return vm.Pedido;
        }

        private void ValidacaoDados(object sender, RoutedEventArgs e)
        {
            string data = this.data.Text;
            string numeroCartao = this.numeroCartao.Text;
            DateTime dataHoje = DateTime.Today;

            try
            {

                if (DateTime.TryParseExact(data, "MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataConvertida))
                {
                    if (dataConvertida < dataHoje)
                    {
                        MessageBox.Show("O prazo de validade do cartão expirou.");
                    }
                    else if (dataConvertida > dataHoje)
                    {

                        if (long.TryParse(numeroCartao, out long numeroCartaoL) && numeroCartao.Length == 16)
                        {
                            MessageBox.Show("Pagamento realizado com sucesso.", "Sucesso");
                            NavigationService navigationService = NavigationService.GetNavigationService(this);
                            navigationService?.Navigate(new ucListarProdutos(observer));
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Número do cartão inválido. Certifique-se de que possui exatamente 16 dígitos.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Formato de data de validade inválido. Utilize o formato MM-yyyy.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro. Verifique seus dados novamente.", "Erro");
            }
        }

        private void ValidacaoTamanho(object sender, TextCompositionEventArgs e)
        {
            if (((TextBox)sender).Text.Length >= 3)
            {
                e.Handled = true;
            }
        }





    }
}

