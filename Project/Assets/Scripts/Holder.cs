using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    //reference for player script
    PlayerMovement _player;
    //reference for rigidbody to implement physics
    Rigidbody _rb;
    private void Awake()
    {   //reference for rigidbody to implement physics
        _rb = GetComponent<Rigidbody>();
        //reference for player script
        _player = FindObjectOfType<PlayerMovement>();
    }
    //this is complicated you can see what is it on youtube 
    private void OnTriggerEnter(Collider other)
    {
        //if the gameobject name is Dead = the gameobject dead is a plane on the scene 
        if (other.name == "Dead")
        {
            //freeze the rigidbody (physics)
            _rb.constraints = RigidbodyConstraints.FreezeAll;
            //call a function inside the player
            _player.DeadChecker();
           //destroy this gameobject (the book)
            Destroy(gameObject);
            //Lose
        }
        //you are a progarmmer so i dont expalin what is if statement and int and float etc
        else
          return;
          
        
    }



}
