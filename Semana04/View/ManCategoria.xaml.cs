using Business;
using Entity;
using Semana04.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semana04.View
{
    /// <summary>
    /// Lógica de interacción para ManCategoria.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int ID { get; set; }
        public MainWindow(int id = 0)
        {
         
            ID = id;
            if (ID > 0)
            {
                BCategoria bcategoria = new BCategoria();
                List<Categoria> categorias = new List<Categoria>();
                categorias = bcategoria.Listar(ID);
                if (categorias.Count > 0)
                {
                    txtId.Content = categorias[0].IdCategoria;
                    txtNombre.Text = categorias[0].NombreCategoria;
                    txtDescripcion.Text = categorias[0].Descripcion;
                }
            }
        }




        private void BntGrabar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria bCategoria = null;
            bool result = true;
            try
            {
                bCategoria = new BCategoria();
                if (ID > 0)
                {
                    result = bCategoria.Actualizar(new Categoria
                    {
                        IdCategoria = ID,
                        NombreCategoria = txtNombre.Text,
                        Descripcion = txtDescripcion.Text
                    });
                }
                else
                {
                    result = bCategoria.Insert(new Categoria
                    {
                        NombreCategoria = txtNombre.Text,
                        Descripcion = txtDescripcion.Text
                    });
                }
                if (!result)
                {
                    MessageBox.Show("Comunicarse con el Administrador");
                }

                Close();
            }
            finally
            {
                bCategoria = null;
            }
        }

        private void BntCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria bCategoria = null;
            bool result = true;
            try
            {
                System.Console.WriteLine("ID =>>>>" + ID);
                bCategoria = new BCategoria();
                result = bCategoria.Eliminar(ID);
                if (!result)
                {
                    MessageBox.Show("Comunicarse con el Administrador");
                }

                Close();
            }
            finally
            {
                bCategoria = null;
            }
        }
    }
}
