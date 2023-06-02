using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownStartCloner : MonoBehaviour
{
    public int numOfClones = 10;

    // Start is called before the first frame update
    void Start()
    {
        // pour une fois
        // GameObject clone =  Instantiate(gameObject, transform.parent);
        // Destroy(clone.GetComponent<CrownStartCloner>());
        // float yAngle = Random.Range(0f, 360f);
        // clone.transform.Rotate(0f, yAngle, 0f);

        // pour n fois
        for(int i = 0 ; i < numOfClones; i++)      {
            MakeAClone();
        }

    }

    void MakeAClone() {
        GameObject clone =  Instantiate(gameObject, transform.parent);
        // nécessaire de détruire script sur le clone pour ne pas avoir de mise en abime 
        Destroy(clone.GetComponent<CrownStartCloner>()); 
        float yAngle = Random.Range(0f, 360f);
        clone.transform.Rotate(0f, yAngle, 0f);

        // pour changer la vitesse de rotation
        Rotate rotate = clone.GetComponent<Rotate>();
        rotate.rotationSpeed = new Vector3(0f, Random.Range(20f, 30f));

        // pour change la taille
        clone.transform.GetChild(0).localScale = Vector3.one * Random.Range(0.2f, 1f);
    }
}
