using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class ServiceLoja : IServiceLoja
    {
        public Produtoes GetProduto(int produtoId)
        {
            var db = new SistemaLojaEntities();
            var produto = db.Produtoes.Find(produtoId);
            db.Dispose();
            return produto;
        }

        public List<Produtoes> GetProdutos()
        {
            var db = new SistemaLojaEntities();
            var produtos = db.Produtoes.ToList();
            db.Dispose();
            return produtos;
        }
    }
}
