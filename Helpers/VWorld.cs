using Unity.Entities;
using UnityEngine;

namespace Notify.Helpers;

/// <summary>
/// Various utilities for interacting with the Unity ECS world.
/// </summary>
public static class VWorld
{
    private static World _serverWorld;
    public static World Server
    {
        get
        {
            if (_serverWorld != null) return _serverWorld;

            _serverWorld = GetWorld("Server")
                ?? throw new System.Exception("There is no Server world (yet). Did you install a server mod on the client?");
            return _serverWorld;
        }
    }

    public static bool IsServer => Application.productName == "VRisingServer";

    private static World GetWorld(string name)
    {
        foreach (var world in World.s_AllWorlds)
        {
            if (world.Name == name)
            {
                return world;
            }
        }

        return null;
    }
}