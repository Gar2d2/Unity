using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveV2 : MonoBehaviour
{
    [SerializeField]
    public float speed = 10.0f;
    // Start is called before the first frame update
    Rigidbody rb;
    float amountOfMove = 0;
    int moveType = 0;
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
        Vector3 direction = new Vector3(0.0f,0.0f,0.0f);
        switch (moveType)
        {
            case 0:
                
                    direction.x = speed * Time.deltaTime;
                    break;
                
            case 1:
                
                    direction.z = speed * Time.deltaTime *- 1.0f;
                    break;
                
            case 2:
                
                    direction.x = speed * Time.deltaTime *-1.0f;

                    break;
                
            case 3:
                
                    direction.z = speed * Time.deltaTime ;
                    break;
                
        }
       
        amountOfMove += speed * Time.deltaTime;
        

        if (amountOfMove >= speed)
        {
            moveType = (moveType + 1) % 4;
            amountOfMove = 0;
            Vector3 rot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            rot.y += 90;
            transform.Rotate(rot);
        }

        rb.MovePosition(rb.position + direction);
       
    }
}
