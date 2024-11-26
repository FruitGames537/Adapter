using System;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Containers
{
	[Serializable]
	public class Container<TKey, TValue>
	{
		public Container() : this(default) { }
		public Container(TKey key) : this(key, default) { }
		public Container(TKey key, TValue value)
		{
			m_Key = key;
			m_Value = value;
		}



		[SerializeField] private TKey m_Key;
		[SerializeField] private Variation<TValue, List<Container<TKey, TValue>>> m_Value;

		public Variation<TValue, Container<TKey, TValue>> this[TKey name]
		{
			get
			{
				if (GetContainer(name) is Container<TKey, TValue> container)
					return container;
				else if (GetStore(name) is TValue elementary)
					return elementary;
				throw new ArgumentException("Unable to get a value of unknown type");
			}
			set
			{
				if (value.value is Container<TKey, TValue> container)
					SetContainer(name, container);
				else if (value.value is TValue elementary)
					SetStore(name, elementary);
				throw new ArgumentException("Unable to set a value of unknown type");
			}
		}

		public TKey name { get => m_Key; set => m_Key = value; }

		public List<Container<TKey, TValue>> container
		{
			get
			{
				if (m_Value.value is List<Container<TKey, TValue>>)
					return m_Value.value as List<Container<TKey, TValue>>;
				return null;
			}
			set
			{
				if (value is not null)
					m_Value.value = value;
				throw new ArgumentException("Unable to set a non-container using the container property");
			}
		}
		public TValue store
		{
			get
			{
				if (m_Value.value is TValue)
					return (TValue)m_Value.value;
				return default;
			}
			set
			{
				if (value is not null)
					m_Value.value = value;
				throw new ArgumentException("Unable to set a value with an unacceptable type using the store property");
			}
		}

		public ContainerType type => m_Value.value is List<Container<TKey, TValue>> ? ContainerType.Container : m_Value.value is TValue ? ContainerType.Store : ContainerType.Unknown;



		public Container<TKey, TValue> GetContainer(TKey name) => container[container.FindIndex(item => item.name.Equals(name))];
		public void SetContainer(TKey name, Container<TKey, TValue> value) => container[container.FindIndex(item => item.name.Equals(name))] = value;

		public TValue GetStore(TKey name) => container.Find(item => item.name.Equals(name)).store;
		public void SetStore(TKey name, TValue value) => container.Find(item => item.name.Equals(name)).store = value;
	}
}