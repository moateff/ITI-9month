#include <iostream>
using namespace std;
    
bool isEven (int num) {
    return num % 2 == 0;
}
    
int main () {
    int weight;
    
    cin >> weight;
    
    if (isEven(weight) && weight > 2) {
        cout << "YES" << endl;
    } else {
        cout << "NO" << endl;
    }
    
    return 0;
}