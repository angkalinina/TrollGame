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
            playerData = PlayerCondition.GetData();
        }

        private void OnDestroy()
        {
            PlayerCondition.SaveData(playerData);
        }

        //взаимодействие с триггером
        //if (Input.GetMouseButtonDown(0))
        //{
        // ModifyScore(+1);
        //}

        //else if (Input.GetMouseButtonDown(1))
        // {
        //playerData = PlayerCondition.GetNewPlayerData();
        //}

        private void Update()
        {
            
        }

        public void ModifyScore(int amount)
        {
            playerData.Score += amount;
        }

    }
}

