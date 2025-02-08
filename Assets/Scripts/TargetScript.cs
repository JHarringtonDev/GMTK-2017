using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    MovementController player;
    [SerializeField] bool isEnemy;
    [SerializeField] int maxHealth;
    int currentHealth;

    private void Start()
    {
        player = FindObjectOfType<MovementController>();
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        player.RestoreDash();
        if (isEnemy && currentHealth > 0)
        {
            currentHealth--;
        }
        else
        {
            deactivateTarget();
        }
    }

    void deactivateTarget()
    {
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void reactivateTarget()
    {
        GetComponent<SphereCollider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
        if (isEnemy)
        {
            currentHealth = maxHealth;
        }
    }
}
