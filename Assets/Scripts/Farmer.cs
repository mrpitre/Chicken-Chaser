using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{

    [SerializeField] float turnSpeed = 1f;
    [SerializeField] float moveSpeed = 1f;

    [SerializeField] float slowSpeed = 1f;

    [SerializeField] float boostSpeed = 5f;

    [SerializeField] float destroyDelay = 0.05f;

    //[SerializeField] float slowDuration = 3f;

    bool hasBoost = false;

    

    // Update is called once per frame
    void Update()
    {
        float turnAmount = Input.GetAxis ("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-turnAmount); 
        transform.Translate(0,moveAmount,0);

    }    

    void OnTriggerEnter2D (Collider2D other)
    
    {
        if (other.tag == "Boost")
        {
            hasBoost = true;
            moveSpeed = boostSpeed;
            FindObjectOfType<AudioManager>().Play("YeeHaw");
            Debug.Log ("YeeHaw!");
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Obstacle")
        {
            hasBoost = false;
            moveSpeed = slowSpeed;

            FindObjectOfType<AudioManager>().Play("Dang");
            Debug.Log ("Dang It!");
        }


        


    }
}
