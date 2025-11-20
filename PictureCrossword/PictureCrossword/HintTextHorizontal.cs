using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureCrossword
{
    public class HintTextHorizontal : Label
    {

        public HintTextHorizontal(int rootX, int rooty, int y, Size size, string text)
        {
            SetText(text);
            Location = new Point(rootX - size.Width, rooty + y * size.Height);
            size.Height -= 1;
            size.Width -= 5;
            Size = size;

            Font = new Font(Font.OriginalFontName, 20);
            BackColor = Color.FromArgb(255, 210, 210, 210);
            TextAlign = ContentAlignment.MiddleRight;
        }

        public void SetText(string text)
        {
            Text = text;
        }
    }
}
