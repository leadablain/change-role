using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPlayerController : MonoBehaviour
{
    public Vector3 speed;
    public KeyCode keyPositive;
    public KeyCode keyNegative;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(keyPositive))
            GetComponent<Rigidbody>().velocity += speed;
        if (Input.GetKey(keyNegative))
            GetComponent<Rigidbody>().velocity -= speed;

    }


}
