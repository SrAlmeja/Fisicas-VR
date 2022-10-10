using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CossionEvent : MonoBehaviour
{
    public event Action myCollision;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            myCollision?.Invoke();
        }
    }
}
