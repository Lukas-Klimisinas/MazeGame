using System.ComponentModel;
using System.Windows.Forms;
using MazeGame.Controls;
using MazeGame.Contexts;

namespace MazeGame.Views
{
    public partial class MainWindow : Form
    {
        LoadingContext LoadingCtx = new LoadingContext();

        public MainWindow()
        {
            InitializeComponent();

            this.SuspendLayout();

            LoadingCtx.LoadContext(this);

            this.ResumeLayout(false);

            this.BackgroundWorker_LoadGame.RunWorkerAsync();
        }

        /// <summary>
        /// Do all assest/function/drawing loading here.
        /// </summary>
        private void BackgroundWorker_LoadGame_DoWork(object sender, DoWorkEventArgs e)
        {
            BasicController.InitContexts();

            if (BasicController.CheckForInternetConnection())
            {
                Config.IsConnectedToInternet = true;
            }
            else
            {
                Config.IsConnectedToInternet = false;
            }

            Config.UniqueToken = BasicController.GenerateUniqueToken();
            Config.PlayerName = BasicController.GetNameFromRegistry();

            if(Config.PlayerName == null)
            {
                Config.InsertNameContext = true;
            }        

            this.BackgroundWorker_LoadGame.ReportProgress(100);
        }

        private void BackgroundWorker_LoadGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error == null)
            {                
                if (Config.InsertNameContext)
                {
                    Config.NameCtx.InsertContext(Config.MainCtx);
                }

                LoadingCtx.RemoveContext(this);
                Config.MainCtx.LoadContext(this); 
            }
        }
    }
}
