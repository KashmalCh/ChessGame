namespace ChessGame
{
    partial class ChessGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessGame));
            this.Start = new System.Windows.Forms.Button();
            this.Box = new System.Windows.Forms.FlowLayoutPanel();
            this.TurnTeller = new System.Windows.Forms.TextBox();
            this.PawnPromotion = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Rook = new System.Windows.Forms.Button();
            this.Bishop = new System.Windows.Forms.Button();
            this.Knight = new System.Windows.Forms.Button();
            this.Queen = new System.Windows.Forms.Button();
            this.PawnPromotion.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.Transparent;
            this.Start.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Start.Location = new System.Drawing.Point(12, 3);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(94, 53);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Box
            // 
            this.Box.BackColor = System.Drawing.Color.Transparent;
            this.Box.Location = new System.Drawing.Point(2, 62);
            this.Box.Name = "Box";
            this.Box.Size = new System.Drawing.Size(1368, 659);
            this.Box.TabIndex = 1;
            // 
            // TurnTeller
            // 
            this.TurnTeller.BackColor = System.Drawing.Color.SteelBlue;
            this.TurnTeller.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnTeller.ForeColor = System.Drawing.Color.SkyBlue;
            this.TurnTeller.Location = new System.Drawing.Point(1077, 3);
            this.TurnTeller.Name = "TurnTeller";
            this.TurnTeller.ReadOnly = true;
            this.TurnTeller.Size = new System.Drawing.Size(258, 55);
            this.TurnTeller.TabIndex = 1;
            this.TurnTeller.Text = "    Chess Game";
            // 
            // PawnPromotion
            // 
            this.PawnPromotion.BackColor = System.Drawing.Color.DimGray;
            this.PawnPromotion.Controls.Add(this.Queen);
            this.PawnPromotion.Controls.Add(this.Knight);
            this.PawnPromotion.Controls.Add(this.Bishop);
            this.PawnPromotion.Controls.Add(this.Rook);
            this.PawnPromotion.Location = new System.Drawing.Point(397, 3);
            this.PawnPromotion.Name = "PawnPromotion";
            this.PawnPromotion.Size = new System.Drawing.Size(403, 48);
            this.PawnPromotion.TabIndex = 3;
            this.PawnPromotion.Visible = false;
            // 
            // Rook
            // 
            this.Rook.BackColor = System.Drawing.Color.Thistle;
            this.Rook.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rook.ForeColor = System.Drawing.Color.SeaGreen;
            this.Rook.Location = new System.Drawing.Point(0, 0);
            this.Rook.Name = "Rook";
            this.Rook.Size = new System.Drawing.Size(80, 48);
            this.Rook.TabIndex = 0;
            this.Rook.Text = "Rook";
            this.Rook.UseVisualStyleBackColor = false;
            this.Rook.Click += new System.EventHandler(this.Rook_Click);
            // 
            // Bishop
            // 
            this.Bishop.BackColor = System.Drawing.Color.Plum;
            this.Bishop.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bishop.ForeColor = System.Drawing.Color.Teal;
            this.Bishop.Location = new System.Drawing.Point(110, 0);
            this.Bishop.Name = "Bishop";
            this.Bishop.Size = new System.Drawing.Size(80, 48);
            this.Bishop.TabIndex = 1;
            this.Bishop.Text = "Bishop";
            this.Bishop.UseVisualStyleBackColor = false;
            this.Bishop.Click += new System.EventHandler(this.Bishop_Click);
            // 
            // Knight
            // 
            this.Knight.BackColor = System.Drawing.Color.Thistle;
            this.Knight.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Knight.ForeColor = System.Drawing.Color.SeaGreen;
            this.Knight.Location = new System.Drawing.Point(215, 0);
            this.Knight.Name = "Knight";
            this.Knight.Size = new System.Drawing.Size(80, 48);
            this.Knight.TabIndex = 2;
            this.Knight.Text = "Knight";
            this.Knight.UseVisualStyleBackColor = false;
            this.Knight.Click += new System.EventHandler(this.Knight_Click);
            // 
            // Queen
            // 
            this.Queen.BackColor = System.Drawing.Color.Plum;
            this.Queen.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Queen.ForeColor = System.Drawing.Color.Teal;
            this.Queen.Location = new System.Drawing.Point(322, 0);
            this.Queen.Name = "Queen";
            this.Queen.Size = new System.Drawing.Size(80, 48);
            this.Queen.TabIndex = 3;
            this.Queen.Text = "Queen";
            this.Queen.UseVisualStyleBackColor = false;
            this.Queen.Click += new System.EventHandler(this.Queen_Click);
            // 
            // ChessGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1370, 711);
            this.Controls.Add(this.PawnPromotion);
            this.Controls.Add(this.TurnTeller);
            this.Controls.Add(this.Box);
            this.Controls.Add(this.Start);
            this.Name = "ChessGame";
            this.Text = "ChessGame";
            this.PawnPromotion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.FlowLayoutPanel Box;
        private System.Windows.Forms.TextBox TurnTeller;
        private System.Windows.Forms.Panel PawnPromotion;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Queen;
        private System.Windows.Forms.Button Knight;
        private System.Windows.Forms.Button Bishop;
        private System.Windows.Forms.Button Rook;
    }
}

