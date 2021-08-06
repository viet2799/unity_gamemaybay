using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float timeToDestroy;

    Rigidbody2D m_rb;

    GameController m_gc;

    AudioSource aus;

    public AudioClip hitSound;

    public GameObject hitVFX;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.up * Speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // tang diem so
            m_gc.ScoreIncrement();

            if(aus && hitSound)
            {
                aus.PlayOneShot(hitSound);
            }

            if (hitVFX)
            {
                Instantiate(hitVFX, collision.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("SceneTopLimit")){
            Destroy(gameObject);
        }
    }
}
