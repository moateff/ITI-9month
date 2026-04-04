#include <iostream>
using namespace std;

int main() {
    int A, H;
    cin >> A >> H;

    if (A > H) 
        cout << 'A' << endl;
    else if (A < H) 
        cout << 'H' << endl;
    else 
        cout << 'D' << endl;
        
    return 0;
}