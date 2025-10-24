using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{
    //Variables
    private float maxBullets = 6;
    private float bullets;
    private InputAction fireAction;
    
    //Serialized Fields
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrel;
    [SerializeField] private PlayerInput tankInput;
    
    void Start()
    {
        bullets = maxBullets;   
    }

    // Update is called once per frame
    void Update()
    {
        fireAction = tankInput.actions["Fire"];
        
        if(fireAction.triggered){
            if (bullets >= 1){
                Instantiate(bullet, barrel.position, barrel.rotation);
                bullets -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.R)){
            bullets = maxBullets;
        }
    }

    public float bulletCount(){
        return bullets;
    }
}