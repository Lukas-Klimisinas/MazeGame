using System.Drawing;
using System.Windows.Forms;
using MazeGame.Controls;
using MazeGame.Classes;

namespace MazeGame.Contexts
{
    public class EnterNameContext : Panel
    {
        private static EnterNameContext instance = null;
        private static readonly object padlock = new object();

        private readonly int CtxWidth = 500;
        private readonly int CtxHeight = 200;
        private TextBox NameBox;

        public static EnterNameContext Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new EnterNameContext();
                    }

                    return instance;
                }
            }
        }

        private EnterNameContext()
        {
            string Text = "ENTER YOUR NAME";
            
            Font LblFont = new Font(Config.TextFont.FontFamily, 24, FontStyle.Bold);
            Size TextSize = TextRenderer.MeasureText(Text, LblFont);

            Image StartImg = Image.FromFile("..//../Content/StartBtn.png");

            CustomButton StartBtn = new CustomButton(StartImg)
            {
                Location = new Point((CtxWidth - StartImg.Width) / 2, CtxHeight - StartImg.Height)
            };

            StartBtn.Click += StartBtn_Click;

            Label NameLbl = new Label
            {
                Text = Text,
                Size = TextSize,
                Font = LblFont,
                ForeColor = Color.Purple,
                Location = new Point((CtxWidth - TextSize.Width) / 2, 0)
            };

            NameBox = new TextBox
            {
                Location = new Point(100, NameLbl.Height + 20),
                Size = new Size(300, 40),
                BackColor = Color.DarkGray,
                BorderStyle = BorderStyle.None,
                Font = Config.TextFont,
                ForeColor = Color.Purple,
                MaxLength = 15
            };

            this.Name = "NameContext";
            this.Size = new Size(CtxWidth, CtxHeight);
            this.Location = new Point((Config.MaxBounds.Width - CtxWidth) / 2, Config.LogoPositionY + Config.LogoHeight + 50);
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.FixedSingle;

            this.Controls.Add(NameLbl);
            this.Controls.Add(StartBtn);
            this.Controls.Add(NameBox);

            LblFont = null;
            StartImg = null;
            StartBtn = null;
        }

        private void StartBtn_Click(object sender, System.EventArgs e)
        {
            string Name = NameBox.Text.ToUpper();

            if (string.IsNullOrWhiteSpace(Name))
            {
                return;
            }

            Config.PlayerName = Name;

            if (BasicController.SetNameToRegistry(Name))
            {
                RemoveContext(Config.MainCtx);
            }
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
