using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    float xDirection;
    float yDirection;
    public GameObject projectile;

    public Transform shootingPoint;

    GameController m_gc;

    public AudioSource aus;

    public AudioClip shootingSound;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.IsGameover())
        {
            return;
        }

        yDirection = Input.GetAxisRaw("Vertical");
        xDirection = Input.GetAxisRaw("Horizontal");
        float xStep = xDirection * moveSpeed * Time.deltaTime;
        float yStep = yDirection * moveSpeed * Time.deltaTime;

        if ((transform.position.x < -11 && xDirection < 0) || (transform.position.x > 11 && xDirection > 0)
            || (transform.position.y < -4.5f && yDirection < 0) || (transform.position.y > 4 && yDirection > 0))
            return;

        transform.position += new Vector3(xStep, yStep, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (projectile && shootingPoint)
        {
            if(aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);
            }
            Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            m_gc.SetGameoverState(true);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("va cham");
        }
    }
}
