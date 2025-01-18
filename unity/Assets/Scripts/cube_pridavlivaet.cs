using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_pridavlivaet : MonoBehaviour
{
    //Rigidbody rb;
    public GameObject panel;
   public static bool enable1 = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
       // rb = GetComponent<Rigidbody>();
      //  rb.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (enable1 == true)
        {
          
            
            if (collision.collider.CompareTag("Player"))
            {
              
                Time.timeScale = 0;
                panel.SetActive(true);
               
            }
            if (collision.collider.CompareTag("pol"))
            {
               // Debug.Log("pol");
                gameObject.SetActive(false);
            }
        }

    }
}