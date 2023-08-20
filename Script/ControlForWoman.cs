using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlForWoman : MonoBehaviour
{
    float speed;
    public int helth;
    float MoveX;
    float MoveY;
    public float maxSpeed;
    public float normalSpeed;
    public float maxX, maxY, minX, minY;

    public Database data;
    public GameObject Shadow;
    Rigidbody2D rb;
    LineRenderer line;
    Animator ani;
    void Start()
    {
        helth = data.woman.helth;
        maxSpeed = data.woman.maxSpeed;
        normalSpeed = data.woman.normalSpeed;

        rb = GetComponent<Rigidbody2D>();
        MoveX = 0;
        MoveY = 0;
        line = FindObjectOfType<LineRenderer>();
        ani = GetComponent<Animator>();
        speed = normalSpeed;
        Instantiate(Shadow, transform.position - new Vector3(0, 0.9f, 0), Quaternion.identity);
    }
    void Update()
    {
        Wrap();
        Instantiate(Shadow, transform.position - new Vector3(0, 0.9f, 0), Quaternion.identity);
        rb.velocity = new Vector2(MoveX * speed * Time.deltaTime, MoveY * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.PlayMusic("ThemeFast");
            speed = maxSpeed;
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.PlayMusic("Theme");
            speed = normalSpeed;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveY = 10;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveY = -10;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveX = -10;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveX = 10;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            MoveY = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            MoveX = 0;
        }
        line.SetPosition(1, transform.position);
        if (MoveX == 0 && MoveY == 0)
            ani.SetBool("isWrunning", false);
        else
            ani.SetBool("isWrunning", true);
    }
    void Wrap()
    {
        if (rb.position.x < minX)
        {
            rb.position = new Vector2(maxX, rb.position.y);
        }
        if (rb.position.x > maxX)
        {
            rb.position = new Vector2(minX, rb.position.y);
        }
        if (rb.position.y < minY)
        {
            rb.position = new Vector2(rb.position.x, maxY);
        }
        if (rb.position.y > maxY)
        {
            rb.position = new Vector2(rb.position.x, minY);
        }
    }
}
