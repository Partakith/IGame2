using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGame2
{
    internal class MoveDropDrag
    {
        // Move Form
        // P/Invoke declarations to call Windows API functions.
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Constants for mouse events.
        private const int WM_NCLBUTTONDOWN = 0xA1; // Non-client area, left button down
        private const int HT_CAPTION = 0x2; // The title bar (caption) of the window

        public static void InitiateDrag(object sender, MouseEventArgs e) 
        {
            XboxController.ControllerActive = true;
            // Only handle left-clicks (MouseButtons.Left)
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture from other controls
                ReleaseCapture();

                // Send a message to the window to simulate dragging
                SendMessage(Form1.ActiveForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
