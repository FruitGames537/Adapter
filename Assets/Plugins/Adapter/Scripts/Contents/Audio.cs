using System;
using UnityEngine;

namespace Adapter.Contents
{
	[Serializable]
	public class Audio
	{
		public Audio(AudioClip audioClip) => m_AudioClip = audioClip;



		[SerializeField] private AudioClip m_AudioClip;

		public AudioClip audioClip { get => m_AudioClip; set => m_AudioClip = value; }



		public static implicit operator Audio(AudioClip audioClip) => new Audio(audioClip);
		public static implicit operator AudioClip(Audio audio) => audio.audioClip;
	}
}