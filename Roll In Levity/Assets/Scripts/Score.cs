
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Transform player;
    public Text ScoreText;
    private float time;
    private float score = 0.0f;
    private void Start()
    {
        time = 0;
        ScoreText.text = time.ToString();
    }
    void Update()
    {
        time += Time.deltaTime;
        score = Mathf.Round(time);
        ScoreText.text = Mathf.Round(time).ToString(/*"0"*/);
    }

    public void OnDeath()
    {
        if(PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
