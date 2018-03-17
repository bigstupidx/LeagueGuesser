using UnityEngine;
using System.Collections;

public class MenuAnimation : MonoBehaviour 
{
    private Animator menuAnimator;

	void Start () 
    {
        menuAnimator = GetComponent<Animator>();
	}
	
    public void SetAnimation(int value)
    {
        menuAnimator.SetInteger("AnimState", value);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetAnimation(0);
        }
    }
}
