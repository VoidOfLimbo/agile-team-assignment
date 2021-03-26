using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float sPEED =10f;
    public Rigidbody rb;
    public bool cubeOnFloor = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * sPEED;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * sPEED;

        transform.Translate(horizontal, 0,vertical ); //once per second not once per frame

        if (Input.GetButtonDown("Jump") && cubeOnFloor)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            cubeOnFloor = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            cubeOnFloor = true;
        }
    }
}
