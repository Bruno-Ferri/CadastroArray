using System;
//using CadastroEmVetor.Enum;
namespace CadastroEmVetor
{    public class Carro : EntidadeBase
    {
        private Marca marca { get; set; }
		private string modelo { get; set; }
		private int ano { get; set; }
        private bool excluido {get; set;}

        public Carro(int id, Marca marca, string titulo, int ano)
		{
			this.Id = id;
			this.marca = marca;
			this.modelo = titulo;
			this.ano = ano;
            this.excluido = false;
		}
        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Marca: " + this.marca + Environment.NewLine;
            retorno += "Modelo: " + this.modelo + Environment.NewLine;
            retorno += "Ano: " + this.ano + Environment.NewLine;
            retorno += "Excluido: " + this.excluido;
			return retorno;
		}

        public string retornaModelo()
		{
			return this.modelo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.excluido;
		}
         public void Excluir() {
            this.excluido = true;
        }
    }
}