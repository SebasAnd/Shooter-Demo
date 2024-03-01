using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerUI : MonoBehaviour
{
    public static GameManagerUI Instance { get; private set; }
    [SerializeField] private PlayerController player;
    [SerializeField] private Button macarenaButton;
    [SerializeField] private Button hipHopButton;
    [SerializeField] private Button HouseButton;
    [SerializeField] private Button ChangeScenceButton;

    [SerializeField] private TMPro.TMP_Dropdown danceSelector;

    // Start is called before the first frame update


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        macarenaButton.onClick.AddListener(() => { player.PlaySelectedDance(1); });
        hipHopButton.onClick.AddListener(() => { player.PlaySelectedDance(2); });
        HouseButton.onClick.AddListener(() => { player.PlaySelectedDance(3); });
        danceSelector.onValueChanged.AddListener(delegate { player.PlaySelectedDance(danceSelector.value); });
        ChangeScenceButton.onClick.AddListener(() => { SceneManager.LoadScene("Scene2", LoadSceneMode.Single); });
    }

    public void PlayDance(int dance)
    {
        player.PlaySelectedDance(dance);
    }



}
