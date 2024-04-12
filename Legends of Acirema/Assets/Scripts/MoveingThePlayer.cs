using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingThePlayer : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private float verticalinput;
    private float horizontalinput;
    private Rigidbody rb;
    [SerializeField] private int force;


    public float sensitivity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


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
        transform.Rotate(0, 0, -Input.GetAxis("QandE") * 90 * Time.deltaTime);
    }
}
