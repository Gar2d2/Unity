using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z4_EjectPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³.");
            var player = other.gameObject.GetComponent<MoveWithCharacterControllerl6>();
            player.playerVelocity.y = player.GetJumpForce() * 3;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
       
    }
}
