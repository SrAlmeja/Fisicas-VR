using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    private float elapsedTime, coldown=2f;
    [SerializeField] private GameObject MRBeen;
    private Vector3 beenSpawn;

    private void Awake()
    {
        FindColiders();
    }

    [SerializeField] float HP = 10;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    private void GetEvent()
    {
        if (elapsedTime < coldown) return;
        GetDamage(1);
        elapsedTime = 0;
    }

    private  void FindColiders()
    {
        foreach (var item in gameObject.GetComponentsInChildren<Collider>())
        {
            item.AddComponent<CossionEvent>();
        }

        foreach (var item2 in gameObject.GetComponentsInChildren<CossionEvent>())
        {
            item2.myCollision += GetEvent;
        }
    }
    
    
    void GetDamage(float amount)
    {
        HP -= amount;
        Debug.Log(HP);
        animator.ResetTrigger("Idle");
        animator.SetTrigger("Hit");
        
        if (HP <= 0)
        {
            YouAreDead();    
        }
        
    }

    void YouAreDead()
    {
        animator.ResetTrigger("Idle");
        animator.ResetTrigger("Hit");
        animator.SetTrigger("Die");
        StartCoroutine(Die());
    }
    
    

    IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        animator.enabled = false;
        StartCoroutine(HeDie());
    }

    IEnumerator HeDie()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(Reborn());
    }

    IEnumerator Reborn()
    {
        yield return new WaitForSeconds(1);
        animator.ResetTrigger("Die");
        animator.ResetTrigger("Hit");
        animator.SetTrigger("Idle");
    }
}
