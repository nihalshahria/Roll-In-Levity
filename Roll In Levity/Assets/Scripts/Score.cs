
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Transform player;
    public Text ScoreText;
    private float time;
    private float score = 0.0f;
    private float v;
    private void Start()
    {
        time = 0;
        ScoreText.text = time.ToString();
    }
    void Update()
    {
        GameObject thePlayer = GameObject.Find("Player");
        Player player = thePlayer.GetComponent<Player>();
        v = player.velocity;
        if(v>0)
        {
            time += Time.deltaTime;
        }
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
