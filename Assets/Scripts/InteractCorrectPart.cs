using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractCorrectPart : MonoBehaviour
{
    public GameObject messageUI;
    public GameObject questionUI;
    public string nextSceneName;

    private bool playerNear = false;

    void Start()
    {
        messageUI.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
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
            messageUI.SetActive(false);
        }
    }
}