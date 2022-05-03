using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
 [CreateAssetMenu(menuName = "Assets/AssetRoot", fileName = "AssetRoot")]
    public class AssetRoot : ScriptableObject
    {
        public List<LevelAsset> Levels;
    }

}
   
