using System.Collections;
using UnityEngine;

public class StartGame : MonoBehaviour, IClickable
{
    public GameObject kitchenScene;
    public GameObject farmScene;
    public Canvas playerUI;
    public GameManager gameManager;
    public GameObject Start_Screen;         // The panel to click on
    public GameObject TutorialPanel;        // The panel that will flash

    public float tutorialDuration = 3f;     // Time to show the tutorial

    void Start()
    {
        gameObject.SetActive(true);
        kitchenScene.SetActive(false);
        farmScene.SetActive(false);
        playerUI.enabled = false;
        gameManager.enabled = false;
        TutorialPanel.SetActive(false); // Make sure it's off at start
    }

    public void Click()
    {
        StartCoroutine(ShowTutorialThenStartGame());
    }

    private IEnumerator ShowTutorialThenStartGame()
    {
        Start_Screen.SetActive(false);         // Hide the start screen
        TutorialPanel.SetActive(true);         // Show tutorial

        yield return new WaitForSeconds(tutorialDuration); // Wait a bit

        Debug.Log("should be gone");

        TutorialPanel.SetActive(false);        // Hide tutorial
        kitchenScene.SetActive(true);
        farmScene.SetActive(true);
        playerUI.enabled = true;
        gameManager.enabled = true;
    }
}
