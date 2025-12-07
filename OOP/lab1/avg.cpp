#include <iostream>
using namespace std;

int main(){
    int num1, num2;

    cout << "Enter first number = ";
    cin >> num1;
    cout << "Enter second number = ";
    cin >> num2;
    
    cout << "num1 + num2 = " << num1 + num2 << endl;
    cout << "num1 - num2  = " << num1 - num2 << endl;
    cout << "avg(num1, num2) = " << (num1 + num2) / 2 << endl;

    return 0;
}