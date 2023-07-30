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

public class GameManager : MonoBehaviour
{
    // Static instance
    public static GameManager Instance;

    // Serialized fields
    [SerializeField]
    GameObject eventSystemPrefab;

    [SerializeField]
    GameObject sceneLoaderPrefab;

    [SerializeField]
    GameObject gameplayCanvasPrefab;

    // Cached references
    ScoreManager scoreManager;
    GameplayCanvas gameplayCanvas;

    private DialogueRunner dialogueRunner;
    public string applicantNode; 

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

    /// <summary>
    /// What to do when a scene has been loaded
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Create objects if they're missing in scene
        AddMissingObjects();

        // Determine if a level was loaded
        string levelNumber = new string(scene.name.TakeWhile(c => char.IsDigit(c)).ToArray());
        if (int.TryParse(levelNumber, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result))
        {
            Debug.Log($"Loaded Level: {result}");

            CreateLevel();
        }
        else
        {
            Debug.Log($"Loaded Non-Level: {scene.name}");
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
        ApplicationInfo levelApplication = FindObjectOfType<ApplicationInfo>();
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
