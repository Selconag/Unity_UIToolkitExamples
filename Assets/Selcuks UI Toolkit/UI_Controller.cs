using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class UI_Controller : MonoBehaviour
{
    private VisualElement _bottomContainer;
    private Button _openButton, _closeButton;
    private VisualElement _bottomSheet, _scrim;
    private VisualElement _boy,_girlBot;
    private Label _paragraph;


    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _bottomContainer = root.Q<VisualElement>("Container_Bottom");
        _openButton = root.Q<Button>("Button_Open");
        _closeButton = root.Q<Button>("Button_Close");
        _bottomSheet = root.Q<VisualElement>("Bottom_Sheet");
        _scrim = root.Q<VisualElement>("Scrim");
        _boy = root.Q<VisualElement>("Image_Boy");
        _girlBot = root.Q<VisualElement>("Image_GirlBot");
        _paragraph = root.Q<Label>("Paragraph_B_S");


        _bottomContainer.style.display = DisplayStyle.None;

        _openButton.RegisterCallback<ClickEvent>(OnOpenButtonClick);
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClick);

        Invoke("AnimateBoy" , .1f);
    }

    private void OnOpenButtonClick(ClickEvent evt)
    {
        _bottomContainer.style.display = DisplayStyle.Flex;
        _bottomSheet.AddToClassList("bottom-sheet-up");
        _scrim.AddToClassList("scrim-fadein");

        AnimateGirl();
    }

    private void OnCloseButtonClick(ClickEvent evt)
    {
        _bottomContainer.style.display = DisplayStyle.None;
        _bottomSheet.RemoveFromClassList("bottom-sheet-up");
        _scrim.RemoveFromClassList("scrim-fadein");

    }

    private void AnimateBoy()
    {
        _boy.RemoveFromClassList("image-boy-air");
    }

    private void AnimateGirl()
    {
        _girlBot.ToggleInClassList("image-girlbot-up");
        _girlBot.RegisterCallback<TransitionEndEvent>
            (
            evt => _girlBot.ToggleInClassList("image-girlbot-up")
            
            );
        string paraghraphText = "\"Hayatım akşama geliyor musun yoksa polis mi çağırayım?\"";
    }
}
