#include <bits/stdc++.h>
using namespace std;

int main() {
    int t;
    cin >> t;

    while (t--) {
        int i, j, a, b;

        cin >> i >> a;
        cin >> j >> b;

        int angle1 = (i == 1) ? a : 90 - a;
        int angle2 = (i == 2) ? a : 90 - a;
        int angle3 = (j == 3) ? b : 180 - b - angle2;
        int angle4 = (j == 4) ? b : 180 - b - angle2;

        if (angle1 <= 0 || angle1 >= 90 || angle2 <= 0 || angle2 >= 90) {
            cout << -1 << endl;
            continue;
        }
        
        if (angle3 <= 0 || angle3 >= 180 || angle4 <= 0 || angle4 >= 180) {
            cout << -1 << endl;
            continue;
        }

        cout << angle1 << ' ' << angle2 << ' ' << angle3 << ' ' << angle4 << endl;
    }

    return 0;
}
