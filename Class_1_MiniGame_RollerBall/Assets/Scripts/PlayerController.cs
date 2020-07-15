using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ScoreManager;
    public float moveHorizontal;
    public float moveVertical;
    public Rigidbody rb;
    void Start()
    {
        //rb = new Rigidbody();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(move * Time.deltaTime * 900.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PickUps"))
        {
            other.gameObject.SetActive(false);
            int point = other.gameObject.GetComponent<PickupsMovement>().Point;
            ScoreManager.GetComponent<ScoreManager>().GetPoint(point);
        }
    }
}
