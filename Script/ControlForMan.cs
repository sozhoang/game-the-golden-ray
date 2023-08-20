using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlForMan : MonoBehaviour
{
    float speed;
    float MoveX;
    float MoveY;
    public int helth;
    public float maxSpeed;
    public float normalSpeed;
    public float maxX, maxY, minX, minY;

    public GameObject Shadow;
    public Database data;
    Rigidbody2D rb;
    LineRenderer line;
    Animator ani;
    void Start()
    {
        helth = data.man.helth;
        maxSpeed = data.man.maxSpeed;
        normalSpeed = data.man.normalSpeed;

        data.score = 0;
        rb = GetComponent<Rigidbody2D>();
        MoveX = 0;
        MoveY = 0;
        line = FindObjectOfType<LineRenderer>();
        ani = GetComponent<Animator>();
        speed = normalSpeed;
        Instantiate(Shadow,transform.position - new Vector3(0,0.75f,0),Quaternion.identity);
    }
    void Update()
    {
        Wrap();
        Instantiate(Shadow, transform.position - new Vector3(0, 0.75f, 0), Quaternion.identity);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.PlayMusic("ThemeFast");
            speed = maxSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.PlayMusic("Theme");
            speed = normalSpeed;
        }
        rb.velocity = new Vector2(MoveX * speed * Time.deltaTime, MoveY * speed * Time.deltaTime); 
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveY = 10;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveY = -10;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveX = -10;
            transform.localScale = new Vector3(0.08f, 0.08f, 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveX = 10;
            transform.localScale = new Vector3(-0.08f, 0.08f, 1);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            MoveY = 0;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            MoveX = 0;
        }
        line.SetPosition(0, transform.position);
        if (MoveX == 0 && MoveY == 0)
            ani.SetBool("isRunning", false);
        else
            ani.SetBool("isRunning", true);
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
