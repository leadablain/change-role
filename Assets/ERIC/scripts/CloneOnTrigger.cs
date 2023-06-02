using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneOnTrigger : MonoBehaviour
{
    public int cloneMax = 10;
    int cloneCount = 0;

    void OnTriggerEnter(Collider other) { // on récupèrer un composant du cube
        GameObject clone = Instantiate(other.gameObject); // on remonete au gameobject du cube pour le dupliquer
        bool check = clone.GetComponent<ScaleDownAndDestroy>() == null;
        if (check) {
            clone.AddComponent<ScaleDownAndDestroy>();
        }
        // durée de vie aléatoire
        clone.GetComponent<ScaleDownAndDestroy>().duration = Random.Range(1f,10f);

        cloneCount++;
        if (cloneCount == cloneMax){
            Destroy(gameObject); // on détruit alors le cloner
        }
    }

}
