
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Transform player;
    public Text ScoreText;
    private float time;
    private void Start()
    {
        time = 0;
        ScoreText.text = time.ToString();
    }
    void Update()
    {
        time += Time.deltaTime;
        ScoreText.text = Mathf.Round(time).ToString("0");
    }
}
