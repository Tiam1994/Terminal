using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{   
    enum Screen {Menu, Password, Win};

    Screen currentScreen = Screen.Menu;
    int level;
    string password;
    string[] level1Passwords = {"ратуша", "улица", "парк", "сквер", "проспект"};
    string[] level2Passwords = {"клерк", "хранилище", "доллар", "кредит", "золото"};
    string[] level3Passwords = {"танк", "казарма", "рота", "генерал", "рядовой" };

    const string menuHint = "Для возврата напишите - 'меню'";

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.Menu;
        level = 0;

        Terminal.ClearScreen();
        Terminal.WriteLine("Какой терминал вы хотите взломать?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Введите 1 - городской терминал");
        Terminal.WriteLine("Введите 2 - банковский терминал");
        Terminal.WriteLine("Введите 3 - военный терминал");
    }

    void LevelSelection(string input)
    {
        int index = Random.Range(0,5);

        switch (input)
        {
            case "1":
                level = 1;
                password = level1Passwords[index];
                GameStart();
                break;
            case "2":
                level = 2;
                password = level2Passwords[index];
                GameStart();
                break;
            case "3":
                level = 3;
                password = level3Passwords[index];
                GameStart();
                break;
            case "меню":
                ShowMainMenu();
                break;
            default:
                Terminal.WriteLine("Ваш выбор некорректный");
                break;
        }
    }

    void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                Terminal.WriteLine(
            @"
      _______
     |xxxxxxx|  _______
     |xxxxxxx| | [][]  |
  ______xxxxx| |[][][] |
 |++++++|xxxx| | [][][]|
 |++++++|_________ [][]|
 |++++++|=|=|=|=|=| [] |
 |++++++|=|=|=|=|=|[][]|
_|++HH++|  _HHHH__|   __");
                Terminal.WriteLine("Пароль верный. Город спасен!");
                Terminal.WriteLine(menuHint);
                break;
            case 2: 
                Terminal.WriteLine(
                    @"
         __________
        /\____;;___\
       | /         /
       `. ())oo() .
        |\(%()*^^()^\
       %| |-%-------|
      % \ | %  ))   |
      %  \|%________|
       %%%%");
                Terminal.WriteLine("Пароль верный. Ваш сундук с золотом!");
                Terminal.WriteLine(menuHint);
                break;
            case 3:
                Terminal.WriteLine(
                    @"
            _,-~~/~  `---.
          _/_,---(   ,    )
       __/        < /   )  \___
--=;;;'====---------------===;;;===--
       \/  ~'~'~'~'~'~\~'~)~' /
        (_(   \  (     >    \)
         \_(_ <         > _ > '
            ~ `-i' ::>|--'
                I;|.|.|
              (` ^''`-' )");
                Terminal.WriteLine("Пароль верный. Вы взорвали бомбу!");
                Terminal.WriteLine(menuHint);
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            Terminal.WriteLine("Попробуйте еще раз...");
        }
}

    void OnUserInput(string input)
    {
        if(input == "меню")
        {
            ShowMainMenu();
        }
        else if(currentScreen == Screen.Menu)
        {
            LevelSelection(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        
    }

    void GameStart()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Вы выбрали городской терминал.");
                Terminal.WriteLine("В терменале бомба!");
                Terminal.WriteLine("Что бы ее обезвредить и спасити");
                Terminal.WriteLine("город, вам нужно угадать пароль.");
                break;
            case 2:
                Terminal.WriteLine("Вы выбрали банковский терминал.");
                Terminal.WriteLine("В сейфе находится сундук с золотом.");
                Terminal.WriteLine("Вам нужно угадать пароль, чтоб");
                Terminal.WriteLine("открыть сейф и забрать золото");
                break;
            case 3:
                Terminal.WriteLine("Вы выбрали военный терминал.");
                Terminal.WriteLine("Вам нужно угадать пароль что бы");
                Terminal.WriteLine("взорвать вражескую военную базу.");
                break;
        }
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Подсказка: " + password.Anagram());
        Terminal.WriteLine("Введите пароль:");
        




    }
}
