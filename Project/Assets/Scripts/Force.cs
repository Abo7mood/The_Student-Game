//NOTE I CANCEL THIS SCRIPT SO YOU DONT HAVE TO USE IT OK?
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    //rigidbody to implement physics
    Rigidbody rb;
    //the speed of the books
    [SerializeField] float speed;
    //the max speed of the books
    [SerializeField] float _maxSpeed;
    //Direction of the books
    private Vector3 Direction;
    //here is some randomization but i cancel it because it will take a bunch of time
    int[] randomization = {44,2 ,3, 4, 5, 6};
    //another rand = random = take a number from the randomization int 
    int rand;
    //here is a reference for the rigidbody 
    private void Awake()=> rb = GetComponent<Rigidbody>();
    //you know this right 
    private void Start()=>  rand = Random.Range(0, 6);       
    //ok this is the direction to make books go forward 
    private void Update() => Direction = new Vector3(speed * -1, 0, 0);






}
