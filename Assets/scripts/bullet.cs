using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
   
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}