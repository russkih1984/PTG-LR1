using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trg2 : MonoBehaviour
{
    public GameObject cube1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {
        //Debug.Log("srablotallo");
        if (other.CompareTag("Player"))
        {
            cube1.GetComponent<Rigidbody>().isKinematic = false;
            cube_pridavlivaet.enable1 = true;
        }

    }
}