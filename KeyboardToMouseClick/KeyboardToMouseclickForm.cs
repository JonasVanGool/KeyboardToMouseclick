using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardToMouseClick
{
    public partial class KeyboardToMouseclickForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */

        private bool spaceHandeld = false;

        public enum MODE
        {
            RUN,
            TEACH
        }

        MODE activeMode = MODE.TEACH;

        public List<KeyboardItem> keyboardItmes;
        String path = @"KeyboardToMouseClickList.ktm";
        Stopwatch stopWatch = new Stopwatch();
        public KeyboardToMouseclickForm()
        {
            // init program data
            keyboardItmes = new List<KeyboardItem>();
            // Load program data
            LoadData();
            InitializeComponent();

            // SetModes
            btn_RunMode.Enabled = true;
            btn_TeachMode.Enabled = false;
            btn_TeachMode.BackColor = Color.Green;
            btn_ClearAll.Enabled = true;

            // Handlers
            this.KeyDown +=Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
        }


        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;

            int keyCode = (int)e.KeyCode;
            KeyboardItem keyboardItem;
            // Stop Time
            stopWatch.Stop();

            if (activeMode == MODE.TEACH)
            {
                if (stopWatch.ElapsedMilliseconds > 3000)
                {
                    // Erase data for this key
                    // Save mouse location for key
                    try
                    {
                        keyboardItem = keyboardItmes.Single(item => item.keyCode == keyCode);
                        keyboardItem.pointList.Clear();
                        lbl_Info.Text = "Erase: " + e.KeyCode.ToString();
                    }
                    catch (Exception exeption)
                    {
                        // Key doesn't existe
                    }
                }
                else
                {
                    // Save mouse location for key
                    try
                    {
                        keyboardItem = keyboardItmes.Single(item => item.keyCode == keyCode);
                        keyboardItem.pointList.Add(new Point(x, y));
                        lbl_Info.Text = "Add: " + e.KeyCode.ToString() + " Location: " + x.ToString() + "," + y.ToString();
                    }
                    catch (Exception exeption)
                    {
                        keyboardItmes.Add(new KeyboardItem(keyCode));
                        keyboardItem = keyboardItmes.Single(item => item.keyCode == keyCode);
                        keyboardItem.pointList.Add(new Point(x, y));
                        lbl_Info.Text = "Add: " + e.KeyCode.ToString() + " Location: " + x.ToString() + "," + y.ToString();
                    }
                }
                SaveData();
            }
            else
            {
                try
                {
                    keyboardItem = keyboardItmes.Single(item => item.keyCode == keyCode);
                    foreach (Point point in keyboardItem.pointList)
                    {
                        SetCursorPos(point.x,point.y);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    }
                    lbl_Info.Text = "Run: " + e.KeyCode.ToString();
                }
                catch (Exception exeption)
                {
                    // Key doesn't existe
                }
            }

            // Reset cursor position
            SetCursorPos(this.Location.X + 2, this.Location.Y + 2);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            SetCursorPos(x, y);
            stopWatch.Reset();
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                spaceHandeld = true;
                e.SuppressKeyPress = true;
            }

            lbl_Info.Text = e.KeyCode.ToString();
            if (activeMode == MODE.TEACH)
            {
                // Start Time
                stopWatch.Start();
            }   
        }

        private void btn_TeachMode_Click(object sender, EventArgs e)
        {
            if (spaceHandeld)
            {
                spaceHandeld = false;
                return;
            }
            activeMode = MODE.TEACH;
            btn_RunMode.Enabled = true;
            btn_RunMode.BackColor = Color.Transparent;
            btn_TeachMode.Enabled = false;
            btn_TeachMode.BackColor = Color.Green;
            btn_ClearAll.Enabled = true;
        }

        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            if (spaceHandeld)
            {
                spaceHandeld = false;
                return;
            }
            keyboardItmes.Clear();
            SaveData();
            lbl_Info.Text = "Clear All";
        }

        private void btn_RunMode_Click(object sender, EventArgs e)
        {
            if (spaceHandeld)
            {
                spaceHandeld = false;
                return;
            }
            activeMode = MODE.RUN;
            btn_RunMode.Enabled = false;
            btn_RunMode.BackColor = Color.Green;
            btn_TeachMode.Enabled = true;
            btn_TeachMode.BackColor = Color.Transparent;
            btn_ClearAll.Enabled = false;
        }

        private void SaveData(){
            //serialize
            using (Stream stream = File.Open(path, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, keyboardItmes);
            }
        }

        private void LoadData()
        {
            if (File.Exists(path))
            {
                //deserialize
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    keyboardItmes = (List<KeyboardItem>)bformatter.Deserialize(stream);
                }
            }
        }
    }
}
