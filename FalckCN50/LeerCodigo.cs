﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FalckCN50Lib;

namespace FalckCN50
{
    public partial class LeerCodigo : Form
    {
        public LeerCodigo()
        {
            InitializeComponent();
            // comprobamos el estado para cargar los controles 
            if (Estado.Vigilante != null)
            {
                lblVigilante.Text = Estado.Vigilante.nombre;
            }
            if (Estado.Ronda != null)
            {
                lblRonda.Text = Estado.Ronda.nombre;
            }
            if (Estado.RondaPuntoEsperado != null)
            {
                TRondaPunto rp = Estado.RondaPuntoEsperado;
                string mens = "{1} [Edificio:{0}] [Cota: {2}] [Cubiculo: {3}]";
                mens = String.Format(mens, rp.Punto.Edificio.nombre, rp.Punto.nombre, rp.Punto.cota, rp.Punto.cubiculo);
                lblSP.Text = mens;
            }
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            LoginForm frmLogin = new LoginForm();
            frmLogin.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Lectura l = CntLecturas.ComprobarTag(txtCodigo.Text);
            LecturaForm lfrm = new LecturaForm(l);
            lfrm.Show();
            this.Close();
        }



        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                btnAceptar_Click(null, null);
            }
        }

        private void LeerCodigo_Load(object sender, EventArgs e)
        {

        }

    }
}