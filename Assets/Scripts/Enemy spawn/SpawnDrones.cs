using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using Enemy;

namespace EnemySpawn
{ 

[System.Serializable]
public class SpawnDrones
{
        public EnemyAsset EnemyAsset;
        public int Count;
        public float TimeBetweenSpawn;

        public float TimeBeforeStartDrones;
}
}