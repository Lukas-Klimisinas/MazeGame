using System.Drawing;
using System.Media;
using MazeGame.Contexts;

namespace MazeGame.Controls
{
    public static class Config
    {
        public static readonly int cGrip = 16;

        public static readonly int cCaption = 32;

        public static readonly int HTLEFT = 10, HTRIGHT = 11, HTTOP = 12, HTTOPLEFT = 13, HTTOPRIGHT = 14, HTBOTTOM = 15, HTBOTTOMLEFT = 16, HTBOTTOMRIGHT = 17;

        public static readonly int Rec = 10;

        public static readonly int LogoPositionY = 150;

        public static int LogoHeight;

        public static readonly string userRoot = "HKEY_CURRENT_USER";

        public static readonly string subkey = "MazeGame";

        public static readonly string keyName = userRoot + "\\" + subkey;

        public static string PlayerName = string.Empty;

        public static readonly Image MuteSound = Image.FromFile("..//../Content/Mute.png");

        public static readonly Image MutedSound = Image.FromFile("..//../Content/Muted.png");

        public static SoundPlayer Player = new SoundPlayer("..//../Content/Music_Compressed.wav");

        public static Font TextFont;

        public static Rectangle MaxBounds;

        public static bool IsSoundMuted = false;

        public static bool IsConnectedToInternet;

        public static bool InsertNameContext = false;

        public static string UniqueToken;

        #region Contexts

        public static MainContext MainCtx;
        public static NameContext NameCtx;

        #endregion
    }
}
