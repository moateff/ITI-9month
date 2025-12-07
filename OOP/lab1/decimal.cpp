#include <iostream>
using namespace std;

int main(){
    int decimal;
    
    cout << "Enter decimal number : ";
    cin >> decimal;

    cout << "Number in hexadecimal format = 0x" << hex << decimal << endl;
    cout << "Number in octal format = 0h" << oct << decimal << endl;

    return 0;
}