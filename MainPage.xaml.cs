﻿using TimerPro.Custom;

namespace TimerPro;

public partial class MainPage : ContentPage
{
    TimerLogic oTimer = new TimerLogic();
    private bool isRunning = false;
    
    public MainPage()
    {
        InitializeComponent();
        Title = "TimerPro";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        btnStart.IsEnabled = true;
        btnStop.IsEnabled = false;
    }

    private void BtnStart_OnClicked(object sender, EventArgs e)
    {
        btnStart.IsEnabled = false;
        btnStop.IsEnabled = true;
        isRunning = true;
        
        Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (isRunning)
            {
                oTimer.SetTickCount();
                lblDisplay.Text = oTimer.GetFormattedString();
            }
            
            return isRunning;
        });
    }

    private void BtnStop_OnClicked(object sender, EventArgs e)
    {
        btnStop.IsEnabled = false;
        btnStart.IsEnabled = true;
        isRunning = false;
    }

    private void btnReset_OnClicked(object sender, EventArgs e)
    {
        oTimer.Reset();
        lblDisplay.Text = oTimer.GetFormattedString();
    }
}