using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Unity.VisualScripting;

public class GameManagerUI : MonoBehaviour
{
    public static GameManagerUI Instance { get; private set; }
    [SerializeField] private PlayerController player;
    [SerializeField] private Button macarenaButton;
    [SerializeField] private Button hipHopButton;
    [SerializeField] private Button HouseButton;
    [SerializeField] private Button ChangeScenceButton;
    [SerializeField] private BunnyController bunny;

    [SerializeField] private TMPro.TMP_Dropdown danceSelector;

    [SerializeField] private AudioSource djTable;
    [SerializeField] private AudioClip[] music;

    [SerializeField] private BunnyController[] peopleDance;

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
        macarenaButton.onClick.AddListener(() => { player.PlaySelectedDance(1); PlayDance(true); });
        hipHopButton.onClick.AddListener(() => { player.PlaySelectedDance(2); PlayDance(false); });
        HouseButton.onClick.AddListener(() => { player.PlaySelectedDance(3); PlayDance(false); });
        danceSelector.onValueChanged.AddListener(delegate { player.PlaySelectedDance(danceSelector.value); if (danceSelector.value == 1) { PlayDance(true); } else { PlayDance(false); } });
        ChangeScenceButton.onClick.AddListener(() => { SceneManager.LoadScene("Scene2", LoadSceneMode.Single); });


    }

    public void PlayDance(bool status)
    {
        if (status)
        {
            djTable.DOFade(0.0f, 1f);
            djTable.clip = music[1];
            djTable.Play();
            djTable.DOFade(0.1f, 1f);
        }
        else
        {

            if (djTable.clip != music[0])
            {
                djTable.DOFade(0.0f, 1f);
                djTable.clip = music[0];
                djTable.Play();
                djTable.DOFade(0.1f, 1f);
            }

        }
        for (int i = 0; i < peopleDance.Length; i++)
        {
            peopleDance[i].ChangeDance(status);
        }
        bunny.ChangeDance(status);
    }
}
