using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement: MonoBehaviour
{
    public float diagMin;
    public float diagMax;
    public float speed;
    public Text loseText;

    private int direction = -1;  // -1 means moving down and left. 1 means moving up and right
    private Rigidbody rb;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float xPos = GameObject.Find("Enemy").transform.position.x;        

        float moveHorizontal = 0;
        float moveVertical = 0;

        switch (direction)
        {
            case -1:
                if (xPos >= diagMin)
                {
                    moveHorizontal = -1;
                    moveVertical = -1;
                }
                else
                {
                    direction = 1;
                }
                break;

            case 1:
                if (xPos <= diagMax)
                {
                    moveHorizontal = 1;
                    moveVertical = 1;
                }
                else
                {
                    direction = -1;
                }
                break;


            default:
                break;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            loseText.color = Color.red;
            loseText.text = "Game Over!";
        }
    }
}






    