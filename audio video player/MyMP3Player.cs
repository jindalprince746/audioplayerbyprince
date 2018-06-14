using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace audio_video_player
{
    class MyMP3Player
    {
        [DllImport("winmm.dll")]

        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength,  int hwdCallBack);

        public void open(String File)
        {
            string Format = @"open ""{0}"" type MPEGVideo alias MediaFile";
            string command = string.Format(Format, File);
            mciSendString(command, null, 0, 0);
        }
        public void play()
        {
            string command = "Play MediaFile";
            mciSendString(command, null, 0, 0);
        }
        public void stop()
        {
            string command = "Stop MediaFile";
            mciSendString(command, null, 0, 0);
        }
        public string Status()
        {
            int i = 128;
            System.Text.StringBuilder stringBuilder = new StringBuilder(i);
            mciSendString("status MediaFile mode", stringBuilder, i, 0);
            return stringBuilder.ToString();
        }
        public void close()
        {
            string command = "close MediaFile";
            mciSendString(command, null, 0, 0);
        }
        public void setvolume(int value)
        {
            string volume = "setaudio MediaFile volume to " + value;
            mciSendString(volume, null, 0, 0);
        }
        public int getlength()
        {
            StringBuilder lengthBuf = new StringBuilder(32);
            mciSendString("status wave length", lengthBuf, lengthBuf.Capacity, 0);

            int length = 0;
            int.TryParse(lengthBuf.ToString(), out length);

            return length;
        }
       
    }
}
