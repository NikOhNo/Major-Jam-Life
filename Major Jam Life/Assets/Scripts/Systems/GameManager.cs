using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Linq;
using System.Globalization;
using Assets.Scripts;
using UnityEngine.EventSystems;
using Yarn.Unity;
using Assets.Scripts.Gameplay.Application.Submission;

public class GameManager : MonoBehaviour
{
    // Static instance
    public static GameManager Instance;

    // Serialized fields
    [SerializeField]
    int correctApprovalScore = 3;

    [SerializeField]
    int correctAnswerScore = 1;

    [SerializeField]
    GameObject eventSystemPrefab;

    [SerializeField]
    GameObject sceneLoaderPrefab;

    [SerializeField]
    GameObject gameplayCanvasPrefab;

    // Cached references
    ScoreManager scoreManager;
    GameplayCanvas gameplayCanvas;
    ApplicationInfo levelApplication;

    private DialogueRunner dialogueRunner;
    public string applicantNode; 

    private SoundManager sm;

    private void Awake()
    {
        // Singleton pattern
        GameManager[] instances = FindObjectsOfType<GameManager>();
        if (instances.Length > 1)
        {
            Destroy(this);
            gameObject.SetActive(false);
        }
        else
        {
            DontDestroyOnLoad(this);

            Instance = this;
            Initialize();
        }

        dialogueRunner = FindObjectOfType<DialogueRunner>(); 
        sm = GetComponent<SoundManager>();
    }

    /// <summary>
    /// Subscribes to any needed events and creates other managers with dependency injection
    /// </summary>
    private void Initialize()
    {
        // Subscribe to scene loading
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Create sub-managers
        scoreManager = new ScoreManager();
    }

    public void GiveSubmission(Submission submission)
    {
        // Helper variables
        int totalPossible = correctApprovalScore;
        int totalGained = 0;
        if (levelApplication.ShouldApprove == true)
        {
            totalPossible += submission.Results.Count;
        }

        // Hide application and character
        gameplayCanvas.applicationDisplay.HideApplication();
        gameplayCanvas.characterDisplay.HideDisplay();
        gameplayCanvas.paperHold.SetActive(false);

        // Check if it should have been approved
        if (levelApplication.ShouldApprove == submission.Approved)
        {
            scoreManager.AddScore(correctApprovalScore);
            totalGained += correctApprovalScore;

            // Give commentary on correct approval
            if (levelApplication.ShouldApprove == true)
            {
                gameplayCanvas.gradeDisplay.SetCommentary("Adequate job. Well done!");
            }
            else
            {
                gameplayCanvas.gradeDisplay.SetCommentary("Good eye! Phew, I'm happy that didn't get through.");
            }
        }
        else
        {
            // Give commentary on wrong approval/denial
            if (levelApplication.ShouldApprove == false)
            {
                gameplayCanvas.gradeDisplay.SetCommentary("Why did you approve this?!");
            }
            else
            {
                gameplayCanvas.gradeDisplay.SetCommentary("This should have been approved!!!");
            }
        }

        // Give stars for each correct answer
        if (levelApplication.ShouldApprove == true)
        {
            foreach (QuestionResult result in submission.Results)
            {
                // if its correct, add a star
                if (result.IsCorrect == true)
                {
                    scoreManager.AddScore(correctAnswerScore);
                    totalGained += correctAnswerScore;
                }
            }
        }

        gameplayCanvas.gradeDisplay.SetEarned(totalGained);
        gameplayCanvas.gradeDisplay.SetGained(totalGained);
        gameplayCanvas.gradeDisplay.SetPossible(totalPossible);

        gameplayCanvas.gradeDisplay.PrepareNextDay(() => FindObjectOfType<SceneLoader>().LoadNextScene());
    }
    
    public void EnableGradeDisplay()
    {
        gameplayCanvas.gradeDisplay.gameObject.SetActive(true);
    }

    /// <summary>
    /// What to do when a scene has been loaded
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        levelApplication = null;

        // Create objects if they're missing in scene
        AddMissingObjects();

        // Determine if a level was loaded
        string levelNumber = new string(scene.name.TakeWhile(c => char.IsDigit(c)).ToArray());
        if (int.TryParse(levelNumber, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result))
        {
            Debug.Log($"Loaded Level: {result}");

            CreateLevel();
            sm.PlayLevelTheme();
        }
        else
        {
            Debug.Log($"Loaded Non-Level: {scene.name}");
            sm.PlayMenuTheme();
        }
    }

    private void AddMissingObjects()
    {
        if (FindObjectOfType<EventSystem>() == null)
        {
            Instantiate(eventSystemPrefab);
        }

        if (FindObjectOfType<SceneLoader>() == null)
        {
            Instantiate(sceneLoaderPrefab);
        }
    }

    private void CreateLevel()
    {
        gameplayCanvas = Instantiate(gameplayCanvasPrefab).GetComponent<GameplayCanvas>();
        levelApplication = FindObjectOfType<ApplicationInfo>();
        if (levelApplication == null) 
        {
            Debug.LogError("Could not find application for level");
        }
        gameplayCanvas.Initialize(scoreManager, levelApplication);

        StartApplicationConversation();
    }

    void StartApplicationConversation()
    {
        dialogueRunner.StartDialogue(applicantNode);
    }
}
