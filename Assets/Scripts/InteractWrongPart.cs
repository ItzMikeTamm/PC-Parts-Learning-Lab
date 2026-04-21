using UnityEngine;

public class InteractWrongPart : MonoBehaviour
{
    public GameObject messageUI;
    public GameObject questionUI;
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

            Invoke("ResetInteraction", 2f);
        }
    }

    void ResetInteraction()
    {
        messageUI.SetActive(false);

        if (questionUI != null)
        {
            questionUI.SetActive(true);
        }

        hasInteracted = false;
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