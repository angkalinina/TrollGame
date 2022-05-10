using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Locator
{
    [CreateAssetMenu(menuName = "Assets/Locator", fileName = "Locator Asset")]

    public class LocatorAsset : ScriptableObject
    {
        public LocatorView ViewPrefab;
    }

}