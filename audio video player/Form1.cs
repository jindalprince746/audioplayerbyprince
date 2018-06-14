using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace audio_video_player
{
    public partial class Form1 : Form
    {
       MyMP3Player mp3player = new MyMP3Player();
        String isplaying = "notplaying";

        
       
        
        public Form1()
        {
            
            InitializeComponent();
            button1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mp3player.close();


           
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "MP3 Files | *.mp3";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                 mp3player.open(ofd.FileName);
               

                }
                }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            if (isplaying == "playing")
            {
                mp3player.stop();

              button1.Text = mp3player.getlength().ToString();
            }
            else
            {

                mp3player.play();
            }
                isplaying = mp3player.Status();
           
           
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            isplaying = mp3player.Status();

            if (isplaying == "playing")
            {
                button3.Image = Properties.Resources.images1;
            }
            else
            {
                button3.Image = Properties.Resources.play_1173551_960_720;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            mp3player.setvolume(trackBar1.Value);
        }
    }
   
}
