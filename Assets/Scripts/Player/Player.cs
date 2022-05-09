using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runtime
{
    public class Player 
    {

        private List<EnemyData> m_EnemyDatas = new List<EnemyData>();
        public IReadOnlyList<EnemyData> EnemyDatas => m_EnemyDatas;


        public void EnemySpawned(EnemyData data)
        {
            m_EnemyDatas.Add(data);
        }
    }
}
