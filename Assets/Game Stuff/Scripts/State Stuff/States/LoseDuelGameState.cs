using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseDuelGameState : DuelGameState
{
    [SerializeField] Text _endText = null;
    [SerializeField] Text _stateTextUI = null;

    private void Start()
    {
        _endText.gameObject.SetActive(false);
    }

    public override void Enter()
    {
        Debug.Log("You Lost...");
        StateMachine.Input.PressedShield += OnReset;
        _endText.gameObject.SetActive(true);
        _endText.text = ("You Lost... Press Space to Restart");
        _stateTextUI.text = ("State: Lose State");
    }

    void OnReset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}

