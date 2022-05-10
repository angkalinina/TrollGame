using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Locator
{
    public class LocatorData 
    {
        private LocatorView m_View;

        public LocatorView View => m_View;

        public LocatorData(LocatorAsset asset)
        { 
        
        }

        public void AttachView(LocatorView view)
        {
            m_View = view;
            m_View = AttachData(this);

        }

        private LocatorView AttachData(LocatorData locatorData)
        {
            throw new NotImplementedException();
        }
    }
}
    
