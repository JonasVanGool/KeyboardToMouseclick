using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KeyboardToMouseClick
{
    [Serializable]
    public class KeyboardItem
    {
        public  int keyCode;
        public List<Point> pointList;

        public KeyboardItem(int keycode)
        {
            keyCode = keycode;
            pointList = new List<Point>();
        }

        public KeyboardItem()
        {
            keyCode = -1;
            pointList = new List<Point>();
        }
    }
}
