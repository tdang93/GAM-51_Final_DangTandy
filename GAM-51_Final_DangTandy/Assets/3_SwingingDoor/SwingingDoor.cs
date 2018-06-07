using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingDoor : MonoBehaviour {
    public GameObject player;
    public Rigidbody rb;
    public GameObject hinge;
    public float timer;

    void Start() {
        timer = 0;
        rb = GetComponent<Rigidbody>();
        //openPosition = transform.position + transform.right * 2;
        //closePosition = transform.position;
    }

    void FixedUpdate() {
        if((transform.position - player.transform.position).magnitude < 3) { // within view distance
            if(transform.rotation.x < 90) { // not at max open position
                Debug.Log("Swing");
                
            }
        }
        else {
            if(transform.position.x >= 1) {
                if(timer <= 3) {
                    timer += Time.fixedDeltaTime;
                }
                else {
                    Debug.Log("3 seconds over!");
                    if(transform.position.x > 1) {
                        rb.velocity = -transform.right;
                    }
                }
            }
            else {
                if(transform.position.x > 1) {
                    rb.velocity = -transform.right;
                }
            }

        }
    }
}
