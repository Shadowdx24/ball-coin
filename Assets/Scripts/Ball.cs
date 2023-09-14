using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rd;
    [Range(0, 100), SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) 
        {
            rd.velocity=Vector3.forward*Time.deltaTime*speed;
        }
        else if (Input.GetKey("a"))
        {
            rd.velocity = Vector3.left * Time.deltaTime * speed;
        }
        else if (Input.GetKey("d"))
        {
            rd.velocity = Vector3.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey("s"))
        {
            rd.velocity = Vector3.back * Time.deltaTime * speed;
        }

    }
}
