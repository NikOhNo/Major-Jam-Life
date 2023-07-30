using Assets.Scripts.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(CanvasGroup))]
public class ApplicationDisplay : MonoBehaviour, IDisplay
{
    [SerializeField]
    float timeToFade = 0.5f;

    [SerializeField]
    Image animalImage;

    [SerializeField]
    GameObject bulletPointContainer;

    [SerializeField]
    GameObject bulletPointPrefab;

    Animator animator;
    CanvasGroup canvasGroup;

    ApplicationInfo applicationInfo;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Initialize(ApplicationInfo applicationInfo)
    {
        this.applicationInfo = applicationInfo;
    }
    public void SetUpApplication()
    {
        // Give sketch
        animalImage.sprite = applicationInfo.Sketch;

        // Instantiate bullet points
        CreateBulletPoints();

        // Instantiate questions

        // Fade in the panel
        StartCoroutine(FadeInInfo(timeToFade));
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
        foreach (BulletPoint p in applicationInfo.BulletPoints)
        {
            Instantiate(bulletPointPrefab, bulletPointContainer.transform);
        }
    }

    public void ShowApplication()
    {
        animator.SetBool("Open", true);

        for ( int i = 0; i < 4; i++ )
        {
            Instantiate(descriptionButton, descriptionLocation.transform);
        }
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
