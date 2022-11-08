using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{
    [SerializeField] private InputActionReference inputActionReference;
    [SerializeField] private GameObject cannonToRotate;
    [SerializeField] private HandHolder _handHolder;
    [SerializeField] private bool _isGrabbingHolders = false;
    [SerializeField] private int maxProjectiles;
    [SerializeField] private float launchForce;
    [SerializeField] private GameObject projectile;

    private Queue<CannonBall> balls;

    public Action<bool> OnGrabHolders;
    void Start()
    {
        inputActionReference.action.performed += ctx => FireCannon();
        _handHolder.OnGrabbed += HandleGrabHolders;
        BuildPool();
    }

    private void Update()
    {
        if (_isGrabbingHolders)
        {
            RotateCannon();
        }
    }

    private void RotateCannon()
    {
        Vector3 aimDirection =  _handHolder.transform.position - cannonToRotate.transform.position;
        cannonToRotate.transform.rotation =  Quaternion.LookRotation(aimDirection);
    }
    
    private void HandleGrabHolders(bool isGrabbing)
    {
        
        if (isGrabbing)
        {
            _isGrabbingHolders = true;
        }
        else
        {
            _isGrabbingHolders = false;
        }
        
        OnGrabHolders?.Invoke(_isGrabbingHolders);

    }
    
    
    void FireCannon()
    {
        try
        { 
            CannonBall current = balls.Dequeue();
            current.Fire(transform.position,transform.forward,launchForce);
        }
        catch { Debug.Log("Queue Is empty"); }
        
    }
    
    private void BuildPool()
    {
        balls = new Queue<CannonBall>();
        for (int i = 0; i < maxProjectiles; i++)
        {
            GameObject temp = Instantiate(projectile);
            temp.name = "CanonBall " + i;
            balls.Enqueue(temp.GetComponent<CannonBall>());
        }    
    }
    
    
    


}
