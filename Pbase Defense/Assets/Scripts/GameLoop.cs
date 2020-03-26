using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {
    private SceneStateController _controller = null;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

	// Use this for initialization
	void Start () {
        _controller = new SceneStateController();
        _controller.SetState(new StartState(_controller), false);
	}
	
	// Update is called once per frame
	void Update () {
        _controller.StateUpdate();
	}
}
