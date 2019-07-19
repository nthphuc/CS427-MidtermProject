using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public int maxJumps = 1;
    public int jumpCount = 0;
    public int isGameOver = 0;
    public int isFacedRight = 1;
    public int isFacedLeft = 0;
    public Transform shootingPoint;

    private gameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && isGameOver==0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));
            if (isFacedRight == 1)
            {   
                transform.Rotate(0f, 180f, 0f);
                isFacedLeft = 1;
                isFacedRight = 0;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && isGameOver==0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
            if (isFacedLeft == 1)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacedLeft = 0;
                isFacedRight = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount==0 && isGameOver==0)
        {
            jumpCount++;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed*0.75f);
        }
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            jumpCount = 0;
        }
        if (Input.anyKeyDown && isGameOver == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            isGameOver = 0;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level2");
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MenuUI");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            SoundManager.PlaySound("CollectGemSound");
            Destroy(collision.gameObject);
            gm.points++;
        }
        if (collision.CompareTag("GameOver"))
        {
            SoundManager.PlaySound("DieSound");
            gm.gameOverText.gameObject.SetActive(true);
            gm.gameOverText2.gameObject.SetActive(true);
            GetComponent<Rigidbody2D>().SetRotation(90);
            GetComponent<Animator>().enabled = false;
            isGameOver = 1;
        }
        if (collision.CompareTag("Level2Trigger") && gm.points==0)
        {
            SoundManager.PlaySound("VictorySound");
            gm.gameOverText.gameObject.SetActive(true);
            gm.gameOverText.text = "Victory";
            StartCoroutine(Wait());
        }
        if (collision.CompareTag("EndGame"))
        {
            SoundManager.PlaySound("VictorySound");
            gm.gameOverText.gameObject.SetActive(true);
            gm.gameOverText.text = "Victory";
            StartCoroutine(Wait2());
        }
    }
}
