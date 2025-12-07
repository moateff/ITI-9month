#include <iostream>
#include <conio.h>
#include <windows.h>
#include "multiLineEditor.cpp"

#define MAXEMP 10
#define NAMELEN 40
#define ADDRLEN 100
#define MENUCOUNT 4

using namespace std;

void ConsoleCursor(bool showFlag) {
    HANDLE hOut = GetStdHandle(STD_OUTPUT_HANDLE);
    CONSOLE_CURSOR_INFO cursorInfo;

    GetConsoleCursorInfo(hOut, &cursorInfo);

    cursorInfo.bVisible = showFlag;
    cursorInfo.dwSize = 1;

    SetConsoleCursorInfo(hOut, &cursorInfo);
}

struct Employee {
    int id = -1;
    int age = 0;
    double salary = 0;
    double overtime = 0;
    double deduction = 0;
    char gender = ' ';
    char name[NAMELEN] = "";
    char address[ADDRLEN] = "";
};

Employee employeeList[MAXEMP];

void insertEmployee(const Employee& emp, int index) {
    if (index < 0 || index >= MAXEMP) return;

    employeeList[index] = emp;

    // Ensure null-termination
    employeeList[index].name[NAMELEN - 1] = '\0';
    employeeList[index].address[ADDRLEN - 1] = '\0';
}

int displayEmployee(int index) {
    if (index < 0 || index >= MAXEMP || employeeList[index].id == -1) return 1;

    Employee& emp = employeeList[index];
    cout << "Employee ID : " << emp.id << endl;
    cout << "Age         : " << emp.age << endl;
    cout << "Salary      : " << emp.salary << endl;
    cout << "Overtime    : " << emp.overtime << endl;
    cout << "Deduction   : " << emp.deduction << endl;
    cout << "Gender      : " << emp.gender << endl;
    cout << "Name        : " << emp.name << endl;
    cout << "Address     : " << emp.address << endl;

    return 0;
}

Employee inputEmployeeForm() {
    clearScreen();
    ConsoleCursor(true);
    Employee employee;

    // Labels
    gotoxy(5, 2);  cout << "ID        :";
    gotoxy(5, 4);  cout << "Age       :";
    gotoxy(5, 6);  cout << "Salary    :";
    gotoxy(5, 8);  cout << "Deduction :";
    gotoxy(5, 10); cout << "Address   :";

    gotoxy(50, 2);  cout << "Name         :";
    gotoxy(50, 4);  cout << "Gender (M/F) :";
    gotoxy(50, 6);  cout << "Overtime     :";
    
    // Editor setup
    int xPosition[] = {17, 65, 17, 65, 17, 65, 17, 17};
    int yPosition[] = {2, 2, 4, 4, 6, 6, 8, 10};
    int length[] = {30, 30, 30, 30, 30, 30, 30, 30};
    char startRange[] = {'0', 'A', '0', 'A', '0', '0', '0', ' '};
    char endRange[] = {'9', 'z', '9', 'z', '9', '9', '9', '~'};
    int lineNum = 8;

    char** lines = multiLineEditor(xPosition, yPosition, length, startRange, endRange, lineNum);
    
    // Map lines to employee fields
    employee.id = atoi(lines[0]);
    strncpy(employee.name, lines[1], 39); employee.name[39] = '\0';
    employee.age = atoi(lines[2]);
    employee.gender = lines[3][0];
    employee.salary = atof(lines[4]);
    employee.overtime = atof(lines[5]);
    employee.deduction= atof(lines[6]);
    strncpy(employee.address, lines[7], 99); employee.address[99] = '\0';

    // Clean up
    for(int i = 0; i < lineNum; i++) 
        delete[] lines[i];
    delete[] lines;

    ConsoleCursor(false);
    
    return employee;
}

void addEmployeeForm() {
    ConsoleCursor(true);

    int index;
    do {
        cout << "Add new employee at index (1-" << MAXEMP << "): ";
        cin >> index;

        clearScreen();

        if (index < 1 || index > MAXEMP)
            cout << "Invalid index!\n";
    } while (index < 1 || index > MAXEMP);

    Employee emp = inputEmployeeForm();
    insertEmployee(emp, index - 1);

    ConsoleCursor(false);
}

void displayEmployeePage() {
    ConsoleCursor(true);

    int index;
    do {
        cout << "Display employee at index (1-" << MAXEMP << "): ";
        cin >> index;

        clearScreen();

        if (index < 1 || index > MAXEMP)
            cout << "Invalid index!\n";
    } while (index < 1 || index > MAXEMP);

    if(displayEmployee(index - 1) != 0) {
        cout << "No employee found at this index.\n";
    }
    
    ConsoleCursor(false);
    getch();
}

void displayAllEmployeesPage() {
    clearScreen();

    for (int i = 0; i < MAXEMP; ++i) {
        if (employeeList[i].id != -1) {
            displayEmployee(i);
            cout << endl << endl;
        }
    }
    
    getch();
}

void showMenu(int choice) {
    clearScreen();

    const char* menu[] = {
        "Add Employee",
        "Display Employee",
        "Display All Employees",
        "Exit"
    };

    for (int i = 0; i < MENUCOUNT; i++) {
        gotoxy(4, 2 + i * 2);
        if (i == choice) {
            cout << "> " << menu[i];
        } else {
            cout << "  " << menu[i]; 
        }
    }
}

int updatemenuChoice(int key, int &menuChoice) {
    if (key == -32) { // Special keys
        key = getch();

        switch (key) {
            case 72: // UP
                menuChoice = (menuChoice + MENUCOUNT - 1) % MENUCOUNT; // wrap-around
                break;
            case 80: // DOWN
                menuChoice = (menuChoice + 1) % MENUCOUNT; // wrap-around
                break;
            case 71: menuChoice = 0; break; // HOME
            case 79: menuChoice = MENUCOUNT - 1; break; // END
        }

        return 0;
    }
    
    if (key == 13) { // ENTER
        clearScreen();

        switch(menuChoice) {
            case 0: addEmployeeForm(); break;
            case 1: displayEmployeePage(); break;
            case 2: displayAllEmployeesPage(); break;
            case 3: return 1;
        }

        return 0;
    }

    if (key == 27) return 1; // ESC

    return 0;
}

void menu() {
    ConsoleCursor(false);
    int menuChoice = 0;

    while(true) {
        showMenu(menuChoice);
        char key = getch();
        if(updatemenuChoice(key, menuChoice)) break;
    }
}

int main() {
    clearScreen();
    menu();
    clearScreen();
    return 0;
}