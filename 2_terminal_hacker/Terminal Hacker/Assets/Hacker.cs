using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ShowMainMenu();
	}

    enum Screen { MainMenu, GuessPassword, WinScreen };

    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    Screen currentScreen = Screen.MainMenu;
    int level;
    string password;

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
        else if (currentScreen == Screen.GuessPassword)
        {
            RunGuessPassword(input);
        }
    }

    void RunGuessPassword(string input)
    {
        if (input == password)
        {
            WinScreen();
        }
        else
        {
            GameStart();
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber =
            (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
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
        ChooseLevelPassword();
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter the password, hint: "+ password.Anagram());
    }

    void ChooseLevelPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void WinScreen()
    {
        currentScreen = Screen.WinScreen;
        Terminal.ClearScreen();
        LevelSpecificScreen();
    }

    void LevelSpecificScreen()
    {
        Terminal.WriteLine("Let's play !");
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
      / X / O
  ___/___/___
  O /   / 
___/___/___
  /   /
 /   /  X
");
                break;
            case 2:
                Terminal.WriteLine(@"
  __/'''\
 ]___ 0  }
    /    }
   /~    }
   \____/
   /____\
  (______)
");
                break;
            case 3:
                Terminal.WriteLine(@"
   ..-^~~~^-..
 .~           ~.
(;:           :;)
  ':._     _.:'
       | |
     (=====)
    ((/   \))
");
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine(menuHint);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
