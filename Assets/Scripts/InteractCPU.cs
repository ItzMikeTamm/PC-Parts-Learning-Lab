using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractCPU : MonoBehaviour
{
    public GameObject messageUI;
    public GameObject questionUI;
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

            Invoke("LoadNextLevel", 2f); // wait 2 seconds
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("Level2");
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