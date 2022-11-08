using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject Vela;
    public GameObject[] hollyClouds;
    private Rigidbody rb;
    private Vector3 airDirection;
    
    
    float closeDistance;
    int closerCloud = 0;
    float planetDistance;
    
    
    public float speed;
    Vector3 myPosition;
    Vector3 seekDesiredV;
    public Vector3 currentV;
    public float slowRadius;
    public float mass;
    public float force;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentV = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectsDistance();
        Vector3 airForce = seek(hollyClouds[closerCloud].transform.position);
        rb.AddForceAtPosition(transform.forward + currentV*Time.deltaTime*force, Vela.transform.position, ForceMode.Force);
        
    }
    
    void ObjectsDistance()
    {
        closeDistance = Vector3.Distance(transform.position, hollyClouds[0].transform.position);    
        for(int i = 0; i<hollyClouds.Length; i++)
        {
            planetDistance = Vector3.Distance(transform.position, hollyClouds[i].transform.position);
            if (planetDistance <= closeDistance) {closeDistance = planetDistance; closerCloud = i;}
            Debug.Log("Closer Planet " + closerCloud);
        }
    }
    
    public Vector3 seek(Vector3 targetPosition)
    {
        Vector3 velaPos = new Vector3(transform.position.x,0, transform.position.z);
        Vector3 CloudPos = new Vector3(targetPosition.x,0, targetPosition.z);
        //Direction
        airDirection = (CloudPos - velaPos);
        if (slowRadius >= airDirection.magnitude)
        {
            Debug.Log("Area lenta ");
            seekDesiredV = (airDirection.normalized * (speed * (airDirection.magnitude/slowRadius)));
        }
        else if(slowRadius < airDirection.magnitude)
        {Debug.Log("Steering normal");
            seekDesiredV = (airDirection.normalized * speed);
        }
        Vector3 steering = (seekDesiredV - currentV) / mass;
        
        return steering * (-1);
    }
}
