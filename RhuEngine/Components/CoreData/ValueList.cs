﻿using RhuEngine.WorldObjects;
using RhuEngine.WorldObjects.ECS;

namespace RhuEngine.Components
{
	[Category(new string[] { "CoreData" })]
	public class ValueList<T> : Component
	{
		public readonly SyncValueList<T> Value;
	}
}
