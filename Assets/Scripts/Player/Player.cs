using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player
{
public class Player : MonoBehaviour

    {
        private PlayerData playerData;

        private void Start()
        {
            playerData = Player—ondition.GetData();
        }

        private void OnDestroy()
        {
            Player—ondition.SaveData(playerData);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ModifyScore(+1);
            }

            else if (Input.GetMouseButtonDown(1))
            {
                playerData = Player—ondition.GetNewPlayerData();
            }
        }

        public void ModifyScore(int amount)
        {
            playerData.Score += amount;
        }

    }
}

