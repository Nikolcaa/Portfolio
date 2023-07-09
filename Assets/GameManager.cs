using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    INTRO,
    STATE1_HOME
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState GameState = GameState.INTRO;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Application.targetFrameRate = 30;
            SetUp();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SetUp()
    {
        FindObjectOfType<Cursor>().SetUp();
        FindObjectOfType<CubesEffect>().SetUp();

        //StartCoroutine(DelayToChangeState());
        //IEnumerator DelayToChangeState()
        //{
        //    yield return new WaitForSeconds(2f);
            ChangeState(GameState.STATE1_HOME);
        //}
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
    }


}
