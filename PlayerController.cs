using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count; //private will be used in this script only
    public Text countText;
    public Text winText;

    private void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
        rb = GetComponent<Rigidbody>();        
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
           if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            
        }
           if (other.gameObject.CompareTag("Sphere"))
        {
            Vector3 force = new Vector3(50, 50, 50);
            rb.AddForce(force);

            
           

        }

    }


    void SetCountText ()
    {
        countText.text = "Score :" + count.ToString();

        if (count >= 10)
        {
            winText.text = "YOU WIN - Press R to Restart";
        }
    }
}
