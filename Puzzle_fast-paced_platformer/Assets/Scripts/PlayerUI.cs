using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _score;
    public GameObject _playerUI;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        _playerUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        int number = (int)sr.gameObject.transform.position.y;
        int score = Int32.Parse(_score.text);
        if(number > score)
        {
            _score.text = number.ToString();
        }
    }
}
