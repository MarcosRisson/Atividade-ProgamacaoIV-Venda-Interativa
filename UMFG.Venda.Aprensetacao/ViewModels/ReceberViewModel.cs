using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UMFG.Venda.Aprensetacao.Classes;
using UMFG.Venda.Aprensetacao.Interfaces;
using UMFG.Venda.Aprensetacao.Models;

namespace UMFG.Venda.Aprensetacao.ViewModels
{
    // ViewModel para a tela de recebimento
    internal sealed class ReceberViewModel : AbstractViewModel
    {
        // Campo privado que armazena o modelo de pedido
        private PedidoModel _pedido = new PedidoModel();

        // Propriedade pública para acessar e modificar o modelo de pedido
        public PedidoModel Pedido
        {
            get => _pedido;
            set => SetField(ref _pedido, value); // O método SetField é usado para atualizar o valor do campo e notificar as alterações para a interface do usuário
        }

        // Construtor da ViewModel de Recebimento
        public ReceberViewModel(UserControl userControl,
            IObserver observer,
            PedidoModel pedido
            ) : base("Receber") // Chama o construtor da classe base (AbstractViewModel) passando o nome "Receber"
        {
            // Verifica se os parâmetros passados são nulos, caso sejam, lança ArgumentNullException
            UserControl = userControl ?? throw new ArgumentNullException(nameof(userControl));
            MainUserControl = observer ?? throw new ArgumentNullException(nameof(observer));
            Pedido = pedido ?? throw new ArgumentNullException(nameof(pedido));

            Add(observer); // Adiciona o observador (observer) à lista de observadores da ViewModel
        }
    }
}

