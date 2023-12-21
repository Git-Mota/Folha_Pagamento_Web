using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using WebTeste.Opera.Operacao;

namespace Operacao
{
    public class DisparaEmail
    {

        private readonly string remetente;
        private readonly SecureString senhaRemetente;
        private string destinatario;
        private readonly string assunto;
        private readonly string corpo;
        private string senhaProvisoria;
        private string cpfDestinatario;


        public DisparaEmail(string RecCPFDestinatario)
        {
            Usuario objUsr = new Usuario();
            this.remetente = "evaldo.dev.junior@gmail.com";
            this.senhaRemetente = ConverterParaSecureString("psdw uenn mmil vlup");
            if (ConsultarEmail(RecCPFDestinatario) != null)
            {
                this.cpfDestinatario = RecCPFDestinatario;
            }
            else
            {
                this.destinatario = null;
            }
            this.senhaProvisoria = objUsr.gerarSenhaProvisoria();
            this.assunto = "Solicitação de recuperação de senha";
            this.corpo = "Recebemos sua solicitação para redefinição de senha. <br>Lembre-se de nunca compartilhar  a senha pessoal e alterar após o primeiro login a senha provisória<br>" +
                " Senha provisória: " + senhaProvisoria;
        }
        static SecureString ConverterParaSecureString(string senha)
        {
            SecureString secureSenha = new SecureString();

            foreach (char c in senha)
            {
                secureSenha.AppendChar(c);
            }

            // Importante: Marque a SecureString como somente leitura e inacessível da memória não gerenciada
            secureSenha.MakeReadOnly();

            return secureSenha;
        }

        public bool EnviarEmail()
        {
            try
            {
                if (destinatario != null)
                {
                    using (var mensagem = new MailMessage(remetente, destinatario, assunto, corpo))
                    {
                        mensagem.IsBodyHtml = true; // Se o corpo do email contém HTML

                        using (var clienteSmtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            clienteSmtp.EnableSsl = true; // Use SSL para conexão segura
                            clienteSmtp.Credentials = new NetworkCredential(remetente, senhaRemetente);

                            try
                            {
                                // Enviando o email
                                Usuario objUsuario = new Usuario();
                                objUsuario.alterarSenhaUsr(cpfDestinatario, senhaProvisoria); // altera senha banco de dados
                                clienteSmtp.Send(mensagem);
                                return true;
                            }
                            catch (Exception)
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }


        }
        public string ConsultarEmail(String RecCPF)
        {
            string emailDestinatario = null;
            if (RecCPF != null)
            {
                using (SqlConnection conexao = OperaBanco.conexaoBanco())
                {
                    string cpf = RecCPF;
                    string strSQL = "select Email from Tab_Funcionario where CPF = '" + cpf + "'";
                    using (SqlCommand cm = new SqlCommand(strSQL, conexao))
                    {
                        SqlDataReader reader = cm.ExecuteReader();
                        if (reader.Read())
                        {
                            emailDestinatario = reader.GetString(0);
                            destinatario = emailDestinatario;
                            conexao.Close();
                            return emailDestinatario;
                        }
                        else
                        {
                            conexao.Close();
                            return emailDestinatario;
                        }
                    }
                }
            }
            else
            {
                return emailDestinatario;
            }
        }
    }
}
