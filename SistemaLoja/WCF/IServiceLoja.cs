using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IServiceLoja
    {

        [OperationContract]
        Produtoes GetProduto(int produtoId);

        [OperationContract]
        List<Produtoes> GetProdutos();
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Adicione suas operações de serviço aqui
    }



}
