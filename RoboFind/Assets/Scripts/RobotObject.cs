using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotObject : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField]
    float speed = 3;
    //adjust this to change how high it goes
    [SerializeField]
    float height;

    Vector3 pos;

    int chooseDirection;

    private void Start()
    {
        pos = transform.position;
    }
    void FixedUpdate()
    {
        //calculate what the new X position will be
        float newY = Mathf.Sin(Time.time * speed) * height + transform.position.y;
        //set the object's X to the new calculated X
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }
}
