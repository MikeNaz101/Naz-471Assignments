using UnityEngine;
using UnityEngine.UI;  // For UI components

public class ScoreManager : MonoBehaviour
{
    public int winScore = 10;           // Score required to win
    //public Text scoreText;              // UI Text to display the score
    //public GameObject winMessage;       // UI element to show the win message
    private int playerScore = 0;        // Player's current score

    void Start()
    {
        //UpdateScoreText();
        //winMessage.SetActive(false);    // Hide the win message at the start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))  // Check if the object entering is tagged as "Enemy"
        {
            Destroy(other);

            playerScore++;
            //UpdateScoreText();

            if (playerScore >= winScore)
            {
                WinGame();
            }
        }
    }

    /*void UpdateScoreText()
    {
        scoreText.text = "Score: " + playerScore;
    }*/

    void WinGame()
    {
        //winMessage.SetActive(true);
        Debug.Log("You Win!");
        // Add additional win logic here (e.g., stop gameplay, load next level, etc.)
    }
}
