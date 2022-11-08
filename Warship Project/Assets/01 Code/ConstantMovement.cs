using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float waterSpeed;
    [SerializeField] private GameObject ship;

    [SerializeField] private float speed;
    
    Vector3 m_EulerAngleVelocity;
    
    
    private Vector3 constantCircularMovement;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        WaterForce();
        m_EulerAngleVelocity = new Vector3(0, 5f, 0);
    }


    

    public void WaterForce()
    {

        float waterforce = (transform.forward.magnitude * waterSpeed);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        rb.AddForceAtPosition(transform.forward * (waterforce), ship.transform.localPosition, ForceMode.Force);
    }

    public void AtractionForce()
    {
        
    }

}
