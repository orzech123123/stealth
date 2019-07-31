using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("walking"))
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (transform.forward * 0.1f), 1.0f * Time.deltaTime);
        }
    }
}
