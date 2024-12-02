using System;
using UnityEngine;

namespace Adapter.Containers
{
	[Serializable]
	public struct Variation<T1, T2>
	{
		private Variation(T1 firstValue, T2 secondValue, VariationType variation, Type type)
		{
			if (typeof(T1) == typeof(T2))
				throw new ArgumentException("First and second types are no different");
			m_FirstValue = firstValue;
			m_SecondValue = secondValue;
			m_Variation = variation;
			m_Type = type;
		}
		public Variation(T1 value) : this(value, default, VariationType.First, typeof(T1)) { }
		public Variation(T2 value) : this(default, value, VariationType.Second, typeof(T2)) { }



		[SerializeField] private T1 m_FirstValue;
		[SerializeField] private T2 m_SecondValue;

		[SerializeField] private VariationType m_Variation;
		[SerializeField] private Type m_Type;

		public T1 firstValue
		{
			get
			{
				if (m_Variation is VariationType.First)
					return m_FirstValue;
				return default;
			}
			set
			{
				m_FirstValue = value;
				m_SecondValue = default;
				m_Variation = VariationType.First;
				m_Type = typeof(T1);
			}
		}
		public T2 secondValue
		{
			get
			{
				if (m_Variation is VariationType.Second)
					return m_SecondValue;
				return default;
			}
			set
			{
				m_FirstValue = default;
				m_SecondValue = value;
				m_Variation = VariationType.Second;
				m_Type = typeof(T2);
			}
		}

		public VariationType variation => m_Variation;
		public Type type => m_Type;

		public object value
		{
			get
			{
				if (variation is VariationType.First)
					return m_FirstValue;
				else if (variation is VariationType.Second)
					return m_SecondValue;
				return default;
			}
			set
			{
				if (value is T1 first)
					firstValue = first;
				else if (value is T2 second)
					secondValue = second;
				else
					throw new InvalidOperationException("Value type is an unavailable type of variation");
			}
		}



		public static implicit operator Variation<T1, T2>(T1 value) => new Variation<T1, T2>(value);
		public static implicit operator T1(Variation<T1, T2> value) => value.firstValue;

		public static implicit operator Variation<T1, T2>(T2 value) => new Variation<T1, T2>(value);
		public static implicit operator T2(Variation<T1, T2> value) => value.secondValue;
	}
}