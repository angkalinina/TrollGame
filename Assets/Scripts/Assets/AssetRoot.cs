using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Assets
{
 [CreateAssetMenu(menuName = "Assets/AssetRoot", fileName = "AssetRoot")]
    public class AssetRoot : ScriptableObject
    {
        public List<LevelAsset> Levels;

        public SceneAsset UIScene;
        
    }

}
   
