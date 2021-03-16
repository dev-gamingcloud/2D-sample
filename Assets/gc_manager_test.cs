using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gamingCloud;
using gamingCloud.Network;
using UnityEngine.UI;

public class gc_manager_test : GCMultiPlayer
{

    public Text txt;
    public GameObject panel;

    private void Start()
    {
        Debug.Log("Hi");
        panel.SetActive(true);
        ConnectToMultiPlayerServer();
    }

    public override void ConnectedToServer()
    {
        txt.text = "waiting for join to room!";
        RoomSetting room = new RoomSetting();
        JoinToServer(room);
    }

    public override void OnJoined()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.Find("SpawnPoint-" + spawnIndex).transform.position;
        panel.SetActive(false);
    }

    public override void OnError(multiplayerErrors netError)
    {
        Debug.LogError(netError);
    }

    private void OnDestroy()
    {
        disconnect();
    }

}
