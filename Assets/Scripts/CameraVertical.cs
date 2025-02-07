using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVertical : MonoBehaviour
{
    [SerializeField] float verticalCamSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseInput = new Vector3(Input.GetAxis("Mouse X"), 0, 0);
        transform.eulerAngles += mouseInput * verticalCamSpeed;
    }
}
