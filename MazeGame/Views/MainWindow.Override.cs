using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MazeGame.Controls;

namespace MazeGame.Views
{
    public partial class MainWindow
    {

        internal new Rectangle Top
        {
            get { return new Rectangle(0, 0, this.ClientSize.Width, Config.Rec); }
        }

        internal new Rectangle Left
        {
            get { return new Rectangle(0, 0, Config.Rec, this.ClientSize.Height); }
        }

        internal new Rectangle Bottom
        {
            get { return new Rectangle(0, this.ClientSize.Height - Config.Rec, this.ClientSize.Width, Config.Rec); }
        }

        internal new Rectangle Right
        {
            get { return new Rectangle(this.ClientSize.Width - Config.Rec, 0, Config.Rec, this.ClientSize.Height); }
        }

        internal Rectangle TopLeft
        {
            get { return new Rectangle(0, 0, Config.Rec, Config.Rec); }
        }

        internal Rectangle TopRight
        {
            get { return new Rectangle(this.ClientSize.Width - Config.Rec, 0, Config.Rec, Config.Rec); }
        }

        internal Rectangle BottomLeft
        {
            get { return new Rectangle(0, this.ClientSize.Height - Config.Rec, Config.Rec, Config.Rec); }
        }

        internal Rectangle BottomRight
        {
            get { return new Rectangle(this.ClientSize.Width - Config.Rec, this.ClientSize.Height - Config.Rec, Config.Rec, Config.Rec); }
        }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (cursor.Y < Config.cCaption)
                {
                    message.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
            }
        }
    }
}
