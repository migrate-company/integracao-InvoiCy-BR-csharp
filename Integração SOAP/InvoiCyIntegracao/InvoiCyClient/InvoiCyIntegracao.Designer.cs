namespace InvoiCyNfeClient
{
    partial class InvoiCyIntegracao
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChaveParceiro = new System.Windows.Forms.TextBox();
            this.txtChaveComunicacao = new System.Windows.Forms.TextBox();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.txtXML = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRetMensagem = new System.Windows.Forms.TextBox();
            this.txtRetDocumento = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chave do Parceiro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chave de Comunicação";
            // 
            // txtChaveParceiro
            // 
            this.txtChaveParceiro.Location = new System.Drawing.Point(12, 44);
            this.txtChaveParceiro.Name = "txtChaveParceiro";
            this.txtChaveParceiro.Size = new System.Drawing.Size(250, 20);
            this.txtChaveParceiro.TabIndex = 2;
            // 
            // txtChaveComunicacao
            // 
            this.txtChaveComunicacao.Location = new System.Drawing.Point(285, 44);
            this.txtChaveComunicacao.Name = "txtChaveComunicacao";
            this.txtChaveComunicacao.Size = new System.Drawing.Size(260, 20);
            this.txtChaveComunicacao.TabIndex = 3;
            // 
            // btnExecutar
            // 
            this.btnExecutar.Location = new System.Drawing.Point(12, 334);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(75, 23);
            this.btnExecutar.TabIndex = 4;
            this.btnExecutar.Text = "Executar";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // txtXML
            // 
            this.txtXML.Location = new System.Drawing.Point(12, 79);
            this.txtXML.Name = "txtXML";
            this.txtXML.Size = new System.Drawing.Size(533, 240);
            this.txtXML.TabIndex = 5;
            this.txtXML.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mensagem de Retorno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Documento de retorno";
            // 
            // txtRetMensagem
            // 
            this.txtRetMensagem.Location = new System.Drawing.Point(19, 391);
            this.txtRetMensagem.Name = "txtRetMensagem";
            this.txtRetMensagem.Size = new System.Drawing.Size(526, 20);
            this.txtRetMensagem.TabIndex = 8;
            // 
            // txtRetDocumento
            // 
            this.txtRetDocumento.Location = new System.Drawing.Point(19, 440);
            this.txtRetDocumento.Name = "txtRetDocumento";
            this.txtRetDocumento.Size = new System.Drawing.Size(526, 111);
            this.txtRetDocumento.TabIndex = 9;
            this.txtRetDocumento.Text = "";
            // 
            // InvoiCyIntegracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 574);
            this.Controls.Add(this.txtRetDocumento);
            this.Controls.Add(this.txtRetMensagem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtXML);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.txtChaveComunicacao);
            this.Controls.Add(this.txtChaveParceiro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "InvoiCyIntegracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exemplo de Integração InvoiCy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChaveParceiro;
        private System.Windows.Forms.TextBox txtChaveComunicacao;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.RichTextBox txtXML;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRetMensagem;
        private System.Windows.Forms.RichTextBox txtRetDocumento;
    }
}

