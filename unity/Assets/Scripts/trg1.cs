using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trg1 : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Cube1;
   // public GameObject Cube2;
    // Start is called before the first frame update
    void Start()
    {
        Cube.SetActive(false);
        Cube1.SetActive(false);
       // Cube2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") == true)  // пересечение игрока с триггером
                {
                    Cube.SetActive(true);
                    Cube1.SetActive(true);
                   // Cube2.SetActive(true);
                }

    }

}