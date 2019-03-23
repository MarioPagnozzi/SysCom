namespace SYSCom
{
    partial class frm_Inicial
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_Hora = new System.Windows.Forms.Label();
            this.lbl_DiaSemana = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_DiaSemana);
            this.panel2.Controls.Add(this.lbl_Hora);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(943, 510);
            this.panel2.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_Hora
            // 
            this.lbl_Hora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Hora.AutoSize = true;
            this.lbl_Hora.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Hora.Location = new System.Drawing.Point(407, 181);
            this.lbl_Hora.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbl_Hora.Name = "lbl_Hora";
            this.lbl_Hora.Size = new System.Drawing.Size(494, 146);
            this.lbl_Hora.TabIndex = 0;
            this.lbl_Hora.Text = "00:00:00";
            // 
            // lbl_DiaSemana
            // 
            this.lbl_DiaSemana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DiaSemana.AutoSize = true;
            this.lbl_DiaSemana.Font = new System.Drawing.Font("Calibri", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DiaSemana.ForeColor = System.Drawing.Color.Sienna;
            this.lbl_DiaSemana.Location = new System.Drawing.Point(380, 327);
            this.lbl_DiaSemana.Name = "lbl_DiaSemana";
            this.lbl_DiaSemana.Size = new System.Drawing.Size(551, 46);
            this.lbl_DiaSemana.TabIndex = 1;
            this.lbl_DiaSemana.Text = "Sexta-Feira, 22 de janeiro de 2019";
            // 
            // frm_Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 510);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Inicial";
            this.Text = "frm_Inicial";
            this.Load += new System.EventHandler(this.frm_Inicial_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_DiaSemana;
        private System.Windows.Forms.Label lbl_Hora;
    }
}