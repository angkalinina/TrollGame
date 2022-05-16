using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public interface IController
    {
        void OnStart();
        void OnStop();
        void Tick();
    
    }

    
    
}



