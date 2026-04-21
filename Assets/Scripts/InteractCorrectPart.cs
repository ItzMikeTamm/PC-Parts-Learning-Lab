using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractCorrectPart : MonoBehaviour
{
    public GameObject messageUI;
    public GameObject questionUI;
    public string nextSceneName;

    private bool playerNear = false;
    private bool hasInteracted = false;

    void Start()
    {
        messageUI.SetActive(false);
    }

    void Update()
    {
        if (playerNear && !hasInteracted && Input.GetKeyDown(KeyCode.E))
        {
            hasInteracted = true;
            messageUI.SetActive(true);

            if (questionUI != null)
            {
                questionUI.SetActive(false);
            }

            Invoke("LoadNextLevel", 2f);
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
}