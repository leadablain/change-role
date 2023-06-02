using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Cette annotation permet d'afficher la variable dans l'inspecteur Unity
public struct structTriggersScales
{
    public float seuil;
    public Vector3 scale;
}

public class ChangeScale : MonoBehaviour
{

    public bool trace;
    public bool reverse;
    public bool constraintFloor;
    public structTriggersScales nearLimit;
    public structTriggersScales farLimit;
    private Vector3 currentPos, currentScale;
    private float minDistance;

    //[Header("Contraintes")]
    // public Contraintes contraintesAxes;

    // Start is called before the first frame update
    void Start()
    {
        minDistance = 999f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = SingletonManager.GetPlayerPos();
        Vector3 currentPosSameY = transform.position;
        currentPosSameY.y = playerPos.y;
        float distance = Vector3.Distance(currentPosSameY, playerPos);

        if(reverse) changeScale(distance);
        else {
            if(distance < minDistance) {
                minDistance = distance;
                changeScale(minDistance);
            }
        }

        if (trace)
        {
            string traceTxt = gameObject.name+"/ChangeScale" +
                           " __ distance = " + distance +
                           " __ near = " + nearLimit.seuil +
                           " __ far = " + farLimit.seuil +
                           " __ scale = "+ currentScale;
            SingletonManager.WriteTrace(SingletonManager.GetModeVR(), traceTxt);
        }

    }

    void onTheFloor()
    {
        Renderer renderer = GetComponent<Renderer>();
        Bounds bounds = renderer.bounds;
        Vector3 size = bounds.size;
        currentPos = transform.position;
        currentPos.y = size.y/2;
        transform.position = currentPos;
    }

    void changeScale(float distance)
    {
        if(distance < nearLimit.seuil) { currentScale = nearLimit.scale; }
        else if(distance > farLimit.seuil) { currentScale = farLimit.scale; }
        else {
            currentScale = SingletonManager.MapV3(distance, nearLimit.seuil, farLimit.seuil, nearLimit.scale, farLimit.scale);
        }
        
        transform.localScale = currentScale;
        if(constraintFloor) onTheFloor();
    }

}
