using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Assets/Enemy", fileName = "Enemy Asset")]
    public class EnemyAsset : ScriptableObject
    {

        public EnemyView ViewPrefub;
        public int Damage;
        public int Reward;

        public float Speed;


    }



}

