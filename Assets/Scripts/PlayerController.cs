using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // <-- IMPORTANTE: Necesario para cambiar de escena

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameObject Bullet;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
        if (mySprites != null && mySprites.Length > 0)
        {
            StartCoroutine(WalkCoRutine());
        }
    }

    void Update()
    {
        // Nota: Si usas Unity 2022 o inferior, cambia linearVelocity por velocity
        myrigidbody2D.linearVelocity = new Vector2(playerSpeed, myrigidbody2D.linearVelocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Mantiene la velocidad horizontal mientras salta
            myrigidbody2D.linearVelocity = new Vector2(playerSpeed, playerJumpForce);
        }

        if (Input.GetKeyDown(KeyCode.F))
{
    // Cambiamos 'transform.position' por esta posición fija más adelante
    Instantiate(Bullet, transform.position + new Vector3(2f, 0, 0), Quaternion.identity);
}
    }

    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.08f);

        if (mySprites != null && mySprites.Length > 0)
        {
            mySpriteRenderer.sprite = mySprites[index];
            index++;

            if (index >= mySprites.Length)
            {
                index = 0;
            }
        }
        
        StartCoroutine(WalkCoRutine());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            Debug.Log("¡Has recogido un corazón!");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("ItemBad"))
        {
            Debug.Log("¡Has chocado con un obstáculo!");
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.CompareTag("DeathZone"))
        {
            Debug.Log("¡Has caído en la zona de muerte!");
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        SceneManager.LoadScene("GameOver"); // <-- CORREGIDO AQUÍ
    }
}