using System.Drawing;
using System.Windows.Forms;
using MazeGame.Controls;

namespace MazeGame.Views
{
    partial class MainWindow
    {
        private int NameCtxWidth = 500;
        private int NameCtxHeight = 250;

        public void InitNameContext()
        {
            string Text = "ENTER YOUR NAME";

            Font LblFont = new Font(Config.TextFont.FontFamily, 24, FontStyle.Bold);
            Size TextSize = TextRenderer.MeasureText(Text, LblFont);

            Label NameLbl = new Label
            {
                Text = Text,
                Size = TextSize,
                Font = LblFont,
                ForeColor = Color.Purple,
                Location = new Point((NameCtxWidth - TextSize.Width) / 2, 0)
            };

            this.PanelName = new Panel
            {
                Name = "NameContext",
                Size = new Size(NameCtxWidth, NameCtxHeight),
                Location = new Point((MaxBounds.Width - NameCtxWidth) / 2, Config.LogoPositionY + Config.LogoHeight + 50),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.FixedSingle
            };

            this.PanelName.Controls.Add(NameLbl);
        }

        public void InsertNameIntoMainContext()
        {
            this.PanelMain.Controls.Add(this.PanelName);
        }

        public void RemoveFromMainContext()
        {
            this.SuspendLayout();

            foreach (Control Item in this.PanelMain.Controls)
            {
                if (Item.Name.Equals("NameContext"))
                {
                    this.Controls.Remove(Item);
                    break;
                }
            }

            this.ResumeLayout(false);
        }
    }
}
