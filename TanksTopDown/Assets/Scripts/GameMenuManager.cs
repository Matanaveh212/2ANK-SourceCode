using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] GameObject namesMenu;

    [SerializeField] TMP_Text redNameFieldStart;
    [SerializeField] TMP_Text blueNameFieldStart;

    [SerializeField] GameObject redV;
    [SerializeField] GameObject blueV;

    [SerializeField] GameObject whoWonMenu;
    [SerializeField] TMP_Text winningNameField;

    [SerializeField] GameObject endLevelMenu;
    [SerializeField] TMP_Text redNameFieldEnd;
    [SerializeField] TMP_Text blueNameFieldEnd;
    [SerializeField] TMP_Text redEndScoreField;
    [SerializeField] TMP_Text blueEndScoreField;

    [SerializeField] Tank_BLUE blueTankPrefab;
    [SerializeField] Tank_RED redTankPrefab;

    [SerializeField] GameObject tankRedStart;
    [SerializeField] GameObject tankBlueStart;

    [SerializeField] AudioSource source;
    [SerializeField] GameObject sounds;

    string nameRed;
    string nameBlue;

    int winsRed;
    int winsBlue;

    int readys = 0;

    bool isRedPressed = false;
    bool isBluePressed = false;

    private void Start()
    {
        Instantiate(sounds);

        namesMenu.SetActive(true);
        whoWonMenu.SetActive(false);
        endLevelMenu.SetActive(false);

        FindObjectOfType<Tank_BLUE>().gameObject.SetActive(false);
        FindObjectOfType<Tank_RED>().gameObject.SetActive(false);
    }

    public void RedReady()
    {
        source.Play();

        nameRed = redNameFieldStart.text;

        redV.SetActive(true);

        if(isRedPressed == false)
        {
            readys += 1;
            isRedPressed = true;
        }

        if(readys == 2)
        {
            StartCoroutine("StartGame");
        }
    }

    public void BlueReady()
    {
        source.Play();

        nameBlue = blueNameFieldStart.text;

        blueV.SetActive(true);

        if (isBluePressed == false)
        {
            readys += 1;
            isBluePressed = true;
        }

        if (readys == 2)
        {
            StartCoroutine("StartGame");
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.4f);
        tankBlueStart.SetActive(true);
        tankRedStart.SetActive(true);
        namesMenu.SetActive(false);
    }
    



    public void EndGameRedLost()
    {
        winsBlue += 1;

        whoWonMenu.SetActive(true);
        winningNameField.text = nameBlue;

        StartEndLevel();

    }
    public void EndGameBlueLost()
    {
        winsRed += 1;

        whoWonMenu.SetActive(true);
        winningNameField.text = nameRed;
        StartEndLevel();
    }

    private void StartEndLevel()
    {
        StartCoroutine("WaitUntilEnd");

        redNameFieldEnd.text = nameRed;
        blueNameFieldEnd.text = nameBlue;

        redEndScoreField.text = winsRed.ToString();
        blueEndScoreField.text = winsBlue.ToString();
    }

    IEnumerator WaitUntilEnd()
    {
        yield return new WaitForSeconds(2);
        whoWonMenu.SetActive(false);
        endLevelMenu.SetActive(true);
    }




    public void Rematch()
    {
        source.Play();

        foreach (Transform child in GameObject.Find("Bullets").transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        HighScores.UploadScore(nameRed, winsRed);
        HighScores.UploadScore(nameBlue, winsBlue);

        endLevelMenu.SetActive(false);

        Tank_RED tank_red = Instantiate(redTankPrefab, transform.position, transform.rotation);
        Tank_BLUE tank_blue = Instantiate(blueTankPrefab, transform.position, transform.rotation);
    }

    public void Finish()
    {
        source.Play();

        HighScores.UploadScore(nameRed, winsRed);
        HighScores.UploadScore(nameBlue, winsBlue);

        SceneManager.LoadScene(0);
    }

}
