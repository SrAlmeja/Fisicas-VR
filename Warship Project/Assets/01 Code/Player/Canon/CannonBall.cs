using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class CannonBall : MonoBehaviour
{
    
    private Rigidbody _rb;
    private Collider _collider;
    private MeshRenderer _meshRenderer;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _meshRenderer = GetComponent<MeshRenderer>();
        
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
        _meshRenderer.enabled = false;
        _collider.enabled = false;
    }

    void Update()
    {
        
    }

    void Activate()
    {
        _rb.isKinematic = false;
        _meshRenderer.enabled = true;
        _collider.enabled = true;
    }
    
    public void Fire(Vector3 origin, Vector3 direction, float magnitude)
    {
        transform.position = origin;
        transform.eulerAngles = Vector3.zero;
        Activate();
        _rb.AddForce((-1)*direction.normalized * magnitude);
    }
}
