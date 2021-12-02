using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinDuelGameState : DuelGameState
{
    [SerializeField] Text _endText = null;
    [SerializeField] Text _stateTextUI = null;
    [SerializeField] AudioClip _winAudio = null;

    private void Start()
    {
        _endText.gameObject.SetActive(false);
    }

    public override void Enter()
    {
        Debug.Log("You Won!");
        StateMachine.Input.PressedShield += OnReset;
        AudioHelper.PlayClip2D(_winAudio, 0.5f);
        _endText.gameObject.SetActive(true);
        _endText.text = ("You Won! Press Space to Restart");
        _stateTextUI.text = ("State: Win State");
    }

    void OnReset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
