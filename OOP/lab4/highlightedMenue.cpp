#include <iostream>
#include <conio.h>   
#include <windows.h>
using namespace std;

void gotoxy(int x, int y) {
    COORD coord;
    coord.X = x;
    coord.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

void textattr(int i) {
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}

void showMenu(int choice) {
    system("cls"); 
    char menu[3][5] = {"New ", "Open", "Exit"};

    gotoxy(2, 0);
    cout << "   MENU   \n\n";
    for (int i = 0; i < 3; ++i) {
        gotoxy(2, 2 + i * 2);
        if (i == choice) {
            textattr(112); 
            cout << "   " << menu[i] << "   " << endl;
            textattr(7);   
        } else {
            cout << "   " << menu[i] << endl;
        }
    }
}

int updateChoice(int key, int *choice) {
    if (key == 0 || key == 224) { // Arrow keys or special keys
        key = getch();
        switch (key) {
            case 72: // UP arrow
                (* choice)--;
                if ((* choice) < 0) (* choice) = 2; // wrap to last
                break;
            case 80: // DOWN arrow
                (* choice)++;
                if ((* choice) > 2) (* choice) = 0; // wrap to first
                break;
            case 71: // HOME key
                (* choice) = 0;
                break;
            case 79: // END key
                (* choice) = 2;
                break;
        }
    }
    else if (key == 13) { // ENTER
        system("cls");
        if ((* choice) == 0)
            cout << "You selected: New\n";
        else if ((* choice) == 1)
            cout << "You selected: Open\n";
        else if ((* choice) == 2) {
            cout << "Exiting program...\n";
            return 1;
        }

        cout << "\nPress any key to return to the menu...";
        getch();
    }
    else if (key == 27) { // ESC
        system("cls");
        cout << "Exiting program...\n";
        return 1;
    }
    return 0;
}

int main() {
    int choice = 0;
    int exitFlag = 0;
    char key;

    do {
        showMenu(choice);
        key = getch();
        exitFlag = updateChoice(key, &choice);
    } while (!exitFlag);

    return 0;
}
