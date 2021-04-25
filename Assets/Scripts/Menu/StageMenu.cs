using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Song
{
    public string name;
    public string composer;
    public int bpm;
    public Sprite sprite;
}

public class StageMenu : MonoBehaviour
{
    [SerializeField] Song[] songList = null;

    [SerializeField] Text txtSongName = null;
    [SerializeField] Text txtSongComposer = null;
    [SerializeField] Image imgDisk = null;

    [SerializeField] GameObject TitleMenu = null;

    int currentSong = 0;

    private void Start()
    {
        SettingSong();
    }

    public void BtnNext()
    {
        AudioManager.instance.PlaySfx("Touch");
        
        if (++currentSong > songList.Length - 1)
        {
            currentSong = 0;
        }

        SettingSong();
    }

    public void BtnPrior()
    {
        AudioManager.instance.PlaySfx("Touch");

        if (--currentSong < 0)
        {
            currentSong = songList.Length - 1;
        }

        SettingSong();
    }

    void SettingSong()
    {
        txtSongName.text = songList[currentSong].name;
        txtSongComposer.text = songList[currentSong].composer;
        imgDisk.sprite = songList[currentSong].sprite;

        AudioManager.instance.PlayBgm("BGM" + currentSong);
    }

    public void BtnBack()
    {
        TitleMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BtnPlay()
    {
        var t_bpm = songList[currentSong].bpm;

        GameManager.instance.GameStart(currentSong, t_bpm);
        gameObject.SetActive(false);
    }
}
