using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Linq;
using System.Globalization;
using Assets.Scripts;

public class GameManager : MonoBehaviour
{
    // Static instance
    public static GameManager Instance;

    // Serialized fields
    [SerializeField]
    GameObject gameplayCanvasPrefab;

    // Cached references
    ScoreManager scoreManager;
    GameplayCanvas gameplayCanvas;

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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
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

    private void CreateLevel()
    {
        gameplayCanvas = Instantiate(gameplayCanvasPrefab).GetComponent<GameplayCanvas>();
        gameplayCanvas.Initialize(scoreManager);
    }
}
