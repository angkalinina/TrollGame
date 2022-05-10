using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Locator
{
    public class LocatorView : MonoBehaviour
    {
        [SerializeField]

        private LocatorData m_Data; 
        private LocatorData Data => m_Data;
        


        public void AttachData(LocatorData locatorData)
        {
            m_Data = locatorData;
        }
    }

}