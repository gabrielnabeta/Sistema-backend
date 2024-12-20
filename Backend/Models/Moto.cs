namespace Backend.Models {
    public class Moto : Veiculo {

        public Moto() {

            qtdRodas = 2;
            tanqueCombustivel = 15;
        }

        public int qtdRodas { get; set; }

        public override void Acelerar() {

            InjetarCombustivel(2);
        }

        private void InjetarCombustivel(int qtdCombustivel) {

            base.tanqueCombustivel = base.tanqueCombustivel - qtdCombustivel;
        }
    }
}

