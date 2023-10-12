using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rd;
    [Range(0, 100), SerializeField] float speed;
    public int Collection;
    private Vector3 PlayerMove;
    //[SerializeField] Transform camara;
    [SerializeField] private GameObject coinPrefeb;
    private Vector3 offset;
    [SerializeField] private Transform coinContainer;
    [SerializeField] private int coinCount=10;
    [SerializeField] GameObject GameOverScrene;
    [SerializeField] GameObject GameWinScrene;
    [SerializeField] GameObject ScoreScrene;
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreText1;
    [SerializeField] private TextMeshProUGUI scoreText2;
    [SerializeField] private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        generateCoin();
       // InvokeRepeating(nameof(coin), 1f, 2f);
        //offset = camara.transform.position - transform.position;
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
            AudioManager.instance.Play("Coin");
            //audioManager.Play("Coin");
            score = score + 1;
        }
        
        Scores();
        if (Collection==coinCount)
        {
            Win();

        }
        
        if (collision.gameObject.CompareTag("wall"))
        {
            gameOver();
        }
    }

  

    private void gameOver()
    {
        Debug.Log("Game Over");
        GameOverScrene.SetActive(true);
        ScoreScrene.SetActive(false);
        AudioManager.instance.Play("Lose");
        AudioManager.instance.Stop("BG");
        scoreText.text = "Score: " + score;
        Time.timeScale = 0f;
    }
    private void Win()
    {
        Debug.Log("Win");
        GameWinScrene.SetActive(true);
        ScoreScrene.SetActive(false);
        AudioManager.instance.Play("Win");
        AudioManager.instance.Stop("BG");
        scoreText.text = "Score: " + score;
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Debug.Log("Start Game");
        AudioManager.instance.Stop("Win");
        AudioManager.instance.Play("BG");
        SceneManager.LoadScene(1);
        score =0;
        Time.timeScale = 1f;
    }

    public void Level2()
    {
        Debug.Log("Level 2");
        AudioManager.instance.Stop("Win");
        AudioManager.instance.Play("BG");
        SceneManager.LoadScene(2);
        score = 0;
        Time.timeScale = 1f;
    }
    public void Level3()
    {
        Debug.Log("Level 3");
        AudioManager.instance.Stop("Win");
        AudioManager.instance.Stop("BG");
        SceneManager.LoadScene(3);
        score = 0;
        Time.timeScale = 1f;
    }


    public void Exit()
    {
        //Application.Quit();
    }

    private void Scores()
    {
        ScoreScrene.SetActive(true);
        scoreText1.text = "Score: " + score;
        Time.timeScale = 1f;
    }


}
 