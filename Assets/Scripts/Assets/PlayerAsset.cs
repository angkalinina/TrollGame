using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/Player", fileName = "Player Asset")]

    public class PlayerAsset : ScriptableObject
    {
        [SerializeField] GameObject Player;
        
    }
}