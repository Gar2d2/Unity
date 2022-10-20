using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interp : MonoBehaviour
{
    // Smooth towards the height of the target

    public Transform target;
    float smoothTime = 0.5f;
    public float xVelocity = 0.0f;
    public float zVelocity = 0.0f;
    public float yVelocity = 0.0f;

    void Update()
    {
        float newX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref xVelocity, smoothTime);
        float newY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        float newZ = Mathf.Lerp(transform.position.z, target.position.z, zVelocity);
        zVelocity += 0.01f * Time.deltaTime; ;
        Debug.Log(target.position); 
        transform.position = new Vector3(newX, newY, newZ);
    }
}
 