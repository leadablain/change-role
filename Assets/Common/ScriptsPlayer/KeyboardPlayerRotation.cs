using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPlayerRotation : MonoBehaviour
{
    public float rotationSpeed;
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
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        if (Input.GetKey(keyNegative))
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);

    }


}
