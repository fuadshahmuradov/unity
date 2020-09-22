using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "Type 'menu' to go to menu screen";
    string[] level1Passwords = { "cousin", "grandmother", "niece", "uncle", "twin" };
    string[] level2Passwords = { "diabetes", "cancer", "ebola", "corona", "alzheimer" };
    string[] level3Passwords = { "negotiation", "contract", "ceasefire", "organization", "election" };

    const string menuHintAZ = "Menyuya qayıtmaq üçün 'menyu' yaz";
    string[] level1PasswordsAZ = { "bacı", "qardaş", "ata", "dayı", "ana" };
    string[] level2PasswordsAZ = { "sincab", "öküz", "tısbağa", "qurbağa", "kirpi" };
    string[] level3PasswordsAZ = { "cahangir", "firdovsi", "hüseyn", "xudaverdi", "mehdi" };

    // Game state
    int level, word=0;

    enum Screen { LanguageMenu, MainMenu, MainMenuAZ, Password, PasswordAZ, Win, WinAZ };
    Screen currentScreen;
    string password;

    void Start()
    {
        SelectLanguage();
    }

    void SelectLanguage()
    {
        currentScreen = Screen.LanguageMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("ANAGRAM HACKER!\n");
        Terminal.WriteLine("1. Azərbaycanca");
        Terminal.WriteLine("2. English");
        Terminal.WriteLine("\n");
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the Family");
        Terminal.WriteLine("Press 2 for the Diseases");
        Terminal.WriteLine("Press 3 for the Political");
        Terminal.WriteLine("NOTE: Always use lower-case letters");
        Terminal.WriteLine("NOTE2: Press '0' for language selection");
        Terminal.WriteLine("\nEnter your selection: ");
    }

    void ShowMainMenuAZ()
    {
        currentScreen = Screen.MainMenuAZ;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hansı sistemə girmək istəyirsən?");
        Terminal.WriteLine("1. Ailə");
        Terminal.WriteLine("2. Heyvanlar");
        Terminal.WriteLine("3. İnsan adları");
        Terminal.WriteLine("QEYD: Həmişə kiçik hərflər işlət.");
        Terminal.WriteLine("QEYD2: Dil seçmək üçün '0' yaz.");
        Terminal.WriteLine("\nSeçimin: ");
    }

    void OnUserInput(string input)
    {
        // TODO More easter eggs
        if (input == "menu")
        {
            word = 0;
            ShowMainMenu();
        }
        if (input == "menyu")
        {
            word = 0;
            ShowMainMenuAZ();
        }
        if (input == "0")
        {
            SelectLanguage();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.MainMenuAZ)
        {
            RunMainMenuAZ(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.PasswordAZ)
        {
            CheckPasswordAZ(input);
        }
        else if (currentScreen == Screen.LanguageMenu)
        {
            if(input=="1")
            {
                ShowMainMenuAZ();
            }
            else if(input =="2")
            {
                ShowMainMenu();
            }
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Please select a level, Mr. Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
            Terminal.WriteLine(menuHint);
        }
    }

    void RunMainMenuAZ(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPasswordAZ();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Bir mövzu seçin, Cənab Bond!");
        }
        else
        {
            Terminal.WriteLine("Düzgün mövzu seçin");
            Terminal.WriteLine(menuHintAZ);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        GeneratePasswords();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }
    void AskForPasswordAZ()
    {
        currentScreen = Screen.PasswordAZ;
        Terminal.ClearScreen();
        GeneratePasswordsAZ();
        Terminal.WriteLine("Parolu daxil et, ipucu: " + password.Anagram());
        Terminal.WriteLine(menuHintAZ);
    }

    void GeneratePasswords()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[word];
                break;
            case 2:
                password = level2Passwords[word];
                break;
            case 3:
                password = level3Passwords[word];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
    void GeneratePasswordsAZ()
    {
        switch (level)
        {
            case 1:
                password = level1PasswordsAZ[word];
                break;
            case 2:
                password = level2PasswordsAZ[word];
                break;
            case 3:
                password = level3PasswordsAZ[word];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password && word!=5)
        {
            word++;
        }
        else if (word == 5 )
        {
            DisplayWinScreen();
        }
        else
        {
            if(input == "fuad" || input == "shahmuradov" || input == "fuadshahmuradov" || input == "fuad shahmuradov")
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Yes, " + input + " is the developer.");
                Terminal.WriteLine(menuHintAZ);
            }
            else
            {
                AskForPassword();
            }
        }
    }

    void CheckPasswordAZ(string input)
    {
        
        if (input == password && word!=5)
        {
            word++;
        }
        else if (word == 5)
        {
            DisplayWinScreenAZ();
        }
        else
        {
            if (input == "eyyub yaqubov" || input == "eyyubyaqubov" || input == "eyyub")
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Mənə dəniz verin?");
                Terminal.WriteLine(menuHintAZ);
            }
            else if (input == "fuad" || input == "shahmuradov" || input == "fuadshahmuradov" || input == "fuad shahmuradov")
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Bəli, "+ input +" bu oyunun yaradıcısıdır.");
                Terminal.WriteLine(menuHintAZ);
            }
            else if (input == "gunay" || input == "karimli" || input == "gunaykarimli" || input == "gunay karimli")
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Nt ae?");
                Terminal.WriteLine(menuHintAZ);
            }
            else
            {
                AskForPasswordAZ();
            }
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }
    void DisplayWinScreenAZ()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelRewardAZ();
        Terminal.WriteLine(menuHintAZ);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("You have hacked into FAMILY.");
                Terminal.WriteLine("Play again for a greater challenge!");
                Terminal.WriteLine(@"
           ~O
           /|\
        ~o/ | \o    ~o/    _o
        /|  |\ |\   /|      |\
        / \ |// >   / \    / >
");
                break;
            case 2:
                Terminal.WriteLine("You have hacked into DISEASES.");
                Terminal.WriteLine("Play again for a greater challenge!");
                Terminal.WriteLine(@"
  .---.
 /     \
( () () )
 \  M  / 
  |HHH|
  `---'
");
                break;
            case 3:
                Terminal.WriteLine("You have hacked into POLITICAL.");
                Terminal.WriteLine(@"
 ^^   // \                    ~
      ][O]    ^^      ,-~ ~
   /''-I_I         _II____
__/_  /   \ ______/ ''   /'\_,__
  | II--'''' \,--:--..,_/,.-{ },
; '/__\,.--';|   |[] .-.| O{ _ }
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
    void ShowLevelRewardAZ()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("AİLƏ sisteminə giriş etdin.");
                Terminal.WriteLine("Daha çətin sistemləri yoxla!");
                Terminal.WriteLine(@"
           ~O
           /|\
        ~o/ | \o    ~o/    _o
        /|  |\ |\   /|      |\
        / \ |// >   / \    / >
");
                break;
            case 2:
                Terminal.WriteLine("HEYVANLAR sisteminə giriş etdin.");
                Terminal.WriteLine("Daha çətin sistemləri yoxla!");
                Terminal.WriteLine(@"
     ,--.   ,--.
     \  /-~-\  /
      )' a a `(
     (  ,---.  )
      `(_o_o_)'
        )`-'( 
");
                break;
            case 3:
                Terminal.WriteLine("İNSAN ADLARI sisteminə giriş etdin.");
                Terminal.WriteLine(@"
  o    _______________
 /\_  _|             |
_\__`[_______________|
] [ \, ][         ][
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
