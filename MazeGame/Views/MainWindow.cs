using System.ComponentModel;
using System.Windows.Forms;

namespace MazeGame.Views
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BackgroundWorker_LoadGame_DoWork(object sender, DoWorkEventArgs e)
        {
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
