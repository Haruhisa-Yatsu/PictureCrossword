using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureCrossword
{
    public class PicButton : Button
    {
        /// <summary>
        /// Boardの参照
        /// </summary>
        Board _board;

        /// <summary>
        /// 横位置
        /// </summary>
        private int _x;

        /// <summary>
        /// 縦位置
        /// </summary>
        private int _y;

        /// <summary>
        /// OnOff
        /// </summary>
        private bool _enable;

        public PicButton(Board board, int rootX, int rooty, int x, int y, Size size)
        {
            SetEnable(false);

            _board = board;
            _x = x;
            _y = y;

            Location = new Point(rootX + x * size.Width, rooty + y * size.Height);
            Size = size;

            Click += ClickEvent;
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~PicButton()
        {
            /// 破棄時にはイベントを消しておく
            Click -= ClickEvent;
        }

        /// <summary>
        /// OnOffの取得
        /// </summary>
        /// <returns></returns>
        public bool GetEnable()
        {
            return _enable;
        }

        /// <summary>
        /// OnOffの設定
        /// </summary>
        /// <param name="b"></param>
        public void SetEnable(bool b)
        {
            _enable = b;
            SetBackColor(b ? Color.Black : Color.White);
        }

        /// <summary>
        /// 背景色の指定
        /// </summary>
        /// <param name="color"></param>
        public void SetBackColor(Color color)
        {
            BackColor = color;
        }

        /// <summary>
        /// クリック処理
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void ClickEvent(object o, EventArgs e)
        {
            // ボタンの反転処理
            SetEnable(!_enable);

            _board.SetSelect(_x, _y);

            // 盤面チェック
            if (_board.CheckBoard())
            {
                // クリアメッセージの表示
                _board.ShowClearMessage();
            }
        }
    }
}
