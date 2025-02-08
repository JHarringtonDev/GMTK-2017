using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPlane : MonoBehaviour
{
    [SerializeField] string nextLevel;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
