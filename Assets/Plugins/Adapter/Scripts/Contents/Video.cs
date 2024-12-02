using System;
using UnityEngine;
using UnityEngine.Video;

namespace Adapter.Contents
{
	[Serializable]
	public class Video
	{
		public Video(VideoClip videoClip) => m_VideoClip = videoClip;



		[SerializeField] private VideoClip m_VideoClip;

		public VideoClip videoClip { get => m_VideoClip; set => m_VideoClip = value; }



		public static implicit operator Video(VideoClip videoClip) => new Video(videoClip);
		public static implicit operator VideoClip(Video video) => video.videoClip;
	}
}