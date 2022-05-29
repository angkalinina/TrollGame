using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{

    internal class PlayerCondition
    {
        internal static PlayerData GetData()
        {
            if (PlayerPrefs.HasKey("Score") == false)
            {
                return GetNewPlayerData();
            }

            return LoadFromPlayerPrefs();
        }

        public static PlayerData GetNewPlayerData()
        {
            return new PlayerData()
            {
                Score = 1
            };
        }

        private static PlayerData LoadFromPlayerPrefs()
        {
            int score = PlayerPrefs.GetInt("Score");
            float movementSpeed = PlayerPrefs.GetFloat("MovementSpeed");

            return new PlayerData()
            {
                Score = score,
                MovementSpeed = movementSpeed
            };
        }

        internal static void SaveData(PlayerData playerData)
        {
            PlayerPrefs.SetInt("Score", playerData.Score);
            PlayerPrefs.SetFloat("MovementSpeed", playerData.MovementSpeed);
        }

    }
}