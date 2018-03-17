using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionChecker : MonoBehaviour 
{
    private PlayAudio audioScript;
    private QuestionGenerator questionGenerator;
    private AnimationHandler animations;
    [SerializeField]private InputField inputAnswer;
    [SerializeField]private GameObject victoryScreen;
    [SerializeField]private GameObject defeatScreen;
    private int winstreak = 0;
    private bool isSkipping = false;
    private Profile profile;

	void Start () 
    {
        animations = GetComponent<AnimationHandler>();
        questionGenerator = GetComponent<QuestionGenerator>();
        profile = GameObject.Find("ProfileData").GetComponent<Profile>();
        audioScript = GameObject.Find("AudioManager").GetComponent<PlayAudio>();

    }

    public void CheckQuestion()
    {
        string tempAnswer = inputAnswer.text;
        string answer = tempAnswer.ToLower();
        int pos = System.Array.IndexOf(questionGenerator.currentQuestion.questionAnswers, answer);
        QuestionAnimations();
        if (pos > -1)
        {
            StartCoroutine(Victory());
            winstreak += 1;
        }
        else
        {
            StartCoroutine(Defeat());
            winstreak = 0;
        }
    }

    IEnumerator Victory()
    {
        audioScript.PlaySound(1);
        inputAnswer.text = "";
        victoryScreen.SetActive(true);
        animations.PlayAnimation("VictoryAnimator", 1);
        yield return new WaitForSeconds(1.5f);
        profile.AddLeaguePoints(Random.Range(80, 120));
        profile.SetPoints();
        animations.PlayAnimation("VictoryAnimator", 2);
        yield return new WaitForSeconds(.3f);
        victoryScreen.SetActive(false);
        profile.SetElo(Random.Range(13,20) + (winstreak * 2));
        questionGenerator.NextQuestion();
        profile.SetLPBar();
    }

    IEnumerator Defeat()
    {
        audioScript.PlaySound(2);
        inputAnswer.text = "";
        defeatScreen.SetActive(true);
        animations.PlayAnimation("DefeatAnimator", 1);
        yield return new WaitForSeconds(1.5f);
        animations.PlayAnimation("DefeatAnimator", 2);
        yield return new WaitForSeconds(.3f);
        defeatScreen.SetActive(false);
        if(profile.GetElo() > 0)
        {
            profile.SetElo(Random.Range(-16, -24));
        }
        else if(profile.GetElo() <= 0)
        {
            profile.SetEloTo(0);
        }       
        questionGenerator.NextQuestion();
        profile.SetLPBar();
    }

    public void QuestionAnimations()
    {
        animations.PlayAnimation("TextAnimator", 2);
        animations.PlayAnimation("TextBackgroundAnimator", 2);
        animations.PlayAnimation("ImageAnimator", 2);
        animations.PlayAnimation("ImageBackgroundAnimator", 2);
    }

    public void SkipQuestion()
    {
        if(profile.GetPoints() >= 1000 && isSkipping == false)
        {
            StartCoroutine(Skip());
        }
    }

    IEnumerator Skip()
    {
        isSkipping = true;
        inputAnswer.text = "";
        profile.AddLeaguePoints(-1000);
        profile.SetPoints();
        QuestionAnimations();
        yield return new WaitForSeconds(1f);
        questionGenerator.NextQuestion();
        isSkipping = false;
    }
}
