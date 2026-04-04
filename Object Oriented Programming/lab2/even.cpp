#include <iostream>
using namespace std;

int main(){
    cout << "Even numbers from 1 to 100:\n";

    for (int i = 1; i <= 100; i++) {
        if (i % 2) continue;
        cout << i << " ";
    }

    return 0;
}