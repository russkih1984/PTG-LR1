using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Lose : MonoBehaviour
{

    public GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }

    public void restart()
    {
       
        Time.timeScale = 1;  //восстановление течения времени
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //повторная загрузка текущей сцены

    }   


}