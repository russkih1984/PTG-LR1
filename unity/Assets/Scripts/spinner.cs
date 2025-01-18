using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinner : MonoBehaviour
{

    [Range(1, 300)]
    public float speed = 100;     //скорость вращения
    public bool clockwise = true; //направление вращения( по часовой стрелке?)
    Rigidbody rb;                 //ccылка на физическое тело

    Vector3 m_EulerAngleVelocity; //переменная для хранения скорости вращения в виде поворота вокруг оси Z


    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 0, speed);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion deltaRotation;    //смещение

        if (clockwise)   //если вращение по часовой стрелке, вычисление поворота в виде кватерниона
            deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime * -1);
        else //если вращение против часовой стрелки
            deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);

        rb.MoveRotation(rb.rotation *  deltaRotation);  //применение вращения к физическому телу

    }
}