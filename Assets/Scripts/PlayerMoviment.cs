using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public GameObject gameOverScreen;
    public float jumpImpulse;
    public GameObject scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        if (Input.GetMouseButtonDown(0))
        {
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, 0f);
            rigidbody2D.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameOver(collision.gameObject, "Wall");
        if (collision.gameObject.tag == "Gap")
        {
            scoreManager.GetComponent<ScoreManager>().score += 1;
            updateGameDifficulty();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _gameOver(collision.gameObject, "Pipe");
    }

    private void _gameOver(GameObject collision, string tag)
    {
        if (collision.gameObject.tag == tag)
        {
            PlayCollisionSound();
            this.gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void PlayCollisionSound()
    {
        GameObject.FindFirstObjectByType<MusicManager>().playCollision();
    }

    private void updateGameDifficulty()
    {
        ScoreManager scoreObject = scoreManager.GetComponent<ScoreManager>();

        if (scoreObject.score % 5 == 0 && scoreObject.score != 0)
        {
            GameObject.FindFirstObjectByType<MusicManager>().playUpDifficulty();
            GameObject spanwManager = GameObject.FindGameObjectWithTag("Spawn");
            spanwManager.GetComponent<SpawnObstacles>().speed += 0.2f;
        }
    }
}
