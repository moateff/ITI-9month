#include <iostream>
#include <conio.h>
#include <windows.h>

#define MAXEMP 10

using namespace std;

struct Employee {
    int id;
    int age;
    double salary;
    double overtime;
    double deduction;
    char gender;
    char name[40];
    char address[100];
};

Employee employeeList[10];

void initList() {
    for (int i = 0; i < 10; i++)
        employeeList[i].id = -1;
}

void insertEmployee(Employee employee, int index) {
    if(index < 0 || index >= MAXEMP) return;

    employeeList[index].id = employee.id;
    employeeList[index].age = employee.age;
    employeeList[index].salary = employee.salary;
    employeeList[index].overtime = employee.overtime;
    employeeList[index].deduction = employee.deduction;
    employeeList[index].gender = employee.gender;

    strncpy(employeeList[index].name, employee.name, 39);
    employeeList[index].name[39] = '\0';

    strncpy(employeeList[index].address, employee.address, 99);
    employeeList[index].name[99] = '\0';
}

void displayEmployee(int index) {
    cout << "Employee id: " << employeeList[index].id << endl;
    cout << "Employee age: " << employeeList[index].age << endl;
    cout << "Employee salary: " << employeeList[index].salary << endl;
    cout << "Employee overtime: " << employeeList[index].overtime << endl;
    cout << "Employee deduction: " << employeeList[index].deduction << endl;
    cout << "Employee gender: " << employeeList[index].gender << endl;
    cout << "Employee name: " << employeeList[index].name << endl;
    cout << "Employee address: " << employeeList[index].address << endl;
}

void displayEmployeeALL() {
    for (int i = 0; i < MAXEMP; i++) {
        if (employeeList[i].id != -1) {
            displayEmployee(i);
            cout << endl;
        }
    }
}

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
    char menu[4][15] = {"    ADD    ", "  Display  ", "Display ALL", "   Exit    "};

    system("cls");
    gotoxy(2, 0);
    cout << "      MENU      ";
    for (int i = 0; i < 4; ++i) {
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

Employee inputEmployeeForm() {
    Employee employee;

    system("cls");

    // Left column labels
    gotoxy(5, 2);  cout << "ID:";
    gotoxy(5, 4);  cout << "Age:";
    gotoxy(5, 6);  cout << "Salary:";
    gotoxy(5, 8);  cout << "Deduction:";
    gotoxy(5, 10); cout << "Address:";

    // Right column labels
    gotoxy(30, 2);  cout << "Name:";
    gotoxy(30, 4);  cout << "Gender (M/F):";
    gotoxy(30, 6);  cout << "Overtime:";

    // Input fields
    gotoxy(15, 2);  cin >> employee.id;
    gotoxy(45, 2);  cin.ignore(); cin.getline(employee.name, 40);

    gotoxy(15, 4);  cin >> employee.age;
    gotoxy(45, 4);  cin >> employee.gender;
    while(employee.gender != 'M' && employee.gender != 'F' &&
          employee.gender != 'm' && employee.gender != 'f') {
        gotoxy(45, 4); cout << "   "; // clear previous input
        gotoxy(45, 4); cin >> employee.gender;
    }

    gotoxy(15, 6);  cin >> employee.salary;
    gotoxy(45, 6);  cin >> employee.overtime;

    gotoxy(15, 8);  cin >> employee.deduction;
    gotoxy(15, 10); cin.ignore(); cin.getline(employee.address, 100);

    gotoxy(0, 20);

    return employee;
}

void addForm() {
    int index;

    do {
        cout << "Add new employee in index from 1 to 10: ";
        cin >> index;
        if (index < 1 || index > 10){
            cout << "Invalid index" << endl;
        }
    } while (index < 1 || index > 10);

    Employee employee = inputEmployeeForm();
    insertEmployee(employee, index - 1);
}

void displayPage() {
    int index;

    do {
        cout << "Display employee in index from 1 to 10: ";
        cin >> index;
        if (index < 1 || index > 10){
            cout << "Invalid index" << endl;
        }
    } while (index < 1 || index > 10);

    displayEmployee(index - 1);
}

int updateChoice(int key, int *choice) {
    if (key == -32) { // Arrow keys or special keys
        key = getch();
        switch (key) {
            case 72: // UP arrow
                (* choice)--;
                if ((* choice) < 0) (* choice) = 3; // wrap to last
                break;
            case 80: // DOWN arrow
                (* choice)++;
                if ((* choice) > 3) (* choice) = 0; // wrap to first
                break;
            case 71: // HOME key
                (* choice) = 0;
                break;
            case 79: // END key
                (* choice) = 3;
                break;
        }
    }
    else if (key == 13) { // ENTER
        system("cls");
        switch(*choice) {
            case 0: addForm(); break;
            case 1: displayPage(); break;
            case 2: displayEmployeeALL(); break;
            case 3: cout << "Exiting program...\n"; return 1;
        }

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
    initList();

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
