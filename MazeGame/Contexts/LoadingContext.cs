using System.Drawing;
using System.Windows.Forms;
using MazeGame.Controls;

namespace MazeGame.Contexts
{
    public class LoadingContext : Panel
    {
        private readonly int CtxWidth = 350;
        private readonly int CtxHeight = 350;

        public LoadingContext()
        {
            BasicController.ConstructFont();

            Image GIF = Image.FromFile("..//../Content/LoadingCrop.gif");
            Size TextSize = TextRenderer.MeasureText("LOADING", Config.TextFont);

            PictureBox Spinner = new PictureBox
            {
                Location = new Point((CtxWidth - GIF.Width) / 2, (CtxHeight - Config.cCaption - GIF.Height) / 2),
                Size = new Size(GIF.Width, GIF.Height),
                Image = GIF
            };

            Label Loading = new Label
            {
                Text = "LOADING",
                Font = Config.TextFont,
                ForeColor = Color.Purple,
                Location = new Point((CtxWidth - TextSize.Width) / 2, Spinner.Location.Y + GIF.Height + 20),
                Size = new Size(TextSize.Width, TextSize.Height)
            };

            this.Name = "LoadingContext";
            this.Location = new Point(0, Config.cCaption);
            this.BackColor = Color.Transparent;

            this.Controls.Add(Spinner);
            this.Controls.Add(Loading);

            Spinner = null;
            Loading = null;
            GIF = null;
        }

        public void LoadContext(Form Main)
        {
            Main.Size = new Size(CtxWidth, CtxHeight);
            Main.MaximumSize = new Size(CtxWidth, CtxHeight);

            this.Size = new Size(CtxWidth, CtxHeight - Config.cCaption);
            Main.Controls.Add(this);
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
    }
}
