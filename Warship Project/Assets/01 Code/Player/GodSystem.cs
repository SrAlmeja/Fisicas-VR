using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GodSystem : MonoBehaviour
{
    [SerializeField] private bool isGod;
    [SerializeField] private GameObject leftCloud, rightCloud;
    [SerializeField] private Transform leftCanon, rightCanon, godPosition;

    [SerializeField] private GameObject player;

    [SerializeField] private int scale;

    [SerializeField] InputActionReference _rightHandCanon;
    [SerializeField] InputActionReference _leftHandCanon;
    
    [SerializeField] InputActionReference _rightHandGod;
    [SerializeField] InputActionReference _leftHandGod;
    
    [SerializeField] InputActionReference _shoot;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        godPosition.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
        _leftHandCanon.action.performed += ctx => LeftCanon();
        _rightHandCanon.action.performed += ctx => RightCanon();
        
        _leftHandGod.action.performed += ctx => LeftCGod();
        _rightHandGod.action.performed += ctx => RightGod();
        
        _shoot.action.performed += ctx => Shoot();
    }
    
    
    void LeftCanon()
    {
        isGod = false;
        leftCloud.SetActive(false);
        rightCloud.SetActive(false);
        transform.position = new Vector3(leftCanon.transform.position.x,leftCanon.transform.position.y,leftCanon.transform.position.z);
    }
    void RightCanon()
    {
        isGod = false;
        leftCloud.SetActive(false);
        rightCloud.SetActive(false);
        transform.position = new Vector3(rightCanon.transform.position.x,rightCanon.transform.position.y,rightCanon.transform.position.z);
    }
    
    void LeftCGod()
    {
        isGod = false;
        leftCloud.SetActive(false);
        rightCloud.SetActive(false);
        transform.position = new Vector3(rightCanon.transform.position.x,rightCanon.transform.position.y,rightCanon.transform.position.z);
    }
    void RightGod()
    {
        isGod = false;
        leftCloud.SetActive(false);
        rightCloud.SetActive(false);
        transform.position = new Vector3(rightCanon.transform.position.x,rightCanon.transform.position.y,rightCanon.transform.position.z);
    }

    void Shoot()
    {
        
    }
    
}
