#include <iostream>
using namespace std;

int main() {
    int n, m;
    cin >> n >> m;

    int count = 0;

    // a^2 <= n
    for (int a = 0; a * a <= n; a++) {
        int b = n - a * a;  // derived from: a^2 + b = n

        // b must be non-negative and satisfy the second equation
        if (b >= 0 && a + b * b == m) {
            count++;
        }
    }

    cout << count << endl;
    return 0;
}
