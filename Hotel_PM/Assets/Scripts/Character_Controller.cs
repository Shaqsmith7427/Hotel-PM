using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] public float p_speed = 10.0f;
    [SerializeField] public float t_speed = 3.0f;
    [SerializeField] public float spr_speed = 5.0f;

     Rigidbody p_Rigidbody;
     public Flashlight flash;

    // Start is called before the first frame update
    void Start()
    {
        p_Rigidbody = GetComponent<Rigidbody>();
        //flash = GetComponent<Flashlight>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vert = Input.GetAxis("Vertical");

        vert *= Time.deltaTime;
        transform.Translate(0, 0, vert * p_speed);

        bool isTurningLeft = Input.GetKey(KeyCode.A);
        bool isTurningRight = Input.GetKey(KeyCode.D);
        if (isTurningLeft && !isTurningRight)
        {
            transform.Rotate(Vector3.down * t_speed);
        }

        else if (!isTurningLeft && isTurningRight)
        {
            transform.Rotate(Vector3.up * t_speed);
        }

       /* bool isRunning = Input.GetKeyDown("Space");
        bool isNotRunning = Input.GetKeyDown("Space");


        if (isRunning)
        {
            transform.Translate(0, 0, vert * spr_speed);
        }
        else if (isNotRunning)
                {
                    transform.Translate(0, 0, vert * p_speed);
                }*/
    }

    private void OnTriggerEnter(Collider other)
    { Debug.Log("Collided");
        if (other.gameObject.CompareTag("Battery"))
        {
            other.gameObject.SetActive(false);
            flash.flashlight.intensity += 1;
        }
       
    }
}

