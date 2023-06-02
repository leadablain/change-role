using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Cette annotation permet d'afficher la variable dans l'inspecteur Unity
public struct structTriggersColors
{
    public float seuil;
    public Color couleur;
}

public class ChangeColors : MonoBehaviour
{

    public bool trace;
    public structTriggersColors[] SeuilsCouleurs;
    private Renderer render;    
  
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = SingletonManager.GetPlayerPos();
        Vector3 currentPosSameY = transform.position;
        currentPosSameY.y = playerPos.y;
        float distance = Vector3.Distance(currentPosSameY, playerPos);        

        structTriggersColors currentSeuil = TrouverSeuilApproprie(distance, SeuilsCouleurs);
        render.material.color = currentSeuil.couleur;

        if (trace)
        {
            string traceTxt = gameObject.name+"/ChangeColors" +
                           " __ distance = " + distance +
                           " __ seuil = " + currentSeuil.seuil +
                           " __ couleur = " + currentSeuil.couleur;
            SingletonManager.WriteTrace(SingletonManager.GetModeVR(), traceTxt);
        }

    }

        structTriggersColors TrouverSeuilApproprie(float valeur, structTriggersColors[] seuils)
        {
            structTriggersColors seuilApproprie = new structTriggersColors();

            for (int i = seuils.Length - 1; i >= 0; i--)
            {
                // Debug.Log("seuil : "+seuils[i].seuil);
                if (valeur >= seuils[i].seuil)
                {
                    seuilApproprie = seuils[i];
                    break;
                }
            }

            return seuilApproprie; 
        }

}
