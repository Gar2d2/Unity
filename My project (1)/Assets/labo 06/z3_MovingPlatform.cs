using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z3_MovingPlatform : MonoBehaviour
{
   
    [SerializeField]
    List<GameObject> m_waypoints;

    int m_nextWaypoint = 1;
    bool bReversedOrder = false;
    bool bMoving = false;
    bool bPlayerOnPlatform = false;
    Vector3 m_moveDirection;
    void Start()
    {
        SetupDirection();
    }

    private void SetupDirection()
    {
        m_moveDirection = m_waypoints[m_nextWaypoint].transform.position- this.transform.position;
        m_moveDirection.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_waypoints.Count < 2)
        {
            return;
        }
        if (!bMoving)
        {
            return;
        }
        var move = m_moveDirection * 2 * Time.deltaTime;
        var pos = this.transform.position;
        var destination = m_waypoints[m_nextWaypoint].transform.position;

        if (Vector3.Distance(pos, destination) < 0.1)
        {
            if(!bReversedOrder)
            { 
                if(m_nextWaypoint < m_waypoints.Count - 1)
                {
                 
                    m_nextWaypoint++;
                }
                else
                {
                    bReversedOrder = true;
                }
            }
            if(bReversedOrder)
            {
                if (m_nextWaypoint > 0)
                {
                    m_nextWaypoint--;
                }
                else
                {
                    if(!bPlayerOnPlatform)
                    {
                        bMoving = false;
                    }
                    bReversedOrder = false;
                    m_nextWaypoint++;
                }
            }
            SetupDirection();
            return;
        }
        pos += move;
        this.transform.position = pos;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = this.gameObject.transform;
            Debug.Log("Player wszed³ na windê.");
            bMoving = true;
            bPlayerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
            Debug.Log("Player zszed³ z windy.");
            bPlayerOnPlatform = false;
        }
    }
}
