﻿using SIEleccionReina.AccesoDatos;
using SIEleccionReina.Control;
using SIEleccionReina.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIEleccionReina.Formularios
{
    public partial class FormAlbumes : Form
    {
        public FormAlbumes()
        {
            InitializeComponent();
        }

        private void FRMAlbum_Load(object sender, EventArgs e)
        {
            llenarDatosCandidata();
        }

        public void llenarDatosCandidata()
        {
            DataTable tb = new DataTable();
            ClsCandidata_DB Obj_Conexion = new ClsCandidata_DB();

            tb = Obj_Conexion.ConsultarCandidatas( tipoCrud: CandidataTipoCrud.ConsultaCortaTodasCandidatasIdNombreApellido );

            //CmbCandidata.DisplayMember = "nombre + ' ' + apellido";
            //CmbCandidata.ValueMember = "id_candidata";
            //CmbCandidata.DataSource = tb;
            if (tb.Columns.Contains("nombres") && tb.Columns.Contains("apellidos"))
            {
                // Concatena 'nombre' y 'apellido' directamente en el DataTable
                tb.Columns.Add("nombre_completo", typeof(string), "nombres + ' ' + apellidos");

                // Asigna 'nombre_completo' al DisplayMember
                CmbCandidata.DisplayMember = "nombre_completo";
                CmbCandidata.ValueMember = "id_candidata";
                CmbCandidata.DataSource = tb;
            }
            else
            {
                // Manejar el caso donde las columnas no existen en el DataTable
                Console.WriteLine("Las columnas 'nombre' y 'apellido' no existen en el DataTable.");
            }
        }

        private void BTNGuardar_Click(object sender, EventArgs e)
        {
            //Validar Nombre_Album
            if (String.IsNullOrEmpty(TxtTituloAlbum.Text))
            {
                MessageBox.Show("Ingresa el campo nombre", "Administradr del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtTituloAlbum.Focus();
                return;
            }

            try
            {
                ClsAlbum candidata_Album = new ClsAlbum()
                {
                    
                    Titulo = TxtTituloAlbum.Text,
                    Id_candidata = Convert.ToInt32(CmbCandidata.SelectedValue)
                };

                ClsAlbum_DB canDB = new ClsAlbum_DB();
                canDB.Ingresar_Album(candidata_Album, 2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CmbCandidata_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            TxtTituloAlbum.Clear();
        }
    }
}
