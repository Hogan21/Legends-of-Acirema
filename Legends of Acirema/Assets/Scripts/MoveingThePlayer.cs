using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingThePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private float speed = 5.0f;
    private float verticalinput;
    private float horizontalinput;

    public float sensitivity = 10f;

    // Update is called once per frame
    void Update()
    {
        verticalinput = Input.GetAxis("Vertical");
        horizontalinput = Input.GetAxis("Horizontal");
        //move
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalinput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalinput);

        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        transform.Rotate(0, 0, -Input.GetAxis("QandE") * 90 * Time.deltaTime);
    }
}
