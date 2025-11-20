using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureCrossword
{
    public partial class Form1 : Form
    {
        private Board _board;
        public Form1()
        {
            InitializeComponent();

            Text = "PictureCrossword";
            KeyPreview = true;

            _board = new Board();
            _board.Generate(this, 215, 200);




            // 特に意味はないけど隙間がもったいないのでなんか配置しておく
            var l = new Label();
            l.Font = new Font(Font.OriginalFontName, 35);
            l.Size = new Size(195, 195);
            l.Location = new Point(15, 0);
            l.BackColor = Color.FromArgb(255, 210, 210, 210);
            l.Text = "(´・ω・｀)";
            l.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(l);
        }


        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    _board.Right();
                    break;
                case Keys.A:
                    _board.Left();
                    break;
                case Keys.W:
                    _board.Up();
                    break;
                case Keys.S:
                    _board.Down();
                    break;
                default:
                    break;
            }
        }
    }
}