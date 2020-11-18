using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject GameScore;
    float Score = 0;
    private int PowerUpCount;
    private int totalcount;
    private int PowerUpleft;

    // Start is called before the first frame update
    void Start()
    {
        totalcount = GameObject.FindGameObjectsWithTag("PowerUp").Length;

    }

    // Update is called once per frame
    void Update()
    {
        PowerUpleft = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        Debug.Log("Total Power Up left is " + PowerUpleft.ToString());
        GameScore.GetComponent<Text>().text = "Score: " + Score;
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Score == 4)
        {
            Debug.Log("Going Over to new Scene Now");
            SceneManager.LoadScene("WinScene");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PowerUp")
        {
            Destroy(other.gameObject);
            Score = Score+1;
        }
        if(other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
