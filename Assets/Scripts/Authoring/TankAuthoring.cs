﻿using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class TankAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public float speed = 10f;
	public GameObject projectilePrefab;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
		dstManager.AddComponentData(entity, new Speed{Value = speed});
        dstManager.AddComponentData(entity, new Velocity());

		dstManager.AddComponentData(entity, new BodyRotation());
		dstManager.AddComponentData(entity, new TurretRotation());

		//store a reference to the entity which represents the projectile Prefab
		dstManager.AddComponentData(entity, new Projectile{Reference = conversionSystem.GetPrimaryEntity(projectilePrefab)});
    }

	public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
	{
		//declare that the projectile Prefab needs to be converted to an entity too
		referencedPrefabs.Add(projectilePrefab);
	}
}
