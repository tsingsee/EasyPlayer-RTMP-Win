**1. EasyPlayer_Init**
###### 接口功能
> EasyPlayer初始化

###### 请求参数
> 無
###### 返回字段
> 0，正常返回

**2. EasyPlayer_Release**
###### 接口功能
> EasyPlayer资源释放

###### 请求参数
> 無
###### 返回字段
> 無

**3. EasyPlayer_OpenStream**
###### 接口功能
> 开始进行流播放

###### 请求参数
|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|url    |ture    |string|媒体地址                          |
|hWnd    |true    |IntPtr   |窗口句柄|
|renderFormat    |true    |RENDER_FORMAT   |编码格式|
|rtpovertcp    |true    |int   |拉取流的传输模式，0=udp,1=tcp|
|username    |true(可置空)    |string   |登錄名|
|password    |true    |string   |密碼|
|callback    |true    |MediaSourceCallBack   |取流回掉|
|userPtr    |true    |IntPtr   |用戶指針|
|bHardDecode |false    |Boolean   |是否硬編碼|
###### 返回字段
> 0，正常返回

**4. EasyPlayer_CloseStream**
###### 接口功能
> 停止取流
###### 请求参数
|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|channelId    |ture    |int|通道ID，EasyPlayer_OpenStream函数返回值                          |
###### 返回字段
> 0，正常返回

**5. EasyPlayer_SetFrameCache**
###### 接口功能
> 设置当前流播放缓存帧数
###### 请求参数
|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|channelId    |ture    |int|通道ID，EasyPlayer_OpenStream函数返回值                          |
|cache    |ture    |int|缓存的视频帧数                         |
###### 返回字段
> 0，正常返回

**6. EasyPlayer_SetShownToScale**
###### 接口功能
> 播放器按比例进行显示
###### 请求参数
|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|channelId    |ture    |int|通道ID，EasyPlayer_OpenStream函数返回值                          |
|shownToScale    |ture    |int|0=整个窗口区域显示，1=按比例显示                         |
###### 返回字段
> 0，正常返回

**7. EasyPlayer_ShowStatisticalInfo**
###### 接口功能
> 设置是否显示码流信息
###### 请求参数
|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|channelId    |ture    |int|通道ID，EasyPlayer_OpenStream函数返回值                          |
|show    |ture    |int|0=不显示，1=显示                         |
###### 返回字段
> 0，正常返回

**8. EasyPlayer_PlaySound**
###### 接口功能
> 开始播放音频
###### 请求参数
|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|channelId    |ture    |int|通道ID，EasyPlayer_OpenStream函数返回值|
###### 返回字段
> 0，正常返回

**9. EasyPlayer_StopSound**
###### 接口功能
> 停止播放音频
###### 请求参数
> 無
###### 返回字段
> 0，正常返回

**10. EasyPlayer_PicShot**
###### 接口功能
> 截图
###### 请求参数
|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|channelId    |ture    |int|通道ID，EasyPlayer_OpenStream函数返回值|
|shotPath    |ture    |String|默认程序路径下shotPath文件夹|
###### 返回字段
> 0，正常返回

**11. EasyPlayer_PicShot**
###### 接口功能
> 音视频数据录制，录制格式为MP4
###### 请求参数
|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|channelId    |ture    |int|通道ID，EasyPlayer_OpenStream函数返回值|
|recordPath    |ture    |String|默认程序路径|
###### 返回字段
> 0，正常返回

**12. EasyPlayer_StopManuRecording**
###### 接口功能
> 停止录制
###### 请求参数
|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|channelId    |ture    |int|通道ID，EasyPlayer_OpenStream函数返回值|
###### 返回字段
> 0，正常返回

**13. EasyPlayer_ShowOSD**
###### 接口功能
> 附件文字显示
###### 请求参数
|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|channelId    |ture    |int|通道ID，EasyPlayer_OpenStream函数返回值|
|osdInfo    |ture    |EASY_PALYER_OSD|设置渲染区域的矩形结构体指针|
|isShow    |false    |Boolean|是否显示，默认不显示|
###### 返回字段
> 0，正常返回

**14 數據結構**
```cs
        /// <summary>
        /// 像素信息
        /// </summary>
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct tagRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        
        /// <summary>
        /// OSD 信息集合
        /// </summary>
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct EASY_PALYER_OSD
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
            public string stOSD;
            public uint alpha;        //0-255
            public uint color;        //RGB(0xf9,0xf9,0xf9)
            public uint shadowcolor;      //RGB(0x4d,0x4d,0x4d) 全为0背景透明
            public tagRECT rect;      //OSD基于图像右上角显示区域
            public int size;       //just D3D Support
        }
        
        /// <summary>
        /// 编码格式
        /// </summary>
        public enum RENDER_FORMAT
        {

            /// DISPLAY_FORMAT_YV12 -> 842094169
            DISPLAY_FORMAT_YV12 = 842094169,

            /// DISPLAY_FORMAT_YUY2 -> 844715353
            DISPLAY_FORMAT_YUY2 = 844715353,

            /// DISPLAY_FORMAT_UYVY -> 1498831189
            DISPLAY_FORMAT_UYVY = 1498831189,

            /// DISPLAY_FORMAT_A8R8G8B8 -> 21
            DISPLAY_FORMAT_A8R8G8B8 = 21,

            /// DISPLAY_FORMAT_X8R8G8B8 -> 22
            DISPLAY_FORMAT_X8R8G8B8 = 22,

            /// DISPLAY_FORMAT_RGB565 -> 23
            DISPLAY_FORMAT_RGB565 = 23,

            /// DISPLAY_FORMAT_RGB555 -> 25
            DISPLAY_FORMAT_RGB555 = 25,

            /// DISPLAY_FORMAT_RGB24_GDI -> 26
            DISPLAY_FORMAT_RGB24_GDI = 26,
        }

        /// <summary>
        /// 帧结构信息
        /// </summary>
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct EASY_FRAME_INFO
        {
            public uint codec;                  /* 音视频格式 */

            public uint type;                   /* 视频帧类型 */
            public byte fps;                    /* 视频帧率 */
            public ushort width;               /* 视频宽 */
            public ushort height;              /* 视频高 */

            public uint reserved1;         /* 保留参数1 */
            public uint reserved2;         /* 保留参数2 */

            public uint sample_rate;       /* 音频采样率 */
            public uint channels;          /* 音频声道数 */
            public uint bits_per_sample;        /* 音频采样精度 */

            public uint length;                /* 音视频帧大小 */
            public uint timestamp_usec;        /* 时间戳,微妙 */
            public uint timestamp_sec;          /* 时间戳 秒 */

            public float bitrate;                       /* 比特率 */
            public float losspacket;                    /* 丢包率 */
        }
```

**15 回調函數,幫助函數定義**
``` cs
        /// <summary>
        /// 流回调
        /// </summary>
        /// <param name="channelId">通道ID，EasyPlayer_OpenStream函数返回值.通道ID.</param>
        /// <param name="userPtr">通道指针.</param>
        /// <param name="_frameType">帧数据类型.</param>
        /// <param name="pBuf">数据指针.</param>
        /// <param name="_frameInfo">帧数据结构体.</param>
        /// <returns>System.Int32.</returns>
        public delegate int MediaSourceCallBack(int _channelId, IntPtr _channelPtr, int _frameType, IntPtr pBuf, ref EASY_FRAME_INFO _frameInfo);
        
        private int ToArgb(Color color)
          {
              int argb = color.B << 16;
              argb += color.G << 8;
              argb += color.R;
              return argb;
          }
```
