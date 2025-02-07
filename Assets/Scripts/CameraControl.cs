using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float mouseSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseInput = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        transform.eulerAngles += mouseInput * mouseSpeed;
    }

    //Input.GetAxis("Mouse Y")
}
