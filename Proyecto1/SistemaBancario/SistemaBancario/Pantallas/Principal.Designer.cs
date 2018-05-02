namespace SistemaBancario.Pantallas
{
    partial class Principal
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
            this.lblcredencial = new System.Windows.Forms.Label();
            this.txtconsultar = new System.Windows.Forms.Button();
            this.txttransferencia = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblcredencial
            // 
            this.lblcredencial.AutoSize = true;
            this.lblcredencial.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcredencial.Location = new System.Drawing.Point(12, 9);
            this.lblcredencial.Name = "lblcredencial";
            this.lblcredencial.Size = new System.Drawing.Size(0, 22);
            this.lblcredencial.TabIndex = 0;
            // 
            // txtconsultar
            // 
            this.txtconsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtconsultar.Location = new System.Drawing.Point(60, 61);
            this.txtconsultar.Name = "txtconsultar";
            this.txtconsultar.Size = new System.Drawing.Size(167, 51);
            this.txtconsultar.TabIndex = 1;
            this.txtconsultar.Text = "Consultar Saldo";
            this.txtconsultar.UseVisualStyleBackColor = true;
            this.txtconsultar.Click += new System.EventHandler(this.txtconsultar_Click);
            // 
            // txttransferencia
            // 
            this.txttransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttransferencia.Location = new System.Drawing.Point(53, 143);
            this.txttransferencia.Name = "txttransferencia";
            this.txttransferencia.Size = new System.Drawing.Size(174, 64);
            this.txttransferencia.TabIndex = 2;
            this.txttransferencia.Text = "Realizar Transferencia";
            this.txttransferencia.UseVisualStyleBackColor = true;
            this.txttransferencia.Click += new System.EventHandler(this.txttransferencia_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txttransferencia);
            this.Controls.Add(this.txtconsultar);
            this.Controls.Add(this.lblcredencial);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcredencial;
        private System.Windows.Forms.Button txtconsultar;
        private System.Windows.Forms.Button txttransferencia;
        private System.Windows.Forms.Button button1;
    }
}