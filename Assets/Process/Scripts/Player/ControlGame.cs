using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class ControlGame : MonoBehaviour
    {
        private int _currentPunctuation = 0;

        public void AugmentPuntuation(int points)
        {
            _currentPunctuation += points;
            print(_currentPunctuation);
            //ui
        }
    }
}
