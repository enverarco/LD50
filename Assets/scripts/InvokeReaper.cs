using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeReaper : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float interval = 100;
    
    [SerializeField]
    private float counter = 0;

    [SerializeField]
    private float max_counter = 10;

    [SerializeField]
    private float reapersInPlay = 1;

    [SerializeField]
    private float maxReapersInPlay = 10;

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += 1;

        if(counter >= interval && reapersInPlay <= maxReapersInPlay){
            counter = 0;
            reapersInPlay += 1;
            Instantiate(enemyPrefab, transform.position,transform.rotation);
        }
    }
}
