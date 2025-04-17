using UnityEngine;

public class Hearts : MonoBehaviour
{

    public GameObject[] hearts; 

    public GameManager game;

    // Update is called once per frame
    void Update()
    {
        if (game.lives == 2){
                Destroy(hearts[2]);
            }
        if(game.lives == 1){
                Destroy(hearts[1]);
        }

        }
        
    }

