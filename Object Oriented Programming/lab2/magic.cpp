#include <iostream>
#include <windows.h>
using namespace std;

void gotoxy(int x, int y) {
    COORD coord;
    coord.X = x;
    coord.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

void enableANSI() {
    HANDLE hOut = GetStdHandle(STD_OUTPUT_HANDLE);
    DWORD dwMode = 0;
    GetConsoleMode(hOut, &dwMode);
    dwMode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
    SetConsoleMode(hOut, dwMode);
}

int main(){
    enableANSI();

    int SIZE;

    cout << "Enter the size of the magic square (odd number only): ";
    cin >> SIZE;

    if (SIZE % 2 == 0 || SIZE < 1) {
        cout << "Invalid size! Please enter a positive odd number.\n";
        return 0;
    }

    int col = SIZE / 2;
    int row = 0;

    cout << "\nMagic Square of size " << SIZE << "x" << SIZE << ":\n";

    for (int n = 1; n <= SIZE * SIZE; n++) {
        gotoxy(col * 4, 4 + row * 2);
        cout << "\033[31m" << n << "\033[0m";

        int old_col = col;
        int old_row = row;

        col = (col + 1) % SIZE;
        row = (row - 1 + SIZE) % SIZE;

        if (n % SIZE == 0) {
            col = old_col;
            row = (old_row + 1) % SIZE;
        }
    }

    gotoxy(0, 3 + SIZE * 2);

    return 0;
}