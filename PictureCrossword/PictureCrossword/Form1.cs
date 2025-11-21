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

            _board = new Board();

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

        /// <summary>
        /// 移動操作の入力を受け取るために元々の処理をオーバーライドしておく
        /// 決定操作はボタンの元々の機能を使用するため特に設定はなし
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.D:
                case Keys.Right:
                    _board.Right();
                    return true;
                case Keys.A:
                case Keys.Left:
                    _board.Left();
                    return true;
                case Keys.W:
                case Keys.Up:
                    _board.Up();
                    return true;
                case Keys.S:
                case Keys.Down:
                    _board.Down();
                    return true;
                default:
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}