
namespace Backend.Models {
    public class Veiculo {
        //construtor

        public Veiculo () {

            tanqueCombustivel = 40;
        }

        //atributos/propriedades
        public string marca { get; set; }

        public string modelo { get; set; }

        public string cor { get; set; }

        public string placa { get; set; }

        public int tanqueCombustivel { get; set; }


        //métodos 
        public virtual void Acelerar () {
        
            InjetarCombustivel(1);
        }

        public virtual void Frear () {

        }

        private void InjetarCombustivel(int qtdCombustivel) {

            tanqueCombustivel = tanqueCombustivel - qtdCombustivel;
        }
    }
}
