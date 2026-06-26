using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Image dialogueImage;
    public Sprite[] dialogueSprites;

    public string gameplayScene = "Gameplay";

    private int currentIndex = 0;

    void Start()
    {
        dialogueImage.sprite = dialogueSprites[currentIndex];
    }

    public void NextDialogue()
    {
        currentIndex++;

        if (currentIndex < dialogueSprites.Length)
        {
            dialogueImage.sprite = dialogueSprites[currentIndex];
        }
        else
        {
            LoadGameplay();
        }
    }

    void LoadGameplay()
    {
        SceneManager.LoadScene(gameplayScene);
    }
}