using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{   
    enum Screen {Menu, Password, Win};

    Screen currentScreen = Screen.Menu;
    int level;
    string password;
    string[] level1Passwords = {"������", "�����", "����", "�����", "��������"};
    string[] level2Passwords = {"�����", "���������", "������", "������", "������"};
    string[] level3Passwords = {"����", "�������", "����", "�������", "�������" };

    const string menuHint = "��� �������� �������� - '����'";

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.Menu;
        level = 0;

        Terminal.ClearScreen();
        Terminal.WriteLine("����� �������� �� ������ ��������?");
        Terminal.WriteLine("");
        Terminal.WriteLine("������� 1 - ��������� ��������");
        Terminal.WriteLine("������� 2 - ���������� ��������");
        Terminal.WriteLine("������� 3 - ������� ��������");
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
            case "����":
                ShowMainMenu();
                break;
            default:
                Terminal.WriteLine("��� ����� ������������");
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
                Terminal.WriteLine("������ ������. ����� ������!");
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
                Terminal.WriteLine("������ ������. ��� ������ � �������!");
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
                Terminal.WriteLine("������ ������. �� �������� �����!");
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
            Terminal.WriteLine("���������� ��� ���...");
        }
}

    void OnUserInput(string input)
    {
        if(input == "����")
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
                Terminal.WriteLine("�� ������� ��������� ��������.");
                Terminal.WriteLine("� ��������� �����!");
                Terminal.WriteLine("��� �� �� ����������� � �������");
                Terminal.WriteLine("�����, ��� ����� ������� ������.");
                break;
            case 2:
                Terminal.WriteLine("�� ������� ���������� ��������.");
                Terminal.WriteLine("� ����� ��������� ������ � �������.");
                Terminal.WriteLine("��� ����� ������� ������, ����");
                Terminal.WriteLine("������� ���� � ������� ������");
                break;
            case 3:
                Terminal.WriteLine("�� ������� ������� ��������.");
                Terminal.WriteLine("��� ����� ������� ������ ��� ��");
                Terminal.WriteLine("�������� ��������� ������� ����.");
                break;
        }
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("���������: " + password.Anagram());
        Terminal.WriteLine("������� ������:");
        




    }
}
