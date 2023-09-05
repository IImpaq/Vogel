using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float flapStrength;
    private LogicScript logic;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && logic.IsBirdAlive())
            rigidbody.velocity = Vector2.up * flapStrength;

        if (gameObject.transform.position.y is > 17 or < -18)
            logic.GameOver();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        logic.GameOver();
    }
}
