using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoveController : MonoBehaviour
{
    float speed = 1f;
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.isOver)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        
    }
}
