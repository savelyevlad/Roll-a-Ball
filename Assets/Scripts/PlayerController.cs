using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private int coinsCount = 0;
    private Rigidbody rigidbody;
    
    public float speed;
    public Text countText;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        countText.text = "Count: " + coinsCount;
    }

    private void FixedUpdate() {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rigidbody.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")) {
            Destroy(other.gameObject);
            ++coinsCount;
            countText.text = "Count: " + coinsCount;
        }
    }
}
