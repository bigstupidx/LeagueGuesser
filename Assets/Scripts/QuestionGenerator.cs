using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour {

    public Question[] questions;
    public Question currentQuestion;

    private AnimationHandler animations;
    [SerializeField]private Text questionText;
    [SerializeField]private Image questionImage;

    void Start()
    {
        animations = GetComponent<AnimationHandler>();
        NextQuestion();
    }

	public void NextQuestion()
    {
        currentQuestion = GenerateQuestion();
        questionText.text = currentQuestion.questionString;
        questionImage.sprite = currentQuestion.questionImage;
        animations.PlayAnimation("TextAnimator", 1);
        animations.PlayAnimation("TextBackgroundAnimator", 1);
        animations.PlayAnimation("ImageAnimator", 1);
        animations.PlayAnimation("ImageBackgroundAnimator", 1);
	}

    private Question GenerateQuestion()
    {
        int index = Random.Range(0,questions.Length);
        return questions[index];
    }

}
