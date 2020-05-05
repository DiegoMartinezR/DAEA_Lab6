using Entity;
using Semana04.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Semana04.ViewModel
{
    public class ListaCategoriaViewModel : ViewModelBase
    {
         private static readonly ListaCategoriaViewModel _instance = new ListaCategoriaViewModel();


            public static ListaCategoriaViewModel Instance
            {
                get
                {
                    return _instance;
                }
            }

          /*  public ObservableCollection<Categoria> _Categorias;
           public ObservableCollection<Categoria> Categorias
           {
                get { return _Categorias; }
                set
                {
                    if (Categorias != value)
                    {
                        _Categorias = value;
                        OnPropertyChanged();
                    }
                }
            }*/


        public ObservableCollection<Categoria> Categorias { get; set; }

        public ICommand NuevoCommand { get; set; }

        public ICommand ConsultarCommand { get; set; }



        private ListaCategoriaViewModel()
        {
            Categorias = new Model.CategoriaModel().categorias;
            NuevoCommand = new RelayCommand<Window>(param => Abrir());
            ConsultarCommand = new RelayCommand<Window>(o => { Categorias = (new Model.CategoriaModel()).categorias; });

        }


        void Abrir()
        {
            View.ManCategoria window = new ManCategoria(new Categoria());
            window.ShowDialog();

            //Categorias = (new Model.CategoriaModel().categorias);

            //ManCategoria window = new ManCategoria(new Categoria());
           // window.Show();
        }
    }
}
