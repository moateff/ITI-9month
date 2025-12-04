#include <iostream>
using namespace std;

int main(){
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

    return 0;
}