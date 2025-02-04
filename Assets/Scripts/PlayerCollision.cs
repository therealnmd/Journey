using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private Animator animator;
    private bool isFireOn = false;
    private float fireActivationDelay = 3f;
    private float fireActivationTime = 2f;
    [SerializeField] private GameObject flameCollider;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        animator = GameObject.FindWithTag("Trap").GetComponent<Animator>();
        if (animator != null)
        {
            StartCoroutine(ControlFireTrap());
        }
    }

    private IEnumerator ControlFireTrap()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireActivationDelay); // Chờ trước khi bật lửa
            isFireOn = true;
            animator.SetBool("isOn", true); // Kích hoạt trạng thái "On" của bẫy lửa
            //flameCollider.SetActive(true);
            yield return new WaitForSeconds(fireActivationTime); // Chờ lửa tắt
            isFireOn = false;
            animator.SetBool("isOn", false); // Quay về trạng thái "Off"
            //flameCollider.SetActive(false);
        }
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
            gameManager.HitTrap(1);
        }

        if (collision.CompareTag("Trap"))
        {
            if (isFireOn)
            {
                gameManager.HitTrap(1);
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            gameManager.HitTrap(1);
        }

        if (collision.CompareTag("End"))
        {
            gameManager.HitEnd();
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
