using Assets.Scripts.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(Image), typeof(CanvasGroup))]
public class ApplicationDisplay : MonoBehaviour, IDisplay
{
    Animator animator;
    Image image;
    CanvasGroup canvasGroup;

    ApplicationInfo applicationInfo;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Initialize(ApplicationInfo applicationInfo)
    {
        this.applicationInfo = applicationInfo;
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
