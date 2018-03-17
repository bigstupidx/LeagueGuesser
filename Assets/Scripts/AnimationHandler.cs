using UnityEngine;
using System.Collections;

public class AnimationHandler : MonoBehaviour 
{
    private Animator questionTextAnimator;
    private Animator questionTextBackgroundAnimator;
    private Animator questionImageAnimator;
    private Animator questionImageBackgroundAnimator;
    private Animator victoryAnimator;
    private Animator defeatAnimator;

	void Awake () 
    {
        questionTextAnimator = GameObject.Find("QuestionText").GetComponent<Animator>();
        questionTextBackgroundAnimator = GameObject.Find("QuestionTextBackground").GetComponent<Animator>();
        questionImageAnimator = GameObject.Find("QuestionImage").GetComponent<Animator>();
        questionImageBackgroundAnimator = GameObject.Find("QuestionImageBackground").GetComponent<Animator>();
        victoryAnimator = GameObject.Find("VictoryPanel").GetComponent<Animator>();
        defeatAnimator = GameObject.Find("DefeatPanel").GetComponent<Animator>();
        victoryAnimator.gameObject.SetActive(false);
        defeatAnimator.gameObject.SetActive(false);
	}

    public void PlayAnimation(string animatorName, int animStateInt)
    {
        switch(animatorName)
        {
            case "TextAnimator":
                questionTextAnimator.SetInteger("animState", animStateInt);
                break;
            case "TextBackgroundAnimator":
                questionTextBackgroundAnimator.SetInteger("animState", animStateInt);
                break;
            case "ImageAnimator":
                questionImageAnimator.SetInteger("animState", animStateInt);
                break;
            case "ImageBackgroundAnimator":
                questionImageBackgroundAnimator.SetInteger("animState", animStateInt);
                break;
            case "VictoryAnimator":
                victoryAnimator.SetInteger("animState", animStateInt);
                break;
            case "DefeatAnimator":
                defeatAnimator.SetInteger("animState", animStateInt);
                break;
        }
    }
}
