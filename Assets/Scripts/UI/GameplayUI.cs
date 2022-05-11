using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Runtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets;

namespace UIGameplayInfo
{
    public class GameplayUI : MonoBehaviour
    {
        public GameObject PauseButton;
        public GameObject ResumeButton;
        public GameObject MainMenuButton;
        public GameObject PauseMenu;

        private static Runner s_Runner;

        public void Resume()
        {

            PauseButton.SetActive(true);
            ResumeButton.SetActive(false);
            MainMenuButton.SetActive(false);

        }

        public void Pause()
        {
            s_Runner.StopRunning();
            PauseMenu.SetActive(true);
            ResumeButton.SetActive(true);
            MainMenuButton.SetActive(true);
        }

        public void ToMainMenu()
        {

            //SceneManager.LoadScene(AssetRoot.UIScene.name, LoadSceneMode.Additive);
        }
    }
}
