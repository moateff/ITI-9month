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

int main()
{
    enableANSI();

    // 1.
    cout << "Even numbers from 1 to 100:\n";

    for (int i = 1; i <= 100; i++) {
        if (i % 2) continue;
        cout << i << " ";
    }
    cout << endl;

    // 2.
    char choice;
    double num1, num2, result;

    while (true) {
        cout << "\n Simple Menu Calculator \n";
        cout << "a) Add\n";
        cout << "b) Subtract\n";
        cout << "c) Multiply\n";
        cout << "d) Divide\n";
        cout << "e) Exit\n";
        cout << "Enter your choice: ";
        cin >> choice;

        if (choice == 'e' || choice == 'E') {
            cout << "Exiting calculator. Goodbye!\n";
            break;
        }

        if (choice != 'a' && choice != 'b' && choice != 'c' && choice != 'd') {
            cout << "Invalid choice. Please try again.\n";
            continue;
        }

        cout << "Enter first number: ";
        cin >> num1;
        cout << "Enter second number: ";
        cin >> num2;

        switch (choice) {
            case 'a':
                result = num1 + num2;
                cout << "Result: " << result << endl;
                break;
            case 'b':
                result = num1 - num2;
                cout << "Result: " << result << endl;
                break;
            case 'c':
                result = num1 * num2;
                cout << "Result: " << result << endl;
                break;
            case 'd':
                if (num2 != 0)
                    result = num1 / num2;
                else {
                    cout << "Error: Division by zero is not allowed.\n";
                    continue;
                }
                cout << "Result: " << result << endl;
                break;
        }
    }

    // 3.
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

    // 4.
    int score;

    cout << "Enter your score (0 - 100): ";
    cin >> score;

    // Check for valid range
    if (score < 0 || score > 100) {
        cout << "Invalid score! Please enter a value between 0 and 100.\n";
        return 0;
    }

    cout << "Your grade is: ";

    if (score >= 90)
       cout << "A (Excellent)\n";
    else if (score >= 80)
        cout << "B (Very Good)\n";
    else if (score >= 70)
        cout << "C (Good)\n";
    else if (score >= 60)
        cout << "D (Pass)\n";
    else
        cout << "F (Fail)\n";

    // 5.
    int size;

    cout << "Enter the size of the matrix: ";
    cin >> size;

    for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
            if (i == j)
                cout << " * ";
            else
                cout << " - ";
        }
        cout << endl;
    }

    return 0;
}
