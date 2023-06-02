using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneOnClic : MonoBehaviour
{
    public int numberOfClones = 3;

    private void OnMouseDown()
    {

        // la mort
        // Destroy(gameObject);   

        // la vie
        //Instantiate(gameObject);
        for (var i = 0; i < numberOfClones; i++)
        {
            GameObject clone = Instantiate(gameObject);
            Destroy(clone, 1f);
        }

    }
}
