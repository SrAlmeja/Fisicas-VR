using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    
    
    void Start()
    {
        ForEach(var item in GetComponentInChildren<Rigidbody>())
        {
            if (item.gameObject != this.gameObject)
            {
                Rigidbody<>
            }
            
        }    
    }

    
    void Update()
    {
        
    }
}
