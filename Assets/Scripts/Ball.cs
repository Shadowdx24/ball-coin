using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rd;
    [Range(0, 100), SerializeField] float speed;
    public int Collection;
    private Vector3 PlayerMove;
    [SerializeField] Transform camara;
    [SerializeField] private GameObject coinPrefeb;
    private Vector3 offset;
    [SerializeField] private Transform coinContainer;
    [SerializeField] private int coinCount=10;

    // Start is called before the first frame update
    void Start()
    {
        generateCoin();
       // InvokeRepeating(nameof(coin), 1f, 2f);
        offset = camara.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W)) 
        //{
        //    rd.velocity = Vector3.forward *speed;
        //    Debug.Log(rd.velocity);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    rd.velocity = Vector3.left  * speed;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    rd.velocity = Vector3.right * speed;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    rd.velocity = Vector3.back * speed;
        //}

    }
    private void FixedUpdate()
    {
        float x=Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 m =new Vector3(x, 0f, z);

        rd.AddForce(m*speed);
    }
    
    void generateCoin()
    {
        
        
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-21, 21), 0.97f, Random.Range(-19, 19));
            Quaternion rot = Quaternion.Euler(90, 0, 0);
            GameObject coin= Instantiate(coinPrefeb,pos,rot,coinContainer);
            coin.SetActive(true);
        }

    }
    
    
    

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);

        if (collision.gameObject.tag=="coin")
        {
            Destroy(collision.gameObject);
            Collection++;
           
        }
    }

}
