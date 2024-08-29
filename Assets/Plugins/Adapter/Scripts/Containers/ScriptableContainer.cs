using System;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Containers
{
	public class ScriptableContainer : ScriptableObject
	{
		protected bool CanGetValue<T>(List<Container<string, T>> containers, string name)
		{
			string[] split = name.Split('.', 2);
			foreach (Container<string, T> container in containers)
				if (split.Length > 1 && split[1].Contains(".") && container.type is ContainerType.Store)
					throw new IndexOutOfRangeException($"Path still contains the keys to access the value: \"{name}\"");
				else if (container.name == split[0] && container.type != ContainerType.Unknown)
					return container.type is ContainerType.Store || CanGetValue(container.container, split[1]);
			return false;
		}
		protected T GetValue<T>(List<Container<string, T>> containers, string name, bool ignore = false)
		{
			string[] split = name.Split('.', 2);
			foreach (Container<string, T> container in containers)
				if (split.Length > 1 && split[1].Contains(".") && container.type is ContainerType.Store)
					throw new IndexOutOfRangeException($"Path still contains the keys to access the value: \"{name}\"");
				else if (container.name == split[0] && container.type is not ContainerType.Unknown)
					return container.type is ContainerType.Store ? container.store : GetValue(container.container, split[1]);
			if (ignore)
				return default;
			throw new KeyNotFoundException($"Value cannot be found in the container by the key: \"{name}\"");
		}
	}
}