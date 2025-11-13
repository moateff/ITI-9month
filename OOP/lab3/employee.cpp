#include <iostream>
using namespace std;

int main() {
    char employee_name[50];   
    int employee_age;
    double employee_salary;
    long employee_number;

    cout << "Please enter employee name: ";
    cin >> employee_name;  

    cout << "Please enter employee age: ";
    cin >> employee_age;

    cout << "Please enter employee salary: ";
    cin >> employee_salary;

    cout << "Please enter employee number: ";
    cin >> employee_number;

    cout << "\nEmployee Details:\n";
    cout << "Name   : " << employee_name << endl;
    cout << "Age    : " << employee_age << endl;
    cout << "Salary : " << employee_salary << endl;
    cout << "Number : " << employee_number << endl;

    return 0;
}
