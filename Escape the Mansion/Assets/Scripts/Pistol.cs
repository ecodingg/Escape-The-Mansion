using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{
    //Variables
    private int bullets = 6;
    private int bulletHolder = 12;
    private int maxBulletHolder = 56;
    private InputAction fireAction, reloadAction;
    
    //Serialized Fields
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrel;
    [SerializeField] private PlayerInput tankInput;

    // Update is called once per frame
    void Update()
    {
        fireAction = tankInput.actions["Fire"];
        reloadAction = tankInput.actions["Reload"];
        
        Shoot();
        Reload();
        
    }

    //Shoot Function
    private void Shoot()
    {
        if(fireAction.triggered){
            if (bullets >= 1){
                Instantiate(bullet, barrel.position, barrel.rotation);
                bullets -= 1;
            }
        }
    }

    //Reload Function
    private void Reload()
    {
        if (reloadAction.triggered)
        {
            if (bulletHolder >= 6)
            {
                bullets = 6;
                bulletHolder -= 6;
            }
            else if (0 <= bulletHolder && bulletHolder <= 6)
            {
                bullets = bulletHolder;
                bulletHolder = 0;
            }
        }
    }
    
    public void AddBullets(int amount)
    {
        if (bullets + bulletHolder != maxBulletHolder)
        {
            bulletHolder += amount; 
        }
        else
        {
            Debug.Log("Max bullets reached");
        }
    }
}