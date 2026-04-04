#include <iostream>
using namespace std;

int main() {
    int N;
    cin >> N;

    int d1 = N / 10;   // tens digit
    int d2 = N % 10;   // ones digit

    if (d1 % 2 == 0 && d2 % 2 == 0)
        cout << "YES";
    else
        cout << "NO";

    return 0;
}
