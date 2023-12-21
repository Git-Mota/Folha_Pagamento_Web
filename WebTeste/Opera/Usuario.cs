using System.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using WebTeste.Opera;
using Microsoft.SqlServer.Types;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using WebTeste.Opera.Operacao;

namespace Operacao
{
    public class Usuario
    {
        public bool alterarSenhaUsr(string RecCpfUser, string RecSenha)
        {
            try
            {
                using (SqlConnection conexao = OperaBanco.conexaoBanco())
                {
                    string strSQL = "UPDATE Tab_Usuario SET db_Senha = @PrmtSenhaTemp where db_Cpf = @PrmtIdFunc";

                    using (SqlCommand cm = new SqlCommand(strSQL, conexao))
                    {
                        //string recebeSenha = gerarSenhaProvisoria();
                        cm.Parameters.Add("@PrmtSenhaTemp", SqlDbType.VarChar).Value = RecSenha;
                        cm.Parameters.Add("@PrmtIdFunc", SqlDbType.VarChar).Value = RecCpfUser;
                        cm.ExecuteNonQuery();
                        cm.Parameters.Clear();
                        conexao.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string gerarSenhaProvisoria()
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            char[] senha = new char[6];
            for (int i = 0; i < 6; i++)
            {
                senha[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
            }

            return new string(senha);
        }
    }
}
