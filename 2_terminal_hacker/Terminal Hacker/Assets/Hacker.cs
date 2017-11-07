using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ShowMainMenu();
	}

    enum Screen { MainMenu, GuessPassword, WinScreen };

    Screen currentScreen = Screen.MainMenu;
    int level;

	void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("o~o~o~o~o~o~o~o~o~o~o~o~o~o~o~o~o~o~o~o");
        Terminal.WriteLine("");
        Terminal.WriteLine(" What do you want to play");
        Terminal.WriteLine("");
        Terminal.WriteLine("    1 Tic Tac Toe");
        Terminal.WriteLine("    2 Chess");
        Terminal.WriteLine("    3 Global Thermonuclear War");
        Terminal.WriteLine("");
        Terminal.WriteLine(" Please enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            GameStart();
        }
        else if (input == "2")
        {
            level = 2;
            GameStart();
        }
        else if (input == "3")
        {
            level = 3;
            GameStart();
        }
        else if (input == "42")
        {
            Terminal.WriteLine("That's the ultimate answer. Now what is the question ?");
        }
        else
        {
            Terminal.WriteLine("Please select a correct level");
        }
    }

    void GameStart()
    {
        currentScreen = Screen.GuessPassword;
        Terminal.WriteLine("Please enter your password:");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
