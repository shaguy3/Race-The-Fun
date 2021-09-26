using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private float speed = 2f;

    private Rigidbody m_rigidBodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        m_rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidBodyComponent.AddForce(transform.right * gyroToMovement());
        transform.rotation = gyroToRot();
    }

    private float gyroToMovement()
    {
        return Input.gyro.attitude.x;
    }

    private Quaternion gyroToRot()
    {
        return new Quaternion(Input.gyro.attitude.x,0,0,0);
    }


}
