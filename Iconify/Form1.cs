using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace Iconify
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // Icon size variable
            int IconSize = 0;

            // create new instance
            Random rand = new Random();

            // Colores list
            var Colores = new List<dynamic>();

            // Toggles list
            var Toggles = new List<dynamic>
            {
                metroToggle1, Brushes.White,
                metroToggle4, Brushes.Red,
                metroToggle3, Brushes.Blue,
                metroToggle6, Brushes.Yellow,
                metroToggle5, Brushes.Orange,
                metroToggle2, Brushes.Purple,
                metroToggle7, Brushes.Pink,
                metroToggle8, Brushes.Green
            };

            // Check if textbox is empty
            if (metroTextBox1.Text == "")
            {
                // Show error message
                MessageBox.Show("ERROR: you havent chosen a path");
            }
            else
            {
                // add the selected colores
                for (int i = 0; i < Toggles.Count; i = i + 2)
                {
                    // Check if toggle equals checked
                    if (Toggles[i].CheckState.ToString() == "Checked")
                    {
                        // Add color
                        Colores.Add(Toggles[i + 1]);
                    }
                }

                // Set icon size
                switch(metroTrackBar4.Value)
                {
                    case 1:
                        IconSize = 64;
                        break;
                    case 2:
                        IconSize = 129;
                        break;
                    case 3:
                        IconSize = 256;
                        break;
                }

                // Check if there are any colors are enabled
                if (Colores.Count == 0)
                {
                    // Show error message
                    MessageBox.Show("ERROR: You havent chosen a color");
                } else
                {
                    // Check if there are any shapes are enabled
                    if (metroToggle9.CheckState.ToString() == "Unchecked" && metroToggle10.CheckState.ToString() == "Unchecked" && metroToggle11.CheckState.ToString() == "Unchecked")
                    {
                        // Show error message
                        MessageBox.Show("ERROR: You have not chosen a shape");
                    } else
                    {
                        // Create new instance
                        using (Bitmap bitmap = new Bitmap(IconSize, IconSize))
                        {
                            // Create new instance
                            using (Graphics graphics = Graphics.FromImage(bitmap))
                            {
                                // For loop
                                for (int i = 0; i < metroTrackBar3.Value; i++)
                                {
                                    // Check if rectangles are enabled & check probability
                                    if (metroToggle9.CheckState.ToString() == "Checked" && rand.Next(0, metroTrackBar6.Value) == 0)
                                    {
                                        // Add rectangle
                                        graphics.FillRectangle(Colores[rand.Next(0, Colores.Count)], rand.Next(0, 300), rand.Next(0, 300), rand.Next(3, metroTrackBar1.Value), rand.Next(5, metroTrackBar1.Value));
                                    }

                                    // Check if circles are enabled & check probability
                                    if (metroToggle10.CheckState.ToString() == "Checked" && rand.Next(0, metroTrackBar5.Value) == 0)
                                    {
                                        // Add circle
                                        graphics.FillEllipse(Colores[rand.Next(0, Colores.Count)], rand.Next(0, 300), rand.Next(0, 300), rand.Next(3, metroTrackBar2.Value), rand.Next(5, metroTrackBar2.Value));
                                    }

                                    // Check if dots are enabled & check probability
                                    if (metroToggle11.CheckState.ToString() == "Checked" && rand.Next(0, metroTrackBar7.Value) == 0)
                                    {
                                        // Add dot
                                        graphics.FillRectangle(Colores[rand.Next(0, Colores.Count)], rand.Next(0, 300), rand.Next(0, 300), 3, 3);
                                    }
                                }
                            }

                            // Save icon as png file
                            bitmap.Save(metroTextBox1.Text + @"\Icon.png", ImageFormat.Png);
                        }

                        // Create new instance
                        using (FileStream stream = File.OpenWrite(metroTextBox1.Text + @"\Icon.ico"))
                        {
                            // Create new instace
                            using (Bitmap Bmap = (Bitmap)Image.FromFile(metroTextBox1.Text + @"\Icon.png"))
                            {
                                // Convert png to actual icon file
                                Icon.FromHandle(Bmap.GetHicon()).Save(stream);
                            }
                        }

                        // Delete icon png file
                        File.Delete(metroTextBox1.Text + @"\Icon.png");

                        // Show icon generated message
                        MessageBox.Show("Icon Generated");
                    }
                }
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            // Create new instance
            using (var Ofd = new FolderBrowserDialog())
            {
                // Open file dialog
                Ofd.ShowDialog();

                // Set textbox to directory path selected in file dialog
                metroTextBox1.Text = Ofd.SelectedPath;
            }
        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroToggle4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroToggle3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroToggle6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroToggle5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroToggle7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroToggle8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroToggle9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroToggle10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroTrackBar3_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroTrackBar4_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroToggle11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroTrackBar6_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroTrackBar5_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroTrackBar7_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
