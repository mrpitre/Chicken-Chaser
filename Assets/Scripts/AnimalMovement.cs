using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] float moveSpeed = 1f;

    

    // Update is called once per frame
    void Update()
    {
        float turnAmount =  turnSpeed * Time.deltaTime;
        float moveAmount =  moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-turnAmount); 
        transform.Translate(0,moveAmount,0);


    }
}
