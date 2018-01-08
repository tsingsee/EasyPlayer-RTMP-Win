/*
	Copyright (c) 2012-2016 EasyDarwin.ORG.  All rights reserved.
	Github: https://github.com/EasyDarwin
	WEChat: EasyDarwin
	Website: http://www.easydarwin.org
*/
#ifndef _EasyRTMP_API_H
#define _EasyRTMP_API_H
#include <string>
#include "EasyTypes.h"
using namespace std;

const int NOT_INIT = -101;//未初始化，调用EasyRTMP_Create EasyRTMP_StartStream 先
const int URL_EMPTY = -102;//URL为空
const int URL_SETUP_FAILED = -103;//RTMP Setup失败
const int RTMP_CONNECT_FAILED = -104;
const int RTMPSTREAM_CONNECT_FAILED = -105;
const int RECONNECT_SETUP_FAILED = -106;
const int RECONNECT_FAILED = -107;
const int RTMP_UNCONNECTED = -108;
const int RTMP_RECONNECTED_FAILED = -109;
const int RTMP_RECV_PARAMERROR = -110;
const int RTMP_RECONNECT_TIMEOUT = -111;
const int FRAME_TOO_LEN	= -112;
const int FRAME_ERROR = -113;//帧错误
const int SEND_SEQUNECE_FAILED = -114;
const int READ_BUFFER_FAILED = -115;
const int READ_DATA_PARAM_ERROR = -116;
const int RTMP_INSIDE_ERROR = -117;
const int RTMP_PARSE_FAILED = -118;/*RTMP帧解析失败*/

#define Easy_RTMP_Handle void*


enum MediaType
{
	e_MediaType_None = 0,
	e_MediaType_raw,
	e_MediaType_Avc,//h264 video
	e_MediaType_Aac,//aac audio
	e_MediaType_script,
	e_MediaType_Pcm,
	e_MediaType_Flv //flv tag
};

/*
	_frameType:		MediaType
	_frameInfo:		帧结构数据
	_channelPtr:		用户自定义数据
*/
typedef int (*EasyRTMPClientCallBack)(int _channelId, void* _channelPtr, int _frameType, char *pBuf, EASY_FRAME_INFO* _frameInfo);

#ifdef __cplusplus
extern "C"
{
#endif
	/* 激活EasyRTMPClient拉流库 */
#ifdef ANDROID
	Easy_API Easy_I32 EasyRTMPClient_Activate(char *license, char* userPtr);
#else
	Easy_API Easy_I32 EasyRTMPClient_Activate(char *license);
#endif

	/* 创建EasyRTMPClient句柄  返回为句柄值 */
	Easy_API Easy_RTMP_Handle EasyRTMPClient_Create();

	/* 释放EasyRTMPClient 参数为EasyRTMP句柄 */
	Easy_API int EasyRTMPClient_Release(Easy_RTMP_Handle handle);

	/* 设置数据回调 */
	Easy_API int EasyRTMPClient_SetCallback(Easy_RTMP_Handle handle, EasyRTMPClientCallBack _callback);

	/* 打开网络流(拉取或者推送) */
	Easy_API int EasyRTMPClient_StartStream(Easy_RTMP_Handle handle, int _channelid, const char* _url, void* _channelPtr);
#ifdef __cplusplus
}
#endif
#endif
