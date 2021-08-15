using System.Collections.Generic;
using DIO.Interfaces;

namespace DIO.Catalogos
{
	public class CatalogoRepositorio : IRepositorio<Catalogo>
	{
        private List<Catalogo> listaSerie = new List<Catalogo>();
		public void Atualiza(int id, Catalogo objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Catalogo objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Catalogo> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Catalogo RetornaPorId(int id)
		{
			return listaSerie[id];
		}
	}
}