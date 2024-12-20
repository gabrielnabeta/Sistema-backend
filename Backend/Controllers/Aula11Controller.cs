using Backend.Models;

using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers {
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase {


        [Route("ObterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo () {

            var meuVeiculo = new Veiculo ();

            meuVeiculo.cor = "Vermelho";
            meuVeiculo.modelo = "Hilux";
            meuVeiculo.marca = "Toyotta";
            meuVeiculo.placa = "DEX-3333";

            meuVeiculo.Acelerar();

            return meuVeiculo;  
        }

        [Route("ObterCarro")]
        [HttpGet]
        public Carro obterCarro () {

            var meuCarro = new Carro ();

            meuCarro.marca = "Honda";
            meuCarro.modelo = "Fit";
            meuCarro.placa = "Dex-1111";
            meuCarro.cor = "Rosa";

            return meuCarro;
        }


        [Route("ObterMoto")]
        [HttpGet]
        public Moto obterMoto () {

            var minhaMoto = new Moto ();

            minhaMoto.marca = "Honda";
            minhaMoto.modelo = "CB600";
            minhaMoto.cor = "Preta";
            minhaMoto.placa = "DDE-1341";

            return minhaMoto;
        }
    }
}
