using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/Level Asset", fileName = "Level Asset")]


    public class LevelAsset : ScriptableObject
    {
        public SceneAsset SceneAsset;
        
    }

}
