using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace ProcessMachine
{
    public class ControlGame : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] int limitTime = 130;
        [SerializeField] PlayerMovement playerMovement;

        [Header("UI")]
        [SerializeField] VideoPlayer videoPlayer;
        [SerializeField] GameObject _goFinishGame;
        [SerializeField] Text _textUIScore;
        [SerializeField] Text _textTime;

        public MenuFin MenuFin;
        private int _currentPunctuation = 0;
        private float _currentCountTime = 0;
        private float _actualTime;

        private void Start()
        {
            _actualTime = limitTime;

            _textUIScore.text = _currentPunctuation.ToString();
            _textTime.text = _actualTime.ToString();

        }

        private void Update()
        {
            _currentCountTime += Time.deltaTime;

            if (_currentCountTime > 1 && _actualTime > 0)
            {
                _actualTime--;
                _currentCountTime = 0;
                _textTime.text = _actualTime.ToString();

                if (_actualTime <= 0)
                    FinishGame();
            }
        }

        private bool oneChance = false;

        public void SeeVideo()
        {
            if (oneChance) return;

            oneChance = true;
            _goFinishGame.SetActive(true);
            videoPlayer.Play();
            Destroy(_goFinishGame, 12);
        }

        private void FinishGame()
        {
            //print("Finish game!");
            MenuFin.Setup(_currentPunctuation);
            playerMovement.enabled = false;
            playerMovement.GetComponent<PlayerInteractProcess>().enabled = false;
            playerMovement.GetComponentInChildren<animationStateController>().enabled = false;

            //_goFinishGame.SetActive(true);
        }

        public void AugmentPuntuation(int points)
        {
            _currentPunctuation += points;
            _textUIScore.text = _currentPunctuation.ToString();
            print(_currentPunctuation);
            //ui
        }
    }
}
