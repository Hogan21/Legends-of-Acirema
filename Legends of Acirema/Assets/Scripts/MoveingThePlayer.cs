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

    [SerializeField] private float swingCooldown;
    [SerializeField] private float shootCooldown;
    [SerializeField] private float swingDelay;
    [SerializeField] private float shootDelay;
    private bool animPlaying = false;

    [SerializeField] private bool hasPipeEquiped = false;

    private Animator animator;
    public GameObject PipeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        animator = PipeWeapon.GetComponent<Animator>();

        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        swingDelay += Time.deltaTime;
        shootDelay += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;

        verticalinput = Input.GetAxis("Vertical");
        horizontalinput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalinput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalinput);
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);

        // Testing code for inventory \/
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hasPipeEquiped = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hasPipeEquiped = false;
        }*/
        // ----------------------------

        if (hasPipeEquiped == true)
        {
            PipeWeapon.SetActive(true);
        }
        else
        {
            PipeWeapon.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        else
        {
            speed = 5.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false;
        }

        /* if (Input.GetKeyDown(KeyCode.C))
        {
            // crouch code goes here
        } */

        if (!animPlaying)
        {
            if ((swingDelay >= swingCooldown) && (Input.GetMouseButtonDown(0)))
            {
                animator.SetTrigger("PipeSwingTest");
                StartCoroutine(Wait("Swing"));
                animPlaying = true;
            }
            else if ((shootDelay >= shootCooldown) && (Input.GetMouseButtonDown(1)))
            {
                animator.SetTrigger("Shoot");
                StartCoroutine(Wait("Shoot"));
                animPlaying = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("pipepickup"))
        {
            Destroy(collision.gameObject);
            hasPipeEquiped = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

    IEnumerator Wait(string action)
    {
        if (action == "Shoot")
        {
            yield return new WaitForSeconds(0.45f);
            if (hasPipeEquiped == true)
            {
                Instantiate(RockPrefab, SpawnRocks.transform.position, transform.rotation);
            }
            animPlaying = false;
            shootDelay = 0;
        }else if (action == "Swing")
        {
            yield return new WaitForSeconds(0.45f);
            animPlaying = false;
            swingDelay = 0;
        }
    }
}
