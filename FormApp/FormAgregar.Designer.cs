namespace FormApp
{
    partial class FormAgregar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFechaLanzamiento = new System.Windows.Forms.Label();
            this.lblCantidadCanciones = new System.Windows.Forms.Label();
            this.lblUrlImagenTapa = new System.Windows.Forms.Label();
            this.lblEstilos = new System.Windows.Forms.Label();
            this.txbTitulo = new System.Windows.Forms.TextBox();
            this.txbCantidadCanciones = new System.Windows.Forms.TextBox();
            this.txbUrlImagenTapa = new System.Windows.Forms.TextBox();
            this.lblTiposEdicion = new System.Windows.Forms.Label();
            this.cbEstilos = new System.Windows.Forms.ComboBox();
            this.cbTiposEdicion = new System.Windows.Forms.ComboBox();
            this.dtpFechaLanzamiento = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar2 = new System.Windows.Forms.Button();
            this.btnCancelar2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(108, 19);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(33, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo";
            // 
            // lblFechaLanzamiento
            // 
            this.lblFechaLanzamiento.AutoSize = true;
            this.lblFechaLanzamiento.Location = new System.Drawing.Point(41, 44);
            this.lblFechaLanzamiento.Name = "lblFechaLanzamiento";
            this.lblFechaLanzamiento.Size = new System.Drawing.Size(100, 13);
            this.lblFechaLanzamiento.TabIndex = 1;
            this.lblFechaLanzamiento.Text = "Fecha Lanzamiento";
            // 
            // lblCantidadCanciones
            // 
            this.lblCantidadCanciones.AutoSize = true;
            this.lblCantidadCanciones.Location = new System.Drawing.Point(24, 73);
            this.lblCantidadCanciones.Name = "lblCantidadCanciones";
            this.lblCantidadCanciones.Size = new System.Drawing.Size(117, 13);
            this.lblCantidadCanciones.TabIndex = 2;
            this.lblCantidadCanciones.Text = "Cantidad de Canciones";
            // 
            // lblUrlImagenTapa
            // 
            this.lblUrlImagenTapa.AutoSize = true;
            this.lblUrlImagenTapa.Location = new System.Drawing.Point(55, 100);
            this.lblUrlImagenTapa.Name = "lblUrlImagenTapa";
            this.lblUrlImagenTapa.Size = new System.Drawing.Size(86, 13);
            this.lblUrlImagenTapa.TabIndex = 3;
            this.lblUrlImagenTapa.Text = "Url Imagen Tapa";
            // 
            // lblEstilos
            // 
            this.lblEstilos.AutoSize = true;
            this.lblEstilos.Location = new System.Drawing.Point(103, 129);
            this.lblEstilos.Name = "lblEstilos";
            this.lblEstilos.Size = new System.Drawing.Size(37, 13);
            this.lblEstilos.TabIndex = 4;
            this.lblEstilos.Text = "Estilos";
            // 
            // txbTitulo
            // 
            this.txbTitulo.Location = new System.Drawing.Point(147, 12);
            this.txbTitulo.MaxLength = 50;
            this.txbTitulo.Name = "txbTitulo";
            this.txbTitulo.Size = new System.Drawing.Size(121, 20);
            this.txbTitulo.TabIndex = 5;
            // 
            // txbCantidadCanciones
            // 
            this.txbCantidadCanciones.Location = new System.Drawing.Point(147, 66);
            this.txbCantidadCanciones.MaxLength = 3;
            this.txbCantidadCanciones.Name = "txbCantidadCanciones";
            this.txbCantidadCanciones.Size = new System.Drawing.Size(121, 20);
            this.txbCantidadCanciones.TabIndex = 7;
            this.txbCantidadCanciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCantidadCanciones_KeyPress);
            // 
            // txbUrlImagenTapa
            // 
            this.txbUrlImagenTapa.Location = new System.Drawing.Point(147, 93);
            this.txbUrlImagenTapa.Name = "txbUrlImagenTapa";
            this.txbUrlImagenTapa.Size = new System.Drawing.Size(121, 20);
            this.txbUrlImagenTapa.TabIndex = 8;
            // 
            // lblTiposEdicion
            // 
            this.lblTiposEdicion.AutoSize = true;
            this.lblTiposEdicion.Location = new System.Drawing.Point(55, 158);
            this.lblTiposEdicion.Name = "lblTiposEdicion";
            this.lblTiposEdicion.Size = new System.Drawing.Size(85, 13);
            this.lblTiposEdicion.TabIndex = 10;
            this.lblTiposEdicion.Text = "Tipos de edición";
            // 
            // cbEstilos
            // 
            this.cbEstilos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstilos.FormattingEnabled = true;
            this.cbEstilos.Location = new System.Drawing.Point(147, 121);
            this.cbEstilos.Name = "cbEstilos";
            this.cbEstilos.Size = new System.Drawing.Size(121, 21);
            this.cbEstilos.TabIndex = 11;
            // 
            // cbTiposEdicion
            // 
            this.cbTiposEdicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTiposEdicion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbTiposEdicion.FormattingEnabled = true;
            this.cbTiposEdicion.Location = new System.Drawing.Point(147, 150);
            this.cbTiposEdicion.Name = "cbTiposEdicion";
            this.cbTiposEdicion.Size = new System.Drawing.Size(121, 21);
            this.cbTiposEdicion.TabIndex = 12;
            // 
            // dtpFechaLanzamiento
            // 
            this.dtpFechaLanzamiento.Location = new System.Drawing.Point(147, 38);
            this.dtpFechaLanzamiento.Name = "dtpFechaLanzamiento";
            this.dtpFechaLanzamiento.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaLanzamiento.TabIndex = 13;
            // 
            // btnAgregar2
            // 
            this.btnAgregar2.Location = new System.Drawing.Point(58, 210);
            this.btnAgregar2.Name = "btnAgregar2";
            this.btnAgregar2.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar2.TabIndex = 14;
            this.btnAgregar2.Text = "Agregar";
            this.btnAgregar2.UseVisualStyleBackColor = true;
            this.btnAgregar2.Click += new System.EventHandler(this.btnAgregar2_Click);
            // 
            // btnCancelar2
            // 
            this.btnCancelar2.Location = new System.Drawing.Point(139, 210);
            this.btnCancelar2.Name = "btnCancelar2";
            this.btnCancelar2.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar2.TabIndex = 15;
            this.btnCancelar2.Text = "Cancelar";
            this.btnCancelar2.UseVisualStyleBackColor = true;
            this.btnCancelar2.Click += new System.EventHandler(this.btnCancelar2_Click);
            // 
            // FormAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 280);
            this.Controls.Add(this.btnCancelar2);
            this.Controls.Add(this.btnAgregar2);
            this.Controls.Add(this.dtpFechaLanzamiento);
            this.Controls.Add(this.cbTiposEdicion);
            this.Controls.Add(this.cbEstilos);
            this.Controls.Add(this.lblTiposEdicion);
            this.Controls.Add(this.txbUrlImagenTapa);
            this.Controls.Add(this.txbCantidadCanciones);
            this.Controls.Add(this.txbTitulo);
            this.Controls.Add(this.lblEstilos);
            this.Controls.Add(this.lblUrlImagenTapa);
            this.Controls.Add(this.lblCantidadCanciones);
            this.Controls.Add(this.lblFechaLanzamiento);
            this.Controls.Add(this.lblTitulo);
            this.MaximumSize = new System.Drawing.Size(356, 319);
            this.MinimumSize = new System.Drawing.Size(356, 319);
            this.Name = "FormAgregar";
            this.Text = "Agregar";
            this.Load += new System.EventHandler(this.FormAgregar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFechaLanzamiento;
        private System.Windows.Forms.Label lblCantidadCanciones;
        private System.Windows.Forms.Label lblUrlImagenTapa;
        private System.Windows.Forms.Label lblEstilos;
        private System.Windows.Forms.TextBox txbTitulo;
        private System.Windows.Forms.TextBox txbCantidadCanciones;
        private System.Windows.Forms.TextBox txbUrlImagenTapa;
        private System.Windows.Forms.Label lblTiposEdicion;
        private System.Windows.Forms.ComboBox cbEstilos;
        private System.Windows.Forms.ComboBox cbTiposEdicion;
        private System.Windows.Forms.DateTimePicker dtpFechaLanzamiento;
        private System.Windows.Forms.Button btnAgregar2;
        private System.Windows.Forms.Button btnCancelar2;
    }
}