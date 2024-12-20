using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers {
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controller : ControllerBase {
        [Route("olaMundo")]
        [HttpGet]
        public string OlaMundo() {
            var msg = "ola mundo";

            return msg;
        }

        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public string OlaMundoPersonalizado(string nome) {

            var mensagem = "Ola mundo via API " + nome;

            return mensagem;
        }

        [Route("calculadora")]
        [HttpGet]
        public string Calculadora(int valor1, int valor2)  {

            var soma = valor1 + valor2;

            var mensagem = "A soma é " + soma;

            return mensagem;
        }


        [Route("Media")]
        [HttpGet]
        public string Media(int valor1, int valor2) {

            var media = (valor1 + valor2) / 2;

            var mensagem = "A média é " + media;

            return mensagem;
        }

        [Route("Terreno")]
        [HttpGet]
        public string Terreno(double largura, double comprimento, double valorM2) {

            var area = largura * comprimento;
            var ValorTerreno = area * valorM2;

            var mensagem = "A área do terreno é " + area + " e o valor do terreno é " + ValorTerreno;

            return mensagem;
        }

        [Route("Troco")]
        [HttpGet]
        public string Troco(double precoUnit, double qtd, double DinheiroRecebido) {

            var troco = DinheiroRecebido - (precoUnit * qtd);

            var mensagem = "O troco do cliente é de R$" + troco;

            return mensagem;

        }
        [Route("Pagamento")]
        [HttpGet]
        public string Pagamento(string nome, double valorHora, int qtdHoras) {

            var pagamento = (double) valorHora * qtdHoras;

            var mensagem = "O pagamento de " + nome + " é de R$" + pagamento;

            return mensagem;
        }


        [Route("Consumo")]
        [HttpGet]
        public string Consumo(int distancia, double combustivelGasto) {

            var medio = (double)distancia / combustivelGasto;

            var mensagem = "O consumo médio é de " + medio + "km";

            return mensagem;
        }
    }
}
