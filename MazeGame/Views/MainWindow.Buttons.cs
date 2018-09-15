﻿using System.Windows.Forms;
using MazeGame.Controls;

namespace MazeGame.Views
{
    partial class MainWindow
    {
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
