using Microsoft.Data.SqlClient;

namespace WebTeste.Opera
{
    namespace Operacao
    {
        public static class OperaBanco
        {
            public static SqlConnection conexaoBanco()
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-GTTL4CT\SQLEXPRESS;Initial Catalog=FolhaDePagamento;trusted_connection=true;TrustServerCertificate=True");
                conexao.Open();
                return conexao;
            }

        }
    }
}
