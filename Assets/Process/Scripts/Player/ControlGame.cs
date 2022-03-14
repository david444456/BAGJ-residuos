using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProcessMachine
{
    public class ControlGame : MonoBehaviour
    {
        [SerializeField] Text _textUI;

        private int _currentPunctuation = 0;

        private void Start()
        {
            _textUI.text = _currentPunctuation.ToString();
        }

        public void AugmentPuntuation(int points)
        {
            _currentPunctuation += points;
            _textUI.text = _currentPunctuation.ToString();
            print(_currentPunctuation);
            //ui
        }
    }
}
