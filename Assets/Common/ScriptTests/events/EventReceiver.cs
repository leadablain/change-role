using UnityEngine;
using UnityEngine.Events;


public class EventReceiver : MonoBehaviour
{
    // Cette méthode est appelée lorsque le composant est activé
    private void OnEnable()
    {
        // Trouve l'objet contenant l'EventManager et ajoute une méthode de gestionnaire d'événement à son événement
        EventManager eventManager = FindObjectOfType<EventManager>();
        eventManager.myEvent.AddListener(HandleEvent);
    }

    // Cette méthode est appelée lorsque le composant est désactivé
    // private void OnDisable()
    // {
    //     // Trouve l'objet contenant l'EventManager et retire la méthode de gestionnaire d'événement de son événement
    //     EventManager eventManager = FindObjectOfType<EventManager>();
    //     eventManager.myEvent.RemoveListener(HandleEvent);
    // }

    // Cette méthode est appelée lorsqu'un événement est déclenché
    private void HandleEvent()
    {
        // Affiche un message de débogage indiquant que l'événement a été reçu
        Debug.Log("Event received!");
    }
}