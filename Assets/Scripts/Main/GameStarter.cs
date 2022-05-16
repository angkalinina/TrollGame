using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

namespace Runtime
{ 
public class GameStarter : MonoBehaviour
{
    public static GameStarter instance;
    public event Action gameStarted, gamePaused, gameLose, gameNextScene;
    
    private List<IController> _Controllers; 
    



    bool isRunning = false;
    bool isPaused = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isRunning == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isRunning = true;
                isPaused = false;
                StartGame(); 
                TickControllers();
                    Debug.Log("Запустился стартер");

            }

                return;
        }

    }
    public void StartGame()
    {
        gameStarted?.Invoke();
            CreateAllControllers();
            OnStartControllers();
            
        }

        public void GameOver()
        {
            OnStopControllers();
            isRunning = false;
        }

    public void PauseGame()
    {
        if (isPaused == true)
        {
            Time.timeScale = 0f;
        }      
        gamePaused?.Invoke();
    }

        private void CreateAllControllers()
        {
            _Controllers = new List<IController>();
            {
                //new EnemySpawnController(SpawnDronesAsset spawnDrones, Grid grid);
                //new MovementController();
            }

        }

        private void OnStartControllers()
        {
            foreach (IController controller in _Controllers)
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
            Debug.Log("Запустились контроллеры");
        }

        private void TickControllers()
        {
            foreach (IController controller in _Controllers)
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
            foreach (IController controller in _Controllers)
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
            Debug.Log("Контроллеры остановились");
        }
        
    }

}
