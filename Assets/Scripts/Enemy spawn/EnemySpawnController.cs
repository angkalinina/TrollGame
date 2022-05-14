using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime;
using Assets;
using Enemy;

namespace EnemySpawn
{
public class EnemySpawnController : IController
{
        private SpawnDronesAsset m_SpawnDrones;
        private Grid m_Grid; //объекта не существует, удалить когда будет готов уровень

        private float m_SpawnStartTime;
        private float m_PassedTimePreviousFrame = -1f;


        //конструктор который передает данные для спавна
        public EnemySpawnController(SpawnDronesAsset spawnDrones, Grid grid)
        {
            m_SpawnDrones = spawnDrones;
            m_Grid = grid;
        }

    public void OnStart()
    {
            m_SpawnStartTime = Time.time;
    }

    public void OnStop()
    {
        
    }

    public void Tick()
    {
            float passedTime = Time.time - m_SpawnStartTime;
            float timeToSpawn = 0f;

            foreach (SpawnDrones drones in m_SpawnDrones.SpawnDrones)
            {
                timeToSpawn += drones.TimeBeforeStartDrones;

                for (int i = 0; i < drones.Count; i++)
                { 
                    if (passedTime >= timeToSpawn && m_PassedTimePreviousFrame < timeToSpawn) 
                    {
                        // Spawn Enemy return;
                    }

                    if (i < drones.Count - 1)
                    { 
                        timeToSpawn += drones.TimeBetweenSpawn;
                    }
                    
                }
            }

            

            m_PassedTimePreviousFrame = passedTime;           

    }

        private void SpawnEnemy(EnemyAsset asset)
        {
            //EnemyView view = Object.Instantiate(asset.ViewPrefab);
            EnemyData data = new EnemyData(asset);

            //data.AttachView(view);

            //Game.Player.EnemySpawned(data);
        }
  }
}
