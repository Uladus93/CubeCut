using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    public static int _point;
    void Start()
    {
        _point = 0;
    }

    void Update()
    {

        _score.text = _point.ToString();
        if (TimeLess._timeDown <= 0)
        {
            _score.fontSize = 12;
            _score.text = "Your result is equal: " + _point.ToString();
        }
    }
}
