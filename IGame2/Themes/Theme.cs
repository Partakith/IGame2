using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGame2.Properties;
using IGame2;
using SharpDX.XInput;

namespace IGame2.Themes
{
    internal class Theme
    {
        public static readonly Theme Instance = new Theme();

        public static void setTheme(Color color) 
        {
            if (color == Color.Red) {

                    Form1.QcontrolBar.BackColor = Color.Red;
                    Form1.QcontrolLeft.BackgroundImage = Resources.my_retro_r;
                    Form1.QcontrolRight.BackgroundImage = Resources.my_retro_b_r;
                    Form1.QlibraryBtn.Image = Resources.button_a_red;
                    Form1.QrefreshBtn.Image = Resources.button_a_red;
                    Form1.QsettingsBtn.Image = Resources.button_a_red;
                    Form1.QaddBtn.Image = Resources.button_a_red;

                    Form1.QlibraryBtn.BackgroundImage = Resources.button_a_red;
                    Form1.QrefreshBtn.BackgroundImage = Resources.button_a_red;
                    Form1.QsettingsBtn.BackgroundImage = Resources.button_a_red;
                    Form1.QaddBtn.BackgroundImage = Resources.button_a_red;

                    Form1.QlibraryBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 53, 83);
                Form1.QrefreshBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 53, 83);
                Form1.QsettingsBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 53, 83);
                Form1.QaddBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 53, 83);

                Form1.QlibraryBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 53, 83);
                Form1.QrefreshBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 53, 83);
                Form1.QsettingsBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 53, 83);
                Form1.QaddBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 53, 83);

            }

            if (color == Color.Blue)
            {

                Form1.QcontrolBar.BackColor = Color.DodgerBlue;
                Form1.QcontrolLeft.BackgroundImage = Resources.my_retro;
                Form1.QcontrolRight.BackgroundImage = Resources.my_retro_b;
                Form1.QlibraryBtn.Image = Resources.button_a;
                Form1.QrefreshBtn.Image = Resources.button_a;
                Form1.QsettingsBtn.Image = Resources.button_a;
                Form1.QaddBtn.Image = Resources.button_a;

                Form1.QlibraryBtn.BackgroundImage = Resources.button_a;
                Form1.QrefreshBtn.BackgroundImage = Resources.button_a;
                Form1.QsettingsBtn.BackgroundImage = Resources.button_a;
                Form1.QaddBtn.BackgroundImage = Resources.button_a;

                Form1.QlibraryBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 117, 255);
                Form1.QrefreshBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 117, 255);
                Form1.QsettingsBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 117, 255);
                Form1.QaddBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 117, 255);

                Form1.QlibraryBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(53, 117, 255);
                Form1.QrefreshBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(53, 117, 255);
                Form1.QsettingsBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(53, 117, 255);
                Form1.QaddBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(53, 117, 255);

            }
        }

        public static Bitmap ApplyHueShift(Bitmap sourceImage, float hueShiftDegrees)
        {
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                // Convert hue shift to radians for matrix
                float hueShift = hueShiftDegrees * (float)(Math.PI / 180);

                // Create a hue rotation color matrix
                float cosH = (float)Math.Cos(hueShift);
                float sinH = (float)Math.Sin(hueShift);

                ColorMatrix hueMatrix = new ColorMatrix(new float[][]
                {
                new float[] { 0.213f + cosH * 0.787f - sinH * 0.213f, 0.715f - cosH * 0.715f - sinH * 0.715f, 0.072f - cosH * 0.072f + sinH * 0.928f, 0, 0 },
                new float[] { 0.213f - cosH * 0.213f + sinH * 0.143f, 0.715f + cosH * 0.285f + sinH * 0.140f, 0.072f - cosH * 0.072f - sinH * 0.283f, 0, 0 },
                new float[] { 0.213f - cosH * 0.213f - sinH * 0.787f, 0.715f - cosH * 0.715f + sinH * 0.715f, 0.072f + cosH * 0.928f + sinH * 0.072f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
                });

                // Apply the matrix
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(hueMatrix);

                    // Draw the image with the hue shift
                    g.DrawImage(sourceImage,
                                new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                                0, 0, sourceImage.Width, sourceImage.Height,
                                GraphicsUnit.Pixel,
                                attributes);
                }
            }

            return result;
        }

        public static Bitmap ApplyHueShiftWG(Bitmap sourceImage, float hueShiftDegrees)
        {
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                // Convert hue shift to radians for matrix
                float hueShift = hueShiftDegrees * (float)(Math.PI / 180);

                // Create hue rotation matrix
                float cosH = (float)Math.Cos(hueShift);
                float sinH = (float)Math.Sin(hueShift);

                ColorMatrix hueMatrix = new ColorMatrix(new float[][]
                {
            new float[] { 0.213f + cosH * 0.787f - sinH * 0.213f, 0.715f - cosH * 0.715f - sinH * 0.715f, 0.072f - cosH * 0.072f + sinH * 0.928f, 0, 0 },
            new float[] { 0.213f - cosH * 0.213f + sinH * 0.143f, 0.715f + cosH * 0.285f + sinH * 0.140f, 0.072f - cosH * 0.072f - sinH * 0.283f, 0, 0 },
            new float[] { 0.213f - cosH * 0.213f - sinH * 0.787f, 0.715f - cosH * 0.715f + sinH * 0.715f, 0.072f + cosH * 0.928f + sinH * 0.072f, 0, 0 },
            new float[] { 0, 0, 0, 1, 0 },
            new float[] { 0, 0, 0, 0, 1 }
                });

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(hueMatrix);

                    // Adjust luminance to preserve white and grayscale tones
                    attributes.SetThreshold(0.1f); // Adjust threshold as needed

                    // Draw the image with the hue shift
                    g.DrawImage(sourceImage,
                                new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                                0, 0, sourceImage.Width, sourceImage.Height,
                                GraphicsUnit.Pixel,
                                attributes);
                }
            }

            return result;
        }
    }
}
