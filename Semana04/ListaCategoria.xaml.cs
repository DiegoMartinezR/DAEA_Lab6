using Business;
using Entity;
using System;
using System.Windows;
using System.Windows.Controls;
using Semana04.ViewModel;

namespace Semana04
{
    public partial class ListaCategoria : Window
    {
        ListaCategoriaViewModel viewModel;
        public ListaCategoria()
        {
            InitializeComponent();
            viewModel = ListaCategoriaViewModel.Instance;
            this.DataContext = viewModel;
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }
        private void Cargar()
        {
            BCategoria bCategoria = null;
            try
            {
                bCategoria = new BCategoria();
                dgvCategoria.ItemsSource = bCategoria.Listar(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                bCategoria = null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(0);
            mainWindow.ShowDialog();
            Cargar();
        }

        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (null == item) return;
            idCategoria = Convert.ToInt32(item.IdCategoria);
            MainWindow mainWindow = new MainWindow(idCategoria);
            mainWindow.ShowDialog();
            Cargar();
        }

    }
}
