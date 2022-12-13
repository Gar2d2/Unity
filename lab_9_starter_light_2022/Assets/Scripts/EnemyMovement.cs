using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private GameObject player;
    public EnemyController2D controller;
    public Animator animator;
    public float runSpeed = 30f;
    bool jump = false;
    float horizontalMove = 0f;
    enum Direction{ TO_POINT_A, TO_POINT_B };
    Direction m_currentDirection = Direction.TO_POINT_A;
    bool m_playerHitted = false;
    void Update()
    {
        if(m_playerHitted)
        {
            horizontalMove = 0f;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            return;
        }
        var dirVector = CurrentPoint() - this.transform.position;
        dirVector.Normalize();
 

        horizontalMove = dirVector.x * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Math.Abs(dirVector.x) < 0.1)
        {
            ChangeDirection();
        }
        //if (Input.GetButtonDown("Jump"))
        //{
        //    jump = true;
        //    animator.SetBool("IsJumping", true);
        //}
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void OnLanding()
    {
        Debug.Log("OnLanding()");
        animator.SetBool("IsJumping", false);
    }
    void ChangeDirection()
    {
        m_currentDirection = m_currentDirection == Direction.TO_POINT_A ? Direction.TO_POINT_B: Direction.TO_POINT_A; 
    }
    Vector3 CurrentPoint()
    {
        if(IsPlayerInside())
        {
            return player.transform.position;
        }
        return m_currentDirection == Direction.TO_POINT_A ? pointA.transform.position : pointB.transform.position;
    }
    bool IsPlayerInside()
    {
        return player.transform.position.x > pointA.transform.position.x && player.transform.position.x < pointB.transform.position.x;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player"))
        {
            m_playerHitted = true;
            Debug.Log("OnCollisionEnter2D");
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            m_playerHitted = false;
            print("No longer in contact with " + other.transform.name);
        }
       
    }
}