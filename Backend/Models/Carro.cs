namespace Backend.Models {
    public class Carro : Veiculo {

        public Carro () {
            qtdRodas = 4;
        }

        public int qtdRodas { get; set; }

        public override void Acelerar() {

            InjetarCombustivel(4);
        }

        private void InjetarCombustivel (int qtdCombustivel) {

            base.tanqueCombustivel = base.tanqueCombustivel - qtdCombustivel;
        }
    }
}
