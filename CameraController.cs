using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    public float camSpeed = 10f;
    public float xMax=50.0f;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag ("Player").transform;
        offset = transform.position - target.position; //to maintain initial position difference between camera and player 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        if(desiredPosition.x>xMax)desiredPosition.x=xMax;
        transform.position =Vector3.Lerp(transform.position,desiredPosition,camSpeed*Time.deltaTime);
    }
}
