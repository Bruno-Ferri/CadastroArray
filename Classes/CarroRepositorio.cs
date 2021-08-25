using System;
using System.Collections.Generic;
using CadastroEmVetor.Interfaces;

namespace CadastroEmVetor
{
    public class CarroRepositorio : IRepositorio<Carro>
   {
        private List<Carro> lista = new List<Carro>();
		public void Atualiza(int id, Carro carro)
		{
			lista[id] = carro;
		}

		public void Exclui(int id)
		{
			lista[id].Excluir();
		}

		public void Insere(Carro carro)
		{
			lista.Add(carro);
		}

		public List<Carro> Listar()
		{
			return lista;
		}

		public int ProximoId()
		{
			return lista.Count;
		}

		public Carro RetornaPorId(int id)
		{
			return lista[id];
		}
	}
}