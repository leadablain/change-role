using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    public float speed = 5f;
    public float jumpspeed = 16f;
    public float jumpCoolDown = 0f;
    public float angularSpeed = 5f;
    public Rigidbody body; // ajouté quand passe dans le start

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = transform.position+ Vector3.up*10f; 
        body = GetComponent<Rigidbody>(); 

        // un test d'existence du rigid body pour montrer usage du start
        if(body == null){
            Debug.LogError("Il n'y a pas de rigid");
            Debug.Break();
        }         
    } 

    void updateMove() 
    {
        Vector3 move = new Vector3();
        move.x = speed * Input.GetAxis("Horizontal"); // clavier
        move.z = speed * Input.GetAxis("Vertical");   // clavier
        move.y = body.velocity.y; // gravité normale

        body.velocity = move; 
    }

    void updateJump() 
    {
        jumpCoolDown = jumpCoolDown - Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && jumpCoolDown <= 0) {
            jumpCoolDown = 1.5f;
            Vector3 move = body.velocity;
            move.y = jumpspeed;
            body.velocity = move;

            // vitesse de rotation aléatoire sur le cube
            body.angularVelocity =Random.onUnitSphere*angularSpeed;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + Vector3.up * 0.1f;

        // on va chercher le rigidbody associé à cet objet
        // Rigidbody body = GetComponent<Rigidbody>();    passé dans le start

        // ecriture 1
        // body.velocity = new Vector3(2f, 0f, 1f); //par seconde
        // rem : body.velocity = Vector3.right;
        // rem : body.velocity = new Vector3(1f, 0f, 0f);

        // ecriture 2
        // Vector3 move = new Vector3(2f, 0f, 1f);
        // move.x = Input.GetAxis("Horizontal");
        // move.y = Input.GetAxis("Vertical")
        // body.velocity = move;

        updateMove();
        updateJump();
    }

}
