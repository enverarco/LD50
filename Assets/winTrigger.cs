using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject WinScreen;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            WinScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
