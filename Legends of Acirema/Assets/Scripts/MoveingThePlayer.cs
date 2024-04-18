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

    private float lastAttacktime;
    [SerializeField] private float autorate;

    private Animator animator;
    public GameObject PipeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        lastAttacktime = Time.time;

        animator = PipeWeapon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;

        verticalinput = Input.GetAxis("Vertical");
        horizontalinput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalinput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalinput);
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false;
        }

        /* if (Input.GetKeyDown(KeyCode.C))
        {
            // crouch code goes here
        } */

        float attackDelta = Time.time - lastAttacktime;
        if ((attackDelta > autorate) && (Input.GetMouseButtonDown(0)))
        {
            animator.SetTrigger("PipeSwingTest");
            lastAttacktime = Time.time;
        }
        else if ((attackDelta > autorate) && (Input.GetMouseButtonDown(1)))
        {
            Instantiate(RockPrefab, SpawnRocks.transform.position, transform.rotation);
            animator.SetTrigger("Shoot");
            lastAttacktime = Time.time;
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
