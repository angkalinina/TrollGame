using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    //public delegate void ClickActon();
    //public static event ClickActon OnClicked;

    // private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(), "Click")); //� ������� � react ���������� ������
    //  {
    //     if (OnClicked != null)
    //        OnClicked();
    //}
    // }

    public void LoadNextScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Debug.Log("�������� �����" + scenename);
    }
}
