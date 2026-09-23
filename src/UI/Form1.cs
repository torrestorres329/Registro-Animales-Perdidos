using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace UI
{
    public partial class Form1 : Form
    {
        private AnimalBLL animalBLL = new AnimalBLL();

        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtEspecie;
        private TextBox txtRaza;
        private TextBox txtColor;
        private TextBox txtDescripcion;
        private TextBox txtLugar;
        private TextBox txtEstado;
        private TextBox txtIdPersona;

        private DateTimePicker dtpFecha;
        private DataGridView dgvAnimales;

        private Button btnRegistrar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;

        public Form1()
        {
            InitializeComponent();
            CrearInterfaz();
            CargarAnimales();
        }

        private void CrearInterfaz()
        {
            this.Text = "Registro de Animales Perdidos";
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label titulo = new Label();
            titulo.Text = "REGISTRO DE ANIMALES PERDIDOS";
            titulo.Font = new Font("Arial", 18, FontStyle.Bold);
            titulo.Location = new Point(300, 20);
            titulo.AutoSize = true;
            this.Controls.Add(titulo);

            CrearCampo("ID:", 30, 80, out txtId);
            txtId.ReadOnly = true;

            CrearCampo("Nombre:", 30, 120, out txtNombre);
            CrearCampo("Especie:", 30, 160, out txtEspecie);
            CrearCampo("Raza:", 30, 200, out txtRaza);
            CrearCampo("Color:", 30, 240, out txtColor);

            CrearCampo("Descripción:", 30, 280, out txtDescripcion);
            CrearCampo("Lugar pérdida:", 30, 320, out txtLugar);
            CrearCampo("Estado:", 30, 360, out txtEstado);
            CrearCampo("ID Persona:", 30, 400, out txtIdPersona);

            Label lblFecha = new Label();
            lblFecha.Text = "Fecha pérdida:";
            lblFecha.Location = new Point(30, 440);
            lblFecha.AutoSize = true;
            this.Controls.Add(lblFecha);

            dtpFecha = new DateTimePicker();
            dtpFecha.Location = new Point(130, 435);
            dtpFecha.Width = 200;
            this.Controls.Add(dtpFecha);

            btnRegistrar = CrearBoton("Registrar", 30, 490);
            btnActualizar = CrearBoton("Actualizar", 130, 490);
            btnEliminar = CrearBoton("Eliminar", 230, 490);
            btnLimpiar = CrearBoton("Limpiar", 330, 490);

            btnRegistrar.Click += BtnRegistrar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;

            dgvAnimales = new DataGridView();
            dgvAnimales.Location = new Point(400, 80);
            dgvAnimales.Size = new Size(550, 400);
            dgvAnimales.ReadOnly = true;
            dgvAnimales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnimales.CellClick += DgvAnimales_CellClick;

            this.Controls.Add(dgvAnimales);
        }

        private void CrearCampo(string texto, int x, int y, out TextBox caja)
        {
            Label etiqueta = new Label();
            etiqueta.Text = texto;
            etiqueta.Location = new Point(x, y);
            etiqueta.AutoSize = true;
            this.Controls.Add(etiqueta);

            caja = new TextBox();
            caja.Location = new Point(x + 100, y - 3);
            caja.Width = 200;
            this.Controls.Add(caja);
        }

        private Button CrearBoton(string texto, int x, int y)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.Location = new Point(x, y);
            boton.Size = new Size(90, 35);
            this.Controls.Add(boton);

            return boton;
        }

        private AnimalPerdido ObtenerAnimal()
        {
            int idPersona;

            if (!int.TryParse(txtIdPersona.Text, out idPersona))
            {
                throw new Exception("El ID de persona debe ser un número.");
            }

            AnimalPerdido animal = new AnimalPerdido();

            if (int.TryParse(txtId.Text, out int id))
                animal.IdAnimal = id;

            animal.Nombre = txtNombre.Text;
            animal.Especie = txtEspecie.Text;
            animal.Raza = txtRaza.Text;
            animal.Color = txtColor.Text;
            animal.Descripcion = txtDescripcion.Text;
            animal.FechaPerdida = dtpFecha.Value;
            animal.LugarPerdida = txtLugar.Text;
            animal.Estado = txtEstado.Text;
            animal.IdPersona = idPersona;

            return animal;
        }

        private void CargarAnimales()
        {
            try
            {
                DataTable tabla = animalBLL.Consultar();
                dgvAnimales.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los animales: " + ex.Message);
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                AnimalPerdido animal = ObtenerAnimal();
                animalBLL.Registrar(animal);

                MessageBox.Show("Animal registrado correctamente.");
                Limpiar();
                CargarAnimales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                AnimalPerdido animal = ObtenerAnimal();

                if (animal.IdAnimal <= 0)
                {
                    MessageBox.Show("Seleccione un animal de la tabla.");
                    return;
                }

                animalBLL.Actualizar(animal);

                MessageBox.Show("Animal actualizado correctamente.");
                Limpiar();
                CargarAnimales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtId.Text, out int id) || id <= 0)
                {
                    MessageBox.Show("Seleccione un animal de la tabla.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de eliminar este registro?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo
                );

                if (respuesta == DialogResult.Yes)
                {
                    animalBLL.Eliminar(id);

                    MessageBox.Show("Animal eliminado correctamente.");
                    Limpiar();
                    CargarAnimales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvAnimales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAnimales.Rows[e.RowIndex];

                txtId.Text = fila.Cells["IdAnimal"].Value?.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                txtEspecie.Text = fila.Cells["Especie"].Value?.ToString();
                txtRaza.Text = fila.Cells["Raza"].Value?.ToString();
                txtColor.Text = fila.Cells["Color"].Value?.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
                txtLugar.Text = fila.Cells["LugarPerdida"].Value?.ToString();
                txtEstado.Text = fila.Cells["Estado"].Value?.ToString();
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtEspecie.Clear();
            txtRaza.Clear();
            txtColor.Clear();
            txtDescripcion.Clear();
            txtLugar.Clear();
            txtEstado.Clear();
            txtIdPersona.Clear();
            dtpFecha.Value = DateTime.Now;
        }
    }
}