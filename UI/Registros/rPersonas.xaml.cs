using Persona2.BLL;
using Persona2.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Persona2.UI.Registros
{
    /// <summary>
    /// Interaction logic for rPersonas.xaml
    /// </summary>
    public partial class rPersonas : Window
    {
        public rPersonas()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
        }

        private Personas LlenaClase()
        {
            Personas persona = new Personas();
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                IdTextBox.Text = "0";

            }
            else
                persona.Nombre = NombreTextBox.Text;
            return persona;
        }

        private void LlenaCampo(Personas persona)
        {

            IdTextBox.Text = Convert.ToString(persona.PersonaId);
            NombreTextBox.Text = persona.Nombre;
        }
        private bool ExisteEnDb()
        {
            Personas persona = PersonasBLL.Buscar(int.Parse(IdTextBox.Text));
            return (persona != null);
        }
        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                MessageBox.Show("el campo Nombre no puede esta vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            return paso;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Personas persona;
            if (!Validar())
                return;

            persona = LlenaClase();
            if (string.IsNullOrEmpty(IdTextBox.Text) || IdTextBox.Text == "0")
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteEnDb())
                {
                    MessageBox.Show("No se puede modificar alguien que no existe");
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }

            if (paso)
            {
                MessageBox.Show("Guardado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Guardado");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);

            if (PersonasBLL.Eliminar(id))
            {
                
                Limpiar();
            }
            else
            {
                MessageBox.Show("No Eliminado!!!");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);
            Personas persona = new Personas();
            Limpiar();
            persona = PersonasBLL.Buscar(id);
            if (persona != null)
            {

                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("No encontrado!!!");
            }
        }
    }
}
