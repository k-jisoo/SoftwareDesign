using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    float h;
    float v;
    public float movespeed;
    
    
    

    
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(h, v) * Time.deltaTime * movespeed);

   
        
        
       
    }


}
