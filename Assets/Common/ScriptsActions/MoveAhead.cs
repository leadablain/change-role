using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Cette annotation permet d'afficher la variable dans l'inspecteur Unity
public struct structAhead
{
    public GameObject objectId;
    public Vector3 initialPos;
    public Vector3 finalPos;
}

public class MoveAhead : MonoBehaviour
{
    public bool trace;
    public float nearLimit, farLimit;
    public structAhead[] Ahead;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Ahead.Length ; i++){
            Ahead[i].initialPos = Ahead[i].objectId.transform.position;
            //Debug.Log("ici" + Ahead[i].initialPos);            
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = SingletonManager.GetPlayerPos();
        Vector3 currentPosSameY = transform.position;
        currentPosSameY.y = playerPos.y;
        float distance = Vector3.Distance(currentPosSameY, playerPos);     

        foreach (structAhead objet in Ahead)
        {
            changePos(distance, objet);
        }

        void changePos(float distance, structAhead objet)
        {
            Vector3 objetPos;
            if (distance < nearLimit) { objetPos = objet.finalPos; }
            else if (distance > farLimit) { objetPos = objet.initialPos; }
            else
            {
                objetPos = SingletonManager.MapV3(distance, nearLimit, farLimit, objet.finalPos, objet.initialPos);
            }
            objet.objectId.transform.position = objetPos;

            if (trace)
            {
                string traceTxt = gameObject.name+"/MoveAhead" +
                               " __ distance = " + distance +
                               " __ near = " + nearLimit +
                               " __ far = "+ farLimit +
                               " __ newPos = " + objet.initialPos +
                               " __ objectPos = " +objetPos;
                SingletonManager.WriteTrace(SingletonManager.GetModeVR(), traceTxt);
            }




        }
        
    }
}
