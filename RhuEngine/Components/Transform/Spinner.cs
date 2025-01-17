﻿using RhuEngine.WorldObjects;
using RhuEngine.WorldObjects.ECS;

using RNumerics;
using RhuEngine.Linker;

namespace RhuEngine.Components
{
	[UpdateLevel(UpdateEnum.Movement)]
	[Category(new string[] { "Transform" })]
	public class Spinner : Component
	{
		public Linker<Quaternionf> driver;

		public Sync<Vector3f> speed;

		public Sync<Quaternionf> offset;

		public override void OnAttach() {
			base.OnAttach();
			offset.Value = Entity.rotation.Value;
			driver.SetLinkerTarget(Entity.rotation);
			speed.Value = new Vector3f(35, 35, 0);
		}

		public override void Step() {
			var deltaSeconds = RTime.Elapsedf;
			if (driver.Linked) {
				var newval = Entity.LocalTrans * Matrix.R(offset.Value) * Matrix.R(Quaternionf.CreateFromEuler(speed.Value.x * deltaSeconds, speed.Value.y * deltaSeconds, speed.Value.z * deltaSeconds));
				newval.Decompose(out _, out var newrotation, out _);
				driver.LinkedValue = newrotation;
			}
			else {
				driver.Target = Entity.rotation;
			}
		}
	}
}
