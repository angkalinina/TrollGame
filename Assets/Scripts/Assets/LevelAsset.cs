using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/Levels", fileName = "Level Asset")]


    public class LevelAsset : ScriptableObject
    {

        public SceneAsset SceneAsset;
    }

}
