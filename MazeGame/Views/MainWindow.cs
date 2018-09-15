using System.ComponentModel;
using System.Windows.Forms;
using MazeGame.Controls;

namespace MazeGame.Views
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Do all assest/function/drawing loading here.
        /// </summary>
        private void BackgroundWorker_LoadGame_DoWork(object sender, DoWorkEventArgs e)
        {
            if (BasicController.CheckForInternetConnection())
            {
                Config.IsConnectedToInternet = true;
            }
            else
            {
                Config.IsConnectedToInternet = false;
            }

            Config.UniqueToken = BasicController.GenerateUniqueToken();

            InitMainContext();

            this.BackgroundWorker_LoadGame.ReportProgress(100);
        }

        private void BackgroundWorker_LoadGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error == null)
            {
                RemoveLoadingContext();
                SwitchToMainContext();
            }
        }
    }
}
