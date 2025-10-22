using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class DialogManager : MonoBehaviour
{
    [SerializeField] private float typeSpeed;
    [SerializeField] private Image storyPanel;
    public AudioClip clickSound;
    public string[] sentences;
    public Sprite[] storySprites;
    public TMP_Text textArea;
    public GameObject continueButton;
    public GameObject startGameButton;
    private int index;
    private int spriteIndex;

    void Start()
    {
        index = 0;
        spriteIndex = 0;
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textArea.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void NextSentence()
    {
        EffectSoundManager.Instance.PlaySoundEffect(clickSound);
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textArea.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textArea.text = "";
            continueButton.SetActive(false);
        }

        if(index != 5 && index!=8)
        {
            ManageStoryPanels();
        }

    }

    private void ManageStoryPanels()
    {
        if(spriteIndex >= storySprites.Length)
        {
            return;
        }
        spriteIndex++;
        storyPanel.sprite = storySprites[spriteIndex];
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (textArea.text == sentences[index] && index != sentences.Length - 1)
        {
            continueButton.SetActive(true);
        }
        else if (textArea.text == sentences[index] && index == sentences.Length - 1)
        {
            startGameButton.SetActive(true);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
