using UnityEngine;
using System.Collections.Generic;

public class Food : MonoBehaviour
{
    private float x;
    private float y;

    void Start()
    {
        SpawnFood();
    }

    private void SpawnFood()
    {
        x = Random.Range(-7.8888f, 7.8888f);
        y = Random.Range(-4f, 4f);
        //Instantiate(food,new Vector2(x, y), Quaternion.identity);
        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        for(int i=0;i<Snake.Instance.snake.Count;i++)
        {
            if (transform.position == Snake.Instance.snake[i].transform.position)
            {
                SpawnFood();
            }
        }
    }
}
