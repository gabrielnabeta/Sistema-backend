﻿
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Backend.Models;
using Backend.Services;
using System;

namespace Backend.Controllers {
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase {
        private IConfiguration _configuration;

        public ProdutoController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("cadastro")]
        public IActionResult Cadastro(CadastroProdutoRequest request) {
            var result = new CadastroProdutoResult();

            if (request == null ||
                string.IsNullOrEmpty(request.nome) ||
                string.IsNullOrEmpty(request.codigo) ||
                request.preco <= 0 ||
                request.qtdeEstoque <= 0) {
                result.mensagem = "Todos os campos são obrigatórios";

                return Ok(result);
            }

            var connectionString = _configuration.GetConnectionString("BackendDB");

            result = new ProdutoService(connectionString).Cadastro(
                request.nome,
                request.codigo,
                request.preco,
                request.qtdeEstoque);

            return Ok(result);
        }
    }
}

