using System;
using UnityEngine;

namespace Adapter.Containers
{
	[Serializable]
	public struct Variation<T1, T2>
	{
		private Variation(T1 oneValue, T2 twoValue, Type storeType, VariationType type)
		{
			if (typeof(T1) == typeof(T2))
				throw new ArgumentException("Cannot create variation because type one and type two not different");
			m_OneValue = oneValue;
			m_TwoValue = twoValue;
			m_StoreType = storeType;
			m_Type = type;
		}
		public Variation(T1 value) : this(value, default, typeof(T1), VariationType.One) { }
		public Variation(T2 value) : this(default, value, typeof(T2), VariationType.Two) { }



		[SerializeField] private T1 m_OneValue;
		[SerializeField] private T2 m_TwoValue;

		[SerializeField] private Type m_StoreType;
		[SerializeField] private VariationType m_Type;

		public T1 oneValue
		{
			get
			{
				if (m_Type is VariationType.One)
					return m_OneValue;
				return default;
			}
			set
			{
				m_OneValue = value;
				m_TwoValue = default;
				m_StoreType = typeof(T1);
				m_Type = VariationType.One;
			}
		}
		public T2 twoValue
		{
			get
			{
				if (m_Type is VariationType.Two)
					return m_TwoValue;
				return default;
			}
			set
			{
				m_OneValue = default;
				m_TwoValue = value;
				m_StoreType = typeof(T2);
				m_Type = VariationType.Two;
			}
		}

		public Type storeType => m_StoreType;
		public VariationType type => m_Type;

		public object value
		{
			get
			{
				return type is VariationType.One ? m_OneValue : m_TwoValue;
			}
			set
			{
				if (value is T1)
					oneValue = (T1)value;
				else if (value is T2)
					twoValue = (T2)value;
				else
					throw new InvalidOperationException("Cannot set value because value type is unacceptable variation type");
			}
		}



		public static implicit operator Variation<T1, T2>(T1 value) => new Variation<T1, T2>(value);
		public static implicit operator Variation<T1, T2>(T2 value) => new Variation<T1, T2>(value);
		public static implicit operator T1(Variation<T1, T2> value) => value.oneValue;
		public static implicit operator T2(Variation<T1, T2> value) => value.twoValue;
	}
}