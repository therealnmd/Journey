using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(1);
        }

        if (collision.CompareTag("Trap"))
        {
            Debug.Log("Ouch");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
