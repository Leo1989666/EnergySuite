﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace EnergySuite
{
    public class ExampleEnegrySuite : MonoBehaviour
    {
        #region Public Vars

        public Text CurrentAmountText;
        public Text TimeLeftText;
        public Slider TimeLeftSlider;
        public Button AddEnergyButton;
        public Button UseEnergyButton;

        #endregion

        #region Private Vars

        #endregion

        void OnEnable()
        {
            Time.timeScale = 0;
            EnergySuiteManager.OnEnergyChanged += OnEnergyAdded;
            EnergySuiteManager.OnTimeLeftChanged += OnTimeLeftChanged;
            AddEnergyButton.onClick.AddListener(OnAddEnergyButtonClicked);
            UseEnergyButton.onClick.AddListener(OnUseEnergyButtonClicked);
            CurrentAmountText.text = EnergySuiteManager.Amount + "/" + EnergySuiteConfig.MaxAmount;
        }

        void OnDisable()
        {
            EnergySuiteManager.OnEnergyChanged -= OnEnergyAdded;
            EnergySuiteManager.OnTimeLeftChanged -= OnTimeLeftChanged;
            AddEnergyButton.onClick.RemoveListener(OnAddEnergyButtonClicked);
            UseEnergyButton.onClick.RemoveListener(OnUseEnergyButtonClicked);
        }

        void Start()
        {
        }

        #region Event Handlers

        void OnAddEnergyButtonClicked()
        {
            EnergySuiteBehaviour.Instance.AddEnergy(1, false);
        }

        void OnUseEnergyButtonClicked()
        {
            EnergySuiteBehaviour.Instance.UseEnergy(1);
        }

        void OnEnergyAdded(int amount)
        {
            CurrentAmountText.text = amount + "/" + EnergySuiteConfig.MaxAmount;
        }

        void OnTimeLeftChanged(TimeSpan timeLeft)
        {
            string formatString = string.Format("{0:00}:{1:00}", timeLeft.Minutes, timeLeft.Seconds);
            TimeLeftText.text = formatString;

            TimeLeftSlider.value = EnergySuiteManager.ConvertToSliderValue(timeLeft);
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
