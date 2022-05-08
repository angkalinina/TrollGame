using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

namespace EnemySpawn
{
    [CreateAssetMenu(menuName = "Assets/Spawn Drones Asset", fileName = "Spawn Drones Asset")]
    public class SpawnDronesAsset : ScriptableObject
    {
        public SpawnDrones[] SpawnDrones;

    }
}
