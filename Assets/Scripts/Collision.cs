using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32 (255,255,255,255);
    [SerializeField] Color32 noPackageColor = new Color32 (255,255,255,255);
    [SerializeField] float destroyDelay = 0.05f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    void OnTriggerEnter2D(Collider2D other)
    
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            FindObjectOfType<AudioManager>().Play("Gotchya");
            spriteRenderer.color = hasPackageColor;
            Debug.Log ("Gotchya!");
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Coop" && hasPackage)
        {
            hasPackage = false;
            FindObjectOfType<AudioManager>().Play("PackageDelivered");
            spriteRenderer.color = noPackageColor;
            Debug.Log ("In You Go!");
        }


        if (other.tag == "Obstacle")
        {
            Debug.Log ("Dang It!");
        }
    }
}
