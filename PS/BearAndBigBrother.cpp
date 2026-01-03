#include <iostream>

using namespace std;

int main () {
    int LimakWeight, BobWeight;

    cin >> LimakWeight >> BobWeight;

    int yearCount = 0;
    while (LimakWeight <= BobWeight) {
        LimakWeight *= 3;
        BobWeight *= 2;
        yearCount++;
    }
    
    cout << yearCount << endl;
    return 0;
}