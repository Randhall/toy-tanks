﻿using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public struct BodyInput : IComponentData
{
	public float2 Movement;
}

public struct TurretInput : IComponentData
{
	public float2 Target;
	public bool Fire;
}

public struct Velocity : IComponentData
{
    public float Value;
}

public struct Speed : IComponentData
{
    public float Value;
}

public struct FireCooldown : IComponentData
{
    public float Value;
}

public struct FireInterval : IComponentData
{
    public float Value;
}

public struct ProjectilePrefab : IComponentData
{
    public Entity Reference;
}