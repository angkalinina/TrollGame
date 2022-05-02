using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    private List<IController> m_Controllers;
    private void OnStartControllers()
    {
        foreach (IController controller in m_Controllers)

            try
            {

            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        controller.OnStart();
    }
}
