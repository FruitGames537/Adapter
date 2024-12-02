using System;
using UnityEngine;

namespace Adapter.Contents
{
	[Serializable]
	public class Image
	{
		public Image(Texture2D texture) => m_Texture = texture;
		public Image(Sprite sprite) => m_Texture = sprite.texture;



		[SerializeField] private Texture2D m_Texture;

		public Texture2D texture { get => m_Texture; set => m_Texture = value; }



		public static implicit operator Image(Texture2D texture) => new Image(texture);
		public static implicit operator Texture2D(Image image) => image.texture;

		public static implicit operator Image(Sprite sprite) => new Image(sprite);
		public static implicit operator Sprite(Image image) => Sprite.Create(image.texture, new Rect(0, 0, image.texture.width, image.texture.height), Vector2.zero);
	}
}