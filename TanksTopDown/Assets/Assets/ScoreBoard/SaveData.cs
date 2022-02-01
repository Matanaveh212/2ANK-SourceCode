using UnityEngine;

public class SaveData : MonoBehaviour
{
    public TMPro.TextMeshProUGUI myName;
    public TMPro.TextMeshProUGUI myScore;
    public int currentScore;

    void Update()
    {
        myScore.text = $"WINS: {PlayerPrefs.GetInt("highscore")}";
    }

    public void SendScore()
    {
        if(currentScore > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", currentScore);
            HighScores.UploadScore(myName.text, currentScore);
            Debug.Log("worked");
        }
    }
}
