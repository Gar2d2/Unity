using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    GameObject m_startObject;
    [SerializeField]
    GameObject m_endObject;

    bool bMove = false;
    Vector3 moveDirection;
    void Start()
    {
        moveDirection = m_endObject.transform.position - this.transform.position;
        moveDirection.y = 0;
        moveDirection.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     

        if(bMove)
        {
            var move = moveDirection * 1 * Time.deltaTime; 
            var pos = this.transform.position;
            pos += move;
            this.transform.position = pos;
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other == m_endObject.GetComponent<Collider>())
        {
            moveDirection = m_startObject.transform.position - this.transform.position;
            moveDirection.y = 0;
            moveDirection.Normalize();
        }
        if (other == m_startObject.GetComponent<Collider>())
        {
            moveDirection = m_endObject.transform.position - this.transform.position;
            moveDirection.y = 0;
            moveDirection.Normalize();

            bMove = false;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = this.gameObject.transform; 
            Debug.Log("Player wszed³ na windê.");
            bMove = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
            Debug.Log("Player zszed³ z windy.");
          
        }
    }
}
