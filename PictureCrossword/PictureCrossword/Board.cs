using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureCrossword
{
    public class Board
    {
        /// <summary>
        /// フォーム
        /// </summary>
        private Form1 _form1;

        /// <summary>
        /// 盤面に並べるボタンたち
        /// </summary>
        private PicButton[] _buttons;

        /// <summary>
        /// 盤面横幅
        /// </summary>
        public const int BOARD_WIDTH = 10;

        /// <summary>
        /// 盤面縦
        /// </summary>
        public const int BOARD_HEIGHT = 10;

        /// <summary>
        /// マス 横幅
        /// </summary>
        private const int CELL_WIDTH = 30;

        /// <summary>
        /// マス 縦
        /// </summary>
        private const int CELL_HEIGHT = 30;

        /// <summary>
        /// 現在選択しているボタンの位置 横
        /// </summary>
        private int _selectX = 0;
        /// <summary>
        /// 現在選択しているボタンの位置 縦
        /// </summary>
        private int _selectY = 0;

        /// <summary>
        /// 答えのデータ
        /// </summary>
        private int[,] _answerData = new int[BOARD_HEIGHT, BOARD_WIDTH]
        {
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,1,1,1,1},
            {0,0,1,1,1,1,0,0,1,1},
            {0,0,1,1,0,0,1,1,1,1},
            {0,0,1,1,1,1,0,0,1,1},
            {0,0,1,1,0,0,0,0,1,1},
            {0,0,1,1,0,0,0,0,1,1},
            {0,1,1,1,0,0,0,1,1,1},
            {1,1,1,1,0,0,1,1,1,1},
            {0,1,1,0,0,0,0,1,1,0},
        };

        /// <summary>
        /// 生成処理 (この関数を呼ばないと盤面が表示されない、絶対に呼ぶこと)
        /// </summary>
        /// <param name="form1">Form</param>
        /// <param name="rootX">生成位置横</param>
        /// <param name="rootY">生成位置縦</param>
        public void Generate(Form1 form1, int rootX, int rootY)
        {
            _form1 = form1;

            GenerateBoard(rootX, rootY);
            GenerateHintHorizontal(rootX, rootY);
            GenerateHintVertical(rootX, rootY);

            _form1.Size = new Size(rootX + CELL_WIDTH * (BOARD_WIDTH + 1), rootY + CELL_HEIGHT * (BOARD_HEIGHT + 1) + SystemInformation.CaptionHeight);
        }

        /// <summary>
        /// 垂直ヒント生成処理
        /// </summary>
        /// <param name="rootX"></param>
        /// <param name="rootY"></param>
        private void GenerateHintVertical(int rootX, int rootY)
        {
            for (int i = 0; i < BOARD_WIDTH; i++)
            {
                HintTextHorizontal hintV = new HintTextHorizontal(rootX, rootY, i, new Size(CELL_WIDTH, 200), GetHintTextVertical(i));
                _form1.Controls.Add(hintV);
            }
        }

        /// <summary>
        /// 水平ヒント生成処理
        /// </summary>
        /// <param name="rootX"></param>
        /// <param name="rootY"></param>
        private void GenerateHintHorizontal(int rootX, int rootY)
        {
            for (int i = 0; i < BOARD_HEIGHT; i++)
            {
                HintTextVertical hint = new HintTextVertical(rootX, rootY, i, new Size(200, CELL_HEIGHT), GetHintTextHorizontal(i));
                _form1.Controls.Add(hint);
            }
        }

        /// <summary>
        /// 盤面の生成処理
        /// </summary>
        /// <param name="rootX"></param>
        /// <param name="rootY"></param>
        private void GenerateBoard(int rootX, int rootY)
        {
            _buttons = new PicButton[BOARD_WIDTH * BOARD_HEIGHT];
            for (int i = 0; i < BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < BOARD_WIDTH; j++)
                {
                    PicButton picButton = new PicButton(this, rootX, rootY, i, j, new Size(CELL_WIDTH, CELL_HEIGHT));

                    _form1.Controls.Add(picButton);
                    _buttons[BOARD_HEIGHT * i + j] = picButton;
                }
            }
        }

        /// <summary>
        /// クリアメッセージ表示
        /// </summary>
        public void ShowClearMessage()
        {
            MessageBox.Show("おめでとー＼(´・ω・｀)ノ", "完成！");
        }

        /// <summary>
        /// ヒントの数列を生成 横
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public string GetHintTextHorizontal(int y)
        {
            string ret = "";
            string delimiter = "  ";
            int count = 0;
            bool first = true;
            for (int i = 0; i < BOARD_WIDTH; i++)
            {
                if (_answerData[y, i] == 0)
                {
                    if (count > 0)
                    {
                        if (!first)
                        {
                            ret += delimiter;
                        }
                        ret += $"{count}";
                        count = 0;
                        first = false;
                    }
                }
                else
                {
                    count++;
                }
            }
            if (count != 0)
            {
                if (!first)
                {
                    ret += delimiter;
                }
                ret += $"{count}";
            }

            if (first && count == 0)
            {
                return "0";
            }
            return ret;
        }

        /// <summary>
        /// ヒントの数列を生成 縦
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public string GetHintTextVertical(int x)
        {
            string ret = "";
            string delimiter = "\n";
            int count = 0;
            bool first = true;
            for (int i = 0; i < BOARD_HEIGHT; i++)
            {
                if (_answerData[i, x] == 0)
                {
                    if (count > 0)
                    {
                        if (!first)
                        {
                            ret += delimiter;
                        }
                        ret += $"{count}";
                        count = 0;
                        first = false;
                    }
                }
                else
                {
                    count++;
                }
            }
            if (count != 0)
            {
                if (!first)
                {
                    ret += delimiter;
                }
                ret += $"{count}";
            }

            if (first && count == 0)
            {
                return "0";
            }

            return ret;
        }

        /// <summary>
        /// 盤面と答えが一致していたらTrueを返す
        /// </summary>
        /// <returns></returns>
        public bool CheckBoard()
        {
            for (int i = 0; i < BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < BOARD_WIDTH; j++)
                {
                    PicButton b = GetButton(j, i);

                    var l = b.GetEnable() ? 1 : 0;
                    var r = _answerData[i, j];
                    if (l != r)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 指定された座標のボタンを返す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PicButton GetButton(int x, int y)
        {
            return _buttons[y * BOARD_WIDTH + x];
        }

        /// <summary>
        /// カーソルの右移動
        /// </summary>
        public void Right()
        {
            _selectX++;
            Select(_selectX, _selectY);
        }
        /// <summary>
        /// カーソルの左移動
        /// </summary>
        public void Left()
        {
            _selectX--;
            Select(_selectX, _selectY);
        }
        /// <summary>
        /// カーソルの上移動
        /// </summary>
        public void Up()
        {
            _selectY++;
            Select(_selectX, _selectY);
        }
        /// <summary>
        /// カーソルの下移動
        /// </summary>
        public void Down()
        {
            _selectY--;
            Select(_selectX, _selectY);
        }

        /// <summary>
        /// 指定した座標にカーソルを設定する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetSelect(int x, int y)
        {
            _selectX = x;
            _selectY = y;
        }

        /// <summary>
        /// 指定した座標を選択状態にする
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Select(int x, int y)
        {
            if (_selectY < 0) _selectY = 0;
            if (_selectX < 0) _selectX = 0;
            if (_selectY >= BOARD_HEIGHT) _selectY = BOARD_HEIGHT - 1;
            if (_selectX >= BOARD_WIDTH) _selectX = BOARD_WIDTH - 1;
            GetButton(_selectX, _selectY).Select();
        }
    }
}