using Semana04.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Semana04.ViewModel
{
    public class ManCategoriaViewModel : ViewModelBase
    {
        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if (ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }

        string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if (Nombre != value)
                {
                    _Nombre = value;
                    OnPropertyChanged();
                }
            }
        }

        string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                if (Descripcion != value)
                {
                    _Descripcion = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand GrabarCommand { set; get; }

        public ICommand CerrarCommand { set; get; }

        public ManCategoriaViewModel()
        {
            GrabarCommand = new RelayCommand<Window>(
                o =>
                {
                    if (ID > 0)
                    {
                        new CategoriaModel().Actualizar(new Entity.Categoria
                        {
                            IdCategoria = ID,
                            NombreCategoria = Nombre,
                            Descripcion = Descripcion
                        });
                        o.Close();

                    }
                    else
                    {
                        new CategoriaModel().Insertar(new Entity.Categoria
                        {
                            NombreCategoria = Nombre,
                            Descripcion = Descripcion
                        });
                        // o.Close();
                        // ListaViewModel.Instance.Categorias = new Model.CategoriaModel().categorias;
                    }
                });
            CerrarCommand = new RelayCommand<Window>(
                param => Cerrar(param)
                );
        }

        private void Cerrar(Window window)
        {
            window.Close();
        }
    }
}
