using EasyPlayer_RTMP.NetSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static EasyPlayer_RTMP.NetSDK.PlayerSdk;

namespace EasyPlayer_RTMP
{
    public partial class PlayerForm : Form
    {
        private PlayerSdk.MediaSourceCallBack callBack = null;
        private bool isInit = false;
        private int channelID = -1;
        private bool isTCP = false;
        private bool isHardEncode = false;
        private PlayerSdk.RENDER_FORMAT RENDER_FORMAT = PlayerSdk.RENDER_FORMAT.DISPLAY_FORMAT_RGB24_GDI;
        public PlayerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据流回调
        /// </summary>
        /// <param name="_channelId">The _channel identifier.</param>
        /// <param name="_channelPtr">The _channel PTR.</param>
        /// <param name="_frameType">Type of the _frame.</param>
        /// <param name="pBuf">The p buf.</param>
        /// <param name="_frameInfo">The _frame information.</param>
        /// <returns>System.Int32.</returns>
        private int MediaCallback(int _channelId, IntPtr _channelPtr, int _frameType, IntPtr pBuf, ref PlayerSdk.EASY_FRAME_INFO _frameInfo)
        {
            if(1 == _frameType)
            {
               //get _frameInfo.width and _frameInfo.height;
            }
            return 0;
        }

        private void PlayerBtn_Click(object sender, EventArgs e)
        {
            var isPlay = (sender as Button).Text == "播放";
            if (isPlay)
            {
                string RTSPStreamURI = this.StreamURI.Text;// "rtsp://184.72.239.149/vod/mp4://BigBuckBunny_175k.mov";
                channelID = PlayerSdk.EasyPlayer_OpenStream(RTSPStreamURI, this.panel1.Handle, RENDER_FORMAT, isTCP ? 1 : 0, "", "", callBack, IntPtr.Zero, isHardEncode);
                if (channelID > 0)
                {
                    PlayerSdk.EasyPlayer_SetFrameCache(channelID, 3);
                    this.PlayerBtn.Text = "停止";
                    this.DecodeType.Enabled = false;
                }
            }
            else
            {
                int ret = PlayerSdk.EasyPlayer_CloseStream(channelID);
                if (ret == 0)
                {
                    this.PlayerBtn.Text = "播放";
                    this.DecodeType.Enabled = true;
                    channelID = -1;
                    this.panel1.Refresh();
                }
            }
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            int nit = PlayerSdk.EasyPlayer_Init();
            if (nit > 0)
                isInit = true;
            callBack = new PlayerSdk.MediaSourceCallBack(MediaCallback);
            this.DecodeType.SelectedItem = "GDI";
            //isTCP = rtpoverType.CheckState == CheckState.Checked;
            isHardEncode = HardDecode.CheckState == CheckState.Checked;
            this.RightToLeft = RightToLeft.Inherit;
        }

        private void DecodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = (sender as ComboBox).Text;
            switch (text.ToUpper())
            {
                case "GDI":
                    RENDER_FORMAT = PlayerSdk.RENDER_FORMAT.DISPLAY_FORMAT_RGB24_GDI; break;
                case "RGB565":
                    RENDER_FORMAT = PlayerSdk.RENDER_FORMAT.DISPLAY_FORMAT_RGB565; break;
                case "YV12":
                    RENDER_FORMAT = PlayerSdk.RENDER_FORMAT.DISPLAY_FORMAT_YV12; break;
                case "YUY2":
                    RENDER_FORMAT = PlayerSdk.RENDER_FORMAT.DISPLAY_FORMAT_YUY2; break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 截图.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Snop_MenuItem_Click(object sender, EventArgs e)
        {
            if (channelID <= 0)
                return;
            int ret = PlayerSdk.EasyPlayer_PicShot(channelID);
        }

        /// <summary>
        /// 视频录制.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Recode_MenuItem_Click(object sender, EventArgs e)
        {
            if (channelID <= 0)
                return;

            var checkState = (sender as ToolStripMenuItem).CheckState;
            if (checkState == CheckState.Unchecked)
            {
                int ret = PlayerSdk.EasyPlayer_StartManuRecording(channelID);
                (sender as ToolStripMenuItem).CheckState = CheckState.Checked;
            }
            if (checkState == CheckState.Checked)
            {
                int ret = PlayerSdk.EasyPlayer_StopManuRecording(channelID);
                (sender as ToolStripMenuItem).CheckState = CheckState.Unchecked;
            }
        }

        /// <summary>
        /// OSD信息显示.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OSDShow_MenuItem_Click(object sender, EventArgs e)
        {
            if (channelID <= 0)
                return;

            var checkState = (sender as ToolStripMenuItem).CheckState;
            if (checkState == CheckState.Unchecked)
            {
                int ret = PlayerSdk.EasyPlayer_ShowStatisticalInfo(channelID, 1);
                (sender as ToolStripMenuItem).CheckState = CheckState.Checked;
            }
            if (checkState == CheckState.Checked)
            {
                int ret = PlayerSdk.EasyPlayer_ShowStatisticalInfo(channelID, 0);
                (sender as ToolStripMenuItem).CheckState = CheckState.Unchecked;
            }
        }

        /// <summary>
        /// 比例显示(仅限于软解码).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FullWindos_MenuItem_Click(object sender, EventArgs e)
        {
            if (channelID > 0)
            {
                var checkState = (sender as ToolStripMenuItem).CheckState;
                if (checkState == CheckState.Unchecked)
                {
                    int ret = PlayerSdk.EasyPlayer_SetShownToScale(channelID, 1);
                    (sender as ToolStripMenuItem).CheckState = CheckState.Checked;
                }
                if (checkState == CheckState.Checked)
                {
                    int ret = PlayerSdk.EasyPlayer_SetShownToScale(channelID, 0);
                    (sender as ToolStripMenuItem).CheckState = CheckState.Unchecked;
                }
            }
        }

        /// <summary>
        /// 播放音频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaySound_MenuItem_Click(object sender, EventArgs e)
        {
            if (channelID <= 0)
                return;

            var checkState = (sender as ToolStripMenuItem).CheckState;
            if (checkState == CheckState.Unchecked)
            {
                int ret = PlayerSdk.EasyPlayer_PlaySound(channelID);
                (sender as ToolStripMenuItem).CheckState = CheckState.Checked;
            }
            if (checkState == CheckState.Checked)
            {
                int ret = PlayerSdk.EasyPlayer_StopSound();
                (sender as ToolStripMenuItem).CheckState = CheckState.Unchecked;
            }
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isInit)
                PlayerSdk.EasyPlayer_Release();
        }

        /// <summary>
        /// 附加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddScreenFontTSMenuItem_Click(object sender, EventArgs e)
        {
            int ret = -1;
            var rect = new Rect { X = 10, Y = 10, Width = panel1.Width, Height = panel1.Height };
            var panelSize = this.panel1.ClientSize;

            EASY_PALYER_OSD fontInfo = new EASY_PALYER_OSD
            {
                alpha = 255,
                size = 35,
                color = (uint)ToArgb(Color.Red),
                shadowcolor = (uint)ToArgb(Color.Black),
                stOSD = "这是EasyPlayer-RTMP-Win播放器 \r\n的字幕叠加接口的效果！！！\r\n以\"\\r\\n\"为换行结束符号\r\n注意：每行的长度不能超过128个字节\r\n总的OSD长度不能超过1024个字节",
                rect = new tagRECT { left = (int)rect.X, top = (int)rect.Y, right = (int)rect.Width, bottom = (int)rect.Height }
            };

            var checkState = (sender as ToolStripMenuItem).CheckState;

            if (checkState == CheckState.Unchecked)
            {
                ret = PlayerSdk.EasyPlayer_ShowOSD(channelID, fontInfo);
                (sender as ToolStripMenuItem).CheckState = CheckState.Checked;
            }
            if (checkState == CheckState.Checked)
            {
                ret = PlayerSdk.EasyPlayer_ShowOSD(channelID, fontInfo, false);
                (sender as ToolStripMenuItem).CheckState = CheckState.Unchecked;
            }
        }

        /// <summary>
        /// 视频缓冲区设置.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CacheFream_ValueChanged(object sender, EventArgs e)
        {
            if (channelID <= 0)
                return;

            var cache = (sender as TrackBar).Value;
            int ret = PlayerSdk.EasyPlayer_SetFrameCache(channelID, cache);
        }

        private int ToArgb(Color color)
        {
            int argb = color.B << 16;
            argb += color.G << 8;
            argb += color.R;
            return argb;
        }
    }
}
