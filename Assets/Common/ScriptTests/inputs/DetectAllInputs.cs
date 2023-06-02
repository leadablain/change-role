using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectAllInputs : MonoBehaviour
{
    public XRController leftController;
    public XRController rightController;

    private void Update()
    {
        // Récupérer l'état des boutons et axes de la manette gauche
        if (leftController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool leftPrimaryButton) && leftPrimaryButton)
        {
            Debug.Log("Bouton X de la manette gauche pressé");
        }
        if (leftController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float leftTrigger) && leftTrigger > 0.5f)
        {
            Debug.Log("Gâchette de la manette gauche pressée à " + leftTrigger);
        }

        // Récupérer l'état des boutons et axes de la manette droite
        if (rightController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool rightPrimaryButton) && rightPrimaryButton)
        {
            Debug.Log("Bouton X de la manette droite pressé");
        }
        if (rightController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float rightTrigger) && rightTrigger > 0.5f)
        {
            Debug.Log("Gâchette de la manette droite pressée à " + rightTrigger);
        }
    }
}

// Oui, il est possible d'écrire un programme en C# qui détecte tous les inputs des manettes 
// d'un Oculus Quest 2 en utilisant le package XR Interaction Toolkit. 
// Voici un exemple de code qui utilise la méthode TryGetFeatureValue pour récupérer 
// les états de tous les boutons et axes des deux manettes :


// Dans cet exemple, nous utilisons la méthode TryGetFeatureValue de la classe InputDevice 
// pour récupérer l'état de chaque bouton et axe des deux manettes. 
// La variable leftController et rightController doivent être définies dans l'inspecteur 
// pour référencer les composants XRController des manettes.

// Notez que cet exemple détecte uniquement l'état des boutons et axes principaux des manettes. 
// Pour détecter d'autres boutons ou axes, vous devez utiliser les identificateurs appropriés 
// fournis par la documentation d'Oculus.