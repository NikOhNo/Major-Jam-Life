using Assets.Scripts.Gameplay;
using Assets.Scripts.Gameplay.Application.Submission;
using Assets.Scripts.Systems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(CanvasGroup))]
public class ApplicationDisplay : MonoBehaviour, IDisplay
{
    #region SerializedFields
    [SerializeField]
    float timeToFade = 0.5f;

    [SerializeField]
    TMP_Text sketchName;

    [SerializeField]
    Image sketchImage;

    [SerializeField]
    GameObject bulletPointContainer;

    [SerializeField]
    GameObject bulletPointPrefab;

    [SerializeField]
    Button approveButton;

    [SerializeField]
    Button denyButton;

    [SerializeField]
    QuestionDisplay questionDisplay;

    [SerializeField]
    Button submitButton;

    [SerializeField]
    ApprovalDisplay approvalDisplay;
    #endregion

    Animator animator;
    CanvasGroup canvasGroup;

    ApplicationInfo applicationInfo;

    Submission submission;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Initialize(ApplicationInfo applicationInfo)
    {
        this.applicationInfo = applicationInfo;

        submission = new Submission();

        // Set up buttons
        approveButton.onClick.AddListener(() => OnApprove());
        denyButton.onClick.AddListener(() => OnDeny());
        submitButton.onClick.AddListener(() => OnSubmit());
        submitButton.gameObject.SetActive(false);
    }

    public void SetUpApplication()
    {
        // Give sketch info
        sketchName.text = applicationInfo.SketchInfo.SketchName;
        sketchImage.sprite = applicationInfo.SketchInfo.Sketch;

        // Instantiate bullet points
        CreateBulletPoints();

        // Instantiate questions
        questionDisplay.Initialize(applicationInfo);
    }

    public void ShowGrade()
    {
        GameManager.Instance.EnableGradeDisplay();
    }

    public void OnApprove()
    {
        submission.Approved = true;
        submitButton.gameObject.SetActive(true);

        // Display thumbs up
        approvalDisplay.ShowApproved(approveButton.GetComponent<RectTransform>());
    }

    public void OnDeny() 
    {
        submission.Approved = false;
        submitButton.gameObject.SetActive(true);

        // Display thumbs down
        approvalDisplay.ShowDenied(denyButton.GetComponent<RectTransform>());
    }

    public void OnSubmit()
    {
        // Get results
        submission.Results = questionDisplay.GetResults();

        // TODO: give submission to game manager or grader
        GameManager.Instance.GiveSubmission(submission);
    }

    IEnumerator FadeInInfo(float timeToFade)
    {
        float timeElapsed = 0f;

        canvasGroup.alpha = 0f;
        while (timeElapsed < timeToFade)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / timeToFade);
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }

    public void CreateBulletPoints()
    {
        foreach (BulletPoint bpInfo in applicationInfo.BulletPoints)
        {
            BulletPointDisplay newBPDisplay = Instantiate(bulletPointPrefab, bulletPointContainer.transform).GetComponent<BulletPointDisplay>();
            newBPDisplay.Initialize(bpInfo);
        }
    }

    public void ShowApplication()
    {
        animator.SetBool("Open", true);
    }

    public void HideApplication()
    {
        animator.SetBool("Open", false);
    }

    public void ShowDisplay()
    {
        canvasGroup.alpha = 1;
    }

    public void HideDisplay()
    {
        canvasGroup.alpha = 0;
    }
}
