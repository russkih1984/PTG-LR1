using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public GameObject panel;  //������ �� ������, ������� ����� ���������� ��� �����������

    private void Start()
    {
        panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other) //����� ������������� ��� ����������� ��������
    {
        if (other.CompareTag("Player")) //���� ����������� ��������� � �������� ������� ��� �����
        {
            Time.timeScale = 0;         //��������� �������
            panel.SetActive(true);      //������������ ������
        }
    }

    public void nextLVL(string sceneName) //����� ��� �������� ������
    {
        // Debug.Log("sdsd");
        //Time.timeScale = 1;                  //�������������� ������� �������
        SceneManager.LoadScene("scene1");   //�������� ����� �� �����
        Time.timeScale = 1;
    }
}