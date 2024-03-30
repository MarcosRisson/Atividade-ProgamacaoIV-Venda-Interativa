using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.Venda.Aprensetacao.Classes;


namespace UMFG.Venda.Aprensetacao.Models
{
    internal class CartaoModel
    {
        
        [CreditCard(ErrorMessage = "Numero de cartao invalido")]
        public string NumeroCartao { get; }

        public string Data { get; }

       
        public CartaoModel(string numeroCartao, string data)
        {
            NumeroCartao = numeroCartao;
            Data = data;
        }
    }
}
