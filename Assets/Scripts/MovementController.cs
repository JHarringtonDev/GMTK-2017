using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    float xInput;
    float yInput;
    [SerializeField] float moveSpeed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        Vector3 playerInput = transform.forward * yInput + transform.right * xInput;

        rb.AddForce (playerInput * moveSpeed, ForceMode.Impulse);
    }
}
