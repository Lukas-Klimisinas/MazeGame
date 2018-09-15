using System.Drawing;
using System.Windows.Forms;
using MazeGame.Controls;

namespace MazeGame.Views
{
    partial class MainWindow
    {
        private Rectangle MaxBounds = Screen.PrimaryScreen.Bounds;

        public void InitMainContext()
        {
            Image QuitImg = Image.FromFile("..//../Content/QuitBtn.png");
            Image Logo = Image.FromFile("..//../Content/Logo.png");

            Button Quit = new Button
            {
                Location = new Point(MaxBounds.Width - QuitImg.Width, MaxBounds.Height - QuitImg.Height),
                Size = new Size(QuitImg.Width, QuitImg.Height),
                BackgroundImage = QuitImg,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat  
            };

            Button MuteSound = new Button
            {
                Location = new Point(0, MaxBounds.Height - Config.MuteSound.Height),
                Size = new Size(Config.MuteSound.Width, Config.MuteSound.Height),
                BackgroundImage = Config.MuteSound,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };

            PictureBox PBLogo = new PictureBox
            {
                Location = new Point((MaxBounds.Width - Logo.Width) / 2, 150),
                Size = new Size(Logo.Width, Logo.Height),
                Image = Logo,
                BackColor = Color.Transparent
            };

            MuteSound.FlatAppearance.MouseDownBackColor = Color.Transparent;
            MuteSound.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Quit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Quit.FlatAppearance.MouseOverBackColor = Color.Transparent;

            Quit.MouseEnter += Button_MouseEnter;
            Quit.MouseLeave += Button_MouseLeave;
            MuteSound.MouseEnter += Button_MouseEnter;
            MuteSound.MouseLeave += Button_MouseLeave;
            Quit.Click += Quit_Click;
            MuteSound.Click += MuteSound_Click;

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
            Config.Player.PlayLooping();

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
