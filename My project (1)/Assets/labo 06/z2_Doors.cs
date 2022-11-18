using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class z2_Doors : MonoBehaviour
{
    [SerializeField]
    float moveLen = 2;

    float endPos;
    float startPos;
    bool bOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position.x;
        endPos = startPos + moveLen; 
    }

    // Update is called once per frame
    void Update()
    {
        if(bOpen)
        {
            var pos = this.transform.position;
            if(pos.x < endPos)
            {
                pos.x += 1f * Time.deltaTime;
                this.transform.position = pos; 
            }
        }
        if (!bOpen)
        {
            var pos = this.transform.position;
            if (pos.x > startPos)
            {
                pos.x -= 1f * Time.deltaTime;
                this.transform.position = pos;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na windê.");
            bOpen = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z windy.");
            bOpen = false;

        }
    }
}
