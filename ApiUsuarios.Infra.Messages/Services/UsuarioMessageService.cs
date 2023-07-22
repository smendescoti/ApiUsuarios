using ApiUsuarios.Domain.Dtos;
using ApiUsuarios.Infra.Messages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Infra.Messages.Services
{
    public class UsuarioMessageService
    {
        //método para fazer o envio da mensagem de boas vindas no cadastro do usuário
        public void GerarMensagemDeBoasVidas(UsuarioDto usuario)
        {
            var subject = $"Seja bem vindo ao sistema - COTI Informática";
            var body = $@"
                <div style='font: verdana; border: 1px solid #000; padding: 40px; margin: 40px;'>
                    <center>
                        <img src='https://www.cotiinformatica.com.br/imagens/logo-coti-informatica.png'/>
                        <br/>
                        <h3>Parabéns, {usuario.Nome}! Sua conta foi criada com sucesso.</h3>
                        <p>Seu usuário foi criado em nosso sistema e agora você pode autenticar-se e usar sua conta.</p>
                        <p>Att</p>
                        <p>Equipe COTI Informática</p>
                    </center>
                <div>
            ";

            MailHelper.SendMail(usuario.Email, subject, body);
        }

        //método para fazer o envio da mensagem de recuperação de senha no cadastro de usuário
        public void GerarRecuperacaoDeSenha(UsuarioDto usuario)
        {
            //TODO
        }
    }
}
