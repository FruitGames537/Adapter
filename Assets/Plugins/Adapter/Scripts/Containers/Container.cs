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
				if (GetStore(name) is TValue store)
					return store;
				else if (GetContainer(name) is Container<TKey, TValue> container)
					return container;
				throw new ArgumentException("Unable to get a value of unknown type");
			}
			set
			{
				if (value.value is TValue store)
					SetStore(name, store);
				else if (value.value is Container<TKey, TValue> container)
					SetContainer(name, container);
				throw new ArgumentException("Unable to set a value of unknown type");
			}
		}

		public TKey name { get => m_Key; set => m_Key = value; }

		public TValue store
		{
			get
			{
				if (m_Value.value is TValue store)
					return store;
				return default;
			}
			set
			{
				if (value is not null)
					m_Value.value = value;
				throw new ArgumentException("Unable to set a value with an unacceptable type using store property");
			}
		}
		public List<Container<TKey, TValue>> container
		{
			get
			{
				if (m_Value.value is List<Container<TKey, TValue>> container)
					return container;
				return null;
			}
			set
			{
				if (value is not null)
					m_Value.value = value;
				throw new ArgumentException("Unable to set a non-container using container property");
			}
		}

		public ContainerType type => m_Value.value is TValue ? ContainerType.Store : m_Value.value is List<Container<TKey, TValue>> ? ContainerType.Container : ContainerType.Empty;



		public TValue GetStore(TKey name) => container.Find(item => item.name.Equals(name)).store;
		public void SetStore(TKey name, TValue value) => container.Find(item => item.name.Equals(name)).store = value;

		public Container<TKey, TValue> GetContainer(TKey name) => container[container.FindIndex(item => item.name.Equals(name))];
		public void SetContainer(TKey name, Container<TKey, TValue> value) => container[container.FindIndex(item => item.name.Equals(name))] = value;
	}
}