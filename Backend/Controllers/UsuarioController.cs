using System;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Backend.Controllers {
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase {

        private IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration) {

            _configuration = configuration;
        }

        [Route("Login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request) {

            var result = new LoginResult();

            if (request == null ||
                string.IsNullOrEmpty(request.email) ||
                string.IsNullOrEmpty(request.senha))
                {

                result.mensagem = "Email e/ou senha inválidos";

                return result;
            } 

             var connectionString = _configuration.GetConnectionString("BackendDB");
             var usuarioService = new UsuarioService(connectionString);

             result = usuarioService.Login(request.email, request.senha);
            
            return result;
        }

        [Route("Cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request) {

            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.nome) ||
                string.IsNullOrWhiteSpace(request.sobrenome) ||
                string.IsNullOrWhiteSpace(request.telefone) ||
                string.IsNullOrWhiteSpace(request.genero) ||
                string.IsNullOrWhiteSpace(request.email) ||
                string.IsNullOrWhiteSpace(request.senha)) {

                result.mensagem = "Todos os campos são obrigatórios";

                return result;
            }
            
                var connectionString = _configuration.GetConnectionString("BackendDB");
                var UsuarioService = new UsuarioService(connectionString);

                result = UsuarioService.Cadastro(
                    request.nome,
                    request.sobrenome,
                    request.telefone,
                    request.genero, 
                    request.email,
                    request.senha);

                return result;
        }

        [Route("EsqueceuSenha")]
        [HttpPost]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request) {

            var result = new EsqueceuSenhaResult();

            if (request == null || 
                string.IsNullOrWhiteSpace(request.email)) {

                result.mensagem = "Email obrigatório";
            }
            else {
                var connectionString = _configuration.GetConnectionString("BackendDB");
                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.EsqueceuSenha(request.email);

                if (!string.IsNullOrWhiteSpace(result.mensagem)) {

                    result.sucesso = false;
                    result.mensagem = "Erro ao enviar email";
                }
                else {
                    result.sucesso = true; 
                }
            }
            return result;
        }

        [Route("ObterU")]
        [HttpGet]
        public ObterUResult ObterU(Guid usuarioGuid) {

            var result = new ObterUResult();

            if (usuarioGuid == null) {

                result.mensagem = "Guid vazio";
            }
            else {

                var connectionString = _configuration.GetConnectionString("BackendDB");

                var usuario = new UsuarioService(connectionString).ObterU(usuarioGuid);

                if (usuario == null) {

                    result.mensagem = "Usuário não existe";
                } 
                else {

                    result.sucesso = true;
                    result.nome = usuario.Nome;
                }
            }

            return result;
        }
    }
}
