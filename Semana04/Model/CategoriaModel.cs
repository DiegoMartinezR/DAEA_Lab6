using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana04.Model
{
    class CategoriaModel
    {
        public ObservableCollection<Categoria> categorias { get; set; }



        public bool Insertar(Categoria categoria)
        {
            return (new BCategoria()).Insert(categoria);
        }

        public bool Actualizar(Categoria categoria)
        {
            return (new BCategoria()).Actualizar(categoria);
        }

        public CategoriaModel()
        {
            var lista = (new BCategoria().Listar(0));
            categorias = new ObservableCollection<Categoria>(lista);
        }

    }
}
