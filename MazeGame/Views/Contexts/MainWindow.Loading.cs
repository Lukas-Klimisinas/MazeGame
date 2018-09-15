using System;
using System.Drawing;
using System.Windows.Forms;
using MazeGame.Controls;

namespace MazeGame.Views
{
    partial class MainWindow
    {
        private const int CtxWidth = 350;
        private const int CtxHeight = 350;
        private Font TextFont = new Font("Consolas", 18, FontStyle.Bold);

		public void InitLoadingContext()
        {
            Graphics G = this.CreateGraphics();
            Image GIF = Image.FromFile("..//../Content/LoadingCrop.gif");
            SizeF TextSize = G.MeasureString("LOADING", TextFont);

            PictureBox Spinner = new PictureBox
            {
                Location = new Point((CtxWidth - GIF.Width) / 2, (CtxHeight - Config.cCaption - GIF.Height) / 2),
                Size = new Size(GIF.Width, GIF.Height),
				Image = GIF
            };

            Label Loading = new Label
            {
				Text = "LOADING",
				Font = TextFont,
				ForeColor = Color.White,
				Location = new Point((CtxWidth - (int)Math.Ceiling(TextSize.Width)) / 2 , Spinner.Location.Y + GIF.Height + 20),
				Size = new Size((int)Math.Ceiling(TextSize.Width), (int)Math.Ceiling(TextSize.Height))
            };

            this.PanelLoading = new Panel
            {
                Name = "LoadingContext",
                Location = new Point(0, Config.cCaption),
                BackColor = Color.Transparent
            };

            this.PanelLoading.Controls.Add(Spinner);
            this.PanelLoading.Controls.Add(Loading);

            Spinner = null;
            Loading = null;
            GIF = null;
            G.Dispose();
        }

		public void SwitchToLoadingContext()
        {
            this.Size = new Size(CtxWidth, CtxHeight);
            this.MaximumSize = new Size(CtxWidth, CtxHeight);

            this.PanelLoading.Size = new Size(CtxWidth, CtxHeight - Config.cCaption);
            this.Controls.Add(this.PanelLoading);

            this.BackgroundWorker_LoadGame.RunWorkerAsync();
        }

		public void RemoveLoadingContext()
        {
            this.SuspendLayout();

            foreach (Control Item in this.Controls)
            {
                if (Item.Name.Equals("LoadingContext"))
                {
                    this.Controls.Remove(Item);
                    break;
                }
            }

            this.ResumeLayout(false);
        }
    }
}
