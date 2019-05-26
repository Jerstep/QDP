using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public GameObject tutScreen;
    public GameObject restartMenu;

    public TMP_Text scoreText;
    public TMP_Text finalScore;

    private PlayerManager playerManager;
    private Animator playerAnimator;
    private OnColission onCollision;

    bool animEnd = false;

    int exitStateHash = Animator.StringToHash("Base Layer.Idle");

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        playerAnimator = GameObject.Find("PlayerObject").GetComponent<Animator>();
        onCollision = GameObject.Find("PlayerCollider").GetComponent<OnColission>();

        if(onCollision == null)
        {
            Debug.Log("ColliderObject not found!");
        }

        if(restartMenu)
        {
            restartMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            tutScreen.SetActive(false);
        }

        scoreText.text = "Points: " + playerManager.playerScore;

        if(onCollision.wrongChoise)
        {
            restartMenu.SetActive(true);
            finalScore.text = "Final Score: " + playerManager.playerScore;
        }

        AnimatorStateInfo statusinfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        if(!animEnd)
        {
            if(statusinfo.fullPathHash == exitStateHash)
            {
                animEnd = true;
                tutScreen.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
