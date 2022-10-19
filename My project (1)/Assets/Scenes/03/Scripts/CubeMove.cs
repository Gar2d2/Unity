using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    [SerializeField]
    public float speed = 10.0f;
    // Start is called before the first frame update
    Rigidbody rb;
    private bool bDirection = false;
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
        Vector3 direction = new Vector3(speed, 0, 0);

        if (bDirection)
        {
            rb.MovePosition(rb.position + direction);
        }
        else
        {
            rb.MovePosition(rb.position + direction * -1);
        }
        bDirection = !bDirection;
    }
}
