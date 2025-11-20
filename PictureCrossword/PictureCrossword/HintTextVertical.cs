using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureCrossword
{
    public class HintTextVertical : Label
    {
        public HintTextVertical(int rootX, int rootY, int x, Size size, string text)
        {
            SetText(text);
            this.Location = new Point(rootX + x * size.Width, rootY - size.Height);
            size.Height -= 5;
            size.Width -= 1;
            Size = size;

            Font = new Font(Font.OriginalFontName, 20);

            BackColor = Color.FromArgb(255, 210, 210, 210);

            TextAlign = ContentAlignment.BottomCenter;
            AutoSize = false;
        }

        public void SetText(string text)
        {
            Text = text;
        }
    }
}
