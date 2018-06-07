using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour {
    public InputField input;
    //public float explosionRadius;
    public float explosionForce;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) {
            if(float.Parse(input.text) > 0 && float.Parse(input.text) < float.MaxValue) {
                Explode(float.Parse(input.text));
            }
        }   
    }

    void Explode(float explosionRadius) {
        Debug.Log("Explode()");
        Collider[] hits;
        hits = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider c in hits) {
            if(c.GetComponent<Rigidbody>()) {
                Rigidbody rb = c.GetComponent<Rigidbody>();
                rb.velocity = (c.transform.position - gameObject.transform.position).normalized * explosionForce;
            }
        }
    }
}
