using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogueBox : MonoBehaviour
{
    public static event Action<DialogueBox> DialogueContinued;
    public static event Action<DialogueBox, int> ChoiceSelected;

    #region Inspector

    [SerializeField] private TextMeshProUGUI dialogueSpeaker;

    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private Button continueButton;

    [SerializeField] private GameObject avatarContainer;
    [SerializeField] private Image avatarImage;
    
    [Header("Choices")]
    [SerializeField] private Transform choicesContainer;

    [SerializeField] private Button choiceButtonPrefab;

    #endregion

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    
    private Coroutine avatarAnimationCoroutine;

    private string lastSpeaker;
    
    #region Unity Event Functions

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        continueButton.onClick.AddListener(() =>
        {
            DialogueContinued?.Invoke(this);
        });
    }

    private void OnEnable()
    {
        dialogueSpeaker.SetText(string.Empty); // ""
        dialogueText.SetText(string.Empty);
    }

    #endregion

    public void DisplayText(DialogueLine line)
    {
        if (line.speaker != null)
        {
            dialogueSpeaker.SetText(line.speaker);
        }
        else
        {
            dialogueSpeaker.SetText(string.Empty);
        }
        
        bool hasAvatarFrames =
            line.speakerAvatarFrames != null &&
            line.speakerAvatarFrames.Length > 0;

        if (hasAvatarFrames)
        {
            StopAvatarAnimation();

            avatarContainer.SetActive(true);
            avatarImage.sprite = line.speakerAvatarFrames[0];

            if (line.speakerAvatarFrames.Length > 1)
            {
                avatarAnimationCoroutine =
                    StartCoroutine(AnimateAvatar(line.speakerAvatarFrames));
            }

            lastSpeaker = line.speaker;
        }
        else if (lastSpeaker != line.speaker)
        {
            StopAvatarAnimation();

            avatarContainer.SetActive(false);
            avatarImage.sprite = null;
            lastSpeaker = line.speaker;
        }

        dialogueText.SetText(line.text);

        // Read out other information such as a speaker image;

        DisplayButtons(line.choices);
    }
    
    private void StopAvatarAnimation()
    {
        if (avatarAnimationCoroutine == null)
            return;

        StopCoroutine(avatarAnimationCoroutine);
        avatarAnimationCoroutine = null;
    }
    
    private IEnumerator AnimateAvatar(Sprite[] frames)
    {
        if (frames == null || frames.Length == 0)
            yield break;
        int frameIndex = 0;
        while (true)
        {
            avatarImage.sprite = frames[frameIndex];
            frameIndex = (frameIndex + 1) % frames.Length;
            yield return new WaitForSecondsRealtime(0.25f);
        }
    }
    
    private void OnDisable()
    {
        StopAvatarAnimation();
    }
    
    private void DisplayButtons(List<Choice> choices)
    {
        Selectable newSelection;

        if (choices == null || choices.Count == 0)
        {
            ShowContinueButton(true);
            ShowChoices(false);
            newSelection = continueButton;
        }
        else
        {
            ClearChoices();
            List<Button> choiceButtons = GenerateChoices(choices);

            ShowContinueButton(false);
            ShowChoices(true);
            newSelection = choiceButtons[0];
        }

        StartCoroutine(DelayedSelect(newSelection));
    }

    private IEnumerator DelayedSelect(Selectable newSelection)
    {
        //yield return new WaitForSeconds(0.1f);
        yield return null; // Wait for next Update() / next frame

        newSelection.Select();
    }

    private void ClearChoices()
    {
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }
    }

    private List<Button> GenerateChoices(List<Choice> choices)
    {
        List<Button> choiceButtons = new List<Button>();

        for (int i = 0; i < choices.Count; i++)
        {
            Choice choice = choices[i];

            Button button = Instantiate(choiceButtonPrefab, choicesContainer);

            button.onClick.AddListener(() =>
            {
                ChoiceSelected?.Invoke(this, choice.index);
            });

            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.SetText(choice.text);
            button.name = choice.text;

            choiceButtons.Add(button);
        }

        return choiceButtons;
    }

    private void ShowContinueButton(bool show)
    {
        continueButton.gameObject.SetActive(show);
    }

    private void ShowChoices(bool show)
    {
        choicesContainer.gameObject.SetActive(show);
    }
}
