﻿namespace Logilingua_Reborn
{
    partial class Form1
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
            this.btnGenerar = new System.Windows.Forms.Button();
            this.textoOutput = new System.Windows.Forms.TextBox();
            this.Bigrama = new System.Windows.Forms.RadioButton();
            this.BigramaSeq = new System.Windows.Forms.RadioButton();
            this.BigramaSeqEst = new System.Windows.Forms.RadioButton();
            this.BigramaEst = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.WordPiedra = new System.Windows.Forms.RadioButton();
            this.WordManzana = new System.Windows.Forms.RadioButton();
            this.WordHola = new System.Windows.Forms.RadioButton();
            this.WordMama = new System.Windows.Forms.RadioButton();
            this.ChangeViewButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(493, 417);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(100, 28);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.button1_Click);
            // 
            // textoOutput
            // 
            this.textoOutput.Location = new System.Drawing.Point(404, 469);
            this.textoOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textoOutput.Multiline = true;
            this.textoOutput.Name = "textoOutput";
            this.textoOutput.Size = new System.Drawing.Size(277, 52);
            this.textoOutput.TabIndex = 1;
            // 
            // Bigrama
            // 
            this.Bigrama.AutoSize = true;
            this.Bigrama.Location = new System.Drawing.Point(4, 10);
            this.Bigrama.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Bigrama.Name = "Bigrama";
            this.Bigrama.Size = new System.Drawing.Size(81, 21);
            this.Bigrama.TabIndex = 3;
            this.Bigrama.TabStop = true;
            this.Bigrama.Text = "Bigrama";
            this.Bigrama.UseVisualStyleBackColor = true;
            // 
            // BigramaSeq
            // 
            this.BigramaSeq.AutoSize = true;
            this.BigramaSeq.Location = new System.Drawing.Point(4, 38);
            this.BigramaSeq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BigramaSeq.Name = "BigramaSeq";
            this.BigramaSeq.Size = new System.Drawing.Size(153, 21);
            this.BigramaSeq.TabIndex = 4;
            this.BigramaSeq.TabStop = true;
            this.BigramaSeq.Text = "Bigrama sequencial";
            this.BigramaSeq.UseVisualStyleBackColor = true;
            // 
            // BigramaSeqEst
            // 
            this.BigramaSeqEst.AutoSize = true;
            this.BigramaSeqEst.Location = new System.Drawing.Point(4, 95);
            this.BigramaSeqEst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BigramaSeqEst.Name = "BigramaSeqEst";
            this.BigramaSeqEst.Size = new System.Drawing.Size(248, 21);
            this.BigramaSeqEst.TabIndex = 6;
            this.BigramaSeqEst.TabStop = true;
            this.BigramaSeqEst.Text = "Bigrama sequencial con estructura";
            this.BigramaSeqEst.UseVisualStyleBackColor = true;
            // 
            // BigramaEst
            // 
            this.BigramaEst.AutoSize = true;
            this.BigramaEst.Location = new System.Drawing.Point(4, 66);
            this.BigramaEst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BigramaEst.Name = "BigramaEst";
            this.BigramaEst.Size = new System.Drawing.Size(176, 21);
            this.BigramaEst.TabIndex = 5;
            this.BigramaEst.TabStop = true;
            this.BigramaEst.Text = "Bigrama con estructura";
            this.BigramaEst.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BigramaSeqEst);
            this.panel1.Controls.Add(this.BigramaSeq);
            this.panel1.Controls.Add(this.BigramaEst);
            this.panel1.Controls.Add(this.Bigrama);
            this.panel1.Location = new System.Drawing.Point(404, 267);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 123);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.WordPiedra);
            this.panel2.Controls.Add(this.WordManzana);
            this.panel2.Controls.Add(this.WordHola);
            this.panel2.Controls.Add(this.WordMama);
            this.panel2.Location = new System.Drawing.Point(84, 71);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(111, 119);
            this.panel2.TabIndex = 8;
            // 
            // WordPiedra
            // 
            this.WordPiedra.AutoSize = true;
            this.WordPiedra.Location = new System.Drawing.Point(4, 91);
            this.WordPiedra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WordPiedra.Name = "WordPiedra";
            this.WordPiedra.Size = new System.Drawing.Size(70, 21);
            this.WordPiedra.TabIndex = 3;
            this.WordPiedra.TabStop = true;
            this.WordPiedra.Text = "Piedra";
            this.WordPiedra.UseVisualStyleBackColor = true;
            // 
            // WordManzana
            // 
            this.WordManzana.AutoSize = true;
            this.WordManzana.Location = new System.Drawing.Point(4, 63);
            this.WordManzana.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WordManzana.Name = "WordManzana";
            this.WordManzana.Size = new System.Drawing.Size(87, 21);
            this.WordManzana.TabIndex = 2;
            this.WordManzana.TabStop = true;
            this.WordManzana.Text = "Manzana";
            this.WordManzana.UseVisualStyleBackColor = true;
            // 
            // WordHola
            // 
            this.WordHola.AutoSize = true;
            this.WordHola.Location = new System.Drawing.Point(4, 34);
            this.WordHola.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WordHola.Name = "WordHola";
            this.WordHola.Size = new System.Drawing.Size(58, 21);
            this.WordHola.TabIndex = 1;
            this.WordHola.TabStop = true;
            this.WordHola.Text = "Hola";
            this.WordHola.UseVisualStyleBackColor = true;
            // 
            // WordMama
            // 
            this.WordMama.AutoSize = true;
            this.WordMama.Location = new System.Drawing.Point(4, 6);
            this.WordMama.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WordMama.Name = "WordMama";
            this.WordMama.Size = new System.Drawing.Size(67, 21);
            this.WordMama.TabIndex = 0;
            this.WordMama.TabStop = true;
            this.WordMama.Text = "Mama";
            this.WordMama.UseVisualStyleBackColor = true;
            // 
            // ChangeViewButton
            // 
            this.ChangeViewButton.Location = new System.Drawing.Point(908, 50);
            this.ChangeViewButton.Name = "ChangeViewButton";
            this.ChangeViewButton.Size = new System.Drawing.Size(104, 23);
            this.ChangeViewButton.TabIndex = 9;
            this.ChangeViewButton.Text = "ChangeView";
            this.ChangeViewButton.UseVisualStyleBackColor = true;
            this.ChangeViewButton.Click += new System.EventHandler(this.ChangeViewButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ChangeViewButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textoOutput);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TextBox textoOutput;
        private System.Windows.Forms.RadioButton Bigrama;
        private System.Windows.Forms.RadioButton BigramaSeq;
        private System.Windows.Forms.RadioButton BigramaSeqEst;
        private System.Windows.Forms.RadioButton BigramaEst;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton WordMama;
        private System.Windows.Forms.RadioButton WordPiedra;
        private System.Windows.Forms.RadioButton WordManzana;
        private System.Windows.Forms.RadioButton WordHola;
        private System.Windows.Forms.Button ChangeViewButton;
    }
}