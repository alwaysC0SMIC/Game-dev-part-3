namespace Game_dev_S2_project_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IbIDisplay = new Label();
            Up = new Button();
            Down = new Button();
            Right = new Button();
            Left = new Button();
            hitPointsLabel = new Label();
            PickUpLabel = new Label();
            DamageLabel = new Label();
            SuspendLayout();
            // 
            // IbIDisplay
            // 
            IbIDisplay.AutoSize = true;
            IbIDisplay.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point);
            IbIDisplay.Location = new Point(388, 160);
            IbIDisplay.Name = "IbIDisplay";
            IbIDisplay.Size = new Size(47, 12);
            IbIDisplay.TabIndex = 0;
            IbIDisplay.Text = "label1";
            IbIDisplay.Click += IbIDisplay_Click;
            // 
            // Up
            // 
            Up.Location = new Point(639, 250);
            Up.Name = "Up";
            Up.Size = new Size(75, 23);
            Up.TabIndex = 2;
            Up.Text = "Up";
            Up.UseVisualStyleBackColor = true;
            Up.Visible = false;
            Up.Click += Up_Click;
            // 
            // Down
            // 
            Down.Location = new Point(639, 292);
            Down.Name = "Down";
            Down.Size = new Size(75, 23);
            Down.TabIndex = 3;
            Down.Text = "Down";
            Down.UseVisualStyleBackColor = true;
            Down.Visible = false;
            Down.Click += Down_Click;
            // 
            // Right
            // 
            Right.Location = new Point(714, 271);
            Right.Name = "Right";
            Right.Size = new Size(75, 23);
            Right.TabIndex = 4;
            Right.Text = "Right";
            Right.UseVisualStyleBackColor = true;
            Right.Visible = false;
            Right.Click += Right_Click;
            // 
            // Left
            // 
            Left.Location = new Point(558, 271);
            Left.Name = "Left";
            Left.Size = new Size(75, 23);
            Left.TabIndex = 5;
            Left.Text = "Left";
            Left.UseVisualStyleBackColor = true;
            Left.Visible = false;
            Left.Click += Left_Click;
            // 
            // hitPointsLabel
            // 
            hitPointsLabel.AutoSize = true;
            hitPointsLabel.Location = new Point(46, 376);
            hitPointsLabel.Name = "hitPointsLabel";
            hitPointsLabel.Size = new Size(58, 15);
            hitPointsLabel.TabIndex = 6;
            hitPointsLabel.Text = "HP: 40/40";
            // 
            // PickUpLabel
            // 
            PickUpLabel.AutoSize = true;
            PickUpLabel.Location = new Point(46, 391);
            PickUpLabel.Name = "PickUpLabel";
            PickUpLabel.Size = new Size(124, 15);
            PickUpLabel.TabIndex = 7;
            PickUpLabel.Text = "no of Health Pick Ups:";
            // 
            // DamageLabel
            // 
            DamageLabel.AutoSize = true;
            DamageLabel.Location = new Point(46, 406);
            DamageLabel.Name = "DamageLabel";
            DamageLabel.Size = new Size(75, 15);
            DamageLabel.TabIndex = 8;
            DamageLabel.Text = "Status of exit";
            DamageLabel.Click += DamageLabel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DamageLabel);
            Controls.Add(PickUpLabel);
            Controls.Add(hitPointsLabel);
            Controls.Add(Left);
            Controls.Add(Right);
            Controls.Add(Down);
            Controls.Add(Up);
            Controls.Add(IbIDisplay);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IbIDisplay;
        private Button Up;
        private Button Down;
        private Button Right;
        private Button Left;
        private Label hitPointsLabel;
        private Label PickUpLabel;
        private Label DamageLabel;
    }
}