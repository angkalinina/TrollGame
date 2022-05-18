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
            playerData = PlayerÑondition.GetData();
        }

        private void OnDestroy()
        {
            PlayerÑondition.SaveData(playerData);
        }

        //âçàèìîäåéñòâèå ñ òğèããåğîì
        //if (Input.GetMouseButtonDown(0))
        //{
        // ModifyScore(+1);
        //}

        //else if (Input.GetMouseButtonDown(1))
        // {
        //playerData = PlayerÑondition.GetNewPlayerData();
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

