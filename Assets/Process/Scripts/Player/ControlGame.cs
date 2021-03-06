using Character;
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
        [SerializeField] private bool _setTimeToZero = true;
        [SerializeField] CharacterMovement playerMovement;

        [Header("UI")]
        [SerializeField] VideoPlayer videoPlayer;
        [SerializeField] GameObject _goFinishGame;
        [SerializeField] Text _textUIScore;
        [SerializeField] Text _textTime;

        public MenuFin MenuFin;
        private int _currentPunctuation = 0;
        private float _currentCountTime = 0;
        private float _actualTime;
        public GameObject VolumeOn;
        public GameObject VolumeOff;
        public GameObject Home;
        private AudioSource Music;

        private void Start()
        {
            if(_setTimeToZero)
                Time.timeScale = 0;
            
            _actualTime = limitTime;

            _textUIScore.text = _currentPunctuation.ToString();
            _textTime.text = _actualTime.ToString();
            Music = this.GetComponent<AudioSource>();
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

        public void SetTimeToNormal()
        {
            Time.timeScale = 1;
            if(VolumeOn != null) VolumeOn.SetActive(true);
            if (Home != null) Home.SetActive(true);
        }

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
            MenuFin.Setup(_currentPunctuation);

            DesactiveControlPlayer();
        }

        private void DesactiveControlPlayer()
        {
            playerMovement.enabled = false;
            playerMovement.GetComponent<PlayerInteractProcess>().enabled = false;
            playerMovement.GetComponentInChildren<CharacterAnimation>().enabled = false;
        }

        public void AugmentPuntuation(int points)
        {
            _currentPunctuation += points;
            _textUIScore.text = _currentPunctuation.ToString();
        }

        public void TurnOnOffVolume()
        {
            if (VolumeOn.activeSelf && (VolumeOn != null) && VolumeOff != null)
            {
                VolumeOn.SetActive(false);
                VolumeOff.SetActive(true);
                Music.Pause();
            }
            else if((VolumeOn != null) && VolumeOff != null)
            {
                VolumeOn.SetActive(true);
                VolumeOff.SetActive(false);
                Music.Play();
            }
        }
    }
}
