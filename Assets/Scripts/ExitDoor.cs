using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] int runesToActivate;

    void OpenDoor()
    {
        Debug.Log("Open Door");
    }

    public void ActivateRune() 
    {
        runesToActivate--;

        if (runesToActivate == 0 ) 
        {
            OpenDoor();
        }
    }
}
