using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGame.Views
{
    partial class MainWindow
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
            this.BackgroundWorker_LoadGame = new BackgroundWorker();

            this.BackgroundWorker_LoadGame.WorkerReportsProgress = true;
            this.BackgroundWorker_LoadGame.DoWork += BackgroundWorker_LoadGame_DoWork;
            this.BackgroundWorker_LoadGame.RunWorkerCompleted += BackgroundWorker_LoadGame_RunWorkerCompleted;

            // 
            // MainWindow
            // 

            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.BackgroundImage = Image.FromFile("..//../Content/Background.png");
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;           
        }

        #endregion

        private BackgroundWorker BackgroundWorker_LoadGame;
    }
}