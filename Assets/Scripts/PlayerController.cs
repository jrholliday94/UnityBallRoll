using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

    public AudioClip soundEffect;
    public AudioSource soundSource;
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private GameObject[] coins;
    private int coinCount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        soundSource.clip = soundEffect;
        coins = GameObject.FindGameObjectsWithTag("Pick Up");
        coinCount = coins.Length;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            soundSource.Play();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= coinCount)
        {
            winText.color = Color.green;
            winText.text = "You win!";
        }
    }


}
