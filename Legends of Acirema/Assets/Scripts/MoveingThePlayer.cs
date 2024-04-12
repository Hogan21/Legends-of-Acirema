using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingThePlayer : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private float verticalinput;
    private float horizontalinput;
<<<<<<< HEAD
    private Rigidbody rb;
    [SerializeField] private int force;


    public float sensitivity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


=======
    [SerializeField] private float sensitivity = 10f;

    private Rigidbody playerRb;
    [SerializeField] private bool isOnGround = true;
    [SerializeField] private float jumpForce = 7;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

>>>>>>> 3ff76d77d1a290e90967c3cef2d1bb9246c3fad7
    // Update is called once per frame
    void Update()
    {
        verticalinput = Input.GetAxis("Vertical");
        horizontalinput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up) * force;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            speed = 100.0f;
        }


        //moveNOW
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalinput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalinput);

        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        // transform.Rotate(0, 0, -Input.GetAxis("QandE") * 90 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
