using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class z6_przeszkodaCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.CompareTag("Przeszkoda"))
        {
            Debug.Log("Dosz³o do kontaktu z przeszkod¹.");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
