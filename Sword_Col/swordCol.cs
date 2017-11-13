using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCol : MonoBehaviour {

    public GameObject bloodParticles;

    public bool killed;

    // Use this for initialization
    void Start()
    {

        killed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to destroy enemies on collision
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            GameObject bldPrt = Instantiate(bloodParticles, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            killed = true;
        }
    }
}
