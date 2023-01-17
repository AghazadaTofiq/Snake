using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private Transform tilePrefab;
    [SerializeField] private GameObject pause;
    [SerializeField] private AudioSource eat;
    [SerializeField] private AudioClip apple;
    [SerializeField] private TMP_Text scoreText;

    public static Snake Instance { get; private set; }

    public List<Transform> snake = new List<Transform>();

    private Vector2 direction = Vector2.right;
    private Vector2 input;

    private int score;
    private int highScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        snake.Add(transform);
    }

    private void Update()
    {
        RotateSnakeHead();
    }

    void FixedUpdate()
    {
        if (input != Vector2.zero)
        {
            direction = input;
        }

        for (int i = snake.Count - 1; i > 0; i--)
        {
            snake[i].position = snake[i - 1].position;
        }

        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);
    }

    public void Grow()
    {
        Transform tile = Instantiate(tilePrefab);
        tile.position = snake[snake.Count - 1].position;
        snake.Add(tile);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Food"))
        {
            eat.PlayOneShot(apple);
            score += 1;
            Grow();
        }
        else
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }

            Time.timeScale = 0;
            pause.SetActive(true);
            scoreText.text = "Your Score: " + score.ToString();
            score = 0;
        }
    }

    private void RotateSnakeHead()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (input != Vector2.down)
            {
                input = Vector2.up;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (input != Vector2.right)
            {
                input = Vector2.left;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (input != Vector2.up)
            {
                input = Vector2.down;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (input != Vector2.left)
            {
                input = Vector2.right;
            }
        }
    }

    public void ResetState()
    {
        direction = Vector2.right;
        transform.position = Vector3.zero;

        for (int i = 1; i < snake.Count; i++)
        {
            Destroy(snake[i].gameObject);
        }

        snake.Clear();
        snake.Add(transform);

        pause.SetActive(false);
        Time.timeScale = 1;
    }

}