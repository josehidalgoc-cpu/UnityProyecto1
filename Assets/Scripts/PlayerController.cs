using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 7f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    //public GameObject Bullet;
    //public GameManager myGameManager;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoroutine()); 
      // myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x, playerJumpForce);
        }
        myrigidbody2D.linearVelocity = new Vector2(playerSpeed, myrigidbody2D.linearVelocity.y);
        
        //if(Input.GetKeyDown(KeyCode.E))
        //{
          // Instantiate(Bullet, transform.position, Quaternion.identity);
        //}
    }

    // CORREGIDO: Se escribió correctamente 'WalkCoroutine'
    IEnumerator WalkCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            mySpriteRenderer.sprite = mySprites[index];
            index++;
            
            if (index == 5)
            {
                index = 0;
            }
        }
    }
}