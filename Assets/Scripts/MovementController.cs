using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    float xInput;
    float yInput;
    float moveSpeed;

    [SerializeField] float groundspeed;
    [SerializeField] float airSpeed;
    [SerializeField] float mouseSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dragDelay;

    [Header("Ground Check")]
    [SerializeField] float groundDrag;
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;

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

        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundLayer / 2 + 0.2f, groundLayer);

        if (isGrounded)
        {
            rb.drag = groundDrag;
            moveSpeed = groundspeed;
        }
        else
        {
            moveSpeed = airSpeed;
        }

        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(HandleDash());
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

    IEnumerator HandleDash()
    {
        rb.drag = groundDrag;
        rb.velocity = Vector3.zero;
        rb.AddForce(cameraHold.transform.forward * dashSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(dragDelay);
        rb.drag = 0;

    }
}
