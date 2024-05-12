using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLaunch : MonoBehaviour
{
    private Rigidbody rockRb;
    [SerializeField] private float jumpForce = 20;
    [SerializeField] private float throwForward = 10;

    public GameObject Player;

    void Start()
    {
        rockRb = GetComponent<Rigidbody>();

        rockRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //rockRb.AddForce(Vector3.forward * throwForce, ForceMode.Impulse);
    }

    void LateUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * throwForward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        /*else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }*/
    }
}
