using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class StartWindow : GenericWindow
{
    public Button continueButton;
    public Button newGameButton;
    public Button optionButton;

    public bool canContinue = false;

    protected override void Awake()
    {
        base.Awake();

        continueButton.onClick.AddListener(OnClickContinue);
        newGameButton.onClick.AddListener(OnClickNewGame);
        //  newGameButton.onClick.AddListener(() => Debug.Log("New Game"));
        optionButton.onClick.AddListener(OnClickOption);
    }

    public override void Open()
    {
        continueButton.gameObject.SetActive(canContinue);

        firstSelected = canContinue ? continueButton.gameObject : newGameButton.gameObject;

        base.Open();
    }
    public void OnClickContinue()
    {
        manager.Open(Windows.GameOver);
    }
    public void OnClickNewGame()
    {
        Debug.Log("OnClickNewGame");
    }
    public void OnClickOption()
    {
        Debug.Log("OnClickOption");
    }

}
