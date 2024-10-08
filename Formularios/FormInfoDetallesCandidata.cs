﻿using SIEleccionReina.Control;
using SIEleccionReina.Entidades;
using SIEleccionReina.Properties;
using System;
using System.Windows.Forms;

namespace SIEleccionReina.Formularios
{
    public partial class FormInfoDetallesCandidata : Form
    {
        private SIEleccionReinaController controlador;
        private int indexCandidata = 0;

        public FormInfoDetallesCandidata( int indexCandidata )
        {
            InitializeComponent();
            controlador = SIEleccionReinaController.Instance;
            this.indexCandidata = indexCandidata;
            this.Icon = Resources.SIER_Icon_Alpha;
        }

        private void FormInfoDetallesCandidata_Load( object sender, EventArgs e )
        {
            MostrarInfoCandidata();

            if ( indexCandidata == 0 )
                BtnAtras.Enabled = false;

            if ( indexCandidata == controlador.ListaCandidatas.Count - 1 )
                BtnSiguiente.Enabled = false;
        }

        private void BTNVolverAlbum_Click( object sender, EventArgs e ) => this.Close();

        private void BtnAtras_Click( object sender, EventArgs e )
        {
            if ( !BtnSiguiente.Enabled )
                BtnSiguiente.Enabled = true;

            indexCandidata--;
            MostrarInfoCandidata();

            if ( indexCandidata == 0 )
                BtnAtras.Enabled = false;
        }

        private void BtnSiguiente_Click( object sender, EventArgs e )
        {
            if ( !BtnAtras.Enabled )
                BtnAtras.Enabled = true;

            indexCandidata++;
            MostrarInfoCandidata();

            if ( indexCandidata == controlador.ListaCandidatas.Count - 1 )
                BtnSiguiente.Enabled = false;
        }

        private void MostrarInfoCandidata()
        {
            ClsCandidata candidata = controlador.ListaCandidatas[ indexCandidata ];
            LblNmbCandidata.Text = $"{candidata.Nombres} {candidata.Apellidos}";
            lblEdad.Text = $"Edad: {candidata.Edad} años";
            lblCarrera.Text = $"Carrera: { controlador.CarrerasDisponibles[ candidata.CarreraId ] }";
            lblSemestre.Text = $"Semestre: {candidata.Semestre}";
            lblInteresesDato.Text = $"Sus intereses son {candidata.Intereses}";
            lblHabilidadesDato.Text = $"Sus habilidades son {candidata.Habilidades}";
            lblAspiracionesDato.Text = $"Sus aspiraciones son {candidata.Aspiraciones}";
            PBOXImagenCandidata.Image = controlador.Base64ToImage( candidata.Foto );
        }
    }
}
