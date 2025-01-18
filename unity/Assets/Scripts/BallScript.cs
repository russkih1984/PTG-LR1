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
    
    public Camera MainCamera; //ссылка на основную камеру
    public LayerMask background; //ссылка на слой заднего фона
    
    [Range(10,100)]
    public float forceLimit = 100; //max сила удара
    [Range(10, 300)]
    public float forceRate = 10; //скорость накопления силы удара
    float force = 0;             //текущая сила удара
    public Text power;


    LineRenderer lineRenderer; //ссылка на линию
    Rigidbody rb; //ссылка на физическое тело
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
       
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition); //проекция курсора мыши на задний фон

        lineRenderer.SetPosition(0, transform.position); //установка позиции точек линии
        lineRenderer.SetPosition(1, transform.position);

        if (Physics.Raycast(ray, out hit, 100, background)) //обнаружение точки пересечения курсора и заднего фона
        {
            Vector3 p = hit.point;
           // p.z = transform.position.y;  //выравнивание позиции точки пересечения по оси z

            Vector3 dir = (p - transform.position); //вычисление вектора между позицией игрока и точкой пересечения
            dir.Normalize();
           // Debug.Log("!!!!!!");

            //рисование вектора от позиции игрока в сторону позиции точки пересечения мыши и заднего фона
            //длина вектора зависит от силы удара
            lineRenderer.SetPosition(1, (transform.position + (dir * (force / 10 + 2) )));  //установка позиции линии

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
                float vert = Input.GetAxisRaw("Vertical");   //получение смещения по вертикали и горизонтали
                float hor = Input.GetAxisRaw("Horizontal");

                dir = new Vector3(hor, 0, vert);   //получение вектора направления смещения камеры
                dir.Normalize();                           //нормализация вектора направления смещения камеры

                dir = transform.TransformDirection(dir) * Time.fixedDeltaTime * 10; //вычисление скорости смещения камеры

                MainCamera.transform.position += dir;      //смещение камеры 


                }

        }
    }

   // public void setSpeed(float value)
   // {
   //     speed = value;
   //     val.text = speed.ToString();
    //}
}