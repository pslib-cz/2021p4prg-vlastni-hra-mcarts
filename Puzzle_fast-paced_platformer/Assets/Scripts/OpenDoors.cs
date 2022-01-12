using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    // Start is called before the first frame update
    Animator an;
    BoxCollider2D bc;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        an = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDoor(/*Animator anim*/)
    {
                
        an.Play("Gate");
    }
}
