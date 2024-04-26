using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingThePlayer : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private Vector3 speed;
    [SerializeField] private float timer;


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

    [SerializeField] private bool hasPipeEquipped = false;

    private Animator animator;
    public GameObject PipeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        animator = PipeWeapon.GetComponent<Animator>();

        movementSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        swingDelay += Time.deltaTime;
        shootDelay += Time.deltaTime;
        if (isOnGround) { timer += Time.deltaTime; }
        Attack();
        Movement();
        Speed();
        Inventory();


    }
    void Attack()
    {
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
    void Movement()
    {
        verticalinput = Input.GetAxis("Vertical");
        horizontalinput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalinput);
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalinput);
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false;
        }
    }
    void Speed()
    {
        
    }
    void Inventory()
    {

        if (hasPipeEquipped == true)
             {PipeWeapon.SetActive(true);}
        else {PipeWeapon.SetActive(false);}
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
            hasPipeEquipped = true;
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
            if (hasPipeEquipped == true)
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
