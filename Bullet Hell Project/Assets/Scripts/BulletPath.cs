using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPath : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    // Start is called before the first frame update

//Destroy the bullet if it goes off screen
    void OnBecameInvisible()
    {
        Debug.Log("Bullet Destroyed");
        Destroy(gameObject);
    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatingMovement();
    }

    public void VerticalMovement(){
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }

    //Function to make the bullet rotate after 3 second of having been spawned
    public void RotatingMovement()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            transform.Rotate(0, 1,0);
    }
    public void RotatingMovementNegative()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(0, -1, 0);
    }
}
