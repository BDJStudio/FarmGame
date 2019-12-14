using UnityEngine;

public class Cam : MonoBehaviour
{
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool isLeft;
    private Transform player;
    private int lastX;
    public float minX, maxX;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(Mathf.Clamp(player.position.x - offset.x, minX, maxX), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(Mathf.Clamp(player.position.x + offset.x, minX, maxX), transform.position.y, transform.position.z);
        }
    }

    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isLeft = false; else if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(Mathf.Clamp(player.position.x - offset.x, minX, maxX), transform.position.y, transform.position.z);
                
            }
            else
            {
                target = new Vector3(Mathf.Clamp(player.position.x + offset.x, minX, maxX), transform.position.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
