using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public float horizontalSpeed;
    float speedX;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LeftButtonDown()
    {
        transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        speedX = -horizontalSpeed;
    }
    public void RightButtonDown()
    {
        speedX = horizontalSpeed;
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }
    public void Stop()
    {
        speedX = 0;
    }

    public void FixedUpdate()
    {
        transform.Translate(speedX, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //тут пишем тригеры))
    }

}
