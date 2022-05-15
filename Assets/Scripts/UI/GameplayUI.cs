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

        public GameObject Button;

        private float ScreenWidth;
        private float ScreenHeight;
        private float ButtonX;
        private float ButtonY;


        void OnGUI()
        {
            
            if (GUI.Button(new Rect(ButtonX, ButtonY, ScreenWidth, ScreenHeight), "click button"))
            { 
            //действие
            }
        }



        public static GameObject PauseButton;
        public static GameObject ResumeButton;
        public static GameObject MainMenuButton;
        public static GameObject PauseMenu;

        private static Runner s_Runner;

        public static void Resume()
        {

            PauseButton.SetActive(true);
            ResumeButton.SetActive(false);
            MainMenuButton.SetActive(false);

        }

        public static void Pause()
        {
            s_Runner.StopRunning();
            PauseMenu.SetActive(true);
            ResumeButton.SetActive(true);
            MainMenuButton.SetActive(true);
        }

        public static void ToMainMenu(string scenename)
        {
            SceneManager.LoadScene(scenename); 
        }

        
    }
}
