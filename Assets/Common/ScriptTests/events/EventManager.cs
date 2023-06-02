using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    // Définit un événement Unity nommé "myEvent"
    public UnityEvent myEvent;

    // Cette méthode est appelée à chaque image du jeu
    private void Update()
    {
        // Si la touche Espace est enfoncée, déclenche l'événement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myEvent.Invoke();
        }
    }
}


// En C#, il est possible d'envoyer un événement en utilisant le mécanisme des délégués et des événements.
// Tout d'abord, il faut définir un délégué pour l'événement :

// csharp
// public delegate void MyEventHandler(object sender, EventArgs e);

// Ensuite, il faut déclarer un événement de ce type dans la classe qui va générer l'événement :

// csharp
// public event MyEventHandler MyEvent;

// Pour déclencher l'événement, il suffit d'appeler la méthode qui le lance :

// csharp
// MyEvent?.Invoke(this, EventArgs.Empty);

// Le point d'interrogation permet de vérifier si l'événement a été correctement défini avant de lancer son invocation.
// Pour écouter cet événement depuis une autre classe, il faut souscrire à l'événement :

// csharp
// myClass.MyEvent += MyEventHandlerMethod;

// La méthode MyEventHandlerMethod sera appelée chaque fois que l'événement MyEvent sera déclenché.
// Enfin, pour se désinscrire de l'événement, il suffit d'utiliser l'opérateur -= :

// csharp
// myClass.MyEvent -= MyEventHandlerMethod;

// Cela supprime l'abonnement de la méthode MyEventHandlerMethod à l'événement MyEvent.