using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IGame2.ResizableForm;
using System.Windows.Forms;

namespace IGame2
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class ResizableForm : NativeWindow
    {
        private const int ResizeMargin = 10;  // Distance from edges to trigger resizing.
        private const int HTLeft = 10;
        private const int HTRight = 11;
        private const int HTTop = 12;
        private const int HTBottom = 13;
        private const int HTTopLeft = 14;
        private const int HTTopRight = 15;
        private const int HTBottomLeft = 16;
        private const int HTBottomRight = 17;

        private bool isResizing = false;
        private Point lastMousePosition;
        private Form form;

        public ResizableForm(Form form)
        {
            this.form = form;
            form.FormBorderStyle = FormBorderStyle.None;  // No border for resizing.
            AssignHandle(form.Handle); // Assign the form handle to this class to intercept messages.
        }

        // Override the WndProc to detect edge hit and handle resizing
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;

            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                Point clientPoint = form.PointToClient(new Point(m.LParam.ToInt32()));
                if (clientPoint.X < ResizeMargin && clientPoint.Y < ResizeMargin)
                {
                    m.Result = (IntPtr)HTTopLeft;  // Top-left corner
                }
                else if (clientPoint.X > form.ClientSize.Width - ResizeMargin && clientPoint.Y < ResizeMargin)
                {
                    m.Result = (IntPtr)HTTopRight;  // Top-right corner
                }
                else if (clientPoint.X < ResizeMargin && clientPoint.Y > form.ClientSize.Height - ResizeMargin)
                {
                    m.Result = (IntPtr)HTBottomLeft;  // Bottom-left corner
                }
                else if (clientPoint.X > form.ClientSize.Width - ResizeMargin && clientPoint.Y > form.ClientSize.Height - ResizeMargin)
                {
                    m.Result = (IntPtr)HTBottomRight;  // Bottom-right corner
                }
                else if (clientPoint.X < ResizeMargin)
                {
                    m.Result = (IntPtr)HTLeft;  // Left edge
                }
                else if (clientPoint.X > form.ClientSize.Width - ResizeMargin)
                {
                    m.Result = (IntPtr)HTRight;  // Right edge
                }
                else if (clientPoint.Y < ResizeMargin)
                {
                    m.Result = (IntPtr)HTTop;  // Top edge
                }
                else if (clientPoint.Y > form.ClientSize.Height - ResizeMargin)
                {
                    m.Result = (IntPtr)HTBottom;  // Bottom edge
                }
            }
        }

        // Mouse event handlers for resizing
        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isResizing = true;
                lastMousePosition = e.Location;
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                // Resize the form by adjusting width/height
                int dx = e.X - lastMousePosition.X;
                int dy = e.Y - lastMousePosition.Y;

                if (form.Width + dx >= form.MinimumSize.Width && form.Width + dx <= form.MaximumSize.Width)
                    form.Width += dx;

                if (form.Height + dy >= form.MinimumSize.Height && form.Height + dy <= form.MaximumSize.Height)
                    form.Height += dy;

                lastMousePosition = e.Location;
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isResizing = false;
            }
        }
    }
}