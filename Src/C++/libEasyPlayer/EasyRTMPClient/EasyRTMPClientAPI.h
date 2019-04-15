/*
	Copyright (c) 2012-2016 EasyDarwin.ORG.  All rights reserved.
	Github: https://github.com/EasyDarwin
	WEChat: EasyDarwin
	Website: http://www.easydarwin.org
*/
#ifndef _EasyRTMP_API_H
#define _EasyRTMP_API_H

#include "EasyTypes.h"

#define	RTMP_PROG_NAME	"libEasyRTMPClient v3.0.19.0415"

enum ErrorType
{
    NOT_INIT = -101,
    URL_EMPTY = -102,
    URL_SETUP_FAILED = -103,
    RTMP_CONNECT_FAILED = -104,
    RTMPSTREAM_CONNECT_FAILED = -105,
    RECONNECT_SETUP_FAILED = -106,
    RECONNECT_FAILED = -107,
    RTMP_UNCONNECTED = -108,
    RTMP_RECONNECTED_FAILED = -109,
    RTMP_RECV_PARAMERROR = -110,
    RTMP_RECONNECT_TIMEOUT = -111,
    FRAME_TOO_LEN	= -112,
    FRAME_ERROR = -113,
    SEND_SEQUNECE_FAILED = -114,
    READ_BUFFER_FAILED = -115,
    READ_DATA_PARAM_ERROR = -116,
    RTMP_INSIDE_ERROR = -117,
    RTMP_PARSE_FAILED = -118
};

enum MediaType
{
	e_MediaType_None = 0,
	e_MediaType_raw,
	e_MediaType_Avc,	//Video
	e_MediaType_Aac,	//Audio
	e_MediaType_script,
	e_MediaType_Pcm,
	e_MediaType_Flv		//flv tag
};

typedef struct __EasyRTMPClientParams_T{
    bool reconnect; //whether reconnet
}EasyRTMPClientParams;

typedef int (*EasyRTMPClientCallBack)(int _channelId, void* _channelPtr, int _frameType, char *pBuf, EASY_FRAME_INFO* _frameInfo);

#ifdef __cplusplus
extern "C"
{
#endif
	/* Active SDK */
#ifdef ANDROID
	Easy_API Easy_I32 EasyRTMPClient_Activate(char *license, char* userPtr);
#else
	Easy_API Easy_I32 EasyRTMPClient_Activate(char *license);
#endif

	/* Create Instance */
	Easy_API Easy_Handle EasyRTMPClient_Create();

	/* Release Instance */
	Easy_API int EasyRTMPClient_Release(Easy_Handle handle);

	/* Set Event&Data Callback */
	Easy_API int EasyRTMPClient_SetCallback(Easy_Handle handle, EasyRTMPClientCallBack _callback);

    Easy_API int EasyRTMPClient_SetParams(Easy_Handle handle, EasyRTMPClientParams* param);

	/* Start Streaming */
	Easy_API int EasyRTMPClient_StartStream(Easy_Handle handle, int _channelid, const char* _url, void* _channelPtr);
#ifdef __cplusplus
}
#endif
#endif
