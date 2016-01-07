namespace Mountain.classes.controls {
    partial class Tile {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.canvas = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(40, 40);
            this.canvas.TabIndex = 0;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
    }
}
