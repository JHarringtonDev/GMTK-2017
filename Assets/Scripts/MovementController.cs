using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    float xInput;
    float yInput;
    [SerializeField] float moveSpeed;
    [SerializeField] float mouseSpeed;
    [SerializeField] float dashSpeed;

    Rigidbody rb;

    CameraControl cameraHold;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraHold = FindObjectOfType<CameraControl>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame

    private void Update()
    {
        //Vector3 mouseInput = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        //transform.eulerAngles += mouseInput * mouseSpeed;

        if(Input.GetMouseButtonDown(0))
        {
            rb.AddForce(cameraHold.transform.forward * dashSpeed, ForceMode.Impulse);
        }
    }

    void LateUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        Vector3 playerInput = cameraHold.transform.forward * yInput + cameraHold.transform.right * xInput;
        playerInput.y = 0;

        rb.AddForce (playerInput * moveSpeed, ForceMode.Force);
    }
}
