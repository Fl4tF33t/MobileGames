using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereContact : MonoBehaviour
{
    
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == this.gameObject.tag)
        {
            MultiTouchInput.score++;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);         
        }
    }
}
