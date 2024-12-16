using System;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Containers
{
	public abstract class ScriptableContainer : ScriptableObject
	{
		protected T GetStore<T>(List<Container<string, T>> search, string path, bool safe = false)
		{
			string[] array = path.Split('.', 2);
			foreach (Container<string, T> container in search)
				if (array.Length > 1 && array[1].Contains(".") && container.type is ContainerType.Store)
					throw new IndexOutOfRangeException($"Path still contains keys to access value: \"{path}\"");
				else if (container.name == array[0] && container.type is not ContainerType.Empty)
					return container.type is ContainerType.Store ? container.store : GetStore(container.container, array[1], safe);
			return safe ? default : throw new KeyNotFoundException($"Value cannot be found in container by path: \"{path}\"");
		}
		protected bool SetStore<T>(List<Container<string, T>> search, string path, T value, bool safe = false)
		{
			string[] array = path.Split('.', 2);
			foreach (Container<string, T> container in search)
				if (array.Length > 1 && array[1].Contains(".") && container.type is ContainerType.Store)
					throw new IndexOutOfRangeException($"Path still contains keys to access value: \"{path}\"");
				else if (container.name == array[0] && container.type is not ContainerType.Empty)
					return container.type is ContainerType.Store ? (object)(container.store = value) == (object)value : SetStore(container.container, array[1], value, safe);
			return safe ? false : throw new KeyNotFoundException($"Value cannot be found in container by path: \"{path}\"");
		}
		protected bool SearchStore<T>(List<Container<string, T>> search, string path, out T store)
		{
			string[] array = path.Split('.', 2);
			foreach (Container<string, T> container in search)
				if (array.Length > 1 && array[1].Contains(".") && container.type is ContainerType.Store)
					return (object)(store = default) != default;
				else if (container.name == array[0] && container.type is not ContainerType.Empty)
					return container.type is ContainerType.Store ? (object)(store = container.store) == (object)container.store : SearchStore(container.container, array[1], out store);
			return (object)(store = default) != default;
		}
	}
}