using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoContainer : MonoBehaviour
{
    [SerializeField] private Pistol gun;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 20 * Time.deltaTime, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("Collision detected!");
        
        if (collision.collider.tag == "Player")
        {
            gun.AddBullets(12);
            Destroy(this.gameObject);
        }
    }
}
