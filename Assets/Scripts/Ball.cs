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
    [SerializeField] public List<GameObject> coins;
    [SerializeField] private Transform coinContainer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(coin), 1f, 2f);
        offset = camara.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            rd.velocity=Vector3.forward*Time.deltaTime*speed;
            Debug.Log(rd.velocity);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rd.velocity = Vector3.left * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rd.velocity = Vector3.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rd.velocity = Vector3.back * Time.deltaTime * speed;
        }

    }
    void coin()
    {
        GameObject coin = coins.Find(x => !x.activeInHierarchy);

        Vector3 pos=new Vector3(Random.Range(-21, 21), 0.97f, Random.Range(-19,19));
        Quaternion rot=Quaternion.Euler(90,0,0);
       
        if(coin==null)
        {
            Instantiate(coinPrefeb, pos, rot,coinContainer);
        }
        else
        {
            coin.transform.position = pos;  
            coin.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);

        if (collision.gameObject.tag=="coin")
        {
            collision.gameObject.SetActive(false);
            Collection++;
           
        }
    }

}
