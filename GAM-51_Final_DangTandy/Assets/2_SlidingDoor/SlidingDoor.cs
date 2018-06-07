using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour {
    public GameObject player;
    public Rigidbody rb;
    public Vector3 openPosition;
    public Vector3 closePosition;
    public float timer;

    void Start() {
        timer = 0;
        rb = GetComponent<Rigidbody>();
        openPosition = transform.position + transform.right * 2;
        closePosition = transform.position;
    }

    void FixedUpdate() {
        if((transform.position - player.transform.position).magnitude < 3) { // within view distance
            if(transform.position.x < openPosition.x) { // not at max open position
                Debug.Log("Right");
                rb.velocity = transform.right;
            }
        }
        else {
            if(transform.position.x >= openPosition.x) {
                if(timer <= 3) {
                    timer += Time.fixedDeltaTime;
                }
                else {
                    Debug.Log("3 seconds over!");
                    if(transform.position.x > closePosition.x) {
                        rb.velocity = -transform.right;
                    }
                }
            }
            else {
                if(transform.position.x > closePosition.x) {
                    rb.velocity = -transform.right;
                }
            }

        }
    }
}
