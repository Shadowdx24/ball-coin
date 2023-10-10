using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private float transitionTime=5f;
    private Vector3 offser;
    // Start is called before the first frame update
    void Start()
    {
        offser = transform.position - ball.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Vector3.Slerp(transform.position,ball.position+offser,Time.deltaTime*transitionTime);
    }
}
