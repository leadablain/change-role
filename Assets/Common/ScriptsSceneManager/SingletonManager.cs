using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{

    public static bool modeVirtualReality;
    private static Vector3 playerPosition;

    // MODE 3D/VR
    public static void SetModeVR(bool value)
    {
        modeVirtualReality = value;
    }
    public static bool GetModeVR()
    {
        return modeVirtualReality;
    }

    // PLAYER POSITION
    public static void SetPlayerPos(Vector3 value) { 
        playerPosition = value; 
    }
    public static Vector3 GetPlayerPos() { 
        return playerPosition; 
    }

    // MAP
    public static Vector3 MapV3(float value, float fromLow, float fromHigh, Vector3 toLow, Vector3 toHigh)
    {
        float t = Mathf.InverseLerp(fromLow, fromHigh, value);
        return Vector3.Lerp(toLow, toHigh, t);
    }

    public static Color MapColor(float value, float fromLow, float fromHigh, Color toLow, Color toHigh)
    {
        float t = Mathf.InverseLerp(fromLow, fromHigh, value);
        return Color.Lerp(toLow, toHigh, t);
    }

    // AFFICHAGE TRACE
    public static void WriteTrace(bool modeVR, string traceTxt)
    {                       
        if (SingletonManager.GetModeVR())
        {
            TextMesh console;
            console = GameObject.Find("My Console").GetComponent<TextMesh>();
            console.text = traceTxt.Replace(" __", "\n");
        }
        else
        {
            Debug.Log(traceTxt);
        }
    }

}
