using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeLess : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stopWatch;

    [SerializeField] public static float _timeDown = 20f;
    [SerializeField] private GameObject _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeDown();
    }

    public void TimeDown()
    {
        if (_timeDown > 0)
        {
            _timeDown -= Time.deltaTime;
            _stopWatch.text = Mathf.Round(_timeDown).ToString();
            if (_timeDown <= 10.5)
            {
                _stopWatch.color = Color.red;
            }
        }
        else
        {
            _timeDown -= Time.deltaTime;
            _stopWatch.fontSize = 40;
            _stopWatch.text = "End!";
            Destroy(_player);
            _timeDown = 0;
        }
    }
}
