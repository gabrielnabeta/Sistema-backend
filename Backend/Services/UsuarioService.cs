using System;
using Backend.Common;
using Backend.Entities;
using Backend.Models;
using Backend.Repositorys;

namespace Backend.Services {
    public class UsuarioService {

        private string _connectionString;

        public UsuarioService(string connectionString) {
        
            _connectionString = connectionString;
        }
        
        public LoginResult Login(string email, string senha) {

            var result = new LoginResult();

            var UsuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = UsuarioRepository.obterUsuario(email);

            if (usuario != null) {

                if (usuario.Senha == senha) {

                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else {
                    result.sucesso = false;
                    result.mensagem = "Usuário e/ou senha inválidos";
                }
            }
            else {
                result.sucesso = false;

                result.mensagem = "Usuário e/ou senha inválidos";
            }

            return result;
        }

        public CadastroResult Cadastro(
            string nome, 
            string sobrenome, 
            string genero, 
            string telefone, 
            string email, 
            string senha) {

            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.obterUsuario(email);

            if (usuario != null) {

                result.sucesso = false;
                result.mensagem = "Usuario existente";
            }
            else {

                usuario = new Usuario1(); 
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Email = email;
                usuario.Telefone = telefone;
                usuario.Senha = senha;
                usuario.Genero = genero;
                usuario.UsuarioGuid = Guid.NewGuid();

                var affectedRows = usuarioRepository.Inserir(usuario);

                if (affectedRows > 0) {

                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else {

                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuario. Tente novamente";
                }
            }

            return result ;
        }

        public EsqueceuSenhaResult EsqueceuSenha(string email) {

            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.obterUsuario(email);

            if (usuario == null) {

                result.sucesso = false;
                result.mensagem = "Usuario não existe para esse email";
            }  
            else {

                var assunto = "Recuperação de senha";
                var corpo = "Sua senha é " + usuario.Senha;

                var emailSender = new EmailSender();

                emailSender.Enviar(assunto, corpo, usuario.Email);
            }

            return result;
        }

        public Usuario1 ObterU(Guid usuarioGuid) {

            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
