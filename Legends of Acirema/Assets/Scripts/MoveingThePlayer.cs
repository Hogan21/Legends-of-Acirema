using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingThePlayer : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private float verticalinput;
    private float horizontalinput;
    [SerializeField] private float sensitivity = 10f;

    private Rigidbody playerRb;
    [SerializeField] private bool isOnGround = true;
    [SerializeField] private float jumpForce = 7;

    public GameObject RockPrefab;
    // public Rigidbody RockRb;
    public GameObject SpawnRocks;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;

        verticalinput = Input.GetAxis("Vertical");
        horizontalinput = Input.GetAxis("Horizontal");
        //move
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalinput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalinput);

        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        // transform.Rotate(0, 0, -Input.GetAxis("QandE") * 90 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false;
        }

        /* if (Input.GetKeyDown(KeyCode.C))
        {
            // crouch code goes here
        } */

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(RockPrefab, SpawnRocks.transform.position, transform.rotation);
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
