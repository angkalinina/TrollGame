using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime;
using Locator;

namespace LocatorSpawn
{
    public class LocatorSpawnController : IController
    {
        public void OnStart()
        {
            
        }

        public void OnStop()
        {
            
        }

        public void Tick()
        {
            //���� ����� ��������������� � �����������, �� ��������� ����� ������ ��������
        }
    }

    //private void SpawnLocator(LocatorAsset asset)
   // {
    //    LocatorView view = Object.Instantiate(asset.ViewPrefab);
   //     LocatorData data = new LocatorData(asset);

   //     data.AttachView(view);
    //}

}