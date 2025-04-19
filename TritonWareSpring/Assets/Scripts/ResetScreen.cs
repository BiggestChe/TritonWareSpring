using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScreen : MonoBehaviour
{

    public GameManager GameManager;

    public TextMeshProUGUI textbox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        textbox.text = "You Completed " + GameManager.cakes + " Cakes";
    }

    public void ResetGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name );
    }
    
}
