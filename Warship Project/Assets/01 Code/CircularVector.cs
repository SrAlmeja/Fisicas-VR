using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CircularVector
    : MonoBehaviour
{
    private float radius2;
    private Vector3 center;
    private float circleForce;

    private Vector3 waterForce;

    [SerializeField] float waterSpeed;

    private Vector3 shipPos;

    Rigidbody rb;
    [SerializeField] private float speed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        center = new Vector3(0, 0  ,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 circleVector = (new Vector3((transform.position.x - center.x)*2,0,(transform.position.z-center.z)*2));  
        
        transform.position = circleVector;
        
    }

    public void DrawCircle()
    {
        shipPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        radius2 = Mathf.Pow(shipPos.x - center.x,2) + Mathf.Pow(shipPos.y - center.y,2);
        circleForce = 3.14f*radius2;
    }

    public void WaterForceConstant()
    {
        DrawCircle();
        waterForce = new Vector3((circleForce*waterSpeed)*Time.deltaTime, 0, (circleForce*waterSpeed)*Time.deltaTime);
    } 
    void ShipMovement()
    {
        transform.position = (/*0(airForce * airDirection) +*/ waterForce) * Time.deltaTime;
    }
}
