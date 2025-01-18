using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour { 

    //[Range(0f, 1000f)]
   // public float speed = 0;
  //  public Text val;
    
    public Camera MainCamera; //������ �� �������� ������
    public LayerMask background; //������ �� ���� ������� ����
    
    [Range(10,100)]
    public float forceLimit = 100; //max ���� �����
    [Range(10, 300)]
    public float forceRate = 10; //�������� ���������� ���� �����
    float force = 0;             //������� ���� �����
    public Text power;


    LineRenderer lineRenderer; //������ �� �����
    Rigidbody rb; //������ �� ���������� ����
    RaycastHit hit;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        power.text = "Power: " + force.ToShortString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        // Debug.Log("!!");
        //Input.GetAxis("Fire1");
        // rb.AddForce(transform.right * speed);
       
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition); //�������� ������� ���� �� ������ ���

        lineRenderer.SetPosition(0, transform.position); //��������� ������� ����� �����
        lineRenderer.SetPosition(1, transform.position);

        if (Physics.Raycast(ray, out hit, 100, background)) //����������� ����� ����������� ������� � ������� ����
        {
            Vector3 p = hit.point;
           // p.z = transform.position.y;  //������������ ������� ����� ����������� �� ��� z

            Vector3 dir = (p - transform.position); //���������� ������� ����� �������� ������ � ������ �����������
            dir.Normalize();
           // Debug.Log("!!!!!!");

            //��������� ������� �� ������� ������ � ������� ������� ����� ����������� ���� � ������� ����
            //����� ������� ������� �� ���� �����
            lineRenderer.SetPosition(1, (transform.position + (dir * (force / 10 + 2) )));  //��������� ������� �����

            if (Input.GetAxisRaw("Fire1") > 0)
                {
                if (force < forceLimit)
                    force += forceRate * Time.deltaTime;
                    power.text = "Power: " + force.ToShortString();
            } else
                if (force > 0)
                {
                    rb.AddForce(dir * force, ForceMode.Impulse);
                    force = 0;
                //lineRenderer.enabled = false;


                //camera  
                Debug.Log("camera");
                float vert = Input.GetAxisRaw("Vertical");   //��������� �������� �� ��������� � �����������
                float hor = Input.GetAxisRaw("Horizontal");

                dir = new Vector3(hor, 0, vert);   //��������� ������� ����������� �������� ������
                dir.Normalize();                           //������������ ������� ����������� �������� ������

                dir = transform.TransformDirection(dir) * Time.fixedDeltaTime * 10; //���������� �������� �������� ������

                MainCamera.transform.position += dir;      //�������� ������ 


                }

        }
    }

   // public void setSpeed(float value)
   // {
   //     speed = value;
   //     val.text = speed.ToString();
    //}
}