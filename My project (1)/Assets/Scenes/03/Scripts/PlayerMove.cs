using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    public float speed = 10.0f;
    // Start is called before the first frame update
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void FixedUpdate()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(mH, 0.0f, mV);
        //if (Input.GetButtonDown("W"))
        //{
        //    direction.x = 1;
        //}
        //if (Input.GetButtonDown("S"))
        //{
        //    direction.x = -1;
        //}
        //if (Input.GetButtonDown("A"))
        //{
        //    direction.z = 1;
        //}
        //if (Input.GetButtonDown("D"))
        //{
        //    direction.z = -1;
        //}
        direction.Normalize();

        rb.MovePosition(rb.position + direction* speed * Time.deltaTime);
       
    }
}
