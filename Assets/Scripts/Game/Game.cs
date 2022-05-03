using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

namespace Runtime
{
    public static class Game 
    {
        
        private static AssetRoot s_AssetRoot;
        private static LevelAsset s_CurrentLevel;

        
        private static AssetRoot AssetRoot => s_AssetRoot;
        private static LevelAsset CurrentLevel => s_CurrentLevel;

        public static void SetAssetRoot(AssetRoot assetRoot)
        {
            s_AssetRoot = assetRoot;
        }

        public static void StartLevel(LevelAsset levelAsset)
        {
            s_CurrentLevel = levelAsset;

           
        }
    }
}