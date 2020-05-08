﻿using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateAfter(typeof(TransformSystemGroup))]
public class TurretRotationSystem : SystemBase
{
	protected override void OnUpdate()
	{
		Entities
			.ForEach((ref Rotation rotation, ref Translation translation, in LocalToWorld localToWorld, in Parent parent, in TurretInput input) =>
			{
				float3 worldTarget = new float3(input.Target.x, 0f, input.Target.y);
				float3 worldPos = new float3(localToWorld.Position.x, 0f, localToWorld.Position.z);

				//calculate world direction
				float3 dir = math.normalize(worldTarget - worldPos);

				quaternion worldRot = quaternion.LookRotationSafe(dir, math.up());

				LocalToWorld parentLocalToWorld = GetComponent<LocalToWorld>(parent.Value);
				quaternion parentRot = parentLocalToWorld.Rotation;
				quaternion localRot = math.mul(math.inverse(parentRot), worldRot);

				rotation.Value = localRot;
			}).Schedule();
	}
}