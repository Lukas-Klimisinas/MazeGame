using System.Windows.Forms;
using System.Drawing;

namespace MazeGame.Classes
{
    public class CustomButton : Button
    {
        public CustomButton(Image Img)
        {
            this.BackgroundImage = Img;
            this.BackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.Size = new Size(Img.Width, Img.Height);
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;

            this.MouseEnter += Button_MouseEnter;
            this.MouseLeave += Button_MouseLeave;
        }

        private void Button_MouseLeave(object sender, System.EventArgs e)
        {
            Button Btn = (Button)sender;

            Btn.Cursor = Cursors.Default;
        }

        private void Button_MouseEnter(object sender, System.EventArgs e)
        {
            Button Btn = (Button)sender;

            Btn.Cursor = Cursors.Hand;
        }
    }
}
