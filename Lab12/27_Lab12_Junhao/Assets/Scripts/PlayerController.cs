using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotatespeed;
    public GameObject CoinCollected;

    private int coinCount;
    private int totalCoin;
    // Start is called before the first frame update
    void Start()
    {
        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinCount == totalCoin)
        {
            //print("You Win!");
            SceneManager.LoadScene("WinScene");
        }
        if(transform.position.y <-5)
        {
            //print("You lose");
            SceneManager.LoadScene("LoseScene");
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * rotatespeed, 0));
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotatespeed, 0));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinCount++;
            CoinCollected.GetComponent<Text>().text = "Coin Clloected: " + coinCount;
            Destroy(other.gameObject);
        }
    }
}
