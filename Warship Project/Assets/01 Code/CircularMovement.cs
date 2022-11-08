using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;
    public float m_Speed;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_EulerAngleVelocity = new Vector3(0, 5f, 0);
    }

    private void Update()
    {
        m_Rigidbody.AddForce(transform.forward * (m_Speed * m_Rigidbody.mass));
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }
    
}
