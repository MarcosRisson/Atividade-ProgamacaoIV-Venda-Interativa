using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UMFG.Venda.Aprensetacao.Classes;
using UMFG.Venda.Aprensetacao.ViewModels;

namespace UMFG.Venda.Aprensetacao.Comandos
{
    internal class RemoverProdutoPedidoComand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            
            if (!(parameter is ListarProdutosViewModel vm) || vm.ProdutoSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um produto para remover.");
                return;
            }

            if (!vm.Pedido.Produtos.Contains(vm.ProdutoSelecionado))
            {
                MessageBox.Show("O produto selecionado não está na lista. Por favor, escolha um produto válido.");
                return;
            }

            vm.Pedido.Produtos.Remove(vm.ProdutoSelecionado);
         
            vm.Pedido.Total = vm.Pedido.Produtos.Sum(x => x.Preco);
        }
    }
}

