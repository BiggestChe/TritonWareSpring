using System.Collections;
using UnityEngine;
using TMPro;

public class WheatCounter : MonoBehaviour
{
    public GameObject Capsule;
    public GameManager game;
    private bool isCounting = false;
    public float interval = 1f;
    public TextMeshProUGUI Text;

    // Reference to DistractionManager to check for weed repellent status
    public DistractionManager distractionManager;

    // Start is called before the first frame update
    void Start()
    {
        Text.text = "Wheat: 0";
    }

    // Update is called once per frame
    void Update()
    {
        // You can handle any additional logic in the update if needed
    }

    public void OnCapsulePressed()
    {
        if (!isCounting && !distractionManager.isWeedRepellentActive) // Check if weed repellent is active
        {
            isCounting = true;
            StartCoroutine(IncrementCounter());
            game.AddWheat(1);
        }
        else if (distractionManager.isWeedRepellentActive) // Inform the player if weed repellent is active
        {
            Debug.Log("Weed repellent is active, wheat growth is stopped.");
        }

        // Reset counting after the press
        isCounting = false;
        Debug.Log("Incrementing wheat.");
    }

    private IEnumerator IncrementCounter()
    {
        // Wait for the specified interval before updating the wheat count
        yield return new WaitForSeconds(interval);

        // Update the UI with the current wheat count from the game manager
        Text.text = "Wheat: " + game.wheat.ToString();
    }
}
