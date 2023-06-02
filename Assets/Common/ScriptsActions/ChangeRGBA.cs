using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Cette annotation permet d'afficher la variable dans l'inspecteur Unity
public struct structTriggersRGBA
{
    public float seuil;
    public Color couleur;
}

public class ChangeRGBA : MonoBehaviour
{

    public bool trace;
    public bool reverse;
    public structTriggersRGBA nearLimit;
    public structTriggersRGBA farLimit;

    private Vector3 currentPos;
    private Color currentColor;
    private float minDistance;
    private Renderer render;

    //[Header("Contraintes")]
    // public Contraintes contraintesAxes;

    // Start is called before the first frame update
    void Start()
    {
        minDistance = 999f;
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = SingletonManager.GetPlayerPos();
        Vector3 currentPosSameY = transform.position;
        currentPosSameY.y = playerPos.y;
        float distance = Vector3.Distance(currentPosSameY, playerPos);

        if(reverse) changeRGBA(distance);
        else {
            if(distance < minDistance) {
                minDistance = distance;
                changeRGBA(minDistance);
            }
        }

        if (trace)
        {
            string traceTxt = gameObject.name+"/ChangeRGBA" +
                           " __ distance = " + distance +
                           " __ near = " + nearLimit.seuil +
                           " __ far = " + farLimit.seuil +
                           " __ color = "+ currentColor;
            SingletonManager.WriteTrace(SingletonManager.GetModeVR(), traceTxt);
        }
    }

    void changeRGBA(float distance)
    {
        if(distance < nearLimit.seuil) { currentColor = nearLimit.couleur; }
        else if(distance > farLimit.seuil) { currentColor = farLimit.couleur; }
        else {
            currentColor = SingletonManager.MapColor(distance, nearLimit.seuil, farLimit.seuil, nearLimit.couleur, farLimit.couleur);
        }
        
        render.material.color = currentColor;
    }

}
