using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public GameObject panel;  //ссылка на панель, которая будет появляться при пересечении

    private void Start()
    {
        panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other) //метод срабатывающий при пересечении объектов
    {
        if (other.CompareTag("Player")) //если пересечении произошло с объектом имеющим тег игрок
        {
            Time.timeScale = 0;         //остановка времени
            panel.SetActive(true);      //демонстрация панели
        }
    }

    public void nextLVL(string sceneName) //метод для загрузки уровня
    {
        // Debug.Log("sdsd");
        //Time.timeScale = 1;                  //восстановление течении времени
        SceneManager.LoadScene("scene1");   //загрузка сцены по имени
        Time.timeScale = 1;
    }
}