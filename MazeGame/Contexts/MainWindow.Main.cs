using System.Drawing;
using System.Windows.Forms;
using MazeGame.Controls;
using MazeGame.Classes;

namespace MazeGame.Views
{
    partial class MainWindow
    {
        private Rectangle MaxBounds = Screen.PrimaryScreen.Bounds;

        public void InitMainContext()
        {
            Image QuitImg = Image.FromFile("..//../Content/QuitBtn.png");
            Image Logo = Image.FromFile("..//../Content/Logo.png");

            CustomButton Quit = new CustomButton(QuitImg);
            CustomButton MuteSound = new CustomButton(Config.MuteSound);

            Config.LogoHeight = Logo.Height;
            Config.MaxBounds = MaxBounds;

            Quit.Location = new Point(MaxBounds.Width - QuitImg.Width, MaxBounds.Height - QuitImg.Height);
            MuteSound.Location = new Point(0, MaxBounds.Height - Config.MuteSound.Height);

            Quit.Click += Quit_Click;
            MuteSound.Click += MuteSound_Click;

            PictureBox PBLogo = new PictureBox
            {
                Location = new Point((MaxBounds.Width - Logo.Width) / 2, Config.LogoPositionY),
                Size = new Size(Logo.Width, Logo.Height),
                Image = Logo,
                BackColor = Color.Transparent
            };

            this.PanelMain = new Panel
            {
                Name = "MainContext",
                Location = new Point(0, 0),
                Size = new Size(MaxBounds.Width, MaxBounds.Height),
                BackgroundImage = Image.FromFile("..//../Content/Background.png")
            };

            this.PanelMain.Controls.Add(Quit);
            this.PanelMain.Controls.Add(MuteSound);
            this.PanelMain.Controls.Add(PBLogo);

            Quit = null;
            QuitImg = null;
            MuteSound = null;
            PBLogo = null;
            Logo = null;
        }

        public void SwitchToMainContext()
        {
            this.SuspendLayout();

            this.Location = new Point(0, 0);
            this.Bounds = MaxBounds;
            this.MaximumSize = new Size(MaxBounds.Width, MaxBounds.Height);
            this.Size = new Size(MaxBounds.Width, MaxBounds.Height);
            this.Width = MaxBounds.Width;
            
            this.Controls.Add(this.PanelMain);
            //Config.Player.PlayLooping();

            this.ResumeLayout(false);
        }

        public void RemoveMainContext()
        {
            this.SuspendLayout();

            foreach (Control Item in this.Controls)
            {
                if (Item.Name.Equals("MainContext"))
                {
                    this.Controls.Remove(Item);
                    break;
                }
            }

            this.ResumeLayout(false);
        }
    }
}
