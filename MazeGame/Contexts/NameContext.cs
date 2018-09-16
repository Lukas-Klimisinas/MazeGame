using System.Drawing;
using System.Windows.Forms;
using MazeGame.Controls;

namespace MazeGame.Contexts
{
    public class NameContext : Panel
    {
        private static NameContext instance = null;
        private static readonly object padlock = new object();

        private readonly int CtxWidth = 500;
        private readonly int CtxHeight = 250;

        public static NameContext Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new NameContext();
                    }

                    return instance;
                }
            }
        }

        private NameContext()
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
                Location = new Point((CtxWidth - TextSize.Width) / 2, 0)
            };

            this.Name = "NameContext";
            this.Size = new Size(CtxWidth, CtxHeight);
            this.Location = new Point((Config.MaxBounds.Width - CtxWidth) / 2, Config.LogoPositionY + Config.LogoHeight + 50);
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.FixedSingle;

            this.Controls.Add(NameLbl);
        }

        public void InsertContext(Panel Insert)
        {
            Insert.Controls.Add(this);
        }

        public void RemoveContext(Panel From)
        {
            foreach (Control Item in From.Controls)
            {
                if (Item.Name.Equals(this.Name))
                {
                    From.Controls.Remove(Item);
                    break;
                }
            }
        }
    }
}
