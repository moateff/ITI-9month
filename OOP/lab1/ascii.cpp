#include <iostream>
using namespace std;

int main(){
    char character;

    cout << "Enter a character : ";
    cin >> character;

    cout << "Character in ASCII representation = " << dec << int(character) << endl;
    
    return 0;
}