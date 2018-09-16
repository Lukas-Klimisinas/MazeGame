using System.Drawing;
using System.Windows.Forms;
using MazeGame.Controls;
using MazeGame.Classes;

namespace MazeGame.Contexts
{
    public sealed class MainContext : Panel
    {
        private static MainContext instance = null;
        private static readonly object padlock = new object();

        public static MainContext Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MainContext();
                    }

                    return instance;
                }
            }
        }

        private MainContext()
        {
            Image QuitImg = Image.FromFile("..//../Content/QuitBtn.png");
            Image Logo = Image.FromFile("..//../Content/Logo.png");

            CustomButton Quit = new CustomButton(QuitImg);
            CustomButton MuteSound = new CustomButton(Config.MuteSound);

            Config.LogoHeight = Logo.Height;
            Config.MaxBounds = Screen.PrimaryScreen.Bounds;

            Quit.Location = new Point(Config.MaxBounds.Width - QuitImg.Width, Config.MaxBounds.Height - QuitImg.Height);
            MuteSound.Location = new Point(0, Config.MaxBounds.Height - Config.MuteSound.Height);

            Quit.Click += Quit_Click;
            MuteSound.Click += MuteSound_Click;

            PictureBox PBLogo = new PictureBox
            {
                Location = new Point((Config.MaxBounds.Width - Logo.Width) / 2, Config.LogoPositionY),
                Size = new Size(Logo.Width, Logo.Height),
                Image = Logo,
                BackColor = Color.Transparent
            };

            this.Name = "MainContext";
            this.Location = new Point(0, 0);
            this.Size = new Size(Config.MaxBounds.Width, Config.MaxBounds.Height);
            this.BackgroundImage = Image.FromFile("..//../Content/Background.png");

            this.Controls.Add(Quit);
            this.Controls.Add(MuteSound);
            this.Controls.Add(PBLogo);

            Quit = null;
            QuitImg = null;
            MuteSound = null;
            PBLogo = null;
            Logo = null;
        }

        public void LoadContext(Form Main)
        {
            Main.SuspendLayout();

            Main.Location = new Point(0, 0);
            Main.Bounds = Config.MaxBounds;
            Main.MaximumSize = new Size(Config.MaxBounds.Width, Config.MaxBounds.Height);
            Main.Size = new Size(Config.MaxBounds.Width, Config.MaxBounds.Height);
            Main.Width = Config.MaxBounds.Width;

            Main.Controls.Add(this);
            //Config.Player.PlayLooping();

            this.ResumeLayout(false);
        }

        public void RemoveContext(Form Main)
        {
            foreach (Control Item in Main.Controls)
            {
                if (Item.Name.Equals(this.Name))
                {
                    Main.Controls.Remove(Item);
                    break;
                }
            }
        }

        private void Quit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void MuteSound_Click(object sender, System.EventArgs e)
        {
            Config.IsSoundMuted = !Config.IsSoundMuted;
            Button Btn = (Button)sender;

            if (Config.IsSoundMuted)
            {
                Config.Player.Stop();
                Btn.BackgroundImage = Config.MutedSound;
            }
            else
            {
                Config.Player.PlayLooping();
                Btn.BackgroundImage = Config.MuteSound;
            }
        }
    }
}
