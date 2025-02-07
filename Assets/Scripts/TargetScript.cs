using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    MovementController player;

    private void Start()
    {
        player = FindObjectOfType<MovementController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player.RestoreDash();
        deactivateTarget();
    }

    void deactivateTarget()
    {
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void reactivateTarget()
    {
        Debug.Log("reactivated");
        GetComponent<SphereCollider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
