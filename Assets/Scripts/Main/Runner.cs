using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Enemy;
using EnemySpawn;
using Main;

namespace Runtime
{
    public class Runner : MonoBehaviour
    {
        private List<IController> m_Controllers;
        private bool m_IsRunning = false;

        private void Update()
        {
            if (!m_IsRunning)
            {
                return;
            }

            TickControllers();
        }

        public void StartRunning()
        {
            CreateAllControllers();
            OnStartControllers();
            m_IsRunning = true;
            Debug.Log("стартовал Runtime");
        }

        public void StopRunning()
        {
            OnStopControllers();
            m_IsRunning = false;
            Debug.Log("остановился Runtime");
        }

        private void CreateAllControllers()
        {
            m_Controllers = new List<IController>();
            { 
                //new EnemySpawnController(SpawnDronesAsset spawnDrones, Grid grid);
                new MovementController();
            }
            
        }

        private void OnStartControllers()
        {
            foreach (IController controller in m_Controllers)
            {
                try
                {
                    controller.OnStart();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }

        }

        private void TickControllers()
        {
            foreach (IController controller in m_Controllers)
            {
                try
                {
                    controller.Tick();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }

        }

        private void OnStopControllers()
        {
            foreach (IController controller in m_Controllers)
            {
                try
                {
                    controller.OnStop();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }

        }
    }
}