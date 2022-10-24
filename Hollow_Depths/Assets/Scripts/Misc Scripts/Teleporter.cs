using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public GameObject sp1, sp2;
    private GameObject trig;
    
    void Start() {
        sp1 = this.gameObject;
    }

    void Update()
    {
        if (trig != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                trig.gameObject.transform.position = sp2.gameObject.transform.position;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            trig = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("Player entered teleporter");
            trig = collision.gameObject;
        }
    }

}
