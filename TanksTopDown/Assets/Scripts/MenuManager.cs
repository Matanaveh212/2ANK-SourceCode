using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] GameObject leaderboard;
    [SerializeField] GameObject controls;

    [SerializeField] AudioSource source;

    private void Start()
    {
        ui.SetActive(true);
        leaderboard.SetActive(false);
        controls.SetActive(false);
    }




    public void Play()
    {
        source.Play();

        SceneManager.LoadScene(1);
    }

    public void Leaderboard()
    {
        source.Play();

        ui.SetActive(false);
        leaderboard.SetActive(true);
    }

    public void Controls()
    {
        source.Play();

        ui.SetActive(false);
        controls.SetActive(true);
    }

    public void Exit()
    {
        source.Play();

        Application.Quit(); 
    }




    public void ExitLeaderboard()
    {
        source.Play();

        leaderboard.SetActive(false);
        ui.SetActive(true);
    }
    public void ExitControls()
    {
        source.Play();

        controls.SetActive(false);
        ui.SetActive(true);
    }
}
