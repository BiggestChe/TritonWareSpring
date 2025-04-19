using UnityEngine;

public class ProgressBarScript : MonoBehaviour
{

    public Animator animator;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

public void PlayLoadingBar()
    {
        animator.SetTrigger("PlayAnimation");
    }
}
