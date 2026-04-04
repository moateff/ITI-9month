#include <bits/stdc++.h>
using namespace std;

int main() {
    int t;
    cin >> t;

    cout << fixed << setprecision(6);

    while (t--) {
        int xa, ya;
        cin >> xa >> ya;

        int xg, yg;
        cin >> xg >> yg;

        float ag = sqrt((xg - xa) * (xg - xa) + (yg - ya) * (yg - ya));

        int s;
        cin >> s;
        float ad = sqrt(s);

        float gd = ad - ag;
        float gf = gd;

        cout << 0.5 * gd * gf << endl;
    }

    return 0;
}